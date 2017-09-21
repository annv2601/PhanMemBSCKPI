<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDanhSachBSC.aspx.cs" Inherits="BSCKPI.BSC.frmDanhSachBSC" %>

<%@ Register src="~/UC/ucBSCKPI.ascx" tagname="BK" tagprefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <ext:ResourceManager runat="server" />
    <form runat="server">
    <ext:TreePanel
            runat="server" ID="tpBSC"
            Title="Danh sách BSC"
            Width="1000"
            Height="380"
            Collapsible="true"
            UseArrows="true"
            RootVisible="false"
            MultiSelect="false"
            SingleExpand="true"
            FolderSort="true">
            <Fields>                
                <ext:ModelField Name="Ma" />
                <ext:ModelField Name="Ten" />
                <ext:ModelField Name="TrongSo" Type="Float" />
                <ext:ModelField Name="MucTieu" Type="Float" />
                <ext:ModelField Name="DonViTinh" />
                <ext:ModelField Name="TanSuatDo" />
                <ext:ModelField Name="XuHuongYeuCau" />
            </Fields>
            <ColumnModel>
                <Columns>
                    <ext:TreeColumn
                        runat="server"
                        Text="Tên"
                        Flex="2"
                        Sortable="true"
                        DataIndex="Ten" />                    
                    <ext:Column
                        runat="server"
                        Text="Trọng số"
                        Flex="1"
                        Sortable="true"
                        DataIndex="TrongSo" FormatterFn="Percent"/>
                   <ext:Column runat="server" Text="Đơn vị tính" DataIndex="DonViTinh" />
                    <ext:Column runat="server" Text="Tần suất đo" DataIndex="TanSuatDo" />
                    <ext:Column runat="server" Text="Xu hướng" DataIndex="XuHuongYeuCau" />
                </Columns>

            </ColumnModel>
        <DirectEvents>
            <ItemClick OnEvent="tpBSC_Click" />
        </DirectEvents>
        </ext:TreePanel>

    <ext:FieldContainer runat="server" Layout="HBoxLayout" >
         <Items>
            <ext:Panel ID="Panel1" runat="server" Header="false" Border="false" Layout="FitLayout">
                 <Content>
                       <uc1:BK ID="ucBK1" runat="server" Title="" />
                 </Content>
            </ext:Panel>
            <ext:Button ID="btnCapNhatBSC" runat="server" Text="Cập nhật" Icon="Accept" Width="150">
                <DirectEvents>
                    <Click OnEvent="btnCapNhatBSC_Click" />
                </DirectEvents>
            </ext:Button>
            
         </Items>
     </ext:FieldContainer>
    </form>
</body>
</html>
