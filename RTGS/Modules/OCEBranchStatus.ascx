<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="OCEBranchStatus.ascx.cs" Inherits="RTGS.modules.OCEBranchStatus" %>
<div class="row">
    <div class="col-md-12">
        <div class="table-responsive" style="height:125px;overflow-y:scroll">
            <DIV id="OCEBranchViewDiv" runat="server">
            <asp:GridView ID="BranchGrid" runat="server" 
                CssClass="table  table-bordered table-striped table-hover margin-bottome-0" HeaderStyle-HorizontalAlign="Center"
                AutoGenerateColumns="False"  ShowHeader="true" ShowFooter="false"   >       
               <Columns>
                   <asp:TemplateField HeaderText="Branch"  ItemStyle-Width="100px">
                        <ItemTemplate>
                            <a href='OutwardList.aspx?SelectedBranch=<%#DataBinder.Eval(Container.DataItem, "SendingBranchID")%>'><%#DataBinder.Eval(Container.DataItem, "BranchName")%></a>
                        </ItemTemplate>
                   </asp:TemplateField>                   
                   <asp:BoundField  DataField = "Maker"      HeaderText="Mkr"      ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" />    
                   <asp:BoundField  DataField = "Checker"    HeaderText="Chkr"     ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" />
                   <asp:BoundField  DataField = "Authorizer"    HeaderText="Athr"      ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center"  />
                   <asp:BoundField  DataField = "CBS"    HeaderText="CBS"      ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center"  />
                   <asp:BoundField  DataField = "Admin"      HeaderText="Adm"      ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center"  />
                   <asp:BoundField  DataField = "STP"       HeaderText="STP"      ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" />
                   <asp:BoundField  DataField = "Rejected"   HeaderText="Rej"      ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" />
                   <asp:BoundField  DataField = "Queued"     HeaderText="Que"      ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" />
                   <asp:BoundField  DataField = "Canceled"   HeaderText="Cncl"     ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" />
                   <asp:BoundField  DataField = "Completed"  HeaderText="Cmpl"     ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" />
                </Columns>
           </asp:GridView>
           </DIV>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-md-12">
        <div class="table-responsive">
            <table Class="table  table-bordered table-striped table-hover margin-bottome-0">
                <tr>
                    <td style="width:95px"><asp:Label ID="Branch" runat="server" /></td>
                    <td style="width:60px;text-align:center;font-weight:bold"><asp:Label ID="Maker"      runat="server" /></td>
                    <td style="width:60px;text-align:center;font-weight:bold"><asp:Label ID="Checker"    runat="server" /></td>
                    <td style="width:60px;text-align:center;font-weight:bold" id="AuthCol" runat="server"><asp:Label ID="Authorizer"    runat="server" /></td>
                    <td style="width:60px;text-align:center;font-weight:bold"><asp:Label ID="Debited"    runat="server" /></td>            
                    <td style="width:60px;text-align:center;font-weight:bold" id="admincol" runat="server"><a id="Admin"  runat="server"></a></td>
                    <td style="width:60px;text-align:center;font-weight:bold"><asp:Label ID="Sent"       runat="server" /></td>
                    <td style="width:60px;text-align:center;font-weight:bold"><asp:Label ID="Rejected"   runat="server" /></td>   
                    <td style="width:60px;text-align:center;font-weight:bold"><asp:Label ID="Queued"     runat="server" /></td>   
                    <td style="width:60px;text-align:center;font-weight:bold"><asp:Label ID="Canceled"   runat="server" /></td>   
                    <td style="width:70px;text-align:center;font-weight:bold"><asp:Label ID="Completed"  runat="server" /></td>  
                    <td style="width:18px;"></td>  
               </tr>
            </table>
        </div>
    </div>
</div>

