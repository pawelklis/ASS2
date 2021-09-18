<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASS2WEB._Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <h2>Daschboard</h2>
   <div style="width:100%;overflow:auto;">
    <asp:Chart ID="chart1" runat="server" Width="4000" Height="300">
        <Series>
            <asp:Series Name="Series1"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
       </div>
   <div style="width:100%;overflow:auto;">
    <asp:DropDownList ID="ddlcircle" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlcircle_SelectedIndexChanged"></asp:DropDownList>
       <div style="width:100%;overflow:auto;">
    <asp:Chart ID="chart2" runat="server" Width="4000" Height="400">
        <Series>
            <asp:Series Name="Series1"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
       </div>
    </div>
</asp:Content>
