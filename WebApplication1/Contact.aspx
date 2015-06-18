<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebApplication1.Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1>Contact Us:</h1>
    </hgroup>

    <section class="contact">
        <header>
            <h3>Company Phone:</h3>
        </header>
        <p>
            <span class="label">Main:</span>
            02-8000666
        </p>
        <p>
            <span class="label">Fax:</span>
            02-8000667
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Email:</h3>
        </header>
        <p>
            <span class="label">Support:</span>
            <a href="mailto:eventSupport@gmail.com">eventSupport@gmail.com</a>&nbsp;
        </p>
        <p>
            <span class="label">Marketing:</span>
            <a href="mailto:Marketing@example.com">eventsMaster@gmail.com</a></p>
        <p>
            <span class="label">Tal Biton E-mail:</span>
            <a href="mailto:tb_bit@walla.com">tb_bit@walla.com</a>
        </p>
         <p>
            <span class="label">Matan Bar-Yosef E-mail:</span>
            <a href="mailto:matan@gmail.com">matan@gmail.com</a>
        </p>
         <p>
            <span class="label">Elad Zada E-mail:</span>
            <a href="mailto:elad@gmail.com">elad@gmail.com</a>
        </p>
        <header>
            <h3>Address:</h3>
        </header>
        <p>
            Ha'histadrot street
        </p>
        <p>
            House Number: 22</p>
        <p>
            Jerusalem Israel.</p>
    </section>
</asp:Content>