$(function () {
    // Cuando cargue el documento, llamamos a la API para listar todos los 
    // servicios existentes.
    cargarServicios();
})
function cargarServicios() {
    $.ajax("/api/AzureServices", {
        method: "GET",
        success: function (data) {
            //Si hay éxito, introducimos el listado en el <ul> declarado.
            var listado = "";
            $.each(data, function (key, item) {
                //Cada item será un objeto AzureService
                listado = listado + '<li>' + item.Name + '</li>';
            });
            $("DIV#listadoServicios>ul").empty();
            $("DIV#listadoServicios>ul").append(listado);
        }
    });
}
function detalleServicio() {
    var id = $("#idServicio").val();
    $.ajax("/api/AzureServices/" + id, {
        method: "GET",
        success: function (data) {
            //Si hay éxito, introducimos los detalles en el div.
            var detalle = "The service with ID " + id + " is " + data.Name + "<br/>" + "Description: " + data.Description;
            $("#detalles").append(detalle);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}

function nuevoServicio() {
    if ($("#name").val() == "" || $("#description").val() == "") {
        alert("Debes añadir nombre y descripción!");
        return;
    }
    var servicio = {
        Name: $("#name").val(),
        Description: $("#description").val()
    }
    $.ajax("/api/AzureServices/", {
        method: "POST",
        data: servicio,
        success: function (data) {
            alert("Servicio agregado!");
            cargarServicios();
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}

function borrarServicio() {
    var id = $("#idServicio").val();
    $.ajax("/api/AzureServices/" + id, {
        method: "DELETE",
        success: function (data) {
            alert("Servicio borrado!");
            cargarServicios();
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}
