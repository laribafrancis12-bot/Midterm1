<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRetrieve
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Label1 = New Label()
        Label2 = New Label()
        dgvDeleted = New DataGridView()
        btnRetrieve = New Button()
        btnClose = New Button()
        CType(dgvDeleted, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(196, 23)
        Label1.Name = "Label1"
        Label1.Size = New Size(188, 30)
        Label1.TabIndex = 0
        Label1.Text = "Retrieve Volunteer"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(48, 78)
        Label2.Name = "Label2"
        Label2.Size = New Size(108, 15)
        Label2.TabIndex = 1
        Label2.Text = "Deleted Volunteers:"
        ' 
        ' dgvDeleted
        ' 
        dgvDeleted.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvDeleted.Location = New Point(48, 96)
        dgvDeleted.Name = "dgvDeleted"
        dgvDeleted.ReadOnly = True
        dgvDeleted.Size = New Size(541, 284)
        dgvDeleted.TabIndex = 2
        ' 
        ' btnRetrieve
        ' 
        btnRetrieve.Location = New Point(171, 412)
        btnRetrieve.Name = "btnRetrieve"
        btnRetrieve.Size = New Size(75, 23)
        btnRetrieve.TabIndex = 3
        btnRetrieve.Text = "Retrieve"
        btnRetrieve.UseVisualStyleBackColor = True
        ' 
        ' btnClose
        ' 
        btnClose.Location = New Point(356, 412)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(75, 23)
        btnClose.TabIndex = 4
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' frmRetrieve
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(634, 485)
        Controls.Add(btnClose)
        Controls.Add(btnRetrieve)
        Controls.Add(dgvDeleted)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "frmRetrieve"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmRetrieve"
        CType(dgvDeleted, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dgvDeleted As DataGridView
    Friend WithEvents btnRetrieve As Button
    Friend WithEvents btnClose As Button
End Class
