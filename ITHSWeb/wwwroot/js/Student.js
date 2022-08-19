var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Students/GetAllStudent",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "studentId", "width": "10%" },
            { "data": "name", "width": "20%" },
            { "data": "lastName", "width": "15%" },
            {
                "data": "studentId",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Students/Update/${data}" class='btn btn-success text-white'
                                    style='cursor:pointer;'> <i class='far fa-edit'></i></a>
                                    &nbsp;
                                <a onclick=Delete("/Students/Delete/${data}") class='btn btn-danger text-white'
                                    style='cursor:pointer;'> <i class='far fa-trash-alt'></i></a>
                                         &nbsp;  
                                </div>
                            `;
                }, "width": "20%"
            },
            {
                "data": "studentId",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Students/CourseList/${data}" class='btn btn-success text-white'
                                    style='cursor:pointer;'> <i class='far fa-edit'></i></a>
                                    &nbsp;
                                </div>
                            `;
                }, "width": "5%"
            },
        ]
    });
}

function Delete(url) {
    swal({
        title: "Are you sure you want to Delete?",
        text: "You will not be able to restore the data!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: 'DELETE',
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