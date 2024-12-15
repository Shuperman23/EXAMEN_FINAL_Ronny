var arreglo_Fabricantes = new Array();
var cantidad_Vehiculos = new Array();

$(document).ready(function () {

    Rutina_CargaGraficoTablas();

    setTimeout(function () {

        Rutina_ListaFabricantes_Grafico();
    }, 200);


});

function Rutina_CargaGraficoTablas() {
    var obj_Parametros = new Array();
    obj_Parametros[0] = $.cookie("GLBUNI");

    var parametros = '{"obj_Parametros" : ' + obj_Parametros + '}';
    parametros = JSON.stringify({ 'obj_Parametros': obj_Parametros });

    if ((obj_Parametros[0] != 0) && (obj_Parametros[0] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmPrincipal.aspx/CargaListaGraficoTablas",
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
                            $("#totalUsuarios").html(arreglo[0]);
                            $("#totalExtras").html(arreglo[1]);
                            $("#totalFabricantes").html(arreglo[2]);
                            $("#totalVehiculos").html(arreglo[3]);
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

            location.href = "/LogIn/frmLogIn.aspx";
        }, 5000);
    }
}

function Rutina_ListaFabricantes_Grafico() {

    var obj_Parametros = new Array();
    obj_Parametros[0] = $.cookie("GLBUNI");

    var parametros = '{"obj_Parametros" : ' + obj_Parametros + '}';
    parametros = JSON.stringify({ 'obj_Parametros': obj_Parametros });

    if ((obj_Parametros[0] != 0) && (obj_Parametros[0] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmPrincipal.aspx/CargaListaFabricantesGrafico",
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
                    var str;
                    str = res;
                    arreglo_Fabricantes = str.split("<SPLITER>").filter(function (el) {
                        return el.trim() !== ""; // Filtra los elementos vacíos
                    });
                    var resultado = arreglo_Fabricantes[0];




                    if (resultado === "No se encontraron registros") {
                        Swal.fire({
                            title: "Información de Registros",
                            text: res,
                            icon: "info"
                        });
                    } else {
                        if (resultado != "") {
                            Rutina_ListaCantidadVehiculosXFabricante();
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

            location.href = "/LogIn/frmLogIn.aspx";
        }, 5000);
    }

}


function Rutina_ListaCantidadVehiculosXFabricante() {

    var obj_Parametros = new Array();
    obj_Parametros[0] = $.cookie("GLBUNI");

    var parametros = '{"obj_Parametros" : ' + obj_Parametros + '}';
    parametros = JSON.stringify({ 'obj_Parametros': obj_Parametros });

    if ((obj_Parametros[0] != 0) && (obj_Parametros[0] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmPrincipal.aspx/CargaListaCantidadVehiculosXFabricantes",
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
                    var str;
                    str = res;
                    cantidad_Vehiculos = str.split("<SPLITER>").filter(function (el) {
                        return el.trim() !== ""; // Filtra los elementos vacíos
                    });

                    var resultado = cantidad_Vehiculos[0];

                    if (resultado === "No se encontraron registros") {
                        Swal.fire({
                            title: "Información de Registros",
                            text: res,
                            icon: "info"
                        });
                    } else {
                        if (resultado != "") {
                            Rutina_Grafico_VehiculosXFabricante();
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

            location.href = "/LogIn/frmLogIn.aspx";
        }, 5000);
    }
}

function Rutina_Grafico_VehiculosXFabricante() {

    // Generar colores aleatorios para cada perfil
    var backgroundColors = arreglo_Fabricantes.map(function () {
        return 'rgba(' +
            Math.floor(Math.random() * 256) + ',' + // Componente rojo (0-255)
            Math.floor(Math.random() * 50) + ',' +  // Componente verde reducido (0-49)
            Math.floor(Math.random() * 50) + ', 0.7)'; // Componente azul reducido (0-49)
    });

    new Chart(document.getElementById("grfPersonasXPerfilPie"), {
        type: 'pie',
        data: {
            labels: arreglo_Fabricantes, // Usar arreglo_Extras para las etiquetas
            datasets: [{
                data: cantidad_Vehiculos, // Usar dataArray para los datos
                backgroundColor: backgroundColors // Colores aleatorios
            }]
        },
        options: {
            responsive: true,
            legend: {
                position: 'top',
            },
        }
    });

    new Chart(document.getElementById("grfPersonasXSucursalPie"), {
        type: 'bar',
        data: {
            labels: arreglo_Fabricantes, // Usar arreglo_Extras para las etiquetas
            datasets: [{
                data: cantidad_Vehiculos, // Usar dataArray para los datos
                backgroundColor: backgroundColors // Colores aleatorios
            }]
        },
        options: {
            responsive: true,
            legend: {
                display: false, // Ocultar la leyenda si solo hay un dataset
            },
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });


    //setTimeout(function () {

    //    Rutina_Grafico_VehiculosXFabricanteBarras();
    //}, 1000);
}

function Rutina_Grafico_VehiculosXFabricanteBarras() {

    // Generar colores aleatorios para cada perfil
    var backgroundColors = arreglo_Fabricantes.map(function () {
        return 'rgba(' + Math.floor(Math.random() * 256) + ',' +
            Math.floor(Math.random() * 256) + ',' +
            Math.floor(Math.random() * 256) + ', 0.7)';
    });

    
}