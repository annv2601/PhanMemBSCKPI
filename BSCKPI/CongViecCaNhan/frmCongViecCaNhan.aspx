<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCongViecCaNhan.aspx.cs" Inherits="BSCKPI.CongViecCaNhan.frmCongViecCaNhan" %>
<%@ Register src="~/CongViecCaNhan/ucCongViecCaNhan.ascx" tagname="CVCN" tagprefix="uc1" %>
<<%@ Register Src="~/CongViecCaNhan/uccvcnNguoiThucHien.ascx" TagName="NTH" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../resource/css/main.css" rel="stylesheet" />
    <style type="text/css">
        .GridPanelUsersRowQuaHan
        {
            background:#FF0000;
        }
        .GridPanelUsersRowKhan
        {
            background: #FFD700;
        }
        .GridPanelUsersRowYellow
        {
            background: #ADFF2F;
        }
        .GridPanelUsersRowWhite
        {
            background: white;
        }
    </style>
    <script type="text/javascript">
        
        function getRowClass(record) {
            //if (record.data.IDMucDo == 18)
            //{
            //    alert("abc");
            //    return "GridPanelUsersRowYellow";
            //}
            //else
            //{
            //    alert("abc1");
            //    return "GridPanelUsersRowWhite";
            //}
            if (record.data.QuaHan) {
                return "GridPanelUsersRowQuaHan";
            }
            else
            {
                switch (record.data.IDMucDo) {
                    case 18:
                        return "GridPanelUsersRowYellow";
                    case 19:
                        return "GridPanelUsersRowKhan";
                    default:
                        return "GridPanelUsersRowWhite";
                }
            }
        }
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" Locale="vi-VN" />
    <form id="form1" runat="server">
        <ext:Store runat="server" ID="stoCVCN" PageSize="20" OnReadData="DanhSachCongViecCNTD">
            <Model>
                <ext:Model runat="server" IDProperty="STT">
                    <Fields>
                        <ext:ModelField Name="STT" />
                        <ext:ModelField Name="Ma" />
                        <ext:ModelField Name="NguoiGiaoViec" />
                        <ext:ModelField Name="TenNguoiGiaoViec" />
                        <ext:ModelField Name="NguoiLamChinh" />
                        <ext:ModelField Name="TenNguoiLamChinh" />
                        <ext:ModelField Name="NgayGiaoViec" />
                        <ext:ModelField Name="NgayDenHan" />
                        <ext:ModelField Name="GioDenHan"/>
                        <ext:ModelField Name="NoiDung" />
                        <ext:ModelField Name="IDMucDo" />
                        <ext:ModelField Name="MucDo" />
                        <ext:ModelField Name="IDTrangThai" />
                        <ext:ModelField Name="TrangThai" />
                        <ext:ModelField Name="QuaHan" />
                        <ext:ModelField Name="ThoiGianQuaHan" />
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>

        <ext:GridPanel runat="server" ID="grdCVCN" MinHeight="600" StoreID="stoCVCN">
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:Button runat="server" ID="btnThemCVMoi" Text="Thêm công việc mới" Icon="Add">
                            <DirectEvents>
                                <Click OnEvent ="btnThemCVMoi_Click" />
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <View>
                <ext:GridView ID="GridView1" runat="server">
                    <GetRowClass Fn="getRowClass" />
                </ext:GridView>
            </View>
            <ColumnModel runat="server">
                <Columns>
                    <ext:Column runat="server" DataIndex="STT" Width="50" Text="STT"  Align="Center"/>
                    <ext:DateColumn runat="server" DataIndex="NgayGiaoViec" Text="Ngày giao" Align="Center" Format="dd/MM/yyyy"/>
                    <ext:Column runat="server" DataIndex="NoiDung" Text="Nội dung công việc" Width="500" CellWrap="true"/>
                    <ext:Column runat="server" DataIndex="TenNguoiGiaoViec" Text="Lãnh đạo giao việc" Align="Center" Width="150" />
                    <ext:Column runat="server" DataIndex="TenNguoiLamChinh" Text="Nhân viên làm chính" Align="Center" Width="150" />

                    <ext:Column runat="server" Text="Hạn xử lý" Align="Center">
                        <Columns>
                            <ext:DateColumn runat="server" DataIndex="NgayDenHan" Text="Ngày" Align="Center" Format="dd/MM/yyyy"/>
                            <%--<ext:DateColumn runat="server" DataIndex="GioDenHan" Text="Giờ" Align="Center" Format="HH:mm:ss"/> --%>                           
                            <ext:Column runat="server" DataIndex="GioDenHan" Text="Giờ" Align="Center" />
                        </Columns>
                    </ext:Column>
                    
                    <ext:Column runat="server" DataIndex="MucDo" Text="Mức độ" Align="Center" Width="120" />                    
                    <ext:Column runat="server" DataIndex="TrangThai" Text="Trạng thái" Align="Center" Width="150" />
                    <ext:Column runat="server" DataIndex="ThoiGianQuaHan" Text="Thời gián quá hạn" Align="Left" Width="200" />
                    <ext:Column runat="server" Text="" Align="Center" Width="300" />
                </Columns>
            </ColumnModel>
            <SelectionModel>
                <ext:RowSelectionModel runat="server" Mode="Single" />
            </SelectionModel>
            <BottomBar>
                <ext:PagingToolbar runat="server"
                    DisplayMsg="Số lượng công việc từ {0} - {1} trên tổng {2}" EmptyMsg="Không có công việc nào" FirstText="Trang đầu" LastText="Trang cuối" NextText="Trang tiếp" PrevText="Trang trước" AfterPageText="trên {0}" BeforePageText="Trang">
                    <Items>
                        <ext:Label runat="server" Text="Số lượng:" />
                        <ext:ToolbarSpacer runat="server" Width="10" />
                        <ext:ComboBox runat="server" Width="80">
                            <Items>
                                <ext:ListItem Text="10" />
                                <ext:ListItem Text="20" />
                                <ext:ListItem Text="40" />
                                <ext:ListItem Text="60" />
                            </Items>
                            <SelectedItems>
                                <ext:ListItem Value="20" />
                            </SelectedItems>
                        </ext:ComboBox>
                    </Items>
                    <Plugins>
                        <ext:ProgressBarPager runat="server" />
                    </Plugins>
                </ext:PagingToolbar>
            </BottomBar>
        </ext:GridPanel>

        <ext:Window runat="server" ID="wCongViecCaNhan" Icon="World" Title="Công việc cá nhân" TitleAlign="Center" Width="800" ButtonAlign="Center"
            Hidden="true">
            <Items>
                <ext:TabPanel runat="server" ID="tabCVCN" ButtonAlign="Center" MinWidth="150">                    
                    <Items>
                        <ext:Panel ID="Panel2" runat="server" Header="false" Title="Giao việc" Border="false" Layout="FormLayout" Closable="false">
                             <Content>
                                   <uc1:CVCN ID="CVCN1" runat="server" Title="" />
                             </Content>
                        </ext:Panel>
                        <ext:Panel ID="Panel3" runat="server" Header="false" Title="Nhân viên thực hiện" Border="false" Layout="FitLayout" Closable="false">
                             <Content>
                                   <uc1:NTH ID="NTH1" runat="server" Title="" />
                             </Content>
                        </ext:Panel>
                        <ext:Panel ID="Panel1" runat="server" Header="false" Title="Quá trình xử lý" Border="false" Layout="FitLayout" Closable="false">
                             
                        </ext:Panel>
                        <ext:Panel ID="Panel4" runat="server" Header="false" Title="Hồ sơ" Border="false" Layout="FitLayout" Closable="false">
                             
                        </ext:Panel>
                        <ext:Panel ID="Panel5" runat="server" Header="false" Title="Đánh giá công việc" Border="false" Layout="FitLayout" Closable="false">
                             
                        </ext:Panel>
                    </Items>
                    <Buttons>
                        <ext:Button runat="server" ID="btnCapNhat" Text="Cập nhật" Icon="Accept">
                            <DirectEvents>
                                <Click OnEvent="btnCapNhat_Click" />
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button runat="server" ID="btnDong" Text="Đóng" Icon="Cross">
                            <Listeners>
                                <Click Handler="#{wCongViecCaNhan}.hide();#{stoCVCN}.reload();" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
                </ext:TabPanel>
            </Items>
        </ext:Window>
    </form>
</body>
</html>
