// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var tokenKey = "access_token";

function getUserNames() {
    var form = {
        Email: "d.belik@bk.ru",
        Password: "123"
    };

    $.ajax({
        url: "/account/login",
        type: "POST",
        data: JSON.stringify(form),
        contentType: "application/json",
        dataType: "json",
        success: function (token) {
            window.sessionStorage.setItem(tokenKey, token.access_token);
            $('#user').append("<h1>" + token.username + "</h1>");
        }
    });
}

function getHome() {
    var token = window.sessionStorage.getItem(tokenKey);

    $.ajax({
        url: "/home/index",
        type: "GET",
        headers: {
            "Accept": "application/json",
            "Authorization": "Bearer " + token
        },
        success: function (text) {
            $('#user').append("<h1>Получено " + text + "</h1>");
        }
    });
}