<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmcvcnNguoiThucHien.aspx.cs" Inherits="BSCKPI.CongViecCaNhan.frmcvcnNguoiThucHien" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var editNTH = function (editor, e)
        {
            if (e.value !== e.originalValue)
            {
                BangNTHX.Edit(e.record.data.STT, e.field, e.originalValue, e.value, e.record.data);
            }
        }
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" Locale="vi-VN" />
    <form id="form1" runat="server">
        <ext:Hidden runat="server" ID="txtMaCongViecCaNhan" />
        <ext:Hidden runat="server" ID="txtNgayGiao" />
        <ext:GridPanel runat="server" ID="grdNguoiThucHien" MinWidth="300" TitleAlign="Center">
            <Store>
                <ext:Store runat="server" ID="stoNTH">
                    <Model>
                        <ext:Model runat="server" IDProperty="STT">
                            <Fields>
                                <ext:ModelField Name="MaCongViecCaNhan" />
                                <ext:ModelField Name="IDNhanVien" />
                                <ext:ModelField Name="TenNhanVien" />
                                <ext:ModelField Name="YKienChiDao" />
                                <ext:ModelField Name="DaChon" />
                                <ext:ModelField Name="STT" />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>        
            </Store>
            <ColumnModel runat="server">
                <Columns>
                    <ext:Column runat="server" DataIndex="STT" Width="60" Align="Center" Text="STT"/>
                    <ext:CheckColumn runat="server" DataIndex="DaChon" Text="Chọn" Align="Center" Editable="true" Width="80">               
                    </ext:CheckColumn>
                    <ext:Column runat="server" DataIndex="TenNhanVien" Width="200" Align="Left" Text="Nhân viên" />
                    <ext:Column runat="server" DataIndex="YKienChiDao" Width="440" Text="Ý kiến chỉ đạo">
                        <Editor>
                            <ext:TextField runat="server" ID="txtYKCD" />
                        </Editor>
                    </ext:Column>
                </Columns>
            </ColumnModel>
            <SelectionModel>
                        <ext:CellSelectionModel runat="server" >
                    
                        </ext:CellSelectionModel>
                    </SelectionModel>
                    <Plugins>                
                        <ext:CellEditing runat="server" ClicksToEdit="1">
                            <Listeners>
                                <Edit Fn="editNTH" />
                            </Listeners>
                        </ext:CellEditing>
                    </Plugins>
        </ext:GridPanel>
    </form>
</body>
</html>
