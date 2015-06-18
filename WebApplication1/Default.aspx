<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>Wellcome to T.M.E Company website <%: Title %>.</h1>
            </hgroup>
            <p>
                <h3>If you are a member just log in , Not a member yet? please Register.</h3>
            </p>
        </div>
    </section>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h1>Why you should use our company to organize your events:</h1>
    <ol class="round">
        <li class="one">
            <h2>Our service is for FREE!</h2>
            <h3>You read it right, our website service is for FREE! We dont charge you for our service, We do it for free and with all one's heart.</h3>
        </li>
        <li class="two">
            <h2>Because we are the BEST!</h2>
            <h3>We managed over 1,000 events all over the years. Contact us and we will send you a feedback of our customers about our service.</h3>
        </li>
        <li class="three">
            <h2>Because our TECHNOLOGY!</h2>
            <h3>We use the best and advanced technology to organize your events.</h3>
        </li>
         <li class="four">
            <h2>It will give you spare TIME!</h2>
            <h3>When we do all the arrangements for you, Your head will be free to do other stuff.</h3>
        </li>
    </ol>
    </asp:Content>

