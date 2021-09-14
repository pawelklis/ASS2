<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="directions.aspx.cs" Inherits="ASS2WEB.directions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="dg1add" runat="server" Text="Dodaj" OnClick="dg1add_Click" />
            <asp:Button ID="dg1save" runat="server" Text="Zapisz" OnClick="dg1save_Click" />

            <asp:GridView ID="dg1" runat="server" AutoGenerateColumns="false" OnRowCommand="dg1_RowCommand"><Columns>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label1" runat="server" Text="Nazwa kierunku"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="txname" runat="server" Text='<% #Eval("name") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>

                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" Text="Wybierz" CommandArgument='<% #Eval("id") %>' CommandName="sel" />
                        <asp:Button ID="Button3" runat="server" Text="Usuń" CommandArgument='<% #Eval("id") %>' CommandName="del" OnClientClick="return confirm('Potwierdzasz usunięcie?');" />
                    </ItemTemplate>
                </asp:TemplateField>


                                                                              </Columns></asp:GridView>
            <asp:Button ID="dg2add" runat="server" Text="Dodaj" OnClick="dg2add_Click" />
            <asp:Button ID="dg2save" runat="server" Text="Zapisz" OnClick="dg2save_Click" />

            <asp:GridView ID="dg2" runat="server" AutoGenerateColumns="false" OnRowCommand="dg2_RowCommand"><Columns>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label2" runat="server" Text="Nazwa"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="txname" runat="server" Text='<% #Eval("name") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label3" runat="server" Text="Skrót WSR"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="txwsr" runat="server" Text='<% #Eval("wsr") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label4" runat="server" Text="Początek zakresu PNA"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="txpnafrom" runat="server" Text='<% #Eval("pnafrom") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label5" runat="server" Text="Koniec zakresu PNA"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="txpnato" runat="server" Text='<% #Eval("pnato") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField>
                    <HeaderTemplate>
                        
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="Button2" runat="server" Text="Usuń" CommandArgument='<% #Eval("id") %>' OnClientClick="return confirm('Potwierdzasz usunięcie?');"/>
                    </ItemTemplate>
                </asp:TemplateField>


                                                  </Columns></asp:GridView>

        </div>
    </form>
</body>
</html>
