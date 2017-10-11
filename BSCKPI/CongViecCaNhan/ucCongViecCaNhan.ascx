<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCongViecCaNhan.ascx.cs" Inherits="BSCKPI.CongViecCaNhan.ucCongViecCaNhan" %>
<ext:Panel ID="Panel1" runat="server" 
    BodyPadding="5" Layout="AnchorLayout">
    <Defaults>
        <ext:Parameter Name="margin" Value="0 0 10 10" Mode="Value" />
    </Defaults>
    <Items>
        <ext:Hidden runat="server" ID="txtMaCongViecCaNhan" />
        <ext:FieldContainer runat="server" Layout="HBoxLayout">
            <Items>
                <ext:SelectBox runat="server" ID="slbLanhDaoGiaoViec" DisplayField="TenNhanVien" ValueField="IDNhanVien"
                    FieldLabel="Lãnh đạo giao việc" LabelStyle="font-weight:bold;padding:0;" LabelWidth="130" Width="350">
                    <Store>
                        <ext:Store runat="server" ID="stoLanhDaoGV">
                            <Fields>
                                <ext:ModelField Name="IDNhanVien" />
                                <ext:ModelField Name="TenNhanVien" />
                            </Fields>
                        </ext:Store>
                    </Store>
                </ext:SelectBox>
                <ext:SelectBox runat="server" ID="slbNguoiTheoDoi" DisplayField="TenNhanVien" ValueField="IDNhanVien"
                    FieldLabel="Lãnh đạo theo dõi" LabelStyle="font-weight:bold;padding:0;" LabelWidth="130" Width="350" MarginSpec="0 0 0 20">
                    <Store>
                        <ext:Store runat="server" ID="stoLanhDaoTD">
                            <Fields>
                                <ext:ModelField Name="IDNhanVien" />
                                <ext:ModelField Name="TenNhanVien" />
                            </Fields>
                        </ext:Store>
                    </Store>
                </ext:SelectBox>
            </Items>
        </ext:FieldContainer>
        
        <ext:TextArea runat="server" ID="txtNoiDung" FieldLabel="Nội dung" Width="740" LabelStyle="font-weight:bold;padding:0;"/>
        <ext:FieldContainer runat="server" Layout="HBoxLayout">
            <Items>
                <ext:DateField runat="server" ID="txtNgayGiao" Format="dd/MM/yyyy" FieldLabel="Ngày giao" LabelStyle="font-weight:bold;padding:0;"/>
                <ext:SelectBox runat="server" ID="slbMucDo" DisplayField="Ten" ValueField="ID" FieldLabel="Mức độ" LabelStyle="font-weight:bold;padding:0;" MarginSpec="0 0 0 30">
                    <Store>
                        <ext:Store runat="server" ID="stoMucDo">
                            <Fields>
                                <ext:ModelField Name="ID" />
                                <ext:ModelField Name="Ten" />
                            </Fields>
                        </ext:Store>
                    </Store>
                </ext:SelectBox>
            </Items>
        </ext:FieldContainer>
        <ext:FieldContainer runat="server" Layout="HBoxLayout">
            <Items>
                <ext:DateField runat="server" ID="txtNgayDenHan" Format="dd/MM/yyyy" FieldLabel="Ngày đến hạn" LabelStyle="font-weight:bold;padding:0;"/>
                <ext:TimeField runat="server" ID="txtGioDenHan" MinTime="08:00:00" MaxTime="20:00:00" Increment="30" Format="H:mm:ss" FieldLabel="Giờ đến hạn" LabelStyle="font-weight:bold;padding:0;" MarginSpec="0 0 0 30"/>
            </Items>
        </ext:FieldContainer>
        <ext:SelectBox runat="server" ID="slbNguoiLamChinh" DisplayField="TenNhanVien" ValueField="IDNhanVien"
            FieldLabel="Người làm chính" LabelStyle="font-weight:bold;padding:0;" LabelWidth="120" Width="350">
            <Store>
                <ext:Store runat="server" ID="stoNguoiLamChinh">
                    <Fields>
                        <ext:ModelField Name="IDNhanVien" />
                        <ext:ModelField Name="TenNhanVien" />
                    </Fields>
                </ext:Store>
            </Store>
        </ext:SelectBox>
        <ext:TextArea runat="server" ID="txtChiDaoChung" FieldLabel="Chỉ đạo chung" Width="740" LabelStyle="font-weight:bold;padding:0;"/>
    </Items>
</ext:Panel>