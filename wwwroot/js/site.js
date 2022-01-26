// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(".card-container").click(e => {
    let cardId = e.currentTarget.getAttribute("id");
    console.log(cardId);

});