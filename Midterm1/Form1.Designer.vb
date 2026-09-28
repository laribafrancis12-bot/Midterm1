<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Label1 = New Label()
        lblname = New Label()
        txtName = New TextBox()
        lblcity = New Label()
        txtCity = New TextBox()
        lbldays = New Label()
        clbDays = New CheckedListBox()
        dgvVolunteers = New DataGridView()
        btnAdd = New Button()
        btnEdit = New Button()
        btnUpdate = New Button()
        btnDelete = New Button()
        btnRetrieve = New Button()
        btnDatabase = New Button()
        Label2 = New Label()
        CType(dgvVolunteers, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(236, 30)
        Label1.Name = "Label1"
        Label1.Size = New Size(315, 32)
        Label1.TabIndex = 0
        Label1.Text = "VOLUNTEER REGISTRATION"
        ' 
        ' lblname
        ' 
        lblname.AutoSize = True
        lblname.Location = New Point(40, 115)
        lblname.Name = "lblname"
        lblname.Size = New Size(44, 15)
        lblname.TabIndex = 1
        lblname.Text = "NAME:"
        ' 
        ' txtName
        ' 
        txtName.Location = New Point(70, 133)
        txtName.Name = "txtName"
        txtName.Size = New Size(308, 23)
        txtName.TabIndex = 2
        ' 
        ' lblcity
        ' 
        lblcity.AutoSize = True
        lblcity.Location = New Point(44, 190)
        lblcity.Name = "lblcity"
        lblcity.Size = New Size(34, 15)
        lblcity.TabIndex = 3
        lblcity.Text = "CITY:"
        ' 
        ' txtCity
        ' 
        txtCity.Location = New Point(70, 208)
        txtCity.Name = "txtCity"
        txtCity.Size = New Size(308, 23)
        txtCity.TabIndex = 4
        ' 
        ' lbldays
        ' 
        lbldays.AutoSize = True
        lbldays.Location = New Point(44, 273)
        lbldays.Name = "lbldays"
        lbldays.Size = New Size(86, 15)
        lbldays.TabIndex = 5
        lbldays.Text = "Days Available:"
        ' 
        ' clbDays
        ' 
        clbDays.FormattingEnabled = True
        clbDays.Items.AddRange(New Object() {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"})
        clbDays.Location = New Point(70, 291)
        clbDays.Name = "clbDays"
        clbDays.Size = New Size(223, 130)
        clbDays.TabIndex = 6
        ' 
        ' dgvVolunteers
        ' 
        dgvVolunteers.AllowUserToAddRows = False
        dgvVolunteers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvVolunteers.Location = New Point(70, 634)
        dgvVolunteers.MultiSelect = False
        dgvVolunteers.Name = "dgvVolunteers"
        dgvVolunteers.ReadOnly = True
        dgvVolunteers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvVolunteers.Size = New Size(585, 242)
        dgvVolunteers.TabIndex = 7
        ' 
        ' btnAdd
        ' 
        btnAdd.Location = New Point(121, 455)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(75, 23)
        btnAdd.TabIndex = 8
        btnAdd.Text = "ADD"
        btnAdd.UseVisualStyleBackColor = True
        ' 
        ' btnEdit
        ' 
        btnEdit.Location = New Point(236, 455)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(75, 23)
        btnEdit.TabIndex = 9
        btnEdit.Text = "EDIT"
        btnEdit.UseVisualStyleBackColor = True
        ' 
        ' btnUpdate
        ' 
        btnUpdate.Location = New Point(349, 455)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(75, 23)
        btnUpdate.TabIndex = 10
        btnUpdate.Text = "UPDATE"
        btnUpdate.UseVisualStyleBackColor = True
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(459, 455)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(75, 23)
        btnDelete.TabIndex = 11
        btnDelete.Text = "DELETE"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnRetrieve
        ' 
        btnRetrieve.Location = New Point(236, 509)
        btnRetrieve.Name = "btnRetrieve"
        btnRetrieve.Size = New Size(75, 23)
        btnRetrieve.TabIndex = 12
        btnRetrieve.Text = "RETRIEVE"
        btnRetrieve.UseVisualStyleBackColor = True
        ' 
        ' btnDatabase
        ' 
        btnDatabase.Location = New Point(349, 509)
        btnDatabase.Name = "btnDatabase"
        btnDatabase.Size = New Size(118, 23)
        btnDatabase.TabIndex = 13
        btnDatabase.Text = "GO TO DATABASE"
        btnDatabase.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(40, 607)
        Label2.Name = "Label2"
        Label2.Size = New Size(123, 15)
        Label2.TabIndex = 14
        Label2.Text = "Registered Volunteers:"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(861, 888)
        Controls.Add(Label2)
        Controls.Add(btnDatabase)
        Controls.Add(btnRetrieve)
        Controls.Add(btnDelete)
        Controls.Add(btnUpdate)
        Controls.Add(btnEdit)
        Controls.Add(btnAdd)
        Controls.Add(dgvVolunteers)
        Controls.Add(clbDays)
        Controls.Add(lbldays)
        Controls.Add(txtCity)
        Controls.Add(lblcity)
        Controls.Add(txtName)
        Controls.Add(lblname)
        Controls.Add(Label1)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form1"
        CType(dgvVolunteers, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lblname As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents lblcity As Label
    Friend WithEvents txtCity As TextBox
    Friend WithEvents lbldays As Label
    Friend WithEvents clbDays As CheckedListBox
    Friend WithEvents dgvVolunteers As DataGridView
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnRetrieve As Button
    Friend WithEvents btnDatabase As Button
    Friend WithEvents Label2 As Label

End Class
