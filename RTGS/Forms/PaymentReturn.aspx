<%@ Page Title="" Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="PaymentReturn.aspx.cs" Inherits="RTGS.Forms.PaymentReturn" %>
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
                                        <div style="float:left;margin-left:27px"><asp:Label runat="server" ID="lblCCY"  CssClass="label label-default" /></div>
                                       <div class="form-group">
                                        <label for="Branch Name:" class="col-sm-4 control-label">Sending Branch Name:</label>
                                        <div class="col-sm-3"><asp:Label runat="server" ID="lblToBranch" Font-Size="small"  CssClass="label label-default" /></div>
                                       <%-- <div class="col-sm-3"><asp:Label ID="lblToBranchID" runat="server" Font-Size="small" CssClass="label label-default" /></div>--%>
                                         </div>
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
                                <div class="col-sm-6"><asp:Label runat="server" ID="lblReceivingBank" Font-Size="small"  CssClass="label label-default" /></div>
                            </div>
                            <div class="form-group">
                                <label for="Branch Name:" class="col-sm-4 control-label">Receiving Branch Name:</label>
                                <div class="col-sm-3"><asp:Label runat="server" ID="lblReceivingBranch" Font-Size="small"  CssClass="label label-default" /></div>
                                <div class="col-sm-3"><asp:Label ID="lblRoutingNo" runat="server" Font-Size="small" CssClass="label label-default" /></div>
                            </div>
