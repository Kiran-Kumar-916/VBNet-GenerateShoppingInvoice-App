<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProducts
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
        Me.LblProductName = New System.Windows.Forms.Label()
        Me.LblProductDescription = New System.Windows.Forms.Label()
        Me.LblProductPrice = New System.Windows.Forms.Label()
        Me.LblProductQuantity = New System.Windows.Forms.Label()
        Me.LblProductCategory = New System.Windows.Forms.Label()
        Me.TxtProductName = New System.Windows.Forms.TextBox()
        Me.TxtProductDescription = New System.Windows.Forms.TextBox()
        Me.TxtProductPrice = New System.Windows.Forms.TextBox()
        Me.TxtProductQuantity = New System.Windows.Forms.TextBox()
        Me.BtnProduct = New System.Windows.Forms.Button()
        Me.CmbProductName = New System.Windows.Forms.ComboBox()
        Me.LblProductDiscount = New System.Windows.Forms.Label()
        Me.TxtProductDiscount = New System.Windows.Forms.TextBox()
        Me.CmbProductCategory = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'LblProductName
        '
        Me.LblProductName.AutoSize = True
        Me.LblProductName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProductName.Location = New System.Drawing.Point(411, 100)
        Me.LblProductName.Name = "LblProductName"
        Me.LblProductName.Size = New System.Drawing.Size(45, 15)
        Me.LblProductName.TabIndex = 0
        Me.LblProductName.Text = "Name"
        '
        'LblProductDescription
        '
        Me.LblProductDescription.AutoSize = True
        Me.LblProductDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProductDescription.Location = New System.Drawing.Point(376, 165)
        Me.LblProductDescription.Name = "LblProductDescription"
        Me.LblProductDescription.Size = New System.Drawing.Size(80, 15)
        Me.LblProductDescription.TabIndex = 1
        Me.LblProductDescription.Text = "Description"
        '
        'LblProductPrice
        '
        Me.LblProductPrice.AutoSize = True
        Me.LblProductPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProductPrice.Location = New System.Drawing.Point(416, 294)
        Me.LblProductPrice.Name = "LblProductPrice"
        Me.LblProductPrice.Size = New System.Drawing.Size(40, 15)
        Me.LblProductPrice.TabIndex = 2
        Me.LblProductPrice.Text = "Price"
        '
        'LblProductQuantity
        '
        Me.LblProductQuantity.AutoSize = True
        Me.LblProductQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProductQuantity.Location = New System.Drawing.Point(397, 355)
        Me.LblProductQuantity.Name = "LblProductQuantity"
        Me.LblProductQuantity.Size = New System.Drawing.Size(59, 15)
        Me.LblProductQuantity.TabIndex = 3
        Me.LblProductQuantity.Text = "Quantity"
        '
        'LblProductCategory
        '
        Me.LblProductCategory.AutoSize = True
        Me.LblProductCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProductCategory.Location = New System.Drawing.Point(393, 233)
        Me.LblProductCategory.Name = "LblProductCategory"
        Me.LblProductCategory.Size = New System.Drawing.Size(63, 15)
        Me.LblProductCategory.TabIndex = 4
        Me.LblProductCategory.Text = "Category"
        '
        'TxtProductName
        '
        Me.TxtProductName.Location = New System.Drawing.Point(516, 99)
        Me.TxtProductName.Multiline = True
        Me.TxtProductName.Name = "TxtProductName"
        Me.TxtProductName.Size = New System.Drawing.Size(230, 30)
        Me.TxtProductName.TabIndex = 5
        '
        'TxtProductDescription
        '
        Me.TxtProductDescription.Location = New System.Drawing.Point(516, 162)
        Me.TxtProductDescription.Multiline = True
        Me.TxtProductDescription.Name = "TxtProductDescription"
        Me.TxtProductDescription.Size = New System.Drawing.Size(230, 30)
        Me.TxtProductDescription.TabIndex = 6
        '
        'TxtProductPrice
        '
        Me.TxtProductPrice.Location = New System.Drawing.Point(516, 293)
        Me.TxtProductPrice.Multiline = True
        Me.TxtProductPrice.Name = "TxtProductPrice"
        Me.TxtProductPrice.Size = New System.Drawing.Size(230, 30)
        Me.TxtProductPrice.TabIndex = 7
        '
        'TxtProductQuantity
        '
        Me.TxtProductQuantity.Location = New System.Drawing.Point(516, 354)
        Me.TxtProductQuantity.Multiline = True
        Me.TxtProductQuantity.Name = "TxtProductQuantity"
        Me.TxtProductQuantity.Size = New System.Drawing.Size(230, 30)
        Me.TxtProductQuantity.TabIndex = 8
        '
        'BtnProduct
        '
        Me.BtnProduct.BackColor = System.Drawing.Color.MediumAquamarine
        Me.BtnProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProduct.Location = New System.Drawing.Point(359, 530)
        Me.BtnProduct.Name = "BtnProduct"
        Me.BtnProduct.Size = New System.Drawing.Size(387, 50)
        Me.BtnProduct.TabIndex = 10
        Me.BtnProduct.Text = "ADD"
        Me.BtnProduct.UseVisualStyleBackColor = False
        '
        'CmbProductName
        '
        Me.CmbProductName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbProductName.FormattingEnabled = True
        Me.CmbProductName.Location = New System.Drawing.Point(516, 102)
        Me.CmbProductName.MaxDropDownItems = 100
        Me.CmbProductName.Name = "CmbProductName"
        Me.CmbProductName.Size = New System.Drawing.Size(230, 21)
        Me.CmbProductName.Sorted = True
        Me.CmbProductName.TabIndex = 11
        '
        'LblProductDiscount
        '
        Me.LblProductDiscount.AutoSize = True
        Me.LblProductDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProductDiscount.Location = New System.Drawing.Point(347, 415)
        Me.LblProductDiscount.Name = "LblProductDiscount"
        Me.LblProductDiscount.Size = New System.Drawing.Size(109, 15)
        Me.LblProductDiscount.TabIndex = 12
        Me.LblProductDiscount.Text = "Discount ( in %)"
        '
        'TxtProductDiscount
        '
        Me.TxtProductDiscount.Location = New System.Drawing.Point(516, 414)
        Me.TxtProductDiscount.Multiline = True
        Me.TxtProductDiscount.Name = "TxtProductDiscount"
        Me.TxtProductDiscount.Size = New System.Drawing.Size(230, 30)
        Me.TxtProductDiscount.TabIndex = 13
        '
        'CmbProductCategory
        '
        Me.CmbProductCategory.DropDownHeight = 30
        Me.CmbProductCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbProductCategory.FormattingEnabled = True
        Me.CmbProductCategory.IntegralHeight = False
        Me.CmbProductCategory.Location = New System.Drawing.Point(516, 232)
        Me.CmbProductCategory.MaxDropDownItems = 100
        Me.CmbProductCategory.Name = "CmbProductCategory"
        Me.CmbProductCategory.Size = New System.Drawing.Size(230, 21)
        Me.CmbProductCategory.Sorted = True
        Me.CmbProductCategory.TabIndex = 14
        '
        'FormProducts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1002, 685)
        Me.Controls.Add(Me.CmbProductCategory)
        Me.Controls.Add(Me.TxtProductDiscount)
        Me.Controls.Add(Me.LblProductDiscount)
        Me.Controls.Add(Me.CmbProductName)
        Me.Controls.Add(Me.BtnProduct)
        Me.Controls.Add(Me.TxtProductQuantity)
        Me.Controls.Add(Me.TxtProductPrice)
        Me.Controls.Add(Me.TxtProductDescription)
        Me.Controls.Add(Me.TxtProductName)
        Me.Controls.Add(Me.LblProductCategory)
        Me.Controls.Add(Me.LblProductQuantity)
        Me.Controls.Add(Me.LblProductPrice)
        Me.Controls.Add(Me.LblProductDescription)
        Me.Controls.Add(Me.LblProductName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FormProducts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Products"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblProductName As System.Windows.Forms.Label
    Friend WithEvents LblProductDescription As System.Windows.Forms.Label
    Friend WithEvents LblProductPrice As System.Windows.Forms.Label
    Friend WithEvents LblProductQuantity As System.Windows.Forms.Label
    Friend WithEvents LblProductCategory As System.Windows.Forms.Label
    Friend WithEvents TxtProductName As System.Windows.Forms.TextBox
    Friend WithEvents TxtProductDescription As System.Windows.Forms.TextBox
    Friend WithEvents TxtProductPrice As System.Windows.Forms.TextBox
    Friend WithEvents TxtProductQuantity As System.Windows.Forms.TextBox
    Friend WithEvents BtnProduct As System.Windows.Forms.Button
    Friend WithEvents CmbProductName As System.Windows.Forms.ComboBox
    Friend WithEvents LblProductDiscount As System.Windows.Forms.Label
    Friend WithEvents TxtProductDiscount As System.Windows.Forms.TextBox
    Friend WithEvents CmbProductCategory As System.Windows.Forms.ComboBox
End Class
