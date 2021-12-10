Imports System
Imports System.Text
Imports System.Collections
Imports System.Web.Security
Imports System.Security.Principal
Imports System.DirectoryServices
Imports System.Data

Namespace FormsAuth
    Public Class LdapAuthentication
        Private _path As String
        Private _filterAttribute As String

        Public Sub New(ByVal path As String)
            _path = path
        End Sub

        Public Function IsAuthenticated(ByVal domain As String, ByVal username As String, ByVal pwd As String) As Boolean
            Dim domainAndUsername As String = domain & "\" & username
            Dim entry As New DirectoryEntry(_path, domainAndUsername, pwd)

            Try
                'Bind to the native AdsObject to force authentication.
                Dim obj As Object = entry.NativeObject

                Dim search As New DirectorySearcher(entry)

                search.Filter = "(SAMAccountName=" & username & ")"
                search.PropertiesToLoad.Add("cn")
                Dim result As SearchResult = search.FindOne()

                If Nothing Is result Then
                    Return False
                End If

                'Update the new path to the user in the directory.
                _path = result.Path
                _filterAttribute = CStr(result.Properties("cn")(0))
            Catch ex As Exception
                Throw New Exception("Error authenticating user. " & ex.Message)
            End Try

            Return True
        End Function

        Public Function GetGroups() As String
            Dim searchRoot As New DirectoryEntry(_path)
            Dim search As New DirectorySearcher(searchRoot)
            'Dim search As New DirectorySearcher(_path)
            search.Filter = "(cn=" & _filterAttribute & ")"
            search.PropertiesToLoad.Add("memberOf")
            Dim groupNames As New StringBuilder()

            Try
                Dim result As SearchResult = search.FindOne()
                Dim propertyCount As Integer = result.Properties("memberOf").Count
                Dim dn As String
                Dim equalsIndex, commaIndex As Integer

                For propertyCounter As Integer = 0 To propertyCount - 1
                    dn = CStr(result.Properties("memberOf")(propertyCounter))
                    equalsIndex = dn.IndexOf("=", 1)
                    commaIndex = dn.IndexOf(",", 1)
                    If -1 = equalsIndex Then
                        Return Nothing
                    End If
                    groupNames.Append(dn.Substring((equalsIndex + 1), (commaIndex - equalsIndex) - 1))
                    groupNames.Append("|")
                Next propertyCounter
            Catch ex As Exception
                Throw New Exception("Error obtaining group names. " & ex.Message)
            End Try
            Return groupNames.ToString()
        End Function

        Public Function isValidUser(ByVal userID As String) As Boolean
            Try
                Dim searchRoot As New DirectoryEntry(_path)
                Dim dssearch As DirectorySearcher = New DirectorySearcher(searchRoot)
                dssearch.Filter = "(sAMAccountName=" + userID + ")"
                Dim sresult As SearchResult = dssearch.FindOne()
                'If dssearch.FindAll.Count > 0 Then
                If Not sresult Is Nothing Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                'MsgBox(ex.Message)
            End Try
        End Function

        Public Function getAllUsers() As DataTable
            Try
                Dim searchRoot As New DirectoryEntry(_path)
                Dim dssearch As DirectorySearcher = New DirectorySearcher(searchRoot)
                'dssearch.Filter = "(sAMAccountName=" + userID + ")"
                Dim ds As New DataSet

                'Dim sresult As SearchResult = dssearch.FindOne()
                Dim sresult As SearchResultCollection = dssearch.FindAll
                If sresult.Count > 0 Then
                    For Each res As SearchResult In sresult
                        ds.Tables(0).Rows.Add(res)
                    Next
                    Return ds.Tables(0)
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                'MsgBox(ex.Message)
            End Try
        End Function
    End Class
End Namespace