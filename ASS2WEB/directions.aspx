<%@ Page Language="C#"  MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="directions.aspx.cs" Inherits="ASS2WEB.directions" MaintainScrollPositionOnPostback="true" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <style>
            .sticky {
                position: fixed;
                top: 0px;
                position: sticky;
                background-color: black;
                color: white;
            }
   </style>

    <asp:UpdatePanel ID="up1" runat="server"><ContentTemplate>
        <div>
            <h2>Kierunki sortownicze</h2>

            <asp:Button ID="dg1add" CssClass="btn btn-info" runat="server" Text="Dodaj" OnClick="dg1add_Click" />
            <asp:Button ID="dg1save" CssClass="btn btn-primary" runat="server" Text="Zapisz" OnClick="dg1save_Click" />

            <div style="height:25vh;overflow:auto;">
            <asp:GridView ID="dg1" CssClass="table table-hover  " HeaderStyle-CssClass="sticky" runat="server" AutoGenerateColumns="false" OnRowCommand="dg1_RowCommand"><Columns>

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
                        <asp:Button ID="Button1" runat="server" Text="Wybierz" CssClass="btn btn-info" CommandArgument='<% #Eval("id") %>' CommandName="sel" />
                        <asp:Button ID="Button3" runat="server" Text="Usuń" CssClass="btn btn-danger" CommandArgument='<% #Eval("id") %>' CommandName="del" OnClientClick="return confirm('Potwierdzasz usunięcie?');" />
                    </ItemTemplate>
                </asp:TemplateField>


                                                                              </Columns></asp:GridView>
                </div>
            <br />


            <asp:Button ID="dg2add" CssClass="btn btn-info" runat="server" Text="Dodaj" OnClick="dg2add_Click" />
            <asp:Button ID="dg2save" CssClass="btn btn-primary" runat="server" Text="Zapisz" OnClick="dg2save_Click" />
            <div style="height:45vh;overflow:auto;">
            <asp:GridView ID="dg2" CssClass="table table-hover  " HeaderStyle-CssClass="sticky" runat="server" AutoGenerateColumns="false" OnRowCommand="dg2_RowCommand"><Columns>

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
                        <asp:TextBox ID="txwsr" Width="100" runat="server" Text='<% #Eval("wsr") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label3" runat="server" Text="Kody rodzaju przesyłek"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="txpt" Width="500" style="max-width:600px;" runat="server" Text='<% #Eval("parceltypes") %>'></asp:TextBox>
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
                        <asp:Button ID="Button2" runat="server" Text="Usuń" CssClass="btn btn-danger" CommandArgument='<% #Eval("id") %>' OnClientClick="return confirm('Potwierdzasz usunięcie?');"/>
                    </ItemTemplate>
                </asp:TemplateField>


                                                  </Columns></asp:GridView>
            </div>
        </div>
        </ContentTemplate></asp:UpdatePanel>

</asp:Content>
