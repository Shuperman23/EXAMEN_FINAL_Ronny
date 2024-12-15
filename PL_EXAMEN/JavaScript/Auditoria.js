$(document).ready(function () {
    cargaUsuarios();
});

function cargaUsuarios() {
    var obj_Parametros = new Array();
    obj_Parametros[0] = $.cookie("GLBUNI");

    var parametros = '{"obj_Parametros" : ' + obj_Parametros + '}';
    parametros = JSON.stringify({ 'obj_Parametros': obj_Parametros });

    if ((obj_Parametros[0] != 0) && (obj_Parametros[0] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmConsultaAuditoria.aspx/CargaListaUsuariosCombo",
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
                        $("#cboUsuario").html("");
                        Swal.fire({
                            title: "Información de Registros",
                            text: res,
                            icon: "info"
                        });
                    } else {
                        $("#cboUsuario").html(res);
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
}

function cargaListaAuditoria() {

    var obj_Parametros = new Array();
    obj_Parametros[0] = $("#cboUsuario").val();
    obj_Parametros[1] = $("#cboAccion").val();
    obj_Parametros[2] = $("#bsqFdd").val();
    obj_Parametros[3] = $("#bsqFhh").val();
    obj_Parametros[4] = $.cookie("GLBUNI");

    var parametros = '{"obj_Parametros" : ' + obj_Parametros + '}';
    parametros = JSON.stringify({ 'obj_Parametros': obj_Parametros });

    if ((obj_Parametros[4] != 0) && (obj_Parametros[4] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmConsultaAuditoria.aspx/CargaListaAuditoria",
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
                        $("#tblAuditoria").html("");
                        Swal.fire({
                            title: "Búsqueda de Registros",
                            text: res,
                            icon: "info"
                        });

                    } else {
                        $("#tblAuditoria").html(res);
                        paginar("#tblAuditoria");
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