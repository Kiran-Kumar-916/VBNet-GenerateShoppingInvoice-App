Imports System.Exception
Imports BLL
Imports DAL

Public Module Program
    Public Const ProductsCaption As String = "Products"
    Public Const CategoriesCaption As String = "Categories"
    Public Const CustomersCaption As String = "Customers"

    Public ProductsDataPath As String = "Products.csv"
    Public CategoriesDataPath As String = "Categories.csv"
    Public CustomersDataPath As String = "Customers.csv"

    'Set dependencies
    Public ProductsDatabaseHandler As IDatabaseHandler = New CSVHandler(ProductsDataPath)
    Public CategoriesDatabaseHandler As IDatabaseHandler = New CSVHandler(CategoriesDataPath)
    Public CustomersDatabaseHandler As IDatabaseHandler = New CSVHandler(CustomersDataPath)
End Module

Public Class FormHome

    Private Sub ProductToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ProductToolStripMenuItem.Click
        Try
            LblHomeCaption.Text = ProductsCaption
            PictureBoxHome.Image = Image.FromFile("Icons\Products.png")
        Catch ex As Exception
            MessageBox.Show("An Unexpected Error Occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub CategoriesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CategoriesToolStripMenuItem.Click
        Try
            LblHomeCaption.Text = CategoriesCaption
            PictureBoxHome.Image = Image.FromFile("Icons\Categories.png")
        Catch ex As Exception
            MessageBox.Show("An Unexpected Error Occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub CustomersToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CustomersToolStripMenuItem.Click
        Try
            LblHomeCaption.Text = CustomersCaption
            PictureBoxHome.Image = Image.FromFile("Icons\Customers.jpg")
        Catch ex As Exception
            MessageBox.Show("An Unexpected Error Occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub CartToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CartToolStripMenuItem.Click
        Try
            FormCart.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("An Unexpected Error Occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            MessageBox.Show("An Unexpected Error Occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub ValidateBeforeLoadingAddProductsWindow(lstCategoriesNames As String())

        If lstCategoriesNames Is Nothing Then
            Throw (New NoCategoryToAddProductException("Add Atleast One Category Before Adding Products!"))
        End If

    End Sub
    Private Sub ShowProductAddWindow()
        Try
            FormProducts.CmbProductCategory.Items.Clear()

            Dim lstCategoriesNames As String()
            Dim CategoryObj As New CategoriesManager(categoriesDatabaseHandler)
            lstCategoriesNames = CategoryObj.GetCategoriesNames()

            'Validate Before Loading Add Products Window
            ValidateBeforeLoadingAddProductsWindow(lstCategoriesNames)

            'If Validation success,
            'Enable/Disable Controls As Per Requirements
            'Visible/Hide Controls As Per Requirements
            FormProducts.CmbProductName.Enabled = False
            FormProducts.CmbProductName.Visible = False

            FormProducts.TxtProductName.Visible = True
            FormProducts.TxtProductName.Enabled = True
            FormProducts.TxtProductDescription.Enabled = True
            FormProducts.CmbProductCategory.Enabled = True
            FormProducts.TxtProductPrice.Enabled = True
            FormProducts.TxtProductQuantity.Enabled = True
            FormProducts.TxtProductDiscount.Enabled = True
            FormProducts.BtnProduct.Text = "ADD"

            'Update Categories ListBox
            For Each item As String In lstCategoriesNames
                FormProducts.CmbProductCategory.Items.Add(item)
            Next

            'Show Products Window
            FormProducts.ShowDialog()
        Catch ex As NoCategoryToAddProductException
            MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As NoCategoryToUpdateProductException
            MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            MessageBox.Show("An Unexpected Error Occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub ShowCategoryAddWindow()
        Try
            'Enable/Disable Controls As Per Requirements
            'Visible/Hide Controls As Per Requirements
            FormCategories.CmbCategoryName.Visible = False
            FormCategories.CmbCategoryName.Enabled = False

            FormCategories.TxtCategoryName.Visible = True
            FormCategories.TxtCategoryName.Enabled = True
            FormCategories.TxtCategoryDescription.Enabled = True
            FormCategories.TxtCategoryTaxrate.Enabled = True
            FormCategories.BtnCategories.Text = "ADD"

            'Show Categories Window
            FormCategories.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("An Unexpected Error Occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub ShowCustomerAddWindow()
        Try
            'Enable/Disable Controls As Per Requirements
            'Visible/Hide Controls As Per Requirements
            FormCustomers.CmbCustomerName.Visible = False
            FormCustomers.CmbCustomerName.Enabled = False

            FormCustomers.TxtCustomerName.Visible = True
            FormCustomers.TxtCustomerName.Enabled = True
            FormCustomers.TxtCustomerEmail.Enabled = True
            FormCustomers.TxtCustomerAddress.Enabled = True
            FormCustomers.TxtCustomerContactNum.Enabled = True
            FormCustomers.BtnCustomers.Text = "ADD"

            'Show Customers Window
            FormCustomers.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("An Unexpected Error Occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            MessageBox.Show("An Unexpected Error Occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            FormProducts.CmbProductName.Items.Clear()

            Dim lstProdutNames As String()
            Dim ProductsObj As New ProductsManager(ProductsDatabaseHandler)
            lstProdutNames = ProductsObj.GetProductsNames()


            FormProducts.CmbProductCategory.Items.Clear()

            Dim lstCategoriesNames() As String
            Dim CategoriesObj As New CategoriesManager(CategoriesDatabaseHandler)
            lstCategoriesNames = CategoriesObj.GetCategoriesNames()

            'Validate Before Loading Update Products Window
            ValidateBeforeLoadingUpdateProductsWindow(lstProdutNames, lstCategoriesNames)

            'If Validation success,
            'Enable/Disable Controls As Per Requirements
            'Visible/Hide Controls As Per Requirements
            FormProducts.TxtProductName.Enabled = False
            FormProducts.TxtProductName.Visible = False

            FormProducts.CmbProductName.Visible = True
            FormProducts.CmbProductName.Enabled = True

            FormProducts.TxtProductDescription.Enabled = False
            FormProducts.CmbProductCategory.Enabled = False
            FormProducts.TxtProductPrice.Enabled = False
            FormProducts.TxtProductQuantity.Enabled = False
            FormProducts.TxtProductDiscount.Enabled = False
            FormProducts.BtnProduct.Text = "UPDATE"

            'Update Produt Names ListBox
            For Each item As String In lstProdutNames
                FormProducts.CmbProductName.Items.Add(item)
            Next

            'Update Categories Names ListBox
            For Each item As String In lstCategoriesNames
                FormProducts.CmbProductCategory.Items.Add(item)
            Next

            'Show Products Window
            FormProducts.ShowDialog()
        Catch ex As NoProductsToUpdateException
            MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As NoCategoryToUpdateProductException
            MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            MessageBox.Show("An Unexpected Error Occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub ValidateBeforeLoadingUpdateCategoriesWindow(lstCategoriesNames As String())

        If lstCategoriesNames Is Nothing Then
            Throw (New NoCategoriesToUpdateException("There Are No Categories To Update!"))
        End If
    End Sub
    Private Sub ShowCategoryUpdateWindow()
        Try
            FormCategories.CmbCategoryName.Items.Clear()

            Dim lstCategoriesNames As String()
            Dim CategoriesObj As New CategoriesManager(CategoriesDatabaseHandler)
            lstCategoriesNames = CategoriesObj.GetCategoriesNames()

            'Validate Before Loading Update Categories Window
            ValidateBeforeLoadingUpdateCategoriesWindow(lstCategoriesNames)

            'If Validation Success,
            'Enable/Disable Controls As Per Requirements
            'Visible/Hide Controls As Per Requirements
            FormCategories.TxtCategoryName.Enabled = False
            FormCategories.TxtCategoryName.Visible = False

            FormCategories.CmbCategoryName.Visible = True
            FormCategories.CmbCategoryName.Enabled = True

            FormCategories.TxtCategoryDescription.Enabled = False
            FormCategories.TxtCategoryTaxrate.Enabled = False
            FormCategories.BtnCategories.Text = "UPDATE"

            For Each item As String In lstCategoriesNames
                FormCategories.CmbCategoryName.Items.Add(item)
            Next

            'Show Categories Window
            FormCategories.ShowDialog()

        Catch ex As NoCategoriesToUpdateException
            MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            MessageBox.Show("An Unexpected Error Occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub ValidateBeforeLoadingUpdateCustomersWindow(lstCustomersNames As String())

        If lstCustomersNames Is Nothing Then
            Throw (New NoCustomersToUpdateException("There Are No Customers To Update!"))
        End If

    End Sub
    Private Sub ShowCustomerUpdateWindow()
        Try
            FormCustomers.CmbCustomerName.Items.Clear()

            Dim lstProdutNames As String()
            Dim CustomerObj As New CustomersManager(CustomersDatabaseHandler)
            lstProdutNames = CustomerObj.GetCustomersNames()

            'Validate Before Loading Update Customers Window
            ValidateBeforeLoadingUpdateCustomersWindow(lstProdutNames)

            'If Validation success,
            'Enable/Disable Controls As Per Requirements
            'Visible/Hide Controls As Per Requirements
            FormCustomers.TxtCustomerName.Enabled = False
            FormCustomers.TxtCustomerName.Visible = False

            FormCustomers.CmbCustomerName().Visible = True
            FormCustomers.CmbCustomerName().Enabled = True

            FormCustomers.TxtCustomerEmail.Enabled = False
            FormCustomers.TxtCustomerAddress.Enabled = False
            FormCustomers.TxtCustomerContactNum.Enabled = False

            FormCustomers.BtnCustomers.Text = "UPDATE"

            For Each item As String In lstProdutNames
                FormCustomers.CmbCustomerName.Items.Add(item)
            Next

            'Show Customers Window
            FormCustomers.ShowDialog()

        Catch ex As NoCustomersToUpdateException
            MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            MessageBox.Show("An Unexpected Error Occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            MessageBox.Show("An Unexpected Error Occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub ValidateBeforeLoadingDeleteProductsWindow(lstProductsNames As String())

        If lstProductsNames Is Nothing Then
            Throw (New NoProductsToDeleteException("There Are No Products To Delete!"))
        End If

    End Sub
    Private Sub ShowProductDeleteWindow()
        Try
            FormProducts.CmbProductName.Items.Clear()

            Dim lstProdutNames As String()
            Dim ProductsObj As New ProductsManager(ProductsDatabaseHandler)
            lstProdutNames = ProductsObj.GetProductsNames()

            'Validate Before Loading Delete Products Window
            ValidateBeforeLoadingDeleteProductsWindow(lstProdutNames)

            'If Validation Success,
            'Enable/Disable Controls As Per Requirements
            'Visible/Hide Controls As Per Requirements
            FormProducts.TxtProductName.Enabled = False
            FormProducts.TxtProductName.Visible = False

            FormProducts.CmbProductName.Visible = True
            FormProducts.CmbProductName.Enabled = True

            FormProducts.TxtProductDescription.Enabled = False
            FormProducts.CmbProductCategory.Enabled = False
            FormProducts.TxtProductPrice.Enabled = False
            FormProducts.TxtProductQuantity.Enabled = False
            FormProducts.TxtProductDiscount.Enabled = False
            FormProducts.BtnProduct.Text = "DELETE"

            For Each item As String In lstProdutNames
                FormProducts.CmbProductName.Items.Add(item)
            Next

            'Show Products Window
            FormProducts.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("An Unexpected Error Occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub ValidateBeforeLoadingDeleteCategoriesWindow(lstCategoriesNames As String())

        If lstCategoriesNames Is Nothing Then
            Throw (New NoCategoriesToDeleteException("There Are No Categories To Delete!"))
        End If
    End Sub
    Private Sub ShowCategoryDeleteWindow()
        Try
            FormCategories.CmbCategoryName.Items.Clear()

            Dim lstCategoriesNames As String()
            Dim CategoriesObj As New CategoriesManager(CategoriesDatabaseHandler)
            lstCategoriesNames = CategoriesObj.GetCategoriesNames()

            'Validate Before Loading Delete Categories Window
            ValidateBeforeLoadingDeleteCategoriesWindow(lstCategoriesNames)

            'If Validation success,
            'Enable/Disable Controls As Per Requirements
            'Visible/Hide Controls As Per Requirements
            FormCategories.TxtCategoryName.Enabled = False
            FormCategories.TxtCategoryName.Visible = False

            FormCategories.CmbCategoryName.Visible = True
            FormCategories.CmbCategoryName.Enabled = True

            FormCategories.TxtCategoryDescription.Enabled = False
            FormCategories.TxtCategoryTaxrate.Enabled = False
            FormCategories.BtnCategories.Text = "DELETE"

            For Each item As String In lstCategoriesNames
                FormCategories.CmbCategoryName.Items.Add(item)
            Next

            'Show Categories Window
            FormCategories.ShowDialog()

        Catch ex As NoCategoriesToDeleteException
            MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            MessageBox.Show("An Unexpected Error Occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub ValidateBeforeLoadingDeleteCustomersWindow(lstCustomersNames As String())

        If lstCustomersNames Is Nothing Then
            Throw (New NoCustomersToDeleteException("There Are No Customers To Delete!"))
        End If

    End Sub
    Private Sub ShowCustomerDeleteWindow()
        Try
            FormCustomers.CmbCustomerName.Items.Clear()

            Dim lstProdutNames As String()
            Dim CustomersObj As New CustomersManager(CustomersDatabaseHandler)
            lstProdutNames = CustomersObj.GetCustomersNames()

            ValidateBeforeLoadingDeleteCustomersWindow(lstProdutNames)

            'If Validation success,
            'Enable/Disable Controls As Per Requirements
            'Visible/Hide Controls As Per Requirements
            FormCustomers.TxtCustomerName.Enabled = False
            FormCustomers.TxtCustomerName.Visible = False

            FormCustomers.CmbCustomerName.Visible = True
            FormCustomers.CmbCustomerName.Enabled = True

            FormCustomers.TxtCustomerEmail.Enabled = False
            FormCustomers.TxtCustomerAddress.Enabled = False
            FormCustomers.TxtCustomerContactNum.Enabled = False
            FormCustomers.BtnCustomers.Text = "DELETE"

            'If Validation Success, Then Continue and Show Form To Delete Customers
            For Each item As String In lstProdutNames
                FormCustomers.CmbCustomerName.Items.Add(item)
            Next

            'Show Customers Window
            FormCustomers.ShowDialog()

        Catch ex As NoCustomersToDeleteException
            MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            MessageBox.Show("An Unexpected Error Occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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