$(document).ready(function () {
    cargaFabricantes();

    var pageName = window.location.pathname.split('/').pop();

    if (pageName == 'frmConsultaVehiculos.aspx') {
        setTimeout(function () {
            cargaListaVehiculos();
        }, 1500);
        
    }
    else if (pageName == 'frmMantenimientoVehiculos.aspx') {
        

        setTimeout(function () {
            obtieneDetalleVehiculo();
        }, 1500);

    }
});

function crearVehiculo() {
    $.cookie('VHCUNI', 0, { expires: TLTC, path: '/', domain: g_Dominio });
    location.href = "frmMantenimientoVehiculos.aspx";
}


function defineVehiculo(pUni) {

    $.cookie('VHCUNI', pUni, { expires: TLTC, path: '/', domain: g_Dominio });
    location.href = "frmMantenimientoVehiculos.aspx";

};

function cargaFabricantes() {
    var obj_Parametros = new Array();
    obj_Parametros[0] = $.cookie("VHCUNI");
    obj_Parametros[1] = $.cookie("GLBUNI");

    var parametros = '{"obj_Parametros" : ' + obj_Parametros + '}';
    parametros = JSON.stringify({ 'obj_Parametros': obj_Parametros });

    if ((obj_Parametros[1] != 0) && (obj_Parametros[1] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmConsultaFabricantes.aspx/CargaListaFabricantesCombo",
            data: parametros,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            success: function (msg) {
                var res = msg.d;
                if (res === undefined) {
                    Swal.fire({
                        title: "Error en la conexión",
                        text: "Error de Conexión a la base de datos. Por favor, contacte al administrador del sistema.",
                        icon: "error"
                    });
                }
                else {
                    if (res === "No se encontraron registros") {
                        $("#bsqFab").html("");
                        $("#cboFab").html("");
                        Swal.fire({
                            title: "Información de Registros",
                            text: res,
                            icon: "info"
                        });

                        setTimeout(function () {

                            location.href = "frmConsultaVehiculos.aspx";
                        }, 1500);
                    } else {
                        $("#bsqFab").html(res);
                        $("#cboFab").html(res);
                    }
                }
            },
            failure: function (msg) {
            },
            error: function (xhr, err) {
            }
        });
    }
    else {
        Swal.fire({
            position: 'center-center',
            icon: 'error',
            title: "Error en la conexión",
            text: "No se ha podido validar la información del usuario. Por favor, inicie Sesión en el Sistema.",
            showConfirmButton: false,
            timer: 4500,
            timerProgressBar: true
        });
        // se redirecciona al index
        setTimeout(function () {

            location.href = "/LogIn/frmInicioSesion.aspx";
        }, 5000);
    }




};

function obtieneDetalleVehiculo() {

    var obj_Parametros = new Array();
    obj_Parametros[0] = $.cookie("VHCUNI");
    obj_Parametros[1] = $.cookie("GLBUNI");

    var parametros = '{"obj_Parametros" : ' + obj_Parametros + '}';
    parametros = JSON.stringify({ 'obj_Parametros': obj_Parametros });

    if ((obj_Parametros[1] != 0) && (obj_Parametros[1] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoVehiculos.aspx/CargaInfoVehiculo",
            data: parametros,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            success: function (msg) {
                var res = msg.d;
                if (res === undefined) {
                    Swal.fire({
                        title: "Error en la conexión",
                        text: "Error de Conexión a la base de datos. Por favor, contacte al administrador del sistema.",
                        icon: "error"
                    });
                }
                else {
                    var arreglo = new Array();
                    var str;

                    str = res;
                    arreglo = (str.split("<SPLITER>"));
                    var resultado = arreglo[0];

                    if (resultado === "No se encontraron registros") {
                        Swal.fire({
                            title: "Información de Registros",
                            text: res,
                            icon: "info"
                        });
                    } else {
                        if (resultado != "") {
                            $("#txtModelo").val(arreglo[1]);
                            $("#txtAno").val(arreglo[2]);
                            $("#txtPsj").val(arreglo[3]);
                            $("#txtCil").val(arreglo[4]);
                            $("#txtFec").val(formatDate(arreglo[5]));
                            $("#cboFab").val(arreglo[6]);
                            $("#cboTra").val(arreglo[7]);
                            $("#txtDsc").val(arreglo[8]);
                            $("#cboSts").val(arreglo[9]);
                        }
                    }
                }
            },
            failure: function (msg) {
            },
            error: function (xhr, err) {
            }
        });
    }
    else {
        Swal.fire({
            position: 'center-center',
            icon: 'error',
            title: "Error en la conexión",
            text: "No se ha podido validar la información del usuario. Por favor, inicie Sesión en el Sistema.",
            showConfirmButton: false,
            timer: 4500,
            timerProgressBar: true
        });
        // se redirecciona al index
        setTimeout(function () {

            location.href = "/LogIn/frmInicioSesion.aspx";
        }, 5000);
    }
};

