<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimientos/frmPrincipalMaster.Master" AutoEventWireup="true" CodeBehind="frmConsultaVehiculos.aspx.cs" Inherits="PL_EXAMEN.Mantenimientos.frmConsultaVehiculos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.11.5/css/jquery.dataTables.min.css"/>
    <script src="https://cdn.datatables.net/1.11.5/js/jquery.dataTables.min.js"></script>


    <nav aria-label="breadcrumb">
      <ol class="breadcrumb my-breadcrumb">
        <li class="breadcrumb-item"><a href="frmPrincipal.aspx">Inicio</a></li>
        <li class="breadcrumb-item active" aria-current="page">Consulta de Vehiculos</li>
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
                    <h3>Filtros de Búsqueda de Vehículos<span></span></h3>
                </div>
                <div class="card-body">
                    <form action="javascript: cargaListaVehiculos()">
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label for="bsqVehiculo" class="input__label">Modelo</label>
                                <input type="text" class="form-control input-style" id="bsqVehiculo"
                                    placeholder="Modelo de Vehículo" maxlength="50">
                            </div>
                            <div class="form-group col-md-6">
                                <label for="bsqFab" class="input__label">Fabricante</label>
                                <select id="bsqFab" class="form-control input-style">
                                    
                                </select>
                            </div>
                        </div>
                        <button type="submit" class="btn btn-primary btn-style mt-4" onclick="">Buscar</button>
                        <button type="button" class="btn btn-primary btn-style mt-4" onclick="javascript: crearVehiculo()">Crear</button>
                    </form>
                </div>
            </div>
            <!-- //Formulario Búsqueda -->

            <!-- Formulario Resultados -->
            <div class="card card_border py-2 mb-4">
                <div class="cards__heading">
                    <h3>Resultados de Búsqueda de Vehículos<span></span></h3>
                </div>
                <div class="card-body">
                     <table id="tblVehiculos">
                        <!-- Definición de tabla aquí -->
                    </table>
                </div>
            </div>
            <!-- //Formulario Resultados -->
        </section>
    
    <script src="../JavaScript/Vehiculos.js"></script>
</asp:Content>
