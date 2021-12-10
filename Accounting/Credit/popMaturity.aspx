<%@ Page Language="VB" AutoEventWireup="false" CodeFile="popMaturity.aspx.vb" Inherits="Credit_popMaturity" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.9.1.js"></script>
    <script src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script>
      $(function () {
          $("#from").datepicker({
              defaultDate: "+1w",
              dateFormat: 'd MM yy',
              changeMonth: true,
              numberOfMonths: 3,
              onClose: function (selectedDate) {
                  $("#to").datepicker("option", "minDate", selectedDate);
              }
          });
          $("#to").datepicker({
              defaultDate: "+1w",
              dateFormat: 'd MM yy',
              changeMonth: true,
              numberOfMonths: 3,
              onClose: function (selectedDate) {
                  $("#from").datepicker("option", "maxDate", selectedDate);
              }
          });
      });
      $("#ui-datepicker-div").css("z-index", "9999");
    </script>
    <style>
        div.ui-datepicker {
            font-size: 8px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label for="from">From</label>
            <input type="text" id="from" name="from" />
            <label for="to">to</label>
            <input type="text" id="to" name="to" />
        </div>
        <div style="display: inline;">
            <input type="button" value="Print" />
        </div>
    </form>
</body>
</html>