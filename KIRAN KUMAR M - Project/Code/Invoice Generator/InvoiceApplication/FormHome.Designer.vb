<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormHome
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ProductToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CategoriesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnHomeAdd = New System.Windows.Forms.Button()
        Me.BtnHomeUpdate = New System.Windows.Forms.Button()
        Me.BtnHomeDelete = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblHomeCaption = New System.Windows.Forms.Label()
        Me.PictureBoxHome = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBoxHome, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProductToolStripMenuItem, Me.CategoriesToolStripMenuItem, Me.CustomersToolStripMenuItem, Me.CartToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1444, 34)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ProductToolStripMenuItem
        '
        Me.ProductToolStripMenuItem.Font = New System.Drawing.Font("Palatino Linotype", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProductToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ProductToolStripMenuItem.Name = "ProductToolStripMenuItem"
        Me.ProductToolStripMenuItem.Size = New System.Drawing.Size(102, 30)
        Me.ProductToolStripMenuItem.Text = "Products"
        '
        'CategoriesToolStripMenuItem
        '
        Me.CategoriesToolStripMenuItem.Font = New System.Drawing.Font("Palatino Linotype", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CategoriesToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CategoriesToolStripMenuItem.Name = "CategoriesToolStripMenuItem"
        Me.CategoriesToolStripMenuItem.Size = New System.Drawing.Size(119, 30)
        Me.CategoriesToolStripMenuItem.Text = "Categories"
        '
        'CustomersToolStripMenuItem
        '
        Me.CustomersToolStripMenuItem.Font = New System.Drawing.Font("Palatino Linotype", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomersToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CustomersToolStripMenuItem.Name = "CustomersToolStripMenuItem"
        Me.CustomersToolStripMenuItem.Size = New System.Drawing.Size(120, 30)
        Me.CustomersToolStripMenuItem.Text = "Customers"
        '
        'CartToolStripMenuItem
        '
        Me.CartToolStripMenuItem.Font = New System.Drawing.Font("Palatino Linotype", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CartToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CartToolStripMenuItem.Name = "CartToolStripMenuItem"
        Me.CartToolStripMenuItem.Size = New System.Drawing.Size(63, 30)
        Me.CartToolStripMenuItem.Text = "Cart"
        '
        'BtnHomeAdd
        '
        Me.BtnHomeAdd.BackColor = System.Drawing.Color.White
        Me.BtnHomeAdd.Font = New System.Drawing.Font("Stencil", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnHomeAdd.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.BtnHomeAdd.Location = New System.Drawing.Point(0, 181)
        Me.BtnHomeAdd.Name = "BtnHomeAdd"
        Me.BtnHomeAdd.Size = New System.Drawing.Size(356, 80)
        Me.BtnHomeAdd.TabIndex = 1
        Me.BtnHomeAdd.Text = "Add"
        Me.BtnHomeAdd.UseVisualStyleBackColor = False
        '
        'BtnHomeUpdate
        '
        Me.BtnHomeUpdate.BackColor = System.Drawing.Color.Silver
        Me.BtnHomeUpdate.Font = New System.Drawing.Font("Stencil", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnHomeUpdate.ForeColor = System.Drawing.Color.Black
        Me.BtnHomeUpdate.Location = New System.Drawing.Point(0, 325)
        Me.BtnHomeUpdate.Name = "BtnHomeUpdate"
        Me.BtnHomeUpdate.Size = New System.Drawing.Size(356, 77)
        Me.BtnHomeUpdate.TabIndex = 2
        Me.BtnHomeUpdate.Text = "Update"
        Me.BtnHomeUpdate.UseVisualStyleBackColor = False
        '
        'BtnHomeDelete
        '
        Me.BtnHomeDelete.BackColor = System.Drawing.Color.Gray
        Me.BtnHomeDelete.Font = New System.Drawing.Font("Stencil", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnHomeDelete.ForeColor = System.Drawing.Color.White
        Me.BtnHomeDelete.Location = New System.Drawing.Point(-3, 463)
        Me.BtnHomeDelete.Name = "BtnHomeDelete"
        Me.BtnHomeDelete.Size = New System.Drawing.Size(359, 83)
        Me.BtnHomeDelete.TabIndex = 3
        Me.BtnHomeDelete.Text = "Delete"
        Me.BtnHomeDelete.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightGreen
        Me.Panel1.Controls.Add(Me.BtnHomeDelete)
        Me.Panel1.Controls.Add(Me.BtnHomeUpdate)
        Me.Panel1.Controls.Add(Me.BtnHomeAdd)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 34)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(356, 918)
        Me.Panel1.TabIndex = 4
        '
        'LblHomeCaption
        '
        Me.LblHomeCaption.AutoSize = True
        Me.LblHomeCaption.Font = New System.Drawing.Font("Algerian", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHomeCaption.Location = New System.Drawing.Point(953, 79)
        Me.LblHomeCaption.Name = "LblHomeCaption"
        Me.LblHomeCaption.Size = New System.Drawing.Size(168, 35)
        Me.LblHomeCaption.TabIndex = 5
        Me.LblHomeCaption.Text = "Products"
        '
        'PictureBoxHome
        '
        Me.PictureBoxHome.Image = Global.WindowsApplication1.My.Resources.Resources.Products2
        Me.PictureBoxHome.InitialImage = Nothing
        Me.PictureBoxHome.Location = New System.Drawing.Point(508, 159)
        Me.PictureBoxHome.Name = "PictureBoxHome"
        Me.PictureBoxHome.Size = New System.Drawing.Size(1036, 734)
        Me.PictureBoxHome.TabIndex = 6
        Me.PictureBoxHome.TabStop = False
        '
        'FormHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1444, 952)
        Me.Controls.Add(Me.PictureBoxHome)
        Me.Controls.Add(Me.LblHomeCaption)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormHome"
        Me.Text = "Home"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBoxHome, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ProductToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CategoriesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnHomeAdd As System.Windows.Forms.Button
    Friend WithEvents BtnHomeUpdate As System.Windows.Forms.Button
    Friend WithEvents BtnHomeDelete As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LblHomeCaption As System.Windows.Forms.Label
    Friend WithEvents PictureBoxHome As System.Windows.Forms.PictureBox

End Class
