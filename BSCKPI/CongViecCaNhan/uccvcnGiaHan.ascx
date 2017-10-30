<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uccvcnGiaHan.ascx.cs" Inherits="BSCKPI.CongViecCaNhan.uccvcnGiaHan" %>
<ext:Panel ID="Panel1" runat="server" 
    BodyPadding="5" Layout="AnchorLayout">
    <Items>
        <ext:Hidden runat="server" ID="txtMaCongViec" />
        <ext:Hidden runat="server" ID="txtNguoiThucHien" />
        <ext:FieldContainer runat="server" Layout="HBoxLayout">
            <Items>
                <ext:DateField runat="server" ID="txtNgayHanCu" FieldLabel="Ngày Hạn cũ" Format="dd/MM/yyyy" ReadOnly="true" LabelStyle="font-weight:bold;padding:0;"/>
                <ext:TimeField runat="server" ID="txtGioHanCu" MinTime="08:00:00" MaxTime="20:00:00" Increment="30" Format="H:mm:ss" FieldLabel="Giờ Hạn cũ" LabelStyle="font-weight:bold;padding:0;" MarginSpec="0 0 0 20" ReadOnly="true"/>
            </Items>
        </ext:FieldContainer>
        <ext:FieldContainer runat="server" Layout="HBoxLayout">
            <Items>
                <ext:DateField runat="server" ID="txtNgayHanMoi" FieldLabel="Ngày Hạn mới" Format="dd/MM/yyyy" LabelStyle="font-weight:bold;padding:0;"/>
                <ext:TimeField runat="server" ID="txtGioHanMoi" MinTime="08:00:00" MaxTime="20:00:00" Increment="30" Format="H:mm:ss" FieldLabel="Giờ Hạn mới" LabelStyle="font-weight:bold;padding:0;" MarginSpec="0 0 0 20"/>
            </Items>
        </ext:FieldContainer>
        <ext:TextArea runat="server" ID="txtLyDo" FieldLabel="Lý do" LabelStyle="font-weight:bold;padding:0;" Width="580" />
    </Items>
 </ext:Panel>