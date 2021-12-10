Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Credit_Holidays
    Inherits System.Web.UI.Page
    Public Shared typeEditID As Double
    Dim urlPermission As String = "PermissionDenied.aspx"

    Protected Sub btnAddAnnual_Click(sender As Object, e As EventArgs) Handles btnAddAnnual.Click
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("ConString").ConnectionString)
                Using cmd As New SqlCommand("insert into ParaAnnualHolidays (Mmonth, Dday, HolidayName) values (@Mmonth,@Dday,@HolidayName)", con)
                    cmd.Parameters.AddWithValue("@Mmonth", cmbMonths.SelectedValue)
                    cmd.Parameters.AddWithValue("@Dday", cmbDay.SelectedValue)
                    cmd.Parameters.AddWithValue("@HolidayName", txtSpecialHolName.Text)
                    con.Open()
                    If cmd.ExecuteNonQuery Then
                        notify("Saved successfully", "success")
                        getAnnualHolidays()
                    Else
                        notify("Error saving holiday", "error")
                    End If
                    con.Close()
                    cmbMonths.ClearSelection()
                    cmbDay.ClearSelection()
                    txtSpecialHolName.Text = ""
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnAddAnnual_Click", ex.ToString)
        End Try
    End Sub

    Protected Sub btnSaveHoliday_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveHoliday.Click
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("insert into HOLIDAYS (HOLIDAY_DATE,HOLIDAY_DESC) values (@HolDate, @HolName)", con)
                    cmd.Parameters.AddWithValue("@HolDate", bdpHolDate.Text)
                    cmd.Parameters.AddWithValue("@HolName", txtHolName.Text)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    If cmd.ExecuteNonQuery Then
                        notify("Holiday Saved", "success")
                        getHolidays()
                        bdpHolDate.Text = ""
                        txtHolName.Text = ""
                    Else
                        notify("Error saving holiday", "error")
                    End If
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSaveHoliday_Click", ex.ToString)
        End Try
    End Sub

    Protected Sub btnSaveWorkingDays_Click(sender As Object, e As EventArgs) Handles btnSaveWorkingDays.Click
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("delete from ParaWorkingDays", con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
                For Each d As ListItem In chkWorkingDays.Items
                    If d.Selected = True Then
                        Using cmd = New SqlCommand("insert into ParaWorkingDays (DayValue,DayName) values (@DayValue, @DayName)", con)
                            cmd.Parameters.AddWithValue("@DayValue", d.Value)
                            cmd.Parameters.AddWithValue("@DayName", d.Text)
                            If con.State = ConnectionState.Open Then
                                con.Close()
                            End If
                            con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End Using
                    End If
                Next
                notify("Working days saved", "success")
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSaveWorkingDays_Click", ex.ToString)
        End Try
    End Sub

    Protected Sub cmbGrdMonthEdit_SelectedIndexChanged()
        Dim row As GridViewRow = grdAnnual.Rows(grdAnnual.EditIndex)
        Dim cmbGrdMonthEdit = DirectCast(row.FindControl("cmbGrdMonthEdit"), DropDownList)
        Dim cmbGrdDayEdit = DirectCast(row.FindControl("cmbGrdDayEdit"), DropDownList)
        Dim txtGrdDay As String = DirectCast(row.FindControl("txtGrdDay"), TextBox).Text
        loadDays(cmbGrdMonthEdit.SelectedValue, cmbGrdDayEdit)
        Try
            cmbGrdDayEdit.Items.FindByValue(txtGrdDay).Selected = True
        Catch ex As Exception
            cmbGrdDayEdit.ClearSelection()
        End Try
    End Sub

    Protected Sub cmbMonths_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMonths.SelectedIndexChanged
        loadDays(cmbMonths.SelectedValue, cmbDay)
    End Sub

    Protected Sub getAnnualHolidays()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select pah.*,mnt.MonthName from ParaAnnualHolidays pah join tbl_Months mnt on pah.MMonth=mnt.MonthValue", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "Holiday")
                    End Using
                    bindGrid(ds.Tables(0), grdAnnual)
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getAnnualHolidays", ex.ToString)
        End Try
    End Sub

    Protected Sub getHolidays()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select *,convert(varchar,HOLIDAY_DATE,106) as HOLIDAY_DATE1 from HOLIDAYS", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "Holiday")
                    End Using
                    bindGrid(ds.Tables(0), grdHolidays)
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getHolidays", ex.ToString)
        End Try
    End Sub
    Protected Sub grdAnnual_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles grdAnnual.RowCancelingEdit
        grdAnnual.EditIndex = -1
        getAnnualHolidays()
    End Sub

    Protected Sub grdAnnual_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdAnnual.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow AndAlso grdAnnual.EditIndex = e.Row.RowIndex Then
                Dim cmbGrdMonthEdit As DropDownList = DirectCast(e.Row.FindControl("cmbGrdMonthEdit"), DropDownList)
                Dim cmbGrdDayEdit As DropDownList = DirectCast(e.Row.FindControl("cmbGrdDayEdit"), DropDownList)
                Dim txtGrdMonthEdit As String = DirectCast(e.Row.FindControl("txtGrdMonthEdit"), TextBox).Text
                Dim txtGrdDay As String = DirectCast(e.Row.FindControl("txtGrdDay"), TextBox).Text
                loadMonths(cmbGrdMonthEdit)
                Try
                    cmbGrdMonthEdit.Items.FindByValue(txtGrdMonthEdit).Selected = True
                Catch ex As Exception
                    cmbGrdMonthEdit.ClearSelection()
                End Try
                loadDays(txtGrdMonthEdit, cmbGrdDayEdit)
                Try
                    cmbGrdDayEdit.Items.FindByValue(txtGrdDay).Selected = True
                Catch ex As Exception
                    cmbGrdDayEdit.ClearSelection()
                End Try
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdProductFees_RowDataBound", ex.ToString)
        End Try
    End Sub

    Protected Sub grdAnnual_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdAnnual.RowDeleting
        ViewState("AnnualID") = DirectCast(grdAnnual.Rows(e.RowIndex).FindControl("txtGrdMonthID"), TextBox).Text
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd = New SqlCommand("delete from ParaAnnualHolidays where ID='" & ViewState("AnnualID") & "'", con)
                con.Open()
                If cmd.ExecuteNonQuery Then
                    notify("Successfully deleted", "success")
                Else
                    notify("Error deleting", "error")
                End If
                con.Close()
                getAnnualHolidays()
            End Using
        End Using
    End Sub

    Protected Sub grdAnnual_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles grdAnnual.RowEditing
        ViewState("AnnualID") = DirectCast(grdAnnual.Rows(e.NewEditIndex).FindControl("txtGrdMonthID"), TextBox).Text
        'Dim cmbGrdMonthEdit = DirectCast(grdAnnual.Rows(e.NewEditIndex).FindControl("cmbGrdMonthEdit"), DropDownList)
        'Dim txtGrdMonthEdit = DirectCast(grdAnnual.Rows(e.NewEditIndex).FindControl("txtGrdMonthEdit"), TextBox)
        'msgbox(txtGrdMonthEdit.Text)
        'loadMonths(cmbGrdMonthEdit)
        'cmbGrdMonthEdit.SelectedValue = txtGrdMonthEdit.Text
        grdAnnual.EditIndex = e.NewEditIndex
        getAnnualHolidays()
    End Sub

    Protected Sub grdAnnual_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles grdAnnual.RowUpdating
        If Trim(ViewState("AnnualID")) = "" Or IsDBNull(ViewState("AnnualID")) Then
            notify("No record selected for update", "error")
            Exit Sub
        End If

        Dim mnth As String = DirectCast(grdAnnual.Rows(e.RowIndex).FindControl("cmbGrdMonthEdit"), DropDownList).SelectedValue
        Dim dday As String = DirectCast(grdAnnual.Rows(e.RowIndex).FindControl("cmbGrdDayEdit"), DropDownList).SelectedValue
        Dim HolidayName As String = DirectCast(grdAnnual.Rows(e.RowIndex).FindControl("txtGrdHolidayName"), TextBox).Text
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd = New SqlCommand("update ParaAnnualHolidays set DDay=@dday,MMonth=@mmonth,HolidayName=@HolidayName where ID='" & ViewState("AnnualID") & "'", con)
                cmd.Parameters.AddWithValue("@dday", dday)
                cmd.Parameters.AddWithValue("@mmonth", mnth)
                cmd.Parameters.AddWithValue("@HolidayName", HolidayName)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery Then
                    notify("Successfully updated", "success")
                Else
                    notify("Error updating value", "error")
                End If
                con.Close()
                grdAnnual.EditIndex = -1
                getAnnualHolidays()
            End Using
        End Using
    End Sub

    Protected Sub grdHolidays_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles grdHolidays.RowCancelingEdit
        grdHolidays.EditIndex = -1
        getHolidays()
    End Sub

    Protected Sub grdHolidays_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdHolidays.RowDeleting
        typeEditID = DirectCast(grdHolidays.Rows(e.RowIndex).FindControl("txtGrdMktID"), TextBox).Text
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd = New SqlCommand("delete from HOLIDAYS where ID='" & typeEditID & "'", con)
                con.Open()
                If cmd.ExecuteNonQuery Then
                    notify("Successfully deleted", "success")
                Else
                    notify("Error deleting", "error")
                End If
                con.Close()
                getHolidays()
            End Using
        End Using
    End Sub

    Protected Sub grdHolidays_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles grdHolidays.RowEditing
        typeEditID = DirectCast(grdHolidays.Rows(e.NewEditIndex).FindControl("txtGrdMktID"), TextBox).Text
        grdHolidays.EditIndex = e.NewEditIndex
        getHolidays()
    End Sub

    Protected Sub grdHolidays_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles grdHolidays.RowUpdating
        If Trim(typeEditID) = "" Or IsDBNull(typeEditID) Then
            notify("No record selected for update", "error")
            Exit Sub
        End If

        Dim newShortName As String = DirectCast(grdHolidays.Rows(e.RowIndex).FindControl("bdpEditDate"), TextBox).Text
        Dim newLongName As String = DirectCast(grdHolidays.Rows(e.RowIndex).FindControl("txtGrdMktNameEdit"), TextBox).Text
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd = New SqlCommand("update HOLIDAYS set HOLIDAY_DESC=@HolName,HOLIDAY_DATE=@HolDate where ID='" & typeEditID & "'", con)
                cmd.Parameters.AddWithValue("@HolName", newLongName)
                cmd.Parameters.AddWithValue("@HolDate", newShortName)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery Then
                    notify("Successfully updated", "success")
                Else
                    notify("Error updating value", "error")
                End If
                con.Close()
                grdHolidays.EditIndex = -1
                getHolidays()
            End Using
        End Using
    End Sub

    Protected Sub loadDays(mnth As String, cmb As DropDownList)
        Try
            Dim dt As New dsParameters.MonthsDataTable
            Dim dss As New dsParametersTableAdapters.MonthsTableAdapter
            dss.FillByValue(dt, mnth)
            Dim dtt As DataTable = dt
            cmb.Items.Clear()
            cmb.AppendDataBoundItems = True
            cmb.Items.Add("")
            For i As Integer = 1 To IIf((dtt.Rows(0).Item("MaxNoDays").ToString = "" Or IsDBNull(dtt.Rows(0).Item("MaxNoDays").ToString)), 0, dtt.Rows(0).Item("MaxNoDays")) Step 1
                cmb.Items.Add(i.ToString)
            Next
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadMonths", ex.ToString)
        End Try
    End Sub

    Protected Sub loadMonths(cmb As DropDownList)
        Try
            Dim dt As New dsParameters.MonthsDataTable
            Dim dss As New dsParametersTableAdapters.MonthsTableAdapter
            dss.Fill(dt)
            Dim dtt As DataTable
            dtt = dt
            loadCombo(dtt, cmb, "MonthName", "MonthValue")
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadMonths", ex.ToString)
        End Try
    End Sub
    Protected Sub loadWorkingDays()
        Try
            Dim dt As New dsParameters.ParaWorkingDaysDataTable
            Dim dss As New dsParametersTableAdapters.ParaWorkingDaysTableAdapter
            dss.Fill(dt)
            Dim dtt As DataTable = dt
            If dtt.Rows.Count > 0 Then
                For Each d In chkWorkingDays.Items
                    For Each row In dtt.Rows
                        If d.value = row("DayValue") Then
                            d.selected = True
                        End If
                    Next
                Next
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadMonths", ex.ToString)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            getHolidays()
            loadMonths(cmbMonths)
            getAnnualHolidays()
            loadWorkingDays()
        End If
    End Sub
End Class