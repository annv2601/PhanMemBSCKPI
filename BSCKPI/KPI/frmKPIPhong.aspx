<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmKPIPhong.aspx.cs" Inherits="BSCKPI.KPI.frmKPIPhong" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../resource/css/main.css" rel="stylesheet" />
    <script type="text/javascript">
        var edit = function (editor, e)
        {
            if (e.value !== e.originalValue)
            {
                BangKPIPX.Edit(e.record.data.IDKPI, e.field, e.originalValue, e.value, e.record.data);
            }
        }
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" />
    <form id="form1" runat="server">
        <ext:Store ID="stoKPIPhong" runat="server" OnReadData="dsKPIPhong">
                    <Model>
                        <ext:Model runat="server" IDProperty="IDKPI">
                            <Fields>
                                <ext:ModelField Name="IDKPI" />
                                <ext:ModelField Name="Ma" />
                                <ext:ModelField Name="TenKPI" />                                
                                <ext:ModelField Name="DonViTinh" />
                                <ext:ModelField Name="TanSuatDo" />
                                <ext:ModelField Name="XuHuongYeuCau" />
                                <ext:ModelField Name="MucTieuNam" Type="Float" />
                                <ext:ModelField Name="MucTieuThang1" Type="Float" />
                                <ext:ModelField Name="MucTieuThang2" Type="Float" />
                                <ext:ModelField Name="MucTieuThang3" Type="Float" />
                                <ext:ModelField Name="MucTieuThang4" Type="Float" />
                                <ext:ModelField Name="MucTieuThang5" Type="Float" />
                                <ext:ModelField Name="MucTieuThang6" Type="Float" />
                                <ext:ModelField Name="MucTieuThang7" Type="Float" />
                                <ext:ModelField Name="MucTieuThang8" Type="Float" />
                                <ext:ModelField Name="MucTieuThang9" Type="Float" />
                                <ext:ModelField Name="MucTieuThang10" Type="Float" />
                                <ext:ModelField Name="MucTieuThang11" Type="Float" />
                                <ext:ModelField Name="MucTieuThang12" Type="Float" />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>

        <ext:GridPanel runat="server" Title="KPI 12 tháng" ID="grdKPIP" StoreID="stoKPIPhong" 
            MinHeight="500">
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:SelectBox runat="server" ID="slbNam" DisplayField="Ten" ValueField="ID"
                            EmptyText="Chọn năm ..." FieldLabel="Năm">
                            <Listeners>
                                <Select Handler="#{stoKPIPhong}.reload();" />
                            </Listeners>
                            <Store>
                                <ext:Store runat="server" ID="stoNam">
                                    <Fields>
                                        <ext:ModelField Name="ID" />
                                        <ext:ModelField Name="Ten" />
                                    </Fields>
                                </ext:Store>
                            </Store>
                        </ext:SelectBox>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <View>
                <ext:GridView ID="GridView1" runat="server">
                    
                </ext:GridView>
            </View>
            <ColumnModel runat="server">
                        <Columns>
                            <ext:RowNumbererColumn runat="server" Text="STT" Width="70" Align="Center" StyleSpec="font-weight:bold;"/>
                            <ext:Column runat="server" Text="Mã" DataIndex="Ma" Width="100" StyleSpec="font-weight:bold;"/>
                            <ext:Column runat="server" Text="Tên" DataIndex="TenKPI" Width="150" StyleSpec="font-weight:bold;"/>
                            <ext:Column runat="server" Text="Đơn vị tính" DataIndex="DonViTinh"  StyleSpec="font-weight:bold;"/>
                            <ext:Column runat="server" Text="Tần suất đo" DataIndex="TanSuatDo"  StyleSpec="font-weight:bold;"/>
                            <ext:Column runat="server" Text="Xu hướng" DataIndex="XuHuongYeuCau"  StyleSpec="font-weight:bold;"/>

                            <ext:NumberColumn runat="server" Text="Năm" DataIndex="MucTieuNam" Format="000,000,000.00" Align="Right" StyleSpec="font-weight:bold;">
                                <Editor>
                                    <ext:NumberField runat="server" ID="txtMTNam" AllowDecimals="true" DecimalPrecision="2" />
                                </Editor>
                            </ext:NumberColumn>
                            <ext:NumberColumn runat="server" Text="Tháng 1" DataIndex="MucTieuThang1" Format="000,000,000.00" Align="Right" StyleSpec="font-weight:bold;">
                                <Editor>
                                    <ext:NumberField runat="server" ID="NumberField1" AllowDecimals="true" DecimalPrecision="2" />
                                </Editor>
                            </ext:NumberColumn>
                            <ext:NumberColumn runat="server" Text="Tháng 2" DataIndex="MucTieuThang2" Format="000,000,000.00" Align="Right" StyleSpec="font-weight:bold;">
                                <Editor>
                                    <ext:NumberField runat="server" ID="NumberField2" AllowDecimals="true" DecimalPrecision="2" />
                                </Editor>
                            </ext:NumberColumn>
                            <ext:NumberColumn runat="server" Text="Tháng 3" DataIndex="MucTieuThang3" Format="000,000,000.00" Align="Right" StyleSpec="font-weight:bold;">
                                <Editor>
                                    <ext:NumberField runat="server" ID="NumberField3" AllowDecimals="true" DecimalPrecision="2" />
                                </Editor>
                            </ext:NumberColumn>
                            <ext:NumberColumn runat="server" Text="Tháng 4" DataIndex="MucTieuThang4" Format="000,000,000.00" Align="Right" StyleSpec="font-weight:bold;">
                                <Editor>
                                    <ext:NumberField runat="server" ID="NumberField4" AllowDecimals="true" DecimalPrecision="2" />
                                </Editor>
                            </ext:NumberColumn>
                            <ext:NumberColumn runat="server" Text="Tháng 5" DataIndex="MucTieuThang5" Format="000,000,000.00" Align="Right" StyleSpec="font-weight:bold;">
                                <Editor>
                                    <ext:NumberField runat="server" ID="NumberField5" AllowDecimals="true" DecimalPrecision="2" />
                                </Editor>
                            </ext:NumberColumn>
                            <ext:NumberColumn runat="server" Text="Tháng 6" DataIndex="MucTieuThang6" Format="000,000,000.00" Align="Right" StyleSpec="font-weight:bold;">
                                <Editor>
                                    <ext:NumberField runat="server" ID="NumberField6" AllowDecimals="true" DecimalPrecision="2" />
                                </Editor>
                            </ext:NumberColumn>
                            <ext:NumberColumn runat="server" Text="Tháng 7" DataIndex="MucTieuThang7" Format="000,000,000.00" Align="Right" StyleSpec="font-weight:bold;">
                                <Editor>
                                    <ext:NumberField runat="server" ID="NumberField7" AllowDecimals="true" DecimalPrecision="2" />
                                </Editor>
                            </ext:NumberColumn>
                            <ext:NumberColumn runat="server" Text="Tháng 8" DataIndex="MucTieuThang8" Format="000,000,000.00" Align="Right" StyleSpec="font-weight:bold;">
                                <Editor>
                                    <ext:NumberField runat="server" ID="NumberField8" AllowDecimals="true" DecimalPrecision="2" />
                                </Editor>
                            </ext:NumberColumn>
                            <ext:NumberColumn runat="server" Text="Tháng 9" DataIndex="MucTieuThang9" Format="000,000,000.00" Align="Right" StyleSpec="font-weight:bold;">
                                <Editor>
                                    <ext:NumberField runat="server" ID="NumberField9" AllowDecimals="true" DecimalPrecision="2" />
                                </Editor>
                            </ext:NumberColumn>
                            <ext:NumberColumn runat="server" Text="Tháng 10" DataIndex="MucTieuThang10" Format="000,000,000.00" Align="Right" StyleSpec="font-weight:bold;">
                                <Editor>
                                    <ext:NumberField runat="server" ID="NumberField10" AllowDecimals="true" DecimalPrecision="2" />
                                </Editor>
                            </ext:NumberColumn>
                            <ext:NumberColumn runat="server" Text="Tháng 11" DataIndex="MucTieuThang11" Format="000,000,000.00" Align="Right" StyleSpec="font-weight:bold;">
                                <Editor>
                                    <ext:NumberField runat="server" ID="NumberField11" AllowDecimals="true" DecimalPrecision="2" />
                                </Editor>
                            </ext:NumberColumn>
                            <ext:NumberColumn runat="server" Text="Tháng 12" DataIndex="MucTieuThang12" Format="000,000,000.00" Align="Right" StyleSpec="font-weight:bold;">
                                <Editor>
                                    <ext:NumberField runat="server" ID="NumberField12" AllowDecimals="true" DecimalPrecision="2" />
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
                        <Edit Fn="edit" />
                    </Listeners>
                </ext:CellEditing>
            </Plugins>
        </ext:GridPanel>
    </form>
</body>
</html>
