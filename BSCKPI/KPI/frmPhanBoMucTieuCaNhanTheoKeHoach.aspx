<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPhanBoMucTieuCaNhanTheoKeHoach.aspx.cs" Inherits="BSCKPI.KPI.frmPhanBoMucTieuCaNhanTheoKeHoach" %>

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
                if (e.field == "TrongSo")
                {
                    var sum = getSum(App.grdPBChiTieu,8);

                    alert(sum);
                    if (total > 100)
                    {
                        alert("Tong trong so trong nhom khong duoc vuot qua 100");
                        return;
                    }
                }
                //BangPBMTCTX.EditCT(e.record.data.ThuTu, e.field, e.originalValue, e.value, e.record.data);
            }
        }
        var getSum = function (grid, index) {
            var dataIndex = grid.getColumnModel().getDataIndex(index),
                sum = 0;

            grid.getStore().each(function (record) {
                sum += record.get(dataIndex);
            });

            return sum;
        };
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" Locale="vi-VN"/>
    <form id="form1" runat="server">
        <ext:FieldContainer runat="server" Layout="HBoxLayout" MarginSpec="10 0 0 0">
            <Items>
                <ext:SelectBox runat="server" ID="slbThang" 
                            EmptyText="Tháng ...." DisplayField="Ten" ValueField="ID" MarginSpec="0 0 0 10" RenderXType="True">
                            <Listeners>
                                <Select Handler="#{stoNhanVien}.reload();" />
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
                                <Select Handler="#{stoNhanVien}.reload();" />
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
                <ext:SelectBox runat="server" ID="slbKeHoachDG" EmptyText="Kế hoạch đánh giá ..."
                    DisplayField="Ten" ValueField="ID" MarginSpec="0 0 0 10" Width="350" >
                    <Listeners>
                          <Select Handler="#{stoNhanVien}.reload();" />
                    </Listeners>
                    <Store>
                        <ext:Store runat="server" ID="stoKHDG">
                            <Fields>
                                <ext:ModelField Name="ID" />
                                <ext:ModelField Name="Ten" />
                            </Fields>
                        </ext:Store>
                    </Store>
                </ext:SelectBox>
            </Items>
        </ext:FieldContainer>

        <ext:GridPanel runat="server" ID="grdPBChiTieu" Width="1300" MinHeight="500" Layout="FitLayout">
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
                                                <ext:ModelField Name="TrongSoNhom" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
            <TopBar>
                <ext:Toolbar runat="server">
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
                                <ext:Label runat="server" ID="lblChucVu" Text="" StyleSpec="font-weight:bold;" MarginSpec="0 0 0 50"/>
                                <ext:Label runat="server" ID="lblChucDanh" Text="" StyleSpec="font-weight:bold;" MarginSpec="0 0 0 20"/>
                                <ext:Label runat="server" ID="lblMoTaCongViec" Text="" StyleSpec="font-weight:bold;" MarginSpec="0 0 0 20"/>

                        <ext:SplitButton runat="server" Scale="Medium" UI="Success" Text="Bản in" MarginSpec="0 0 0 50" Width="150">
                            <Menu>
                                <ext:Menu runat="server">
                                    <Items>
                                        <ext:MenuItem runat="server" Text="Bản in cá nhân" ID="btnInbangPhanBo" UI="Success">
                                            <DirectEvents>
                                                <Click OnEvent="btnInbangPhanBo_Click" />
                                            </DirectEvents>
                                        </ext:MenuItem>
                                        <ext:MenuItem runat="server" Text="Bản in theo kế hoạch" ID="btnInKeHoach" UI="Success" >
                                            <DirectEvents>
                                                <Click OnEvent="btnInKeHoach_Click" />
                                            </DirectEvents>
                                        </ext:MenuItem>
                                    </Items>
                                </ext:Menu>
                            </Menu>
                        </ext:SplitButton>

                        <%--<ext:Button runat="server" ID="btnInbangPhanBo" Text="In Bảng mục tiêu" Icon="Printer" MarginSpec="0 0 0 50">
                            <DirectEvents>
                                <Click OnEvent="btnInbangPhanBo_Click" />
                            </DirectEvents>
                        </ext:Button>--%>
                    </Items>
                </ext:Toolbar>
            </TopBar>
                            <ColumnModel runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn runat="server" ID="RowNumbererColumn1" Text="STT" Width="60" Align="Center"/>
                                    <ext:Column runat="server" ID="Column1" Text="Mã" DataIndex="MaKPI" Width="70"/>
                                    <ext:Column runat="server" ID="Column2" Text="Tên KPI" DataIndex="TenKPI" Width="200"/>
                                    <ext:Column runat="server" ID="Column3" Text="Đơn vị tính" DataIndex="DonViTinh"  Align="Center"/>
                                    <ext:Column runat="server" ID="Column4" Text="Tần suất đo" DataIndex="TanSuatDo"  Align="Center"/>
                                    <ext:Column runat="server" ID="Column5" Text="Xu hướng yêu cầu" DataIndex="XuHuongYeuCau" Width="130" Align="Center"/>
                                    <ext:NumberColumn runat="server" ID="cTrongSoNhom" Text="Trọng số nhóm" DataIndex="TrongSoNhom" Format="000%"  Align="Center" Width="120"/>
                                    <ext:NumberColumn runat="server" ID="NumberColumn1" Text="Trọng số" DataIndex ="TrongSo" Width="150" Align="Right">
                                    <Renderer Handler="return Ext.util.Format.number(value,'0,000.0')+'%';"></Renderer>
                                    <SummaryRenderer  Handler="return Ext.util.Format.number(value,'0,000.0')+'%';"></SummaryRenderer >
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
                                    <ext:Column runat="server" Width="100" />
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
    </form>
</body>
</html>
