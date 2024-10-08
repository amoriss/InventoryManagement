﻿// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// JavaScript to handle row click events and redirect to URL


//Makes entire row clickable
document.addEventListener('DOMContentLoaded', function () {
    const rows = document.querySelectorAll('.clickable-row');

    rows.forEach(row => {
        row.addEventListener('click', function () {
            window.location.href = this.getAttribute('data-href');
        });
    });
});

////////FILTER DATA////////////////
document.addEventListener('DOMContentLoaded', function () {
    const filterProductId = document.getElementById('filterProductId');
    const filterName = document.getElementById('filterName');
    const filterCategory = document.getElementById('filterCategory');
    const tableRows = document.querySelectorAll('.table tbody tr');

    // Function to filter table rows
    function filterTable() {
        const productIdValue = filterProductId.value.toLowerCase();
        const nameValue = filterName.value.toLowerCase();
        const categoryValue = filterCategory.value.toLowerCase();

        tableRows.forEach(row => {
            const productId = row.cells[0].textContent.toLowerCase();
            const name = row.cells[1].textContent.toLowerCase();
            const category = row.cells[3].textContent.toLowerCase();

            const matchesProductId = productId.includes(productIdValue);
            const matchesName = name.includes(nameValue);
            const matchesCategory = category.includes(categoryValue);

            // Show or hide the row based on the filter criteria
            if (matchesProductId && matchesName && matchesCategory) {
                row.style.display = '';
            } else {
                row.style.display = 'none';
            }
        });
    }

    // Attach event listeners to the filter inputs
    filterProductId.addEventListener('input', filterTable);
    filterName.addEventListener('input', filterTable);
    filterCategory.addEventListener('input', filterTable);
});


/////FIND A PRODUCT PAGE --> HIDES PRODUCTS UNTIL USER CHOOSES FILTER
document.addEventListener('DOMContentLoaded', function () {
    const filterProductId = document.getElementById('filterProductId');
    const filterName = document.getElementById('filterName');
    const filterCategory = document.getElementById('filterCategory');
    const tableBody = document.querySelector('tbody');

    function filterProducts() {
        const productIdValue = filterProductId.value.toLowerCase();
        const nameValue = filterName.value.toLowerCase();
        const categoryValue = filterCategory.value.toLowerCase();

        let hasFilters = false;

        tableBody.querySelectorAll('tr').forEach(row => {
            const productId = row.querySelector('td:nth-child(1)').textContent.toLowerCase();
            const name = row.querySelector('td:nth-child(2)').textContent.toLowerCase();
            const category = row.querySelector('td:nth-child(4)').textContent.toLowerCase();

            if (
                (productIdValue === '' || productId.includes(productIdValue)) &&
                (nameValue === '' || name.includes(nameValue)) &&
                (categoryValue === '' || category.includes(categoryValue))
            ) {
                row.style.display = ''; // Show row
                hasFilters = true;
            } else {
                row.style.display = 'none'; // Hide row
            }
        });

        // Show the table if any row matches the filter
        tableBody.parentElement.classList.toggle('products-hidden', !hasFilters);
    }

    // Add event listeners to filter inputs
    filterProductId.addEventListener('input', filterProducts);
    filterName.addEventListener('input', filterProducts);
    filterCategory.addEventListener('input', filterProducts);

    // Initialize the display
    filterProducts();
});