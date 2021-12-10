Imports Microsoft.VisualBasic

Public Class BankString

    Public Shared Function removeSpecialCharacter(ByVal inputStr As String) As String
        If Trim(inputStr) = "" Then
            Return inputStr
        End If
        Return inputStr.Replace("'", "''")
    End Function

    Public Shared Function isNullString(ByVal inputStr As Object) As String
        If IsDBNull(inputStr) Then
            Return ""
        Else
            Return inputStr
        End If
    End Function

    Public Shared Function isNullNumber(ByVal inputNum As Object) As Double
        If IsDBNull(inputNum) Then
            Return 0
        Else
            If inputNum = "" Then
                Return 0
            Else
                Return inputNum
            End If
        End If
    End Function
End Class
