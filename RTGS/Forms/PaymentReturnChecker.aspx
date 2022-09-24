<%@ Page Title="" Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="PaymentReturnChecker.aspx.cs" Inherits="RTGS.Forms.PaymentReturnChecker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-primary">
                <div class="panel-heading"><h3 class="panel-title">Payment Return</h3></div>
                <div class="panel-body">
                    <div class="panel panel-info">
                        <div class="panel-heading"><h5 class="panel-title">Senders Information</h5></div>
                        <div class="panel-body">
                            <table class="table table-striped table-hover">
                                <tr>
                                    <td>
                                        <div style="float:left">Account Number</div>
                                        <div style="float:left;margin-left:5px"><asp:Label runat="server" ID="lblAccountNo" placeholder="13 digits" Width="220px" Font-Size="small" CssClass="label label-default" /></div>
                                        <div style="float:left;margin-left:25px">Sending Amount</div>
                                        <div style="float:left;margin-left:7px"><asp:Label runat="server" ID="lblSettlmentAmount" Font-Size="small" Width="220px" CssClass="label label-default" /></div>
                                        <div style="float:left;margin-left:28px;">Currency</div>
                                        <div style="float:left;margin-left:27px"><asp:Label runat="server" ID="lblCCY" Font-Size="small" Width="220px" CssClass="label label-default" />
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td>
                                        
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="panel panel-info">
                        <div class="panel-heading"><h5 class="panel-title">Receivers Information</h5></div>
                        <div class="panel-body">
                            <div class="form-horizontal" role="form">
                            <div class="form-group">
                                <label for="Receiving Bank Name:" class="col-sm-4 control-label">Receiving Bank Name:</label>
                                <div class="col-sm-6"><asp:Label runat="server" ID="lblReceivingBank" Font-Size="small" Width="220px" CssClass="label label-default" /></div>
                            </div>
                            <div class="form-group">
                                <label for="Branch Name:" class="col-sm-4 control-label">Receiving Branch Name:</label>
                                <div class="col-sm-3"><asp:Label ID="lblReceivingBranch" runat="server" Font-Size="Small" CssClass="label label-default" /></div>
                                <div class="col-sm-3"><asp:Label ID="lblReceivingRoutingNo" runat="server" Font-Size="Small" MaxLength="9" CssClass="label label-default"></asp:Label></div>
                            </div>

                            <div class="form-group">
                                <label for="Receiver's Name:" class="col-sm-4 control-label">Receiver's Name:</label>
                                <div class="col-sm-6"><asp:Label ID="lblReceiverName" runat="server" Font-Size="Small" CssClass="label label-default" /></div>
                            </div>
                            <div class="form-group">
                                <label for="Receiver's ID:" class="col-md-4 control-label">Receiver's Account No:</label>
                                <div class="col-md-6"><asp:Label ID="lblReceiverAccountNo" runat="server" Font-Size="Small" CssClass="label label-default" /></div>
                            </div>
                       
                            <div class="form-group">
                                <label for="Reason For Payment:" class="col-md-4 control-label">Return Reason:</label>
                                <div class="col-md-6"><asp:Label ID="lblReturnReason" runat="server" Font-Size="Small" CssClass="label label-default"  /></div>
                            </div>
                            <div>
                            <div class="form-group">
                                <asp:Label ID="lblMsg" CssClass="bg-info" runat="server"></asp:Label>
                            </div>
                            <div class="form-group" id="ButtonPanel" runat="server" visible="false" style="margin-top:20px">
                                <div class="col-md-4">
                                    <div style="margin-left:200px"><asp:Button ID="btnSend" Text="Approve Transaction" runat="server" CssClass="btn btn-success" OnClick="btnSend_Click" /></div>
                                </div>
                                <div class="col-md-4">
                                    <div style="margin-left:100px"><asp:Button ID="btnRejectyTransaction" Text="Reject Transaction" runat="server" CssClass="btn btn-warning" OnClick="btnRejectTransaction_Click" /></div>
                                </div>
                                <div class="col-md-4">
                                    <div style="margin-left:10px"><asp:Button ID="btnCancelTrans" Text="Cancel" runat="server" CssClass="btn btn-danger" OnClick="btnCancelTrans_Click" /></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
 </div>
</asp:Content>
