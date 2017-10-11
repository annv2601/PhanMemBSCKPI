<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uccvcnNguoiThucHien.ascx.cs" Inherits="BSCKPI.CongViecCaNhan.uccvcnNguoiThucHien" %>
<script type="text/javascript">
        var edit = function (editor, e)
        {
            if (e.value !== e.originalValue)
            {
                BangNTHX.Edit(e.record.data.STT, e.field, e.originalValue, e.value, e.record.data);
            }
        }
    </script>
<ext:Hidden runat="server" ID="txtMaCongViecCaNhan" />
<ext:Hidden runat="server" ID="txtNgayGiao" />
<ext:GridPanel runat="server" ID="grdNguoiThucHien" MinWidth="300">
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
            <ext:CheckColumn runat="server" DataIndex="DaChon" Text="Chọn" Align="Center" Editable="true">               
            </ext:CheckColumn>
            <ext:Column runat="server" DataIndex="TenNhanVien" Width="250" Align="Left" Text="Nhân viên" />
            <ext:Column runat="server" DataIndex="YKienChiDao" Width="400" Text="Ý kiến chỉ đạo">
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
                        <Edit Fn="edit" />
                    </Listeners>
                </ext:CellEditing>
            </Plugins>
</ext:GridPanel>