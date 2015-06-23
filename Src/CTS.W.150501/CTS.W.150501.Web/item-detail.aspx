<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true"
    CodeBehind="item-detail.aspx.cs" Inherits="CTS.W._150501.Web.item_detail" %>

<%@ Import Namespace="CTS.Web.Com.Domain.Helper" %>
<%@ Import Namespace="CTS.Com.Domain.Model" %>
<%@ Import Namespace="Resources" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="contentMain" ContentPlaceHolderID="contentMain" runat="server">
    <div>
        <!-- CONTENT -->
        <div class="wr-chitiet">
            <h1>
                <asp:Literal ID="ltTitle" runat="server" Text=""></asp:Literal>
            </h1>
            <div class="col-left">
                <asp:Literal ID="ltDescription" runat="server" Text=""></asp:Literal>
                <div class="wr-datlich">
                    <h4>
                        <%= Strings.CLN_MASTER_ITEMDETAIL_EMAIL_SUBJECT%></h4>
                    <ul class="contact_form">
                        <li>
                            <label>
                                <%= Strings.CLN_MASTER_MAIL_NAME%></label>
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="*" ControlToValidate="txtName"
                                Display="Dynamic" ForeColor="#FF3300" CssClass="alert_textbox_inputText"></asp:RequiredFieldValidator>
                        </li>
                        <li>
                            <label>
                                <%= Strings.CLN_MASTER_MAIL_PHONE%></label>
                            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ErrorMessage="*" ControlToValidate="txtPhone"
                                Display="Dynamic" ForeColor="#FF3300" CssClass="alert_textbox_inputText"></asp:RequiredFieldValidator>
                        </li>
                        <li>
                            <label>
                                <%= Strings.CLN_MASTER_MAIL_EMAIL%></label>
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="*" ControlToValidate="txtEmail"
                                Display="Dynamic" ForeColor="#FF3300" CssClass="alert_textbox_inputText"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="This information is invalid"
                                ControlToValidate="txtEmail" CssClass="alert_textbox_inputText" Display="Dynamic" ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </li>
                        <li>
                            <label>
                                <%= Strings.CLN_MASTER_MAIL_DES%></label>
                            <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" Columns="30"
                                Rows="5"></asp:TextBox>
                        </li>
                        <li>
                            <label>
                                &nbsp;</label>
                            <asp:Button ID="btnSubmit" runat="server" CssClass="button" OnCommand="btnSubmit_Command" />
                                <input id="Reset1" class="reset" onclick="hideValidator(); ResetForm();" type="button" value='<%= Strings.CLN_BTN_RESER%>' />
                        </li>
                    </ul>
                </div>
            </div>
            <div class="col-right">
                <asp:Repeater ID="rptItemsRelated" runat="server">
                    <HeaderTemplate>
                        <ul class="wr-product-ct">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li class="element-ct">
                            <div class="inner">
                                <a href='<%# "/" + WebContextHelper.LocaleCd + "/dich-vu/chi-tiet/" + ((HashMap)Container.DataItem)["LinkName"] %>'
                                    title='<%# ((HashMap)Container.DataItem)["ItemName"] %>'>
                                    <img src='<%# ((HashMap)Container.DataItem)["ItemImage"] %>' />
                                </a>
                            </div>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
