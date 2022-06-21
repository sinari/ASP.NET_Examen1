// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function validerFormulaire() {
    var nom = document.getElementById("nom").value;
    var telephone = document.getElementById("telephone").value;
    var couriel = document.getElementById("couriel").value;
    var site_web = document.getElementById("site_web").value;


    
    if (!(/.inc$/.test(nom))) {
        alert("Le nom de compagnie doit contenir à la fin \".inc\"");
        return false;
    }

    if (!(/^[(][0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4}$/.test(telephone))) {
        alert("Le format du telefone doit être \"(123)319-1234\"");
        return false;
    }

    if (!(/^[www.][0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4}$/.test(site_web))) {
        alert("Le format du telefone doit être \"(123)319-1234\"");
        return false;
    }

}