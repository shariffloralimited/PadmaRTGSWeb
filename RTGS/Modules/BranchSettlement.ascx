<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="BranchSettlement.ascx.cs" Inherits="RTGS.modules.BranchSettlement" %>
  <div class="row">
    <div class="col-md-12">
        <div class="table-responsive" style="height:125px;overflow-y:scroll">
             <div id="SettlementViewDiv">
             <asp:GridView ID="SettlementGrid" runat="server" CssClass=" table  table-bordered table-striped table-hover margin-bottome-0" 
                AutoGenerateColumns="False"  CellPadding="5" ShowHeader="true" ShowFooter="false">
               <Columns>
                   <asp:BoundField  DataField = "Name" HeaderText="Branch"     ItemStyle-Width="140px"  ItemStyle-HorizontalAlign="Left"    HeaderStyle-HorizontalAlign="Left" />
                   <asp:BoundField  DataField = "iOCE" HeaderText=""           ItemStyle-Width="100px"  ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" />
                   <asp:BoundField  DataField = "OCE"  HeaderText="Outward"    ItemStyle-Width="140px"  ItemStyle-HorizontalAlign="Right"   HeaderStyle-HorizontalAlign="Right" DataFormatString="{0:N}"/>
                   <asp:BoundField  DataField = "iICE" HeaderText=""           ItemStyle-Width="100px"  ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" />
                   <asp:BoundField  DataField = "ICE"  HeaderText="Inward"     ItemStyle-Width="140px"  ItemStyle-HorizontalAlign="Right"   HeaderStyle-HorizontalAlign="Right" DataFormatString="{0:N}"/>
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
                   <td style="width:140px;text-align:left;font-weight:bold"><asp:Label ID="LblTotal" runat="server" /></td>
                   <td style="width:100px;text-align:center;font-weight:bold"><asp:Label ID="iOCE"  runat="server" /></td>
                   <td style="width:140px;text-align:right;font-weight:bold"><asp:Label ID="OCE"   runat="server" /></td>
                   <td style="width:100px;text-align:center;font-weight:bold"><asp:Label ID="iICE"  runat="server" /></td>
                   <td style="width:140px;text-align:right;font-weight:bold"><asp:Label ID="ICE"   runat="server" /></td>
                   <td style="width:15px;"></td>
               </tr>
            </table>
        </div>
    </div>
</div>
























