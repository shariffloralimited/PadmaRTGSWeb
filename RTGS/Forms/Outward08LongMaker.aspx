<%@ Page Title="" Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="Outward08LongMaker.aspx.cs" Inherits="RTGS.Forms.Outward08LongMaker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-primary">
                <div class="panel-heading"><h3 class="panel-title"><b>FI To FI Customer Credit Transfer</b></h3></div>
                <div class="panel-body">
                    <div class="panel panel-info">
                        <div class="panel-heading"><h5 class="panel-title">App Header</h5></div>
                        <div class="panel-body">
                            <table class="table table-striped table-hover">
                                <tr>
                                    <td colspan="4">Financial Institution BICFI</td>
                                </tr>
                                <tr>
                                    <td>From </td>
                                    <td><asp:label runat="server" ID="TxtFrBICFI" placeholder="Max8Text" Width="100px" MaxLength="8" CssClass="form-control-small" /></td>
                                    <td>To </td>
                                    <td><asp:label runat="server" ID="TxtToBICFI" placeholder="Max12Text" Width="150px" MaxLength="12" CssClass="form-control-small" /></td>
                                </tr>
                                <tr>
                                    <td>Business Message Identifier</td>
                                    <td><asp:label runat="server" ID="TxtBizMsgIdr" placeholder="Max35Text" Width="170px" CssClass="form-control-small" MaxLength="35" /></td>

                                    <td>Message Def Identifier</td>
                                    <td><asp:label runat="server" ID="TxtMsgDefIdr" placeholder="Fixed Value(CLRG)" Width="150px" CssClass="form-control-small" MaxLength="16" /></td>
                                </tr>
                                <tr>
                                    <td>Business Service</td>
                                    <td><asp:label runat="server" ID="TxtBizSvc" placeholder="Max10Text" Width="100px" CssClass="form-control-small" MaxLength="10" /></td>
                                    <td>Creation Date</td>
                                    <td><asp:label runat="server" ID="TxtCreDt" placeholder="Fixed Value(CLRG)" Width="200px" CssClass="form-control-small" MaxLength="50" /></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="panel panel-info">
                        <div class="panel-heading"><h5 class="panel-title">Group Header</h5></div>
                        <div class="panel-body">
                            <table class="table table-striped table-hover">
                                <tr>
                                    <td>Message ID</td>
                                    <td><asp:label runat="server" ID="TxtMsgId" placeholder="Max35Text" Width="200px"   MaxLength="35" CssClass="form-control-small" /></td>
                                    <td>Creation Date Time</td>
                                    <td><asp:label runat="server" ID="TxtCreDtTm" placeholder="ISODateTime" Width="170px" CssClass="form-control-small" MaxLength="50" /></td>
                                </tr>
                                <tr>
                                    <td>Batch Booking</td>
                                    <td><asp:CheckBox runat="server" ID="ChkBtchBookg" Enabled="false" /></td>
                                    <td>Number Of Transactions</td>
                                    <td><asp:TextBox runat="server" ID="TxtNbOfTxs" placeholder="Max15NumericText" Enabled="false" Width="50px" CssClass="form-control-small" /></td>
                                </tr>

                                <tr>
                                    <td colspan="4"><p class="bg-info"><span class="caret"></span>&nbsp;&nbsp;Settlement Information</p></td>
                                </tr>
                                <tr>
                                    <td>Settlement Method </td>
                                    <td>CLRG</td>
                                    <td>Charger Waived</td>
                                    <td><asp:CheckBox runat="server" ID="ChkChargerWaived" Enabled="false" /></td>
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
                                                <td>Instruction Identification</td>
                                                <td><asp:TextBox runat="server" ID="TxtInstrId" Width="180" placeholder="Max35Text" MaxLength="35" CssClass="form-control-small"  /></td>
                                            </tr>
                                            <tr>
                                                <td>End To End Identification</td>
                                                <td><asp:TextBox runat="server" ID="TxtEndToEndId" Width="180" placeholder="Max35Text" MaxLength="35" CssClass="form-control-small"  /></td>
                                            </tr>
                                            <tr>
                                                <td>Transaction Identification</td>
                                                <td><asp:TextBox runat="server" ID="TxtTxId" Width="180" placeholder="Max35Text" MaxLength="35" CssClass="form-control-small"  /></td>
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
                                            <tr><td colspan="2"><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp; Clearing Channel</td></tr>
                                            <tr>
                                                <td><label class="myChildRow">Real Time Gross <br />Settlement System</label></td>
                                                <td><asp:Label runat="server" ID="TxtClrChanl" placeholder="RTGS" MaxLength="10" /></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2"><p class="bg-info myChildHead"><span class="caret"></span>Service Level</td>
                                            </tr>
                                            <tr>
                                                <td><label class="myChildRow"> Proprietary</label></td>
                                                <td><asp:Label runat="server" ID="TxtSvcLvlPrtry" placeholder="Max35Text" CssClass="form-control-small"  /></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2"><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;Local Instrument</td>
                                            </tr>
                                            <tr>
                                                <td><label class="myChildRow">Proprietary</label></td>
                                                <td><asp:Label runat="server" ID="TxtLclInstrmPrtry" CssClass="form-control-small" MaxLength="35" /></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2"><p class="bg-info myChildHead"><span class="caret"></span>Category Purpose</td>
                                            </tr>
                                            <tr>
                                                <td><label class="myChildRow">Proprietary</label></td>
                                                <td><asp:TextBox runat="server" Width="50" ID="TxtCtgyPurpPrtry" CssClass="form-control-small" MaxLength="35"  /></td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
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
                                                    <asp:Label ID="LblSettlementCurrency" runat="server" CssClass="form-control-small" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                   Amount
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="LblIntrBkSttlmAmt" CssClass="form-control-small"/>
                                                   </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                   Date
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="TxtIntrBkSttlmDt" CssClass="form-control-small" MaxLength="10" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="panel panel-info">
                                    <div class="panel-heading"><h5 class="panel-title"><span class="caret"></span>&nbsp;&nbsp;Charge Bearer</h5></div>
                                    <div class="panel-body">
                                        <table class="table table-striped table-hover">
                                            <tr>
                                                <td>
                                                    <asp:RadioButtonList runat="server" ID="radioChargeBearer">
                                                        <asp:ListItem Text="Borne By Debtor [DEBT]" Value="DEBT" />
                                                        <asp:ListItem Text="Borne By Creditor [CRED]" Value="CRED" />
                                                        <asp:ListItem Text="Shared [SHAR]" Value="SHAR" />
                                                         <asp:ListItem Text="Service Level [SLEV]" Value="SLEV" />
                                                    </asp:RadioButtonList>  
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
                                                    <asp:TextBox runat="server" ID="TxtInstgAgtBICFI" CssClass="form-control-small" MaxLength="20" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><label class="myChildRow">Name</label></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="TxtInstgAgtNm" placeholder="Max140Text" CssClass="form-control-small" MaxLength="140"  />
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
                                                    <asp:TextBox runat="server" ID="TxtInstgAgtBranchId" placeholder="Max35Text" CssClass="form-control-small" MaxLength="35" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
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
                                                    <asp:TextBox runat="server" ID="TxtInstdAgtBICFI" CssClass="form-control-small" MaxLength="8" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><label class="myChildRow">Name</label></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="TxtInstdAgtNm" placeholder="Max140Text" CssClass="form-control-small" MaxLength="140"  />
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
                                                    <asp:TextBox runat="server" ID="TxtInstdAgtBranchId" placeholder="Max35Text"  CssClass="form-control-small" MaxLength="35" />
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
                                    <div class="panel-heading"><h5 class="panel-title"><span class="caret"></span>&nbsp;&nbsp;Debtor</h5></div>
                                    <div class="panel-body">
                                        <table class="table table-striped table-hover">
                                            <tr>
                                                <td>Name</td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="TxtDbtrNm" placeholder="Max140Text" CssClass="form-control-small" MaxLength="140"  />
                                                </td>
                                            </tr>
                                             <tr>
                                                <td><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;
                                                   Postal Address
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="TxtDbtrPstlAdr" Width="300px" placeholder="Max140Text" CssClass="form-control-small" MaxLength="140" />
                                                </td>
                                            </tr>                                            
                                            <tr>
                                                <td><label class="myChildRow">Street Name</label></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="TxtDbtrStrtNm" placeholder="Max70Text" CssClass="form-control-small" MaxLength="70" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><p class="bg-info "><span class="caret"></span>&nbsp;&nbsp;Town Name</td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="TxtDbtrTwnNm" placeholder="Max35Text"  CssClass="form-control-small" MaxLength="35" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><label class="myChildRow">Address Line</label></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="TxtDbtrAdrLine" Width="300px" placeholder="Max70Text"  CssClass="form-control-small" MaxLength="70" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><label class="myChildRow">Country</label></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="TxtDbtrCtry" placeholder="Max20Text"  CssClass="form-control-small" MaxLength="20"  />
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
                                                    <asp:Label runat="server" ID="lblDbtrAcctOthrId" CssClass="form-control-small"  />
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
                                                    <asp:TextBox runat="server" ID="TxtDbtrAgtBICFI" CssClass="form-control-small" MaxLength="8" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><label class="myChildRow">Name</label></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="TxtDbtrAgtNm" placeholder="Max140Text" CssClass="form-control-small" MaxLength="140" />
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
                                                    <asp:TextBox runat="server" ID="TxtDbtrAgtBranchId" placeholder="Max20Text"  CssClass="form-control-small" MaxLength="20"  />
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
                                                <td colspan="2"><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;Identification</td>
                                            </tr>
                                            <tr>
                                                <td colspan="2"><p class="bg-info my2ndChildHead"><span class="caret"></span>&nbsp;&nbsp;Other</td>
                                            </tr>
                                            <tr>
                                                <td><label class="my2ndChildRow">Identification</label></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="TxtDbtrAgtAcctOthrId" placeholder="Max35Text" CssClass="form-control-small" MaxLength="35" />
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
                                                    <asp:TextBox runat="server" ID="TxtDbtrAgtAcctPrtry" placeholder="Max35Text" CssClass="form-control-small" MaxLength="35" />
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
                                                    <asp:TextBox runat="server" ID="TxtCdtrAgtBICFI" CssClass="form-control-small" MaxLength="8" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><label class="myChildRow">Name</label></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="TxtCdtrAgtNm" placeholder="Max140Text" CssClass="form-control-small" MaxLength="140" />
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
                                                    <asp:TextBox runat="server" ID="TxtCdtrAgtBranchId" placeholder="Max20Text"  CssClass="form-control-small" MaxLength="20" />
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
                                                    <asp:TextBox runat="server" ID="TxtCdtrAgtAcctOthrId" placeholder="Max35Text" CssClass="form-control-small" MaxLength="35" />
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
                                                    <asp:TextBox runat="server" ID="TxtCdtrAgtAcctPrtry" placeholder="Max35Text" CssClass="form-control-small" MaxLength="35" />
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
                                                <td><asp:TextBox runat="server" ID="TxtCdtrNm" placeholder="Max140Text" CssClass="form-control-small" MaxLength="140" /></td>
                                            </tr>
                                             <tr>
                                                <td><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;Postal Address</td>
                                                 <td><asp:TextBox runat="server" ID="TxtCdtrPstlAdr" Width="300px" placeholder="Max140Text" CssClass="form-control-small" MaxLength="140" /></td>
                                            </tr>
                                             <tr>
                                                <td><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;Street Name</td>
                                                 <td><asp:TextBox runat="server" ID="TxtCdtrStrtNm" placeholder="Max70Text" CssClass="form-control-small" MaxLength="70"  /></td>
                                            </tr>
                                            <tr>
                                                <td><p class="bg-info myChildHead"><span class="caret"></span>&nbsp;&nbsp;Town Name</td>
                                                 <td><asp:TextBox runat="server" ID="TxtCdtrTwnNm" placeholder="Max35Text" CssClass="form-control-small" MaxLength="35" /></td>
                                            </tr>

                                            <tr>
                                                <td><label class="myChildRow">Address Line</label></td>
                                                <td><asp:TextBox runat="server" ID="TxtCdtrAdrLine" Width="300px" placeholder="Max70Text"  CssClass="form-control-small" MaxLength="70"  /></td>
                                            </tr>
                                            <tr>
                                                <td><label class="myChildRow">Country</label></td>
                                                <td><asp:TextBox runat="server" ID="TxtCdtrCtry" placeholder="Max20Text"  CssClass="form-control-small" MaxLength="20"  /></td>
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
                                                    <asp:TextBox runat="server" ID="TxtCdtrAcctOthrId" placeholder="Max34Text" CssClass="form-control-small" MaxLength="34" />
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
                                                    <asp:TextBox runat="server" ID="TxtCdtrAcctPrtry" placeholder="Max35Text" CssClass="form-control-small" MaxLength="35" />
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
                                    <div class="panel-heading"><h5 class="panel-title"><span class="caret"></span>&nbsp;&nbsp;Instruction For Next Agent</h5></div>
                                    <div class="panel-body">
                                        <table class="table table-striped table-hover">
                                            <tr>
                                                <td>Instruction Information</td>
                                                <td><asp:TextBox runat="server" ID="TxtInstrInf" Width="300px" placeholder="Max140Text" CssClass="form-control-small" MaxLength="140" /></td>
                                            </tr>
                                             <tr>
                                                <td>Orginator A/C Type</td>
                                                <td><asp:TextBox runat="server" ID="txtOrginatorACType" Width="300px" placeholder="Max30Text" CssClass="form-control-small" MaxLength="140" /></td>
                                            </tr>
                                            <tr>
                                                <td>Reciever A/C Type</td>
                                                <td><asp:TextBox runat="server" ID="txtRecieverACType" Width="300px" placeholder="Max30Text" CssClass="form-control-small" MaxLength="30" /></td>
                                            </tr>
                                            <tr>
                                                <td>Purpose Of Transaction</td>
                                                <td><asp:TextBox runat="server" ID="txtTransactionPurpose" Width="300px" placeholder="Max30Text" CssClass="form-control-small" MaxLength="30" /></td>
                                            </tr>
                                            <tr>
                                                <td>Other Information</td>
                                                <td><asp:TextBox runat="server" ID="txtOtherInf" Width="300px" placeholder="Max30Text" CssClass="form-control-small" MaxLength="30" /></td>
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
                                                <td>Unstructured</td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="TxtUstrd" Width="300px" placeholder="Max140Text" CssClass="form-control-small" MaxLength="140" />
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
                                                <td><asp:Label runat="server" ID="LblReturnReason" placeholder="Max140Text" CssClass="form-control-small" MaxLength="140" /></td>
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
                        </div>
                    </div>
            </div>   
                    <div class="panel panel-info">
                        <div class="panel-heading"><h5 class="panel-title">Receivers Information</h5></div>
                        <div class="panel-body">
                            <div style="float:left;margin-left:20px;clear:both">
                                    <asp:Button ID="btnSend" Text="Send" runat="server" CssClass="btn btn-success" OnClick="btnSend_Click" /></div>
                            <div style="float:left;margin-left:60px">
                                <asp:Button ID="btnDelete" Text="Delete" runat="server" CssClass="btn btn-danger" OnClick="btnDelete_Click"/></div>
                            <div style="float:left;margin-left:60px">
                                    <asp:Button ID="btnCancelTrans" Text="Cancel" runat="server" CssClass="btn btn-info" OnClick="btnCancelTrans_Click" /></div>
                        </div>
                     </div>
        </div>
    </div>
    </div>
</div>
</asp:Content>
