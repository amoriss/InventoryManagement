// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// JavaScript to handle row click events and redirect to URL
document.addEventListener('DOMContentLoaded', function () {
    const rows = document.querySelectorAll('.clickable-row');

    rows.forEach(row => {
        row.addEventListener('click', function () {
            window.location.href = this.getAttribute('data-href');
        });
    });
});