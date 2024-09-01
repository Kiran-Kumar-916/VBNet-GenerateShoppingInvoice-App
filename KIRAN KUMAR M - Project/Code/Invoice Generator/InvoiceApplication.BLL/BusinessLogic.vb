Imports System.IO

Public Class Product
    Private _name As String
    Private _pricePerUnit As Decimal
    Private _quantity As Integer

    Public ReadOnly Property Name As String
        Get
            Return _name
        End Get
    End Property
    Public ReadOnly Property PricePerUnit As Decimal
        Get
            Return _pricePerUnit
        End Get
    End Property
    Public ReadOnly Property Quantity As Integer
        Get
            Return _quantity
        End Get
    End Property

    Public Sub New(name As String, pricePerUnit As Decimal, quantity As Integer)
        Me._name = name
        Me._pricePerUnit = pricePerUnit
        Me._quantity = quantity
    End Sub
    Public Function CalculateBaseTotal() As Decimal
        Return _quantity * _pricePerUnit
    End Function
End Class

Public MustInherit Class Discount
    Public MustOverride Function ApplyDiscount(amount As Decimal) As Decimal
End Class
Public Class PercentageDiscount
    Inherits Discount
    Private _discountRate As Decimal
    Public ReadOnly Property DiscountRate As Decimal
        Get
            Return _discountRate
        End Get
    End Property

    Public Sub New(discountRate As Decimal)
        Me._discountRate = discountRate
    End Sub
    Public Overrides Function ApplyDiscount(amount As Decimal) As Decimal
        Return amount - (amount * (_discountRate / 100))
    End Function
End Class
Public Class FlatAmountDiscount
    Inherits Discount
    Private _flatDiscountAmount As Decimal
    Public Sub New(flatDiscountAmount As Decimal)
        Me._flatDiscountAmount = flatDiscountAmount
    End Sub
    Public ReadOnly Property FlatDiscountAmount As Decimal
        Get
            Return _flatDiscountAmount
        End Get
    End Property
    Public Overrides Function ApplyDiscount(amount As Decimal) As Decimal
        If amount > _flatDiscountAmount Then
            'Flat Discout Applies Only When "Order Total" Is Greater Than Flat Discount Amount.
            Return amount - _flatDiscountAmount
        Else
            Return amount
        End If
    End Function
End Class

Public Class Tax
    Private _taxRate As Decimal
    Public ReadOnly Property TaxRate As Decimal
        Get
            Return _taxRate
        End Get
    End Property
    Public Sub New(taxRate As Decimal)
        Me._taxRate = taxRate
    End Sub
    Public Function ApplyTax(amount As Decimal) As Decimal
        Return amount + (amount * (_taxRate / 100))
    End Function
End Class

Public Class InvoiceGenerator
    Private _eligibleForFlatDiscount As Boolean
    Public Sub New(eligibleForFlatDiscount As Boolean)
        Me._eligibleForFlatDiscount = eligibleForFlatDiscount
    End Sub

    Public Function GenerateInvoiceForOrderTotal(product As List(Of Product), percentageDiscount As List(Of PercentageDiscount), tax As List(Of Tax), flatAmountDiscount As FlatAmountDiscount) As String
        Dim iproduct As Product
        Dim ipercentageDiscount As PercentageDiscount
        Dim itax As Tax

        Try
            Dim Total As Decimal
            Dim invoiceSummary As String = ""
            Dim OrderTotal As Decimal

            'Loop For All Products and Generate Invoice Summary Having --> Customer Details, Products Details, Discount Detials, Tax Details. 
            For i = 0 To product.Count - 1
                Total = 0

                iproduct = product(i)
                ipercentageDiscount = percentageDiscount(i)
                itax = tax(i)

                Total = iproduct.CalculateBaseTotal()
                Total = ipercentageDiscount.ApplyDiscount(Total)
                Total = itax.ApplyTax(Total)

                Total = Math.Round(Total, 2)

                invoiceSummary &= "Total Amount For Product: """ & iproduct.Name & """ is Rs." & Total & vbNewLine & "(With " & ipercentageDiscount.DiscountRate & "% discount and " & itax.TaxRate & "% tax)" & vbNewLine & vbNewLine

                OrderTotal += Total

                OrderTotal = Math.Round(OrderTotal, 2)
            Next

            invoiceSummary &= "Order Total Amount is Rs." & OrderTotal & vbNewLine & vbNewLine


            If _eligibleForFlatDiscount = True Then
                Total = flatAmountDiscount.ApplyDiscount(OrderTotal)
                invoiceSummary &= vbNewLine & "Order Total Amount After Applying Flat Discount is Rs." & Total & vbNewLine & "(Flat Discount of Rs." & flatAmountDiscount.FlatDiscountAmount & ")"
            End If

            Return invoiceSummary
        Catch ex As Exception
            Throw (New InvoiceGenerationException("An Unexpected Error Occurred While Generate Invoice: " & ex.Message))
        Finally
            iproduct = Nothing
            ipercentageDiscount = Nothing
            itax = Nothing
        End Try
    End Function
End Class

Public Class InvoiceGenerationException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.new(message)
    End Sub
End Class