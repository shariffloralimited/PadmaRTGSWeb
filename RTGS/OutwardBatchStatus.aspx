<%@ Page Title="Outward List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OutwardBatchStatus.aspx.cs" Inherits="RTGS.OutwardBatchStatus" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">     
      <div class="row">
        <div class="col-md-12">
            <section class="panel">
                <header class="panel-heading">
                    Outward List
                    <span class="tools pull-right">
                        <a href="javascript:;" class="fa fa-chevron-down"></a>

                    </span>
                </header>

                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-4">
                             <asp:DropDownList ID="BranchList" CssClass="form-control" runat="server" DataTextField="BranchName" DataValueField="RoutingNo" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <div class="col-md-4">
                             
                        </div>
                        <div class="col-md-4">
                           
                        </div>
                    </div>
                    <div class="mtop10"></div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="table-responsive">
                                <asp:GridView Id="MyDataGrid" CssClass="table  table-bordered table-striped table-hover"
	                            runat="server" 
	                            autogeneratecolumns="false" 
            	                ShowFooter="true" >
            	                <Columns>  
                                    <asp:BoundField DataField = "BatchName"   HeaderText="Batch"/>       
                                    <asp:BoundField DataField = "EntryDate"   HeaderText="Entry Date"/>       
                                    <asp:BoundField DataField = "TotalChecks" HeaderText="Total Item" />       
                                    <asp:BoundField DataField = "BatchTotal"  HeaderText="Batch Total"/>       
                                    <asp:BoundField DataField = "Scan"        HeaderText="Entry" />       
                                    <asp:BoundField DataField = "Maker"       HeaderText="Maker"/>       
                                    <asp:BoundField DataField = "OCE"         HeaderText="Sent"/>       
                                    <asp:BoundField DataField = "SettlementDate" HeaderText="SettlementDate"/>       
                                    <asp:BoundField DataField = "SettlementTime" HeaderText="Time"/>       
                                    <asp:BoundField DataField = "Status"      HeaderText="Status"/>       
                                    <asp:BoundField DataField = "Description" HeaderText="Description"/>       
                                    <asp:BoundField DataField = "Presented"   HeaderText="Presented" />       
                                    <asp:TemplateField  ItemStyle-Wrap="false" HeaderText="Presented">    
                                    <ItemTemplate>
                                        <a href='BranchChecks.aspx?BatchID=<%#DataBinder.Eval(Container.DataItem, "BatchID") %>'><%#DataBinder.Eval(Container.DataItem, "Presented") %></a>
                                    </ItemTemplate>
                                    </asp:TemplateField>                                        
                                    <asp:BoundField DataField = "Accepted"    HeaderText="Accepted"   />       
                                    <asp:TemplateField  ItemStyle-Wrap="false" HeaderText="Rejected">    
                                    <ItemTemplate>
                                        <a href='OCEAckItems.aspx?FileName=<%#DataBinder.Eval(Container.DataItem, "FileName") %>'><%#DataBinder.Eval(Container.DataItem, "Rejected") %></a>
                                    </ItemTemplate>
                                    </asp:TemplateField>                    
                                    <asp:BoundField DataField = "Waiting"     HeaderText="Waiting"/>       
           	                </Columns>
	                        </asp:GridView>
                            </div>
                           
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>  
</asp:Content>
