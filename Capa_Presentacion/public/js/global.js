function __login() {
    $("#login-form").on("submit", function(e){
        e.preventDefault();
        var data = {
            objUsuario: {
                idusuario: 0,
                usuario: $("#usuario").val(),
                password: $("#password").val()
            }
        };
        $.ajax({
            method: "POST",
            url: "Index.aspx/Login",
            data: JSON.stringify(data),
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).done(function (info) {
            //Respuesta del servidor
            if (info.d.mensaje === "BAD") {
                $(".mensaje").html(`<b>Usuario o Password incorrectos.</b>`);
                console.log("Usuario o Password incorrectos");
            }
            else{
                window.location = info.d.mensaje;//url
            }
            //$(".mensaje").html( info.d );
        })
    });
}

function __showUsers() {
    $("#boton").on("click", function () {
        dtUsers();
    });
}

function dtUsers() {
    var table = $("#table-users").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "Index.aspx/getUsers",
            data: function (d) {               
                return JSON.stringify(d);
            },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            dataSrc: "d.data"
        },
        columns: [
            { "data": "id"},
            { "data": "user" },
            { "data": "password"}
        ]
    });
}

function test() {
    $.ajax({
        method: "POST",
        url: "Index.aspx/getUsers",
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).done(function (info) {
        console.log(info);
    });
}