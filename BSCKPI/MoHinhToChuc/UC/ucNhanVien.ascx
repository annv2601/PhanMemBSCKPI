<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNhanVien.ascx.cs" Inherits="BSCKPI.MoHinhToChuc.UC.ucNhanVien" %>
<ext:Panel ID="Panel1" runat="server" 
    BodyPadding="5" Layout="AnchorLayout">
    <Items>
        <ext:Hidden runat="server" ID="txtIDNhanVien" />
        <ext:FieldContainer runat="server" Layout="HBoxLayout">
            <Items>
                <ext:TextField runat="server" ID="txtHoDem" FieldLabel="Họ đệm" EmptyText="Nhập Họ và tên đệm" LabelStyle="font-weight:bold;" LabelWidth="80"/>
                <ext:TextField runat="server" ID="txtTen" FieldLabel="Tên" EmptyText="Nhập Tên gọi" LabelStyle="font-weight:bold;" LabelWidth="60" MarginSpec="0 0 0 10"/>
                <ext:TextField runat="server" ID="txtMa" FieldLabel="Mã" EmptyText="Nhập Mã nhân viên" LabelStyle="font-weight:bold;" LabelWidth="60" MarginSpec="0 0 0 10"/>
                <ext:Hidden runat="server" ID="txtTenNhanVien" />
            </Items>
        </ext:FieldContainer>
        <ext:FieldContainer runat="server" Layout="HBoxLayout">
            <Items>
                <ext:DateField runat="server" ID="txtNgaySinh" FieldLabel="Ngày sinh" EmptyText="Nhập ngày tháng năm sinh" Format="dd/MM/yyyy"  LabelStyle="font-weight:bold;" LabelWidth="80"/>
                <ext:SelectBox runat="server" ID="slbGioiTinh" FieldLabel="Giới tính" DisplayField="Ten" ValueField="ID" EmptyText="Chọn giới tính" LabelStyle="font-weight:bold;" LabelWidth="60" MarginSpec="0 0 0 10">
                    <Store>
                        <ext:Store runat="server" ID="stoGioiTinh">
                            <Fields>
                                <ext:ModelField Name="ID" />
                                <ext:ModelField Name="Ten" />
                            </Fields>
                        </ext:Store>
                    </Store>
                </ext:SelectBox>
                <ext:TextField runat="server" ID="txtDienThoaiDiDong" FieldLabel="Di động" EmptyText="Nhập số điện thoại di động" LabelStyle="font-weight:bold;" LabelWidth="60"  MarginSpec="0 0 0 10"/>
            </Items>
        </ext:FieldContainer>
        <ext:TextField runat="server" ID="txtEmail" FieldLabel="Email" EmptyText="Nhập địa chỉ Email"  LabelStyle="font-weight:bold;" LabelWidth="80" Width="750"/>
        <ext:FieldContainer runat="server" Layout="HBoxLayout">
            <Items>
                <ext:ComboBox runat="server" ID="cboChucVu" FieldLabel="Chức vụ" EmptyText="Chọn chức vụ quản lý"
                    DisplayField="Ten" ValueField="ID" QueryMode="Local"  LabelStyle="font-weight:bold;" LabelWidth="80">
                    <Store>
                        <ext:Store runat="server" ID="stoChucVu">
                            <Model>
                                <ext:Model runat="server" IDProperty="ID">
                                    <Fields>
                                        <ext:ModelField Name="ID" />
                                        <ext:ModelField Name="Ten" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" Hidden="true" Weight="-1" />
                    </Triggers>
                    <Listeners>
                        <Select Handler="this.getTrigger(0).show();" />
                        <BeforeQuery Handler="this.getTrigger(0)[this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                        <TriggerClick Handler="if (index == 0) {
                                                   this.clearValue();
                                                   this.getTrigger(0).hide();
                                               }" />
                    </Listeners>
                </ext:ComboBox>
                <ext:ComboBox runat="server" ID="cboChucDanh" FieldLabel="Chức danh" EmptyText="Chọn chức danh công việc"
                    DisplayField="Ten" ValueField="ID" QueryMode="Local" LabelStyle="font-weight:bold;" LabelWidth="70" MarginSpec="0 0 0 30">
                    <Store>
                        <ext:Store runat="server" ID="stoChucDanh">
                            <Model>
                                <ext:Model runat="server" IDProperty="ID">
                                    <Fields>
                                        <ext:ModelField Name="ID" />
                                        <ext:ModelField Name="Ten" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" Hidden="true" Weight="-1" />
                    </Triggers>
                    <Listeners>
                        <Select Handler="this.getTrigger(0).show();" />
                        <BeforeQuery Handler="this.getTrigger(0)[this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                        <TriggerClick Handler="if (index == 0) {
                                                   this.clearValue();
                                                   this.getTrigger(0).hide();
                                               }" />
                    </Listeners>
                </ext:ComboBox>
            </Items>
        </ext:FieldContainer>
        <ext:TextArea runat="server" ID="txtMoTaCongViec" FieldLabel="Mô tả công việc" EmptyText="Nhập mô tả công việc theo vị trí công tác"  LabelStyle="font-weight:bold;" LabelWidth="80" Width="750"/>
    </Items>
</ext:Panel>