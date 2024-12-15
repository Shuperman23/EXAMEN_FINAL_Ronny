var g_Dominio = "localhost";
var TLTC = 60;
var g_NombreUsuario;

$(document).ready(function () {

    var pageName = window.location.pathname.split('/').pop();

    if (pageName !== 'frmInicioSesion.aspx') {
        cargaOpcionesUsuario();
    }
});

function cargaOpcionesUsuario()
{
    $("#nombreUsuario").html($.cookie("GLBDSC"));
    $("#emlUsuario").html($.cookie("GLBCOD"));
    $("#lblNombreUsuario").html($.cookie("GLBDSC"));
    $("#lblEmlUsuario").html($.cookie("GLBCOD"));

    var obj_Parametros = new Array();
    obj_Parametros[0] = $.cookie("GLBUNI");

    var parametros = '{"obj_Parametros" : ' + obj_Parametros + '}';
    parametros = JSON.stringify({ 'obj_Parametros': obj_Parametros });

    if ((obj_Parametros[0] != 0) && (obj_Parametros[0] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "/LogIn/frmInicioSesion.aspx/cargaOpcionesMenuUsuarios",
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
                        Swal.fire({
                            title: "Permisos de Usuario",
                            text: "El usuario no tiene permisos asignados para el acceso a las opciones del sistema. Por favor, contacte al administrador del sistema.",
                            icon: "error"
                        });

                    } else {
                        $("#menu").html(res);
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

function cerrarSesion() {
    var obj_Parametros = new Array();
    obj_Parametros[0] = $.cookie("GLBUNI");
    obj_Parametros[1] = $.cookie("GLBDSC");
    var parametros = '{"obj_Parametros" : ' + obj_Parametros + '}';
    parametros = JSON.stringify({ 'obj_Parametros': obj_Parametros });

    jQuery.ajax({
        type: "POST",
        url: "/LogIn/frmInicioSesion.aspx/CierreSesionUsuarios",
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

                if ((resultado != "0") && (resultado != "-1")) {

                    //COOKIES DEL USUARIO GLOBAL
                    $.cookie('GLBUNI', null, { expires: -1, path: '/', domain: g_Dominio }); //ID DE USUARIO GLOBAL
                    $.cookie('GLBCOD', null, { expires: -1, path: '/', domain: g_Dominio }); //EMAIL DE USUARIO GLOBAL
                    $.cookie('GLBDSC', null, { expires: -1, path: '/', domain: g_Dominio }); //NOMBRE DE USUARIO GLOBAL

                    //COOKIES DE FABRICANTE
                    $.cookie('FABUNI', null, { expires: -1, path: '/', domain: g_Dominio }); //ID DE FABRICANTE
                    //COOKIES DE VEHICULO
                    $.cookie('VHCUNI', null, { expires: -1, path: '/', domain: g_Dominio }); //ID DE VEHICULO




                    Swal.fire({
                        position: 'center-center',
                        icon: 'success',
                        title: "Cierre de Sesión",
                        text: "Gracias " + obj_Parametros[1] + ". Hasta pronto!!!",
                        showConfirmButton: false,
                        timer: 4500,
                        timerProgressBar: true
                    });
                    // se redirecciona al index
                    setTimeout(function () {

                        location.href = "/LogIn/frmInicioSesion.aspx";
                    }, 5000);

                } else {

                    Swal.fire({
                        position: 'center-center',
                        icon: 'error',
                        title: "Cierre de Sesión",
                        text: "No se pudo cerrar la sesión, intente más tarde.",
                        showConfirmButton: false,
                        timer: 4500,
                        timerProgressBar: true
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

function inicioSesion() {
    var obj_Parametros = new Array();

    obj_Parametros[0] = $("#txtUsuario").val();
    obj_Parametros[1] = $("#txtPassword").val();

    var parametros = '{"obj_Parametros" : ' + obj_Parametros + '}';
    parametros = JSON.stringify({ 'obj_Parametros': obj_Parametros });

    jQuery.ajax({
        type: "POST",
        url: "frmInicioSesion.aspx/InicioSesionUsuarios",
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

                if ((resultado != "0") && (resultado != "-1"))
                {
                    $.cookie('GLBUNI', arreglo[0], { expires: TLTC, path: '/', domain: g_Dominio });
                    $.cookie('GLBCOD', arreglo[2], { expires: TLTC, path: '/', domain: g_Dominio });
                    $.cookie('GLBDSC', arreglo[3], { expires: TLTC, path: '/', domain: g_Dominio });

                    Swal.fire({
                        position: 'center-center',
                        icon: 'success',
                        title: "Inicio de Sesión",
                        text: arreglo[1],
                        showConfirmButton: false,
                        timer: 4500,
                        timerProgressBar: true
                    });
                    setTimeout(function () {

                        location.href = "../Mantenimientos/frmPrincipal.aspx";
                    }, 4500);
                }
                else {
                    Swal.fire({
                        position: 'center-center',
                        icon: 'error',
                        title: "Inicio de Sesión",
                        text: arreglo[1],
                        showConfirmButton: false,
                        timer: 4500,
                        timerProgressBar: true
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
