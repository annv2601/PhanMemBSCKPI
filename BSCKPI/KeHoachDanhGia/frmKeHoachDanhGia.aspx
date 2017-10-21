<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmKeHoachDanhGia.aspx.cs" Inherits="BSCKPI.KeHoachDanhGia.frmKeHoachDanhGia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../resource/css/main.css" rel="stylesheet" />
    
    <script type="text/javascript">
        var editCV = function (editor, e) {
            if (e.value !== e.originalValue) {
                BangCVX.EditCV(e.record.data.IDChucVu, e.field, e.originalValue, e.value, e.record.data);
            }
        }

        var editCD = function (editor, e) {
            if (e.value !== e.originalValue) {
                BangCDX.EditCD(e.record.data.IDChucDanh, e.field, e.originalValue, e.value, e.record.data);
            }
        }

        var editDV = function (editor, e) {
            if (e.value !== e.originalValue) {
                BangDVX.EditDV(e.record.data.IDDonVi, e.field, e.originalValue, e.value, e.record.data);
            }
        }
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" Locale="vi-VN" />
    <form id="form1" runat="server">
        <ext:Menu runat="server" ID="mnuKH">
            <Items>
                <ext:MenuItem runat="server" ID="mnuitmThongTin" Text="Thông tin Kế hoạch" Icon="Information" >
                    <DirectEvents>
                        <Click OnEvent="mnuitmThongTin_Click">
                            <ExtraParams>
                                <ext:Parameter Name="Values" Value="Ext.encode(#{grdKHDG}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
                <ext:MenuSeparator />
                <ext:MenuItem runat="server" ID="mnuitmDSNV" Text="Danh sách nhân viên trong kế hoạch" Icon="Table" >
                    <DirectEvents>
                        <Click OnEvent="mnuitmDSNV_Click">
                            <ExtraParams>
                                <ext:Parameter Name="Values" Value="Ext.encode(#{grdKHDG}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
            </Items>
        </ext:Menu>
        <ext:GridPanel runat="server" ID="grdKHDG" MinHeight="500" ContextMenuID="mnuKH">
            <Store>
                <ext:Store runat="server" ID="stoKHDG" OnReadData="DanhSachKHDGTD">
                    <Model>
                        <ext:Model runat="server" IDProperty="ID">
                            <Fields>
                                <ext:ModelField Name="ID" />
                                <ext:ModelField Name="Ten" />
                                <ext:ModelField Name="TuNgay" />
                                <ext:ModelField Name="DenNgay" />
                                <ext:ModelField Name="NgayNhap" />
                                <ext:ModelField Name="NgaySua" />
                                <ext:ModelField Name="NguoiNhap" />
                                <ext:ModelField Name="NguoiSua" />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>
            </Store>
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:Button runat="server" ID="btnThemMoiKHDG" Text="Thêm mới" Icon="Add">
                            <DirectEvents>
                                <Click OnEvent="btnThemMoiKHDG_Click" />
                            </DirectEvents>
                        </ext:Button>
                        <%--<ext:Button runat="server" ID="btnDanhSachNhanVien" Text="Danh sách nhân viên" Icon="Table" MarginSpec="0 0 0 20">
                            <DirectEvents>
                                <Click OnEvent="btnDanhSachNhanVien_Click" />
                            </DirectEvents>
                        </ext:Button>--%>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <ColumnModel>
                <Columns>
                    <ext:RowNumbererColumn runat="server" Text="STT" Align="Center" Width="60" />
                    <ext:Column runat="server" DataIndex="Ten" Text="Tên" Width="350" CellWrap="true"/>
                    <ext:DateColumn runat="server" DataIndex="TuNgay" Text="Ngày áp dụng" Width="120" Format="dd/MM/yyyy" />
                    <ext:DateColumn runat="server" DataIndex="DenNgay" Text="Ngày kết thúc" Width="120" Format="dd/MM/yyyy" />
                    <ext:Column runat="server" Width="400" />
                </Columns>
            </ColumnModel>
        </ext:GridPanel>
        <ext:Hidden runat="server" ID="txtID" />
        <ext:Window runat="server" ID="wKeHoachDG" Hidden="true" Icon="ResultsetFirst"
            Width="820" ButtonAlign="Center" Height="600" AutoScroll="true" Title="Kế hoạch đánh giá" >
            <Items>
                <ext:TextArea runat="server" ID="txtTen" Width="780" FieldLabel="Tên" MarginSpec="10 0 0 10" LabelWidth="70"/>
                <ext:FieldContainer runat="server" MarginSpec="10 0 0 10" Layout="HBoxLayout">
                    <Items>
                        <ext:DateField runat="server" ID="txtTuNgay" FieldLabel="Từ ngày" Width="360" LabelWidth="70"/>
                        <ext:DateField runat="server" ID="txtDenNgay" FieldLabel="Đến ngày" Width="360" MarginSpec="0 0 0 40" LabelWidth="70"/>
                    </Items>
                </ext:FieldContainer>
                
                <ext:Panel runat="server" Height="230" Width="780" Title="" Layout="HBoxLayout" MarginSpec="10 0 0 0">
                <LayoutConfig>
                    <ext:HBoxLayoutConfig Align="Stretch" Padding="5" />
                </LayoutConfig>
                    <Items>                        
                        <ext:GridPanel runat="server" ID="grdChucVu" Header="false" Title="" Height="200" Flex="1">
                            <Store>
                                <ext:Store runat="server" ID="stoChucVu">
                                    <Model>
                                        <ext:Model runat="server" IDProperty="IDChucVu">
                                        <Fields>
                                            <ext:ModelField Name="DaChonCV" />
                                            <ext:ModelField Name="IDChucVu" />
                                            <ext:ModelField Name="ChucVu" />
                                        </Fields>
                                        </ext:Model>                                    
                                    </Model>
                                </ext:Store>
                            </Store>
                            <ColumnModel>
                                <Columns>
                                    <ext:CheckColumn runat="server" DataIndex="DaChonCV" Text="" Width="80" Editable="true"/>
                                    <ext:Column runat="server" DataIndex="ChucVu" Text="Chức vụ" Width="250" Flex="1" StyleSpec="font-weight:bold;"/>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:CellSelectionModel runat="server" />
                            </SelectionModel>
                            <Plugins>
                                <ext:CellEditing runat="server" ClicksToEdit="1">
                                    <Listeners>
                                        <Edit Fn="editCV" />
                                    </Listeners>
                                </ext:CellEditing>
                            </Plugins>
                        </ext:GridPanel>
                        <ext:GridPanel runat="server" ID="grdChucDanh" Header="false" Title="" MarginSpec="0 0 0 20" Height="200" Flex="1">
                            <Store>
                                <ext:Store runat="server" ID="stoChucDanh">
                                <Model>
                                    <ext:Model runat="server" IDProperty="IDChucDanh">
                                        <Fields>
                                            <ext:ModelField Name="DaChonCD" />
                                            <ext:ModelField Name="IDChucDanh" />
                                            <ext:ModelField Name="ChucDanh" />
                                        </Fields>
                                    </ext:Model>                                    
                                </Model>
                                </ext:Store>
                            </Store>
                            <ColumnModel>
                                <Columns>
                                    <ext:CheckColumn runat="server" DataIndex="DaChonCD" Text="" Width="80" Editable="true"/>
                                    <ext:Column runat="server" DataIndex="ChucDanh" Text="Chức danh" Width="250" Flex="1" StyleSpec="font-weight:bold;"/>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:CellSelectionModel runat="server" />
                            </SelectionModel>
                            <Plugins>
                                <ext:CellEditing runat="server" ClicksToEdit="1">
                                    <Listeners>
                                        <Edit Fn="editCD" />
                                    </Listeners>
                                </ext:CellEditing>
                            </Plugins>
                        </ext:GridPanel>
                    </Items>
                </ext:Panel>

                <ext:GridPanel runat="server" ID="grdDonVi" Header="false" Title="" Height="200" Width="780" MarginSpec="10 0 0 0">
                            <Store>
                                <ext:Store runat="server" ID="stoDonVi">
                                    <Model>
                                        <ext:Model runat="server" IDProperty="IDDonVi">                                        
                                            <Fields>
                                                <ext:ModelField Name="DaChonDV" />
                                                <ext:ModelField Name="IDDonVi" />
                                                <ext:ModelField Name="IDPhongBan" />
                                                <ext:ModelField Name="Ten" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                            <ColumnModel>
                                <Columns>
                                    <ext:CheckColumn runat="server" DataIndex="DaChonDV" Text="" Width="80" Editable="true"/>
                                    <ext:Column runat="server" DataIndex="Ten" Text="Đơn vị" Width="650" StyleSpec="font-weight:bold;"/>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:CellSelectionModel runat="server" />
                            </SelectionModel>
                            <Plugins>
                                <ext:CellEditing runat="server" ClicksToEdit="1">
                                    <Listeners>
                                        <Edit Fn="editDV" />
                                    </Listeners>
                                </ext:CellEditing>
                            </Plugins>
                        </ext:GridPanel>
            </Items>
            <Buttons>
                <ext:Button runat="server" Text="Cập nhật" ID="btnCapNhatKH" Icon="Accept" Width="150">
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatKH_Click">
                            <EventMask ShowMask="true" Msg="Đang thực hiện ....." />
                            <ExtraParams>
                                <ext:Parameter Name="ValuesCV" Value="Ext.encode(#{grdChucVu}.getRowsValues())" Mode="Raw" />
                                <ext:Parameter Name="ValuesCD" Value="Ext.encode(#{grdChucDanh}.getRowsValues())" Mode="Raw" />
                                <ext:Parameter Name="ValuesDV" Value="Ext.encode(#{grdDonVi}.getRowsValues())" Mode="Raw" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Text="Đóng" Icon="Cross" Width="150">
                    <Listeners>
                        <Click Handler="#{wKeHoachDG}.hide();#{stoKHDG}.reload();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>

        <ext:Window runat="server" ID="wDSNhanVien" Icon="Table" Title="Danh sách nhân viên trong kế hoạch" TitleAlign="Center"
            ButtonAlign="Center" Width="600" Height="650" AutoScroll="true" Hidden="true">
            <Items>
                <ext:GridPanel runat="server" ID="grdNhanVien" Header="false">
                    <Store>
                        <ext:Store runat="server" ID="stoDSNV">
                            <Fields>
                                <ext:ModelField Name="IDNhanVien" />
                                <ext:ModelField Name="TenNhanVien" />
                            </Fields>
                        </ext:Store>
                    </Store>
                    <ColumnModel>
                        <Columns>
                            <ext:RowNumbererColumn runat="server" Text="STT" Align="Center" Width="60" />
                            <ext:Column runat="server" Text="Tên" DataIndex="TenNhanVien" Width="500" />
                        </Columns>
                    </ColumnModel>
                </ext:GridPanel>
            </Items>
            <Buttons>
                <ext:Button runat="server" Text="Đóng" Icon="Cross">
                    <Listeners>
                        <Click Handler="#{wDSNhanVien}.hide()" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
    </form>
</body>
</html>
