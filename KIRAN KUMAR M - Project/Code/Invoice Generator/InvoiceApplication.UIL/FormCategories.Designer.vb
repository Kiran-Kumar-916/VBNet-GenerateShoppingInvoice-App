<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCategories
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
        Me.LblCategoriesName = New System.Windows.Forms.Label()
        Me.LblCategoriesDescription = New System.Windows.Forms.Label()
        Me.TxtCategoryName = New System.Windows.Forms.TextBox()
        Me.TxtCategoryDescription = New System.Windows.Forms.TextBox()
        Me.BtnCategories = New System.Windows.Forms.Button()
        Me.CmbCategoryName = New System.Windows.Forms.ComboBox()
        Me.LblCategoriesTaxrate = New System.Windows.Forms.Label()
        Me.TxtCategoryTaxrate = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'LblCategoriesName
        '
        Me.LblCategoriesName.AutoSize = True
        Me.LblCategoriesName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCategoriesName.Location = New System.Drawing.Point(400, 164)
        Me.LblCategoriesName.Name = "LblCategoriesName"
        Me.LblCategoriesName.Size = New System.Drawing.Size(45, 15)
        Me.LblCategoriesName.TabIndex = 0
        Me.LblCategoriesName.Text = "Name"
        '
        'LblCategoriesDescription
        '
        Me.LblCategoriesDescription.AutoSize = True
        Me.LblCategoriesDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCategoriesDescription.Location = New System.Drawing.Point(364, 251)
        Me.LblCategoriesDescription.Name = "LblCategoriesDescription"
        Me.LblCategoriesDescription.Size = New System.Drawing.Size(81, 15)
        Me.LblCategoriesDescription.TabIndex = 1
        Me.LblCategoriesDescription.Text = "Descriprion"
        '
        'TxtCategoryName
        '
        Me.TxtCategoryName.Location = New System.Drawing.Point(491, 160)
        Me.TxtCategoryName.Multiline = True
        Me.TxtCategoryName.Name = "TxtCategoryName"
        Me.TxtCategoryName.Size = New System.Drawing.Size(230, 30)
        Me.TxtCategoryName.TabIndex = 2
        '
        'TxtCategoryDescription
        '
        Me.TxtCategoryDescription.Location = New System.Drawing.Point(491, 236)
        Me.TxtCategoryDescription.Multiline = True
        Me.TxtCategoryDescription.Name = "TxtCategoryDescription"
        Me.TxtCategoryDescription.Size = New System.Drawing.Size(230, 30)
        Me.TxtCategoryDescription.TabIndex = 3
        '
        'BtnCategories
        '
        Me.BtnCategories.BackColor = System.Drawing.Color.MediumAquamarine
        Me.BtnCategories.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCategories.Location = New System.Drawing.Point(334, 461)
        Me.BtnCategories.Name = "BtnCategories"
        Me.BtnCategories.Size = New System.Drawing.Size(380, 50)
        Me.BtnCategories.TabIndex = 4
        Me.BtnCategories.Text = "ADD"
        Me.BtnCategories.UseVisualStyleBackColor = False
        '
        'CmbCategoryName
        '
        Me.CmbCategoryName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCategoryName.FormattingEnabled = True
        Me.CmbCategoryName.Location = New System.Drawing.Point(491, 163)
        Me.CmbCategoryName.MaxDropDownItems = 100
        Me.CmbCategoryName.Name = "CmbCategoryName"
        Me.CmbCategoryName.Size = New System.Drawing.Size(230, 21)
        Me.CmbCategoryName.Sorted = True
        Me.CmbCategoryName.TabIndex = 5
        '
        'LblCategoriesTaxrate
        '
        Me.LblCategoriesTaxrate.AutoSize = True
        Me.LblCategoriesTaxrate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCategoriesTaxrate.Location = New System.Drawing.Point(331, 320)
        Me.LblCategoriesTaxrate.Name = "LblCategoriesTaxrate"
        Me.LblCategoriesTaxrate.Size = New System.Drawing.Size(114, 15)
        Me.LblCategoriesTaxrate.TabIndex = 6
        Me.LblCategoriesTaxrate.Text = "Tax Rate ( in % )"
        '
        'TxtCategoryTaxrate
        '
        Me.TxtCategoryTaxrate.Location = New System.Drawing.Point(491, 319)
        Me.TxtCategoryTaxrate.Multiline = True
        Me.TxtCategoryTaxrate.Name = "TxtCategoryTaxrate"
        Me.TxtCategoryTaxrate.Size = New System.Drawing.Size(230, 30)
        Me.TxtCategoryTaxrate.TabIndex = 7
        '
        'FormCategories
        '
        Me.ClientSize = New System.Drawing.Size(1002, 685)
        Me.Controls.Add(Me.TxtCategoryTaxrate)
        Me.Controls.Add(Me.LblCategoriesTaxrate)
        Me.Controls.Add(Me.CmbCategoryName)
        Me.Controls.Add(Me.BtnCategories)
        Me.Controls.Add(Me.TxtCategoryDescription)
        Me.Controls.Add(Me.TxtCategoryName)
        Me.Controls.Add(Me.LblCategoriesDescription)
        Me.Controls.Add(Me.LblCategoriesName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FormCategories"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Categories"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents LblCategoriesName As System.Windows.Forms.Label
    Friend WithEvents LblCategoriesDescription As System.Windows.Forms.Label
    Friend WithEvents TxtCategoryName As System.Windows.Forms.TextBox
    Friend WithEvents TxtCategoryDescription As System.Windows.Forms.TextBox
    Friend WithEvents BtnCategories As System.Windows.Forms.Button
    Friend WithEvents CmbCategoryName As System.Windows.Forms.ComboBox
    Friend WithEvents LblCategoriesTaxrate As System.Windows.Forms.Label
    Friend WithEvents TxtCategoryTaxrate As System.Windows.Forms.TextBox
End Class
