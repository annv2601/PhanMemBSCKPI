<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BSCKPI.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8"/>
    <meta http-equiv="x-ua-compatible" content="ie=edge"/>
    
    <meta name="viewport" content="width=device-width, initial-scale=1"/>

    <link rel="stylesheet" href="resource/css/main.css" />
    <link rel="shortcut icon" href="favicon.ico" />

    <script src="resource/js/perfect-scrollbar.min.js?0.6.8"></script>
    <script src="resource/js/main.js"></script>
</head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server" Theme="Neptune" />

    <ext:Viewport runat="server" Layout="BorderLayout">
        <Items>
            <ext:Container
                ID="RedirectOverlay"
                runat="server"
                Cls="redirect-overlay"
                WidthSpec="80%"
                Modal="true"
                Floating="true">
                <LayoutConfig>
                    <ext:VBoxLayoutConfig Align="Stretch" />
                </LayoutConfig>
                <Items>
                    <ext:Component
                        Cls="redirect-overlay-body"
                        runat="server"
                        Html="<p>Looks like you are browsing from a phone or a tablet device. Would you like to redirect to Ext.NET Mobile examples?</p>"/>

                    <ext:Button
                        runat="server"
                        Text="Redirect"
                        Flex="1"
                        Handler="onRedirect" />

                    <ext:Button
                        runat="server"
                        Text="Stay here"
                        Flex="1"
                        Handler="onStay" />

                    <ext:Checkbox
                        ID="RememberCheckbox"
                        Cls="remember-me"
                        runat="server"
                        BoxLabel="Remember my choice" />
                </Items>
            </ext:Container>

            <ext:Panel
                runat="server"
                Header="false"
                Region="North"
                Border="false"
                Height="70">
                <Content>
                    <header class="site-header" role="banner">
                        <nav class="top-navigation">
                            <div class="logo-container">
                                <%--<img src="resources/images/extdotnet-logo.svg" />--%>
                            </div>
                            <div class="navigation-bar">
                                <div class="platform-selector-container">
                                    
                                </div>
                                <input type="checkbox" id="menu-button-checkbox"/>
                                <label id="menu-button" for="menu-button-checkbox">
                                    <span></span>
                                </label>
                            </div>
                        </nav>
                    </header>
                </Content>
            </ext:Panel>
            <ext:Panel
                ID="rightnav"
                runat="server"
                Region="East"
                Width="270"
                Header="false"
                MarginSpec="0"
                Hidden="true"
                Border="false"
                BodyCls="right-nav-menu">
                <Content>
                    <ul id="nav-menu" class="nav-menu">
                        <li><a href="http://examples.ext.net/">Web Forms Examples</a></li>
                        <li><a href="http://mvc.ext.net/">MVC Examples</a></li>
                        <li><a href="http://mobile.ext.net/">Mobile Examples</a></li>
                        <li><a href="http://mvc.mobile.ext.net/">MVC Mobile Examples</a></li>
                        <li class="separator"></li>
                        <li><a href="https://docs.sencha.com/extjs/6.5.1/classic/Ext.html">EXT JS Documentation</a></li>
                        <li><a href="http://docs.ext.net/">Ext.NET Documentation</a></li>
                        <li class="separator"></li>
                        <li><a href="http://forums.ext.net/">Community Forums</a></li>
                        <li><a href="http://ext.net/faq/">FAQ</a></li>
                        <li><a href="http://ext.net/contact/">Contact</a></li>
                        <li><a href="http://ext.net/">Ext.NET Home</a></li>
                        <li class="separator"></li>
                        <li>
                            <a href="#" data-toggle="collapse" data-target="#archives"><i class="fa collapse-icon"></i> Archives</a>
                            <ul class="collapse" id="archives">
                                <li class="section-title">Ext.NET 3</li>
                                <li><a href="http://examples3.ext.net/">Web Forms Examples (3.3)</a></li>
                                <li><a href="http://mvc3.ext.net/">MVC Examples (3.3)</a></li>
                                <li class="separator"></li>
                                <li class="section-title">Ext.NET 2</li>
                                <li><a href="http://examples2.ext.net/">Web Forms Examples (2.5)</a></li>
                                <li><a href="http://mvc2.ext.net/">MVC Examples (2.5)</a></li>
                                <li class="separator"></li>
                                <li class="section-title">Ext.NET 1</li>
                                <li><a href="http://examples1.ext.net/">Web Forms Examples (1.7)</a></li>
                            </ul>
                        </li>
                    </ul>
                    <a href="http://ext.net/store/" class="button button-success button-block button-sidebar-right">Get Ext.NET</a>
                </Content>
            </ext:Panel>
            <ext:Panel
                runat="server"
                Region="West"
                Layout="Fit"
                Width="270"
                Header="false"
                MarginSpec="0"
                Border="false">
                <Items>
                    
                </Items>
            </ext:Panel>
            
        </Items>
    </ext:Viewport>
</body>
</html>
