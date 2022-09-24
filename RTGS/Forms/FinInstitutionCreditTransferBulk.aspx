<%@ Page Title="" Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="FinInstitutionCreditTransferBulk.aspx.cs" Inherits="RTGS.Forms.FinInstitutionCreditTransferBulk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <div class="row" style="font-weight:bold;margin-top:55px" >
        <div class="col-md-12">
            <div class="panel panel-success">
                <div class="panel-heading">
                    <h3 class="panel-title"><b>FI To FI Financial Institution Credit Transfer(Bulk)</b></h3>
                </div>
                <div class="panel-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h5 class="panel-title">Upload Transactions In the Format of Excel</h5>
                        </div>
                        <div class="panel-body">
                            <table class="table table-striped table-hover">
                                <tr>
                                    <td>
                                        <div style="float: left; margin-left: 5px">Upload Customer Credit Transfer</div>
                                        <div style="float: left; margin-left: 25px">
                                            <asp:FileUpload runat="server" ID="upload1" Width="300px" CssClass="form-control" /></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="float: left; margin-left: 55px">
                                            <asp:Button ID="Submit" Text="Submit Transaction" Width="150px" CssClass="btn btn-success" runat="server" OnClick="Submit_Click" /></div>
                                        <div style="float: left; margin-left: 155px">
                                            <asp:Button ID="Cancel" Text="Cancel Transaction" Width="150px" CssClass="btn btn-danger" runat="server" OnClick="Cancel_Click" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:Label ID="Msg" runat="server" CssClass="alert-warning" /></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="paanel body">
                    <div class="panel-heading">
                            <h5 class="panel-title">Invalid Data List</h5>
                    </div>
                    <div class="panel-body">
                        <asp:Button ID="btnExcel" Text="Excel"  CssClass="btn btn-success" runat="server" OnClick="btnExcel_Click"  />
                    </div>
                    <div class="panel-body">
                            <div style="width:100%; overflow-x:auto">
                                <asp:GridView Id="InvalidList" HeaderStyle-Wrap="false" RowStyle-Wrap="false" CssClass="table  table-bordered table-striped table-hover" runat="server" 
	                            autogeneratecolumns="true">
    	                        </asp:GridView>
                            </div>
                    </div>
                    <div class="panel-body">
                        <asp:Button ID="btnProcess" Text="Proceed" Visible="false" Width="150px" CssClass="btn btn-success" runat="server" OnClick="btnProcess_Click" />
                    </div>

                </div>
            </div>

        </div>
       </div>
    <asp:HiddenField ID="HdnTick" runat="server" />
</asp:Content>
