Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Public Class DatabaseHandler
    Public Function InsertDataIntoCsv(filePath As String, row As String()) As Boolean
        Try
            'Quote values that contain commas
            For i As Integer = 0 To row.Length - 1
                If row(i).Contains(",") Then
                    row(i) = """" & row(i) & """"
                End If
            Next

            Dim newRow As String = String.Join(",", row)

            Using writer As StreamWriter = File.AppendText(filePath)
                writer.WriteLine(newRow)
            End Using

            Return True
        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred While Attempting To Insert Data Into CSV File: " & ex.Message, MessageBoxButtons.OK, "Error")
        End Try
    End Function
    Public Function UpdateDataInCsv(filePath As String, rowId As String, updatedRow As String()) As Boolean
        Dim lines As List(Of String)
        Dim row As String()
        Try

            For i As Integer = 0 To updatedRow.Length - 1
                If updatedRow(i).Contains(",") Then
                    updatedRow(i) = """" & updatedRow(i) & """"
                End If
            Next

            lines = File.ReadAllLines(filePath).ToList()
            Dim updatedLine As String = String.Join(",", updatedRow)


            For i As Integer = 0 To lines.Count - 1
                If i <> 0 Then
                    Using parser As New TextFieldParser(New StringReader(lines(i))) 'To Handle Comma in Values Case
                        parser.TextFieldType = FieldType.Delimited
                        parser.SetDelimiters(",")
                        parser.HasFieldsEnclosedInQuotes = True ' This handles values with commas
                        row = parser.ReadFields()

                        'Assuming the first column is the Unique ID
                        'Match and Update Details
                        If row(0) = rowId Then
                            lines(i) = updatedLine
                            Exit For
                        End If
                    End Using
                End If
            Next

            File.WriteAllLines(filePath, lines)
            Return True

        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred While Attempting To Update Data In CSV File: " & ex.Message, MessageBoxButtons.OK, "Error")
        Finally
            lines = Nothing
            Erase row
        End Try
    End Function
    Public Function DeleteDataFromCsv(filePath As String, rowId As String) As Boolean
        Dim lines As List(Of String)
        Try
            lines = File.ReadAllLines(filePath).ToList()

            lines = lines.Where(Function(line) line.Split(","c)(0) <> rowId).ToList()

            File.WriteAllLines(filePath, lines)
            Return True
        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred While Attempting To Delete Data From CSV File: : " & ex.Message, MessageBoxButtons.OK, "Error")
        Finally
            lines = Nothing
        End Try
    End Function
    Public Function ReadDataFromCsv(filePath As String) As DataTable
        Dim dataTab As New DataTable()
        Dim row As String()

        Try
            Dim i As Byte

            If File.Exists(filePath) Then
                Dim lines() As String = File.ReadAllLines(filePath)
                Dim newDataRow As DataRow

                i = 0
                For Each line As String In lines
                    Using parser As New TextFieldParser(New StringReader(line)) 'To Handle Comma in Values Case
                        parser.TextFieldType = FieldType.Delimited
                        parser.SetDelimiters(",")
                        parser.HasFieldsEnclosedInQuotes = True ' This handles values with commas
                        row = parser.ReadFields()

                        If i = 0 Then 'To Update Column Headers To DataTable
                            For j As Integer = LBound(row) To UBound(row)
                                dataTab.Columns.Add(row(j))
                            Next
                            i = 1
                        Else
                            newDataRow = dataTab.NewRow()
                            For j As Integer = LBound(row) To UBound(row)
                                newDataRow(j) = row(j)
                            Next
                            dataTab.Rows.Add(newDataRow)
                        End If
                    End Using
                Next
            End If

            Return dataTab
        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred While Attempting To Read Data From CSV File: " & ex.Message, MessageBoxButtons.OK, "Error")
        Finally
            dataTab = Nothing
            Erase row
        End Try
    End Function
    Public Function GetAllRowsFromTable(FilePath As String) As DataTable
        Dim FillDataTable As New DataTable
        Try

            FillDataTable = ReadDataFromCsv(FilePath)
            Return FillDataTable

        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        Finally
            FillDataTable = Nothing
        End Try
    End Function
    Public Function GetListOfUniqueIdValues(FilePath As String) As String()
        Dim AllRowsDataList As DataTable
        Dim ListOfUniqueIdValues As String()
        Try

            AllRowsDataList = GetAllRowsFromTable(FilePath)

            Dim i As Integer = 0
            For Each row As DataRow In AllRowsDataList.Rows()
                ReDim Preserve ListOfUniqueIdValues(i)
                ListOfUniqueIdValues(i) = row(0) 'Assuming UniqueID in first column
                i = i + 1
            Next

            Return ListOfUniqueIdValues
        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        Finally
            AllRowsDataList = Nothing
            Erase ListOfUniqueIdValues
        End Try
    End Function
    Public Function GetSelectedProductDetails(FilePath As String, ByVal id As String) As String()
        Dim AllRowsDataList As DataTable
        Dim lstSelectedRowDetails As String()
        Try

            AllRowsDataList = GetAllRowsFromTable(FilePath)

            Dim colCount As Integer
            colCount = AllRowsDataList.Columns.Count


            Dim j As Integer
            For Each row As DataRow In AllRowsDataList.Rows()
                If row(0) = id Then
                    For j = 0 To colCount - 1
                        ReDim Preserve lstSelectedRowDetails(j)
                        lstSelectedRowDetails(j) = row(j)
                    Next
                    Exit For
                End If
            Next

            Return lstSelectedRowDetails
        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        Finally
            AllRowsDataList = Nothing
            Erase lstSelectedRowDetails
        End Try
    End Function
