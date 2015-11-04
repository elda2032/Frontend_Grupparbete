$(document).ready(function () {
    $('#myTable').dataTable({
        ajax: 'js/data.txt',
        paging: true,
        ordering: true,
        responsive: true
    });
});