function formatDate(dateStr) {
    var dateParts = dateStr.split("/");
    var day = dateParts[0].padStart(2, '0');
    var month = dateParts[1].padStart(2, '0');
    var year = dateParts[2];
    return `${year}-${month}-${day}`;
}


function cargaListaVehiculos() {


};



function mantenimientoVehiculo() {

    

};


function eliminaVehiculo(pUni) {

    var obj_Parametros = new Array();
    obj_Parametros[0] = pUni;
    obj_Parametros[1] = $.cookie("GLBUNI");

    var parametros = '{"obj_Parametros" : ' + obj_Parametros + '}';
    parametros = JSON.stringify({ 'obj_Parametros': obj_Parametros });

    if ((obj_Parametros[1] != 0) && (obj_Parametros[1] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoVehiculos.aspx/EliminaVehiculos",
            data: parametros,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            success: function (msg) {
                //$("#dialogLoading").dialog("close");
                var res = msg.d;
                if (res === undefined) {
                    Swal.fire({
                        title: "Error en la conexión",
                        text: "Error de Conexión a la base de datos. Por favor, contacte al administrador del sistema.",
                        icon: "error"
                    });
                }
                else {
                    var arreglo = new Array();
                    var str;

                    str = res;
                    arreglo = (str.split("<SPLITER>"));

                    var resultado = arreglo[0];

                    if ((resultado != "0") && (resultado != "-1")) {

                        Swal.fire({
                            position: 'center-center',
                            icon: 'success',
                            title: "Información de Registros",
                            text: arreglo[1],
                            showConfirmButton: false,
                            timer: 2500,
                            timerProgressBar: true
                        });
                        setTimeout(function () {

                            cargaListaVehiculos();
                        }, 3000);

                    } else {
                        cargaListaVehiculos();

                        Swal.fire({
                            title: "Información de Registros",
                            text: arreglo[1],
                            icon: "info"
                        });
                    }
                }
            },
            failure: function (msg) {
            },
            error: function (xhr, err) {
            }
        });
    }
    else {
        Swal.fire({
            position: 'center-center',
            icon: 'error',
            title: "Error en la conexión",
            text: "No se ha podido validar la información del usuario. Por favor, inicie Sesión en el Sistema.",
            showConfirmButton: false,
            timer: 4500,
            timerProgressBar: true
        });
        // se redirecciona al index
        setTimeout(function () {

            location.href = "/LogIn/frmInicioSesion.aspx";
        }, 5000);
    }
};

function regresar() {
    location.href = "frmConsultaVehiculos.aspx";
}

function paginar(elemento) {


    var table;

    if ($.fn.DataTable.isDataTable(elemento)) {

        table = $(elemento).DataTable({

            "iDisplayLength": 5,
            "aLengthMenu": [[5, 10, 50, 100], [5, 10, 50, 100]],
            "oLanguage":
            {
                "sLengthMenu": " Mostrar _MENU_  registros por p&aacute;gina",
                "sProcessing": "Procesando...",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Filtrar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                }
            },
            paging: true,
            destroy: true
        });
    }
    else {
        table = $(elemento).DataTable({

            "iDisplayLength": 5,
            "aLengthMenu": [[5, 10, 50, 100], [5, 10, 50, 100]],
            "oLanguage":
            {
                "sLengthMenu": " Mostrar _MENU_  registros por p&aacute;gina",
                "sProcessing": "Procesando...",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Filtrar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                }
            },
            paging: true,
            destroy: true
        });

    }

};

function ExtrasXVehiculo(pUni) {

    $.cookie('VHCUNI', pUni, { expires: TLTC, path: '/', domain: g_Dominio });
    location.href = "frmMantenimientoExtrasXVehiculo.aspx";
}

