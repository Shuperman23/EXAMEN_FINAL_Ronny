<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimientos/frmPrincipalMaster.Master" AutoEventWireup="true" CodeBehind="frmConsultaAuditoria.aspx.cs" Inherits="PL_EXAMEN.Mantenimientos.frmConsultaAuditoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.11.5/css/jquery.dataTables.min.css"/>
    <script src="https://cdn.datatables.net/1.11.5/js/jquery.dataTables.min.js"></script>

    <nav aria-label="breadcrumb">
      <ol class="breadcrumb my-breadcrumb">
        <li class="breadcrumb-item"><a href="frmPanel.aspx">Inicio</a></li>
        <li class="breadcrumb-item active" aria-current="page">Consulta de Auditoría</li>
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
                    <h3>Filtros de Búsqueda de Auditoría<span></span></h3>
                </div>
                <div class="card-body">
                    <form action="javascript: cargaListaAuditoria()">
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label for="cboUsuario" class="input__label">Usuario</label>
                                <select id="cboUsuario" class="form-control input-style" required="">
                                </select>
                            </div> 
                            <div class="form-group col-md-6">
                                <label for="cboAccion" class="input__label">Acción</label>
                                <select id="cboAccion" class="form-control input-style" required="">
                                    <option value="T">Todas</option>
                                    <option value="I">Insertar</option>
                                    <option value="A">Actualizar</option>
                                    <option value="E">Eliminar</option>
                                </select>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label for="bsqFdd" class="input__label">Desde</label>
                                <input type="date" class="form-control input-style" id="bsqFdd"
                                    placeholder="Fecha Desde" required="">
                            </div>
                            <div class="form-group col-md-6">
                                <label for="bsqFhh" class="input__label">Hasta</label>
                                <input type="date" class="form-control input-style" id="bsqFhh"
                                    placeholder="Fecha Hasta" required="">
                            </div>
                        </div>
                        <button type="submit" class="btn btn-primary btn-style mt-4">Buscar</button>
                    </form>
                </div>
            </div>
            <!-- //Formulario Búsqueda -->

            <!-- Formulario Resultados -->
            <div class="card card_border py-2 mb-4">
                <div class="cards__heading">
                    <h3>Resultados de Búsqueda de Auditoría<span></span></h3>
                </div>
                <div class="card-body">
                     <table id="tblAuditoria">
                        <!-- Definición de tabla aquí -->
                    </table>
                </div>
            </div>
            <!-- //Formulario Resultados -->
        </section>
    <script src="../JavaScript/Auditoria.js"></script>
</asp:Content>
