Imports System.Exception
Imports BLL
Imports DAL

Public Class FormPayment
    Const PaymentTableNameCol As String = "Name"
    Const PaymentTableCategoryCol As String = "Category"
    Const PaymentTablePriceCol As String = "Price"
    Const PaymentTableQuantityCol As String = "Quantity"
    Const PaymentTableDiscountCol As String = "Discount"
    Const PaymentTableTaxRateCol As String = "TaxRate"
    Const PaymentTableSubTotalCol As String = "Sub Total" & vbNewLine & "(After Discount & Tax)"
    Const CartTableHiddenCol As String = "RowNumInOtherTable"
    Const CoupenCodeExample As String = "FLAT500"
    Public Const FlatDiscountAmountExample As Decimal = 500 'Rs.500 FLAT Discount
    Public EligibleForFlatDiscount As Boolean
    Private Sub FormPayment_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            EligibleForFlatDiscount = False 'Set default Value Before Loading Payment Window

            DgvPurchaseSummary.Columns.Clear()

            'Set Columns To Purchase Summary DataGridView
            Dim DataGridViewCol As DataGridViewTextBoxColumn
            For Each DgvStocksCol As DataGridViewColumn In FormCart.DgvCart.Columns
                If DgvStocksCol.Name <> CartTableHiddenCol Then
                    DataGridViewCol = New DataGridViewTextBoxColumn
                    DataGridViewCol.Name = DgvStocksCol.Name
                    DataGridViewCol.HeaderText = DgvStocksCol.HeaderText
                    DgvPurchaseSummary.Columns.Add(DataGridViewCol)
                End If
            Next

            DgvPurchaseSummary.ReadOnly = True
            DgvPurchaseSummary.AllowUserToAddRows = False

            'Add "TaxRate" column
            DataGridViewCol = New DataGridViewTextBoxColumn
            DataGridViewCol.Name = PaymentTableTaxRateCol
            DataGridViewCol.HeaderText = PaymentTableTaxRateCol
            DgvPurchaseSummary.Columns.Add(DataGridViewCol)

            'Update Rows To Purchase Summary DataGridView In Payment window
            Dim DataGridRow As DataGridViewRow
            For row As Integer = 0 To FormCart.DgvCart.RowCount - 1
                DataGridRow = New DataGridViewRow
                DataGridRow.CreateCells(DgvPurchaseSummary)
                For col As Integer = 0 To FormCart.DgvCart.ColumnCount - 2 'to avoid last column -2 done
                    DataGridRow.Cells(col).Value = FormCart.DgvCart.Rows(row).Cells(col).Value
                Next
                DgvPurchaseSummary.Rows.Add(DataGridRow)
            Next

            Dim dataTab As DataTable
            Dim CategoryObj As New CategoriesManager(CategoriesDatabaseHandler)
            Dim categorTemp As String
            Dim taxRateTemp As String

            'Load All Categories To Datatable
            dataTab = CategoryObj.GetAllCategoriesDetails()

            'Update TaxRate from Categories Table
            Dim dtrow() As DataRow
            For row As Integer = 0 To DgvPurchaseSummary.RowCount - 1
                categorTemp = FormCart.DgvCart.Rows(row).Cells(PaymentTableCategoryCol).Value
                dtrow = dataTab.Select("[" & PaymentTableNameCol & "]='" & categorTemp & "'")

                If dtrow.Length > 0 Then
                    taxRateTemp = dtrow(0).Item(PaymentTableTaxRateCol).ToString
                    DgvPurchaseSummary.Rows(row).Cells(PaymentTableTaxRateCol).Value = taxRateTemp
                End If
            Next

            'Add "Sub Total (After Discount & Tax)" column
            DataGridViewCol = New DataGridViewTextBoxColumn
            DataGridViewCol.Name = PaymentTableSubTotalCol
            DataGridViewCol.HeaderText = PaymentTableSubTotalCol
            DgvPurchaseSummary.Columns.Add(DataGridViewCol)


            Dim name As String
            Dim category As String
            Dim pricePerUnit As Decimal
            Dim quantity As Integer
            Dim discountRate As Decimal
            Dim taxRate As String
            Dim subtotal As Decimal
            Dim TotalAfterDiscountAndTax As Decimal

            'Calculate Subtotal & Update In DataGridView 'Sub Total (After Discount & Tax)' column
            For row As Integer = 0 To DgvPurchaseSummary.RowCount - 1
                name = DgvPurchaseSummary.Rows(row).Cells(PaymentTableNameCol).Value                  'Name Of Product
                pricePerUnit = DgvPurchaseSummary.Rows(row).Cells(PaymentTablePriceCol).Value         'Price Of Product
                quantity = DgvPurchaseSummary.Rows(row).Cells(PaymentTableQuantityCol).Value          'Quantity Of Product
                discountRate = DgvPurchaseSummary.Rows(row).Cells(PaymentTableDiscountCol).Value      'Discount On Product
                category = DgvPurchaseSummary.Rows(row).Cells(PaymentTableCategoryCol).Value          'Category Of Product
                taxRate = DgvPurchaseSummary.Rows(row).Cells(PaymentTableTaxRateCol).Value            'TaxRate On Product Category

                'Find Base Total
                Dim productObj As New Product(name, pricePerUnit, quantity)
                subtotal = productObj.CalculateBaseTotal()

                'Apply Discount on Products
                Dim percentageDiscountObj As New PercentageDiscount(discountRate)
                subtotal = percentageDiscountObj.ApplyDiscount(subtotal)

                'Apply Tax On Product Category
                Dim taxObj As New Tax(taxRate)
                subtotal = taxObj.ApplyTax(subtotal)

                'Update 'Sub Total (After Discount & Tax)' column
                DgvPurchaseSummary.Rows(row).Cells(PaymentTableSubTotalCol).Value = subtotal

                'Calculating TOTAL In Same Loop 
                TotalAfterDiscountAndTax += subtotal

                TotalAfterDiscountAndTax = Math.Round(TotalAfterDiscountAndTax, 2)
            Next


            'Update Total Amount After Applying Of Discount (On Each Products) And Tax (On Each Categories)
            LblTotalAfterTax2.Text = TotalAfterDiscountAndTax 'TotalAfterDiscount + TotalTax   'Total Before Applying of Tax + TotalTax

            'Here Update Total Same As Before Applying Of Flat Discount. Later May Change If Valid "COUPEN CODE" Provided.
            'i.e Now same as 'Total Amount After Applying of Tax'. 
            LblTotAfterFlatDiscount2.Text = LblTotalAfterTax2.Text

            'ORDER TOTAL =  Update Same As After Flat Discount Field.
            LblOrderTotal2.Text = LblTotAfterFlatDiscount2.Text

            'Uncheck if any radio button is checked bydefault
            For Each iControl As Control In GrbPaymentOptions.Controls
                If TypeOf iControl Is RadioButton Then
                    Dim rb As RadioButton = CType(iControl, RadioButton)
                    rb.Checked = False
                    rb.Refresh()
                End If
            Next

            'Enable FlatDiscount Related controls Bydefault
            TxtFlatDiscount.Text = ""
            TxtFlatDiscount.Enabled = True
            BtnApplyFlatDiscount.Enabled = True

        Catch ex As Exception
            MessageBox.Show("An Unexpected Error Occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub ValidatePaymentWindow()

        'Check if Valid Payment Option Selcted Or Not
        Dim PaymentOptionSelected = False
        For Each iControl As Control In GrbPaymentOptions.Controls
            If TypeOf iControl Is RadioButton Then
                Dim rb As RadioButton = CType(iControl, RadioButton)
                If rb.Checked = True Then
                    PaymentOptionSelected = True
                    Exit For
                End If
            End If
        Next

        If PaymentOptionSelected = False Then
            Throw (New PaymentOptionNotSelectedException("Select Valid Payment Option."))
        End If

    End Sub
    Private Sub ShowProgressBar()
        Try
            'Showing ProgressBar While Payment is Processing [Dummy ProgressBar shown]
            PbBar.Visible = True
            PbBar.Value = 0
            For increment = 4 To 1 Step -1
                PbBar.Value += (PbBar.Maximum / 4)
                PbBar.Refresh()
                Threading.Thread.Sleep(500)
            Next
            PbBar.Visible = False

        Catch ex As Exception
            'Handle any other unexpected exceptions
            MessageBox.Show("An Unexpected Error Occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub BtnProceedPay_Click(sender As System.Object, e As System.EventArgs) Handles BtnProceedPay.Click
        Try

            'Validate the Payement Window Inputs Before Proceeding to Payment
            ValidatePaymentWindow()

            'Showing ProgressBar While Payment is Processing
            ShowProgressBar()

            'Show Final Invoice Window
            FormInvoice.ShowDialog()

        Catch ex As PaymentOptionNotSelectedException
            MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            'Handle any other unexpected exceptions
            MessageBox.Show("An Unexpected Error Occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub ValidateCoupenCode(CoupenCode As String)

        If UCase(Trim(CoupenCode)) <> CoupenCodeExample Then
            Throw (New InvalidCoupenCodeException("Oops! Invalid Coupen Code!"))
        End If

    End Sub
    Private Sub BtnApplyFlatDiscount_Click(sender As System.Object, e As System.EventArgs) Handles BtnApplyFlatDiscount.Click
        Try
            Dim Total As Decimal
            Dim TotalTemp As Decimal
            Dim CoupenCode As String
            CoupenCode = TxtFlatDiscount.Text

            'Validate Entered Coupen Code
            ValidateCoupenCode(CoupenCode)

            'If Valid Coupen Code, Then Update Total Amount After Applying Subtracting Flat Discount Amount
            Total = LblTotAfterFlatDiscount2.Text
            TotalTemp = Total

            Dim flatAmountDiscountObj As New FlatAmountDiscount(FlatDiscountAmountExample)
            Total = flatAmountDiscountObj.ApplyDiscount(Total)

            If TotalTemp <> Total Then
                'i.e If flat Amount Discount Applied
                Total = Math.Round(Total, 2)
            Else
                Throw (New NotEligibleForFlatDiscountException("'Rs.500 Flat Discount' Applicable For Purchases Above Rs.500."))
            End If

            LblTotAfterFlatDiscount2.Text = Total

            'Update GRAND ORDER TOTAL
            LblOrderTotal2.Text = Total

            'Disable Coupen Code Related Controls
            TxtFlatDiscount.Enabled = False
            BtnApplyFlatDiscount.Enabled = False

            MessageBox.Show("You Have Earned 'Rs.500 Flat Discount' On Coupen Code.", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information)

            EligibleForFlatDiscount = True

        Catch ex As InvalidCoupenCodeException
            MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As NotEligibleForFlatDiscountException
            MessageBox.Show(ex.Message, "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            MessageBox.Show("An Unexpected Error Occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
End Class

Public Class PaymentOptionNotSelectedException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
Public Class InvalidCoupenCodeException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
Public Class NotEligibleForFlatDiscountException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class