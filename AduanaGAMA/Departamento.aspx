<%@ Page Language="C#" MasterPageFile="~/layout/LayoutPublic.Master"  AutoEventWireup="true" CodeBehind="Departamento.aspx.cs" Inherits="AduanaGAMA.Departamento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-12 col-sm-12 col-md-8 col-lg-4 mx-auto">
            <div class="card">
                <div class="card-header">
                    Gestion Departamento
                </div>
                <div class="card-body">
                    <div class="form-group">
                        <asp:TextBox runat="server" ClientIDMode="Static" class="form-control" id="departa" placeholder="Departamento*" />
                    </div>
                    <button class="btn btn-primary btn-block" onclick="GuardarDatosDepartamento()" type="button">
                        Signup
                    </button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

