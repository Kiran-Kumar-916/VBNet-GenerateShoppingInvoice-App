Imports System.IO

Public Class ProductsManager

    Private _databaseHandler As IDatabaseHandler

    Public Sub New(databaseHandler As IDatabaseHandler)
        Me._databaseHandler = databaseHandler
    End Sub

    Public Function AddProduct(name As String, description As String, category As String, price As String, quantity As String, Discount As String) As Boolean
        Dim AllProductsDataList As DataTable
        Dim row() As String
        Try

            AllProductsDataList = GetAllProductsDetails()

            For Each dtrow As DataRow In AllProductsDataList.Rows()
                If UCase(Trim(dtrow(0))) = UCase(Trim(name)) Then
                    Throw (New DuplicateProductException("Duplicate Entry! Product With Same Name Already Present In Database"))
                End If
            Next

            row = {name, description, category, price, quantity, Discount}

            If _databaseHandler.InsertData(row) = True Then
                Return True
            End If

        Catch ex As DuplicateProductException
            Throw
        Catch ex As ApplicationException
            Throw
        Catch ex As Exception
            ' Handle any other types of exceptions
            Throw New ApplicationException("An Unexpected Error Occurred While Add Product Details.", ex)
        Finally
            AllProductsDataList = Nothing
            Erase row
        End Try
    End Function
    Public Function UpdateProduct(name As String, description As String, category As String, price As String, quantity As String, Discount As String) As Boolean
        Dim row() As String
        Try
            row = {name, description, category, price, quantity, Discount}

            If _databaseHandler.UpdateData(name, row) = True Then
                Return True
            End If

        Catch ex As ApplicationException
            Throw
        Catch ex As Exception
            Throw New ApplicationException("An Unexpected Error Occurred While Update Product Details.", ex)
        Finally
            Erase row
        End Try
    End Function
    Public Function DeleteProduct(name As String) As Boolean
        Try

            If _databaseHandler.DeleteData(name) = True Then
                Return True
            End If

        Catch ex As ApplicationException
            Throw
        Catch ex As Exception
            Throw New ApplicationException("An Unexpected Error Occurred While Delete Product Details.", ex)
        End Try
    End Function
    Public Function GetAllProductsDetails() As DataTable
        Dim AllProductsDataList As New DataTable
        Try
            AllProductsDataList = _databaseHandler.GetAllRows()

            Return AllProductsDataList

        Catch ex As ApplicationException
            Throw
        Catch ex As Exception
            Throw New ApplicationException("An Unexpected Error Occurred While Get All Products Details.", ex)
        Finally
            AllProductsDataList = Nothing
        End Try
    End Function
    Public Function GetProductsNames() As String()
        Dim lstProductsNames As String()
        Try

            lstProductsNames = _databaseHandler.GetListOfUniqueIdValues()

            Return lstProductsNames

        Catch ex As ApplicationException
            Throw
        Catch ex As Exception
            Throw New ApplicationException("An Unexpected Error Occurred While Get All Products Names.", ex)
        Finally
            Erase lstProductsNames
        End Try
    End Function
    Public Function GetSelectedProductDetails(ByVal name As String) As String()
        Dim lstProductsDetails As String()
        Try
            lstProductsDetails = _databaseHandler.GetSelectedIdDetails(name)

            Return lstProductsDetails

        Catch ex As ApplicationException
            Throw
        Catch ex As Exception
            Throw New ApplicationException("An Unexpected Error Occurred While Get Selected Product Details.", ex)
        Finally
            Erase lstProductsDetails
        End Try
    End Function
