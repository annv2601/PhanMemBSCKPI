<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNhiemVuTrongTam.ascx.cs" Inherits="BSCKPI.UC.ucNhiemVuTrongTam" %>
<ext:Panel 
    ID="Panel1" 
    runat="server" 
    BodyPadding="5"
    Layout="AnchorLayout">
    <Items>
        <ext:Hidden runat="server" ID="txtID" />
        <ext:Hidden runat="server" ID="txtTrangThai" />
        <ext:FieldContainer runat="server" Layout="HBoxLayout">
            <Items>
                <ext:ComboBox runat="server" ID="cboNhanVien" FieldLabel="Nhân viên"
                    QueryMode="Local" DisplayField="TenNhanVien" ValueField="IDNhanVien" Width="320" LabelWidth="90">
                    <Store>
                        <ext:Store runat="server" ID="stoNhanVien">
                            <Fields>
                                <ext:ModelField Name="IDNhanVien" Type="String" />
                                <ext:ModelField Name="TenNhanVien" />
                            </Fields>
                        </ext:Store>
                    </Store>
                </ext:ComboBox>
                <ext:NumberField ID="txtMucTieu" runat="server" FieldLabel="Mục tiêu" Width="200" AllowDecimals="true" DecimalPrecision="2" MarginSpec="0 0 0 10" LabelWidth="70"/>
                <ext:ComboBox ID="cboDonViTinh"
                            runat="server"
                            FieldLabel="Đơn vị tính"
                            DisplayField="Ten"
                            ValueField="ID"
                            Width="180" QueryMode="Local"
                            TypeAhead="true" MarginSpec="0 0 0 10" LabelWidth="70">
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
                <ext:ComboBox ID="cboTanSuatDo"
                            runat="server"
                            FieldLabel="Tần suất"
                            DisplayField="Ten"
                            ValueField="ID"
                            Width="180" QueryMode="Local"
                            TypeAhead="true" MarginSpec="0 0 0 10" LabelWidth="70">
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
            </Items>
        </ext:FieldContainer>
        <ext:TextArea runat="server" ID="txtTen" FieldLabel="Tên công việc" Width="900" LabelWidth="90"/>
        <%--<ext:FieldContainer runat="server" Layout="HBoxLayout">
            <Items>
                <ext:ComboBox ID="cboDonViTinh"
                            runat="server"
                            FieldLabel="Đơn vị tính"
                            DisplayField="Ten"
                            ValueField="ID"
                            Width="150" QueryMode="Local"
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
                <ext:NumberField ID="txtMucTieu" runat="server" FieldLabel="Mục tiêu" Width="200" AllowDecimals="true" DecimalPrecision="2" MarginSpec="0 0 0 10"/>
            </Items>
        </ext:FieldContainer>--%>
    </Items>
</ext:Panel>