<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDanhMucTrongSoNhom.aspx.cs" Inherits="BSCKPI.DanhMuc.frmDanhMucTrongSoNhom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var editTSN = function (editor, e)
        {
            if (e.value !== e.originalValue)
            {
                BangTSoNX.Edit(e.record.data.STT, e.field, e.originalValue, e.value, e.record.data);
            }
        }
        
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" Locale="vi-VN" />
    <form id="form1" runat="server">
        <ext:GridPanel runat="server" ID="grdTSN" TitleAlign="Center" MinHeight="300">
            <Store>
                <ext:Store runat="server" ID="stoTSN">
                    <Model>
                        <ext:Model runat="server" IDProperty="STT">
                            <Fields>
                                <ext:ModelField Name="STT" />
                                <ext:ModelField Name="IDNhomKPI" />
                                <ext:ModelField Name="Ten" />
                                <ext:ModelField Name="Ma" />
                                <ext:ModelField Name="GiaTri" />
                                <ext:ModelField Name="TuNgay" />
                                <ext:ModelField Name="DenNgay" />
                                <ext:ModelField Name="NgayTao" />
                                <ext:ModelField Name="NgaySua" />
                                <ext:ModelField Name="NguoiTao" />
                                <ext:ModelField Name="NguoiSua" />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>
            </Store>
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:Button runat="server" ID="btnThemTSNMoi" Text="Thêm trọng số mới" Icon="Add">
                            <DirectEvents>
                                <Click OnEvent="btnThemTSNMoi_Click" />
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <ColumnModel>
                <Columns>
                    <ext:Column runat="server" Text="STT" DataIndex="STT" Width="60" Align="Center" />
                    <ext:Column runat="server" Text="Mã" DataIndex="Ma" Width="80"/>
                    <ext:Column runat="server" Text="Tên" DataIndex="Ten" Width="250" />
                    <ext:NumberColumn runat="server" Text="Trọng số" DataIndex="GiaTri" Format="0000%" Align="Center">
                        <Editor>
                            <ext:NumberField runat="server" ID="txtTrongSoNhomKPI" AllowDecimals="false" />
                        </Editor>
                    </ext:NumberColumn>
                    <ext:DateColumn runat="server" Text="Từ ngày" DataIndex="TuNgay" />
                    <ext:DateColumn runat="server" Text="Đến ngày" DataIndex="DenNgay" />
                </Columns>
            </ColumnModel>
            <SelectionModel>
                <ext:CellSelectionModel runat="server" >                    
                </ext:CellSelectionModel>
            </SelectionModel>
            <Plugins>
                <ext:CellEditing runat="server" ClicksToEdit="1">
                    <Listeners>
                        <Edit Fn="editTSN" />
                    </Listeners>
                </ext:CellEditing>
            </Plugins>
        </ext:GridPanel>

        <ext:Window runat="server" ID="wTSNhomKPI" TitleAlign="Center" Title="Trọng số KPI" Width="300" Height="280" Layout="FormLayout" Hidden="true">
            <Items>
                <ext:SelectBox runat="server" ID="slbNhom" DisplayField="Ten" ValueField="ID" FieldLabel="Nhóm">
                    <Store>
                        <ext:Store runat="server" ID="stoNhom">
                            <Fields>
                                <ext:ModelField Name="ID" />
                                <ext:ModelField Name="Ten" />
                            </Fields>
                        </ext:Store>
                    </Store>
                </ext:SelectBox>
                <ext:NumberField runat="server" ID="txtGiaTri" AllowDecimals="false" FieldLabel="Trọng số (%)" MinValue="0"/>
                <ext:DateField runat="server" ID="txtTuNgay" Format="dd/MM/yyyy" FieldLabel="Từ ngày" />
                <ext:DateField runat="server" ID="txtDenNgay" Format="dd/MM/yyyy" FieldLabel="Đến ngày" ReadOnly="true"/>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnCapNhatTSN" Text="Cập nhật" Icon="Accept">
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatTSN_Click" />
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnDongTSN" Text="Đóng" Icon="Cross">
                    <Listeners>
                        <Click Handler="#{wTSNhomKPI}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
    </form>
</body>
</html>
