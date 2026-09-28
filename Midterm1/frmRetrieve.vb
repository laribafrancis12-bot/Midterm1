Imports ClosedXML.Excel
Imports System.IO

Public Class frmRetrieve

    Private excelFile As String =
        Path.Combine(Application.StartupPath, "VolunteerDatabase.xlsx")


    Private Sub frmRetrieve_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dgvDeleted.ReadOnly = True
        dgvDeleted.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvDeleted.MultiSelect = False
        dgvDeleted.AllowUserToAddRows = False

        LoadDeleted()

    End Sub


    '========================================
    ' LOAD DELETED VOLUNTEERS
    '========================================
    Private Sub LoadDeleted()

        dgvDeleted.Rows.Clear()
        dgvDeleted.Columns.Clear()

        dgvDeleted.Columns.Add("ID", "ID")
        dgvDeleted.Columns.Add("Name", "Name")
        dgvDeleted.Columns.Add("City", "City")
        dgvDeleted.Columns.Add("Days", "Days Available")

        Using workbook As New XLWorkbook(excelFile)

            Dim ws As IXLWorksheet = workbook.Worksheet("DeletedVolunteers")

            Dim lastRow As IXLRow = ws.LastRowUsed()

            If lastRow Is Nothing Then Exit Sub

            For row As Integer = 2 To lastRow.RowNumber()

                If String.IsNullOrWhiteSpace(ws.Cell(row, 1).GetString()) Then
                    Continue For
                End If

                dgvDeleted.Rows.Add(
                    ws.Cell(row, 1).GetString(),
                    ws.Cell(row, 2).GetString(),
                    ws.Cell(row, 3).GetString(),
                    GetDays(ws, row))

            Next

        End Using

    End Sub


    '========================================
    ' GET DAYS FROM EXCEL
    '========================================
    Private Function GetDays(ws As IXLWorksheet, row As Integer) As String

        Dim dayNames() As String =
            {"Monday", "Tuesday", "Wednesday", "Thursday",
             "Friday", "Saturday", "Sunday"}

        Dim days As New List(Of String)

        For i As Integer = 0 To 6
            If ws.Cell(row, i + 4).GetString() = "Yes" Then
                days.Add(dayNames(i))
            End If
        Next

        Return String.Join(", ", days)

    End Function


    '========================================
    ' RESTORE
    '========================================
    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRetrieve.Click

        If dgvDeleted.CurrentRow Is Nothing Then

            MessageBox.Show("Please select a volunteer to restore.",
                            "Restore",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
            Exit Sub

        End If

        Dim restoreID As Integer =
            Convert.ToInt32(dgvDeleted.CurrentRow.Cells("ID").Value)

        Using workbook As New XLWorkbook(excelFile)

            Dim ws As IXLWorksheet = workbook.Worksheet("Volunteers")
            Dim deletedWs As IXLWorksheet = workbook.Worksheet("DeletedVolunteers")

            'Find the record in DeletedVolunteers
            Dim deletedRow As Integer = -1
            Dim lastDeleted As IXLRow = deletedWs.LastRowUsed()

            If lastDeleted IsNot Nothing Then
                For row As Integer = 2 To lastDeleted.RowNumber()
                    If deletedWs.Cell(row, 1).GetString() = restoreID.ToString() Then
                        deletedRow = row
                        Exit For
                    End If
                Next
            End If

            If deletedRow = -1 Then
                MessageBox.Show("Record not found.")
                Exit Sub
            End If

            'Find the next empty row in Volunteers
            Dim newRow As Integer = 2
            If ws.LastRowUsed() IsNot Nothing Then
                newRow = ws.LastRowUsed().RowNumber() + 1
            End If

            'Copy the record back
            For column As Integer = 1 To 10
                ws.Cell(newRow, column).Value = deletedWs.Cell(deletedRow, column).Value
            Next

            'If the ID is already used by a newer volunteer, give a new one
            If IDExists(ws, restoreID, newRow) Then
                ws.Cell(newRow, 1).Value = GetNextID(ws)
            End If

            'Remove from DeletedVolunteers
            deletedWs.Row(deletedRow).Delete()

            workbook.Save()

        End Using

        MessageBox.Show("Volunteer restored successfully!",
                        "Restore",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)

        LoadDeleted()

    End Sub


    '========================================
    ' HELPERS
    '========================================
    Private Function IDExists(ws As IXLWorksheet, id As Integer, skipRow As Integer) As Boolean

        For row As Integer = 2 To ws.LastRowUsed().RowNumber()
            If row <> skipRow AndAlso ws.Cell(row, 1).GetString() = id.ToString() Then
                Return True
            End If
        Next

        Return False

    End Function


    Private Function GetNextID(ws As IXLWorksheet) As Integer

        Dim highestID As Integer = 0

        For row As Integer = 2 To ws.LastRowUsed().RowNumber()
            Dim currentID As Integer
            If Integer.TryParse(ws.Cell(row, 1).GetString(), currentID) Then
                If currentID > highestID Then highestID = currentID
            End If
        Next

        Return highestID + 1

    End Function


    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class