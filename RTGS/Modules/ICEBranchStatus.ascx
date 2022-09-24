<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="ICEBranchStatus.ascx.cs" Inherits="RTGS.modules.ICEBranchStatus" %>
    <div class="row">
    <div class="col-md-12">
        <div class="table-responsive" style="height:125px;overflow-y:scroll">
             <div id="ICEBranchViewDiv">
            <asp:GridView ID="BranchGrid" runat="server" CssClass=" table  table-bordered table-striped table-hover margin-bottome-0" 
                AutoGenerateColumns="False"  ShowHeader="true" ShowFooter="true" >
               <Columns>
                    <asp:TemplateField HeaderText="Branch"   ItemStyle-Width="140px">
                        <ItemTemplate>
                            <a href='InwardList.aspx?SelectedBranch=<%#DataBinder.Eval(Container.DataItem, "SendingBranchID")%>'><%#DataBinder.Eval(Container.DataItem, "BranchName")%></a>
                        </ItemTemplate>
                    </asp:TemplateField>                   
                    <asp:BoundField  DataField = "Received"   HeaderText="Received"     ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField  DataField = "Approved"   HeaderText="Approved"     ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField  DataField = "Maker"      HeaderText="Maker"        ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField  DataField = "Checker"    HeaderText="Checker"      ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField  DataField = "Authorizer" HeaderText="Authrzr"      ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center"  />
                    <asp:BoundField  DataField = "Reversed"   HeaderText="Reversed"     ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" />
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
                    <td style="width:140px"><b>Total</b></td>
                    <td style="width:80px;text-align:center;font-weight:bold"><asp:Label ID="Received"  runat="server" /></td>
                    <td style="width:80px;text-align:center;font-weight:bold"><asp:Label ID="Approved"  runat="server" /></td>
                    <td style="width:80px;text-align:center;font-weight:bold"><asp:Label ID="Maker"     runat="server" /></td>
                    <td style="width:80px;text-align:center;font-weight:bold"><asp:Label ID="Checker"   runat="server" /></td>
                    <td style="width:60px;text-align:center;font-weight:bold" id="AuthCol" runat="server"><asp:Label ID="Authorizer"    runat="server" /></td>
                    <td style="width:80px;text-align:center;font-weight:bold"><asp:Label ID="Reversed"  runat="server" /></td>  
                    <td style="width:15px;"></td>        
               </tr>
            </table>
        </div>
    </div>
</div>
























