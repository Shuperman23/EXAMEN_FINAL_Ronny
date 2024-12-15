$(document).ready(function () {

    var pageName = window.location.pathname.split('/').pop();

    if (pageName == 'frmConsultaFabricantes.aspx') {
        cargaListaFabricantes();
    }
    else if (pageName == 'frmMantenimientoFabricantes.aspx') {
        obtieneDetalleFabricante();
    }
});

function crearFabricante() {
    $.cookie('FABUNI', 0, { expires: TLTC, path: '/', domain: g_Dominio });
    location.href = "frmMantenimientoFabricantes.aspx";
}

function abcdefg_cargaListaFabricantes_abcdefg() {
    $.cookie('FABUNI', 0, { expires: TLTC, path: '/', domain: g_Dominio });

    var obj_Parametros = new Array();
    obj_Parametros[0] = $("#bsqFabricante").val();
    obj_Parametros[1] = $("#bsqEstado").val();
    obj_Parametros[2] = $.cookie("GLBUNI");

    var parametros = '{"obj_Parametros" : ' + obj_Parametros + '}';
    parametros = JSON.stringify({ 'obj_Parametros': obj_Parametros });

    if ((obj_Parametros[2] != 0) && (obj_Parametros[2] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmConsultaFabricantes.aspx/CargaListaFabricantes",
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
                        $("#tblFabricantes").html("");
                        Swal.fire({
                            title: "Búsqueda de Registros",
                            text: res,
                            icon: "info"
                        });

                    } else {
                        $("#tblFabricantes").html(res);
                        paginar("#tblFabricantes");
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

function defineFabricante(pUni) {

    $.cookie('FABUNI', pUni, { expires: TLTC, path: '/', domain: g_Dominio });
    location.href = "frmMantenimientoFabricantes.aspx";

};

function abcdefg_obtieneDetalleFabricante_abcdfg() {

    var obj_Parametros = new Array();
    obj_Parametros[0] = $.cookie("FABUNI");
    obj_Parametros[1] = $.cookie("GLBUNI");

    var parametros = '{"obj_Parametros" : ' + obj_Parametros + '}';
    parametros = JSON.stringify({ 'obj_Parametros': obj_Parametros });

    if ((obj_Parametros[1] != 0) && (obj_Parametros[1] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoFabricantes.aspx/CargaInfoFabricante",
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
                            $("#txtFabricante").val(arreglo[1]);
                            $("#txtOfi").val(arreglo[2]);
                            $("#txtTel").val(arreglo[3]);
                            $("#txtEml").val(arreglo[4]);
                            $("#txtFecFun").val(formatDate(arreglo[5]));
                            $("#txtFecOpe").val(formatDate(arreglo[6]));
                            $("#cboPais").val(arreglo[7]);
                            $("#txtDireccion").val(arreglo[8]);
                            $("#cboSts").val(arreglo[9]);
                        }
                        if (obj_Parametros[0] == 0) {
                            $("#cboSts").attr("disabled", "disabled");
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

function mantenimientoFabricante() {


};

function eliminaFabricante(pUni) {


};



function regresar() {
    location.href = "frmConsultaFabricantes.aspx";
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