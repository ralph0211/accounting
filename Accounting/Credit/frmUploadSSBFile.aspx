<%@ Page Title="Upload Credit Management SSB File" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="frmUploadSSBFile.aspx.vb" Inherits="Credt_uploadSSBFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        .panel-heading{
            text-align: left;
            font-weight:bold;
        }
        .control-label{
            text-align: left;
            font-weight:bold;
        }

        .panel-body{
            background-color:#eeeeee;
        }
        .row{
            margin-bottom:4px;
        }
    </style>
     <script type="text/javascript">
         function isDelete() {
             return confirm("Are you sure you want to delete this record?");
         }
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="">
        <div class="panel panel-primary">
            <div class="panel-heading">
               Upload Credit Management SSB File</div>
            <div class="panel-body">
                                
                <div class="row">
                    
                    <div class="col-xs-3">
                                  <table>
                                      <tr>
                                          <td>
                                              &nbsp;</td>
                                          <td>
 <asp:Label ID="Label116" runat="server" Text="Select File To Upload" Font-Bold="True"></asp:Label>   
 <asp:FileUpload ID="FileUpload1" runat="server" Width="403px" />
                                          </td>
                                      </tr>

                                  </table>                       
                       
                                                         
                    </div><div class="row">  
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Width="250px">
                            <asp:ListItem>SSB Error</asp:ListItem>
                            <asp:ListItem>SSB Approved</asp:ListItem>
                        </asp:RadioButtonList>
                        </div>
                    </div>
                    
                 <div class="row">
                        <div class="row">
                        </div>
                        <div class="row">
                        </div>
                        <div class="col-xs-12 center-block">
                            <asp:Button ID="btnAddAgent" runat="server" Text="Process SSB File" CssClass="btn btn-primary" />
                        </div>
                    </div>
                <div class="row">
                        <div class="row">
                        </div>
                        <div class="row">
                        </div>
                        <div class="col-xs-12 center-block">
                        </div>
                                            <hr size="1" style="color: #7C8D59" width="95%" />
                    </div>

            </div>
            </div> 
     
          
        </div>

</asp:Content>

