<%@ Page Title="" Language="C#" MasterPageFile="~/layout/LayoutPublic.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AduanaGAMA.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-12 col-sm-12 col-md-12">
            <div class="form-group text-right">
                <a href="Empleado.aspx" class="btn btn-primary ">crear empleado</a>
            </div>
        </div>

        <div class="col-12 col-sm-12 col-md-12">
            <div class="card">
                <div class="card-header">
                    Listado de empleados
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView runat="server" ClientIDMode="Static" ID="gridViewEmpleado" BorderWidth="0" GridLines="None" AutoGenerateColumns="false"
                        CssClass="table table-striped">
                            <Columns>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                                <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                                <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                                <asp:BoundField DataField="Salario" HeaderText="Salario" />
                                <asp:BoundField DataField="IdDepartamento" HeaderText="IdDepartamento" />
                                <asp:BoundField DataField="Rol" HeaderText="Rol" />
                                <asp:BoundField DataField="FechaIngreso" HeaderText="FechaIngreso" />
                                <asp:BoundField DataField="Sexo" HeaderText="Sexo" />
                                <asp:BoundField DataField="CodigoCompania" HeaderText="Código Compañia" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <a href="Empleado.aspx?id=<%# Eval("Id") %>">
                                            <i class="fa fa-pencil fa-2x"></i>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <i class="fa fa-trash fa-2x"></i>
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
