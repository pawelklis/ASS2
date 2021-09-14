<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stands.aspx.cs" Inherits="ASS2WEB.stands" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.4.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div class="container-fluid">
 <div class="row">
    <div class="col-sm" style="height:300px;overflow:auto;">
            <asp:Button ID="dg1save" runat="server" Text="Zapisz" OnClick="dg1save_Click" />

            <asp:GridView ID="dg1" CssClass="table table-hover table-responsive "  runat="server" AutoGenerateColumns="false" OnRowCommand="dg1_RowCommand"><Columns>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label1" runat="server" Text="Stanowisko"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:label ID="txname" runat="server" Text='<% #Eval("name") %>'></asp:label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label4" runat="server" Text="Takt lampy gotowości"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="txlamp1index" runat="server" Text='<% #Eval("lamp1index") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label5" runat="server" Text="Takt lampy sygnalizacyjnej"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="txlamp2index" runat="server" Text='<% #Eval("lamp2index") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField Visible="false">
                    <HeaderTemplate>

                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" Text="Wybierz" CommandArgument='<% #Eval("id") %>' CommandName="sel" />
                    </ItemTemplate>
                </asp:TemplateField>


                                                                              </Columns></asp:GridView> 
    </div>
    <div class="col-sm" style="visibility:hidden;">

            <asp:Button ID="dg2save" runat="server" Text="Zapisz" OnClick="dg2save_Click" />

            <asp:GridView ID="dg2" Visible="false"  CssClass="table table-hover table-responsive "  runat="server" AutoGenerateColumns="false" OnRowCommand="dg2_RowCommand" OnRowDataBound="dg2_RowDataBound"><Columns>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label2" runat="server" Text="Kierunek sortowniczy"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:DropDownList ID="ddldirection"    runat="server"></asp:DropDownList>
                        <asp:Label ID="Label6" style="visibility:hidden;width:1px;height:1px;" ToolTip='<% #Eval("id") %>' runat="server" Text='<% #Eval("directionid") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label3" runat="server" Text="Kolor sygnalizacyjny"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                         <asp:DropDownList ID="ddlcolor" ToolTip='<% #Eval("color") %>' runat="server">
                         </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>


                                                  </Columns></asp:GridView>
    </div>




                </div>
                </div>
        </div>
    </form>
</body>
</html>
