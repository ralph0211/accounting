<%@ Page Language="VB" AutoEventWireup="false" CodeFile="OTPConfirm.aspx.vb" Inherits="OTPConfirm" %>

<!doctype html>
<html xmlns="http://www.w3.org/1999/xhtml" xmlns:v="urn:schemas-microsoft-com:vml" xmlns:o="urn:schemas-microsoft-com:office:office">
   <head>
      <title>Identity Verification</title>
      <meta http-equiv="X-UA-Compatible" content="IE=edge">
      <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
      <style type="text/css">
         #outlook a { padding: 0; }
         .ReadMsgBody { width: 100%; }
         .ExternalClass { width: 100%; }
         .ExternalClass * { line-height:100%; }
         body { margin: 0; padding: 0; -webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; }
         table, td { border-collapse:collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; }
         img { border: 0; height: auto; line-height: 100%; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; }
         p { display: block; margin: 13px 0; }
      </style>
      <style type="text/css">
         @media only screen and (max-width:480px) {
         @-ms-viewport { width:320px; }
         @viewport { width:320px; }
         }
      </style>
      <link href="https://fonts.googleapis.com/css?family=Open Sans" rel="stylesheet" type="text/css">
      <link href="https://fonts.googleapis.com/css?family=Ubuntu:300,400,500,700" rel="stylesheet" type="text/css">
      <style type="text/css">
         @import url(https://fonts.googleapis.com/css?family=Open Sans);
         @import url(https://fonts.googleapis.com/css?family=Ubuntu:300,400,500,700);
      </style>
      <style type="text/css">
         @media only screen and (min-width:480px) {
         .mj-column-per-100 { width:100%!important; }
         }
      </style>
   </head>
   <body style="background: #f5f6fa;">
                                 <form name ="form1" runat="server" >
      <div style="background-color:#f5f6fa;">
         <div style="margin:0px auto;max-width:600px;">
            <table role="presentation" cellpadding="0" cellspacing="0" style="font-size:0px;width:100%;" align="center" border="0">
               <tbody>
                  <tr>
                     <td style="text-align:center;vertical-align:top;direction:ltr;font-size:0px;padding:20px 0px;padding-bottom:20px;padding-top:30px;">
                        <div class="" style="cursor:auto;color:#000000;font-family:Ubuntu, Helvetica, Arial, sans-serif;font-size:13px;line-height:22px;text-align:center;">
                           <a href="#" class="ks-logo" style="font-size: 18px; text-decoration: none; color: #3a529b; font-weight: bold;"><img src="Images/escrow.png" width="50%"/></a>
                        </div>
                     </td>
                  </tr>
               </tbody>
            </table>
         </div>
         <div style="margin:0px auto;max-width:600px;background:#fff;">
            <table role="presentation" cellpadding="0" cellspacing="0" style="font-size:0px;width:100%;background:#fff;" align="center" border="0">
               <tbody>
                  <tr>
                     <td style="text-align:center;vertical-align:top;direction:ltr;font-size:0px;padding:20px 0px;">
                        <div class="mj-column-per-100 outlook-group-fix" style="vertical-align:top;display:inline-block;direction:ltr;font-size:13px;text-align:left;width:100%;">
                           <table role="presentation" cellpadding="0" cellspacing="0" width="100%" border="0">
                              <tbody>
                                    <input type = "hidden" value="" name ="email" runat="server"/>
                                    <tr>
                                       <td style="word-break:break-word;font-size:0px;padding:10px 25px;padding-bottom:5px;" align="center">
                                          <div class="" style="cursor:auto;color:#333;font-family:Open Sans;font-size:30px;font-weight:bold;line-height:22px;text-align:center;">
                                             Login-Verify Your Identity
                                          </div>
                                       </td>
                                    </tr>
                                    <tr>
                                       <td style="word-break:break-word;font-size:0px;padding:10px 25px;padding-bottom:20px;" align="center">
                                          <div class="" style="cursor:auto;color:#333;font-family:Open Sans;font-size:18px;line-height:1.44;text-align:center;">
                                            One Time password(OTP) has been sent to your email / mobile number 
                                          </div>
                                       </td>
                                    </tr>                                 
                                    <tr>
                                       <td style="word-break:break-word;font-size:10px;padding:10px 25px;padding-bottom:20px;" align="center">
                                          <div class="" style="cursor:auto;color:#c50b12; font-style: italic;font-family:Open Sans;font-size:15px;line-height:1.44;text-align:center;">
                                            <asp:Label ID="lblFailed" runat="server" Text="Failed to verify (OTP) password" Visible="false"></asp:Label>
                                          </div>
                                       </td>
                                    </tr>
                                    <tr>
                                       <td style="word-break:break-word;font-size:0px;padding:10px 25px;padding-bottom:30px;" align="center">
                                          <table role="presentation" cellpadding="0" cellspacing="0" style="border-collapse:separate;" align="center" border="0">
                                             <tbody>
                                                <tr>
                                                   <td  align="center" valign="middle">
                                                       <input name="pass" placeholder="XXX-XXX" data-mask="XXX-XXX" data-mask-clearifnotmatch="true" runat="server" id="txtConfirm"
                                                           style="font-size: 30px; text-align: center; cursor: auto; padding: 12px 30px; border: solid 1px #c9c9c9; box-shadow: inset 0 0 0 1px #707070; transition: box-shadow 0.3s, border 0.3s;"
                                                           type="text"/>
                                                   </td>
                                                </tr>
                                             </tbody>
                                          </table>
                                       </td>
                                    </tr>                                
                                    <tr>
                                       <td style="word-break:break-word;font-size:10px;padding:10px 25px;padding-bottom:20px;" align="center">
                                          <div class="" style="cursor:auto;color:#c50b12; font-style: italic;font-family:Open Sans;font-size:15px;line-height:1.44;text-align:center;">
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="One Time Password is required" ControlToValidate="txtConfirm"></asp:RequiredFieldValidator>
                                          </div>
                                       </td>
                                    </tr>
                                    <tr>
                                       <td style="word-break:break-word;font-size:0px;padding:10px 25px;padding-bottom:30px;" align="center">
                                          <table role="presentation" cellpadding="0" cellspacing="0" style="border-collapse:separate;" align="center" border="0">
                                             <tbody>
                                                   <tr>
                                                      <td style="word-break:break-word;font-size:0px;padding:10px 25px;padding-bottom:30px;" align="left">
                                                         <table role="presentation" cellpadding="0" cellspacing="0" style="border-collapse:separate;" align="left" border="0">
                                                            <tbody>
                                                               <tr>
                                                                  <td style="" align="center" valign="middle" bgcolor="#fff">
                                                                      <asp:Button ID="btnConfirm" runat="server" Text="Confirm" style="border:2px solid #3a529b;border-radius:2px;color:#3a529b;cursor:auto;padding:12px 30px; text-decoration:none;line-height:100%;background:#fff;color:#3a529b;font-family:Ubuntu, Helvetica, Arial, sans-serif;font-size:14px;font-weight:500;text-transform:none;margin:0px;" />
                                                                  </td>
                                                               </tr>
                                                            </tbody>
                                                         </table>
                                                      </td>
                                                   </tr>
                                             </tbody>
                                          </table>
                                       </td>
                                    </tr>

                                 <tr>
                                    <td style="word-break:break-word;font-size:0px;padding:10px 25px;padding-bottom:10px;">
                                       <p style="font-size:1px;margin:0px auto;border-top:1px solid #e6e6e6;width:100%;"></p>
                                    </td>
                                 </tr>
                                 <tr>
                                    <td style="word-break:break-word;font-size:0px;padding:10px 25px;" align="left">
                                       <div class="" style="cursor:auto;color:#858585;font-family:Ubuntu, Helvetica, Arial, sans-serif;font-size:13px;line-height:22px;text-align:left;">
                                         If you do not get the message within the next 3 minutes please click <br> <a href="" class="ks-link" style="color: #22a7f0; text-decoration: none;">Request to send another OTP</a>
                                       </div>
                                    </td>
                                 </tr>
                              </tbody>
                           </table>
                        </div>
                     </td>
                  </tr>
               </tbody>
            </table>
         </div>
      </div>
<script type="text/javascript" src ="js/jquery-latest.min.js"></script>
<script type="text/javascript" src ="js/jquery.mask.min.js"></script>
                                 </form>

   </body>
    <script type="text/javascript">
        setTimeout(function () { alert("Your session has expired!"); window.location = 'Logout.aspx'; }, 60000 * 3);
        window.history.forward(1);
    </script>
</html>