<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimientos/frmPrincipalMaster.Master" AutoEventWireup="true" CodeBehind="frmMantenimientoExtrasXVehiculo.aspx.cs" Inherits="PL_EXAMEN.Mantenimientos.frmMantenimientoExtrasXVehiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.11.5/css/jquery.dataTables.min.css"/>
    <script src="https://cdn.datatables.net/1.11.5/js/jquery.dataTables.min.js"></script>
    <nav aria-label="breadcrumb">
      <ol class="breadcrumb my-breadcrumb">
        <li class="breadcrumb-item"><a href="frmPanel.aspx">Inicio</a></li>
        <li class="breadcrumb-item active" aria-current="page">Mantenimiento de Extras x Vehiculo</li>
      </ol>
    </nav>
    <div class="welcome-msg pt-3 pb-4">
      <h1>Hola <span class="text-primary" id="nombreUsuario"></span>, Bienvenido</h1>
      <p id="emlUsuario">Email</p>
    </div>
    <section class="forms">
            <!-- Formulario Búsqueda -->
            <div class="card card_border py-2 mb-4">
                <div class="cards__heading">
                    <h3>Extras Disponibles<span></span></h3>
                </div>
                <div class="card-body">
                    <form action="javascript: asignaExtrasXVehiculo()">
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label for="cboExtra" class="input__label">Extra</label>
                                <select id="cboExtra" class="form-control input-style">
                                </select>
                            </div>
                        </div>
                        <button type="submit" class="btn btn-primary btn-style mt-4" onclick="">Asignar</button>
                        <button type="button" class="btn btn-primary btn-style mt-4" onclick="javascript: regresar()">Regresar</button>
                    </form>
                </div>
            </div>
            <!-- //Formulario Búsqueda -->

            <!-- Formulario Resultados -->
            <div class="card card_border py-2 mb-4">
                <div class="cards__heading">
                    <h3>Resultados de Búsqueda de Extras Asignados<span></span></h3>
                </div>
                <div class="card-body">
                     <table id="tblExtrasXVehiculo">
                        <!-- Definición de tabla aquí -->
                    </table>
                </div>
            </div>
            <!-- //Formulario Resultados -->
        </section>
    
    <script src="../JavaScript/ExtrasXVehiculo.js"></script>
</asp:Content>
