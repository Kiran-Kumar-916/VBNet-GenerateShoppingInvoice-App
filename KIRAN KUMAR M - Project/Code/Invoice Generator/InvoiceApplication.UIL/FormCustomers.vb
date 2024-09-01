Imports System.Exception
Imports System.Text.RegularExpressions
Imports BLL
Imports DAL

Public Class FormCustomers
    
    Private CustomersObj As CustomersManager = New CustomersManager(CustomersDatabaseHandler)

    Private Sub FormCustomers_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try

            Me.Left = FormHome.PictureBoxHome.Left - 5
            Me.Top = FormHome.PictureBoxHome.Top - 5
            Me.Height = FormHome.PictureBoxHome.Height + 100
            Me.Width = FormHome.PictureBoxHome.Width + 100

            CmbCustomerName.Text = ""

            TxtCustomerName.Text = ""
            TxtCustomerEmail.Text = ""
            TxtCustomerName.Text = ""
            TxtCustomerAddress.Text = ""
            TxtCustomerContactNum.Text = ""
        Catch ex As Exception
            MessageBox.Show("An Unexpected Error Occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub ValidateCustomerData(name As String, email As String, address As String, ContactNumber As String)

        'Validate Customer Name (i.e Not Empty)
        If String.IsNullOrWhiteSpace(name) Then
            Throw (New InvalidCustomerNameException("Invalid Customer Name: " & name))
        End If

        'Validate Customer Email Pattern (Using Regular Expression)
        If Not Regex.IsMatch(email, "^\S+@\S+\.\S+$") Then
            Throw (New InvalidCustomerEmailException("Invalid Customer Email: " & email))
        End If

        'Validate Customer Address (i.e Not Empty)
        If String.IsNullOrWhiteSpace(address) Then
            Throw (New InvalidCustomerAddressException("Invalid Customer Address:" & address))
        End If

        'Validate Customer Contact Number Pattern (Using Regular Expression)
        If Not Regex.IsMatch(ContactNumber, "^\d{10}$") Then
            Throw (New InvalidCustomerContactNumberException("Invalid Customer Contact Number: " & ContactNumber))
        End If

    End Sub
    Private Sub BtnCustomers_Click(sender As System.Object, e As System.EventArgs) Handles BtnCustomers.Click
        Try
            Dim name As String = Trim(TxtCustomerName.Text) 'ComboBox1.Text
            Dim email As String = Trim(TxtCustomerEmail.Text)
            Dim address As String = Trim(TxtCustomerAddress.Text)
            Dim contactNumber As String = Trim(TxtCustomerContactNum.Text)

            Select Case UCase(Trim((BtnCustomers.Text)))

                Case "ADD"
                    'Validate the Customer Input Data
                    ValidateCustomerData(name, email, address, contactNumber)

                    'If Validation success,
                    If CustomersObj.AddCustomer(name, email, address, contactNumber) Then
                        MessageBox.Show("New Customer Detail Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    TxtCustomerName.Text = ""
                    TxtCustomerEmail.Text = ""
                    TxtCustomerAddress.Text = ""
                    TxtCustomerContactNum.Text = ""

                Case "UPDATE"
                    'Validate the Customer Input Data
                    ValidateCustomerData(name, email, address, contactNumber)

                    'If Validation success,
                    If CustomersObj.UpdateCustomer(name, email, address, contactNumber) Then
                        MessageBox.Show("Customer Details Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                Case "DELETE"
                    If CustomersObj.DeleteCustomer(name) Then
                        MessageBox.Show("Customer Details Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    CmbCustomerName.Text = ""
                    TxtCustomerName.Text = ""
                    TxtCustomerEmail.Text = ""
                    TxtCustomerName.Text = ""
                    TxtCustomerAddress.Text = ""
                    TxtCustomerContactNum.Text = ""

                    CmbCustomerName.Items.Remove(name)

            End Select

        Catch ex As InvalidCustomerNameException
            MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As InvalidCustomerEmailException
            MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As InvalidCustomerAddressException
            MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As InvalidCustomerContactNumberException
            MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As DuplicateCustomerException
            MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As ApplicationException
            MessageBox.Show("Exception: " & ex.Message & ", Inner Exception: " & ex.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            'Handle any other unexpected exceptions
            MessageBox.Show("An Unexpected Error Occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub CmbCustomerName_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles CmbCustomerName.SelectedValueChanged
        Try
            If UCase(Trim((BtnCustomers.Text))) = "UPDATE" Then
                TxtCustomerEmail.Enabled = True
                TxtCustomerAddress.Enabled = True
                TxtCustomerContactNum.Enabled = True
            End If

            'Load Selected Customer Details Details
            Dim CustomerName As String
            CustomerName = CmbCustomerName.Text
            Dim lstCustomerDetails As String()
            ReDim lstCustomerDetails(4)

            Dim CustomerObj As New CustomersManager(CustomersDatabaseHandler)
            lstCustomerDetails = CustomerObj.GetSelectedCustomerDetails(CustomerName)

            TxtCustomerName.Text = lstCustomerDetails(0)
            TxtCustomerEmail.Text = lstCustomerDetails(1)
            TxtCustomerAddress.Text = lstCustomerDetails(2)
            TxtCustomerContactNum.Text = lstCustomerDetails(3)

        Catch ex As Exception
            MessageBox.Show("An Unexpected Error Occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
End Class


Public Class InvalidCustomerNameException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
Public Class InvalidCustomerEmailException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
Public Class InvalidCustomerAddressException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
Public Class InvalidCustomerContactNumberException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class