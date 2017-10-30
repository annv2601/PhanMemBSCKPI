<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCongViecCaNhan.aspx.cs" Inherits="BSCKPI.CongViecCaNhan.frmCongViecCaNhan" %>
<%@ Register src="~/CongViecCaNhan/ucCongViecCaNhan.ascx" tagname="CVCN" tagprefix="uc1" %>
<%@ Register src="~/CongViecCaNhan/uccvcnGiaHan.ascx" tagname="GHa" tagprefix="uc1" %>
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

        var editNTH = function (editor, e) {
            if (e.value !== e.originalValue) {
                BangNTHX.EditNTH(e.record.data.STT, e.field, e.originalValue, e.value, e.record.data);
            }
        }

        var editDG = function (editor, e) {
            if (e.value !== e.originalValue) {
                BangDGX.EditDG(e.record.data.STT, e.field, e.originalValue, e.value, e.record.data);
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
                        <ext:ModelField Name="MaNhap" />
                        <ext:ModelField Name="NoiDung" />
                        <ext:ModelField Name="IDMucDo" />
                        <ext:ModelField Name="MucDo" />
                        <ext:ModelField Name="IDTrangThai" />
                        <ext:ModelField Name="TrangThai" />
                        <ext:ModelField Name="QuaHan" />
                        <ext:ModelField Name="ThoiGianQuaHan" />
                        <ext:ModelField Name="DaHoanThanh" />
                        <ext:ModelField Name="MucDoHoanThanh" />
                        <ext:ModelField Name="KetQuaHoanThanh" />
                        <ext:ModelField Name="NgayHoanThanh" />
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>

        <ext:Menu runat="server" ID="mnuCongViecCaNhan" Width="300">
            <Items>
                <ext:MenuItem runat="server" ID="mnuitmThongTinCVCN" Text="Thông tin Công việc" Icon="Information" Visible="False">
                    <DirectEvents>
                        <Click OnEvent="mnuitmThongTinCVCN_Click">
                            <ExtraParams>
                                <ext:Parameter Name="Values" Value="Ext.encode(#{grdCVCN}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
                <ext:MenuItem runat="server" ID="mnuitmThemNguoiThucHien" Text="Thêm người phối hợp" Icon="UserAdd">
                    <DirectEvents>
                        <Click OnEvent="mnuitmThemNguoiThucHien_Click">
                            <ExtraParams>
                                <ext:Parameter Name="Values" Value="Ext.encode(#{grdCVCN}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
                <ext:MenuItem runat="server" ID="mnuitemGiaHan" Text="Gia hạn xử lý công việc" Icon="DateGo">
                    <DirectEvents>
                        <Click OnEvent="mnuitemGiaHan_Click">
                            <ExtraParams>
                                <ext:Parameter Name="Values" Value="Ext.encode(#{grdCVCN}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
                <ext:MenuItem runat="server" ID="mnuitemDanhGia" Text="Đánh giá kết quả công việc" Icon="ControlEnd">
                    <DirectEvents>
                        <Click OnEvent="mnuitemDanhGia_Click">
                            <ExtraParams>
                                <ext:Parameter Name="Values" Value="Ext.encode(#{grdCVCN}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
            </Items>
        </ext:Menu>

        <ext:GridPanel runat="server" ID="grdCVCN" MinHeight="600" StoreID="stoCVCN" ContextMenuID="mnuCongViecCaNhan">
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
                    <ext:Column runat="server" DataIndex="MaNhap" Text="Mã" Align="Center" />
                    <ext:DateColumn runat="server" DataIndex="NgayGiaoViec" Text="Ngày giao" Align="Center" Format="dd/MM/yyyy"/>
                    <%--<ext:Column runat="server" DataIndex="NoiDung" Text="Nội dung công việc" Width="500" CellWrap="true"/>--%>
                    <ext:HyperlinkColumn
                        ID="HyperlinkColumn1"
                        runat="server"
                        Text="Nội dung công việc"
                        DataIndex="NoiDung"
                        DataIndexHref="Ma"
                        Pattern="{text:uppercase}"
                        HrefPattern="frmQuaTrinhXuLy.aspx?MaCongViec={href}" Width="500" CellWrap="true"/>
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
            <Plugins>
                <ext:FilterHeader runat="server" OnCreateFilterableField="OnCreateFilterableField" />
            </Plugins>
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
                <ext:Panel ID="Panel2" runat="server" Header="false"  Border="false" Layout="FormLayout" Closable="false">
                             <Content>
                                   <uc1:CVCN ID="CVCN1" runat="server" Title="" />
                             </Content>
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
        </ext:Window>

        <ext:Window runat="server" ID="wGiaHan" Icon="DateGo" Title="" TitleAlign="Center" Width="620" ButtonAlign="Center"
            Hidden="true">
            <Items>
                <ext:Panel ID="Panel1" runat="server" Header="false"  Border="false" Layout="FormLayout" Closable="false">
                             <Content>
                                   <uc1:GHa ID="ucGHa1" runat="server" Title="" />
                             </Content>
                        </ext:Panel>                
            </Items>
             <Buttons>
                        <ext:Button runat="server" ID="btnGiaHan" Text="Cập nhật" Icon="Accept">
                            <DirectEvents>
                                <Click OnEvent="btnGiaHan_Click" />
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button runat="server" ID="Button2" Text="Đóng" Icon="Cross">
                            <Listeners>
                                <Click Handler="#{wGiaHan}.hide();" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
        </ext:Window>

        <ext:Hidden runat="server" ID="txtMaCongViecCaNhan" />
        <ext:Hidden runat="server" ID="txtNgayGiao" />

        <ext:Window runat="server" ID="wNguoiThucHien" Width="800" Height="500" Icon="Eyes" Title="Người phối hợp" TitleAlign="Center" Hidden="true" ButtonAlign="Center">
            <Items>
                
                <ext:GridPanel runat="server" ID="grdNguoiThucHien" MinWidth="300" TitleAlign="Center">
                    <Store>
                        <ext:Store runat="server" ID="stoNTH">
                            <Model>
                                <ext:Model runat="server" IDProperty="STT">
                                    <Fields>
                                        <ext:ModelField Name="MaCongViecCaNhan" />
                                        <ext:ModelField Name="IDNhanVien" />
                                        <ext:ModelField Name="TenNhanVien" />
                                        <ext:ModelField Name="YKienChiDao" />
                                        <ext:ModelField Name="DaChon" />
                                        <ext:ModelField Name="STT" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>        
                    </Store>
                    <ColumnModel runat="server">
                        <Columns>
                            <ext:Column runat="server" DataIndex="STT" Width="60" Align="Center" Text="STT"/>
                            <ext:CheckColumn runat="server" DataIndex="DaChon" Text="Chọn" Align="Center" Editable="true" Width="80">               
                            </ext:CheckColumn>
                            <ext:Column runat="server" DataIndex="TenNhanVien" Width="200" Align="Left" Text="Nhân viên" />
                            <ext:Column runat="server" DataIndex="YKienChiDao" Width="440" Text="Ý kiến chỉ đạo">
                                <Editor>
                                    <ext:TextField runat="server" ID="txtYKCD" />
                                </Editor>
                            </ext:Column>
                        </Columns>
                    </ColumnModel>
                    <SelectionModel>
                                <ext:CellSelectionModel runat="server" >
                    
                                </ext:CellSelectionModel>
                            </SelectionModel>
                            <Plugins>                
                                <ext:CellEditing runat="server" ClicksToEdit="1">
                                    <Listeners>
                                        <Edit Fn="editNTH" />
                                    </Listeners>
                                </ext:CellEditing>
                            </Plugins>
                </ext:GridPanel>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnDongNTH" Text="Đóng" Icon="Cross">
                    <Listeners>
                        <Click Handler="#{wNguoiThucHien}.hide()" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>

        <ext:Window runat="server" ID="wDanhGiaCVCN" Width="1000" Height="600" Icon="ControlEnd" Title="Đánh giá hoàn thành công việc" TitleAlign="Center" Hidden="true" ButtonAlign="Center" AutoScroll="true">
            <Items>
                <ext:GridPanel runat="server" ID="grdCaNhanDanhGia" Title="Nhân viên tự đánh giá" Height="300">
                    <Store>
                        <ext:Store runat="server" ID="stoCaNhanDG">
                            <Fields>
                                <ext:ModelField Name="NguoiThucHien" />
                                <ext:ModelField Name="ChatLuong" />
                                <ext:ModelField Name="KhoiLuong" />
                                <ext:ModelField Name="TienDo" />
                                <ext:ModelField Name="DoPhucTap" />
                                <ext:ModelField Name="TrachNhiem" />
                            </Fields>
                        </ext:Store>
                    </Store>
                    <ColumnModel>
                        <Columns>
                            <ext:RowNumbererColumn runat="server" Text="STT" Align="Center" Width="60" />
                            <ext:Column runat="server" DataIndex="NguoiThucHien" Text="Họ tên" Width="200" />
                            <ext:Column runat="server" DataIndex="ChatLuong" Text="Chất lượng" Width="150" />
                            <ext:Column runat="server" DataIndex="KhoiLuong" Text="Khối lượng" Width="150" />
                            <ext:Column runat="server" DataIndex="TienDo" Text="Tiến độ" Width="150" />
                            <ext:Column runat="server" DataIndex="DoPhucTap" Text="Độ phức tạp" Width="150" />
                            <ext:Column runat="server" DataIndex="TrachNhiem" Text="Trách nhiệm" Width="150" />
                        </Columns>
                    </ColumnModel>
                </ext:GridPanel>

                <ext:GridPanel runat="server" ID="grdLanhDaoDanhGia" Title="Lãnh đạo Đánh giá" Height="300" MarginSpec="10 0 0 0">
                    <Store>
                        <ext:Store runat="server" ID="stoLanhDaoDG">
                            <Model>
                                <ext:Model runat="server" IDProperty="STT">
                                    <Fields>
                                        <ext:ModelField Name="STT" />
                                        <ext:ModelField Name="NguoiDanhGia" />
                                        <ext:ModelField Name="IDNguoiDuocDanhGia" />
                                        <ext:ModelField Name="NguoiDuocDanhGia" />
                                        <ext:ModelField Name="ChatLuong" />
                                        <ext:ModelField Name="KhoiLuong" />
                                        <ext:ModelField Name="TienDo" />
                                        <ext:ModelField Name="DoPhucTap" />
                                        <ext:ModelField Name="TrachNhiem" />
                                    </Fields>
                                </ext:Model>
                            </Model>                            
                        </ext:Store>
                    </Store>
                    <ColumnModel>
                        <Columns>
                            <ext:RowNumbererColumn runat="server" Text="STT" Align="Center" Width="60" />
                            <ext:Column runat="server" DataIndex="NguoiDanhGia" Text="Lãnh đạo đánh giá" Width="200"/>
                            <ext:Column runat="server" DataIndex="NguoiDuocDanhGia" Text="Họ tên" Width="200"/>
                            <ext:Column runat="server" DataIndex="ChatLuong" Text="Chất lượng" Width="150" >
                                <Editor>
                                    <ext:TextField runat="server" />
                                </Editor>
                            </ext:Column>
                            <ext:Column runat="server" DataIndex="KhoiLuong" Text="Khối lượng" Width="150" >
                                <Editor>
                                    <ext:TextField runat="server" />
                                </Editor>
                            </ext:Column>
                            <ext:Column runat="server" DataIndex="TienDo" Text="Tiến độ" Width="150" >
                                <Editor>
                                    <ext:TextField runat="server" />
                                </Editor>
                            </ext:Column>
                            <ext:Column runat="server" DataIndex="DoPhucTap" Text="Độ phức tạp" Width="150" >
                                <Editor>
                                    <ext:TextField runat="server" />
                                </Editor>
                            </ext:Column>
                            <ext:Column runat="server" DataIndex="TrachNhiem" Text="Trách nhiệm" Width="150" >
                                <Editor>
                                    <ext:TextField runat="server" />
                                </Editor>
                            </ext:Column>
                        </Columns>
                    </ColumnModel>
                    <SelectionModel>
                                <ext:CellSelectionModel runat="server" >
                    
                                </ext:CellSelectionModel>
                            </SelectionModel>
                            <Plugins>                
                                <ext:CellEditing runat="server" ClicksToEdit="1">
                                    <Listeners>
                                        <Edit Fn="editDG" />
                                    </Listeners>
                                </ext:CellEditing>
                            </Plugins>
                </ext:GridPanel>

                <ext:FormPanel runat="server" ID="frmDGChung" Title="Đánh giá kết quả công việc" ButtonAlign="Center" Width="1000">
                    <Items>
                        <ext:Hidden runat="server" ID="chkDaHoanThanh" />
                        <ext:FieldContainer runat="server" Layout="HBoxLayout" MarginSpec="10 0 0 0">
                            <Items>
                                <ext:SelectBox runat="server" ID="slbTrangThaiHoanThanh" DisplayField="Ten" ValueField="ID"
                                    FieldLabel="Kết quả" Width="300" >
                                    <Store>
                                        <ext:Store runat="server" ID="stoTrangThaiHoanThanh">
                                            <Fields>
                                                <ext:ModelField Name="ID" />
                                                <ext:ModelField Name="Ten" />
                                            </Fields>
                                        </ext:Store>
                                    </Store>
                                </ext:SelectBox>
                                <ext:DateField runat="server" ID="txtNgayHoanThanh" FieldLabel="Ngày hoàn thành" LabelWidth="130" Width="250" MarginSpec="0 0 0 30" />
                            </Items>
                        </ext:FieldContainer>
                        <ext:TextArea runat="server" ID="txtMucDoHoanThanh" FieldLabel="Mức độ" Width="960" MarginSpec="10 0 0 0" />
                        <ext:TextArea runat="server" ID="txtKetQuaHoanThanh" FieldLabel="Nội dung kết quả" Width="960" MarginSpec="10 0 0 0" />
                    </Items>
                    <Buttons>
                        <ext:Button runat="server" ID="btnCapNhatDanhGia" Text="Cập nhật" Icon="Accept" Width="150">
                            <DirectEvents>
                                <Click OnEvent="btnCapNhatDanhGia_Click" />
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button runat="server" ID="btnDongDG" Text="Đóng" Icon="Cross" Width="150">
                            <Listeners>
                                <Click Handler="#{wDanhGiaCVCN}.hide();#{stoCVCN}.reload();" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
                </ext:FormPanel>
            </Items>
        </ext:Window>
    </form>
</body>
</html>
