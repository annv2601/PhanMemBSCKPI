﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmGiaoBSC.aspx.cs" Inherits="BSCKPI.BSC.frmGiaoBSC" %>
<%@ Register src="~/UC/ucBSCKPI.ascx" tagname="BK" tagprefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <ext:ResourceManager runat="server" />
    <form id="form1" runat="server">
        <ext:FieldContainer runat="server" Layout="HBoxLayout" ID="FieldContainer1" >
         <Items>
         
            <ext:TreePanel
            runat="server" ID="tpBSC"
            Title="Danh sách BSC Đơn vị" TitleAlign="Center"
            Width="1000"
            Height="420"
            Collapsible="false"
            UseArrows="true"
            RootVisible="false"
            MultiSelect="false"
            SingleExpand="false"
            FolderSort="true">
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:SelectBox runat="server" ID="slbThang" 
                            EmptyText="Tháng ...." DisplayField="Ten" ValueField="ID" MarginSpec="0 0 0 10" RenderXType="True">
                            <DirectEvents>
                                <Change OnEvent="slbThang_Change">
                                    <EventMask ShowMask="true" Msg="Thực thi ......" />
                                </Change>
                            </DirectEvents>
                            <Store>
                                <ext:Store runat="server" ID="stoThang">
                                    <Model>
                                        <ext:Model runat="server">
                                            <Fields>
                                                <ext:ModelField Name="ID" />
                                                <ext:ModelField Name="Ten" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                        </ext:SelectBox>
                        <ext:SelectBox runat="server" ID="slbNam" QueryMode="Local" TypeAhead="true"
                            EmptyText="Năm ...." DisplayField="Ten" ValueField="ID" MarginSpec="0 0 0 10" RenderXType="true">
                            <DirectEvents>
                                <Change OnEvent="slbThang_Change">
                                    <EventMask ShowMask="true" Msg="Thực thi ......" />
                                </Change>
                            </DirectEvents>
                            <Store>
                                <ext:Store runat="server" ID="stoNam" AutoDataBind="true">
                                    <Model>
                                        <ext:Model runat="server">
                                            <Fields>
                                                <ext:ModelField Name="ID" />
                                                <ext:ModelField Name="Ten" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                        </ext:SelectBox>
                        <ext:Button ID="btnHienThi" runat="server" Icon="PageRefresh" ToolTip="Hiển thị lại dữ liệu" MarginSpec="0 0 0 10">
                            <DirectEvents>
                                <Click OnEvent="btnHienThi_Click" />
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <Fields>                
                <ext:ModelField Name="Ma" />
                <ext:ModelField Name="Ten" />
                <ext:ModelField Name="TrongSo" Type="Float" />
                <ext:ModelField Name="TrongSoChung" Type="Float" />
                <ext:ModelField Name="MucTieu" Type="Float" />
                <ext:ModelField Name="DonViTinh" />
                <ext:ModelField Name="TanSuatDo" />
                <ext:ModelField Name="XuHuongYeuCau" />
            </Fields>
            <ColumnModel>
                <Columns>
                    <ext:TreeColumn
                        runat="server"
                        Text="Tên"
                        Flex="2"
                        Sortable="true"
                        DataIndex="Ten" />                    
                    <ext:Column
                        runat="server"
                        Text="Trọng số"
                        Flex="1"
                        Sortable="true"
                        DataIndex="TrongSo" FormatterFn="Percent" Width="100" />
                    <ext:NumberColumn runat="server" Text="Trọng số chung" DataIndex="TrongSoChung" Format="000,000,000,000.00%" Width="100"/>
                    <ext:NumberColumn runat="server" Text="Mục tiêu" DataIndex="MucTieu" Format="000,000,000,000.000" Width="200"/>
                   <ext:Column runat="server" Text="Đơn vị tính" DataIndex="DonViTinh" />
                    <ext:Column runat="server" Text="Tần suất đo" DataIndex="TanSuatDo" />
                    <ext:Column runat="server" Text="Xu hướng" DataIndex="XuHuongYeuCau" />
                </Columns>

            </ColumnModel>
        <DirectEvents>
            <ItemClick OnEvent="tpBSC_Click" />
        </DirectEvents>
        </ext:TreePanel>


             <ext:Panel ID="tabBieuDo"
                runat="server"
                Title="Biểu đồ"
                Collapsible="true"
                Split="true"
                MinWidth="200"
                Width="400"
                Height="380"
                Layout="Fit">
                 <Loader ID="lBieuDo" runat="server" Mode="Frame" Url="">

                </Loader>
            </ext:Panel>
         </Items>
    </ext:FieldContainer>

    <ext:FieldContainer runat="server" Layout="HBoxLayout" ID="fdcNhapLieu" >
         <Items>
            <ext:Panel ID="Panel1" runat="server" Header="false" Border="false" Layout="FitLayout">
                 <Content>
                       <uc1:BK ID="ucBK1" runat="server" Title="" />
                 </Content>
            </ext:Panel>
             <ext:FieldContainer runat="server" Layout="VBoxLayout" >
                <Items>
                    <%--<ext:Button ID="btnThemMoiBSC" runat="server" Text="Thêm mới" Icon="Add" Width="150" Height="50" MarginSpec="20 0 0 0">
                        <DirectEvents>
                            <Click OnEvent="btnThemMoiBSC_Click" />
                        </DirectEvents>
                    </ext:Button>--%>
                    <ext:Button ID="btnCapNhatBSC" runat="server" Text="Cập nhật" Icon="Accept" Width="150" Height="50" MarginSpec="50 0 0 0">
                        <DirectEvents>
                            <Click OnEvent="btnCapNhatBSC_Click" />
                        </DirectEvents>
                    </ext:Button>
                </Items>
            </ext:FieldContainer>
            
            
         </Items>
     </ext:FieldContainer>
    </form>
</body>
</html>
