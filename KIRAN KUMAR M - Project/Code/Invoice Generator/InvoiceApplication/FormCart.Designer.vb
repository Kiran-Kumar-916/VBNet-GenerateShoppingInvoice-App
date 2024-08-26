<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCart
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
        Me.CmbCustomerInCart = New System.Windows.Forms.ComboBox()
        Me.LblCustomerInCart = New System.Windows.Forms.Label()
        Me.DgvStocks = New System.Windows.Forms.DataGridView()
        Me.DgvCart = New System.Windows.Forms.DataGridView()
        Me.BtnAddToCart = New System.Windows.Forms.Button()
        Me.BtnPlaceOrder = New System.Windows.Forms.Button()
        Me.LblProductsInStock = New System.Windows.Forms.Label()
        Me.LblMyCart = New System.Windows.Forms.Label()
        Me.BtnRemoveAllFromCart = New System.Windows.Forms.Button()
        CType(Me.DgvStocks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvCart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmbCustomerInCart
        '
        Me.CmbCustomerInCart.DropDownHeight = 200
        Me.CmbCustomerInCart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCustomerInCart.FormattingEnabled = True
        Me.CmbCustomerInCart.IntegralHeight = False
        Me.CmbCustomerInCart.ItemHeight = 13
        Me.CmbCustomerInCart.Location = New System.Drawing.Point(277, 57)
        Me.CmbCustomerInCart.MaxDropDownItems = 100
        Me.CmbCustomerInCart.Name = "CmbCustomerInCart"
        Me.CmbCustomerInCart.Size = New System.Drawing.Size(354, 21)
        Me.CmbCustomerInCart.Sorted = True
        Me.CmbCustomerInCart.TabIndex = 0
        '
        'LblCustomerInCart
        '
        Me.LblCustomerInCart.AutoSize = True
        Me.LblCustomerInCart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCustomerInCart.Location = New System.Drawing.Point(88, 55)
        Me.LblCustomerInCart.Name = "LblCustomerInCart"
        Me.LblCustomerInCart.Size = New System.Drawing.Size(147, 20)
        Me.LblCustomerInCart.TabIndex = 1
        Me.LblCustomerInCart.Text = "Customer Name :"
        '
        'DgvStocks
        '
        Me.DgvStocks.AllowUserToAddRows = False
        Me.DgvStocks.AllowUserToDeleteRows = False
        Me.DgvStocks.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.DgvStocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvStocks.Location = New System.Drawing.Point(91, 155)
        Me.DgvStocks.Name = "DgvStocks"
        Me.DgvStocks.RowHeadersWidth = 50
        Me.DgvStocks.Size = New System.Drawing.Size(702, 450)
        Me.DgvStocks.TabIndex = 2
        '
        'DgvCart
        '
        Me.DgvCart.AllowUserToAddRows = False
        Me.DgvCart.AllowUserToDeleteRows = False
        Me.DgvCart.AllowUserToOrderColumns = True
        Me.DgvCart.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.DgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvCart.Location = New System.Drawing.Point(904, 155)
        Me.DgvCart.Name = "DgvCart"
        Me.DgvCart.RowHeadersWidth = 50
        Me.DgvCart.Size = New System.Drawing.Size(702, 450)
        Me.DgvCart.TabIndex = 3
        '
        'BtnAddToCart
        '
        Me.BtnAddToCart.BackColor = System.Drawing.Color.LightGreen
        Me.BtnAddToCart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAddToCart.Location = New System.Drawing.Point(553, 653)
        Me.BtnAddToCart.Name = "BtnAddToCart"
        Me.BtnAddToCart.Size = New System.Drawing.Size(240, 66)
        Me.BtnAddToCart.TabIndex = 4
        Me.BtnAddToCart.Text = "Add More to Cart"
        Me.BtnAddToCart.UseVisualStyleBackColor = False
        '
        'BtnPlaceOrder
        '
        Me.BtnPlaceOrder.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BtnPlaceOrder.Font = New System.Drawing.Font("Stencil", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPlaceOrder.ForeColor = System.Drawing.Color.Blue
        Me.BtnPlaceOrder.Location = New System.Drawing.Point(405, 750)
        Me.BtnPlaceOrder.Name = "BtnPlaceOrder"
        Me.BtnPlaceOrder.Size = New System.Drawing.Size(890, 47)
        Me.BtnPlaceOrder.TabIndex = 5
        Me.BtnPlaceOrder.Text = "Place Order"
        Me.BtnPlaceOrder.UseVisualStyleBackColor = False
        '
        'LblProductsInStock
        '
        Me.LblProductsInStock.AutoSize = True
        Me.LblProductsInStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProductsInStock.Location = New System.Drawing.Point(88, 119)
        Me.LblProductsInStock.Name = "LblProductsInStock"
        Me.LblProductsInStock.Size = New System.Drawing.Size(162, 20)
        Me.LblProductsInStock.TabIndex = 6
        Me.LblProductsInStock.Text = "Products In Stock :"
        '
        'LblMyCart
        '
        Me.LblMyCart.AutoSize = True
        Me.LblMyCart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMyCart.Location = New System.Drawing.Point(901, 119)
        Me.LblMyCart.Name = "LblMyCart"
        Me.LblMyCart.Size = New System.Drawing.Size(80, 20)
        Me.LblMyCart.TabIndex = 7
        Me.LblMyCart.Text = "My Cart :"
        '
        'BtnRemoveAllFromCart
        '
        Me.BtnRemoveAllFromCart.BackColor = System.Drawing.Color.LightSalmon
        Me.BtnRemoveAllFromCart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRemoveAllFromCart.Location = New System.Drawing.Point(904, 653)
        Me.BtnRemoveAllFromCart.Name = "BtnRemoveAllFromCart"
        Me.BtnRemoveAllFromCart.Size = New System.Drawing.Size(240, 66)
        Me.BtnRemoveAllFromCart.TabIndex = 8
        Me.BtnRemoveAllFromCart.Text = "Remove Product From Cart"
        Me.BtnRemoveAllFromCart.UseVisualStyleBackColor = False
        '
        'FormCart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1694, 871)
        Me.Controls.Add(Me.BtnRemoveAllFromCart)
        Me.Controls.Add(Me.LblMyCart)
        Me.Controls.Add(Me.LblProductsInStock)
        Me.Controls.Add(Me.BtnPlaceOrder)
        Me.Controls.Add(Me.BtnAddToCart)
        Me.Controls.Add(Me.DgvCart)
        Me.Controls.Add(Me.DgvStocks)
        Me.Controls.Add(Me.LblCustomerInCart)
        Me.Controls.Add(Me.CmbCustomerInCart)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "FormCart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Shopping Cart"
        CType(Me.DgvStocks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvCart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmbCustomerInCart As System.Windows.Forms.ComboBox
    Friend WithEvents LblCustomerInCart As System.Windows.Forms.Label
    Friend WithEvents DgvStocks As System.Windows.Forms.DataGridView
    Friend WithEvents DgvCart As System.Windows.Forms.DataGridView
    Friend WithEvents BtnAddToCart As System.Windows.Forms.Button
    Friend WithEvents BtnPlaceOrder As System.Windows.Forms.Button
    Friend WithEvents LblProductsInStock As System.Windows.Forms.Label
    Friend WithEvents LblMyCart As System.Windows.Forms.Label
    Friend WithEvents BtnRemoveAllFromCart As System.Windows.Forms.Button
End Class
