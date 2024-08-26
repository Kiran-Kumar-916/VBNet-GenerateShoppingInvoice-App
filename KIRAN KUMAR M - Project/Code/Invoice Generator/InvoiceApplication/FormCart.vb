Imports System.Exception
'Imports System.Data.SqlClient

Public Class FormCart
    Const CartTableQuantityCol As String = "Quantity"
    Const CartTableHiddenCol As String = "RowNumInOtherTable"

    Private Sub ValidateBeforeLoadingCartWindow(lstCustomerNames As String())
        If lstCustomerNames Is Nothing Then
            Throw (New NoCustomersAddedException("Add Atleast One Customer Detail Before Proceeding For Shopping"))
        End If
    End Sub

    Private Sub FormCart_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            CmbCustomerInCart.Items.Clear()

            Dim lstCustomerNames As String()
            Dim CustomerObj As New CustomersManager()
            lstCustomerNames = CustomerObj.GetCustomersNames()

            'Validate
            ValidateBeforeLoadingCartWindow(lstCustomerNames)

            'If validation Success
            For Each item As String In lstCustomerNames
                CmbCustomerInCart.Items.Add(item)
            Next

            'Load All Products Data to Stocks datagridview
            'Create Empty Cart datagridview
            Dim dataTab As New DataTable
            Dim ProductObj As New ProductsManager
            dataTab = ProductObj.GetAllProductsDetails()

            DgvStocks.Columns.Clear()
            DgvCart.Columns.Clear()
            DgvStocks.AutoGenerateColumns = True
            DgvStocks.DataSource = dataTab
            DgvStocks.AutoGenerateColumns = False
            DgvStocks.AllowUserToAddRows = False
            DgvStocks.ReadOnly = True

            DgvStocks.RowHeadersVisible = False

            Dim DataGridViewCol As DataGridViewTextBoxColumn

            For Each DgvProductsCol As DataGridViewColumn In DgvStocks.Columns
                DataGridViewCol = New DataGridViewTextBoxColumn
                DataGridViewCol.Name = DgvProductsCol.Name
                DataGridViewCol.HeaderText = DgvProductsCol.HeaderText
                DgvProductsCol.SortMode = DataGridViewColumnSortMode.NotSortable
                DataGridViewCol.SortMode = DataGridViewColumnSortMode.NotSortable
                DgvCart.Columns.Add(DataGridViewCol)
            Next
            DgvCart.ReadOnly = True
            DgvCart.AllowUserToAddRows = False
            DgvCart.RowHeadersVisible = False

            DataGridViewCol = New DataGridViewTextBoxColumn
            DataGridViewCol.Name = CartTableHiddenCol
            DataGridViewCol.HeaderText = CartTableHiddenCol
            DataGridViewCol.Visible = False
            DgvStocks.Columns.Add(DataGridViewCol)

            DataGridViewCol = New DataGridViewTextBoxColumn
            DataGridViewCol.Name = CartTableHiddenCol
            DataGridViewCol.HeaderText = CartTableHiddenCol
            DataGridViewCol.Visible = False
            DgvCart.Columns.Add(DataGridViewCol)

        Catch ex As NoCustomersAddedException
            Call MsgBox(ex.Message, MessageBoxButtons.OK, "Validation Error")
            Me.Close()
        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        End Try
    End Sub
    Private Function ValidateQuantityWhileAddToCart() As Integer

        If DgvStocks.CurrentRow.Cells(CartTableQuantityCol).Value = 0 Then
            Throw (New ProductOutOfStockException("Sorry! The Selected Product is either 'Out Of Stock' " & vbNewLine & "OR You have already added all quantities to Your Cart."))
        End If

        Dim UserInputStr As String
        UserInputStr = Trim(InputBox("Enter Product Quantity: ", "Add More To Cart"))

        If UserInputStr = "" Then
            Throw (New QuantityNotSpecifiedException("Invalid Product Quantity"))
        End If

        Dim Quantity As Integer

        'Validate Specified Product Quantity
        If Not Integer.TryParse(UserInputStr, Quantity) OrElse Quantity = 0 Then
            Throw (New InvalidQuantitySpecifiedException("Invalid Product Quantity: " & UserInputStr & vbNewLine & "Enter Quantity in Numbers."))
        End If

        If DgvStocks.CurrentRow.Cells(CartTableQuantityCol).Value < Quantity Then
            Throw (New ShortageInQuantityException("Quantity Available In Stocks Is Upto : " & DgvStocks.CurrentRow.Cells(CartTableQuantityCol).Value & vbNewLine & "Specify Quantity Within Same Range."))
        End If

        ValidateQuantityWhileAddToCart = Quantity

    End Function
    Private Sub BtnAddToCart_Click(sender As System.Object, e As System.EventArgs) Handles BtnAddToCart.Click
        Try

            Dim Quantity As Integer

            'Validate Product Quantity While 'Add To Cart'
            Quantity = ValidateQuantityWhileAddToCart()

            'If Valide Quantity Specified, Then Proceed For 'Add To Cart'
            Dim RowFoundInCart As String = ""
            RowFoundInCart = Trim(DgvStocks.CurrentRow.Cells(DgvStocks.ColumnCount - 1).Value)

            If RowFoundInCart <> "" Then
                'If Selcted Product Already Present In Cart, Then Increase Quantity In Cart and Decrease From Stocks.
                DgvCart.Rows(CInt(RowFoundInCart)).Cells(CartTableQuantityCol).Value += Quantity
                DgvStocks.CurrentRow.Cells(CartTableQuantityCol).Value -= Quantity
            Else
                'If Selcted Product Not Present In Cart, Then Add Row In Cart With Mentioned Quantity
                Dim DataGridRow As New DataGridViewRow

                DataGridRow.CreateCells(DgvCart)

                For i As Integer = 0 To DgvCart.ColumnCount - 2
                    If DgvCart.Columns(i).Name = CartTableQuantityCol Then
                        DataGridRow.Cells(i).Value = Quantity
                        DgvStocks.CurrentRow.Cells(CartTableQuantityCol).Value -= Quantity
                    Else
                        DataGridRow.Cells(i).Value = DgvStocks.CurrentRow.Cells(i).Value
                    End If
                Next

                'Save Corresponding Row Numbers In Each Datagridview's Hidden Column.
                DataGridRow.Cells(DgvCart.ColumnCount - 1).Value = DgvStocks.CurrentRow.Index
                DgvCart.Rows.Add(DataGridRow)

                DgvStocks.CurrentRow.Cells(DgvStocks.ColumnCount - 1).Value = DgvCart.RowCount - 1
            End If

        Catch ex As ProductOutOfStockException
            Call MsgBox(ex.Message, MessageBoxButtons.OK, "Validation Error")
        Catch ex As QuantityNotSpecifiedException
            Call MsgBox(ex.Message, MessageBoxButtons.OK, "Validation Error")
        Catch ex As InvalidQuantitySpecifiedException
            Call MsgBox(ex.Message, MessageBoxButtons.OK, "Validation Error")
        Catch ex As ShortageInQuantityException
            Call MsgBox(ex.Message, MessageBoxButtons.OK, "Validation Error")
        Catch ex As Exception
            'Handle any other unexpected exceptions
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        End Try
    End Sub
    Private Function ValidateWhileRemoveFromCart() As Integer

        If DgvCart.Rows.Count = 0 Then
            Throw (New CartIsEmptyException("Cart Is Empty"))
        End If

    End Function
    Private Sub BtnRemoveAllFromCart_Click(sender As System.Object, e As System.EventArgs) Handles BtnRemoveAllFromCart.Click
        Try
            'Validate While Remove Product From Cart
            ValidateWhileRemoveFromCart()

            'If validation Sucess,
            Dim Quantity As Integer
            Dim DeletedRowincart As String
            Dim RowInStocks As String = ""

            RowInStocks = Trim(DgvCart.CurrentRow.Cells(DgvCart.ColumnCount - 1).Value)
            Quantity = DgvCart.CurrentRow.Cells(CartTableQuantityCol).Value

            'Setback Quantity To Stocks DataGridView
            DgvStocks.Rows(CInt(RowInStocks)).Cells(CartTableQuantityCol).Value += Quantity

            'Delete Product From Cart DataGridView
            DeletedRowincart = DgvCart.CurrentRow.Index
            DgvCart.Rows.RemoveAt(DgvCart.CurrentRow.Index)

            DgvStocks.Rows(CInt(RowInStocks)).Cells(DgvCart.ColumnCount - 1).Value = ""

            For DgvStocksRow As Integer = 0 To DgvStocks.Rows.Count - 1
                If Trim(DgvStocks.Rows(DgvStocksRow).Cells(DgvCart.ColumnCount - 1).Value) <> "" Then
                    If DgvStocks.Rows(DgvStocksRow).Cells(DgvCart.ColumnCount - 1).Value > DeletedRowincart Then
                        DgvStocks.Rows(DgvStocksRow).Cells(DgvCart.ColumnCount - 1).Value -= 1
                    End If
                End If
            Next

        Catch ex As CartIsEmptyException
            Call MsgBox(ex.Message, MessageBoxButtons.OK, "Validation Error")
        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        End Try
    End Sub
    Private Sub ValidateCart()

        If CmbCustomerInCart.Text = "" Then
            Throw (New CustomerNotSelectedException("Select Customer Name From List."))
        End If

        If DgvCart.Rows.Count = 0 Then
            Throw (New EmptyCartException("Add Product(s) To Cart Before Placing Order."))
        End If

    End Sub
    Private Sub BtnProceedPayment_Click(sender As System.Object, e As System.EventArgs) Handles BtnPlaceOrder.Click
        Try
            'Validate Cart Data Before Proceeding To Payment
            ValidateCart()

            'If Validation Success, then show Payment Window
            FormPayment.ShowDialog()

        Catch ex As CustomerNotSelectedException
            Call MsgBox(ex.Message, MessageBoxButtons.OK, "Validation Error")
        Catch ex As EmptyCartException
            Call MsgBox(ex.Message, MessageBoxButtons.OK, "Validation Error")
        Catch ex As Exception
            'Handle any other unexpected exceptions
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        End Try
    End Sub
End Class

Public Class CustomerNotSelectedException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
Public Class EmptyCartException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
Public Class ProductOutOfStockException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
Public Class QuantityNotSpecifiedException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
Public Class InvalidQuantitySpecifiedException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
Public Class ShortageInQuantityException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
Public Class CartIsEmptyException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
Public Class NoCustomersAddedException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
