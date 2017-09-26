<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDanhSachKPI.aspx.cs" Inherits="BSCKPI.KPI.frmDanhSachKPI" %>
<%@ Register src="~/UC/ucBSCKPI.ascx" tagname="BK" tagprefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../resource/css/main.css" rel="stylesheet" />
    <style type="text/css">
        .GridPanelUsersRowYellow
        {
            background: #FFFF00;
        }
        .GridPanelUsersRowWhite
        {
            background: white;
        }
    </style>
    <script type="text/javascript">
        var edit = function (editor, e)
        {
            if (e.value !== e.originalValue)
            {
                BangKPIX.Edit(e.record.data.ID, e.field, e.originalValue, e.value, e.record.data);
            }
        }

        function getRowClass(record) {
            if (record.data.ChiTieuChung) {
                return "GridPanelUsersRowYellow";
            }
            else {

            }
        }
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" />
    <form id="form1" runat="server">
        <ext:Store ID="stoKPI" runat="server">
                    <Model>
                        <ext:Model runat="server">
                            <Fields>
                                <ext:ModelField Name="ID" />
                                <ext:ModelField Name="Ma" />
                                <ext:ModelField Name="STT" />
                                <ext:ModelField Name="Ten" />
                                <ext:ModelField Name="TrongSo" Type="Float" />
                                <ext:ModelField Name="MucTieu" Type="Float" />
                                <ext:ModelField Name="IDDonViTinh"/>
                                <ext:ModelField Name="DonViTinh" />
                                <ext:ModelField Name="IDBSC" />
                                <ext:ModelField Name="TenBSC" />
                                <ext:ModelField Name="Muc" />
                                <ext:ModelField Name="IDTanSuatDo" />
                                <ext:ModelField Name="TanSuatDo" />
                                <ext:ModelField Name="IDXuHuongYeuCau" />
                                <ext:ModelField Name="XuHuongYeuCau" />
                                <ext:ModelField Name="IDDonVi" />
                                <ext:ModelField Name="DonVi" />
                                <ext:ModelField Name="IDPhongBan" />
                                <ext:ModelField Name="PhongBan" />
                                <ext:ModelField Name="STTsx" />
                                <ext:ModelField Name="InDam" />
                                <ext:ModelField Name="InNghieng" />
                                <ext:ModelField Name="ChiTieuChung" />
                                <ext:ModelField Name="TrangThai" />
                                <ext:ModelField Name="TenTrangThai" />
                                <ext:ModelField Name="GhiChuTrangThai" />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>
        <ext:Menu runat="server" ID="mnuKPI">
            <Items>
                <ext:MenuItem ID="mnuitemKPIPheDuyet" runat="server" Text="Phê duyệt" Icon="Accept">
                    <DirectEvents>
                        <Click OnEvent="mnuitemKPIPheDuyet_Click">
                            <ExtraParams>
                                <ext:Parameter Name="Values" Value="Ext.encode(#{grdKPI}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
                <ext:MenuItem ID="mnuitemKPILienKetBSC" runat="server" Text="Liên kết BSC" Icon="Link">
                    <DirectEvents>
                        <Click OnEvent="mnuitemKPILienKetBSC_Click">
                            <ExtraParams>
                                <ext:Parameter Name="Values" Value="Ext.encode(#{grdKPI}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
            </Items>
        </ext:Menu>
        <ext:GridPanel runat="server" Title="Danh sách KPI" ID="grdKPI" StoreID="stoKPI" 
            MinHeight="300" ContextMenuID="mnuKPI">
            <View>
                <ext:GridView ID="GridView1" runat="server">
                    <GetRowClass Fn="getRowClass" />
                </ext:GridView>
            </View>
            <ColumnModel runat="server">
                        <Columns>
                            <%--<ext:Column runat="server" Text="STT" DataIndex="STT" Width="50"/>--%>
                            <ext:RowNumbererColumn runat="server" Text="STT" Width="70" Align="Center"/>
                            <ext:Column runat="server" Text="Mã" DataIndex="Ma" Width="100"/>
                            <ext:Column runat="server" Text="Tên" DataIndex="Ten" Width="150"/>
                            
                            <ext:NumberColumn runat="server" Text="Trọng số" DataIndex="TrongSo" Format="000,000.00%"/>
                            <ext:NumberColumn runat="server" Text="Mục tiêu" DataIndex="MucTieu" Format="000,000,000.00"/>
                            <ext:Column runat="server" Text="Đơn vị tính" DataIndex="DonViTinh" />
                            <ext:Column runat="server" Text="Tần suất đo" DataIndex="TanSuatDo" />
                            <ext:Column runat="server" Text="Xu hướng" DataIndex="XuHuongYeuCau" />
                            <ext:Column runat="server" Text="Tên BSC" DataIndex="TenBSC" Width="160"/>
                            <ext:Column runat="server" Text="Đơn vị" DataIndex="DonVi" />
                            <ext:Column runat="server" Text="Phòng ban" DataIndex="PhongBan" />
                            <ext:Column runat="server" Text="Chỉ tiêu chung" DataIndex="ChiTieuchung" />
                            <ext:Column runat="server" Text="Trạng thái" DataIndex="TenTrangThai" />
                            <ext:Column runat="server" Text="Nội dung" DataIndex="GhiChuTrangThai" />
                        </Columns>
                    </ColumnModel>
            <SelectionModel>
                <ext:CellSelectionModel runat="server" >
                    <DirectEvents>
                        <Select OnEvent="grdKPI_Select">
                            <ExtraParams>
                                <ext:Parameter Name="Values" Value="Ext.encode(#{grdKPI}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
                            </ExtraParams>
                        </Select>
                    </DirectEvents>
                </ext:CellSelectionModel>
            </SelectionModel>
            <Plugins>
                <ext:FilterHeader runat="server" OnCreateFilterableField="OnCreateFilterableField" />
                <ext:CellEditing runat="server" ClicksToEdit="2">
                    <Listeners>
                        <Edit Fn="edit" />
                    </Listeners>
                </ext:CellEditing>
            </Plugins>
        </ext:GridPanel>

        <ext:FieldContainer runat="server" Layout="HBoxLayout" ID="fdcNhapLieu" >
         <Items>
            <ext:Panel ID="Panel1" runat="server" Header="false" Border="false" Layout="FitLayout">
                 <Content>
                       <uc1:BK ID="ucBK1" runat="server" Title="" />
                 </Content>
            </ext:Panel>
             <ext:FieldContainer runat="server" Layout="VBoxLayout" >
                <Items>
                    <%--<ext:Button ID="btnThemMoiBSC" runat="server" Text="Thêm mới" Icon="Add" Width="150" Height="50" MarginSpec="20 0 0 0">
                        <DirectEvents>
                            <Click OnEvent="btnThemMoiBSC_Click" />
                        </DirectEvents>
                    </ext:Button>--%>
                    <ext:Button ID="btnCapNhatBSC" runat="server" Text="Cập nhật" Icon="Accept" Width="150" Height="50" MarginSpec="50 0 0 0">
                        <DirectEvents>
                            <Click OnEvent="btnCapNhatBSC_Click" />
                        </DirectEvents>
                    </ext:Button>
                </Items>
            </ext:FieldContainer>
            
            
         </Items>
     </ext:FieldContainer>

        <ext:Window runat="server" ID="wPheDuyet" Hidden="true" ButtonAlign="Center"
            Title="Phê duyệt KPI" TitleAlign="Center" Icon="Accept" Width="400" Height="250">
            <Items>
                <ext:Label runat="server" ID="lblTenKPI" StyleSpec="font-weight:bold; font-size:20px;text-align: center;" Width="380" MarginSpec="0 0 0 10"></ext:Label>
                <ext:Checkbox runat="server" ID="chkChiTieuChung" FieldLabel="Chỉ tiêu chung" LabelWidth="120" Width="380" MarginSpec="0 0 0 10"></ext:Checkbox>
                <ext:TextArea runat="server" ID="txtGhiChuTrangThai" LabelWidth="120" FieldLabel="Nội dung" Width="380" MarginSpec="0 0 0 10"></ext:TextArea>
                <ext:Hidden runat="server" ID="txtIDKPIPheDuyet" />
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnPheDuyet" Icon="Accept" Text="Duyệt">
                    <DirectEvents>
                        <Click OnEvent="btnPheDuyet_Click" />
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnDongPheDuyet" Icon="Cross" Text="Không">
                    <Listeners>
                        <Click Handler="#{wPheDuyet}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>

        <ext:Window runat="server" ID="wLienKetBSC" Hidden="true" ButtonAlign="Center"
            Title="Liên kết BSC" TitleAlign="Center" Icon="Link" Width="400" Height="400">
            <Items>
                <ext:Label runat="server" ID="lblTenKPILienKet" StyleSpec="font-weight:bold; font-size:20px;text-align: center;" Width="380" MarginSpec="0 0 0 10"></ext:Label>
                <ext:TreePanel
                    runat="server" ID="tpBSC"
                    Title="Danh sách BSC"
                    Width="380"
                    Height="350"
                    Collapsible="false"
                    UseArrows="true"
                    RootVisible="false"
                    MultiSelect="false"
                    SingleExpand="false" HideHeaders="true"
                    FolderSort="true" MarginSpec="0 0 0 10">
        
                    <Fields>                
                        <ext:ModelField Name="Ma" />
                        <ext:ModelField Name="Ten" />
                    </Fields>
                    <ColumnModel>
                        <Columns>
                            <ext:TreeColumn
                                runat="server"
                                Text="Tên"
                                Flex="2"
                                Sortable="true"
                                DataIndex="Ten"/>                            
                        </Columns>

                    </ColumnModel>               
                </ext:TreePanel>
                <ext:Hidden runat="server" ID="txtIDKPILienKet" />
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnLienKetBSC" Icon="Link" Text="Liên kết">
                    <DirectEvents>
                        <Click OnEvent="btnLienKetBSC_Click" />
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="Button2" Icon="Cross" Text="Không">
                    <Listeners>
                        <Click Handler="#{wLienKetBSC}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
    </form>
</body>
</html>
