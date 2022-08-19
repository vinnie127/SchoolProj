var dataTable;



function loadDataTable(id) {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Courses/Studenterna",
            "type": "GET",
            "datatype": "json",
            "data": { id: id },
        },
        "columns": [
            { "data": "studentId", "width": "15%" },
            { "data": "name", "width": "15%" },
            { "data": "lastName", "width": "15%" },
            { "data": "epost", "width": "15%" },
            { "data": "phoneNumber", "width": "15%" },
            { "data": "streetAdress", "width": "15%" },
        ]
    });
}