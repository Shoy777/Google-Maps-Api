# Google Maps Api

Crud de Persona con Entity Framework, usando la api de Google Maps, Jquery UI(para el selector de fecha) y Bootstrap.

## Registrar
Vista de Inicio

## Modificar
Reutiliza la misma vista. Al seleccionar el icono lápiz de cada registro carga la información correspondiente en la vista.

## Eliminar
Eliminación fisica de modo directo, al seleccionar el icono trash.

## Listado
Parte de la vista principal al cargar la interfaz.

## Google Maps Api
* Infoview
* Marcador Personalizado(la imagen circular)
* Un ejemplo simple de uso de la api de google.

### Api Key
cambia "YourApiKey" del siguiente script, que se encuentra en el layout en la carpeta view.

```
<script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?key=YourApiKey"></script>
```

Para pintar el mapa en cada registro de la lista se adicionó el siguiente script al bucle.

```
var punto = new google.maps.LatLng(@i.CX, @i.CY);
var config = {
   zoom: 14,
   center: punto,
   mapTypeId: google.maps.MapTypeId.ROADMAP
};
var image = '/Content/img/marker.png';
var mapa = new google.maps.Map($("#map_@i.Id")[0], config);
var marcador = new google.maps.Marker({
   position: punto,
   map: mapa,
   icon: image
});
var infowindow = new google.maps.InfoWindow({
   content: "Vivo Aquí"
});
infowindow.open(mapa, marcador);
marcador.setMap(mapa);
```

Para que el mapa pueda verse en la interfaz, se envolvió el tag principal con otro tag con atributo 
class="container-mapa", estableciéndole un alto y se seleccionó los tag con identificador map,
anidánlole su id, para que no haya conflicto, y muestre el mapa de cada registro.

```
/*div que muestra el mapa de cada registro*/
<div class="container-mapa">
   <div id="map_@i.Id"></div>
</div>

/*Estilos archivo style ~/Content/css/style.css*/
[id*="map"] {
    height: 100%;
    width: 100%;
}
.container-mapa {
    height: 250px;
}
```

### Pantalla de la Aplicación

![Crud Google Maps Api](https://github.com/Shoy777/Google-Maps-Api/blob/master/Crud_GoogleMaps/Content/img/pantalla.png)

Crud de Persona con registro de ubicación - Google Maps Api , Entity Framework y Bootstrap
