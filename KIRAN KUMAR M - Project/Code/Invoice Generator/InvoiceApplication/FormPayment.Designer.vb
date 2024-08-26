<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPayment
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
        Me.GrbPaymentOptions = New System.Windows.Forms.GroupBox()
        Me.LblDigitalWallets = New System.Windows.Forms.Label()
        Me.Rdb8 = New System.Windows.Forms.RadioButton()
        Me.Rdb7 = New System.Windows.Forms.RadioButton()
        Me.Rdb6 = New System.Windows.Forms.RadioButton()
        Me.Rdb5 = New System.Windows.Forms.RadioButton()
        Me.LblCreditDebit = New System.Windows.Forms.Label()
        Me.Rdb4 = New System.Windows.Forms.RadioButton()
        Me.Rdb3 = New System.Windows.Forms.RadioButton()
        Me.Rdb2 = New System.Windows.Forms.RadioButton()
        Me.Rdb1 = New System.Windows.Forms.RadioButton()
        Me.LblSelectPaymentOption = New System.Windows.Forms.Label()
        Me.LblPurchaseSummary = New System.Windows.Forms.Label()
        Me.DgvPurchaseSummary = New System.Windows.Forms.DataGridView()
        Me.LblOrderTotal1 = New System.Windows.Forms.Label()
        Me.TxtFlatDiscount = New System.Windows.Forms.TextBox()
        Me.LblFlatDiscount = New System.Windows.Forms.Label()
        Me.LblTotAfterFlatDiscount1 = New System.Windows.Forms.Label()
        Me.BtnProceedPay = New System.Windows.Forms.Button()
        Me.BtnApplyFlatDiscount = New System.Windows.Forms.Button()
        Me.LblTotAfterFlatDiscount2 = New System.Windows.Forms.Label()
        Me.LblOrderTotal2 = New System.Windows.Forms.Label()
        Me.PbBar = New System.Windows.Forms.ProgressBar()
        Me.LblTotalAfterTax2 = New System.Windows.Forms.Label()
        Me.LblTotalAfterDiscntAndTax1 = New System.Windows.Forms.Label()
        Me.GrbPaymentOptions.SuspendLayout()
        CType(Me.DgvPurchaseSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrbPaymentOptions
        '
        Me.GrbPaymentOptions.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GrbPaymentOptions.Controls.Add(Me.LblDigitalWallets)
        Me.GrbPaymentOptions.Controls.Add(Me.Rdb8)
        Me.GrbPaymentOptions.Controls.Add(Me.Rdb7)
        Me.GrbPaymentOptions.Controls.Add(Me.Rdb6)
        Me.GrbPaymentOptions.Controls.Add(Me.Rdb5)
        Me.GrbPaymentOptions.Controls.Add(Me.LblCreditDebit)
        Me.GrbPaymentOptions.Controls.Add(Me.Rdb4)
        Me.GrbPaymentOptions.Controls.Add(Me.Rdb3)
        Me.GrbPaymentOptions.Controls.Add(Me.Rdb2)
        Me.GrbPaymentOptions.Controls.Add(Me.Rdb1)
        Me.GrbPaymentOptions.Controls.Add(Me.LblSelectPaymentOption)
        Me.GrbPaymentOptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrbPaymentOptions.Location = New System.Drawing.Point(273, 517)
        Me.GrbPaymentOptions.Margin = New System.Windows.Forms.Padding(4)
        Me.GrbPaymentOptions.Name = "GrbPaymentOptions"
        Me.GrbPaymentOptions.Padding = New System.Windows.Forms.Padding(4)
        Me.GrbPaymentOptions.Size = New System.Drawing.Size(504, 299)
        Me.GrbPaymentOptions.TabIndex = 1
        Me.GrbPaymentOptions.TabStop = False
        '
        'LblDigitalWallets
        '
        Me.LblDigitalWallets.AutoSize = True
        Me.LblDigitalWallets.Location = New System.Drawing.Point(277, 63)
        Me.LblDigitalWallets.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDigitalWallets.Name = "LblDigitalWallets"
        Me.LblDigitalWallets.Size = New System.Drawing.Size(94, 16)
        Me.LblDigitalWallets.TabIndex = 10
        Me.LblDigitalWallets.Text = "Digital Wallets"
        '
        'Rdb8
        '
        Me.Rdb8.AutoSize = True
        Me.Rdb8.Location = New System.Drawing.Point(291, 226)
        Me.Rdb8.Margin = New System.Windows.Forms.Padding(4)
        Me.Rdb8.Name = "Rdb8"
        Me.Rdb8.Size = New System.Drawing.Size(110, 20)
        Me.Rdb8.TabIndex = 9
        Me.Rdb8.TabStop = True
        Me.Rdb8.Text = "Samsung Pay"
        Me.Rdb8.UseVisualStyleBackColor = True
        '
        'Rdb7
        '
        Me.Rdb7.AutoSize = True
        Me.Rdb7.Location = New System.Drawing.Point(291, 188)
        Me.Rdb7.Margin = New System.Windows.Forms.Padding(4)
        Me.Rdb7.Name = "Rdb7"
        Me.Rdb7.Size = New System.Drawing.Size(89, 20)
        Me.Rdb7.TabIndex = 8
        Me.Rdb7.TabStop = True
        Me.Rdb7.Text = "Apple Pay"
        Me.Rdb7.UseVisualStyleBackColor = True
        '
        'Rdb6
        '
        Me.Rdb6.AutoSize = True
        Me.Rdb6.Location = New System.Drawing.Point(291, 148)
        Me.Rdb6.Margin = New System.Windows.Forms.Padding(4)
        Me.Rdb6.Name = "Rdb6"
        Me.Rdb6.Size = New System.Drawing.Size(70, 20)
        Me.Rdb6.TabIndex = 7
        Me.Rdb6.TabStop = True
        Me.Rdb6.Text = "PayPal"
        Me.Rdb6.UseVisualStyleBackColor = True
        '
        'Rdb5
        '
        Me.Rdb5.AutoSize = True
        Me.Rdb5.Location = New System.Drawing.Point(291, 106)
        Me.Rdb5.Margin = New System.Windows.Forms.Padding(4)
        Me.Rdb5.Name = "Rdb5"
        Me.Rdb5.Size = New System.Drawing.Size(98, 20)
        Me.Rdb5.TabIndex = 6
        Me.Rdb5.TabStop = True
        Me.Rdb5.Text = "Google Pay"
        Me.Rdb5.UseVisualStyleBackColor = True
        '
        'LblCreditDebit
        '
        Me.LblCreditDebit.AutoSize = True
        Me.LblCreditDebit.Location = New System.Drawing.Point(44, 62)
        Me.LblCreditDebit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCreditDebit.Name = "LblCreditDebit"
        Me.LblCreditDebit.Size = New System.Drawing.Size(118, 16)
        Me.LblCreditDebit.TabIndex = 5
        Me.LblCreditDebit.Text = "Credit/Debit Cards"
        '
        'Rdb4
        '
        Me.Rdb4.AutoSize = True
        Me.Rdb4.Location = New System.Drawing.Point(57, 225)
        Me.Rdb4.Margin = New System.Windows.Forms.Padding(4)
        Me.Rdb4.Name = "Rdb4"
        Me.Rdb4.Size = New System.Drawing.Size(80, 20)
        Me.Rdb4.TabIndex = 4
        Me.Rdb4.TabStop = True
        Me.Rdb4.Text = "Discover"
        Me.Rdb4.UseVisualStyleBackColor = True
        '
        'Rdb3
        '
        Me.Rdb3.AutoSize = True
        Me.Rdb3.Location = New System.Drawing.Point(57, 187)
        Me.Rdb3.Margin = New System.Windows.Forms.Padding(4)
        Me.Rdb3.Name = "Rdb3"
        Me.Rdb3.Size = New System.Drawing.Size(135, 20)
        Me.Rdb3.TabIndex = 3
        Me.Rdb3.TabStop = True
        Me.Rdb3.Text = "American Express"
        Me.Rdb3.UseVisualStyleBackColor = True
        '
        'Rdb2
        '
        Me.Rdb2.AutoSize = True
        Me.Rdb2.Location = New System.Drawing.Point(57, 148)
        Me.Rdb2.Margin = New System.Windows.Forms.Padding(4)
        Me.Rdb2.Name = "Rdb2"
        Me.Rdb2.Size = New System.Drawing.Size(96, 20)
        Me.Rdb2.TabIndex = 2
        Me.Rdb2.TabStop = True
        Me.Rdb2.Text = "MasterCard"
        Me.Rdb2.UseVisualStyleBackColor = True
        '
        'Rdb1
        '
        Me.Rdb1.AutoSize = True
        Me.Rdb1.Location = New System.Drawing.Point(57, 105)
        Me.Rdb1.Margin = New System.Windows.Forms.Padding(4)
        Me.Rdb1.Name = "Rdb1"
        Me.Rdb1.Size = New System.Drawing.Size(53, 20)
        Me.Rdb1.TabIndex = 1
        Me.Rdb1.TabStop = True
        Me.Rdb1.Text = "Visa"
        Me.Rdb1.UseVisualStyleBackColor = True
        '
        'LblSelectPaymentOption
        '
        Me.LblSelectPaymentOption.AutoSize = True
        Me.LblSelectPaymentOption.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSelectPaymentOption.Location = New System.Drawing.Point(8, 20)
        Me.LblSelectPaymentOption.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblSelectPaymentOption.Name = "LblSelectPaymentOption"
        Me.LblSelectPaymentOption.Size = New System.Drawing.Size(173, 16)
        Me.LblSelectPaymentOption.TabIndex = 0
        Me.LblSelectPaymentOption.Text = "Select Payment Option :"
        '
        'LblPurchaseSummary
        '
        Me.LblPurchaseSummary.AutoSize = True
        Me.LblPurchaseSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPurchaseSummary.Location = New System.Drawing.Point(149, 38)
        Me.LblPurchaseSummary.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPurchaseSummary.Name = "LblPurchaseSummary"
        Me.LblPurchaseSummary.Size = New System.Drawing.Size(173, 20)
        Me.LblPurchaseSummary.TabIndex = 2
        Me.LblPurchaseSummary.Text = "Purchase Summary :"
        '
        'DgvPurchaseSummary
        '
        Me.DgvPurchaseSummary.AllowUserToOrderColumns = True
        Me.DgvPurchaseSummary.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.DgvPurchaseSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPurchaseSummary.Location = New System.Drawing.Point(189, 90)
        Me.DgvPurchaseSummary.Margin = New System.Windows.Forms.Padding(4)
        Me.DgvPurchaseSummary.Name = "DgvPurchaseSummary"
        Me.DgvPurchaseSummary.Size = New System.Drawing.Size(1157, 283)
        Me.DgvPurchaseSummary.TabIndex = 3
        '
        'LblOrderTotal1
        '
        Me.LblOrderTotal1.AutoSize = True
        Me.LblOrderTotal1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrderTotal1.Location = New System.Drawing.Point(998, 587)
        Me.LblOrderTotal1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblOrderTotal1.Name = "LblOrderTotal1"
        Me.LblOrderTotal1.Size = New System.Drawing.Size(143, 20)
        Me.LblOrderTotal1.TabIndex = 6
        Me.LblOrderTotal1.Text = "ORDER TOTAL :"
        '
        'TxtFlatDiscount
        '
        Me.TxtFlatDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFlatDiscount.Location = New System.Drawing.Point(1193, 478)
        Me.TxtFlatDiscount.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtFlatDiscount.Name = "TxtFlatDiscount"
        Me.TxtFlatDiscount.Size = New System.Drawing.Size(132, 22)
        Me.TxtFlatDiscount.TabIndex = 7
        '
        'LblFlatDiscount
        '
        Me.LblFlatDiscount.AutoSize = True
        Me.LblFlatDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFlatDiscount.Location = New System.Drawing.Point(897, 481)
        Me.LblFlatDiscount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblFlatDiscount.Name = "LblFlatDiscount"
        Me.LblFlatDiscount.Size = New System.Drawing.Size(244, 16)
        Me.LblFlatDiscount.TabIndex = 8
        Me.LblFlatDiscount.Text = "Coupen Code for Flat Discount (Rs.500):"
        '
        'LblTotAfterFlatDiscount1
        '
        Me.LblTotAfterFlatDiscount1.AutoSize = True
        Me.LblTotAfterFlatDiscount1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotAfterFlatDiscount1.Location = New System.Drawing.Point(989, 530)
        Me.LblTotAfterFlatDiscount1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTotAfterFlatDiscount1.Name = "LblTotAfterFlatDiscount1"
        Me.LblTotAfterFlatDiscount1.Size = New System.Drawing.Size(152, 16)
        Me.LblTotAfterFlatDiscount1.TabIndex = 10
        Me.LblTotAfterFlatDiscount1.Text = "Total After Flat Discount:"
        '
        'BtnProceedPay
        '
        Me.BtnProceedPay.BackColor = System.Drawing.Color.LightGreen
        Me.BtnProceedPay.Font = New System.Drawing.Font("Stencil", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProceedPay.ForeColor = System.Drawing.Color.Crimson
        Me.BtnProceedPay.Location = New System.Drawing.Point(1014, 650)
        Me.BtnProceedPay.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnProceedPay.Name = "BtnProceedPay"
        Me.BtnProceedPay.Size = New System.Drawing.Size(311, 81)
        Me.BtnProceedPay.TabIndex = 11
        Me.BtnProceedPay.Text = "Proceed Payment"
        Me.BtnProceedPay.UseVisualStyleBackColor = False
        '
        'BtnApplyFlatDiscount
        '
        Me.BtnApplyFlatDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnApplyFlatDiscount.Location = New System.Drawing.Point(1359, 475)
        Me.BtnApplyFlatDiscount.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnApplyFlatDiscount.Name = "BtnApplyFlatDiscount"
        Me.BtnApplyFlatDiscount.Size = New System.Drawing.Size(96, 31)
        Me.BtnApplyFlatDiscount.TabIndex = 13
        Me.BtnApplyFlatDiscount.Text = "Apply"
        Me.BtnApplyFlatDiscount.UseVisualStyleBackColor = True
        '
        'LblTotAfterFlatDiscount2
        '
        Me.LblTotAfterFlatDiscount2.AutoSize = True
        Me.LblTotAfterFlatDiscount2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotAfterFlatDiscount2.Location = New System.Drawing.Point(1189, 530)
        Me.LblTotAfterFlatDiscount2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTotAfterFlatDiscount2.Name = "LblTotAfterFlatDiscount2"
        Me.LblTotAfterFlatDiscount2.Size = New System.Drawing.Size(143, 16)
        Me.LblTotAfterFlatDiscount2.TabIndex = 14
        Me.LblTotAfterFlatDiscount2.Text = "(total after flat discount)"
        '
        'LblOrderTotal2
        '
        Me.LblOrderTotal2.AutoSize = True
        Me.LblOrderTotal2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrderTotal2.Location = New System.Drawing.Point(1189, 587)
        Me.LblOrderTotal2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblOrderTotal2.Name = "LblOrderTotal2"
        Me.LblOrderTotal2.Size = New System.Drawing.Size(104, 20)
        Me.LblOrderTotal2.TabIndex = 15
        Me.LblOrderTotal2.Text = "(order total)"
        '
        'PbBar
        '
        Me.PbBar.Location = New System.Drawing.Point(883, 770)
        Me.PbBar.Margin = New System.Windows.Forms.Padding(4)
        Me.PbBar.MarqueeAnimationSpeed = 1
        Me.PbBar.Name = "PbBar"
        Me.PbBar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PbBar.Size = New System.Drawing.Size(600, 41)
        Me.PbBar.Step = 90
        Me.PbBar.TabIndex = 0
        Me.PbBar.Visible = False
        '
        'LblTotalAfterTax2
        '
        Me.LblTotalAfterTax2.AutoSize = True
        Me.LblTotalAfterTax2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAfterTax2.Location = New System.Drawing.Point(1189, 430)
        Me.LblTotalAfterTax2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTotalAfterTax2.Name = "LblTotalAfterTax2"
        Me.LblTotalAfterTax2.Size = New System.Drawing.Size(169, 16)
        Me.LblTotalAfterTax2.TabIndex = 16
        Me.LblTotalAfterTax2.Text = "(total after discount and tax)"
        '
        'LblTotalAfterDiscntAndTax1
        '
        Me.LblTotalAfterDiscntAndTax1.AutoSize = True
        Me.LblTotalAfterDiscntAndTax1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAfterDiscntAndTax1.Location = New System.Drawing.Point(958, 430)
        Me.LblTotalAfterDiscntAndTax1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTotalAfterDiscntAndTax1.Name = "LblTotalAfterDiscntAndTax1"
        Me.LblTotalAfterDiscntAndTax1.Size = New System.Drawing.Size(183, 16)
        Me.LblTotalAfterDiscntAndTax1.TabIndex = 9
        Me.LblTotalAfterDiscntAndTax1.Text = "Total After Discount And Tax: "
        '
        'FormPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1719, 857)
        Me.Controls.Add(Me.PbBar)
        Me.Controls.Add(Me.LblTotalAfterTax2)
        Me.Controls.Add(Me.LblOrderTotal2)
        Me.Controls.Add(Me.LblTotAfterFlatDiscount2)
        Me.Controls.Add(Me.BtnApplyFlatDiscount)
        Me.Controls.Add(Me.BtnProceedPay)
        Me.Controls.Add(Me.LblTotAfterFlatDiscount1)
        Me.Controls.Add(Me.LblTotalAfterDiscntAndTax1)
        Me.Controls.Add(Me.LblFlatDiscount)
        Me.Controls.Add(Me.TxtFlatDiscount)
        Me.Controls.Add(Me.LblOrderTotal1)
        Me.Controls.Add(Me.DgvPurchaseSummary)
        Me.Controls.Add(Me.LblPurchaseSummary)
        Me.Controls.Add(Me.GrbPaymentOptions)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "FormPayment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payment"
        Me.GrbPaymentOptions.ResumeLayout(False)
        Me.GrbPaymentOptions.PerformLayout()
        CType(Me.DgvPurchaseSummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GrbPaymentOptions As System.Windows.Forms.GroupBox
    Friend WithEvents LblSelectPaymentOption As System.Windows.Forms.Label
    Friend WithEvents LblDigitalWallets As System.Windows.Forms.Label
    Friend WithEvents Rdb8 As System.Windows.Forms.RadioButton
    Friend WithEvents Rdb7 As System.Windows.Forms.RadioButton
    Friend WithEvents Rdb6 As System.Windows.Forms.RadioButton
    Friend WithEvents Rdb5 As System.Windows.Forms.RadioButton
    Friend WithEvents LblCreditDebit As System.Windows.Forms.Label
    Friend WithEvents Rdb4 As System.Windows.Forms.RadioButton
    Friend WithEvents Rdb3 As System.Windows.Forms.RadioButton
    Friend WithEvents Rdb2 As System.Windows.Forms.RadioButton
    Friend WithEvents Rdb1 As System.Windows.Forms.RadioButton
    Friend WithEvents LblPurchaseSummary As System.Windows.Forms.Label
    Friend WithEvents DgvPurchaseSummary As System.Windows.Forms.DataGridView
    Friend WithEvents LblOrderTotal1 As System.Windows.Forms.Label
    Friend WithEvents TxtFlatDiscount As System.Windows.Forms.TextBox
    Friend WithEvents LblFlatDiscount As System.Windows.Forms.Label
    Friend WithEvents LblTotAfterFlatDiscount1 As System.Windows.Forms.Label
    Friend WithEvents BtnProceedPay As System.Windows.Forms.Button
    Friend WithEvents BtnApplyFlatDiscount As System.Windows.Forms.Button
    Friend WithEvents LblTotAfterFlatDiscount2 As System.Windows.Forms.Label
    Friend WithEvents LblOrderTotal2 As System.Windows.Forms.Label
    Friend WithEvents PbBar As System.Windows.Forms.ProgressBar
    Friend WithEvents LblTotalAfterTax2 As System.Windows.Forms.Label
    Friend WithEvents LblTotalAfterDiscntAndTax1 As System.Windows.Forms.Label
End Class
