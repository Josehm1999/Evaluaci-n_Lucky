var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/orden/ordenespaginados/",
            "type": "GET",
            "datatype": "json",
            "pagingType": "full_numbers"
        },
        "columns": [
            { "data": "ordenId", "width": "20%" },
            { "data": "cliente", "width": "20%" },
            { "data": "cantidadTotal", "width": "20%" },
            { "data": "ordenNumero", "width": "20%" },
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Estás seguro?",
        text: "Una vez borrado no se podrá recuperar",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    console.log(data);
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}