End Class

Public Class ProductsManager
    Inherits DatabaseHandler

    Private FilePath As String = "Products.csv"
    Public Sub AddData(name As String, description As String, category As String, price As String, quantity As String, Discount As String)
        'Try

        Dim AllProductsDataList As DataTable
        AllProductsDataList = GetAllProductsDetails()

        For Each dtrow As DataRow In AllProductsDataList.Rows()
            If UCase(Trim(dtrow(0))) = UCase(Trim(name)) Then
                Throw (New DuplicateProductException("Duplicate Entry! Product With Same Name Already Present In Database"))
            End If
        Next

        Dim row() As String = {name, description, category, price, quantity, Discount}

        If MyBase.InsertDataIntoCsv(FilePath, row) = True Then
            Call MsgBox("New Product Added Successfully", MessageBoxButtons.OK)
        End If


        AllProductsDataList = Nothing
        Erase row
        'Catch ex As Exception
        '    Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        'End Try
    End Sub
    Public Sub UpdateData(name As String, description As String, category As String, price As String, quantity As String, Discount As String)
        Dim row() As String
        Try
            row = {name, description, category, price, quantity, Discount}

            If MyBase.UpdateDataInCsv(FilePath, name, row) = True Then
                Call MsgBox("Product Details Updated Successfully", MessageBoxButtons.OK)
            End If

        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        Finally
            Erase row
        End Try
    End Sub
    Public Sub DeleteData(name As String)
        Try

            If MyBase.DeleteDataFromCsv(FilePath, name) = True Then
                Call MsgBox("Product Deleted Successfully", MessageBoxButtons.OK)
            End If

        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        End Try
    End Sub
    Public Function GetAllProductsDetails() As DataTable
        Dim AllProductsDataList As New DataTable
        Try
            AllProductsDataList = MyBase.GetAllRowsFromTable(FilePath)
            'AllProductsDataList = MyBase.ReadDataFromCsv(FilePath)

            Return AllProductsDataList

        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        Finally
            AllProductsDataList = Nothing
        End Try
    End Function
    Public Function GetProductsNames() As String()
        'Dim AllProductsDataList As DataTable
        Dim lstProductsNames As String()
        Try

            lstProductsNames = MyBase.GetListOfUniqueIdValues(FilePath)
            'AllProductsDataList = GetAllProductsDetails()

            'Dim i As Integer = 0
            'For Each row As DataRow In AllProductsDataList.Rows()
            '    ReDim Preserve lstProductsNames(i)
            '    lstProductsNames(i) = row(0)
            '    i = i + 1
            'Next


            Return lstProductsNames
        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        Finally
            'AllProductsDataList = Nothing
            Erase lstProductsNames
        End Try
    End Function
    Public Function GetSelectedProductDetails(ByVal name As String) As String()
        'Dim AllProductsDataList As DataTable
        Dim lstProductsDetails As String()
        Try
            lstProductsDetails = MyBase.GetSelectedProductDetails(FilePath, name)
            'AllProductsDataList = GetAllProductsDetails()

            'Dim colCount As Integer
            'colCount = AllProductsDataList.Columns.Count


            'Dim j As Integer
            'For Each row As DataRow In AllProductsDataList.Rows()
            '    If row(0) = name Then
            '        For j = 0 To colCount - 1
            '            ReDim Preserve lstProductsDetails(j)
            '            lstProductsDetails(j) = row(j)
            '        Next
            '        Exit For
            '    End If
            'Next

            Return lstProductsDetails
        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        Finally
            'AllProductsDataList = Nothing
            Erase lstProductsDetails
        End Try
    End Function
End Class

