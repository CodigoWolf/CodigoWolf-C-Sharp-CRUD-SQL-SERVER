$(function () {
    //alert("Funcionando Jquery");
    addAnime();
    dtAnimes();
});

function addAnime() {
    $("#registrar-anime").on("click", function (e) {
        e.preventDefault();
        var data = {
            objAnime: {
                idanime : 0,
                nombre: $("#nombre").val(),
                sinopsis: $("#sinopsis").val(),
                estado: 1,
                objGenero: {
                    idgenero: $("#idgenero option:selected").val()
                }
            }
        }
        console.log(data);

        /*$.ajax({
            method: "POST",
            url: "Principal.aspx/addAnime",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify( data )
        }).done(function (info) {
            console.log(info);
            $(".mensaje").addClass("bg-info").html(info.d);
        });*/
    });
}

function dtAnimes() {
    var table = $("#dtanime").DataTable({
        destroy: true,
        ajax: {
            method: "POST",
            url: "Principal.aspx/getAnimes",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            dataSrc: "d.data"
        },
        columns: [
            { "data": "idanime", visible:false },
            { "data": "nombre" },
            { "data": "sinopsis" },
            { "data": "objGenero.idgenero", visible: false },
            { "data": "objGenero.nombre" },
            { "defaultContent": '<button type="button" class="editar btn btn-primary"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></button>', "bSortable": false },
            { "defaultContent": '<button type="button" class="eliminar btn btn-danger"><span class="glyphicon glyphicon-trash" aria-hidden="true"></span></button>', "bSortable": false }
        ]
    });
    getDataAnime("#dtanime tbody", table);
    getIdAnime("#dtanime tbody", table);
}

function getDataAnime(tbody, table) {
    $(tbody).on("click", "button.editar", function () {
        var data = table.row($(this).parents("tr")).data();
        console.log(data);        
    });
}

function getIdAnime(tbody, table) {
    $(tbody).on("click", "button.eliminar", function () {
        var data = table.row($(this).parents("tr")).data();
        console.log("Obteniendo el ID: " + data.idanime);
    });
}

function testAnimes() {
    $("#boton").on("click", function (e) {
        e.preventDefault();
        $.ajax({
            method: "POST",
            url: "Principal.aspx/getAnimes",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).done(function (info) {
            console.log(info);
        });
    });
}