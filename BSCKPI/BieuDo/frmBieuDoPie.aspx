<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmBieuDoPie.aspx.cs" Inherits="BSCKPI.BieuDo.frmBieuDoPie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/resources/css/examples.css" rel="stylesheet" />
</head>
<body>
    <ext:ResourceManager runat="server" />
    <form id="form1" runat="server">
        <ext:Panel runat="server" Width="390" Height="380" Layout="FitLayout">
            
            <Items>
                <ext:PolarChart
                    ID="Chart1"
                    runat="server"
                    Shadow="true"
                    InsetPadding="60"
                    InnerPadding="20">
                    
                    <Store>
                        <ext:Store
                            runat="server"
                            AutoDataBind="true">
                            <Model>
                                <ext:Model runat="server">
                                    <Fields>
                                        <ext:ModelField Name="Ten" />
                                        <ext:ModelField Name="TrongSo" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <Interactions>
                        <ext:ItemHighlightInteraction />
                        <ext:RotateInteraction />
                    </Interactions>
                    <Series>
                        <ext:Pie3DSeries
                            AngleField="TrongSo"
                            ShowInLegend="true"
                            Donut="20">
                            <Label Field="Ten" Display="Inside" FontSize="8" FontFamily="Arial"/>
                           
                        </ext:Pie3DSeries>
                    </Series>
                </ext:PolarChart>
            </Items>
        </ext:Panel>
    </form>
</body>
</html>