Public Class CategoriesManager
    Inherits DatabaseHandler

    Private FilePath As String = "Categories.csv"
    Public Sub AddData(name As String, description As String, taxRate As String)
        'Try
        Dim AllCategoriesDataList As DataTable
        AllCategoriesDataList = GetAllCategoriesDetails()

        For Each dtrow As DataRow In AllCategoriesDataList.Rows()
            If UCase(Trim(dtrow(0))) = UCase(Trim(name)) Then
                Throw (New DuplicateCategoryException("Duplicate Entry! Category With Same Name Already Present In Database"))
            End If
        Next

        Dim row() As String = {name, description, taxRate}
        If MyBase.InsertDataIntoCsv(FilePath, row) = True Then
            Call MsgBox("New Category Added Successfully", MessageBoxButtons.OK)
        End If

        Erase row
        AllCategoriesDataList = Nothing
        'Catch ex As Exception
        '    Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        'End Try
    End Sub
    Public Sub UpdateData(name As String, description As String, taxRate As String)
        Dim row() As String
        Try

            row = {name, description, taxRate}
            If MyBase.UpdateDataInCsv(FilePath, name, row) = True Then
                Call MsgBox("Category Details Updated Successfully", MessageBoxButtons.OK)
            End If

        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        Finally
            Erase row
        End Try
    End Sub
    Public Sub DeleteData(name As String)
        Try

            If MyBase.DeleteDataFromCsv(FilePath, name) = True Then
                Call MsgBox("Category Deleted Successfully", MessageBoxButtons.OK)
            End If

        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        End Try
    End Sub
    Public Function GetAllCategoriesDetails() As DataTable
        Dim AllCategoriesDataList As DataTable
        Try
            AllCategoriesDataList = MyBase.GetAllRowsFromTable(FilePath)
            'AllCategoriesDataList = MyBase.ReadDataFromCsv(FilePath)
            Return AllCategoriesDataList

        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        Finally
            AllCategoriesDataList = Nothing
        End Try
    End Function
    Public Function GetCategoriesNames() As String()
        'Dim AllCategoriesDataList As DataTable
        Dim lstCategoriesNames As String()
        Try

            lstCategoriesNames = MyBase.GetListOfUniqueIdValues(FilePath)
            'AllCategoriesDataList = GetAllCategoriesDetails()

            'Dim i As Integer = 0
            'For Each row As DataRow In AllCategoriesDataList.Rows()
            '    ReDim Preserve lstCustomersNames(i)
            '    lstCustomersNames(i) = row(0)
            '    i = i + 1
            'Next
            'AllCategoriesDataList = GetAllCategoriesDetails()

            'Dim i As Integer = 0
            'For Each row As DataRow In AllCategoriesDataList.Rows()
            '    ReDim Preserve lstCategoriesNames(i)
            '    lstCategoriesNames(i) = row(0)
            '    i = i + 1
            'Next

            Return lstCategoriesNames
        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        Finally
            'AllCategoriesDataList = Nothing
            Erase lstCategoriesNames
        End Try
    End Function
    Public Function GetSelectedCategoriesDetails(ByVal name As String) As String()
        'Dim AllCategoriesDataList As DataTable
        Dim lstCategoriesDetails As String()
        Try
            lstCategoriesDetails = MyBase.GetSelectedProductDetails(FilePath, name)
            'AllCategoriesDataList = GetAllCategoriesDetails()

            'Dim colCount As Integer
            'colCount = AllCategoriesDataList.Columns.Count


            'Dim j As Integer
            'For Each row As DataRow In AllCategoriesDataList.Rows()
            '    If row(0) = name Then
            '        For j = 0 To colCount - 1
            '            ReDim Preserve lstCategoriesDetails(j)
            '            lstCategoriesDetails(j) = row(j)
            '        Next
            '        Exit For
            '    End If
            'Next

            Return lstCategoriesDetails
        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        Finally
            'AllCategoriesDataList = Nothing
            Erase lstCategoriesDetails
        End Try
    End Function
End Class

