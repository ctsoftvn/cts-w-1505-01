<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true"
    CodeBehind="contact-us.aspx.cs" Inherits="CTS.W._150501.Web.contact_us" %>

<%@ Import Namespace="Resources" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="contentMain" ContentPlaceHolderID="contentMain" runat="server">
    <div class="wr-chitiet">
        <h1>
            <%= Strings.CLN_MASTER_CONTACTUS_TITLE%></h1>
        <div class="col-info">
            <asp:Literal runat="server" ID="ltDescription"></asp:Literal>
        </div>
        <div class="wr-lienhe">
            <div class="thongtin">
                <h2>
                    <asp:Literal runat="server" ID="ltCompanyName"></asp:Literal></h2>
                <p>
                    <span><strong>
                        <%= Strings.CLN_MASTER_ADDRESS_1%>:</strong></span><asp:Literal ID="ltAdderess1"
                            runat="server" />
                </p>
                <p>
                    <span><strong>
                        <%= Strings.CLN_MASTER_ADDRESS_2%>:</strong></span><asp:Literal ID="ltAdderess2"
                            runat="server" />
                </p>
                <p>
                    <span><strong>
                        <%= Strings.CLN_MASTER_PHONE%>:</strong></span>
                    <asp:Literal ID="ltPhone" runat="server" /></p>
                <p>
                    <span><strong>
                        <%= Strings.CLN_MASTER_EMAIL_ADDRESS%>:</strong></span><asp:Literal ID="ltEmail"
                            runat="server" /></p>
                <p>
                    <span><strong>
                        <%= Strings.CLN_MASTER_WEBSITE%>:</strong></span><asp:Literal ID="ltWebsite" runat="server" /></p>
            </div>
            <h4>
                <%= Strings.CLN_MASTER_CONTACTUS%></h4>
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
                        Display="Dynamic" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </li>
                <li>
                    <label>
                        <%= Strings.CLN_MASTER_MAIL_EMAIL%></label>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="*" ControlToValidate="txtEmail"
                        Display="Dynamic" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="This information is invalid"
                        ControlToValidate="txtEmail" Display="Dynamic" ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
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
                    <asp:Button ID="btnReset" runat="server" CssClass="button" OnCommand="btnReset_Command"/>
                </li>
            </ul>
        </div>
    </div>
</asp:Content>
