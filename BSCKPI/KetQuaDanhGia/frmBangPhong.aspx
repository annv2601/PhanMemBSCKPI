<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmBangPhong.aspx.cs" Inherits="BSCKPI.KetQuaDanhGia.frmBangPhong" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../resource/css/main.css" rel="stylesheet" />
</head>
<body>
    <ext:ResourceManager runat="server" Locale="vi-VN"/>
    <form id="form1" runat="server">
       <ext:FieldContainer runat="server" Layout="HBoxLayout">
           <Items>
               <ext:SelectBox runat="server" ID="slbThang" DisplayField="Ten" ValueField="ID"
                            FieldLabel="Tháng" MarginSpec="0 0 0 40" LabelWidth="40">
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
                           <DirectEvents>
                                <Change OnEvent="ChonThangNam_Click" />
                            </DirectEvents>
                        </ext:SelectBox>
                        <ext:SelectBox runat="server" ID="slbNam" DisplayField="Ten" ValueField="ID"
                            FieldLabel="Năm" MarginSpec="0 0 0 40" LabelWidth="40">
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
                            <DirectEvents>
                                <Change OnEvent="ChonThangNam_Click" />
                            </DirectEvents>
                        </ext:SelectBox>
               <ext:Button runat="server" ID="btnBoSung" Text="Bổ sung" Icon="TableRowInsert" MarginSpec="0 0 0 80">
                   <DirectEvents>
                       <Click OnEvent="btnBoSung_Click" >
                           <EventMask ShowMask="true" Msg="Đang thực hiện ....." />
                        </Click>
                   </DirectEvents>
               </ext:Button>
           </Items>
       </ext:FieldContainer>
       <ext:TabPanel runat="server" ID="tabBangDanhGia" MarginSpec="10 0 0 0">

       </ext:TabPanel>
        <%----%>
        
    </form>
</body>
</html>
