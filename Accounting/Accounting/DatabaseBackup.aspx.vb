Imports System.Data
Imports System.Data.SqlClient
Imports System.Threading
Imports CreditManager
Imports ErrorLogging

Partial Class Accounting_DatabaseBackup
    Inherits System.Web.UI.Page

    Protected Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Dim builder As New System.Data.Common.DbConnectionStringBuilder()

                builder.ConnectionString = ConfigurationManager.ConnectionStrings("Constring").ConnectionString

                Dim server As String = TryCast(builder("Data Source"), String)
                Dim database As String = TryCast(builder("Initial Catalog"), String)

                Dim dbname As String = database & "" & Today.ToLongDateString & ".bak"
                Dim strPath As String = MapPath("~/Backup/")
                Dim s As String = Nothing
                s = strPath & txtFileName.Text & ".bak"
                Dim query As String = "Backup database " & database & " to disk='" & s & "'"
                Using cmd = New SqlCommand(query, con)
                    con.Open()
                    If cmd.ExecuteNonQuery() Then
                        notify("Backup Created successfully", "success")
                    Else
                        notify("Error creating backup", "error")
                    End If
                    con.Close()
                End Using
            End Using
        Catch e1 As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnBackup_Click()", e1.ToString)
        End Try
    End Sub

    Protected Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Dim builder As New System.Data.Common.DbConnectionStringBuilder()

                builder.ConnectionString = ConfigurationManager.ConnectionStrings("Constring").ConnectionString

                Dim server As String = TryCast(builder("Data Source"), String)
                Dim database As String = TryCast(builder("Initial Catalog"), String)

                Dim DbName As String = database ' initialise with your DB name
                'Dim result As DialogResult = openFileDialog1.ShowDialog()
                'If result = DialogResult.OK Then
                Dim query As String = "IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'" & DbName & "')ALTER DATABASE " & DbName & " SET SINGLE_USER WITH ROLLBACK IMMEDIATE DROP DATABASE " & DbName & " RESTORE DATABASE " & DbName & " FROM DISK = '" & filRestore.FileName & "'"
                Thread.Sleep(1000)
                Using cmd As New SqlCommand(query, con)
                    con.Open()
                    If cmd.ExecuteNonQuery() Then
                        notify("Database restored successfully", "success")
                    Else
                        notify("Error restoring database", "error")
                    End If
                    con.Close()
                    'End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnRestore_Click()", ex.ToString)

        End Try
    End Sub

End Class