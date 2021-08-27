<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GrillaRol.aspx.cs" MasterPageFile="~/layout/LayoutPublic.Master" Inherits="AduanaGAMA.GrillaRol" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-12 col-sm-12 col-md-12">
            <div class="form-group text-right">
                <a href="Rol.aspx" class="btn btn-primary ">crear cargos</a>
            </div>
        </div>

        <div class="col-12 col-sm-12 col-md-12">
            <div class="card">
                <div class="card-header">
                    Listado de cargos
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView runat="server" ClientIDMode="Static" ID="gridViewRol" BorderWidth="0" GridLines="None" AutoGenerateColumns="false"
                        CssClass="table table-striped">
                            <Columns>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <a href="Rol.aspx?id=<%# Eval("Id") %>">
                                            <i class="fa fa-pencil fa-2x"></i>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <i class="fa fa-trash fa-2x" onclick="EliminarRol('<%# Eval("Id") %>')"></i>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>