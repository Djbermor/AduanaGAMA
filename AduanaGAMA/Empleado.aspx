<%@ Page Title="" Language="C#" MasterPageFile="~/layout/LayoutPublic.Master" AutoEventWireup="true" CodeBehind="Empleado.aspx.cs" Inherits="AduanaGAMA.Empleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-12 col-sm-6 col-md-4 mx-auto">
            <div class="card">
                <div class="card-header">
                    Gestion Empleado
                </div>
                <div class="card-body">
                    <div class="form-group">
                        <asp:TextBox runat="server" ClientIDMode="Static" class="form-control" id="nombre" placeholder="Nombre*" />
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" ClientIDMode="Static" class="form-control" id="apellido" placeholder="Apellido*" />
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" ClientIDMode="Static" class="form-control" id="direccion" placeholder="Direccion*" />
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" ClientIDMode="Static" class="form-control" id="telefono" placeholder="Telefono*" />
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" ClientIDMode="Static" class="form-control" id="salario" 
                            placeholder="Salario*" TextMode="Number" />
                    </div>
                    <div class="form-group">
                        <asp:DropDownList runat="server" ClientIDMode="Static" ID="departamento" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <asp:DropDownList runat="server" ClientIDMode="Static" ID="rol" CssClass="form-control"/>
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" ClientIDMode="Static" class="form-control" id="fecha" 
                            placeholder="Salario*" TextMode="date" />
                    </div>
                    <div class="form-group">
                            <asp:DropDownList runat="server" ClientIDMode="Static" ID="sexo" CssClass="form-control"/>
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" ClientIDMode="Static" class="form-control" 
                            id="codigoCompania" placeholder="Codigo Compañia*" />
                    </div>
                    <button class="btn btn-primary btn-block" onclick="GuardarDatos()">
                        Signup
                    </button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
