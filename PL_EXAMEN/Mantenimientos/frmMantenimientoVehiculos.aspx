<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimientos/frmPrincipalMaster.Master" AutoEventWireup="true" CodeBehind="frmMantenimientoVehiculos.aspx.cs" Inherits="PL_EXAMEN.Mantenimientos.frmMantenimientoVehiculos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.11.5/css/jquery.dataTables.min.css"/>
    <script src="https://cdn.datatables.net/1.11.5/js/jquery.dataTables.min.js"></script>
    
    <nav aria-label="breadcrumb">
      <ol class="breadcrumb my-breadcrumb">
        <li class="breadcrumb-item"><a href="frmPrincipal.aspx">Inicio</a></li>
        <li class="breadcrumb-item"><a href="frmConsultaVehiculos.aspx">Consulta de Vehículos</a></li>
        <li class="breadcrumb-item active" aria-current="page">Mantenimiento de Vehículos</li>
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
                    <h3>Mantenimiento de Información de Vehículos<span></span></h3>
                </div>
                <div class="card-body">
                   <form id="frmVehiculos" action="javascript: mantenimientoVehiculo()">
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label for="txtModelo" class="input__label">Modelo Vehículo</label>
                                <input type="text" class="form-control input-style" id="txtModelo" maxlength="50"
                                    placeholder="Modelo del Vehículo" required="">
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label for="txtAno" class="input__label">Año de Vehículo</label>
                                <input type="number" class="form-control input-style" id="txtAno"
                                    placeholder="Año de Vehículo" required="" min="1900" max="9999">
                            </div>
                            <div class="form-group col-md-6">
                                <label for="txtPsj" class="input__label">Pasajeros</label>
                                <input type="number" class="form-control input-style" id="txtPsj" min="3" max="8"
                                    placeholder="Capacidad de Pasajeros">
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label for="txtCil" class="input__label">Cilindraje</label>
                                <input type="number" class="form-control input-style" id="txtCil" min="1000" max="3000"
                                    placeholder="Cilindraje de Motor de Vehículo">
                            </div>
                            <div class="form-group col-md-6">
                                <label for="txtFec" class="input__label">Fecha Fabricación</label>
                                <input type="date" class="form-control input-style" id="txtFec" required="">
                            </div>
                        </div>
                       <div class="form-row">
                            <div class="form-group col-md-6">
                                <label for="cboFab" class="input__label">Fabricante</label>
                                <select id="cboFab" class="form-control input-style" required="">
                                    
                                </select>
                            </div>
                            <div class="form-group col-md-6">
                                <label for="cboTra" class="input__label">Transmisión</label>
                                <select id="cboTra" class="form-control input-style">
                                    <option value="A">Automática</option>
                                    <option value="M">Manual</option>
                                </select>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label for="txtDsc" class="input__label">Descripción</label>
                                <input type="text" class="form-control input-style" id="txtDsc" maxlength="500"
                                    placeholder="Descripción de Vehículo" required="">
                            </div>
                            <div class="form-group col-md-6">
                                <label for="cboSts" class="input__label">Estado</label>
                                <select id="cboSts" class="form-control input-style">
                                    <option value="A">Activo</option>
                                    <option value="I">Inactivo</option>
                                </select>
                            </div>
                        </div>
                        <button type="submit" class="btn btn-primary btn-style mt-4">Guardar</button>
                        <button type="button" class="btn btn-primary btn-style mt-4" onclick="javascript: regresar()">Regresar</button>
                    </form>
                </div>
            </div>
            <!-- //Formulario Búsqueda -->
        </section>
    <script src="../JavaScript/Vehiculos.js"></script>
</asp:Content>
