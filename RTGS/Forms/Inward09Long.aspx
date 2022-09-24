<%@ Page Title="" Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="Inward09Long.aspx.cs" Inherits="RTGS.Forms.Inward09Long" %>
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
                                    <td><asp:Label runat="server" ID="lblFrBICFI" placeholder="Max8Text" Width="100px" MaxLength="8" CssClass="form-control-small" /></td>
                                    <td>To </td>
                                    <td><asp:Label runat="server" ID="lblToBICFI" placeholder="Max10Text" Width="150px" MaxLength="10" CssClass="form-control-small" /></td>
                                </tr>
                                <tr>
                                    <td>Business Message Identifier</td>
                                    <td><asp:Label runat="server" ID="lblBizMsgIdr" placeholder="Max30Text" Width="170px" CssClass="form-control-small" /></td>

                                    <td>Message Def Identifier</td>
                                    <td><asp:Label runat="server" ID="lblMsgDefIdr" placeholder="Fixed Value(CLRG)" Width="150px" CssClass="form-control-small" /></td>
                                </tr>
                                <tr>
                                    <td>Business Service</td>
                                    <td><asp:Label runat="server" ID="lblBizSvc" placeholder="Max30Text" Width="100px" CssClass="form-control-small" /></td>
                                    <td>Creation Date</td>
                                    <td><asp:Label runat="server" ID="lblCreDt" placeholder="Fixed Value(CLRG)" Width="200px" CssClass="form-control-small" /></td>
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
                                        <asp:Label runat="server" ID="lblMsgId" Text="202-002" placeholder="Max35Text" Width="170px" MaxLength="16" CssClass="form-control-small" />
                                    </td>
                                    <td>
                                        Creation Date Time
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblCreDtTm" placeholder="ISODateTime" Width="170px" CssClass="form-control-small" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Number Of Transactions
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblNbOfTxs" Text="1" placeholder="Max15NumericText" Width="170px" CssClass="form-control-small" />
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
                                                        <asp:Label runat="server" ID="lblInstrId" Text="202-002-SHS" placeholder="Max35Text" MaxLength="35" CssClass="form-control-small" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        End To End Identification
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblEndToEndId" Text="202-002-SHS" CssClass="form-control-small" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                       Transaction Identification
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblTxId" Text="202-002-SHS" CssClass="form-control-small" />
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
                                                        <asp:Label runat="server" ID="lblSvcLvlPrtry" Text="0040" placeholder="Max35Text" CssClass="form-control-small" />
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
                                                        <asp:Label runat="server" ID="lblLclInstrmPrtry" Text="RTGS_FICT" CssClass="form-control-small" />
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
                                                        <asp:Label runat="server" ID="lblCtgyPurpPrtry" Text="001" CssClass="form-control-small" />
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
                                                        <asp:Label runat="server" ID="lblIntrBkSttlmCcy" CssClass="form-control-small" />                                                 
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
                                                        <asp:Label runat="server" ID="lblIntrBkSttlmDt" CssClass="form-control-small" />
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
                                                        <asp:Label runat="server" ID="lblInstgAgtBICFI" CssClass="form-control-small" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td><label class="myChildRow">Name</label></td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblInstgAgtNm" placeholder="Max140Text" CssClass="form-control-small" />
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
                                                        <asp:Label runat="server" ID="lblInstgAgtBranchId" placeholder="Max35Text" CssClass="form-control-small" />
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
                                                        <asp:Label runat="server" ID="lblInstdAgtBICFI" Text="" CssClass="form-control-small" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td><label class="myChildRow">Name</label></td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblInstdAgtNm" placeholder="Max140Text" CssClass="form-control-small" />
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
                                                        <asp:Label runat="server" ID="lblInstdAgtBranchId" placeholder="Max35Text"  CssClass="form-control-small" />
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
                                                        <asp:Label runat="server" ID="lblIntrmyAgt1BICFI" CssClass="form-control-small" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td><label class="myChildRow">Name</label></td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblIntrmyAgt1Nm" placeholder="Max140Text" CssClass="form-control-small" />
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
                                                        <asp:Label runat="server" ID="lblIntrmyAgt1BranchId" placeholder="Max35Text"  CssClass="form-control-small" />
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
                                                        <asp:Label runat="server" ID="lblIntrmyAgt1AcctId" placeholder="Max35Text" CssClass="form-control-small" />
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
                                                        <asp:Label runat="server" ID="lblIntrmyAgt1AcctTp" placeholder="Max35Text" CssClass="form-control-small" />
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
                                                        <asp:Label runat="server" ID="lblDbtrBICFI" Text="ABBLBDDH" CssClass="form-control-small" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td><label class="myChildRow">Name</label></td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblDbtrNm" placeholder="Max140Text" CssClass="form-control-small" />
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
                                                        <asp:Label runat="server" ID="lblDbtrBranchId" placeholder="Max35Text"  CssClass="form-control-small" />
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
                                                        <asp:Label runat="server" ID="lblDbtrAcctId" placeholder="Max35Text" CssClass="form-control-small" />
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
                                                        <asp:Label runat="server" ID="lblDbtrAcctTp" placeholder="Max35Text" CssClass="form-control-small" />
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
                                                        <asp:Label runat="server" ID="lblCdtrAgtBICFI" CssClass="form-control-small" />
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
                                                        <asp:Label runat="server" ID="lblCdtrAgtBranchId" placeholder="Max35Text"  CssClass="form-control-small" />
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
                                                        <asp:Label runat="server" ID="lblCdtrAgtAcctId" placeholder="Max35Text" CssClass="form-control-small" />
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
                                                        <asp:Label runat="server" ID="lblCdtrAgtAcctTp" placeholder="Max35Text" CssClass="form-control-small" />
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
                                                        <asp:Label runat="server" ID="lblCdtrBICFI" Text="" CssClass="form-control-small" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td><label class="myChildRow">Name</label></td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblCdtrNm" placeholder="Max140Text" CssClass="form-control-small" />
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
                                                        <asp:Label runat="server" ID="lblCdtrBranchId" placeholder="Max35Text"  CssClass="form-control-small" />
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
                                                        <asp:Label runat="server" ID="lblCdtrAcctId" placeholder="Max35Text" CssClass="form-control-small" />
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
                                                        <asp:Label runat="server" ID="lblCdtrAcctTp" placeholder="Max35Text" CssClass="form-control-small" />
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
                                                        <asp:Label runat="server" ID="lblInstrInf" placeholder="Max140Text" CssClass="form-control-small" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Payment Reason</td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblPmntRsn" placeholder="Max140Text" CssClass="form-control-small" />
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
                                    <div class="panel-body" id="ButtonPanel" runat="server" visible="false">
                                        <div style="float:left;margin-left:20px;clear:both">
                                                <asp:Button ID="btnSend" Text="Generate Reversal" runat="server" CssClass="btn btn-danger" OnClick="btnSend_Click"  /></div>
                                        <div style="float:left;margin-left:40px">
                                                <asp:Button ID="btnCancelTrans" Text="Cancel" runat="server" CssClass="btn btn-info" OnClick="btnCancelTrans_Click" /></div>
                                        <div style="float:left;margin-left:40px">
                                             <asp:Button ID="btnReturn" Text="Approve" runat="server" CssClass="btn btn-success" OnClick="btnReturn_Click" /></div>
                                         <div style="float:left;margin-left:10px">
                                             <asp:TextBox ID="txtNewAccountNo" runat="server" Visible="false" Width="300px" placeholder="Enter New Account No. here: Max17Text" CssClass="form-control-small" /></div>
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
