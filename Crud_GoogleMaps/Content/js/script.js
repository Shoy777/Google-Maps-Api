$(".btnDate").click(function () {
    $("#FechaNacimiento").focus();
});


var nuevos_marcadores = [];
var marcadores_bd = [];
var mapa = null; //VARIABLE GENERAL PARA EL MAPA
//FUNCION PARA QUITAR MARCADORES DE MAPA
function limpiar_marcadores(lista) {
    for (i in lista) {
        //QUITAR MARCADOR DEL MAPA
        lista[i].setMap(null);
    }
}

$(document).ready(function () {
    //VARIABLE DE FORMULARIO
    var formulario = $("#frm-crud");
    var punto = new google.maps.LatLng(-12.05602465826096, -77.0844554901123);
    var config = {
        zoom: 14,
        center: punto,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    mapa = new google.maps.Map($("#mapa")[0], config);
    google.maps.event.addListener(mapa, "click", function (event) {
        var coordenadas = event.latLng.toString();
        coordenadas = coordenadas.replace("(", "");
        coordenadas = coordenadas.replace(")", "");
        var lista = coordenadas.split(",");
        var direccion = new google.maps.LatLng(lista[0], lista[1]);
        //PASAR LA INFORMACI�N AL FORMULARIO
        formulario.find("input[name='CX']").val(lista[0]);
        formulario.find("input[name='CY']").val(lista[1]);

        var marcador = new google.maps.Marker({
            position: direccion,
            map: mapa,
            animation: google.maps.Animation.DROP,
            draggable: false
        });
        //ALMACENAR UN MARCADOR EN EL ARRAY nuevos_marcadores
        nuevos_marcadores.push(marcador);
        google.maps.event.addListener(marcador, "click", function () {});
        //BORRAR MARCADORES NUEVOS
        limpiar_marcadores(nuevos_marcadores);
        marcador.setMap(mapa);
    });
});

$(".fecha").datepicker({ dateFormat: "dd/mm/yy" }).mask("99/99/9999");
$.validator.addMethod('date',
function (value, element, params) {
    if (this.optional(element)) {
        return true;
    }
    var ok = true;
    try {
        $.datepicker.parseDate('dd/mm/yy', value);
    }
    catch (err) {
        ok = false;
    }
    return ok;
});
