var dataTable;



function loadDataTable(id) {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Students/Courses",
            "type": "GET",
            "datatype": "json",
            "data": { id: id },
        },
        "columns": [
            { "data": "id", "width": "15%" },
            { "data": "title", "width": "15%" },
        ]
    });
}