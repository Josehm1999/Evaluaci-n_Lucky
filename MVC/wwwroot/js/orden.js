var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/orden/ordenespaginados/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "ordenId", "width": "20%" },
            { "data": "cliente", "width": "20%" },
            { "data": "cantidadTotal", "width": "20%" },
            { "data": "ordenNumero", "width": "20%" },
            {
                "data": "ordenid",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Orden/Upsert?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                            Editar
                        </a>
                        &nbsp;
                        <a class='btn btn-danger text-white' style='cursor:pointer; width:70px;'
                            onclick=Delete('/Orden/Delete?id='+${data})>
                            Borrar
                        </a>
                        </div>`;
                }, "width": "40%"
            }
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