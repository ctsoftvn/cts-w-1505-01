<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true"
    CodeBehind="about-us.aspx.cs" Inherits="CTS.W._150501.Web.about_us" %>

<%@ Import Namespace="Resources" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="contentMain" ContentPlaceHolderID="contentMain" runat="server">
    <div class="wr-chitiet">
        <h1>
            <%= Strings.CLN_MASTER_ABOUTUS_TITLE %></h1>
        <div class="col-info">
            <asp:Literal runat="server" ID="ltDescription"></asp:Literal>
        </div>
    </div>
</asp:Content>
