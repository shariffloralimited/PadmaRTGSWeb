<%@ Page Title="" Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="Outward09LongMaker.aspx.cs" Inherits="RTGS.Forms.Outward09LongMaker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-primary">
                   <div class="panel panel-info">
                        <div class="panel-heading"><h5 class="panel-title">App Header</h5></div>
                        <div class="panel-body">
                            <table class="table table-striped table-hover">
                                <tr>
                                    <td colspan="4">Financial Institution BICFI</td>
                                </tr>
                                <tr>
                                    <td>From </td>
                                    <td><asp:TextBox runat="server" ID="txtFrBICFI" placeholder="Max20Text" Width="100px" MaxLength="20" CssClass="form-control-small"/></td>
                                    <td>To </td>
                                    <td><asp:TextBox runat="server" ID="txtToBICFI" placeholder="Max25Text" Width="150px" MaxLength="25" CssClass="form-control-small" /></td>
                                </tr>
                                <tr>
                                    <td>Business Message Identifier</td>
                                    <td><asp:TextBox runat="server" ID="txtBizMsgIdr" placeholder="Max35Text" Width="170px" CssClass="form-control-small" MaxLength="35" /></td>

                                    <td>Message Def Identifier</td>
                                    <td><asp:TextBox runat="server" ID="txtMsgDefIdr" placeholder="Fixed Value(CLRG)" Width="150px" CssClass="form-control-small" MaxLength="35" /></td>
                                </tr>
                                <tr>
                                    <td>Business Service</td>
                                    <td><asp:TextBox runat="server" ID="txtBizSvc" placeholder="Max20Text" Width="100px" CssClass="form-control-small" MaxLength="20" /></td>
                                    <td>Creation Date</td>
                                    <td><asp:TextBox runat="server" ID="txtCreDt" placeholder="Fixed Value(CLRG)" Width="200px" CssClass="form-control-small" MaxLength="30"/></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="panel panel-info">
                        <div class="panel-heading"><h5 class="panel-title">Group Header</h5></div>
                        <div class="panel-body">
                            <table class="table table-striped table-hover">
                                <tr>
                                    <td>
                                        Message Identification
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtMsgId" Text="202-002" placeholder="Max35Text" Width="170px" MaxLength="35" CssClass="form-control-small" />
                                    </td>
                                    <td>
                                        Creation Date Time
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtCreDtTm" placeholder="ISODateTime" Width="170px" CssClass="form-control-small" MaxLength="30"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Number Of Transactions
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtNbOfTxs" Text="1" Enabled="false" placeholder="Max15NumericText" Width="170px" CssClass="form-control-small" />
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
                                       CLRG
                                    </td>
                                    <td>No CBS</td>
                                    <td><asp:CheckBox runat="server" ID="ChkNoCBS" Enabled="false" /></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="panel panel-info">
                        <div class="panel-heading"><h5 class="panel-title"><span class="caret"></span>&nbsp;&nbsp;Credit Transfer Transaction Information</h5></div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="panel panel-info">
                                        <div class="panel-heading"><h5 class="panel-title"><span class="caret"></span>&nbsp;&nbsp;Payment Identification</h5></div>
                                        <div class="panel-body">
                                            <table class="table table-striped table-hover">
                                                <tr>
                                                    <td>
                                                        Instruction Identification
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtInstrId" Text="202-002-SHS" placeholder="Max34Text" MaxLength="34" CssClass="form-control-small" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        End To End Identification
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtEndToEndId" Text="202-002-SHS" CssClass="form-control-small" MaxLength="35" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                       Transaction Identification
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtTxId" Text="202-002-SHS" CssClass="form-control-small" MaxLength="35"  />
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
                                                    <td>RTGS</td>
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
                                                        <asp:TextBox runat="server" ID="txtSvcLvlPrtry" Text="0040" placeholder="Max35Text" CssClass="form-control-small"  MaxLength="35" />
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
                                                        <asp:TextBox runat="server" ID="txtLclInstrmPrtry" Text="RTGS_FICT" CssClass="form-control-small" MaxLength="35"  />
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
                                                        <asp:DropDownList runat="server" ID="ddlCtgyPurpPrtry" DataTextField="TTCType" DataValueField="TTCCode" CssClass="form-control-small" />
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
                                        <div class="panel-heading"><h5 class="panel-title"><span class="caret"></span>&nbsp;&nbsp;Interbank Settlement Amount And Date</h5></div>
                                        <div class="panel-body">
                                            <table class="table table-striped table-hover">
                                                <tr>
                                                    <td>
                                                       Currency
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSettlementCurrency" runat="server" CssClass="form-control-small" /> 
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                       Amount
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblIntrBkSttlmAmt" CssClass="form-control-small" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                       Date
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtIntrBkSttlmDt" CssClass="form-control-small" MaxLength="10" />
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
                                                        <asp:TextBox runat="server" ID="txtInstgAgtBICFI" CssClass="form-control-small" MaxLength="35" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td><label class="myChildRow">Name</label></td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtInstgAgtNm" placeholder="Max70Text" CssClass="form-control-small" MaxLength="70"  />
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
                                                        <asp:TextBox runat="server" ID="txtInstgAgtBranchId" placeholder="Max35Text" CssClass="form-control-small" MaxLength="35" />
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
                                                        <asp:TextBox runat="server" ID="txtInstdAgtBICFI" Text="" CssClass="form-control-small"  MaxLength="35" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td><label class="myChildRow">Name</label></td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtInstdAgtNm" placeholder="Max70Text" CssClass="form-control-small"  MaxLength="70" />
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
                                                        <asp:TextBox runat="server" ID="txtInstdAgtBranchId" placeholder="Max35Text"  CssClass="form-control-small" MaxLength="35" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="panel panel-info">
                                        <div class="panel-heading"><h5 class="panel-title"><span class="caret"></span>&nbsp;&nbsp;Intermediary Agent 1</h5></div>
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
                                                        <asp:TextBox runat="server" ID="txtIntrmyAgt1BICFI" CssClass="form-control-small" MaxLength="50" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td><label class="myChildRow">Name</label></td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtIntrmyAgt1Nm" placeholder="Max70Text" CssClass="form-control-small" MaxLength="70" />
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
                                                        <asp:TextBox runat="server" ID="txtIntrmyAgt1BranchId" placeholder="Max50Text"  CssClass="form-control-small" MaxLength="50" />
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
                                        <div class="panel-heading"><h5 class="panel-title"><span class="caret"></span>&nbsp;&nbsp;Intermediary Agent 1 Account</h5></div>
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
                                                        <asp:TextBox runat="server" ID="txtIntrmyAgt1AcctId" placeholder="Max34Text" CssClass="form-control-small" MaxLength="34"  />
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
                                                        <asp:TextBox runat="server" ID="txtIntrmyAgt1AcctTp" placeholder="Max50Text" CssClass="form-control-small" MaxLength="50"  />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="panel panel-info">
                                        <div class="panel-heading"><h5 class="panel-title"><span class="caret"></span>&nbsp;&nbsp;Debtor</h5></div>
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
                                                        <asp:TextBox runat="server" ID="txtDbtrBICFI" Text="ABBLBDDH" CssClass="form-control-small" MaxLength="25" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td><label class="myChildRow">Name</label></td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtDbtrNm" placeholder="Max70Text" CssClass="form-control-small" MaxLength="70" />
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
                                                        <asp:TextBox runat="server" ID="txtDbtrBranchId" placeholder="Max35Text"  CssClass="form-control-small" MaxLength="35" />
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
                                                        <asp:Label runat="server" ID="lblDbtrAcctId" CssClass="form-control-small"  />
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
                                                        <asp:TextBox runat="server" ID="txtDbtrAcctTp" placeholder="Max50Text" CssClass="form-control-small" MaxLength="50" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>                        
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
                                                        <asp:TextBox runat="server" ID="txtCdtrAgtBICFI" CssClass="form-control-small" MaxLength="35" />
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
                                                        <asp:TextBox runat="server" ID="txtCdtrAgtBranchId" placeholder="Max35Text"  CssClass="form-control-small" MaxLength="35" />
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
                                                        <asp:TextBox runat="server" ID="txtCdtrAgtAcctId" placeholder="Max35Text" CssClass="form-control-small" MaxLength="35"  />
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
                                                        <asp:TextBox runat="server" ID="txtCdtrAgtAcctTp" placeholder="Max50Text" CssClass="form-control-small" MaxLength="50" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="panel panel-info">
                                        <div class="panel-heading"><h5 class="panel-title"><span class="caret"></span>&nbsp;&nbsp;Creditor</h5></div>
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
                                                        <asp:TextBox runat="server" ID="txtCdtrBICFI" Text="Max35Text" CssClass="form-control-small" MaxLength="35" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td><label class="myChildRow">Name</label></td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtCdtrNm" placeholder="Max70Text" CssClass="form-control-small" MaxLength="70"/>
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
                                                        <asp:TextBox runat="server" ID="txtCdtrBranchId" placeholder="Max35Text"  CssClass="form-control-small" MaxLength="35"/>
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
                                                        <asp:Label runat="server" ID="lblCdtrAcctId" CssClass="form-control-small" />
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
                                                        <asp:TextBox runat="server" ID="txtCdtrAcctTp" placeholder="Max50Text" CssClass="form-control-small" MaxLength="50" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="panel panel-info">
                                        <div class="panel-heading"><h5 class="panel-title"><span class="caret"></span>&nbsp;&nbsp;Instruction For Next Agent</h5></div>
                                        <div class="panel-body">
                                            <table class="table table-striped table-hover">
                                                <tr>
                                                    <td>Instruction Information</td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtInstrInf" placeholder="Max140Text" Width="300" CssClass="form-control-small" MaxLength="140" />
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
                                        <div class="panel-heading"><h5 class="panel-title"><span class="caret"></span>&nbsp;&nbsp;Instruction For Maker From Checker</h5></div>
                                        <div class="panel-body">
                                            <table class="table table-striped table-hover">
                                                <tr>
                                                    <td>Return Reason</td>
                                                    <td>
                                                        <asp:Label runat="server" ID="LblReturnReason" CssClass="form-control-small" />
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
                                    <div class="panel-heading"><h5 class="panel-title"><span class="caret"></span>&nbsp;&nbsp;CBS Response</h5></div>
                                    <div class="panel-body">
                                        <table class="table table-striped table-hover">
                                            <tr>
                                                <td>CBS Response</td>
                                                <td><asp:Label runat="server" ID="lblCBSResponse" Width="300px" placeholder="Max140Text" CssClass="form-control-small"  /></td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12" style="display:none">
                                    <asp:Label ID="lblMsg" CssClass="bg-info" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="panel panel-info">
                                        <div class="panel-body">
                                            <div class="form-group">
                                            <div class="col-md-4"><div style="margin-left:200px"><asp:Button ID="btnSend" Text="Send" runat="server" CssClass="btn btn-success" OnClick="btnSend_Click" /></div></div>
                                            <div class="col-md-4"><div style="margin-left:100px"><asp:Button ID="btnDelete" Text="Delete" runat="server" CssClass="btn btn-danger" OnClick="btnDelete_Click" /></div></div>
                                            <div class="col-md-4"><div style="margin-left:10px"><asp:Button ID="btnCancelTrans" Text="Cancel" runat="server" CssClass="btn btn-info" OnClick="btnCancelTrans_Click" /></div></div>
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
