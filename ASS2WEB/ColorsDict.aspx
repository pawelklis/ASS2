<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ColorsDict.aspx.cs" Inherits="ASS2WEB.ColorsDict" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Zapisz" OnClick="Button1_Click" />

            <asp:GridView ID="dg1" runat="server" OnRowDataBound="dg1_RowDataBound" AutoGenerateColumns="false">


                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label1" runat="server" Text="Kolor"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlcolor" ToolTip='<% #Eval("color") %>' runat="server">                               
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBoxList ID="ckl" runat="server" ToolTip='<% #Eval("values") %>'>
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem></asp:ListItem>
                            </asp:CheckBoxList>
                        </ItemTemplate>
                    </asp:TemplateField>


                </Columns>
            </asp:GridView>


        </div>
    </form>
</body>
</html>
