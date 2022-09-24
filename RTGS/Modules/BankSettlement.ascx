<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="BankSettlement.ascx.cs" Inherits="RTGS.modules.BankSettlement" %>
    <div class="row">
    <div class="col-md-12">
        <div class="table-responsive" style="height:125px;overflow-y:scroll">
             <div id="SettlementViewDiv">
             <asp:GridView ID="SettlementGrid" runat="server" 
                 CssClass=" table  table-bordered table-striped table-hover margin-bottome-0" 
                AutoGenerateColumns="False"  CellPadding="5" ShowHeader="true" ShowFooter="false">
               <Columns>
                   <asp:BoundField  DataField = "Name"  HeaderText="Bank"   ItemStyle-Width="140px" ItemStyle-HorizontalAlign="Left"  HeaderStyle-HorizontalAlign="Center" />
                   <asp:BoundField  DataField = "iOCE"  HeaderText=""        ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" />
                   <asp:BoundField  DataField = "OCE"   HeaderText="Outward" DataFormatString="{0:N}" ItemStyle-Width="140px" ItemStyle-HorizontalAlign="Right"  HeaderStyle-HorizontalAlign="Center" />
                   <asp:BoundField  DataField = "iICE"  HeaderText=""       ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" />
                   <asp:BoundField  DataField = "ICE"   HeaderText="Inward" DataFormatString="{0:N}" ItemStyle-Width="140px" ItemStyle-HorizontalAlign="Right"  HeaderStyle-HorizontalAlign="Center" />
               </Columns>	
           </asp:GridView>
           </div>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-md-12">
        <div class="table-responsive">
            <table Class="table  table-bordered table-striped table-hover margin-bottome-0">
                <tr>
                    <td style="width:140px;text-align:center;font-weight:bold"><asp:Label ID="LblTotal"   CssClass="font-weight:bold" runat="server" /></td>
                    <td style="width:80px;text-align:center;font-weight:bold"><asp:Label ID="iOCE"        CssClass="font-weight:bold" runat="server"  /></td>
                    <td style="width:140px;text-align:right;font-weight:bold"><asp:Label ID="OCE"         CssClass="font-weight:bold" runat="server"  /></td>
                    <td style="width:80px;text-align:center;font-weight:bold"><asp:Label ID="iICE"        CssClass="font-weight:bold" runat="server"  /></td>
                    <td style="width:140px;text-align:right;font-weight:bold"><asp:Label ID="ICE"         CssClass="font-weight:bold" runat="server"  /></td>
                    <td style="width:15px;"></td>  
                </tr>
            </table>
        </div>
    </div>
</div>

