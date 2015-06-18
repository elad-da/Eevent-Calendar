<%@ Page EnableEventValidation="false" Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageEvent.aspx.cs" Inherits="WebApplication1.Account.ManageEvent" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
       <section class="featured">
         <div class="content-wrapper">
            <hgroup class="title">
                <h1>Creating New Event</h1>
            </hgroup>
            <p>
                Please fill the following form to create new Event.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Type Of Eent:</h3>
    <p>&nbsp;</p>
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <asp:DropDownList ID="DropDownList" runat="server" Font-Bold="True" Font-Italic="True" Height="30px" Width="250px">
                <asp:ListItem>Select Event</asp:ListItem>
                <asp:ListItem>Bar-Mitzva</asp:ListItem>
                <asp:ListItem>BirthDay</asp:ListItem>
                <asp:ListItem>Henna</asp:ListItem>
                <asp:ListItem>Circumcision</asp:ListItem>
                <asp:ListItem>Wedding</asp:ListItem>
                <asp:ListItem>Other...</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEvent" runat="server" Font-Size="Large" ControlToValidate="DropDownList" CssClass="field-validation-error" ErrorMessage="Type Of The Evenet Required." InitialValue="Select Event"></asp:RequiredFieldValidator>
            &nbsp;
        </ContentTemplate>
    </asp:UpdatePanel>
    <p>&nbsp;&nbsp;</p>
    <p>
        <asp:Label ID="LabelOther" runat="server" Font-Bold="True" Font-Size="Medium" Text="Other Type Of Event:" style="text-align: left"></asp:Label>
    </p>
    <form>
        <p>
            <asp:TextBox ID="TextBoxOther" runat="server" Height="22px" Width="240px"></asp:TextBox>&nbsp;&nbsp;&nbsp;</p>
        <p>
            &nbsp;<asp:Label ID="lableOtherChose" runat="server" Font-Bold="True" Font-Size="Large" CssClass="field-validation-error" Text="You can fill this field only if option other is chosen in the list." Visible="False"></asp:Label>
        </p>
        <h3 class="auto-style1">Date Of The Event:</h3>
        <p>
            <asp:TextBox ID="TextBoxDate" runat="server" Height="22px" TextMode="Date" Width="240px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDate" runat="server" Font-Size="Large" ControlToValidate="TextBoxDate" CssClass="field-validation-error" ErrorMessage="RequiredFieldValidator">Date Of The Event Required.</asp:RequiredFieldValidator>
        </p>
        <p>
            &nbsp;</p>
        <p>&nbsp;</p>
    &nbsp;<asp:Button ID="ButtonSubmit" runat="server" OnClick="ButtonSubmit_Click" Text="Submit" />
    </form>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            text-align: left;
        }
    </style>
</asp:Content>

