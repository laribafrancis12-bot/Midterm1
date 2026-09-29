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
        Panel1 = New Panel()
        CType(dgvDeleted, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(262, 23)
        Label1.Name = "Label1"
        Label1.Size = New Size(188, 30)
        Label1.TabIndex = 0
        Label1.Text = "Retrieve Volunteer"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(22, 77)
        Label2.Name = "Label2"
        Label2.Size = New Size(143, 20)
        Label2.TabIndex = 1
        Label2.Text = "Deleted Volunteers:"
        ' 
        ' dgvDeleted
        ' 
        dgvDeleted.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvDeleted.Location = New Point(50, 109)
        dgvDeleted.Name = "dgvDeleted"
        dgvDeleted.ReadOnly = True
        dgvDeleted.Size = New Size(613, 284)
        dgvDeleted.TabIndex = 2
        ' 
        ' btnRetrieve
        ' 
        btnRetrieve.Location = New Point(170, 409)
        btnRetrieve.Name = "btnRetrieve"
        btnRetrieve.Size = New Size(75, 23)
        btnRetrieve.TabIndex = 3
        btnRetrieve.Text = "Retrieve"
        btnRetrieve.UseVisualStyleBackColor = True
        ' 
        ' btnClose
        ' 
        btnClose.Location = New Point(454, 409)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(75, 23)
        btnClose.TabIndex = 4
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.MenuHighlight
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(-2, -5)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(725, 69)
        Panel1.TabIndex = 5
        ' 
        ' frmRetrieve
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(720, 485)
        Controls.Add(btnClose)
        Controls.Add(btnRetrieve)
        Controls.Add(dgvDeleted)
        Controls.Add(Label2)
        Controls.Add(Panel1)
        Name = "frmRetrieve"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmRetrieve"
        CType(dgvDeleted, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dgvDeleted As DataGridView
    Friend WithEvents btnRetrieve As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents Panel1 As Panel
End Class
