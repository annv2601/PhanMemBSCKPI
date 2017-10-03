<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmNhiemVuChinh.aspx.cs" Inherits="BSCKPI.KPI.frmNhiemVuChinh" %>
<%@ Register src="~/UC/ucNhiemVuTrongTam.ascx" tagname="NV" tagprefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../resource/css/main.css" />
</head>
<body>
    <ext:ResourceManager runat="server" Locale="vi-VN"/>
    <form id="form1" runat="server">
        <ext:GridPanel runat="server" ID="grdNV"
            Title="Nhiệm vụ trọng tâm" TitleAlign="Center" MinHeight="500">
            <Store>
                <ext:Store runat="server" ID="stoNV" OnReadData="DanhSachNVTTam">
                    <Model>
                        <ext:Model runat="server">
                            <Fields>
                                <ext:ModelField Name="ID" />
                                <ext:ModelField Name="IDNhanVien" />
                                <ext:ModelField Name="TenNhanVien" />
                                <ext:ModelField Name="TenCongViec" />
                                <ext:ModelField Name="IDTanSuatDo" />
                                <ext:ModelField Name="TanSuatDo" />
                                <ext:ModelField Name="IDDonViTinh" />
                                <ext:ModelField Name="DonViTinh" />
                                <ext:ModelField Name="MucTieu" />
                                <ext:ModelField Name="IDTrangThai" />
                                <ext:ModelField Name="TrangThai" />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>
            </Store>
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:SelectBox runat="server" ID="slbThang" 
                            EmptyText="Tháng ...." DisplayField="Ten" ValueField="ID" MarginSpec="0 0 0 10" RenderXType="True">
                            <Listeners>
                                <Select Handler="#{stoNV}.reload();" />
                            </Listeners>
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
                            <Listeners>
                                <Select Handler="#{stoNV}.reload();" />
                            </Listeners>
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
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <ColumnModel>
                <Columns>
                    <ext:RowNumbererColumn runat="server" Text="STT" Align="Center" Width="60" />
                    <ext:Column runat="server" Text="Tên nhân viên" DataIndex="TenNhanVien" Width="200" />
                    <ext:Column runat="server" Text="Tên công việc" DataIndex="TenCongViec" Width="400" CellWrap="true"/>
                    <ext:Column runat="server" Text="Tần suất đo" DataIndex="TanSuatDo" Width="120" />
                    <ext:Column runat="server" Text="Đơn vị tính" DataIndex="DonViTinh" Width="120" />
                    <ext:NumberColumn runat="server" Text="Mục tiêu" DataIndex="MucTieu" Width="150" Align="Right" />
                    <ext:Column runat="server" Text="Trạng thái" DataIndex="TrangThai" Width="120" />
                </Columns>
            </ColumnModel>
            <SelectionModel>
                <ext:CellSelectionModel runat="server" >
                    <DirectEvents>
                        <Select OnEvent="grdNV_Select">
                            <ExtraParams>
                                <ext:Parameter Name="Values" Value="Ext.encode(#{grdNV}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
                            </ExtraParams>
                        </Select>
                    </DirectEvents>
                </ext:CellSelectionModel>
            </SelectionModel>
        </ext:GridPanel>

        <ext:FieldContainer runat="server" Layout="HBoxLayout" ID="fdcNhapLieu" >
         <Items>
            <ext:Panel ID="Panel1" runat="server" Header="false" Border="false" Layout="FitLayout">
                 <Content>
                       <uc1:NV ID="ucNV1" runat="server" Title="" />
                 </Content>
            </ext:Panel>
             <ext:FieldContainer runat="server" Layout="VBoxLayout" >
                <Items>
                    <ext:Button ID="btnCapNhatNV" runat="server" Text="Cập nhật" Icon="Accept" Width="150" Height="50" MarginSpec="50 0 0 0">
                        <DirectEvents>
                            <Click OnEvent="btnCapNhatNV_Click" />
                        </DirectEvents>
                    </ext:Button>
                </Items>
            </ext:FieldContainer>
         </Items>
     </ext:FieldContainer>
    </form>
</body>
</html>
