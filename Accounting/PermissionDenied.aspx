<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PermissionDenied.aspx.vb" Inherits="PermissionDenied" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Permission Denied</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="fonts/css/font-awesome.min.css" rel="stylesheet" />
    <link rel="shortcut icon" href="~/favicon.ico" />
    <style>
        .col-center-block {
            float: none;
            display: block;
            margin-left: auto;
            margin-right: auto;
        }

        html,
        body,
        .container {
            height: 100%;
            width: 100%;
            background-color: #b51010;
        }

        .container {
            display: table;
            vertical-align: middle;
            padding-top: 5%;
        }

        .vertical-center-row {
            display: table-cell;
            vertical-align: middle;
        }

        .login-screen-bg {
            background-color: #EFEFEF;
        }

        .panel-git {
            border: 1px solid #d8dee2;
        }

            .panel-git h3 {
                color: #fff;
            }

            .panel-git .panel-heading {
                background-color: #829AA8;
            }

        .login-widget {
            padding: 50px;
            border-radius: 5px;
            padding: 30px;
            box-shadow: 0px 0px 1px 1px rgba(161, 159, 159, 0.8);
            background-color: #f35550;
            /*width: 50%;*/
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row vertical-center-row">
                <div class="col-md-4 col-center-block login-widget text-center">
                    <h2>LOST?</h2>
                    <small>It looks like you do not have permission to access this page.</small>

                    <div class="row">
                        <a href="index.aspx"><i class="fa fa-home fa-3x"></i></a>
                        <%--<a href="index.aspx"><i class="glyphicon glyphicon-home"></i></a>--%>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>