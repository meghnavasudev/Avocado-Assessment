<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MapCSV.aspx.cs" Inherits="Assessment.MapCSV" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>Map CSV File Data on a Grid</title>
        <meta name="viewport" content = "width = device-width, initial-scale = 1.0, minimum-scale = 1.0, maximum-scale = 1.0, user-scalable = no" />
    <link href="bootstrap.css" rel="stylesheet" />    
   
</head>
<body>
    <form id="form2" runat="server">
    <table style="width: 100%;">
         <tr><td colspan="2"><h3>Solution to process CSV data and map it </h3></td></tr>
         <tr><td><br/></td></tr>

                        <tr>  
                    <td style="width: 184px">Select CSV File:</td>  
                    <td style="width: 331px">  
                        <asp:FileUpload ID="FileUpload1" runat="server" />  
                    </td>  
                    <td>  
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* required" ControlToValidate="FileUpload1" ForeColor="Red" ValidationGroup="validation">  
                        </asp:RequiredFieldValidator>  
                    </td>  
                </tr>  
          <tr><td><br/></td></tr>
                <tr>  
                    <td style="width: 184px"> </td>  
                    <td style="width: 331px"> </td>  
                </tr>  
                <tr>  
                    <td colspan="2">  
                        <asp:Button ID="btnUpload" runat="server" Text="Upload" ValidationGroup="validation" OnClick="btnUpload_Click" />  
                    </td>  
                </tr>  
            </table>  
            <br />  
            <asp:GridView ID="grdCSVMap"   CssClass="table table-hover table-striped" runat="server"></asp:GridView>  
            <br />  
            <asp:Label ID="lblerror" runat="server" />  
    </form>
</body>
</html>