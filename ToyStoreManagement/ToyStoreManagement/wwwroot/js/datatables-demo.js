$(document).ready(function () {
    var table = $('#dataTable').DataTable({
        searching: true,
        ordering: true
    });

    $('#searchInput').on('keyup', function () {
        table.search(this.value).draw();
    });

    $('#dataTable').on('click', 'th', function () {
        var columnIndex = $(this).index();
        table.order([columnIndex, 'asc']).draw();
    });
});