Imports System.Exception
Imports System.Text.RegularExpressions

Public Class FormCategories
    Public CategoriesObj As CategoriesManager = New CategoriesManager()

    Private Sub FormCategories_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try

            Me.Left = FormHome.PictureBoxHome.Left - 5
            Me.Top = FormHome.PictureBoxHome.Top - 5
            Me.Height = FormHome.PictureBoxHome.Height + 100
            Me.Width = FormHome.PictureBoxHome.Width + 100

            CmbCategoryName.Text = ""

            TxtCategoryName.Text = ""
            TxtCategoryDescription.Text = ""
            TxtCategoryTaxrate.Text = ""
        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        End Try
    End Sub
    Private Sub ValidateCategoriesData(name As String, description As String, taxRate As String)

        'Validate Categories Name (i.e Not Empty)
        If String.IsNullOrWhiteSpace(name) Then
            Throw (New InvalidCategoriesNameException("Invalid Category Name: " & name))
        End If

        'Validate Categories Description (i.e Not Empty)
        If String.IsNullOrWhiteSpace(description) Then
            Throw (New InvalidCategoriesDescriptionException("Invalid Category Description: " & description))
        End If

        'Validate Categories TaxRate (Using Regular Expression)
        If Not Regex.IsMatch(taxRate, "^\d+(\.\d+)?$") Then
            'If Not IsNumeric(taxRate) Then
            Throw (New InvalidCategoriesTaxRateException("Invalid Category TaxRate: " & taxRate))
        End If

    End Sub
    Private Sub BtnCategories_Click(sender As System.Object, e As System.EventArgs) Handles BtnCategories.Click
        Try
            Dim name As String = Trim(TxtCategoryName.Text)
            Dim description As String = Trim(TxtCategoryDescription.Text)
            Dim taxRate As String = Trim(TxtCategoryTaxrate.Text)

            Select Case UCase(Trim((BtnCategories.Text)))

                Case "ADD"
                    'Validate the Categories Input Data
                    ValidateCategoriesData(name, description, taxRate)

                    'If Validation success,
                    Call CategoriesObj.AddData(name, description, taxRate)

                    TxtCategoryName.Text = ""
                    TxtCategoryDescription.Text = ""
                    TxtCategoryTaxrate.Text = ""
                Case "DELETE"
                    Call CategoriesObj.DeleteData(name)

                    CmbCategoryName.Text = ""
                    TxtCategoryName.Text = ""
                    TxtCategoryDescription.Text = ""
                    TxtCategoryTaxrate.Text = ""

                    CmbCategoryName.Items.Remove(name)
                Case "UPDATE"
                    'Validate the Categories Input Data
                    ValidateCategoriesData(name, description, taxRate)

                    'If Validation success,
                    Call CategoriesObj.UpdateData(name, description, taxRate)
            End Select

        Catch ex As InvalidCategoriesNameException
            Call MsgBox(ex.Message, MessageBoxButtons.OK, "Validation Error")
        Catch ex As InvalidCategoriesDescriptionException
            Call MsgBox(ex.Message, MessageBoxButtons.OK, "Validation Error")
        Catch ex As InvalidCategoriesTaxRateException
            Call MsgBox(ex.Message, MessageBoxButtons.OK, "Validation Error")
        Catch ex As DuplicateCategoryException
            Call MsgBox(ex.Message, MessageBoxButtons.OK, "Validation Error")
        Catch ex As Exception
            'Handle any other unexpected exceptions
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        End Try
    End Sub
    Private Sub CmbCategoriesName_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles CmbCategoryName.SelectedValueChanged
        Try

            If UCase(Trim((BtnCategories.Text))) = "UPDATE" Then
                TxtCategoryDescription.Enabled = True
                TxtCategoryTaxrate.Enabled = True
            End If

            'Load Selected Category Details
            Dim CategoryName As String
            CategoryName = CmbCategoryName.Text
            Dim lstProductDetails As String()

            lstProductDetails = CategoriesObj.GetSelectedCategoriesDetails(CategoryName)

            TxtCategoryName.Text = lstProductDetails(0)
            TxtCategoryDescription.Text = lstProductDetails(1)
            TxtCategoryTaxrate.Text = lstProductDetails(2)
            
        Catch ex As Exception
            Call MsgBox("An Unexpected Error Occurred: " & ex.Message, MessageBoxButtons.OK, "Error")
        End Try
    End Sub
End Class
Public Class InvalidCategoriesNameException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
Public Class InvalidCategoriesDescriptionException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
Public Class InvalidCategoriesTaxRateException
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