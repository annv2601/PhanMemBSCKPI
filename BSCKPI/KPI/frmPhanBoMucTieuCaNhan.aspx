<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPhanBoMucTieuCaNhan.aspx.cs" Inherits="BSCKPI.KPI.frmPhanBoMucTieuCaNhan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../resource/css/main.css" rel="stylesheet" />
    <style>
        .x-grid-body .x-grid-cell-Cost {
            background-color : #f1f2f4;
        }

        .x-grid-row-summary .x-grid-cell-Cost .x-grid-cell-inner{
            background-color : #e1e2e4;
        }

        .task .x-grid-cell-inner {
            padding-left: 15px;
        }

        .x-grid-row-summary .x-grid-cell-inner {
            font-weight: bold;
            font-size: 16px;
            background-color : #f1f2f4;
        }
    </style>
    <script type="text/javascript">
        var editNV = function (editor, e)
        {
            if (e.value !== e.originalValue)
            {
                BangPBMTNVX.EditNV(e.record.data.ThuTu, e.field, e.originalValue, e.value, e.record.data);
            }
        }

        var editCT = function (editor, e) {
            if (e.value !== e.originalValue) {
                BangPBMTCTX.EditCT(e.record.data.ThuTu, e.field, e.originalValue, e.value, e.record.data);
            }
        }
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" Locale="vi-VN"/>
    <form id="form1" runat="server">
        
        <ext:Panel
            runat="server"
            MinHeight="500"
            Layout="CardLayout"
            ActiveIndex="0"
            DefaultBorder="false"
            DefaultPadding="5">
            <TopBar>
                <ext:Toolbar runat="server" StyleSpec="padding-bottom:0px;">
                    <Items>
                        <ext:SelectBox runat="server" ID="slbThang" 
                            EmptyText="Tháng ...." DisplayField="Ten" ValueField="ID" MarginSpec="0 0 0 10" RenderXType="True">
                            <Listeners>
                                <Select Handler="#{stoNhanVien}.reload();#{stoChiTieu}.reload();" />
                            </Listeners>
                            <Store>
                                <ext:Store runat="server" ID="stoThang">
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
                        </ext:SelectBox>
                        <ext:SelectBox runat="server" ID="slbNam" QueryMode="Local" TypeAhead="true"
                            EmptyText="Năm ...." DisplayField="Ten" ValueField="ID" MarginSpec="0 0 0 10" RenderXType="true">
                            <Listeners>
                                <Select Handler="#{stoNhanVien}.reload();#{stoChiTieu}.reload();" />
                            </Listeners>
                            <Store>
                                <ext:Store runat="server" ID="stoNam" AutoDataBind="true">
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
                        </ext:SelectBox>
                        
                        <ext:TabStrip runat="server" Width="500">
                            <Items>
                                <ext:Tab ActionItemID="pnlPBNhanVien" Text="Theo chỉ tiêu KPI" Icon="Tick"/>
                                <ext:Tab ActionItemID="pnlPBChiTieu" Text="Theo nhân viên" Icon="UserHome"/>
                            </Items>
                        </ext:TabStrip>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            
            <Items>
                <ext:Panel ID="pnlPBNhanVien" runat="server" Header="false">
                    <Items>
                        <ext:FieldContainer runat="server" Layout="HBoxLayout" MarginSpec="0 0 10 0">
                            <Items>
                                <ext:SelectBox runat="server" ID="slbChiTieuKPI" QueryMode="Local" FieldLabel="Chỉ tiêu KPI"
                                    DisplayField="Ten" ValueField="ID" LabelStyle="font-weight:bold;" Width="350">
                                    <Listeners>
                                        <Select Handler="#{stoPhanBoNV}.reload();" />
                                    </Listeners>
                                    <Store>
                                        <ext:Store runat="server" ID="stoChiTieu" OnReadData="DanhSachChiTieu">
                                            <Fields>
                                                <ext:ModelField Name="Ten" />
                                                <ext:ModelField Name="ID" />
                                            </Fields>
                                        </ext:Store>
                                    </Store>
                                </ext:SelectBox>
                                <ext:Label runat="server" ID="lblDonViTinh" Text="" StyleSpec="font-weight:bold;" MarginSpec="10 0 0 50"/>
                                <ext:Label runat="server" ID="lblTanSuatDo" Text="" StyleSpec="font-weight:bold;" MarginSpec="10 0 0 20"/>
                                <ext:Label runat="server" ID="lblXuHuongYeuCau" Text="" StyleSpec="font-weight:bold;" MarginSpec="10 0 0 20"/>
                            </Items>
                        </ext:FieldContainer>
                        
                        <ext:GridPanel runat="server" ID="grdPBNhanVien">
                            <Store>
                            <ext:Store runat="server" ID="stoPhanBoNV" OnReadData="DanhSachPBMTCT">
                                    <Model>
                                        <ext:Model runat="server" IDProperty="ThuTu">
                                            <Fields>
                                                <ext:ModelField Name="ThuTu" />
                                                <ext:ModelField Name="IDNhanVien" />
                                                <ext:ModelField Name="TenNhanVien" />
                                                <ext:ModelField Name="ChucVu" />
                                                <ext:ModelField Name="ChucDanh" />
                                                <ext:ModelField Name="XuHuongYeuCau" />
                                                <ext:ModelField Name="DonViTinh" />
                                                <ext:ModelField Name="TanSuatDo" />
                                                <ext:ModelField Name="MucTieu" />
                                                <ext:ModelField Name="TrongSo" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                                </Store>
                            <ColumnModel runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn runat="server" ID="nvSTT" Text="STT" Width="70" Align="Center"/>                                    
                                    <ext:Column runat="server" ID="nvTenKPI" Text="Tên nhân viên" DataIndex="TenNhanVien" Width="200"/>
                                    <ext:Column runat="server" ID="Column6" Text="Chức vụ" DataIndex="ChucVu" Width="150"/>
                                    <ext:Column runat="server" ID="Column7" Text="Chức danh" DataIndex="ChucDanh" Width="150"/>
                                    <ext:NumberColumn runat="server" ID="nvTrongSo" Text="Trọng số" SummaryType="Sum" DataIndex ="TrongSo" Width="150" Align="Right">
                                    <Renderer Handler="return Ext.util.Format.number(value,'0,000.00')+'%';"></Renderer>
                                    <SummaryRenderer  Handler="return Ext.util.Format.number(value,'0,000.00')+'%';"></SummaryRenderer >
                                        <Editor>
                                            <ext:NumberField ID="txtnvTrongSo" runat="server" AllowDecimals="true" DecimalPrecision="2" />
                                        </Editor>
                                    </ext:NumberColumn>
                                    
                                    <ext:NumberColumn runat="server" ID="nvMucTieu" Text="Mục tiêu" SummaryType="Sum" DataIndex ="MucTieu" Width="200" Align="Right">
                                    <SummaryRenderer  Handler="return Ext.util.Format.number(value,'000,000,000.00');"></SummaryRenderer >
                                        <Editor>
                                            <ext:NumberField ID="NumberField1" runat="server" AllowDecimals="true" DecimalPrecision="2" />
                                        </Editor>
                                    </ext:NumberColumn>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:CellSelectionModel runat="server" >                    
                                </ext:CellSelectionModel>
                            </SelectionModel>
                            <Features>
                                <ext:Summary runat="server" />
                            </Features>
                            <Plugins>                
                                <ext:CellEditing runat="server" ClicksToEdit="1">
                                    <Listeners>
                                        <Edit Fn="editNV" />
                                    </Listeners>
                                </ext:CellEditing>
                            </Plugins>
                        </ext:GridPanel>
                    </Items>
                </ext:Panel>
                <ext:Panel ID="pnlPBChiTieu" runat="server" Header="false">
                    <Items>
                        <ext:FieldContainer runat="server" Layout="HBoxLayout" MarginSpec="0 0 10 0">
                            <Items>
                                <ext:SelectBox runat="server" ID="slbNhanVien" QueryMode="Local" FieldLabel="Nhân viên"
                                    DisplayField="TenNhanVien" ValueField="IDNhanVien" LabelStyle="font-weight:bold;" Width="350">
                                    <Listeners>
                                        <Select Handler="#{stoPhanBoCT}.reload();" />
                                    </Listeners>
                                    <Store>
                                        <ext:Store runat="server" ID="stoNhanVien" OnReadData="DanhSachNhanVien">
                                            <Fields>
                                                <ext:ModelField Name="TenNhanVien" />
                                                <ext:ModelField Name="IDNhanVien" />
                                            </Fields>
                                        </ext:Store>
                                    </Store>
                                </ext:SelectBox>
                                <ext:Label runat="server" ID="lblChucVu" Text="" StyleSpec="font-weight:bold;" MarginSpec="10 0 0 50"/>
                                <ext:Label runat="server" ID="lblChucDanh" Text="" StyleSpec="font-weight:bold;" MarginSpec="10 0 0 20"/>
                                <ext:Label runat="server" ID="lblMoTaCongViec" Text="" StyleSpec="font-weight:bold;" MarginSpec="10 0 0 20"/>
                            </Items>
                        </ext:FieldContainer>
                        
                        <ext:GridPanel runat="server" ID="grdPBChiTieu">
                            <Store>
                                <ext:Store runat="server" ID="stoPhanBoCT" OnReadData="DanhSachPBMTNV">
                                    <Model>
                                        <ext:Model runat="server" IDProperty="ThuTu">
                                            <Fields>
                                                <ext:ModelField Name="ThuTu" />
                                                <ext:ModelField Name="IDKPI" />
                                                <ext:ModelField Name="MaKPI" />
                                                <ext:ModelField Name="TenKPI" />
                                                <ext:ModelField Name="XuHuongYeuCau" />
                                                <ext:ModelField Name="DonViTinh" />
                                                <ext:ModelField Name="TanSuatDo" />
                                                <ext:ModelField Name="MucTieu" />
                                                <ext:ModelField Name="TrongSo" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                            <ColumnModel runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn runat="server" ID="RowNumbererColumn1" Text="STT" Width="70" Align="Center"/>
                                    <ext:Column runat="server" ID="Column1" Text="Mã" DataIndex="MaKPI" Width="80"/>
                                    <ext:Column runat="server" ID="Column2" Text="Tên KPI" DataIndex="TenKPI" Width="200"/>
                                    <ext:Column runat="server" ID="Column3" Text="Đơn vị tính" DataIndex="DonViTinh" />
                                    <ext:Column runat="server" ID="Column4" Text="Tần suất đo" DataIndex="TanSuatDo" />
                                    <ext:Column runat="server" ID="Column5" Text="Xu hướng yêu cầu" DataIndex="XuHuongYeuCau" Width="150"/>
                                    <ext:NumberColumn runat="server" ID="NumberColumn1" Text="Trọng số" DataIndex ="TrongSo" Width="150" Align="Right">
                                    <Renderer Handler="return Ext.util.Format.number(value,'0,000.00')+'%';"></Renderer>
                                    <SummaryRenderer  Handler="return Ext.util.Format.number(value,'0,000.00')+'%';"></SummaryRenderer >
                                        <Editor>
                                            <ext:NumberField ID="NumberField2" runat="server" AllowDecimals="true" DecimalPrecision="2" />
                                        </Editor>
                                    </ext:NumberColumn>
                                    <ext:NumberColumn runat="server" ID="NumberColumn2" Text="Mục tiêu" DataIndex ="MucTieu" Width="200" Align="Right">
                                    <SummaryRenderer  Handler="return Ext.util.Format.number(value,'000,000,000.00');"></SummaryRenderer >
                                        <Editor>
                                            <ext:NumberField ID="NumberField3" runat="server" AllowDecimals="true" DecimalPrecision="2" />
                                        </Editor>
                                    </ext:NumberColumn>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:CellSelectionModel runat="server" >                    
                                </ext:CellSelectionModel>
                            </SelectionModel>
                            <Plugins>                
                                <ext:CellEditing runat="server" ClicksToEdit="1">
                                    <Listeners>
                                        <Edit Fn="editCT" />
                                    </Listeners>
                                </ext:CellEditing>
                            </Plugins>
                        </ext:GridPanel>
                    </Items>
                </ext:Panel>
            </Items>
        </ext:Panel>
    </form>
</body>
</html>
