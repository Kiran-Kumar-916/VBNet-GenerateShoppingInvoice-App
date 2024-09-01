Imports BLL
Imports DAL

Public Class FormInvoice
    Const InvoiceTableNameCol As String = "Name"
    Const InvoiceTablePriceCol As String = "Price"
    Const InvoiceTableQuantityCol As String = "Quantity"
    Const InvoiceTableDiscountCol As String = "Discount"
    Const InvoiceTableTaxRateCol As String = "TaxRate"
    Const InvoiceTableSubTotalCol As String = "Sub Total" & vbNewLine & "(After Discount & Tax)"
    Const InvoiceTableCategoryCol As String = "Category"
    Const PaymentTableHiddenCol As String = "RowNumInOtherTable"

    Private Sub FormInvoice_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Dim lstCustomerDetails() As String

            Dim CustomerObj As New CustomersManager(CustomersDatabaseHandler)
            lstCustomerDetails = CustomerObj.GetSelectedCustomerDetails(FormCart.CmbCustomerInCart.Text)

            LblCustDetails2.Text = lstCustomerDetails(0) & vbNewLine & lstCustomerDetails(1) & vbNewLine & lstCustomerDetails(2) & vbNewLine & lstCustomerDetails(3)

            Dim name As String
            Dim pricePerUnit As Decimal
            Dim quantity As Integer
            Dim discount As Decimal
            Dim tax As Decimal

            '------------------------------------------------------------------------------------------
            'Updating Hidden DataGridView In Invoice Window
            DgvFinalInvoice.Columns.Clear()

            Dim DataGridViewCol As DataGridViewTextBoxColumn

            For Each DgvPurchaseSummaryCol As DataGridViewColumn In FormPayment.DgvPurchaseSummary.Columns
                If DgvPurchaseSummaryCol.Name <> PaymentTableHiddenCol Then
                    DataGridViewCol = New DataGridViewTextBoxColumn
                    DataGridViewCol.Name = DgvPurchaseSummaryCol.Name
                    DataGridViewCol.HeaderText = DgvPurchaseSummaryCol.HeaderText
                    DgvFinalInvoice.Columns.Add(DataGridViewCol)
                End If
            Next

            DgvFinalInvoice.ReadOnly = True
            DgvFinalInvoice.AllowUserToAddRows = False

            Dim DataGridRow As DataGridViewRow

            For row As Integer = 0 To FormPayment.DgvPurchaseSummary.RowCount - 1
                DataGridRow = New DataGridViewRow
                DataGridRow.CreateCells(DgvFinalInvoice)
                For col As Integer = 0 To FormPayment.DgvPurchaseSummary.ColumnCount - 1
                    DataGridRow.Cells(col).Value = FormPayment.DgvPurchaseSummary.Rows(row).Cells(col).Value
                Next
                DgvFinalInvoice.Rows.Add(DataGridRow)
            Next
            '---------------------------------------------------------------------------------------------

            Dim productsList As List(Of Product) = New List(Of Product)
            Dim percentageDiscountsList As List(Of PercentageDiscount) = New List(Of PercentageDiscount)
            Dim TaxesList As List(Of Tax) = New List(Of Tax)
            Dim flatAmountDiscount As New FlatAmountDiscount(FormPayment.FlatDiscountAmountExample) 'FLAT 500

            For row As Integer = 0 To DgvFinalInvoice.RowCount - 1
                name = DgvFinalInvoice.Rows(row).Cells(InvoiceTableNameCol).Value
                pricePerUnit = DgvFinalInvoice.Rows(row).Cells(InvoiceTablePriceCol).Value
                quantity = DgvFinalInvoice.Rows(row).Cells(InvoiceTableQuantityCol).Value
                discount = DgvFinalInvoice.Rows(row).Cells(InvoiceTableDiscountCol).Value
                tax = DgvFinalInvoice.Rows(row).Cells(InvoiceTableTaxRateCol).Value

                productsList.Add(New Product(name, pricePerUnit, quantity))
                percentageDiscountsList.Add(New PercentageDiscount(discount))
                TaxesList.Add(New Tax(tax))
            Next

            'Generate Invoice Sumary By Calculating Total Amount (Applying Discounts & Taxes)
            Dim invoiceSummary As String

            Dim OrderTotalObj As New InvoiceGenerator(eligibleForFlatDiscount:=FormPayment.EligibleForFlatDiscount)
            invoiceSummary = OrderTotalObj.GenerateInvoiceForOrderTotal(productsList, percentageDiscountsList, TaxesList, flatAmountDiscount)

            'Update Customer Details, Product Details, Discounts, Tax in Invoice Summary
            LblPurchaseDetails2.Text = invoiceSummary

            'Show Total Amount In Invoice Sumary
            LblTotalAmount2.Text = FormPayment.LblOrderTotal2.Text

            'Update Payment Option in Invoice Summary
            For Each iControl As Control In FormPayment.GrbPaymentOptions.Controls
                If TypeOf iControl Is RadioButton Then
                    Dim rb As RadioButton = CType(iControl, RadioButton)
                    If rb.Checked = True Then
                        LblPaymentOption2.Text = rb.Text
                        Exit For
                    End If
                End If
            Next

            LblDateOfPayment2.Text = Format(Now, "dd-MMM-yyyy hh:mm:ss tt")
        Catch ex As InvoiceGenerationException
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            MessageBox.Show("An Unexpected Error Occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub BtnInvoiceOK_Click(sender As System.Object, e As System.EventArgs) Handles BtnInvoiceOK.Click
        Try
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("An Unexpected Error Occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
End Class

