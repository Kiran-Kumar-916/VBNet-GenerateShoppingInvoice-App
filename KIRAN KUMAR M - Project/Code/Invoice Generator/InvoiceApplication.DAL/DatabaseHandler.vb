Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Public Interface IDatabaseHandler
    Function InsertData(row As String()) As Boolean
    Function UpdateData(rowId As String, updatedRow As String()) As Boolean
    Function DeleteData(rowId As String) As Boolean
    Function ReadData() As DataTable
    Function GetAllRows() As DataTable
    Function GetListOfUniqueIdValues() As String()
    Function GetSelectedIdDetails(ByVal id As String) As String()
End Interface
Public Class CSVHandler
    Implements IDatabaseHandler

    Private _filePath As String
    Public Sub New(filePath As String)
        Me._filePath = filePath
    End Sub
    Public Function InsertData(row As String()) As Boolean Implements IDatabaseHandler.InsertData
        Try
            'Quote values that contain commas
            For i As Integer = 0 To row.Length - 1
                If row(i).Contains(",") Then
                    row(i) = """" & row(i) & """"
                End If
            Next

            Dim newRow As String = String.Join(",", row)

            Using writer As StreamWriter = File.AppendText(_filePath)
                writer.WriteLine(newRow)
            End Using

            Return True
       
        Catch ex As IOException
            ' Handle IO-related errors (e.g., file not found, access denied)
            Throw New ApplicationException("An I/O error occurred.", ex)
        Catch ex As UnauthorizedAccessException
            ' Handle unauthorized access errors (e.g., trying to access a protected file)
            Throw New ApplicationException("Access to the file is denied.", ex)
        Catch ex As FormatException
            ' Handle format errors (e.g., parsing errors)
            Throw New ApplicationException("Data format error.", ex)
        Catch ex As Exception
            ' Handle any other types of exceptions
            Throw New ApplicationException("An Unexpected Error Occurred While Attempting To Insert Data Into Database.", ex)
        End Try
    End Function
    Public Function UpdateData(rowId As String, updatedRow As String()) As Boolean Implements IDatabaseHandler.UpdateData
        Dim rows As List(Of String)
        Dim row As String()
        Try

            For i As Integer = 0 To updatedRow.Length - 1
                If updatedRow(i).Contains(",") Then
                    updatedRow(i) = """" & updatedRow(i) & """"
                End If
            Next

            rows = File.ReadAllLines(_filePath).ToList()
            Dim updatedLine As String = String.Join(",", updatedRow)


            For i As Integer = 0 To rows.Count - 1
                If i <> 0 Then
                    Using parser As New TextFieldParser(New StringReader(rows(i))) 'To Handle Comma in Values Case
                        parser.TextFieldType = FieldType.Delimited
                        parser.SetDelimiters(",")
                        parser.HasFieldsEnclosedInQuotes = True ' This handles values with commas
                        row = parser.ReadFields()

                        'Assuming the first column is the Unique ID
                        'Match and Update Details
                        If row(0) = rowId Then
                            rows(i) = updatedLine
                            Exit For
                        End If
                    End Using
                End If
            Next

            File.WriteAllLines(_filePath, rows)

            Return True

        Catch ex As IOException
            ' Handle IO-related errors (e.g., file not found, access denied)
            Throw New ApplicationException("An I/O error occurred.", ex)
        Catch ex As UnauthorizedAccessException
            ' Handle unauthorized access errors (e.g., trying to access a protected file)
            Throw New ApplicationException("Access to the file is denied.", ex)
        Catch ex As FormatException
            ' Handle format errors (e.g., parsing errors)
            Throw New ApplicationException("Data format error.", ex)
        Catch ex As Exception
            ' Handle any other types of exceptions
            Throw New ApplicationException("An Unexpected Error Occurred While Attempting To Update Data In Database.", ex)
        Finally
            rows = Nothing
            Erase row
        End Try
    End Function
    Public Function DeleteData(rowId As String) As Boolean Implements IDatabaseHandler.DeleteData
        Dim rows As List(Of String)
        Try
            rows = File.ReadAllLines(_filePath).ToList()

            rows = rows.Where(Function(line) line.Split(","c)(0) <> rowId).ToList()

            File.WriteAllLines(_filePath, rows)
            Return True

        Catch ex As IOException
            ' Handle IO-related errors (e.g., file not found, access denied)
            Throw New ApplicationException("An I/O error occurred.", ex)
        Catch ex As UnauthorizedAccessException
            ' Handle unauthorized access errors (e.g., trying to access a protected file)
            Throw New ApplicationException("Access to the file is denied.", ex)
        Catch ex As FormatException
            ' Handle format errors (e.g., parsing errors)
            Throw New ApplicationException("Data format error.", ex)
        Catch ex As Exception
            ' Handle any other types of exceptions
            Throw New ApplicationException("An Unexpected Error Occurred While Attempting To Delete Data From Database.", ex)
        Finally
            rows = Nothing
        End Try
    End Function
    Public Function ReadData() As DataTable Implements IDatabaseHandler.ReadData
        Dim dataTab As New DataTable()
        Dim row As String()

        Try
            Dim i As Byte

            If File.Exists(_filePath) Then
                Dim rows() As String = File.ReadAllLines(_filePath)
                Dim newDataRow As DataRow

                i = 0
                For Each line As String In rows
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

        Catch ex As IOException
            ' Handle IO-related errors (e.g., file not found, access denied)
            Throw New ApplicationException("An I/O error occurred.", ex)
        Catch ex As UnauthorizedAccessException
            ' Handle unauthorized access errors (e.g., trying to access a protected file)
            Throw New ApplicationException("Access to the file is denied.", ex)
        Catch ex As FormatException
            ' Handle format errors (e.g., parsing errors)
            Throw New ApplicationException("Data format error.", ex)
        Catch ex As Exception
            ' Handle any other types of exceptions
            Throw New ApplicationException("An Unexpected Error Occurred While Attempting To Read Data From Database.", ex)
        Finally
            dataTab = Nothing
            Erase row
        End Try
    End Function
    Public Function GetAllRows() As DataTable Implements IDatabaseHandler.GetAllRows
        Dim FillDataTable As New DataTable
        Try

            FillDataTable = ReadData()
            Return FillDataTable

        Catch ex As Exception
            Throw New ApplicationException("An Unexpected Error Occurred.", ex)
        Finally
            FillDataTable = Nothing
        End Try
    End Function
    Public Function GetListOfUniqueIdValues() As String() Implements IDatabaseHandler.GetListOfUniqueIdValues
        Dim AllRowsDataList As DataTable
        Dim ListOfUniqueIdValues As String()
        Try

            AllRowsDataList = GetAllRows()

            Dim i As Integer = 0
            For Each row As DataRow In AllRowsDataList.Rows()
                ReDim Preserve ListOfUniqueIdValues(i)
                ListOfUniqueIdValues(i) = row(0) 'Assuming UniqueID in first column
                i = i + 1
            Next

            Return ListOfUniqueIdValues

        Catch ex As Exception
            Throw New ApplicationException("An Unexpected Error Occurred.", ex)
        Finally
            AllRowsDataList = Nothing
            Erase ListOfUniqueIdValues
        End Try
    End Function
    Public Function GetSelectedIdDetails(ByVal id As String) As String() Implements IDatabaseHandler.GetSelectedIdDetails
        Dim AllRowsDataList As DataTable
        Dim lstSelectedRowDetails As String()
        Try

            AllRowsDataList = GetAllRows()

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
            Throw New ApplicationException("An Unexpected Error Occurred.", ex)
        Finally
            AllRowsDataList = Nothing
            Erase lstSelectedRowDetails
        End Try
    End Function
End Class
