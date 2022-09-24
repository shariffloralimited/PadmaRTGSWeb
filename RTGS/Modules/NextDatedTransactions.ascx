<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="NextDatedTransactions.ascx.cs" Inherits="RTGS.modules.NextDatedTransactions" %>

<%--<div class="row">
    <div class="col-md-12">
        <div class="table-responsive" style="height:70px;overflow-y:scroll">
             <div id="SettlementViewDiv">
             <asp:GridView ID="SettlementGrid" runat="server" CssClass=" table  table-bordered table-striped table-hover" 
                AutoGenerateColumns="False"  ShowHeader="true" ShowFooter="false" 
                 >
               <Columns>
                    <asp:BoundField  DataField = "Name" HeaderText="Bank"/>
                   <asp:BoundField  DataField = "Outward"  HeaderText="Outward"/>
                   <asp:BoundField  DataField = "Amount"  HeaderText="Amount"/>
               </Columns>	
           </asp:GridView>
           </div>
        </div>
    </div>
</div>--%>
<div class="row">
    <div class="col-md-12">
        <div class="table-responsive">
            <table Class="table  table-bordered table-striped table-hover margin-bottome-0">
                <tr>
                    <td><b>Settlement Date</b></td>
                    <td style="text-align:center"><b>Qty</b></td>
                    <td style="text-align:right"><b>Amount</b></td>
                    <td width="15px"></td>
               </tr>
                <tr>
                    <td>22/07/2015</td>
                    <td style="text-align:center">2</td>
                    <td style="text-align:right">10,000.00</td>
                    <td width="15px"></td>
                </tr>
                 <tr>
                     <td>23/07/2015</td>
                     <td style="text-align:center">10</td>
                     <td style="text-align:right">50,00,000.00</td>
                     <td width="15px"></td>
                </tr>
                 <tr>
                    <td>24/07/2015</td>
                    <td style="text-align:center">20</td>
                    <td style="text-align:right">10,00,000.00</td>
                    <td width="15px"></td>
                 </tr>
            </table>
        </div>
    </div>
</div>




























