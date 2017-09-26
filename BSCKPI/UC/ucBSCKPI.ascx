<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucBSCKPI.ascx.cs" Inherits="BSCKPI.UC.ucBSCKPI" %>

<ext:Panel 
    ID="Panel1" 
    runat="server" 
    BodyPadding="5"
    Layout="AnchorLayout">
    <Items>
        <ext:Panel 
            ID="Panel2" 
            runat="server" 
            Border="false" 
            Header="false" 
            AnchorHorizontal="100%" 
            Layout="FormLayout">
            <Items>
                <ext:FieldContainer runat="server" Layout="HBoxLayout">
                    <FieldDefaults LabelAlign="Top" />
                    <Items>
                        <ext:Hidden runat="server" ID="txtIDBSC" />
                        <ext:Hidden runat="server" ID="txtidChiTieuTren" />
                        <ext:TextField ID="txtTen" runat="server" FieldLabel="Tên" Width="450" MarginSpec="0 0 0 10"/>
                        <ext:NumberField ID="txtMucTieu" runat="server" FieldLabel="Mục tiêu" Width="150" AllowDecimals="true" DecimalPrecision="3" MarginSpec="0 0 0 10"/>
                        <ext:ComboBox ID="cboDonViTinh"
                            runat="server"
                            FieldLabel="Đơn vị tính"
                            DisplayField="Ten"
                            ValueField="ID"
                            Width="120" QueryMode="Local"
                            TypeAhead="true" MarginSpec="0 0 0 10">
                            <Store>
                                <ext:Store runat="server" ID="stoDonViTinh" AutoDataBind="true">
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
                        </ext:ComboBox>
                        <ext:NumberField ID="txtTrongSo" runat="server" FieldLabel="Trọng số (%)" Width="100" AllowDecimals="true" DecimalPrecision="3" MarginSpec="0 0 0 10" MinValue="0" MaxValue="100"/>
                    </Items>
                </ext:FieldContainer>
                <ext:FieldContainer runat="server" Layout="HBoxLayout">
                    <FieldDefaults LabelAlign="Top" />
                    <Items>
                        <ext:TextField ID="txtMa" runat="server" FieldLabel="Mã" Width="100" MarginSpec="0 0 0 10" />
                        <ext:NumberField ID="txtMuc" runat="server" FieldLabel="Mức" Width="100" AllowDecimals="false" MarginSpec="0 0 0 10" />
                        <ext:Checkbox ID="chkInDam" runat="server" FieldLabel="In đậm" Width="80" MarginSpec="0 0 0 30" />
                        <ext:Checkbox ID="chkInNghieng" runat="server" FieldLabel="In nghiêng" Width="80" MarginSpec="0 0 0 30" />

                        <ext:ComboBox ID="cboTanSuatDo"
                            runat="server"
                            FieldLabel="Tần suất"
                            DisplayField="Ten"
                            ValueField="ID"
                            Width="150" QueryMode="Local"
                            TypeAhead="true" MarginSpec="0 0 0 30">
                            <Store>
                                <ext:Store runat="server" ID="stoTanSuat" AutoDataBind="true">
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
                        </ext:ComboBox>

                        <ext:ComboBox ID="cboXuHuongYeuCau"
                            runat="server"
                            FieldLabel="Xu hướng"
                            DisplayField="Ten"
                            ValueField="ID"
                            Width="120" QueryMode="Local"
                            TypeAhead="true" MarginSpec="0 0 0 10">
                            <Store>
                                <ext:Store runat="server" ID="stoXuHuong" AutoDataBind="true">
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
                        </ext:ComboBox>

                        <ext:NumberField ID="txtSTTsx" runat="server" FieldLabel="STTsx" AllowDecimals="true" DecimalPrecision="1" Width="100" MarginSpec="0 0 0 10"/>
                    </Items>
                </ext:FieldContainer>
            </Items>
        </ext:Panel>
    </Items>
</ext:Panel>