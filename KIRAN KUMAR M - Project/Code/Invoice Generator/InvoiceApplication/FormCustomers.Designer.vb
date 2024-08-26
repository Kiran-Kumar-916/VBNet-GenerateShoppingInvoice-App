<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCustomers
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
        Me.LblCustomersName = New System.Windows.Forms.Label()
        Me.LblCustomersEmail = New System.Windows.Forms.Label()
        Me.LblCustomersAddress = New System.Windows.Forms.Label()
        Me.LblCustomersContactNum = New System.Windows.Forms.Label()
        Me.TxtCustomerName = New System.Windows.Forms.TextBox()
        Me.TxtCustomerEmail = New System.Windows.Forms.TextBox()
        Me.TxtCustomerAddress = New System.Windows.Forms.TextBox()
        Me.TxtCustomerContactNum = New System.Windows.Forms.TextBox()
        Me.CmbCustomerName = New System.Windows.Forms.ComboBox()
        Me.BtnCustomers = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LblCustomersName
        '
        Me.LblCustomersName.AutoSize = True
        Me.LblCustomersName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCustomersName.Location = New System.Drawing.Point(368, 134)
        Me.LblCustomersName.Name = "LblCustomersName"
        Me.LblCustomersName.Size = New System.Drawing.Size(45, 15)
        Me.LblCustomersName.TabIndex = 1
        Me.LblCustomersName.Text = "Name"
        '
        'LblCustomersEmail
        '
        Me.LblCustomersEmail.AutoSize = True
        Me.LblCustomersEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCustomersEmail.Location = New System.Drawing.Point(369, 196)
        Me.LblCustomersEmail.Name = "LblCustomersEmail"
        Me.LblCustomersEmail.Size = New System.Drawing.Size(44, 15)
        Me.LblCustomersEmail.TabIndex = 2
        Me.LblCustomersEmail.Text = "Email"
        '
        'LblCustomersAddress
        '
        Me.LblCustomersAddress.AutoSize = True
        Me.LblCustomersAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCustomersAddress.Location = New System.Drawing.Point(355, 260)
        Me.LblCustomersAddress.Name = "LblCustomersAddress"
        Me.LblCustomersAddress.Size = New System.Drawing.Size(58, 15)
        Me.LblCustomersAddress.TabIndex = 3
        Me.LblCustomersAddress.Text = "Address"
        '
        'LblCustomersContactNum
        '
        Me.LblCustomersContactNum.AutoSize = True
        Me.LblCustomersContactNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCustomersContactNum.Location = New System.Drawing.Point(303, 335)
        Me.LblCustomersContactNum.Name = "LblCustomersContactNum"
        Me.LblCustomersContactNum.Size = New System.Drawing.Size(110, 15)
        Me.LblCustomersContactNum.TabIndex = 4
        Me.LblCustomersContactNum.Text = "Contact Number"
        '
        'TxtCustomerName
        '
        Me.TxtCustomerName.Location = New System.Drawing.Point(497, 132)
        Me.TxtCustomerName.Multiline = True
        Me.TxtCustomerName.Name = "TxtCustomerName"
        Me.TxtCustomerName.Size = New System.Drawing.Size(230, 30)
        Me.TxtCustomerName.TabIndex = 7
        '
        'TxtCustomerEmail
        '
        Me.TxtCustomerEmail.Location = New System.Drawing.Point(497, 195)
        Me.TxtCustomerEmail.Multiline = True
        Me.TxtCustomerEmail.Name = "TxtCustomerEmail"
        Me.TxtCustomerEmail.Size = New System.Drawing.Size(230, 30)
        Me.TxtCustomerEmail.TabIndex = 8
        '
        'TxtCustomerAddress
        '
        Me.TxtCustomerAddress.Location = New System.Drawing.Point(497, 258)
        Me.TxtCustomerAddress.Multiline = True
        Me.TxtCustomerAddress.Name = "TxtCustomerAddress"
        Me.TxtCustomerAddress.Size = New System.Drawing.Size(230, 30)
        Me.TxtCustomerAddress.TabIndex = 9
        '
        'TxtCustomerContactNum
        '
        Me.TxtCustomerContactNum.Location = New System.Drawing.Point(497, 333)
        Me.TxtCustomerContactNum.Multiline = True
        Me.TxtCustomerContactNum.Name = "TxtCustomerContactNum"
        Me.TxtCustomerContactNum.Size = New System.Drawing.Size(230, 30)
        Me.TxtCustomerContactNum.TabIndex = 10
        '
        'CmbCustomerName
        '
        Me.CmbCustomerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCustomerName.FormattingEnabled = True
        Me.CmbCustomerName.Location = New System.Drawing.Point(497, 136)
        Me.CmbCustomerName.MaxDropDownItems = 100
        Me.CmbCustomerName.Name = "CmbCustomerName"
        Me.CmbCustomerName.Size = New System.Drawing.Size(230, 21)
        Me.CmbCustomerName.Sorted = True
        Me.CmbCustomerName.TabIndex = 12
        '
        'BtnCustomers
        '
        Me.BtnCustomers.BackColor = System.Drawing.Color.MediumAquamarine
        Me.BtnCustomers.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCustomers.Location = New System.Drawing.Point(306, 460)
        Me.BtnCustomers.Name = "BtnCustomers"
        Me.BtnCustomers.Size = New System.Drawing.Size(421, 50)
        Me.BtnCustomers.TabIndex = 13
        Me.BtnCustomers.Text = "ADD"
        Me.BtnCustomers.UseVisualStyleBackColor = False
        '
        'FormCustomers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 675)
        Me.Controls.Add(Me.BtnCustomers)
        Me.Controls.Add(Me.CmbCustomerName)
        Me.Controls.Add(Me.TxtCustomerContactNum)
        Me.Controls.Add(Me.TxtCustomerAddress)
        Me.Controls.Add(Me.TxtCustomerEmail)
        Me.Controls.Add(Me.TxtCustomerName)
        Me.Controls.Add(Me.LblCustomersContactNum)
        Me.Controls.Add(Me.LblCustomersAddress)
        Me.Controls.Add(Me.LblCustomersEmail)
        Me.Controls.Add(Me.LblCustomersName)
        Me.MaximizeBox = False
        Me.Name = "FormCustomers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Customers"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblCustomersName As System.Windows.Forms.Label
    Friend WithEvents LblCustomersEmail As System.Windows.Forms.Label
    Friend WithEvents LblCustomersAddress As System.Windows.Forms.Label
    Friend WithEvents LblCustomersContactNum As System.Windows.Forms.Label
    Friend WithEvents TxtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents TxtCustomerEmail As System.Windows.Forms.TextBox
    Friend WithEvents TxtCustomerAddress As System.Windows.Forms.TextBox
    Friend WithEvents TxtCustomerContactNum As System.Windows.Forms.TextBox
    Friend WithEvents CmbCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents BtnCustomers As System.Windows.Forms.Button
End Class
