<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimientos/frmPrincipalMaster.Master" AutoEventWireup="true" CodeBehind="frmConsultaFabricantes.aspx.cs" Inherits="PL_EXAMEN.Mantenimientos.frmConsultaFabricantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.11.5/css/jquery.dataTables.min.css"/>
    <script src="https://cdn.datatables.net/1.11.5/js/jquery.dataTables.min.js"></script>


    <nav aria-label="breadcrumb">
      <ol class="breadcrumb my-breadcrumb">
        <li class="breadcrumb-item"><a href="frmPrincipal.aspx">Inicio</a></li>
        <li class="breadcrumb-item active" aria-current="page">Consulta de Fabricantes</li>
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
                    <h3>Filtros de Búsqueda de Fabricantes<span></span></h3>
                </div>
                <div class="card-body">
                    <form action="javascript: cargaListaFabricantes()">
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label for="bsqFabricante" class="input__label">Fabricante</label>
                                <input type="text" class="form-control input-style" id="bsqFabricante"
                                    placeholder="Nombre de Fabricante" maxlength="50">
                            </div>
                            <div class="form-group col-md-6">
                                <label for="bsqEstado" class="input__label">Estado</label>
                                <select id="bsqEstado" class="form-control input-style">
                                    <option value="A">Activo</option>
                                    <option value="I">Inactivo</option>
                                </select>
                            </div>
                        </div>
                        <button type="submit" class="btn btn-primary btn-style mt-4" onclick="">Buscar</button>
                        <button type="button" class="btn btn-primary btn-style mt-4" onclick="javascript: crearFabricante()">Crear</button>
                    </form>
                </div>
            </div>
            <!-- //Formulario Búsqueda -->

            <!-- Formulario Resultados -->
            <div class="card card_border py-2 mb-4">
                <div class="cards__heading">
                    <h3>Resultados de Búsqueda de Fabricantes<span></span></h3>
                </div>
                <div class="card-body">
                     <table id="tblFabricantes">
                        <!-- Definición de tabla aquí -->
                    </table>
                </div>
            </div>
            <!-- //Formulario Resultados -->
        </section>
    
    <script src="../JavaScript/Fabricantes.js"></script>
</asp:Content>
