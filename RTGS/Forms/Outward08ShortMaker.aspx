<%@ Page Title="" Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="Outward08ShortMaker.aspx.cs" Inherits="RTGS.Forms.Outward08ShortMaker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <script type="text/javascript">
    <%-- function ViewSignature() {
         var str = 'ViewSignature.aspx?AccountNo=<%=AccountNo %>'
    	    window.open(str, 'Signature', 'scrollbars=no,width=600,height=600,left=50,top=50');
    	}--%>
   	    </script>

    <div class="row">
        <div class="col-md-12">
            <section class="panel">
            <div class="panel panel-primary">
                <header class="panel-heading"><h3 class="panel-title"><b>FI To FI Customer Credit Transfer</b></h3></header>
                <div class="panel-body">
                    <div class="panel panel-info">
                        <div class="panel-heading"><h5 class="panel-title">Senders Information</h5></div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-8">
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Transaction Type</span>
                                            <div class="col-sm-4">
                                                <asp:DropDownList runat="server" ID="ddlCtgyPurpPrtry"  AutoPostBack="true" DataTextField="TTCType" DataValueField="TTCCode" CssClass="form-control" OnSelectedIndexChanged="ddlCtgyPurpPrtry_SelectedIndexChanged" >
                                                  </asp:DropDownList>
                                            </div>
                                            </div>
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Branch</span>
                                            <div class="col-sm-7">
                                                <asp:DropDownList runat="server" ID="ddlSendBranch" CssClass="form-control" DataTextField="BranchName" DataValueField="RoutingNo" ></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Account Number</span>
                                            <div class="col-sm-7">
                                                <asp:TextBox runat="server" ID="txtAccountNo" CssClass="form-control" MaxLength="34"  placeholder="Sender's Account Number" />
                                            </div>
                                            <div class="col-sm-2">
                                                <asp:Button Text="Get A/C Info" ID="btnGetInfo" CssClass="btn btn-success" runat="server" CausesValidation="false" OnClick="btnGetInfo_Click" />
                                                
                                                <%--<a id="ViewSignature" href="javascript:ViewSignature()">ViewSignature</a>--%>
                                                <%--<a id="ViewSignature" href="ViewSignature.aspx">ViewSignature</a>--%>
                                               
                                            </div>

                                        </div>
                                        <div class="form-group" id="ActNameDiv" runat="server" visible="true">
                                            <span class="col-sm-3 control-label">Account Name</span>
                                            <div class="col-sm-7">
                                                <asp:TextBox runat="server" ID="txtAccountName" Enabled="true" CssClass="form-control" MaxLength="34" placeholder="Sender's Name" />
                                            </div>
                                            <div class="col-sm-2">
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAccountName" 
                                                 CssClass="normal-red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                        <span class="col-sm-3 control-label">Currency</span>
                                        <div class="col-sm-7">
                                            <asp:DropDownList runat="server" ID="ddlCurrency" CssClass="form-control">
                                                <asp:ListItem Text="BDT" Value="BDT" />
                                                <asp:ListItem Text="USD" Value="USD" />
                                                <asp:ListItem Text="CAD" Value="CAD" />
                                                <asp:ListItem Text="EUR" Value="EUR" />
                                                <asp:ListItem Text="GBP" Value="GBP" />
                                                <asp:ListItem Text="YEN" Value="YEN" />
                                            </asp:DropDownList>
                                        </div>
                                        </div>
                                        <div class="form-group">
                                        <span class="col-sm-3 control-label">Sending Amount</span>
                                        <div class="col-sm-7"><asp:TextBox runat="server" ID="txtSettlmentAmount" placeholder="Min: 1 Lac Max:1000 Cr" CssClass="form-control"  Display="Dynamic" AutoPostBack="true" OnTextChanged="txtSettlmentAmount_txtChanged" /></div>
                                        <div class="col-sm-2">
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSettlmentAmount" 
                                                 CssClass="normal-red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                             <asp:RangeValidator id="RangeCheck1" runat="server" ControlToValidate="txtSettlmentAmount"
                                                Type="Double" Minimum="100000.00" MaximumValue="10000000000.00" CssClass="normal-red" 
                                                 ErrorMessage="Min: One Lac- Max: 1000 Cr" Display="Dynamic" />
                                        </div>
                                        <div class="form-group">
                                              <span class="col-sm-3 control-label"></span>
                                              <span class="col-sm-7 control-label" style="text-align:left">
                                              <asp:Label ID="lblAmount" runat="server" ForeColor="Red" /></span>
                                        </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-3"></div>
                                            <div class="col-sm-7">
                                                <asp:CheckBox ID="ChkChargeWaived" runat="server" CssClass="form-control" Text=" Charges Waived" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-3">
                                            </div>
                                            <div class="col-md-3">
                                            <asp:Label ID="lblMsg" CssClass="normal-red" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div>
                                        <asp:Label ID="lblAccountInfo" runat="server" />
                                    </div>
                                </div>

                                <div>
                                  <%--  <a id="ViewSignature" href="javascript:ViewSignature()">
                                         <asp:Image ID="Sigimages" height='150px' width='250px' alt='Signature Not Found' runat="server" />
                                    </a>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <h5 class="panel-title">Receivers Information</h5>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-8">
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Receiving Bank</span>
                                             <div class="col-sm-7">
                                                 <asp:DropDownList ID="ddListReceivingBank" CssClass="form-control" runat="server" DataTextField="BankName" DataValueField="BIC" OnSelectedIndexChanged="ddListReceivingBank_SelectedIndexChanged" AutoPostBack="true" />
                                             </div>
                                        </div>
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Receiving Branch</span>
                                             <div class="col-sm-7">
                                                 <asp:DropDownList ID="ddListBranch" runat="server" CssClass="form-control"  DataTextField="BranchName" DataValueField="RoutingNo" AutoPostBack="true" OnSelectedIndexChanged="ddListBranch_SelectedIndexChanged" />
                                             </div>
                                            <div class="col-sm-2">
                                                <asp:TextBox ID="txtRoutingNo" runat="server" MaxLength="9" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRoutingNo"  CssClass="normal-red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Receiver's Name</span>
                                             <div class="col-sm-7">
                                                 <asp:TextBox ID="txtReceiverName" MaxLength="120" runat="server" CssClass="form-control" />
                                             </div>
                                            <div class="col-sm-2">
                                                <asp:RequiredFieldValidator ID="ReqtxtReceiverName" runat="server" autocomplete="off" ControlToValidate="txtReceiverName" EnableViewState="false"  CssClass="normal-red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Receiver's Account No</span>
                                             <div class="col-sm-7">
                                                 <asp:TextBox ID="txtReceiverAccountNo" MaxLength="34" runat="server" CssClass="form-control" />
                                             </div>
                                            <div class="col-sm-2">
                                                <asp:RequiredFieldValidator ID="ReqTxtReceiverID" CssClass="normal-red" runat="server" autocomplete="off" ControlToValidate="txtReceiverAccountNo" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <asp:Panel ID="CustomDutyPanel" runat="server">
                                        <!-------->
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Custom Office Code</span>
                                             <div class="col-sm-7">
                                                 <asp:TextBox ID="txtCustomOfficeCD" MaxLength="3" runat="server" Width="300px" CssClass="form-control" placeholder ="3 Digit"/>
                                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtCustomOfficeCD" runat="server" ErrorMessage="Only Numbers allowed" ForeColor="Red"  ValidationExpression="\d+"></asp:RegularExpressionValidator>
                                             </div>
                                            <div class="col-sm-2">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" CssClass="normal-red" runat="server" ControlToValidate="txtCustomOfficeCD" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Registration Year</span>
                                             <div class="col-sm-7">
                                                 <asp:TextBox ID="txtRegYr" MaxLength="4" runat="server"  Width="300px" CssClass="form-control" placeholder ="4 Digit"/>
                                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtRegYr" runat="server" ErrorMessage="Only Numbers allowed" ForeColor="Red"  ValidationExpression="\d+"></asp:RegularExpressionValidator>
                                             </div>
                                            <div class="col-sm-2">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="normal-red" runat="server" ControlToValidate="txtRegYr" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Registration Number</span>
                                             <div class="col-sm-7">
                                                 <asp:TextBox ID="txRegNumber" MaxLength="12" runat="server"  Width="300px" CssClass="form-control" placeholder ="Maximum 12 Digit" />
                                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txRegNumber" runat="server" ErrorMessage="Only Numbers allowed" ForeColor="Red" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                                             </div>
                                            <div class="col-sm-2">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="normal-red" runat="server" ControlToValidate="txRegNumber" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Declarant Code</span>
                                             <div class="col-sm-7">
                                                 <asp:TextBox ID="txtDeclarantCD" MaxLength="18" runat="server" Width="300px" CssClass="form-control" placeholder ="Maximum 18 Digit"/>
                                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtDeclarantCD" runat="server" ErrorMessage="Only Numbers allowed" ForeColor="Red"  ValidationExpression="\d+"></asp:RegularExpressionValidator>

                                             </div>
                                            <div class="col-sm-2">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" CssClass="normal-red" runat="server" ControlToValidate="txtDeclarantCD" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <span class="col-sm-3 control-label">Customer Mobile Number</span>
                                             <div class="col-sm-7">
                                                 <asp:TextBox ID="txtCustomerMobile" MaxLength="11" runat="server"  Width="300px" CssClass="form-control" placeholder ="11 Digit" />
                                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txtCustomerMobile" runat="server" ErrorMessage="Only Numbers allowed" ForeColor="Red"  ValidationExpression="\d+"></asp:RegularExpressionValidator>

                                             </div>
                                            <div class="col-sm-2">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="normal-red" runat="server" ControlToValidate="txtCustomerMobile" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <!-------->
                                        </asp:Panel>
                                        <div class="form-group" runat="server" id="UnstructDiv">
                                            <span class="col-sm-3 control-label">Unstructured Information</span>
                                            <div class="col-sm-7">
                                                 <asp:TextBox ID="txtReasonForPayment" MaxLength="34" placeholder ="Maximum Character 34 Digit And Special Character Not Allowed" runat="server" CssClass="form-control"/>
                                            </div>
                                            <div class="col-sm-2">
                                                <asp:RequiredFieldValidator ID="ReqtxtReasonForPayment" runat="server" ControlToValidate="txtReasonForPayment"  CssClass="normal-red" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                             <span class="col-sm-3 control-label">Charge Bearer</span>
                                             <div class="col-sm-7">
                                                 <asp:RadioButtonList runat="server" ID="radioChargeBearer1">
                                                    <asp:ListItem Text="Borne By Debtor [DEBT]" Value="DEBT" />
                                                    <asp:ListItem Text="Borne By Creditor [CRED]" Value="CRED" />
                                                    <asp:ListItem Text="Shared [SHAR]" Value="SHAR" Selected="True"/>
                                                     </asp:RadioButtonList>
                                             </div>
                                        </div>

                                        <div class="form-group">
                                             <div class="col-sm-5">
                                                 <asp:Button ID="btnSend" Text="Save and Continue" Visible="true" runat="server" OnClick="btnSave_Click" CssClass="btn btn-success" />
                                             </div>
                                             <div class="col-sm-5">
                                                 <asp:Button ID="btnCancelTrans" Text="Cancel Transaction" runat="server" CssClass="btn btn-info" CausesValidation="false" OnClick="btnCancelTrans_Click" />
                                             </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
               </div>
            </section>
        </div>
    </div>
</asp:Content>
