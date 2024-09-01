Imports System.Exception
Imports System.Text.RegularExpressions
Imports BLL
Imports DAL

Public Class FormProducts

    Private ProductsObj As New ProductsManager(ProductsDatabaseHandler)
    Private Sub FormProducts_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            Me.Left = FormHome.PictureBoxHome.Left - 5
            Me.Top = FormHome.PictureBoxHome.Top - 5
            Me.Height = FormHome.PictureBoxHome.Height + 100
            Me.Width = FormHome.PictureBoxHome.Width + 100

            CmbProductName.Text = ""

            TxtProductName.Text = ""
            TxtProductDescription.Text = ""
            CmbProductCategory.SelectedIndex = -1
            TxtProductPrice.Text = ""
            TxtProductQuantity.Text = ""
            TxtProductDiscount.Text = ""
        Catch ex As Exception
            MessageBox.Show("An Unexpected Error Occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub ValidateProductData(name As String, description As String, category As String, price As String, quantity As String, discount As String)
        Dim intNumber As Integer

        'Validate Product Name (i.e Not Empty)
        If String.IsNullOrWhiteSpace(name) Then
            Throw (New InvalidProductNameException("Invalid Product Name: " & name))
        End If

        'Validate Product Description (i.e Not Empty)
        If String.IsNullOrWhiteSpace(description) Then
            Throw (New InvalidProductDescriptionException("Invalid Product Description: " & description))
        End If

        'Validate Product Category (i.e Not Empty)
        If String.IsNullOrWhiteSpace(category) Then
            Throw (New InvalidProductCategorytException("Invalid Product Category: " & category))
        End If

        'Validate Product Price (Using Regular Expression)
        If Not Regex.IsMatch(price, "^\d+(\.\d+)?$") Then
            'If Not IsNumeric(price) Then
            Throw (New InvalidProductPriceException("Invalid Product Price: " & price))
        End If

        'Validate Product Quantity - should be Interger.
        If Not Integer.TryParse(quantity, intNumber) Then
            Throw (New InvalidProductQuantityException("Invalid Product Quantity: " & quantity))
        End If

        'Validate Product Discount (Using Regular Expression)
        If Not Regex.IsMatch(discount, "^\d+(\.\d+)?$") Then
            'If Not IsNumeric(discount) Then
            Throw (New InvalidProductDiscountException("Invalid Product Discount: " & discount))
        End If

    End Sub
    Private Sub BtnProduct_Click(sender As System.Object, e As System.EventArgs) Handles BtnProduct.Click
        Try
            Dim Name As String = Trim(TxtProductName.Text) 'ComboBox1.Text
            Dim Desc As String = Trim(TxtProductDescription.Text)
            Dim Price As String = Trim(TxtProductPrice.Text)
            Dim Quantity As String = Trim(TxtProductQuantity.Text)
            Dim Category As String = Trim(CmbProductCategory.Text)
            Dim Discount As String = Trim(TxtProductDiscount.Text)

            Select Case UCase(Trim((BtnProduct.Text)))

                Case "ADD"
                    'Validate the Product Input Data
                    ValidateProductData(Name, Desc, Category, Price, Quantity, Discount)

                    'If Validation success,
                    If ProductsObj.AddProduct(Name, Desc, Category, Price, Quantity, Discount) = True Then
                        MessageBox.Show("New Product Added Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    TxtProductName.Text = ""
                    TxtProductDescription.Text = ""
                    CmbProductCategory.SelectedIndex = -1
                    TxtProductPrice.Text = ""
                    TxtProductQuantity.Text = ""
                    TxtProductDiscount.Text = ""

                Case "UPDATE"
                    'Validate the Product Input Data
                    ValidateProductData(Name, Desc, Category, Price, Quantity, Discount)

                    'If Validation success,
                    If ProductsObj.UpdateProduct(Name, Desc, Category, Price, Quantity, Discount) Then
                        MessageBox.Show("Product Details Updated Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                Case "DELETE"
                    If ProductsObj.DeleteProduct(Name) Then
                        MessageBox.Show("Product Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    CmbProductName.Text = ""
                    TxtProductName.Text = ""
                    TxtProductDescription.Text = ""
                    CmbProductCategory.SelectedIndex = -1
                    TxtProductPrice.Text = ""
                    TxtProductQuantity.Text = ""
                    TxtProductDiscount.Text = ""

                    CmbProductName.Items.Remove(Name)
            End Select

        Catch ex As InvalidProductNameException
            MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As InvalidProductDescriptionException
            MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As InvalidProductCategorytException
            MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As InvalidProductPriceException
            MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As InvalidProductQuantityException
            MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As InvalidProductDiscountException
            MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As DuplicateProductException
            MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As ApplicationException
            MessageBox.Show("Exception: " & ex.Message & ", Inner Exception: " & ex.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            'Handle any other unexpected exceptions
            MessageBox.Show("An Unexpected Error Occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub CmbProductName_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles CmbProductName.SelectedValueChanged
        Try

            If UCase(Trim((BtnProduct.Text))) = "UPDATE" Then
                TxtProductDescription.Enabled = True
                CmbProductCategory.Enabled = True
                TxtProductPrice.Enabled = True
                TxtProductQuantity.Enabled = True
                TxtProductDiscount.Enabled = True
            End If

            Dim CustomerName As String
            CustomerName = CmbProductName.Text

            'Load SelectedProduct Details
            Dim lstProductDetails As String()
            lstProductDetails = ProductsObj.GetSelectedProductDetails(CustomerName)

            TxtProductName.Text = lstProductDetails(0)
            TxtProductDescription.Text = lstProductDetails(1)
            CmbProductCategory.SelectedItem = lstProductDetails(2)
            TxtProductPrice.Text = lstProductDetails(3)
            TxtProductQuantity.Text = lstProductDetails(4)

            TxtProductDiscount.Text = lstProductDetails(5)

        Catch ex As Exception
            MessageBox.Show("An Unexpected Error Occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

End Class

Public Class InvalidProductNameException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
Public Class InvalidProductDescriptionException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
Public Class InvalidProductCategorytException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
Public Class InvalidProductQuantityException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
Public Class InvalidProductPriceException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
Public Class InvalidProductDiscountException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class