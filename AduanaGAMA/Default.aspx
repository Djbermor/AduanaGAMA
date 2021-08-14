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
                    <asp:GridView runat="server" ClientIDMode="Static" ID="gridViewEmpleado"
                        CssClass="table table-striped" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
