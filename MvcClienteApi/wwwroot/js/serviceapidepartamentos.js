var urlapi = "https://apicruddepartamentoscorepgs.azurewebsites.net/";

function getTablaDepartamentosAsync(callback) {
    var request = "api/departamentos";
    $.ajax({
        url: urlapi + request,
        type: "GET",
        success: function (data) {
            var html = "";
            $.each(data, function (ind, dept) {
                html += "<tr>";
                html += "<td>" + dept.idDepartamento + "</td>";
                html += "<td>" + dept.nombre + "</td>";
                html += "<td>" + dept.localidad + "</td>";
                html += "</tr>";
            });
            callback(html);
        }
    });
}

function convertirDeptJson(id, nombre, localidad) {
    var departamento = new Object();
    departamento.idDepartamento = id;
    departamento.nombre = nombre;
    departamento.localidad = localidad;
    var json = JSON.stringify(departamento);
    return json;
}

function eliminarDepartamentoAsync(id, callback) {
    var request = "api/departamentos/" + id;
    $.ajax({
        url: urlapi + request,
        type: "DELETE",
        success: function () {
            //DEVOLVERE A LA PAGINA CUANDO HE TERMINADO
            callback();
        }
    });
}

function insertarDepartamentoAsync(json, callback) {
    var request = "api/departamentos";
    $.ajax({
        url: urlapi + request,
        type: "POST",
        data: json,
        contentType: "application/json",
        success: function () {
            callback();
        }
    });
}

function modificarDepartamentoAsync(json, callback) {
    var request = "api/departamentos";
    $.ajax({
        url: urlapi + request,
        contentType: "application/json",
        type: "PUT",
        data: json,
        success: function () {
            callback();
        }
    });
}