End Class
Public Class CategoriesManager

    Private _databaseHandler As IDatabaseHandler

    Public Sub New(databaseHandler As IDatabaseHandler)
        Me._databaseHandler = databaseHandler
    End Sub
    Public Function AddCategories(name As String, description As String, taxRate As String) As Boolean
        Dim AllCategoriesDataList As DataTable
        Dim row() As String
        Try
            AllCategoriesDataList = GetAllCategoriesDetails()

            For Each dtrow As DataRow In AllCategoriesDataList.Rows()
                If UCase(Trim(dtrow(0))) = UCase(Trim(name)) Then
                    Throw (New DuplicateCategoryException("Duplicate Entry! Category With Same Name Already Present In Database"))
                End If
            Next

            row = {name, description, taxRate}
            If _databaseHandler.InsertData(row) = True Then
                Return True
            End If

        Catch ex As DuplicateCategoryException
            Throw
        Catch ex As ApplicationException
            Throw
        Catch ex As Exception
            Throw New ApplicationException("An Unexpected Error Occurred WHile Add Categories Details.", ex)
        Finally
            Erase row
            AllCategoriesDataList = Nothing
        End Try
    End Function
    Public Function UpdateCategories(name As String, description As String, taxRate As String) As Boolean
        Dim row() As String
        Try

            row = {name, description, taxRate}
            If _databaseHandler.UpdateData(name, row) = True Then
                Return True
            End If

        Catch ex As Exception
            Throw New ApplicationException("An Unexpected Error Occurred While Update Categories Details.", ex)
        Finally
            Erase row
        End Try
    End Function
    Public Function DeleteCategories(name As String) As Boolean
        Try

            If _databaseHandler.DeleteData(name) = True Then
                Return True
            End If

        Catch ex As ApplicationException
            Throw
        Catch ex As Exception
            Throw New ApplicationException("An Unexpected Error Occurred While Delete Categories Details.", ex)
        End Try
    End Function
    Public Function GetAllCategoriesDetails() As DataTable
        Dim AllCategoriesDataList As DataTable
        Try
            AllCategoriesDataList = _databaseHandler.GetAllRows()

            Return AllCategoriesDataList

        Catch ex As ApplicationException
            Throw
        Catch ex As Exception
            Throw New ApplicationException("An Unexpected Error Occurred While Get All Categories Details.", ex)
        Finally
            AllCategoriesDataList = Nothing
        End Try
    End Function
    Public Function GetCategoriesNames() As String()
        Dim lstCategoriesNames As String()
        Try

            lstCategoriesNames = _databaseHandler.GetListOfUniqueIdValues()

            Return lstCategoriesNames

        Catch ex As ApplicationException
            Throw
        Catch ex As Exception
            Throw New ApplicationException("An Unexpected Error Occurred While Get All Categories Names.", ex)
        Finally
            Erase lstCategoriesNames
        End Try
    End Function
    Public Function GetSelectedCategoriesDetails(ByVal name As String) As String()
        Dim lstCategoriesDetails As String()
        Try
            lstCategoriesDetails = _databaseHandler.GetSelectedIdDetails(name)

            Return lstCategoriesDetails

        Catch ex As ApplicationException
            Throw
        Catch ex As Exception
            Throw New ApplicationException("An Unexpected Error Occurred While Get Selected Categories Details.", ex)
        Finally
            Erase lstCategoriesDetails
        End Try
    End Function
End Class
Public Class CustomersManager

    Private _databaseHandler As IDatabaseHandler

    Public Sub New(databaseHandler As IDatabaseHandler)
        Me._databaseHandler = databaseHandler
    End Sub

    Public Function AddCustomer(name As String, email As String, address As String, contactNumber As String) As Boolean
        Dim AllCustomersDataList As DataTable
        Dim row() As String
        Try

            AllCustomersDataList = GetAllCustomersData()

            For Each dtrow As DataRow In AllCustomersDataList.Rows()
                If UCase(Trim(dtrow(0))) = UCase(Trim(name)) Then
                    Throw (New DuplicateCustomerException("Duplicate Entry! Customer Data With Same Name Already Present In Database"))
                End If
            Next

            row = {name, email, address, contactNumber}

            If _databaseHandler.InsertData(row) = True Then
                Return True
            End If

        Catch ex As DuplicateCustomerException
            Throw
        Catch ex As ApplicationException
            Throw
        Catch ex As Exception
            Throw New ApplicationException("An Unexpected Error Occurred While Add Customer Details.", ex)
        Finally
            AllCustomersDataList = Nothing
            Erase row
        End Try
    End Function
    Public Function UpdateCustomer(name As String, email As String, address As String, contactNumber As String) As Boolean
        Dim row() As String
        Try

            row = {name, email, address, contactNumber}
            If _databaseHandler.UpdateData(name, row) = True Then
                Return True
            End If

        Catch ex As ApplicationException
            Throw
        Catch ex As Exception
            Throw New ApplicationException("An Unexpected Error Occurred While Update Customer Details.", ex)
        Finally
            Erase row
        End Try
    End Function
    Public Function DeleteCustomer(name As String) As Boolean
        Try

            If _databaseHandler.DeleteData(name) = True Then
                Return True
            End If

        Catch ex As Exception
            Throw New ApplicationException("An Unexpected Error Occurred While Delete Customer Details.", ex)
        End Try
    End Function
    Public Function GetAllCustomersData() As DataTable
        Dim AllCustomersDataList As DataTable

        Try
            AllCustomersDataList = _databaseHandler.GetAllRows()
            Return AllCustomersDataList

        Catch ex As ApplicationException
            Throw
        Catch ex As Exception
            Throw New ApplicationException("An Unexpected Error Occurred While Get All Customers Details.", ex)
        Finally
            AllCustomersDataList = Nothing
        End Try
    End Function
    Public Function GetCustomersNames() As String()
        Dim lstCustomersNames As String()
        Try

            lstCustomersNames = _databaseHandler.GetListOfUniqueIdValues()


            Return lstCustomersNames
        Catch ex As Exception
            Throw New ApplicationException("An Unexpected Error Occurred While Get Customers Names.", ex)
        Finally
            Erase lstCustomersNames
        End Try
    End Function
    Public Function GetSelectedCustomerDetails(ByVal name As String) As String()
        Dim lstCustomersDetails As String()
        Try
            lstCustomersDetails = _databaseHandler.GetSelectedIdDetails(name)

            Return lstCustomersDetails

        Catch ex As ApplicationException
            Throw
        Catch ex As Exception
            Throw New ApplicationException("An Unexpected Error Occurred While Get Selected Customer Details.", ex)
        Finally
            Erase lstCustomersDetails
        End Try
    End Function
End Class

Public Class DuplicateProductException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
Public Class DuplicateCategoryException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
Public Class DuplicateCustomerException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class