<%--                            <div class="form-group">
                                <label for="Branch Name:" class="col-sm-4 control-label">Sending Branch Name:</label>
                                <div class="col-sm-3"><asp:Label runat="server" ID="lblToBranch" Font-Size="small"  CssClass="label label-default" /></div>
                                <div class="col-sm-3"><asp:Label ID="lblToBranchID" runat="server" Font-Size="small" CssClass="label label-default" /></div>
                            </div>--%>
                            <div class="form-group">
                                <label for="Receiver's Name:" class="col-sm-4 control-label">Receiver's Name:</label>
                                <div class="col-sm-6">
                                    <asp:Label ID="lblReceiverName" runat="server" Font-Size="Small" CssClass="label label-default" />
                                </div>
                                <div class="col-sm-2">
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="Receiver's ID:" class="col-md-4 control-label">Receiver's Account No:</label>
                                <div class="col-md-6">
                                     <asp:Label ID="lblReceiverAccountNo" runat="server" Font-Size="Small" CssClass="label label-default" />
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                       
                            <div class="form-group">
                                <label for="Reason For Payment:" class="col-md-4 control-label">Return Reason:</label>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddlReturnReason" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="Account Closed"  Value="R 01" />
                                        <asp:ListItem Text="No Account/Unable to Locate Account" Value="R 02" />
                                        <asp:ListItem Text="Invaliid Account Number" Value="R 03" />
                                        <asp:ListItem Text="Returned per Originator/Originationg Bank's Request" Value="R 04" />
                                        <asp:ListItem Text="Representative Payee Deceased or Unable to Continue in that Capacity " Value="R 05" />
                                        <asp:ListItem Text="Beneficiary or Account Holder (other than a Representative Payee) Deceased " Value="R 06" />
                                        <asp:ListItem Text="Account Frozen" Value="R 07" />
                                        <asp:ListItem Text="Non-Transaction Account" Value="R 08" />
                                        <asp:ListItem Text="Entry Refused by the Receiver" Value="R 09" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div>
                                <asp:Label ID="lblMsg" CssClass="bg-info" runat="server"></asp:Label>
                            </div>
                            <div class="form-group" style="margin-top:20px">
                                <div class="col-md-4">
                                    <div style="margin-left:200px"><asp:Button ID="btnSend" Text="Send Transaction" runat="server" CssClass="btn btn-success" OnClick="btnSend_Click" /></div>
                                </div>
                                <div class="col-md-4">
                                    <div style="margin-left:100px"></div>
                                </div>
                                <div class="col-md-4">
                                    <div style="margin-left:10px"><asp:Button ID="btnCancelTrans" Text="Cancel Transaction" runat="server" CssClass="btn btn-danger" OnClick="btnCancelTrans_Click" /></div>
                                </div>
                            </div>
                        </div>

                        </div>
                    </div>

                    <div class="panel panel-info" style="display:none">
                        <div class="panel-heading"><h5 class="panel-title">Group Header</h5></div>
                        <div class="panel-body">
                            <table class="table table-striped table-hover">
                                <tr>
                                    <td>
                                        Message Identification
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtMsgId" Width="120px" MaxLength="16" CssClass="form-control" />
                                    </td>
                                    <td>
                                        Creation Date Time
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtCreDtTm" Width="120px" CssClass="form-control" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Number Of Transactions
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtNbOfTxs" Width="120px" CssClass="form-control" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><p class="bg-info"><span class="caret"></span>&nbsp;&nbsp;
                                        Settlement Information</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Settlement Method
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="Label3" placeholder="Fixed Value(CLRG)" Width="150px" CssClass="form-control" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="panel panel-info" style="display:none">
                        <div class="panel-heading"><h5 class="panel-title">Original Group Information</h5></div>
                        <div class="panel-body">
                            <table class="table table-striped table-hover">
                                <tr>
                                    <td>
                                        Original Message Identification
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtOrgnlMsgId" MaxLength="35" CssClass="form-control" />
                                    </td>
                                    <td>
                                        Original Message Name Identification
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtOrgnlMsgNmId" CssClass="form-control" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Original Creation Date Time
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtOrgnlCreDtTm" CssClass="form-control" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <div class="panel panel-info">
                                        <div class="panel-heading"><h5 class="panel-title">Return Reason Information</h5></div>
                                        <div class="panel-body">
                                            <table class="table table-striped table-hover">
                                                <tr>
                                                    <td colspan="4"><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;Originator</p></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label class="myChildRow">Name</label> 
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtReturnReasonInfoName" MaxLength="35" CssClass="form-control" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4"<p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;>Reason</p></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label class="myChildRow">Code</label> 
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtReturnReasonInfoCode" MaxLength="35" CssClass="form-control" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td><label class="myChildRow">Proprietary</label> </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtPrtry" MaxLength="35" CssClass="form-control" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;Additional Information</p></td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtAddtlInf" MaxLength="105" CssClass="form-control" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;CrossElementComplexRule</p></td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="TextBox4" MaxLength="105" CssClass="form-control" />
                                                    </td>
                                                </tr>
                                               </table>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="panel panel-info" style="display:none">
                        <div class="panel-heading"><h5 class="panel-title">Transaction Information</h5></div>
                        <div class="panel-body">
                            <table class="table table-striped table-hover">
                                <tr>
                                    <td>
                                        Return Identification
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtRtrId" MaxLength="35" CssClass="form-control" />
                                    </td>
                                    <td>
                                        Original Instruction Identification
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtOrgnlInstrId" MaxLength="35" CssClass="form-control" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Original End To End Identification
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtOrgnlEndToEndId" MaxLength="35" CssClass="form-control" />
                                    </td>
                                    <td>Original Transaction Identification</td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtOrgnlTxId" MaxLength="35" CssClass="form-control" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Returned Interbank Settlement Amount</td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtRtrdIntrBkSttlmAmt" CssClass="form-control" />
                                    </td>
                                    <td>Interbank Settlement Date</td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtIntrBkSttlmDt" CssClass="form-control" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Charge Bearer</td>
                                    <td>
                                        <asp:RadioButtonList runat="server">
                                            <asp:ListItem Text="Borne By Debtor [DEBT]" />
                                            <asp:ListItem Text="Borne By Creditor [CRED]" />
                                            <asp:ListItem Text="Shared [SHAR]" />
                                        </asp:RadioButtonList>  
                                    </td>
                                </tr>
                           </table>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="panel panel-info">
                                <div class="panel-heading"><h5 class="panel-title"><span class="caret"></span>&nbsp;&nbsp;Charges Information</h5></div>
                                <div class="panel-body">
                                    <table class="table table-striped table-hover">
                                        <tr>
                                            <td colspan="2"><p class="bg-info"><span class="caret"></span>&nbsp;&nbsp;</p></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Agent</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">&nbsp;&nbsp;Financial Institution Identification</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;BICFI</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;Name</td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtChargeNm" MaxLength="140" CssClass="form-control" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;Branch Identification</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Identification</td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtId" MaxLength="35" CssClass="form-control" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            </div>
                            <div class="col-md-6">
                                <div class="panel panel-info">
                                <div class="panel-heading"><h5 class="panel-title"><span class="caret"></span>&nbsp;&nbsp;Instructing Agent</h5></div>
                                <div class="panel-body">
                                    <table class="table table-striped table-hover">
                                        <tr>
                                            <td colspan="2"><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;
                                                Financial Institution Identification
                                            </td>
                                        </tr>
                                        <tr>
                                            <td><label class="myChildRow">BICFI</label></td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtInstructingAgentBICFI" CssClass="form-control" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td><label class="myChildRow">Name</label></td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtInstructingAgentName" placeholder="Max140Text" CssClass="form-control" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2"><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;
                                                Branch Identification
                                            </td>
                                        </tr>
                                        <tr>
                                            <td><label class="myChildRow">Identification</label></td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtInstructingAgentBranchId" placeholder="Max35Text" CssClass="form-control" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="panel panel-info">
                                    <div class="panel-heading"><h5 class="panel-title"><span class="caret"></span>&nbsp;&nbsp;Instructed Agent</h5></div>
                                    <div class="panel-body">
                                        <table class="table table-striped table-hover">
                                            <tr>
                                                <td colspan="2"><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;
                                                    Financial Institution Identification
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><label class="myChildRow">BICFI</label></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtInstructedAgentBICFI" CssClass="form-control" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2"><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;
                                                   Branch Identification
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><label class="myChildRow">Identification</label></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtInstructedAgentBranchId" placeholder="Max35Text"  CssClass="form-control" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="panel panel-info">
                                    <div class="panel-heading"><h5 class="panel-title"><span class="caret"></span>&nbsp;&nbsp;Original Transaction Reference</h5></div>
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="panel panel-info">
                                                    <div class="panel-heading"><h5 class="panel-title"><span class="caret"></span>&nbsp;&nbsp;Interbank Settlement Amount</h5></div>
                                                    <div class="panel-body">
                                                        <table class="table table-striped table-hover">
                                                            <tr>
                                                                <td>
                                                                   Currency
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList runat="server" ID="ddlSettlementCurrency" CssClass="form-control">
                                                                        <asp:ListItem Text="BDT" Value="BDT" />
                                                                        <asp:ListItem Text="USD" Value="USD" />
                                                                        <asp:ListItem Text="EUR" Value="EUR" />
                                                                        <asp:ListItem Text="GBP" Value="GBP" />
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                   Amount
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="txtInterBankSetlmntAmount" CssClass="form-control" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                   Date
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="txtSettlementDate" CssClass="form-control" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="panel panel-info">
                                                <div class="panel-heading"><h5 class="panel-title"><span class="caret"></span>&nbsp;&nbsp;Payment Type Information</h5></div>
                                                <div class="panel-body">
                                                    <table class="table table-striped table-hover">
                                                        <tr>
                                                            <td colspan="2"><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;
                                                                Clearing Channel
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <label class="myChildRow">Real Time Gross <br />Settlement System</label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtPTClearingChannel" placeholder="RTGS" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2"><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;
                                                                Service Level
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <label class="myChildRow"> Proprietary</label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtPTIServiceLevelProprietary" placeholder="Max35Text" CssClass="form-control" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2"><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;
                                                                Local Instrument
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                               <label class="myChildRow">Proprietary</label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtPTILocalInstrumentProprietary" CssClass="form-control" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2"><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;
                                                                Category Purpose
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                               <label class="myChildRow">Proprietary</label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtPTICategoryPurposeProprietary" CssClass="form-control" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="panel panel-info">
                                                <div class="panel-heading"><h5 class="panel-title"><span class="caret"></span>&nbsp;&nbsp;Payment Method</h5></div>
                                                <div class="panel-body">
                                                    <table class="table table-striped table-hover">
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="TextBox2" CssClass="form-control" Text="TRF" /></td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="panel panel-info">
                                                <div class="panel-heading"><h5 class="panel-title"><span class="caret"></span>&nbsp;&nbsp;Remittance Information</h5></div>
                                                <div class="panel-body">
                                                    <table class="table table-striped table-hover">
                                                        <tr>
                                                            <td><label class="myChildRow">Unstructured</label></td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="TextBox5" CssClass="form-control" /></td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="panel panel-info">
                                                <div class="panel-heading"><h5 class="panel-title"><span class="caret"></span>&nbsp;&nbsp;Debtor</h5></div>
                                                <div class="panel-body">
                                                    <table class="table table-striped table-hover">
                                                        <tr>
                                                            <td>Name</td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="TextBox6" placeholder="Max35Text" CssClass="form-control" />
                                                            </td>
                                                        </tr>
                                                         <tr>
                                                            <td colspan="2"><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;
                                                               Postal Address
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><label class="myChildRow">Street Name</label></td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtDebtorStreetName" placeholder="Max35Text" CssClass="form-control" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><p class="bg-info "><span class="caret"></span>&nbsp;&nbsp;Town Name</td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtDebtorTownName" placeholder="Max35Text"  CssClass="form-control" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><label class="myChildRow">Country</label></td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtDebtorCountry" placeholder="Max35Text"  CssClass="form-control" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><label class="myChildRow">Address Line</label></td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtDebtorAddressLine" placeholder="Max70Text"  CssClass="form-control" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="panel panel-info">
                                                <div class="panel-heading"><h5 class="panel-title"><span class="caret"></span>&nbsp;&nbsp;Debtor Account</h5></div>
                                                <div class="panel-body">
                                                    <table class="table table-striped table-hover">
                                                        <tr>
                                                            <td colspan="2"><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;
                                                               Identification
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2"><p class="bg-info my2ndChildHead"><span class="caret"></span>&nbsp;&nbsp;
                                                               Other
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><label class="my2ndChildRow">Identification</label></td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtDebtorAccountId" placeholder="Max35Text" CssClass="form-control" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2"><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;
                                                               Type
                                                            </td>
                                                        </tr>
                                                         <tr>
                                                            <td><label class="my2ndChildRow">Proprietory</label></td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtDebtorAccountProprietary" placeholder="Max35Text" CssClass="form-control" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                            <div class="col-md-6">
                                <div class="panel panel-info">
                                    <div class="panel-heading"><h5 class="panel-title"><span class="caret"></span>&nbsp;&nbsp;Debtor Agent</h5></div>
                                    <div class="panel-body">
                                        <table class="table table-striped table-hover">
                                            <tr>
                                                <td colspan="2"><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;
                                                    Financial Institution Identification
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><label class="myChildRow">BICFI</label></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtDebtorAgentBICFI" CssClass="form-control" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><label class="myChildRow">Name</label></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtDebtorAgentName" placeholder="Max140Text" CssClass="form-control" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2"><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;
                                                   Branch Identification
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><label class="myChildRow">Identification</label></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtDebtorAgenId" placeholder="Max35Text"  CssClass="form-control" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                             <div class="col-md-6">
                                <div class="panel panel-info">
                                    <div class="panel-heading"><h5 class="panel-title"><span class="caret"></span>&nbsp;&nbsp;Debtor Agent Account</h5></div>
                                    <div class="panel-body">
                                        <table class="table table-striped table-hover">
                                            <tr>
                                                <td colspan="2"><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;
                                                   Identification
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2"><p class="bg-info my2ndChildHead"><span class="caret"></span>&nbsp;&nbsp;
                                                   Other
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><label class="my2ndChildRow">Identification</label></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtDebtorAgentAccountId" placeholder="Max35Text" CssClass="form-control" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2"><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;
                                                   Type
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><label class="myChildRow">Proprietary</label></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtDebtorAgentAccountProprietary" placeholder="Max35Text" CssClass="form-control" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                             <div class="col-md-6">
                                <div class="panel panel-info">
                                    <div class="panel-heading"><h5 class="panel-title"><span class="caret"></span>&nbsp;&nbsp;Creditor Agent</h5></div>
                                    <div class="panel-body">
                                        <table class="table table-striped table-hover">
                                            <tr>
                                                <td colspan="2"><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;
                                                    Financial Institution Identification
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><label class="myChildRow">BICFI</label></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtCreditorAgentBICFI" CssClass="form-control" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><label class="myChildRow">Name</label></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="TextBox9" placeholder="Max140Text" CssClass="form-control" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2"><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;
                                                   Branch Identification
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><label class="myChildRow">Identification</label></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="TextBox10" placeholder="Max35Text"  CssClass="form-control" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="panel panel-info">
                                    <div class="panel-heading"><h5 class="panel-title"><span class="caret"></span>&nbsp;&nbsp;Creditor Agent Account</h5></div>
                                    <div class="panel-body">
                                        <table class="table table-striped table-hover">
                                            <tr>
                                                <td colspan="2"><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;
                                                   Identification
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2"><p class="bg-info my2ndChildHead"><span class="caret"></span>&nbsp;&nbsp;
                                                   Other
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><label class="my2ndChildRow">Identification</label></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="TextBox11" placeholder="Max35Text" CssClass="form-control" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2"><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;
                                                   Type
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><label class="myChildRow">Proprietary</label></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="TextBox12" placeholder="Max35Text" CssClass="form-control" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="panel panel-info">
                                    <div class="panel-heading"><h5 class="panel-title"><span class="caret"></span>&nbsp;&nbsp;Creditor</h5></div>
                                    <div class="panel-body">
                                        <table class="table table-striped table-hover">
                                            <tr>
                                                <td>Name</td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtCreditorName" placeholder="Max140Text" CssClass="form-control" />
                                                </td>
                                            </tr>
                                             <tr>
                                                <td colspan="2"><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;
                                                   Postal Address
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><label class="myChildRow">Address Line</label></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtCreditorAddressLine" placeholder="Max70Text"  CssClass="form-control" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>  
                           <div class="col-md-6">
                                <div class="panel panel-info">
                                    <div class="panel-heading"><h5 class="panel-title"><span class="caret"></span>&nbsp;&nbsp;Creditor Account</h5></div>
                                    <div class="panel-body">
                                        <table class="table table-striped table-hover">
                                            <tr>
                                                <td colspan="2"><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;
                                                   Identification
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2"><p class="bg-info my2ndChildHead"><span class="caret"></span>&nbsp;&nbsp;
                                                   Other
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><label class="my2ndChildRow">Identification</label></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtCreditorAccountId" placeholder="Max34Text" CssClass="form-control" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2"><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;
                                                   Type
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label class="myChildRow">Proprietary</label></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="TextBox16" placeholder="Max35Text" CssClass="form-control" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
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
