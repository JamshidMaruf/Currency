// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const elListResult = document.querySelector("#list");

new Sortable(elListResult,{
    animation: 150,
    ghostClass: `blue-background-class`
})