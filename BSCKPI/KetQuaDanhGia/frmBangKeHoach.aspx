<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmBangKeHoach.aspx.cs" Inherits="BSCKPI.KetQuaDanhGia.frmBangKeHoach" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../resource/css/main.css" rel="stylesheet" />
</head>
<body>
    <ext:ResourceManager runat="server" Locale="vi-VN"/>
    <form id="form1" runat="server">
       <ext:FieldContainer runat="server" Layout="HBoxLayout" MarginSpec="10 0 0 0">
           <Items>
               <ext:SelectBox runat="server" ID="slbThang" DisplayField="Ten" ValueField="ID"
                           EmptyText="Tháng" MarginSpec="0 0 0 20" LabelWidth="40" Width="120">
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
                           <%--<DirectEvents>
                                <Change OnEvent="ChonThangNam_Click" />
                            </DirectEvents>--%>
                        </ext:SelectBox>
                        <ext:SelectBox runat="server" ID="slbNam" DisplayField="Ten" ValueField="ID"
                            EmptyText="Năm" MarginSpec="0 0 0 20" LabelWidth="40" Width="120">
                            <Store>
                                <ext:Store runat="server" ID="stoNam">
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
                            <%--<DirectEvents>
                                <Change OnEvent="ChonThangNam_Click" />
                            </DirectEvents>--%>
                        </ext:SelectBox>
               <ext:SelectBox runat="server" ID="slbKeHoachDG" EmptyText="Kế hoạch đánh giá ..."
                    DisplayField="Ten" ValueField="ID" MarginSpec="0 0 0 20" Width="350" MatchFieldWidth="true">
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
               <ext:SelectBox runat="server" ID="slbNhanVien" QueryMode="Local" EmptyText="Nhân viên"
                                    DisplayField="TenNhanVien" ValueField="IDNhanVien" LabelStyle="font-weight:bold;" Width="250" MarginSpec="0 0 0 20">
                                    <DirectEvents>
                                        <Change OnEvent="ChonThangNam_Click" />
                                    </DirectEvents>
                                    <Store>
                                        <ext:Store runat="server" ID="stoNhanVien" OnReadData="DanhSachNhanVien">
                                            <Fields>
                                                <ext:ModelField Name="TenNhanVien" />
                                                <ext:ModelField Name="IDNhanVien" />
                                            </Fields>
                                        </ext:Store>
                                    </Store>
                                </ext:SelectBox>

               <ext:SplitButton runat="server" Scale="Medium" UI="Warning" Text="Bản in" MarginSpec="0 0 0 20" Width="150">
                            <Menu>
                                <ext:Menu runat="server">
                                    <Items>
                                        <ext:MenuItem runat="server" Text="Bản in cá nhân" ID="btnInCaNhan" UI="Warning">
                                            <DirectEvents>
                                                <Click OnEvent="btnInCaNhan_Click" />
                                            </DirectEvents>
                                        </ext:MenuItem>
                                        <ext:MenuItem runat="server" Text="Bản in theo kế hoạch" ID="btnInKeHoach" UI="Warning" >
                                            <DirectEvents>
                                                <Click OnEvent="btnInKeHoach_Click" />
                                            </DirectEvents>
                                        </ext:MenuItem>
                                    </Items>
                                </ext:Menu>
                            </Menu>
                        </ext:SplitButton>
           </Items>
       </ext:FieldContainer>
       <ext:TabPanel runat="server" ID="tabBangDanhGia" MarginSpec="10 0 0 0">

       </ext:TabPanel>
        <%----%>
        
    </form>
</body>
</html>
