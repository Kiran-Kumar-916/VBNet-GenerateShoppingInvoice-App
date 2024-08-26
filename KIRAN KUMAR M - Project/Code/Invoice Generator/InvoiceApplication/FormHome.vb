Imports System.Exception

Public Class FormHome
    Public FrmProducts As New FormProducts
    Public FrmCategories As New FormCategories
    Public FrmCustomers As New FormCustomers
    Public Const ProductsCaption As String = "Products"
    Public Const CategoriesCaption As String = "Categories"
    Public Const CustomersCaption As String = "Customers"

    Private Sub ProductToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ProductToolStripMenuItem.Click
        Try
            LblHomeCaption.Text = ProductsCaption
            PictureBoxHome.Image = Image.FromFile("Icons\Products.png")
        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        End Try
    End Sub
    Private Sub CategoriesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CategoriesToolStripMenuItem.Click
        Try
            LblHomeCaption.Text = CategoriesCaption
            PictureBoxHome.Image = Image.FromFile("Icons\Categories.png")
        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        End Try
    End Sub
    Private Sub CustomersToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CustomersToolStripMenuItem.Click
        Try
            LblHomeCaption.Text = CustomersCaption
            PictureBoxHome.Image = Image.FromFile("Icons\Customers.jpg")
        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        End Try
    End Sub
    Private Sub CartToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CartToolStripMenuItem.Click
        Try
            FormCart.ShowDialog()
        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        End Try
    End Sub

    Private Sub BtnHomeAdd_Click(sender As System.Object, e As System.EventArgs) Handles BtnHomeAdd.Click
        Try
            If LblHomeCaption.Text = ProductsCaption Then
                Call ShowProductAddWindow()
            ElseIf LblHomeCaption.Text = CategoriesCaption Then
                Call ShowCategoryAddWindow()
            ElseIf LblHomeCaption.Text = CustomersCaption Then
                Call ShowCustomerAddWindow()
            End If
        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        End Try
    End Sub
    Private Sub ValidateBeforeLoadingAddProductsWindow(lstCategoriesNames As String())

        If lstCategoriesNames Is Nothing Then
            Throw (New NoCategoryToAddProductException("Add Atleast One Category Before Adding Products!"))
        End If

    End Sub
    Private Sub ShowProductAddWindow()
        Try
            FrmProducts.CmbProductCategory.Items.Clear()

            Dim lstCategoriesNames As String()
            Dim categoryObj As New CategoriesManager()
            lstCategoriesNames = categoryObj.GetCategoriesNames()

            'Validate Before Loading Add Products Window
            ValidateBeforeLoadingAddProductsWindow(lstCategoriesNames)

            'If Validation success,
            'Enable/Disable Controls As Per Requirements
            'Visible/Hide Controls As Per Requirements
            FrmProducts.CmbProductName.Enabled = False
            FrmProducts.CmbProductName.Visible = False

            FrmProducts.TxtProductName.Visible = True
            FrmProducts.TxtProductName.Enabled = True
            FrmProducts.TxtProductDescription.Enabled = True
            FrmProducts.CmbProductCategory.Enabled = True
            FrmProducts.TxtProductPrice.Enabled = True
            FrmProducts.TxtProductQuantity.Enabled = True
            FrmProducts.TxtProductDiscount.Enabled = True
            FrmProducts.BtnProduct.Text = "ADD"

            'Update Categories ListBox
            For Each item As String In lstCategoriesNames
                FrmProducts.CmbProductCategory.Items.Add(item)
            Next

            'Show Products Window
            FrmProducts.ShowDialog()
        Catch ex As NoCategoryToAddProductException
            Call MsgBox(ex.Message, MessageBoxButtons.OK, "Validation Error")
        Catch ex As NoCategoryToUpdateProductException
            Call MsgBox(ex.Message, MessageBoxButtons.OK, "Validation Error")
        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        End Try
    End Sub
    Private Sub ShowCategoryAddWindow()
        Try
            'Enable/Disable Controls As Per Requirements
            'Visible/Hide Controls As Per Requirements
            FrmCategories.CmbCategoryName.Visible = False
            FrmCategories.CmbCategoryName.Enabled = False

            FrmCategories.TxtCategoryName.Visible = True
            FrmCategories.TxtCategoryName.Enabled = True
            FrmCategories.TxtCategoryDescription.Enabled = True
            FrmCategories.TxtCategoryTaxrate.Enabled = True
            FrmCategories.BtnCategories.Text = "ADD"

            'Show Categories Window
            FrmCategories.ShowDialog()

        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        End Try
    End Sub
    Private Sub ShowCustomerAddWindow()
        Try
            'Enable/Disable Controls As Per Requirements
            'Visible/Hide Controls As Per Requirements
            FrmCustomers.CmbCustomerName.Visible = False
            FrmCustomers.CmbCustomerName.Enabled = False

            FrmCustomers.TxtCustomerName.Visible = True
            FrmCustomers.TxtCustomerName.Enabled = True
            FrmCustomers.TxtCustomerEmail.Enabled = True
            FrmCustomers.TxtCustomerAddress.Enabled = True
            FrmCustomers.TxtCustomerContactNum.Enabled = True
            FrmCustomers.BtnCustomers.Text = "ADD"

            'Show Customers Window
            FrmCustomers.ShowDialog()

        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        End Try
    End Sub

    Private Sub BtnHomeUpdate_Click(sender As System.Object, e As System.EventArgs) Handles BtnHomeUpdate.Click
        Try
            If LblHomeCaption.Text = ProductsCaption Then
                Call ShowProductUpdateWindow()
            ElseIf LblHomeCaption.Text = CategoriesCaption Then
                Call ShowCategoryUpdateWindow()
            ElseIf LblHomeCaption.Text = CustomersCaption Then
                Call ShowCustomerUpdateWindow()
            End If

        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        End Try
    End Sub
    Public Sub ValidateBeforeLoadingUpdateProductsWindow(lstProductsNames As String(), lstCategoriesNames As String())

        If lstProductsNames Is Nothing Then
            Throw (New NoProductsToUpdateException("There Are No Products To Update!"))
        End If

        If lstCategoriesNames Is Nothing Then
            Throw (New NoCategoryToUpdateProductException("Add Atleast One Category Before Updating Products!"))
        End If

    End Sub
    Private Sub ShowProductUpdateWindow()
        Try
            FrmProducts.CmbProductName.Items.Clear()

            Dim lstProdutNames As String()
            Dim ProductsObj As New ProductsManager()
            lstProdutNames = ProductsObj.GetProductsNames()


            FrmProducts.CmbProductCategory.Items.Clear()

            Dim lstCategoriesNames() As String
            Dim CategoriesObj As New CategoriesManager()
            lstCategoriesNames = CategoriesObj.GetCategoriesNames()

            'Validate Before Loading Update Products Window
            ValidateBeforeLoadingUpdateProductsWindow(lstProdutNames, lstCategoriesNames)

            'If Validation success,
            'Enable/Disable Controls As Per Requirements
            'Visible/Hide Controls As Per Requirements
            FrmProducts.TxtProductName.Enabled = False
            FrmProducts.TxtProductName.Visible = False

            FrmProducts.CmbProductName.Visible = True
            FrmProducts.CmbProductName.Enabled = True

            FrmProducts.TxtProductDescription.Enabled = False
            FrmProducts.CmbProductCategory.Enabled = False
            FrmProducts.TxtProductPrice.Enabled = False
            FrmProducts.TxtProductQuantity.Enabled = False
            FrmProducts.TxtProductDiscount.Enabled = False
            FrmProducts.BtnProduct.Text = "UPDATE"

            'Update Produt Names ListBox
            For Each item As String In lstProdutNames
                FrmProducts.CmbProductName.Items.Add(item)
            Next

            'Update Categories Names ListBox
            For Each item As String In lstCategoriesNames
                FrmProducts.CmbProductCategory.Items.Add(item)
            Next

            'Show Products Window
            FrmProducts.ShowDialog()
        Catch ex As NoProductsToUpdateException
            Call MsgBox(ex.Message, MessageBoxButtons.OK, "Validation Error")
        Catch ex As NoCategoryToUpdateProductException
            Call MsgBox(ex.Message, MessageBoxButtons.OK, "Validation Error")
        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        End Try
    End Sub
    Private Sub ValidateBeforeLoadingUpdateCategoriesWindow(lstCategoriesNames As String())

        If lstCategoriesNames Is Nothing Then
            Throw (New NoCategoriesToUpdateException("There Are No Categories To Update!"))
        End If
    End Sub
    Private Sub ShowCategoryUpdateWindow()
        Try
            FrmCategories.CmbCategoryName.Items.Clear()

            Dim lstCategoriesNames As String()
            Dim CategoriesObj As New CategoriesManager()
            lstCategoriesNames = CategoriesObj.GetCategoriesNames()

            'Validate Before Loading Update Categories Window
            ValidateBeforeLoadingUpdateCategoriesWindow(lstCategoriesNames)

            'If Validation Success,
            'Enable/Disable Controls As Per Requirements
            'Visible/Hide Controls As Per Requirements
            FrmCategories.TxtCategoryName.Enabled = False
            FrmCategories.TxtCategoryName.Visible = False

            FrmCategories.CmbCategoryName.Visible = True
            FrmCategories.CmbCategoryName.Enabled = True

            FrmCategories.TxtCategoryDescription.Enabled = False
            FrmCategories.TxtCategoryTaxrate.Enabled = False
            FrmCategories.BtnCategories.Text = "UPDATE"

            For Each item As String In lstCategoriesNames
                FrmCategories.CmbCategoryName.Items.Add(item)
            Next

            'Show Categories Window
            FrmCategories.ShowDialog()

        Catch ex As NoCategoriesToUpdateException
            Call MsgBox(ex.Message, MessageBoxButtons.OK, "Validation Error")
        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        End Try
    End Sub
    Private Sub ValidateBeforeLoadingUpdateCustomersWindow(lstCustomersNames As String())

        If lstCustomersNames Is Nothing Then
            Throw (New NoCustomersToUpdateException("There Are No Customers To Update!"))
        End If

    End Sub
    Private Sub ShowCustomerUpdateWindow()
        Try
            FrmCustomers.CmbCustomerName.Items.Clear()

            Dim lstProdutNames As String()
            Dim CustomerObj As New CustomersManager()
            lstProdutNames = CustomerObj.GetCustomersNames()

            'Validate Before Loading Update Customers Window
            ValidateBeforeLoadingUpdateCustomersWindow(lstProdutNames)

            'If Validation success,
            'Enable/Disable Controls As Per Requirements
            'Visible/Hide Controls As Per Requirements
            FrmCustomers.TxtCustomerName.Enabled = False
            FrmCustomers.TxtCustomerName.Visible = False

            FrmCustomers.CmbCustomerName().Visible = True
            FrmCustomers.CmbCustomerName().Enabled = True

            FrmCustomers.TxtCustomerEmail.Enabled = False
            FrmCustomers.TxtCustomerAddress.Enabled = False
            FrmCustomers.TxtCustomerContactNum.Enabled = False

            FrmCustomers.BtnCustomers.Text = "UPDATE"

            For Each item As String In lstProdutNames
                FrmCustomers.CmbCustomerName.Items.Add(item)
            Next

            'Show Customers Window
            FrmCustomers.ShowDialog()

        Catch ex As NoCustomersToUpdateException
            Call MsgBox(ex.Message, MessageBoxButtons.OK, "Validation Error")
        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        End Try
    End Sub

    Private Sub BtnHomeDelete_Click(sender As System.Object, e As System.EventArgs) Handles BtnHomeDelete.Click
        Try
            If LblHomeCaption.Text = ProductsCaption Then
                Call ShowProductDeleteWindow()
            ElseIf LblHomeCaption.Text = CategoriesCaption Then
                Call ShowCategoryDeleteWindow()
            ElseIf LblHomeCaption.Text = CustomersCaption Then
                Call ShowCustomerDeleteWindow()
            End If

        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        End Try
    End Sub
    Private Sub ValidateBeforeLoadingDeleteProductsWindow(lstProductsNames As String())

        If lstProductsNames Is Nothing Then
            Throw (New NoProductsToDeleteException("There Are No Products To Delete!"))
        End If

    End Sub
    Private Sub ShowProductDeleteWindow()
        Try
            FrmProducts.CmbProductName.Items.Clear()

            Dim lstProdutNames As String()
            Dim ProductsObj As New ProductsManager()
            lstProdutNames = ProductsObj.GetProductsNames()

            'Validate Before Loading Delete Products Window
            ValidateBeforeLoadingDeleteProductsWindow(lstProdutNames)

            'If Validation Success,
            'Enable/Disable Controls As Per Requirements
            'Visible/Hide Controls As Per Requirements
            FrmProducts.TxtProductName.Enabled = False
            FrmProducts.TxtProductName.Visible = False

            FrmProducts.CmbProductName.Visible = True
            FrmProducts.CmbProductName.Enabled = True

            FrmProducts.TxtProductDescription.Enabled = False
            FrmProducts.CmbProductCategory.Enabled = False
            FrmProducts.TxtProductPrice.Enabled = False
            FrmProducts.TxtProductQuantity.Enabled = False
            FrmProducts.TxtProductDiscount.Enabled = False
            FrmProducts.BtnProduct.Text = "DELETE"
            
            For Each item As String In lstProdutNames
                FrmProducts.CmbProductName.Items.Add(item)
            Next

            'Show Products Window
            FrmProducts.ShowDialog()

        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        End Try
    End Sub
    Private Sub ValidateBeforeLoadingDeleteCategoriesWindow(lstCategoriesNames As String())

        If lstCategoriesNames Is Nothing Then
            Throw (New NoCategoriesToDeleteException("There Are No Categories To Delete!"))
        End If
    End Sub
    Private Sub ShowCategoryDeleteWindow()
        Try
            FrmCategories.CmbCategoryName.Items.Clear()

            Dim lstCategoriesNames As String()
            Dim CategoriesObj As New CategoriesManager()
            lstCategoriesNames = CategoriesObj.GetCategoriesNames()

            'Validate Before Loading Delete Categories Window
            ValidateBeforeLoadingDeleteCategoriesWindow(lstCategoriesNames)

            'If Validation success,
            'Enable/Disable Controls As Per Requirements
            'Visible/Hide Controls As Per Requirements
            FrmCategories.TxtCategoryName.Enabled = False
            FrmCategories.TxtCategoryName.Visible = False

            FrmCategories.CmbCategoryName.Visible = True
            FrmCategories.CmbCategoryName.Enabled = True

            FrmCategories.TxtCategoryDescription.Enabled = False
            FrmCategories.TxtCategoryTaxrate.Enabled = False
            FrmCategories.BtnCategories.Text = "DELETE"

            For Each item As String In lstCategoriesNames
                FrmCategories.CmbCategoryName.Items.Add(item)
            Next

            'Show Categories Window
            FrmCategories.ShowDialog()

        Catch ex As NoCategoriesToDeleteException
            Call MsgBox(ex.Message, MessageBoxButtons.OK, "Validation Error")
        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        End Try
    End Sub
    Private Sub ValidateBeforeLoadingDeleteCustomersWindow(lstCustomersNames As String())

        If lstCustomersNames Is Nothing Then
            Throw (New NoCustomersToDeleteException("There Are No Customers To Delete!"))
        End If

    End Sub
    Private Sub ShowCustomerDeleteWindow()
        Try
            FrmCustomers.CmbCustomerName.Items.Clear()

            Dim lstProdutNames As String()
            Dim CustomersObj As New CustomersManager()
            lstProdutNames = CustomersObj.GetCustomersNames()

            ValidateBeforeLoadingDeleteCustomersWindow(lstProdutNames)

            'If Validation success,
            'Enable/Disable Controls As Per Requirements
            'Visible/Hide Controls As Per Requirements
            FrmCustomers.TxtCustomerName.Enabled = False
            FrmCustomers.TxtCustomerName.Visible = False

            FrmCustomers.CmbCustomerName.Visible = True
            FrmCustomers.CmbCustomerName.Enabled = True

            FrmCustomers.TxtCustomerEmail.Enabled = False
            FrmCustomers.TxtCustomerAddress.Enabled = False
            FrmCustomers.TxtCustomerContactNum.Enabled = False
            FrmCustomers.BtnCustomers.Text = "DELETE"

            'If Validation Success, Then Continue and Show Form To Delete Customers
            For Each item As String In lstProdutNames
                FrmCustomers.CmbCustomerName.Items.Add(item)
            Next

            'Show Customers Window
            FrmCustomers.ShowDialog()

        Catch ex As NoCustomersToDeleteException
            Call MsgBox(ex.Message, MessageBoxButtons.OK, "Validation Error")
        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        End Try
    End Sub

End Class
Public Class NoProductsToDeleteException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
Public Class NoProductsToUpdateException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
Public Class NoCategoriesToDeleteException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
Public Class NoCategoriesToUpdateException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
Public Class NoCustomersToDeleteException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
Public Class NoCustomersToUpdateException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
Public Class NoCategoryToAddProductException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
Public Class NoCategoryToUpdateProductException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
