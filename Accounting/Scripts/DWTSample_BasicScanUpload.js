function DW_AcquireImage() {
    DWObject.SelectSource();
    DWObject.CloseSource();
    DWObject.OpenSource();
    DWObject.IfShowUI = false;
    DWObject.PixelType = 1;
    DWObject.Resolution = 100;
    DWObject.IfFeederEnabled = true;
    DWObject.IfDisableSourceAfterAcquire = true;
    DWObject.AcquireImage();
}

//--------------------------------------------------------------------------------------
//************************** Upload Image***********************************
//--------------------------------------------------------------------------------------
function btnUpload_onclick() {
    if (DWObject.HowManyImagesInBuffer == 0) {
        return;
    }
    var DW_ActionPage = "SaveToFile.aspx";
    var strHTTPServer, strActionPage, strImageType;
    var CurrentPathName = unescape(location.pathname); // get current PathName in plain ASCII	
    var CurrentPath = CurrentPathName.substring(0, CurrentPathName.lastIndexOf("/") + 1);
    strActionPage = CurrentPath + DW_ActionPage; //  DW_ActionPage; //the ActionPage's file path

    strHTTPServer = location.hostname; //Demo: "www.dynamsoft.com";
    DWObject.HTTPPort = location.port == "" ? 80 : location.port; //Demo: 80;
    var uploadfilename = "uploadPdf.pdf";
    DWObject.HTTPUploadAllThroughPostAsPDF(
        strHTTPServer,
        strActionPage,
        uploadfilename
    );
    if (DWObject.ErrorCode != 0) {
        alert(DWObject.ErrorString);
    }
}
//******************Instructions*******************//
function InitInfo() {
    var MessageBody = document.getElementById("divInfo");
    if (MessageBody) {
////        var ObjString = "<div>";
////        ObjString += "You can see the button 'Scan' & 'Upload' above!<br />";
////        ObjString += "<br />";
////        ObjString += "If you have a scanner available, you can click 'Scan' to scan a document!<br />";
////        ObjString += "<br />";
////        ObjString += "Then you can click 'Upload' to upload this document as a PDF file.<br />";
////        ObjString += "<br />";
////        ObjString += "Now you can check the JavaScript behind this page to see how this is done!";
////        ObjString += "<br />";
////        ObjString += "Please NOTE that you should deploy the sample in IIS or other web service that supports C#";
////        ObjString += "<br />";
////        ObjString += "<br />";
////        ObjString += "<a href='SampleSource/DWTSample_BasicScanUpload.zip' alt = 'DWTSample_BasicScanUpload Sample'>Download Sample Source</a><br />";        
////        ObjString += "<br />";
////        ObjString += "Any questions? <a target='blank' href='mailto:support@dynamsoft.com'>Let us know</a> !!";
////        ObjString += "<br />";
////        ObjString += "</div>";
//        MessageBody.innerHTML = ObjString;
    }
}
