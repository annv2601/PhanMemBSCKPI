<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmBangCaNhan.aspx.cs" Inherits="BSCKPI.KetQuaDanhGia.frmBangCaNhan" %>

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
            font-size: 11px;
            background-color : #f1f2f4;
        }

        .total-field{
            background-color : #fff;
            padding          : 0px 1px 1px 1px;
            margin-right     : 1px;
            position: absolute;
        }

        .total-field .x-form-display-field{
            font-weight      : bold !important;
            border           : solid 1px silver;
            font-size        : 11px;
            font-family      : tahoma, arial, verdana, sans-serif;
            color            : #000;
            padding          : 0px 0px 0px 5px;
            height           : 22px;
            margin-top       : 0px;
            padding-top      : 3px;
        }
    </style>

    <script>
        var updateTotal = function (grid, container) {
            if (!grid.view.rendered) {
                return;
            }

            var field,
                value,
                width,
                c,
                cs = grid.headerCt.getVisibleGridColumns();

            container.suspendLayout = true;

            for (var i = 0; i < cs.length; i++) {
                c = cs[i];

                if (c.summaryType) {
                    value = App.Group1.getSummary(grid.store, c.summaryType, c.dataIndex);
                } else {
                    value = "-";
                }

                field = container.down('component[name="'+c.dataIndex+'"]');

                container.remove(field, false);
                container.insert(i, field);
                width = c.getWidth();
                field.setWidth(width - 1);

                var r = c.summaryRenderer || simpleRenderer;
                field.setValue(r(value, {}, c.dataIndex));
            }

            container.items.each(function (field) {
                var column = grid.headerCt.down('component[dataIndex="'+field.name+'"]');
                field.setVisible(column.isVisible());
            });

            container.suspendLayout = false;
            container.updateLayout();
        };

        var simpleRenderer = function (v) {
            return v;
        };

        var totalCost = function (records) {
            var i = 0,
                length = records.length,
                total = 0,
                record;

            for (; i < length; ++i) {
                record = records[i];
                total += record.get('Estimate') * record.get('Rate');
            }

            return total;
        };

        var beforeCellEditHandler = function (e) {
            if (e.field == "Diem" && e.record.data.NhapDiem == false) {
                //alert("Co chay");
                CellEditing1.cancelEdit(); 
            }
        }

        var edit = function (editor, e) {
            if (e.value !== e.originalValue) {
                BangKQDGX.Edit(e.record.data.STT, e.field, e.originalValue, e.value, e.record.data);
            }
        }
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" Locale="vi-VN"/>
    <form id="form1" runat="server">
        <ext:Hidden runat="server" ID="txtIDNhanVien" />
        <ext:GridPanel
            ID="grdBangCN"
            runat="server"
            Frame="true"
            Title=""
            TitleAlign="Center"
            Icon="TableKey" MinHeight="500">
            <Store>
                <ext:Store ID="stoBCN" runat="server" GroupField="TenNhom" GroupDir="Default">
                    <Model>
                        <ext:Model runat="server" IDProperty="STT">
                            <Fields>
                                <ext:ModelField Name="STT" />
                                <ext:ModelField Name="ID" />
                                <ext:ModelField Name="TenNhom" />
                                <ext:ModelField Name="ThuTu" />
                                <ext:ModelField Name="Ten" />
                                <ext:ModelField Name="TrongSoNhom" Type="Float" />
                                <ext:ModelField Name="MucTieu" Type="Float" />
                                <ext:ModelField Name="TanSuatDo" />
                                <ext:ModelField Name="DonViTinh" />
                                <ext:ModelField Name="TrongSo" Type="Float" />
                                <ext:ModelField Name="KetQua" Type="Float" />
                                <ext:ModelField Name="Diem" />
                                <ext:ModelField Name="DienGiai" />
                                <ext:ModelField Name="LoaiChiTieu" />
                                <ext:ModelField Name="NhapDiem" />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>
            </Store>            
            <ColumnModel runat="server">
                <Columns>
                    <ext:Column runat="server" Text="STT" DataIndex="ThuTu" Width="50" Align="Center"/>
                    <ext:SummaryColumn
                        runat="server"
                        Text="Chỉ tiêu"
                        DataIndex="Ten"
                        Hideable="false"
                        SummaryType="Count"
                        Width="350">
                        <SummaryRenderer Handler="return ((value === 0 || value > 1) ? '(' + value +')' : '(1)');" />
                    </ext:SummaryColumn>

                    <ext:Column runat="server" Text="Nhóm" DataIndex="TenNhom" Width="20" />

                    <ext:Column runat="server" Text="Mục tiêu" Align="Center">
                        <Columns>
                            <ext:NumberColumn runat="server" Text="Chỉ tiêu" DataIndex="MucTieu" />
                            <ext:Column runat="server" Text="Tần suất đo" DataIndex="TanSuatDo" />
                            <ext:Column runat="server" Text="Đơn vị tính" DataIndex="DonViTinh" />
                        </Columns>
                    </ext:Column>                   

                    <ext:NumberColumn runat="server" Text="Trọng số" DataIndex="TrongSo" Format="000%" Align="Right">
                    <%--<Renderer Format="Percent" />--%>
                        <Editor>
                            <ext:NumberField runat="server" AllowDecimals="false" EmptyNumber="0"  MinValue="0"/>
                        </Editor>
                    </ext:NumberColumn>
                    <ext:NumberColumn runat="server" Text="Kết quả" DataIndex="KetQua" Align="Right">
                        <Editor>
                            <ext:NumberField runat="server" AllowDecimals="true" DecimalPrecision="2" EmptyNumber="0"  MinValue="0"/>
                        </Editor>
                    </ext:NumberColumn>
                    <ext:SummaryColumn runat="server" Text="Điểm" DataIndex="Diem" Align="Right" SummaryType="Sum">
                        <Editor>
                            <ext:NumberField runat="server" AllowDecimals="false" EmptyNumber="0" MinValue="0"/>
                        </Editor>
                    </ext:SummaryColumn>
                    <ext:Column runat="server" Text="Diễn giải" DataIndex="DienGiai" Width="300">
                        <Editor>
                            <ext:TextField runat="server" />
                        </Editor>
                    </ext:Column>
                </Columns>
            </ColumnModel>
            <View>
                 <ext:GridView runat="server">
                    <Listeners>
                        <Refresh Handler="updateTotal(this.panel, #{Container1});" Delay="100" />
                    </Listeners>
                </ext:GridView>
            </View>
            <Plugins>
                <ext:CellEditing runat="server" ClicksToEdit="1" ID="CellEditing1">
                    <Listeners>
                        <BeforeEdit Handler="return beforeCellEditHandler(e);"></BeforeEdit>
                        <Edit Fn="edit" />
                    </Listeners>
                </ext:CellEditing>
            </Plugins>            
            <Features>
                <ext:GroupingSummary
                    ID="Group1"
                    runat="server"                    
                    GroupHeaderTplString="{name}"
                    HideGroupedHeader="true"
                    EnableGroupingMenu="false" />
            </Features>
            <%--<DockedItems>
                <ext:Container
                    ID="Container1"
                    runat="server"
                    Layout="HBoxLayout"
                    Dock="Bottom"
                    StyleSpec="margin-top:2px;">
                    <Defaults>
                        <ext:Parameter Name="height" Value="24" />
                    </Defaults>
                    <Items>
                        <ext:DisplayField ID="ColumnField1" runat="server" Name="Ten" Cls="total-field" Text="-" />
                        <ext:DisplayField ID="ColumnField2" runat="server" Name="MucTieu" Cls="total-field" Text="-" />
                        <ext:DisplayField ID="ColumnField3" runat="server" Name="TanSuatDo" Cls="total-field" Text="-" />
                        <ext:DisplayField ID="ColumnField4" runat="server" Name="DonViTinh" Cls="total-field" Text="-" />
                        <ext:DisplayField ID="ColumnField5" runat="server" Name="TrongSo" Cls="total-field" Text="-" />
                        <ext:DisplayField ID="DisplayField1" runat="server" Name="KetQua" Cls="total-field" Text="-" />
                        <ext:DisplayField ID="DisplayField2" runat="server" Name="Diem" Cls="total-field" Text="-" />
                    </Items>
                </ext:Container>
            </DockedItems>--%>
        </ext:GridPanel>
    </form>
</body>
</html>
