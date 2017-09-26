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
    <style type="text/css">
        .bold-highlight {
            font-weight: bold;
            font-size:16px;
        }
        .my-item span {
            font-size:14px;
        }
    </style>

    <ext:XScript runat="server">
        <script>
            var addTabCN = function (tabPanel, id, url, TieuDe) {
                var tab = tabPanel.getComponent(id);

                if (!tab) {
                    tab = tabPanel.add({
                        id       : id,
                        title    : TieuDe,
                        closable : true,
                        
                        loader   : {
                            url      : url,
                            renderer : "frame",
                            loadMask : {
                                showMask : true,
                                msg      : "Nạp chức năng ..."
                            }
                        }
                    });
                }

                tabPanel.setActiveTab(tab);
            }
        </script>
    </ext:XScript>
</head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server" Theme="Default" />

    <ext:Viewport runat="server" Layout="BorderLayout" UI="Warning">
        <Items>           

            <%--<ext:Panel
                runat="server"
                Header="false"
                Region="North"
                Border="false"
                Height="70">
                <Content>
                    <header class="site-header" role="banner">
                        <nav class="top-navigation">
                            <div class="logo-container">
                               
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
            </ext:Panel>--%>

            <ext:Panel ID="pnlChucNang"
                runat="server"
                    Region="West"
                    Title="Chức năng"
                    Width="200"
                    Collapsible="true"
                    Split="true"
                    MinWidth="175"
                    MaxWidth="400"
                    MarginSpec="5 0 5 5"
                    Layout="AccordionLayout">
                <Items>
                    
                </Items>
            </ext:Panel>
            
            <ext:TabPanel
                ID="TabPanelChinh"
                runat="server"
                Region="Center"
                MarginSpec="0"
                Cls="tabs"
                MinTabWidth="115">
                <Items>
                    <ext:Panel
                        ID="tabHome"
                        runat="server"
                        Title="Trang chính"
                        HideMode="Offsets"
                        IconCls="fa fa-home">
                       
                    </ext:Panel>
                </Items>
            </ext:TabPanel>

            <%--<ext:Panel ID="tabBieuDo"
                runat="server"
                Title="Biểu đồ"
                Region="East"
                Collapsible="true"
                Split="true"
                MinWidth="100"
                Width="200"
                Layout="Fit" LayoutOnTabChange="true" HideMode="Offsets">
                <Items>
                    <ext:FieldContainer runat="server">
                        <Loader runat="server" Mode="Frame" Url="/BieuDo/frmBieuDoPie.aspx">

                        </Loader>
                    </ext:FieldContainer>
                </Items>
            </ext:Panel>--%>
        </Items>
    </ext:Viewport>
</body>
</html>
