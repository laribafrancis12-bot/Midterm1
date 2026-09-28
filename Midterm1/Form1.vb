Imports System.IO
Imports ClosedXML.Excel
Imports DocumentFormat.OpenXml.Wordprocessing

Public Class Form1

    Private excelFile As String =
        Path.Combine(Application.StartupPath, "VolunteerDatabase.xlsx")

    Private selectedID As Integer = -1


    '========================================
    ' FORM LOAD
    '========================================
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Create Excel database
        CreateDatabase()

        'Display existing volunteers
        LoadVolunteers()

        'Update is disabled until Edit is clicked
        btnUpdate.Enabled = False

    End Sub


    '========================================
    ' CREATE EXCEL DATABASE
    '========================================
    Private Sub CreateDatabase()

        If Not File.Exists(excelFile) Then

            Using workbook As New XLWorkbook()

                Dim ws As IXLWorksheet =
                    workbook.Worksheets.Add("Volunteers")

                CreateHeaders(ws)


                Dim deletedWs As IXLWorksheet =
                    workbook.Worksheets.Add("DeletedVolunteers")

                CreateHeaders(deletedWs)

                workbook.SaveAs(excelFile)

            End Using

        End If

    End Sub


    '========================================
    ' CREATE EXCEL HEADERS
    '========================================
    Private Sub CreateHeaders(ws As IXLWorksheet)

        ws.Cell(1, 1).Value = "ID"
        ws.Cell(1, 2).Value = "Name"
        ws.Cell(1, 3).Value = "City"
        ws.Cell(1, 4).Value = "Monday"
        ws.Cell(1, 5).Value = "Tuesday"
        ws.Cell(1, 6).Value = "Wednesday"
        ws.Cell(1, 7).Value = "Thursday"
        ws.Cell(1, 8).Value = "Friday"
        ws.Cell(1, 9).Value = "Saturday"
        ws.Cell(1, 10).Value = "Sunday"

    End Sub


    '========================================
    ' LOAD VOLUNTEERS
    '========================================
    Private Sub LoadVolunteers()

        dgvVolunteers.Rows.Clear()
        dgvVolunteers.Columns.Clear()

        dgvVolunteers.Columns.Add("ID", "ID")
        dgvVolunteers.Columns.Add("Name", "Name")
        dgvVolunteers.Columns.Add("City", "City")
        dgvVolunteers.Columns.Add("Days", "Days Available")


        Using workbook As New XLWorkbook(excelFile)

            Dim ws As IXLWorksheet =
                workbook.Worksheet("Volunteers")


            Dim lastRow As IXLRow = ws.LastRowUsed()

            If lastRow Is Nothing Then
                Exit Sub
            End If


            For row As Integer = 2 To lastRow.RowNumber()

                If String.IsNullOrWhiteSpace(
                    ws.Cell(row, 1).GetString()) Then

                    Continue For

                End If


                Dim id As String =
                    ws.Cell(row, 1).GetString()

                Dim name As String =
                    ws.Cell(row, 2).GetString()

                Dim city As String =
                    ws.Cell(row, 3).GetString()

                Dim days As String =
                    GetDays(ws, row)


                dgvVolunteers.Rows.Add(
                    id,
                    name,
                    city,
                    days)

            Next

        End Using

    End Sub


    '========================================
    ' GET SELECTED DAYS
    '========================================
    Private Function GetSelectedDays() As String

        Dim days As New List(Of String)

        For Each item In clbDays.CheckedItems

            days.Add(item.ToString())

        Next

        Return String.Join(", ", days)

    End Function


    '========================================
    ' CHECK IF AT LEAST ONE DAY IS SELECTED
    '========================================
    Private Function HasSelectedDay() As Boolean

        Return clbDays.CheckedItems.Count > 0

    End Function


    '========================================
    ' GET DAYS FROM EXCEL
    '========================================
    Private Function GetDays(ws As IXLWorksheet,
                             row As Integer) As String

        Dim days As New List(Of String)


        If ws.Cell(row, 4).GetString() = "Yes" Then
            days.Add("Monday")
        End If

        If ws.Cell(row, 5).GetString() = "Yes" Then
            days.Add("Tuesday")
        End If

        If ws.Cell(row, 6).GetString() = "Yes" Then
            days.Add("Wednesday")
        End If

        If ws.Cell(row, 7).GetString() = "Yes" Then
            days.Add("Thursday")
        End If

        If ws.Cell(row, 8).GetString() = "Yes" Then
            days.Add("Friday")
        End If

        If ws.Cell(row, 9).GetString() = "Yes" Then
            days.Add("Saturday")
        End If

        If ws.Cell(row, 10).GetString() = "Yes" Then
            days.Add("Sunday")
        End If


        Return String.Join(", ", days)

    End Function


    '========================================
    ' ADD
    '========================================
    Private Sub btnAdd_Click(sender As Object,
                             e As EventArgs) Handles btnAdd.Click

        'Check Name
        If txtName.Text.Trim() = "" Then

            MessageBox.Show(
                "Please enter the volunteer name.",
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            txtName.Focus()

            Exit Sub

        End If


        'Check City
        If txtCity.Text.Trim() = "" Then

            MessageBox.Show(
                "Please enter the city.",
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            txtCity.Focus()

            Exit Sub

        End If


        'Check Days
        If Not HasSelectedDay() Then

            MessageBox.Show(
                "Please select at least one available day.",
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Exit Sub

        End If


        Using workbook As New XLWorkbook(excelFile)

            Dim ws As IXLWorksheet =
                workbook.Worksheet("Volunteers")


            Dim lastRow As Integer

            If ws.LastRowUsed() Is Nothing Then

                lastRow = 1

            Else

                lastRow = ws.LastRowUsed().RowNumber()

            End If


            Dim newRow As Integer =
                lastRow + 1


            Dim newID As Integer =
                GetNextID(ws)


            ws.Cell(newRow, 1).Value =
                newID

            ws.Cell(newRow, 2).Value =
                txtName.Text.Trim()

            ws.Cell(newRow, 3).Value =
                txtCity.Text.Trim()


            ws.Cell(newRow, 4).Value =
                If(clbDays.GetItemChecked(0),
                   "Yes",
                   "No")

            ws.Cell(newRow, 5).Value =
                If(clbDays.GetItemChecked(1),
                   "Yes",
                   "No")

            ws.Cell(newRow, 6).Value =
                If(clbDays.GetItemChecked(2),
                   "Yes",
                   "No")

            ws.Cell(newRow, 7).Value =
                If(clbDays.GetItemChecked(3),
                   "Yes",
                   "No")

            ws.Cell(newRow, 8).Value =
                If(clbDays.GetItemChecked(4),
                   "Yes",
                   "No")

            ws.Cell(newRow, 9).Value =
                If(clbDays.GetItemChecked(5),
                   "Yes",
                   "No")

            ws.Cell(newRow, 10).Value =
                If(clbDays.GetItemChecked(6),
                   "Yes",
                   "No")


            workbook.Save()

        End Using


        MessageBox.Show(
            "Volunteer added successfully!",
            "Success",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)


        ClearFields()

        LoadVolunteers()

    End Sub


    '========================================
    ' GET NEXT ID
    '========================================
    Private Function GetNextID(ws As IXLWorksheet) As Integer

        If ws.LastRowUsed() Is Nothing Then

            Return 1

        End If


        Dim lastRow As Integer =
            ws.LastRowUsed().RowNumber()


        Dim highestID As Integer = 0


        For row As Integer = 2 To lastRow

            Dim currentID As Integer


            If Integer.TryParse(
                ws.Cell(row, 1).GetString(),
                currentID) Then


                If currentID > highestID Then

                    highestID = currentID

                End If

            End If

        Next


        Return highestID + 1

    End Function


    '========================================
    ' EDIT
    '========================================
    Private Sub btnEdit_Click(sender As Object,
                              e As EventArgs) Handles btnEdit.Click

        If dgvVolunteers.CurrentRow Is Nothing Then

            MessageBox.Show(
                "Please select a volunteer first.",
                "Edit",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Exit Sub

        End If


        selectedID =
            Convert.ToInt32(
                dgvVolunteers.CurrentRow.Cells("ID").Value)


        Using workbook As New XLWorkbook(excelFile)

            Dim ws As IXLWorksheet =
                workbook.Worksheet("Volunteers")


            Dim row As Integer =
                FindVolunteerRow(ws, selectedID)


            If row = -1 Then

                MessageBox.Show(
                    "Volunteer not found.")

                Exit Sub

            End If


            'Put existing information into the fields

            txtName.Text =
                ws.Cell(row, 2).GetString()

            txtCity.Text =
                ws.Cell(row, 3).GetString()


            'Clear CheckedListBox selections

            For i As Integer = 0 To clbDays.Items.Count - 1

                clbDays.SetItemChecked(i, False)

            Next


            'Load the selected days

            For i As Integer = 0 To 6

                If ws.Cell(row, i + 4).GetString() = "Yes" Then

                    clbDays.SetItemChecked(i, True)

                End If

            Next

        End Using


        'Disable Add while editing

        btnAdd.Enabled = False


        'Enable Update

        btnUpdate.Enabled = True

    End Sub


    '========================================
    ' FIND VOLUNTEER ROW
    '========================================
    Private Function FindVolunteerRow(
        ws As IXLWorksheet,
        id As Integer) As Integer


        If ws.LastRowUsed() Is Nothing Then

            Return -1

        End If


        Dim lastRow As Integer =
            ws.LastRowUsed().RowNumber()


        For row As Integer = 2 To lastRow

            If ws.Cell(row, 1).GetValue(Of Integer)() = id Then

                Return row

            End If

        Next


        Return -1

    End Function


    '========================================
    ' UPDATE
    '========================================
    Private Sub btnUpdate_Click(sender As Object,
                                e As EventArgs) Handles btnUpdate.Click

        If selectedID = -1 Then

            MessageBox.Show(
                "Please click Edit first.",
                "Update",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Exit Sub

        End If


        'Validate Name

        If txtName.Text.Trim() = "" Then

            MessageBox.Show(
                "Please enter the volunteer name.")

            txtName.Focus()

            Exit Sub

        End If


        'Validate City

        If txtCity.Text.Trim() = "" Then

            MessageBox.Show(
                "Please enter the city.")

            txtCity.Focus()

            Exit Sub

        End If


        'Validate Days

        If Not HasSelectedDay() Then

            MessageBox.Show(
                "Please select at least one day.")

            Exit Sub

        End If


        Using workbook As New XLWorkbook(excelFile)

            Dim ws As IXLWorksheet =
                workbook.Worksheet("Volunteers")


            Dim row As Integer =
                FindVolunteerRow(ws, selectedID)


            If row = -1 Then

                MessageBox.Show(
                    "Volunteer not found.")

                Exit Sub

            End If


            'Update Name

            ws.Cell(row, 2).Value =
                txtName.Text.Trim()


            'Update City

            ws.Cell(row, 3).Value =
                txtCity.Text.Trim()


            'Update Days

            For i As Integer = 0 To 6

                ws.Cell(row, i + 4).Value =
                    If(
                        clbDays.GetItemChecked(i),
                        "Yes",
                        "No"
                    )

            Next


            workbook.Save()

        End Using


        MessageBox.Show(
            "Volunteer information updated successfully!",
            "Update",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)


        ClearFields()


        btnAdd.Enabled = True

        btnUpdate.Enabled = False


        LoadVolunteers()

    End Sub


    '========================================
    ' DELETE
    '========================================
    Private Sub btnDelete_Click(sender As Object,
                                e As EventArgs) Handles btnDelete.Click

        If dgvVolunteers.CurrentRow Is Nothing Then

            MessageBox.Show(
                "Please select a volunteer first.",
                "Delete",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Exit Sub

        End If


        Dim selectedID As Integer =
            Convert.ToInt32(
                dgvVolunteers.CurrentRow.Cells("ID").Value)


        Dim selectedName As String =
            dgvVolunteers.CurrentRow.Cells("Name").Value.ToString()


        Dim answer As DialogResult =
            MessageBox.Show(
                "Do you want to delete " &
                selectedName & "?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)


        If answer = DialogResult.No Then

            Exit Sub

        End If


        Using workbook As New XLWorkbook(excelFile)

            Dim ws As IXLWorksheet =
                workbook.Worksheet("Volunteers")


            Dim deletedWs As IXLWorksheet =
                workbook.Worksheet("DeletedVolunteers")


            Dim row As Integer =
                FindVolunteerRow(ws, selectedID)


            If row = -1 Then

                MessageBox.Show(
                    "Volunteer not found.")

                Exit Sub

            End If


            Dim newRow As Integer


            If deletedWs.LastRowUsed() Is Nothing Then

                newRow = 2

            Else

                newRow =
                    deletedWs.LastRowUsed().RowNumber() + 1

            End If


            'Copy record to DeletedVolunteers

            For column As Integer = 1 To 10

                deletedWs.Cell(newRow, column).Value =
                    ws.Cell(row, column).Value

            Next


            'Delete from Volunteers

            ws.Row(row).Delete()


            workbook.Save()

        End Using


        MessageBox.Show(
            "Volunteer deleted successfully!",
            "Delete",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)


        ClearFields()

        LoadVolunteers()

    End Sub


    '========================================
    ' OPEN RETRIEVE FORM
    '========================================
    Private Sub btnRetrieve_Click(sender As Object,
                                  e As EventArgs) Handles btnRetrieve.Click

        Dim retrieveForm As New frmRetrieve()

        retrieveForm.ShowDialog()

        LoadVolunteers()

    End Sub


    '========================================
    ' GO TO DATABASE
    '========================================
    Private Sub btnDatabase_Click(sender As Object,
                                  e As EventArgs) Handles btnDatabase.Click

        If File.Exists(excelFile) Then

            Process.Start(
                New ProcessStartInfo With {
                    .FileName = excelFile,
                    .UseShellExecute = True
                })

        Else

            MessageBox.Show(
                "Database file not found.")

        End If

    End Sub


    '========================================
    ' CLEAR FIELDS
    '========================================
    Private Sub ClearFields()

        txtName.Clear()

        txtCity.Clear()


        'Uncheck all days

        For i As Integer = 0 To clbDays.Items.Count - 1

            clbDays.SetItemChecked(i, False)

        Next


        selectedID = -1

    End Sub

End Class