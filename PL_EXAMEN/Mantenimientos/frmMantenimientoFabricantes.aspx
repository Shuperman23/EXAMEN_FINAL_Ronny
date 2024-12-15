<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimientos/frmPrincipalMaster.Master" AutoEventWireup="true" CodeBehind="frmMantenimientoFabricantes.aspx.cs" Inherits="PL_EXAMEN.Mantenimientos.frmMantenimientoFabricantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.11.5/css/jquery.dataTables.min.css"/>
    <script src="https://cdn.datatables.net/1.11.5/js/jquery.dataTables.min.js"></script>
    
    <nav aria-label="breadcrumb">
      <ol class="breadcrumb my-breadcrumb">
        <li class="breadcrumb-item"><a href="frmPrincipal.aspx">Inicio</a></li>
        <li class="breadcrumb-item"><a href="frmConsultaFabricantes.aspx">Consulta de Fabricantes</a></li>
        <li class="breadcrumb-item active" aria-current="page">Mantenimiento de Fabricantes</li>
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
                    <h3>Mantenimiento de Información de Fabricantes<span></span></h3>
                </div>
                <div class="card-body">
                   <form id="frmFabricantees" action="javascript: mantenimientoFabricante()">
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label for="txtFabricante" class="input__label">Fabricante</label>
                                <input type="text" class="form-control input-style" id="txtFabricante" maxlength="50"
                                    placeholder="Nombre del Fabricante" required="">
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label for="txtOfi" class="input__label">Oficinas</label>
                                <input type="number" class="form-control input-style" id="txtOfi"
                                    placeholder="Cantidad de Oficinas del Fabricante" required="" min="0" max="100">
                            </div>
                            <div class="form-group col-md-6">
                                <label for="txtTel" class="input__label">Teléfono</label>
                                <input type="number" class="form-control input-style" id="txtTel" min="0" max="99999999"
                                    placeholder="Teléfono del Fabricante">
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label for="txtEml" class="input__label">Correo</label>
                                <input type="email" class="form-control input-style" id="txtEml" maxlength="100"
                                    placeholder="Correo del Fabricante" required="">
                            </div>
                            <div class="form-group col-md-6">
                                <label for="txtFecFun" class="input__label">Fecha Fundación</label>
                                <input type="date" class="form-control input-style" id="txtFecFun" required="">
                            </div>
                        </div>
                       <div class="form-row">
                            <div class="form-group col-md-6">
                                <label for="txtFecOpe" class="input__label">Fecha Inicio Operaciones</label>
                                <input type="date" class="form-control input-style" id="txtFecOpe" required="">
                            </div>
                            <div class="form-group col-md-6">
                                <label for="cboPais" class="input__label">País Origen</label>
                                <select id="cboPais" class="form-control input-style">
                                    <option value="ALE">Alemania</option>
                                    <option value="FRA">Francia</option>
                                    <option value="JAP">Japón</option>
                                    <option value="CHI">China</option>
                                    <option value="EU">Estados Unidos</option>
                                    <option value="UK">Reino Unido</option>
                                </select>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label for="txtDir" class="input__label">Dirección</label>
                                <input type="text" class="form-control input-style" id="txtDireccion" maxlength="500"
                                    placeholder="Dirección del Fabricante" required="">
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
    <script src="../JavaScript/Fabricantes.js"></script>
</asp:Content>
