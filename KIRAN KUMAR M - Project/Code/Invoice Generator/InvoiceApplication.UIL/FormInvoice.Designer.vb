<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInvoice
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
        Me.LblInvoice = New System.Windows.Forms.Label()
        Me.LblCustDetails1 = New System.Windows.Forms.Label()
        Me.DgvFinalInvoice = New System.Windows.Forms.DataGridView()
        Me.LblPurchaseDetails1 = New System.Windows.Forms.Label()
        Me.LblTotalAmount1 = New System.Windows.Forms.Label()
        Me.LblPaymentOption1 = New System.Windows.Forms.Label()
        Me.LblPaymentStatus1 = New System.Windows.Forms.Label()
        Me.BtnInvoiceOK = New System.Windows.Forms.Button()
        Me.LblCustDetails2 = New System.Windows.Forms.Label()
        Me.LblPaymentOption2 = New System.Windows.Forms.Label()
        Me.LblTotalAmount2 = New System.Windows.Forms.Label()
        Me.LblPurchaseDetails2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblDateOfPayment1 = New System.Windows.Forms.Label()
        Me.LblDateOfPayment2 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.DgvFinalInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblInvoice
        '
        Me.LblInvoice.AutoSize = True
        Me.LblInvoice.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInvoice.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblInvoice.Location = New System.Drawing.Point(288, 43)
        Me.LblInvoice.Name = "LblInvoice"
        Me.LblInvoice.Size = New System.Drawing.Size(116, 26)
        Me.LblInvoice.TabIndex = 0
        Me.LblInvoice.Text = "INVOICE"
        '
        'LblCustDetails1
        '
        Me.LblCustDetails1.AutoSize = True
        Me.LblCustDetails1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCustDetails1.Location = New System.Drawing.Point(21, 99)
        Me.LblCustDetails1.Name = "LblCustDetails1"
        Me.LblCustDetails1.Size = New System.Drawing.Size(149, 18)
        Me.LblCustDetails1.TabIndex = 1
        Me.LblCustDetails1.Text = "Customer Details :"
        '
        'DgvFinalInvoice
        '
        Me.DgvFinalInvoice.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.DgvFinalInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvFinalInvoice.Location = New System.Drawing.Point(303, 704)
        Me.DgvFinalInvoice.Name = "DgvFinalInvoice"
        Me.DgvFinalInvoice.Size = New System.Drawing.Size(32, 27)
        Me.DgvFinalInvoice.TabIndex = 2
        Me.DgvFinalInvoice.Visible = False
        '
        'LblPurchaseDetails1
        '
        Me.LblPurchaseDetails1.AutoSize = True
        Me.LblPurchaseDetails1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPurchaseDetails1.Location = New System.Drawing.Point(17, 181)
        Me.LblPurchaseDetails1.Name = "LblPurchaseDetails1"
        Me.LblPurchaseDetails1.Size = New System.Drawing.Size(171, 18)
        Me.LblPurchaseDetails1.TabIndex = 3
        Me.LblPurchaseDetails1.Text = "Purchased Products: "
        '
        'LblTotalAmount1
        '
        Me.LblTotalAmount1.AutoSize = True
        Me.LblTotalAmount1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAmount1.Location = New System.Drawing.Point(17, 470)
        Me.LblTotalAmount1.Name = "LblTotalAmount1"
        Me.LblTotalAmount1.Size = New System.Drawing.Size(156, 18)
        Me.LblTotalAmount1.TabIndex = 4
        Me.LblTotalAmount1.Text = "Total Amount Paid :"
        '
        'LblPaymentOption1
        '
        Me.LblPaymentOption1.AutoSize = True
        Me.LblPaymentOption1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPaymentOption1.Location = New System.Drawing.Point(17, 515)
        Me.LblPaymentOption1.Name = "LblPaymentOption1"
        Me.LblPaymentOption1.Size = New System.Drawing.Size(195, 16)
        Me.LblPaymentOption1.TabIndex = 5
        Me.LblPaymentOption1.Text = "Selected Payment Option : "
        '
        'LblPaymentStatus1
        '
        Me.LblPaymentStatus1.AutoSize = True
        Me.LblPaymentStatus1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPaymentStatus1.Location = New System.Drawing.Point(17, 555)
        Me.LblPaymentStatus1.Name = "LblPaymentStatus1"
        Me.LblPaymentStatus1.Size = New System.Drawing.Size(123, 16)
        Me.LblPaymentStatus1.TabIndex = 6
        Me.LblPaymentStatus1.Text = "Payment Status :"
        '
        'BtnInvoiceOK
        '
        Me.BtnInvoiceOK.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.BtnInvoiceOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnInvoiceOK.Location = New System.Drawing.Point(245, 695)
        Me.BtnInvoiceOK.Name = "BtnInvoiceOK"
        Me.BtnInvoiceOK.Size = New System.Drawing.Size(189, 48)
        Me.BtnInvoiceOK.TabIndex = 7
        Me.BtnInvoiceOK.Text = "OK"
        Me.BtnInvoiceOK.UseVisualStyleBackColor = False
        '
        'LblCustDetails2
        '
        Me.LblCustDetails2.AutoSize = True
        Me.LblCustDetails2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCustDetails2.Location = New System.Drawing.Point(231, 99)
        Me.LblCustDetails2.Name = "LblCustDetails2"
        Me.LblCustDetails2.Size = New System.Drawing.Size(132, 16)
        Me.LblCustDetails2.TabIndex = 8
        Me.LblCustDetails2.Text = "(customer details)"
        '
        'LblPaymentOption2
        '
        Me.LblPaymentOption2.AutoSize = True
        Me.LblPaymentOption2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPaymentOption2.Location = New System.Drawing.Point(231, 515)
        Me.LblPaymentOption2.Name = "LblPaymentOption2"
        Me.LblPaymentOption2.Size = New System.Drawing.Size(188, 16)
        Me.LblPaymentOption2.TabIndex = 9
        Me.LblPaymentOption2.Text = "(selected payment option)"
        '
        'LblTotalAmount2
        '
        Me.LblTotalAmount2.AutoSize = True
        Me.LblTotalAmount2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAmount2.Location = New System.Drawing.Point(231, 470)
        Me.LblTotalAmount2.Name = "LblTotalAmount2"
        Me.LblTotalAmount2.Size = New System.Drawing.Size(150, 18)
        Me.LblTotalAmount2.TabIndex = 10
        Me.LblTotalAmount2.Text = "(total amount paid)"
        '
        'LblPurchaseDetails2
        '
        Me.LblPurchaseDetails2.AutoSize = True
        Me.LblPurchaseDetails2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPurchaseDetails2.Location = New System.Drawing.Point(231, 181)
        Me.LblPurchaseDetails2.Name = "LblPurchaseDetails2"
        Me.LblPurchaseDetails2.Size = New System.Drawing.Size(127, 13)
        Me.LblPurchaseDetails2.TabIndex = 11
        Me.LblPurchaseDetails2.Text = "(purchased products)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label1.Location = New System.Drawing.Point(216, 652)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(254, 18)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Thank you for shopping With Us!"
        '
        'LblDateOfPayment1
        '
        Me.LblDateOfPayment1.AutoSize = True
        Me.LblDateOfPayment1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDateOfPayment1.Location = New System.Drawing.Point(17, 593)
        Me.LblDateOfPayment1.Name = "LblDateOfPayment1"
        Me.LblDateOfPayment1.Size = New System.Drawing.Size(132, 16)
        Me.LblDateOfPayment1.TabIndex = 13
        Me.LblDateOfPayment1.Text = "Date Of Payment :"
        '
        'LblDateOfPayment2
        '
        Me.LblDateOfPayment2.AutoSize = True
        Me.LblDateOfPayment2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDateOfPayment2.Location = New System.Drawing.Point(231, 593)
        Me.LblDateOfPayment2.Name = "LblDateOfPayment2"
        Me.LblDateOfPayment2.Size = New System.Drawing.Size(112, 16)
        Me.LblDateOfPayment2.TabIndex = 14
        Me.LblDateOfPayment2.Text = "(date payment)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(231, 555)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 16)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Success"
        '
        'FormInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 786)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblDateOfPayment2)
        Me.Controls.Add(Me.LblDateOfPayment1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblPurchaseDetails2)
        Me.Controls.Add(Me.LblTotalAmount2)
        Me.Controls.Add(Me.LblPaymentOption2)
        Me.Controls.Add(Me.LblCustDetails2)
        Me.Controls.Add(Me.BtnInvoiceOK)
        Me.Controls.Add(Me.LblPaymentStatus1)
        Me.Controls.Add(Me.LblPaymentOption1)
        Me.Controls.Add(Me.LblTotalAmount1)
        Me.Controls.Add(Me.LblPurchaseDetails1)
        Me.Controls.Add(Me.DgvFinalInvoice)
        Me.Controls.Add(Me.LblCustDetails1)
        Me.Controls.Add(Me.LblInvoice)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FormInvoice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Invoice"
        CType(Me.DgvFinalInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblInvoice As System.Windows.Forms.Label
    Friend WithEvents LblCustDetails1 As System.Windows.Forms.Label
    Friend WithEvents DgvFinalInvoice As System.Windows.Forms.DataGridView
    Friend WithEvents LblPurchaseDetails1 As System.Windows.Forms.Label
    Friend WithEvents LblTotalAmount1 As System.Windows.Forms.Label
    Friend WithEvents LblPaymentOption1 As System.Windows.Forms.Label
    Friend WithEvents LblPaymentStatus1 As System.Windows.Forms.Label
    Friend WithEvents BtnInvoiceOK As System.Windows.Forms.Button
    Friend WithEvents LblCustDetails2 As System.Windows.Forms.Label
    Friend WithEvents LblPaymentOption2 As System.Windows.Forms.Label
    Friend WithEvents LblTotalAmount2 As System.Windows.Forms.Label
    Friend WithEvents LblPurchaseDetails2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblDateOfPayment1 As System.Windows.Forms.Label
    Friend WithEvents LblDateOfPayment2 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
