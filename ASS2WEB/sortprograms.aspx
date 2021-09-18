<%@ Page Language="C#"  MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="sortprograms.aspx.cs" Inherits="ASS2WEB.sortprograms" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <style>
       .sticky{
           position:fixed;
           top:0px;
           position:sticky;
           background-color:black;
           color:white;
       }
   </style>
    <h2>Programy sortownicze</h2>
            <asp:Button ID="Button1" CssClass="btn btn-info" runat="server" Text="Dodaj" OnClick="Button1_Click" />
            <asp:Button ID="Button2" CssClass="btn btn-primary" runat="server" Text="Zapisz" OnClick="Button2_Click" />
            <div style="height:25vh;overflow:auto;">
            <asp:GridView ID="dg1" CssClass="table table-hover  " HeaderStyle-CssClass="sticky" runat="server" OnRowCommand="dg1_RowCommand" AutoGenerateColumns="false">
                <Columns>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label1" runat="server" Text="Nazwa"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txname" runat="server" Text='<% #Eval("name") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Button ID="Button3" CssClass="btn btn-info" runat="server" Text="Wybierz" CommandArgument='<% #Eval("id") %>' CommandName="sel" />
                            <asp:Button ID="Button5" CssClass="btn btn-danger" runat="server" Text="Usuń"    CommandArgument='<% #Eval("id") %>' CommandName="usun"  OnClientClick="return confirm('Potwierdzasz usunięcie?');" />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
            </div>

            <asp:Label ID="lbselsp" runat="server" Text="0" style="visibility:hidden;"></asp:Label>

            
            <asp:Button ID="Button4" Visible="false" runat="server" CssClass="btn btn-primary" Text="Zapisz" OnClick="Button4_Click" />
            <div style="height:45vh;overflow:auto;">
            <asp:GridView ID="dg2" CssClass="table table-hover" HeaderStyle-CssClass="sticky" runat="server" OnRowDataBound="dg2_RowDataBound" AutoGenerateColumns="false">
                <Columns>
                     <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label4" runat="server" Text="Stanowisko"></asp:Label>     
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbstandindex" runat="server" ToolTip='<%  #Eval("standindex") %>' Text='<%  #Eval("standname") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label5" runat="server" Text="Pozycja"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbdirectionindex" runat="server" ToolTip='<% #Eval("directionindex") %>' Text='<%  #Eval("directionname") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label2" runat="server" Text="Kierunek"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:DropDownList ID="ddldirection" ToolTip='<% #Eval("directionid") %>' runat="server"></asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label3" runat="server" Text="Kolor"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlcolor" ToolTip='<% #Eval("color") %>' runat="server" Enabled="false" ForeColor="Transparent" Font-Bold="true" ></asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </div>

    
</asp:Content>
