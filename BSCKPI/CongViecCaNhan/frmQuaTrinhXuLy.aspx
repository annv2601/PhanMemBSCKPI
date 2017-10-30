<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmQuaTrinhXuLy.aspx.cs" Inherits="BSCKPI.CongViecCaNhan.frmQuaTrinhXuLy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .Dam{
            font-weight:bold;
        }
        .TD{
            font-weight:bold;
            font-size:30px;
            align-content:center;
            align-items:center;
            align-self:center;
        }
    </style>
    <script>
        var beforeCellEditHandler = function (e) {
            if (e.record.data.ID <0) {
                CellEditing1.cancelEdit(); 
            }
        }

        var edit = function (editor, e) {
            if (e.value !== e.originalValue) {
                BangQTXLX.Edit(e.record.data.STT, e.field, e.originalValue, e.value, e.record.data);
            }
        }
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" Locale="vi-VN" />
    <form id="form1" runat="server">
        <ext:Hidden runat="server" ID="txtMaCongViecCaNhan"/>
        <ext:Hidden runat="server" ID="txtIDQTXL" />
        <ext:FieldContainer runat="server" MarginSpec="10 0 0 0" Layout="CenterLayout" Width="1200">
            <Items>
                <ext:Label runat="server" ID="lblTenCongViec" Width="1000" Cls="TD" MarginSpec="10 0 0 0"/>
            </Items>
        </ext:FieldContainer>
        
        <ext:FieldContainer runat="server" MarginSpec="10 0 0 20">
            <Items>
                <ext:FieldContainer runat="server" Layout="HBoxLayout">
                    <Items>
                        <ext:SelectBox runat="server" ID="slbHuongXuLy" DisplayField="Ten" ValueField="ID" FieldLabel="Hướng xử lý" LabelCls="Dam">
                            <Store>
                                <ext:Store runat="server" ID="stoHuongXuLy">
                                    <Fields>
                                        <ext:ModelField Name="ID" />
                                        <ext:ModelField Name="Ten" />
                                    </Fields>
                                </ext:Store>
                            </Store>
                        </ext:SelectBox>
                        <ext:Button runat="server" ID="btnCapNhatXL" Text="Cập nhật" Icon="Accept" MarginSpec="0 0 0 50" Width="150" LabelCls="Dam">
                            <DirectEvents>
                                <Click OnEvent="btnCapNhatXL_Click">
                                    <EventMask ShowMask="true" Msg="Đang thực hiện ....." />
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:FieldContainer>
                
                <ext:TextArea runat="server" ID="txtNoiDungXuLy" FieldLabel="Nội dung xử lý" Width="750" LabelCls="Dam"/>
            </Items>
        </ext:FieldContainer>
        <ext:Store runat="server" ID="stoTienTrinh" OnReadData="DanhSachTienTrinhTD">
            <Model>
                <ext:Model runat="server" IDProperty="STT">
                    <Fields>
                        <ext:ModelField Name="ID" />
                        <ext:ModelField Name="STT" />
                        <ext:ModelField Name="LanhDao" />
                        <ext:ModelField Name="NguoiThucHien" />
                        <ext:ModelField Name="Ngay" />
                        <ext:ModelField Name="NgayNhap" />
                        <ext:ModelField Name="HuongXuLy" />
                        <ext:ModelField Name="NoiDung" />
                        <ext:ModelField Name="YKienChiDao" />
                        <ext:ModelField Name="NgayChiDao" />
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>
        <ext:GridPanel runat="server" ID="grdTienTrinh" StoreID="stoTienTrinh">
            <ColumnModel>
                <Columns>
                    <ext:Column runat="server" Text="STT" DataIndex="STT" Width="50" Align="Center" Cls="Dam"></ext:Column>
                    <ext:Column runat="server" Text="Lãnh đạo" DataIndex="LanhDao" Width="140" Cls="Dam"/>
                    <ext:Column runat="server" Text="Nhân viên" DataIndex="NguoiThucHien" Width="140" Cls="Dam"/>
                    <ext:DateColumn runat="server" Text="Ngày" DataIndex="NgayNhap" Format="dd/MM/yyyy HH:mm:ss" Width="150" Cls="Dam"/>
                    <ext:Column runat="server" Text="Hướng xử lý" DataIndex="HuongXuLy" Width="160" Cls="Dam"/>
                    <ext:Column runat="server" Text="Nội dung" DataIndex="NoiDung" Width="400" CellWrap="true" Cls="Dam"/>
                    <ext:Column runat="server" Text="Ý kiến chỉ đạo" DataIndex="YKienChiDao" Width="300" CellWrap="true" Cls="Dam">
                        <Editor>
                            <ext:TextField runat="server" />
                        </Editor>
                    </ext:Column>
                    <ext:DateColumn runat="server" Text="Ngày chỉ đạo" DataIndex="NgayChiDao" Format="dd/MM/yyyy HH:mm:ss" Width="150" Cls="Dam"/>
                </Columns>
            </ColumnModel>
            <Plugins>
                <ext:CellEditing runat="server" ClicksToEdit="1" ID="CellEditing1">
                    <Listeners>
                        <BeforeEdit Handler="return beforeCellEditHandler(e);"></BeforeEdit>
                        <Edit Fn="edit" />
                    </Listeners>
                </ext:CellEditing>
            </Plugins>
        </ext:GridPanel>
    </form>
</body>
</html>
