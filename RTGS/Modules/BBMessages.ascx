<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="BBMessages.ascx.cs" Inherits="RTGS.modules.BBMessages" %> 
<div class="row">
    <div class="col-md-12">
        <div class="table-responsive" style="height:105px;overflow-y:scroll">
             <asp:GridView ID="MyDataGrid" runat="server" CssClass=" table  table-bordered table-striped table-hover margin-bottome-0" 
                AutoGenerateColumns="False"  CellPadding="5" ShowHeader="true" ShowFooter="false">
               <Columns>
                   <asp:HyperLinkField DataTextField="Time" DataNavigateUrlFormatString="../XslTransform.aspx?FormName={0}&BBID={1}"  Target="_new" HeaderText="Time" DataNavigateUrlFields="Form, BBID" /> 
                   <asp:BoundField  DataField = "Form" HeaderText="MsgType"         ItemStyle-Width="100px"  />
                   <asp:BoundField  DataField = "Message"  HeaderText="Message" />
               </Columns>	
           </asp:GridView>
        </div>
    </div>
</div>


















