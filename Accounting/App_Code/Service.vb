Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web.Script.Services

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class Service
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

    <WebMethod> _
        <ScriptMethod(ResponseFormat:=ResponseFormat.Json)> _
    Public Function GetApplicants(prefix As String) As String()
        Dim customers As New List(Of String)()
        Using conn As New SqlConnection()
            conn.ConnectionString = ConfigurationManager.ConnectionStrings("Constring").ConnectionString
            Using cmd As New SqlCommand()
                cmd.CommandText = "select CUSTOMER_NUMBER,SURNAME+' '+FORENAMES+' '+IDNO+' '+ADDRESS as display from CUSTOMER_DETAILS where SURNAME like @SearchText +'%'"
                cmd.Parameters.AddWithValue("@SearchText", prefix)
                cmd.Connection = conn
                conn.Open()
                Using sdr As SqlDataReader = cmd.ExecuteReader()
                    While sdr.Read()
                        customers.Add(String.Format("{0}--{1}", sdr("display"), sdr("CUSTOMER_NUMBER")))
                    End While
                End Using
                conn.Close()
            End Using
            Return customers.ToArray()
        End Using
    End Function

End Class