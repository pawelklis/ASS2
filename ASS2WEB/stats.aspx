<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="stats.aspx.cs" Inherits="ASS2WEB.stats" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <style>
        .btndownload{
            background-color:white;
            transition:all 1s;
            border-radius:50%;
            border-style:solid;
            border-width:1px;
        }
        .btndownload:hover{
            background-color:silver;
            transition:all 1s;
        }
    </style>

    <h2>Statystyki</h2>
    <asp:Label ID="Label1" runat="server" Text="Przebieg:"></asp:Label>
    <asp:DropDownList ID="ddlrun" runat="server" style="max-width:350px;" AutoPostBack="true" OnSelectedIndexChanged="ddlrun_SelectedIndexChanged"></asp:DropDownList>
    <br />

    <div style="float: right; text-align: center;">
        <asp:ImageButton ID="imgDownload" runat="server" CssClass="btndownload" OnClick="imgDownload_Click" ImageUrl="~/images/icons/appbar.office.excel.png" />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Przesyłki" Style="width: 100%; text-align: center; font-size: small;"></asp:Label>
    </div>

    <div style="float: right; text-align: center;">
        <asp:ImageButton ID="ImageButton1" runat="server" CssClass="btndownload" OnClick="ImageButton1_Click" ImageUrl="~/images/icons/appbar.office.excel.png" />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Stanowiska" Style="width: 100%; text-align: center; font-size: small;"></asp:Label>
    </div>

    <asp:Chart ID="chart1" runat="server" Width="1200">
        <series><asp:Series Name="Series1"></asp:Series></series>
        <chartareas><asp:ChartArea Name="ChartArea1"></asp:ChartArea></chartareas>
    </asp:Chart>
    <br />
        <asp:Chart ID ="chart2" runat="server" Width="600">
        <series><asp:Series Name="Series1"></asp:Series></series>
        <chartareas><asp:ChartArea Name="ChartArea1"></asp:ChartArea></chartareas>
    </asp:Chart>
        <asp:Chart ID="chart3" runat="server" Width="600">
        <series><asp:Series Name="Series1"></asp:Series></series>
        <chartareas><asp:ChartArea Name="ChartArea1"></asp:ChartArea></chartareas>
    </asp:Chart>


  

</asp:Content>
