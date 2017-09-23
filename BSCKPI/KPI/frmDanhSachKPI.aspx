<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDanhSachKPI.aspx.cs" Inherits="BSCKPI.KPI.frmDanhSachKPI" %>
<%@ Register src="~/UC/ucBSCKPI.ascx" tagname="BK" tagprefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../resource/css/main.css" rel="stylesheet" />
</head>
<body>
    <ext:ResourceManager runat="server" />
    <form id="form1" runat="server">
        <ext:Store ID="stoKPI" runat="server">
                    <Model>
                        <ext:Model runat="server">
                            <Fields>
                                <ext:ModelField Name="ID" />
                                <ext:ModelField Name="Ma" />
                                <ext:ModelField Name="STT" />
                                <ext:ModelField Name="Ten" />
                                <ext:ModelField Name="TrongSo" Type="Float" />
                                <ext:ModelField Name="MucTieu" Type="Float" />
                                <ext:ModelField Name="IDDonViTinh"/>
                                <ext:ModelField Name="DonViTinh" />
                                <ext:ModelField Name="IDBSC" />
                                <ext:ModelField Name="TenBSC" />
                                <ext:ModelField Name="Muc" />
                                <ext:ModelField Name="IDTanSuatDo" />
                                <ext:ModelField Name="TanSuatDo" />
                                <ext:ModelField Name="IDXuHuongYeuCau" />
                                <ext:ModelField Name="XuHuongYeuCau" />
                                <ext:ModelField Name="IDDonVi" />
                                <ext:ModelField Name="DonVi" />
                                <ext:ModelField Name="IDPhongBan" />
                                <ext:ModelField Name="PhongBan" />
                                <ext:ModelField Name="STTsx" />
                                <ext:ModelField Name="InDam" />
                                <ext:ModelField Name="InNghieng" />
                                <ext:ModelField Name="ChiTieuChung" />
                                <ext:ModelField Name="TrangThai" />
                                <ext:ModelField Name="TenTrangThai" />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>
        <ext:GridPanel runat="server" Title="Danh sách KPI" ID="grdKPI" StoreID="stoKPI">
            <ColumnModel runat="server">
                        <Columns>
                            <ext:Column runat="server" Text="STT" DataIndex="STT" />
                            <ext:Column runat="server" Text="Mã" DataIndex="Ma" Flex="1" />
                            <ext:Column runat="server" Text="Tên" DataIndex="Ten" />
                            <ext:Column runat="server" Text="Trọng số" DataIndex="TrongSo" />
                            <ext:Column runat="server" Text="Mục tiêu" DataIndex="MucTieu" />
                            <ext:Column runat="server" Text="Đơn vị tính" DataIndex="DonViTinh" />
                            <ext:Column runat="server" Text="Tần suất đo" DataIndex="TanSuatDo" />
                            <ext:Column runat="server" Text="Xu hướng" DataIndex="XuHuongYeuCau" />
                            <ext:Column runat="server" Text="Tên BSC" DataIndex="TenBSC" />
                            <ext:Column runat="server" Text="Đơn vị" DataIndex="DonVi" />
                            <ext:Column runat="server" Text="Phòng ban" DataIndex="PhongBan" />
                            <ext:Column runat="server" Text="Chỉ tiêu chung" DataIndex="ChiTieuchung" />
                            <ext:Column runat="server" Text="Trạng thái" DataIndex="TenTrangThai" />
                        </Columns>
                    </ColumnModel>
                    <Plugins>
                        <ext:FilterHeader runat="server" OnCreateFilterableField="OnCreateFilterableField" />
                    </Plugins>
        </ext:GridPanel>

        <ext:FieldContainer runat="server" Layout="HBoxLayout" ID="fdcNhapLieu" >
         <Items>
            <ext:Panel ID="Panel1" runat="server" Header="false" Border="false" Layout="FitLayout">
                 <Content>
                       <uc1:BK ID="ucBK1" runat="server" Title="" />
                 </Content>
            </ext:Panel>
             <ext:FieldContainer runat="server" Layout="VBoxLayout" >
                <Items>
                    <ext:Button ID="btnThemMoiBSC" runat="server" Text="Thêm mới" Icon="Add" Width="150" Height="50" MarginSpec="20 0 0 0">
                        <DirectEvents>
                            <Click OnEvent="btnThemMoiBSC_Click" />
                        </DirectEvents>
                    </ext:Button>
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