Public Class CustomersManager
    Inherits DatabaseHandler

    Private FilePath As String = "Customers.csv"
    Public Sub AddData(name As String, email As String, address As String, contactNumber As String)
        'Try
        Dim AllCustomersDataList As DataTable
        AllCustomersDataList = GetAllCustomersData()

        For Each dtrow As DataRow In AllCustomersDataList.Rows()
            If UCase(Trim(dtrow(0))) = UCase(Trim(name)) Then
                Throw (New DuplicateCustomerException("Duplicate Entry! Customer Data With Same Name Already Present In Database"))
            End If
        Next

        Dim row() As String = {name, email, address, contactNumber}
        
        If MyBase.InsertDataIntoCsv(FilePath, row) = True Then
            Call MsgBox("New Customer Detail Added Successfully", MessageBoxButtons.OK)
        End If

        AllCustomersDataList = Nothing
        Erase row
        'Catch ex As Exception
        '    Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        'End Try
    End Sub
    Public Sub UpdateData(name As String, email As String, address As String, contactNumber As String)
        Dim row() As String
        Try

            Row = {name, email, address, contactNumber}
            If MyBase.UpdateDataInCsv(FilePath, name, row) = True Then
                Call MsgBox("Customer Details Updated Successfully", MessageBoxButtons.OK)
            End If

        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        Finally
            Erase row
        End Try
    End Sub
    Public Sub DeleteData(name As String)
        Try

            If MyBase.DeleteDataFromCsv(FilePath, name) = True Then
                Call MsgBox("Customer Details Deleted Successfully", MessageBoxButtons.OK)
            End If

        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        End Try
    End Sub
    Public Function GetAllCustomersData() As DataTable
        Dim AllCustomersDataList As DataTable

        Try
            AllCustomersDataList = MyBase.GetAllRowsFromTable(FilePath)
            'AllCustomersDataList = MyBase.ReadDataFromCsv(FilePath)
            Return AllCustomersDataList

        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        Finally
            AllCustomersDataList = Nothing
        End Try
    End Function
    Public Function GetCustomersNames() As String()
        'Dim AllCustomersDataList As DataTable
        Dim lstCustomersNames As String()
        Try

            lstCustomersNames = MyBase.GetListOfUniqueIdValues(FilePath)
            'AllCustomersDataList = GetAllCustomersData()

            'Dim i As Integer = 0
            'For Each row As DataRow In AllCustomersDataList.Rows()
            '    ReDim Preserve lstCustomersNames(i)
            '    lstCustomersNames(i) = row(0)
            '    i = i + 1
            'Next

            Return lstCustomersNames
        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        Finally
            'AllCustomersDataList = Nothing
            Erase lstCustomersNames
        End Try
    End Function
    Public Function GetSelectedCustomerDetails(ByVal name As String) As String()
        'Dim AllCustomersDataList As DataTable
        Dim lstCustomersDetails As String()
        Try
            lstCustomersDetails = MyBase.GetSelectedProductDetails(FilePath, name)
            'AllCustomersDataList = GetAllCustomersData()

            'Dim colCount As Integer
            'colCount = AllCustomersDataList.Columns.Count


            'Dim j As Integer
            'For Each row As DataRow In AllCustomersDataList.Rows()
            '    If row(0) = name Then
            '        For j = 0 To colCount - 1
            '            ReDim Preserve lstCustomersDetails(j)
            '            lstCustomersDetails(j) = row(j)
            '        Next
            '        Exit For
            '    End If
            'Next

            Return lstCustomersDetails
        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        Finally
            'AllCustomersDataList = Nothing
            Erase lstCustomersDetails
        End Try
    End Function
End Class

Public Class Product
    Private _name As String
    Private _pricePerUnit As Decimal
    Private _quantity As Integer

    Public ReadOnly Property Name As String
        Get
            Return _name
        End Get
    End Property
    Public ReadOnly Property PricePerUnit As String
        Get
            Return _pricePerUnit
        End Get
    End Property
    Public ReadOnly Property Quantity As String
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
    Public MustOverride Function ApplyDiscount(amount As Decimal)
End Class
Public Class PercentageDiscount
    Inherits Discount
    Private _discountRate As Decimal
    Public ReadOnly Property DiscountRate As String
        Get
            Return _discountRate
        End Get
    End Property

    Public Sub New(discountRate As Decimal)
        Me._discountRate = discountRate
    End Sub
    Public Overrides Function ApplyDiscount(amount As Decimal)
        Return amount - (amount * (_discountRate / 100))
    End Function
End Class
Public Class FlatAmountDiscount
    Inherits Discount
    Private _flatDiscountAmount As Decimal
    Public Sub New(flatDiscountAmount As Decimal)
        Me._flatDiscountAmount = flatDiscountAmount
    End Sub
    Public ReadOnly Property FlatDiscountAmount As String
        Get
            Return _flatDiscountAmount
        End Get
    End Property
    Public Overrides Function ApplyDiscount(amount As Decimal)
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
    Public ReadOnly Property TaxRate As String
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

Public Class OrderTotalInvoice
    Const FlatDiscountAmountExample As Decimal = 500 'Rs.500 FLAT Discount
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


            If FormPayment.EligibleForFlatDiscount = True Then
                flatAmountDiscount = New FlatAmountDiscount(FlatDiscountAmountExample) 'FLAT 500
                Total = flatAmountDiscount.ApplyDiscount(OrderTotal)

                invoiceSummary &= vbNewLine & "Order Total Amount After Applying Flat Discount is Rs." & Total & vbNewLine & "(Flat Discount of Rs." & flatAmountDiscount.FlatDiscountAmount & ")"
            End If

            Return invoiceSummary
        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        Finally
            iproduct = Nothing
            ipercentageDiscount = Nothing
            itax = Nothing
        End Try
    End Function
End Class