/* ESTAS FUNCIONES PUEDEN RESOLVER ALGUNOS REQUERIMIENTOS DE CRUD, LEER Y ANALIZAR*/

function mantenimientoFabricante() {
    var obj_Parametros = new Array();
    obj_Parametros[0] = $.cookie("FABUNI");
    obj_Parametros[1] = $("#txtFabricante").val();
    obj_Parametros[2] = $("#txtOfi").val();
    obj_Parametros[3] = $("#txtTel").val();
    obj_Parametros[4] = $("#txtEml").val();
    obj_Parametros[5] = $("#txtFecFun").val();
    obj_Parametros[6] = $("#txtFecOpe").val();
    obj_Parametros[7] = $("#cboPais").val();
    obj_Parametros[8] = $("#txtDireccion").val();
    obj_Parametros[9] = $("#cboSts").val();
    obj_Parametros[10] = $.cookie("GLBUNI");

    var parametros = '{"obj_Parametros" : ' + obj_Parametros + '}';
    parametros = JSON.stringify({ 'obj_Parametros': obj_Parametros });

    if ((obj_Parametros[10] != 0) && (obj_Parametros[10] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoFabricantes.aspx/MantenimientoFabricantes",
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
                        Swal.fire({
                            position: 'center-center',
                            icon: 'success',
                            title: "Información de Registros",
                            text: arreglo[1],
                            showConfirmButton: false,
                            timer: 4500,
                            timerProgressBar: true
                        });

                        setTimeout(function () {

                            location.href = "frmConsultaFabricantes.aspx";
                        }, 5000);
                    } else {
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

function eliminaFabricante(pUni) {

    var obj_Parametros = new Array();
    obj_Parametros[0] = pUni;
    obj_Parametros[1] = $.cookie("GLBUNI");

    var parametros = '{"obj_Parametros" : ' + obj_Parametros + '}';
    parametros = JSON.stringify({ 'obj_Parametros': obj_Parametros });

    if ((obj_Parametros[1] != 0) && (obj_Parametros[1] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoFabricantes.aspx/EliminaFabricantes",
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

                            cargaListaFabricantes();
                        }, 3000);

                    } else {
                        cargaListaFabricantes();

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


function cargaListaVehiculos() {
    $.cookie('VHCUNI', 0, { expires: TLTC, path: '/', domain: g_Dominio });

    var obj_Parametros = new Array();
    obj_Parametros[0] = $("#bsqVehiculo").val();
    obj_Parametros[1] = $("#bsqFab").val();
    obj_Parametros[2] = $.cookie("GLBUNI");

    var parametros = '{"obj_Parametros" : ' + obj_Parametros + '}';
    parametros = JSON.stringify({ 'obj_Parametros': obj_Parametros });

    if ((obj_Parametros[2] != 0) && (obj_Parametros[2] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmConsultaVehiculos.aspx/CargaListaVehiculos",
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
                        $("#tblVehiculos").html("");
                        Swal.fire({
                            title: "Búsqueda de Registros",
                            text: res,
                            icon: "info"
                        });

                    } else {
                        $("#tblVehiculos").html(res);
                        paginar("#tblVehiculos");
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



function mantenimientoVehiculo() {

    var obj_Parametros = new Array();
    obj_Parametros[0] = $.cookie("VHCUNI");
    obj_Parametros[1] = $("#txtModelo").val();
    obj_Parametros[2] = $("#txtAno").val();
    obj_Parametros[3] = $("#txtPsj").val();
    obj_Parametros[4] = $("#txtCil").val();
    obj_Parametros[5] = $("#txtFec").val();
    obj_Parametros[6] = $("#cboFab").val();
    obj_Parametros[7] = $("#cboTra").val();
    obj_Parametros[8] = $("#txtDsc").val();
    obj_Parametros[9] = $("#cboSts").val();
    obj_Parametros[10] = $.cookie("GLBUNI");

    var parametros = '{"obj_Parametros" : ' + obj_Parametros + '}';
    parametros = JSON.stringify({ 'obj_Parametros': obj_Parametros });

    if ((obj_Parametros[10] != 0) && (obj_Parametros[10] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoVehiculos.aspx/MantenimientoVehiculos",
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
                        Swal.fire({
                            position: 'center-center',
                            icon: 'success',
                            title: "Información de Registros",
                            text: arreglo[1],
                            showConfirmButton: false,
                            timer: 4500,
                            timerProgressBar: true
                        });

                        setTimeout(function () {

                            location.href = "frmConsultaVehiculos.aspx";
                        }, 5000);
                    } else {
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
