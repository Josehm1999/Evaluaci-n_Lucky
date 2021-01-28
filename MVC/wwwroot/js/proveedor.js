var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/proveedor/proveedorespaginados/",
            "type": "GET",
            "datatype": "json",
            "pagingType": "full_numbers",

        },
        "columns": [
            { "data": "nombreEmpresa", "width": "20%" },
            { "data": "nombreContacto", "width": "20%" },
            { "data": "ciudad", "width": "20%" },
            { "data": "pais", "width": "20%" },
            { "data": "telefono", "width": "20%" },
            { "data": "fax", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Proveedor/Upsert?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                            Editar
                        </a>
                        &nbsp;
                        <a class='btn btn-danger text-white' style='cursor:pointer; width:70px;'
                            onclick=Delete('/Proveedor/Delete?id='+${data})>
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