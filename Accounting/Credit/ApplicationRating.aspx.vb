Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Partial Class Credit_ApplicationRating
    Inherits System.Web.UI.Page
    Dim adp As New SqlDataAdapter
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Public Shared Function convertToSaveFormat(ByVal dbl As String) As String
        If dbl.ToString.Contains(",") Then
            dbl = dbl.ToString.Replace(",", ".")
        End If
        Return dbl
    End Function

    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub btnSaveRating_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveRating.Click
        Dim loanID = txtLoanSearchID.Text
        'msgbox(loanID)
        Dim custID = txtCustSearchID.Text
        Dim clientType = lblClientType.Text
        doCalculation(loanID, custID, clientType)
        cmd = New SqlCommand("update APPLICATION_OVERALL_RATING set [RATED_BY]='" & Session("UserID") & "',[RATED_DATE]=getdate() where LOAN_ID='" & loanID & "'", con)
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        cmd.ExecuteNonQuery()
        CreditManager.notify("Rating successfully saved", "success")
        con.Close()
    End Sub

    Protected Sub btnSearchClientID_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchClientID.Click
        Try
            lblOverallRating.Text = ""
            cmd = New SqlCommand("select * from QUEST_APPLICATION where CUSTOMER_NUMBER='" & Trim(txtClientID.Text) & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "LOANS")
            If ds.Tables(0).Rows.Count > 0 Then
                lblClientName.Text = Trim(ds.Tables(0).Rows(0).Item("SURNAME").ToString & " " & ds.Tables(0).Rows(0).Item("FORENAMES").ToString)
                lblClientType.Text = ds.Tables(0).Rows(0).Item("CUSTOMER_TYPE").ToString
                lblLoanAmt.Text = Format(ds.Tables(0).Rows(0).Item("FIN_AMT"), "###,###")
                lblLoanType.Text = ds.Tables(0).Rows(0).Item("FIN_PURPOSE").ToString
                txtClientID.Text = ds.Tables(0).Rows(0).Item("CUSTOMER_NUMBER").ToString
                txtLoanID.Text = ds.Tables(0).Rows(0).Item("ID").ToString
                txtCustSearchID.Text = ds.Tables(0).Rows(0).Item("CUSTOMER_NUMBER").ToString
                txtLoanSearchID.Text = ds.Tables(0).Rows(0).Item("ID").ToString
                getCategories()
                lblOverallRatingText.Visible = True
            Else
                lblClientName.Text = ""
                lblClientType.Text = ""
                lblLoanAmt.Text = ""
                lblLoanType.Text = ""
                txtClientID.Text = ""
                txtLoanID.Text = ""
                txtCustSearchID.Text = ""
                txtLoanSearchID.Text = ""
                msgbox("Search record not found")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
            'msgbox("btnSearchClientID")
        End Try
    End Sub

    Protected Sub btnSearchLoanID_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchLoanID.Click
        Try
            lblOverallRating.Text = ""
            lblViewReport.Text = ""
            'cmd = New SqlCommand("select * from Z_LOAN_SUBMISSION_DETAILS where LOAN_REQID='" & Trim(txtLoanID.Text) & "'", con)
            cmd = New SqlCommand("select * from QUEST_APPLICATION where ID='" & Trim(txtLoanID.Text) & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "LOANS")
            If ds.Tables(0).Rows.Count > 0 Then
                lblClientName.Text = Trim(ds.Tables(0).Rows(0).Item("SURNAME").ToString & " " & ds.Tables(0).Rows(0).Item("FORENAMES").ToString)
                lblClientType.Text = ds.Tables(0).Rows(0).Item("CUSTOMER_TYPE").ToString
                lblLoanAmt.Text = Format(ds.Tables(0).Rows(0).Item("FIN_AMT"), "###,###")
                lblLoanType.Text = ds.Tables(0).Rows(0).Item("FIN_PURPOSE").ToString
                txtClientID.Text = ds.Tables(0).Rows(0).Item("CUSTOMER_NUMBER").ToString
                txtLoanID.Text = ds.Tables(0).Rows(0).Item("ID").ToString
                txtCustSearchID.Text = ds.Tables(0).Rows(0).Item("CUSTOMER_NUMBER").ToString
                txtLoanSearchID.Text = ds.Tables(0).Rows(0).Item("ID").ToString
                getCategories()
                lblOverallRatingText.Visible = True

                lblViewReport.Text = "<a href='rptRatingStatement.aspx?LOANID=" & txtLoanID.Text & "' target='new'>View Report</a>"
            Else
                lblClientName.Text = ""
                lblClientType.Text = ""
                lblLoanAmt.Text = ""
                lblLoanType.Text = ""
                txtClientID.Text = ""
                txtLoanID.Text = ""
                txtCustSearchID.Text = ""
                txtLoanSearchID.Text = ""
                CreditManager.notify("Search record not found", "error")
            End If
            'btnSaveRating.Visible = True

        Catch ex As Exception
            msgbox(ex.Message)
            'msgbox("btnSearchLoanID_Click")
        End Try
    End Sub

    Protected Sub calculateCategoryRating(ByVal loanID As Double, ByVal catID As Integer, ByVal category As RepeaterItem)
        Try
            cmd = New SqlCommand("select * from APPLICATION_RATING where LOANID='" & loanID & "' and QUESTION_CATEGORY_ID='" & catID & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APPLICATION_RATING")

            Dim actualRate As Double = 0
            Dim maxRate As Double = 0
            Dim cmd1 = New SqlCommand("select max(isnull(CALC_VALUE,0)) from PARA_RATING_VALUES", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            maxRate = CInt(cmd1.ExecuteScalar)
            con.Close()
            If ds.Tables(0).Rows.Count > 0 Then
                ''calculate
                Dim recordCount = 0
                For Each row As DataRow In ds.Tables(0).Rows
                    recordCount = recordCount + 1
                    actualRate = actualRate + CInt(row.Item("RATING"))
                Next
                maxRate = maxRate * recordCount
                Dim avgRating As Double = Math.Round(actualRate / maxRate * 100, 2)
                Dim newRating As String = ""
                Dim lblActRating = DirectCast(category.FindControl("lblActRating"), Label)

                'avgRating = avgRating.ToString.Replace(",", ".")
                newRating = avgRating '.ToString.Replace(",", ".")

                txtCategoryRating.Text = newRating

                'lblActRating.Text = avgRating & " %"
                lblActRating.Text = newRating & " %"

                If CDbl(avgRating) < 50 Then
                    lblActRating.ForeColor = Drawing.Color.Red
                Else
                    lblActRating.ForeColor = Drawing.Color.Green
                End If
                ''add ratings to database (APPLICATION_CATEGORY_RATING)
                'msgbox(ClientID)
                cmd = New SqlCommand("select * from APPLICATION_CATEGORY_RATING where [LOAN_ID]='" & CDbl(loanID) & "' and [CATEGORY_ID]='" & CDbl(catID) & "'", con)
                Dim dsCat As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsCat, "CATEGORY")
                'msgbox(catID)
                If dsCat.Tables(0).Rows.Count > 0 Then
                    ''rating already present, update
                    cmd = New SqlCommand("update APPLICATION_CATEGORY_RATING set [AVERAGE_RATING]= '" & convertToSaveFormat(newRating) & "' where [ID]='" & CDbl(dsCat.Tables(0).Rows(0).Item("ID")) & "'", con)
                Else
                    ''new rating, insert
                    cmd = New SqlCommand("insert into APPLICATION_CATEGORY_RATING ([LOAN_ID],[CLIENT_ID],[CATEGORY_ID],[AVERAGE_RATING]) values ('" & loanID & "','" & txtCustSearchID.Text & "','" & catID & "','" & convertToSaveFormat(newRating) & "')", con)
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                'msgbox(cmd.CommandText)
                cmd.ExecuteNonQuery()
                con.Close()
            Else
                ''update label:- "No rating entered for category"
            End If
            'msgbox("out of category")
        Catch ex As Exception
            msgbox(ex.Message)
            'msgbox("calculateCategoryRating")
        End Try
    End Sub

    Protected Sub calculateOverallRating(ByVal loanID As Double)
        Try
            loanID = CDbl(loanID)
            cmd = New SqlCommand("select * from APPLICATION_CATEGORY_RATING where LOAN_ID='" & loanID & "'", con)
            Dim ds As New DataSet
            'msgbox(cmd.CommandText)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "CATEGORY")
            Dim maxRating As Double = 0
            Dim actRating As Double = 0
            Dim overRating As Double = 0
            If ds.Tables(0).Rows.Count > 0 Then
                ''continue with rating calculation
                For Each row As DataRow In ds.Tables(0).Rows
                    maxRating = maxRating + 100
                    actRating = actRating + CDbl(row.Item("AVERAGE_RATING"))
                Next
                overRating = Math.Round(actRating / maxRating * 100, 2)
                cmd = New SqlCommand("select * from APPLICATION_OVERALL_RATING where LOAN_ID='" & loanID & "'", con)
                Dim dsOverall As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsOverall, "OVERALL")
                If dsOverall.Tables(0).Rows.Count > 0 Then
                    ''just update the rate
                    'cmd = New SqlCommand("update APPLICATION_OVERALL_RATING set [AVERAGE_RATING]='" & convertToSaveFormat(overRating) & "',[RATED_BY]='" & Session("UserID") & "',[RATED_DATE]='" & DateFormat.getSaveDateTime(Date.Now) & "' where LOAN_ID='" & loanID & "'", con)
                    cmd = New SqlCommand("update APPLICATION_OVERALL_RATING set [AVERAGE_RATING]='" & convertToSaveFormat(overRating) & "' where LOAN_ID='" & loanID & "'", con)
                Else
                    cmd = New SqlCommand("insert into APPLICATION_OVERALL_RATING ([LOAN_ID],[CLIENT_ID],[AVERAGE_RATING],[RATED_BY],[RATED_DATE]) values ('" & loanID & "','" & ds.Tables(0).Rows(0).Item("CLIENT_ID") & "','" & convertToSaveFormat(overRating) & "','" & Session("UserID") & "',GETDATE())", con)
                End If

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                'Dim lblOverallRating = DirectCast(rptCategories.FooterTemplate.FindControl("lblOverallRating"), Label)
                lblOverallRating.Text = overRating & " %"
                If overRating < 50 Then
                    lblOverallRating.ForeColor = Drawing.Color.Red
                    lblOverallRatingText.ForeColor = Drawing.Color.Red
                    lblWhoRated.ForeColor = Drawing.Color.Red
                Else
                    lblOverallRating.ForeColor = Drawing.Color.Green
                    lblOverallRatingText.ForeColor = Drawing.Color.Green
                    lblWhoRated.ForeColor = Drawing.Color.Green
                End If
                getSystemDecision(overRating)
            Else
                ''no rating to calculate
            End If
        Catch ex As Exception
            msgbox(ex.Message)
            'msgbox("calculateOverallRating")
        End Try
    End Sub

    Protected Sub decisionColours(ratioInd As HtmlGenericControl, currVal As Double)
        If currVal > 0 Then
            ratioInd.Attributes.Add("class", "alert-success")
        ElseIf currVal < 0 Then
            ratioInd.Attributes.Add("class", "alert-danger")
        Else
            ratioInd.Attributes.Add("class", "alert-warning")
        End If
    End Sub

    Protected Sub doCalculation(ByVal loanID As Double, ByVal custID As String, ByVal clientType As String)
        For Each category As RepeaterItem In rptCategories.Items
            Dim catID = DirectCast(category.FindControl("lblCatID"), Label).Text
            Dim cat = DirectCast(category.FindControl("lblCategory"), Label).Text
            Dim rptQuestions = DirectCast(category.FindControl("rptQuestions"), Repeater)
            For Each question As RepeaterItem In rptQuestions.Items
                Dim questID = DirectCast(question.FindControl("lblQuestionID"), Label).Text
                Dim quest = DirectCast(question.FindControl("lblQuestions"), Label).Text
                Dim rating As Integer
                Dim comment As String = ""
                ''set rating to -1000; to track if radiobutton is checked
                rating = -1000
                Try
                    rating = DirectCast(question.FindControl("rdbQuestionRating"), RadioButtonList).SelectedValue
                    comment = DirectCast(question.FindControl("rdbQuestionRating"), RadioButtonList).SelectedItem.ToString
                Catch ex As Exception

                End Try
                If rating <> -1000 Then
                    cmd = New SqlCommand("select * from APPLICATION_RATING where [CUSTID]='" & custID & "' and [LOANID]='" & loanID & "' and [RATE_QUESTION_ID]='" & questID & "'", con)
                    Dim ds As New DataSet
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "APPLICATION_RATING")
                    If ds.Tables(0).Rows.Count > 0 Then
                        cmd = New SqlCommand("update APPLICATION_RATING set [CUSTID]='" & custID & "',[CATEGORY]='" & cat & "',[QUESTION]='" & quest & "',[COMMENT]='" & BankString.removeSpecialCharacter(comment) & "',[LOANID]='" & loanID & "',[QUESTION_CATEGORY_ID]='" & catID & "',[RATE_QUESTION_ID]='" & questID & "',[RATING]='" & rating & "',[CLIENT_TYPE]='" & clientType & "' where [CUSTID]='" & ds.Tables(0).Rows(0).Item("CUSTID") & "' and [LOANID]='" & ds.Tables(0).Rows(0).Item("LOANID") & "' and [RATE_QUESTION_ID]='" & ds.Tables(0).Rows(0).Item("RATE_QUESTION_ID") & "'", con)
                    Else
                        cmd = New SqlCommand("insert into APPLICATION_RATING([CUSTID],[LOANID],[QUESTION_CATEGORY_ID],[RATE_QUESTION_ID],[RATING],[CLIENT_TYPE],[CATEGORY],[QUESTION],[COMMENT]) values ('" & custID & "','" & loanID & "','" & catID & "','" & questID & "','" & rating & "','" & clientType & "','" & cat & "','" & quest & "','" & BankString.removeSpecialCharacter(comment) & "')", con)
                    End If
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
            Next
            ''calculate category rating
            'msgbox(loanID & " " & catID)
            calculateCategoryRating(CInt(loanID), CInt(catID), category)
        Next
        ''calculate overall rating
        calculateOverallRating(CDbl(loanID))
        getWhoRated(txtClientID.Text, txtLoanID.Text)
    End Sub

    Protected Sub getCategories()
        Try
            cmd = New SqlCommand("select * from PARA_RATING_CATEGORIES where CLIENT_TYPE='" & lblClientType.Text & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "CATEGORIES")
            If ds.Tables(0).Rows.Count > 0 Then
                btnSaveRating.Visible = True
                rptCategories.DataSource = ds.Tables(0)
            Else
                rptCategories.DataSource = Nothing
            End If
            rptCategories.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
            'msgbox("getCategories")
        End Try
    End Sub

    Protected Function getQuestions(ByVal catID As Double) As DataTable
        Try
            cmd = New SqlCommand("select * from PARA_RATING_QUESTIONS where CATEGORY_ID='" & catID & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "QUESTIONS")
            If ds.Tables(0).Rows.Count > 0 Then
                Return ds.Tables(0)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            msgbox(ex.Message)
            'msgbox("getQuestions")
        End Try
    End Function

    Protected Sub getSystemDecision(rating As String)
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd As New SqlCommand("select " & rating & " as rating, * from  rating_sheet where lower_range<=" & rating & " and upper_range>" & rating & " and [entity_id]=2", con)
                Dim ds As New DataSet
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "dec")
                repSystemDecision.DataSource = ds.Tables(0)
                repSystemDecision.DataBind()
            End Using
        End Using
    End Sub

    Protected Sub getWhoRated(ByVal custNo As String, ByVal loanID As String)
        Try
            cmd = New SqlCommand("select *,convert(varchar,RATED_DATE,113) as RATED_DATE1 from application_overall_rating where CLIENT_ID='" & custNo & "' and LOAN_ID='" & loanID & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "OVRL")
            If ds.Tables(0).Rows.Count > 0 Then
                lblWhoRated.Text = "Rated by " & ds.Tables(0).Rows(0).Item("RATED_BY") & " on " & ds.Tables(0).Rows(0).Item("RATED_DATE1")
            Else
                lblWhoRated.Text = ""
            End If
        Catch ex As Exception
            msgbox(ex.Message)
            'msgbox("getWhoRated")
        End Try
    End Sub

    Protected Sub loadLoanRatings(ByVal loanID As Double)
        Try
            cmd = New SqlCommand("select * from APPLICATION_RATING where LOAN_ID='" & loanID & "'", con)

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub loadRadioButton(ByVal rdbX As RadioButtonList, ByVal questID As Double)
        Try
            rdbX = DirectCast(rdbX, RadioButtonList)
            cmd = New SqlCommand("select * from PARA_RATING_VALUES where QUESTION_ID='" & questID & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "PRV")
            If ds.Tables(0).Rows.Count > 0 Then
                rdbX.DataSource = ds.Tables(0)
                rdbX.DataValueField = "CALC_VALUE"
                rdbX.DataTextField = "COMMENT"
            Else
                rdbX.DataSource = Nothing
            End If
            rdbX.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
            'msgbox("loadRadioButton")
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)

            If Not IsPostBack Then
                Try
                    Dim loanID = Request.QueryString("loanID")
                    If loanID <> "" Then
                        txtLoanSearchID.Text = loanID
                        txtLoanID.Text = loanID
                        btnSearchLoanID_Click(sender, New System.EventArgs())
                        lblReturn.Text = "<a href='ApplicationApproval.aspx?id=" & loanID & "'>Return to Loan Approval</a>"
                    Else
                        lblReturn.Text = ""
                    End If
                Catch ex As Exception
                    lblReturn.Text = ""
                End Try
            End If
        Catch ex As Exception
            msgbox(ex.Message)
            'msgbox("pageload")
        End Try
    End Sub
    Protected Sub repSystemDecision_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles repSystemDecision.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim decRow = TryCast(e.Item.FindControl("decRow"), HtmlGenericControl)
            Dim rating = Replace(lblOverallRating.Text, "%", "")
            'Dim lblScale = TryCast(e.Item.FindControl("lblScale"), Label)
            If Not IsNumeric(rating) Or Trim(rating) = "" Then
            Else
                decisionColours(decRow, rating)
            End If
        End If
    End Sub

    Protected Sub rptCategories_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptCategories.ItemDataBound
        If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
            Dim lblCatID As Label = DirectCast(e.Item.FindControl("lblCatID"), Label)
            Dim childRepeater As Repeater = DirectCast(e.Item.FindControl("rptQuestions"), Repeater)
            Dim rdbList As RadioButtonList = DirectCast(childRepeater.FindControl("rdbQuestionRating"), RadioButtonList)
            Dim dt As New DataTable
            dt = Nothing
            dt = getQuestions(CDbl(lblCatID.Text))
            If dt.Rows.Count > 0 Then
                childRepeater.DataSource = dt
            Else
                childRepeater.DataSource = Nothing
            End If
            'msgbox(lblCatID.Text)
            childRepeater.DataBind()

        End If
    End Sub

    Protected Sub rptQuestions_ItemDatabound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs)
        If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
            Dim rdbList As RadioButtonList = DirectCast(e.Item.FindControl("rdbQuestionRating"), RadioButtonList)
            Dim lblQuestID As Label = DirectCast(e.Item.FindControl("lblQuestionID"), Label)
            Dim loanID = txtLoanSearchID.Text
            loadRadioButton(rdbList, lblQuestID.Text)
            'If rdbList.Text <> "" Then

            cmd = New SqlCommand("select RATING from APPLICATION_RATING where RATE_QUESTION_ID='" & lblQuestID.Text & "' and LOANID='" & loanID & "'", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            Dim rating = cmd.ExecuteScalar
            con.Close()
            Try
                rdbList.Items.FindByValue(rating).Selected = True
            Catch ex As Exception
                rdbList.ClearSelection()
            End Try
            doCalculation(loanID, txtCustSearchID.Text, lblClientType.Text)
        End If
    End Sub
End Class