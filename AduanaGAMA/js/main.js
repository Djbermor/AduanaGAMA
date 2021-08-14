////$(document).ready(function () {


////});

function ValidarCompaos() {
    if ($(nombre).val() === "" || $(apellido).val() === "" || $(direccion).val() === "" || $(telefono).val() === "" || $(salario).val() === "" ||
        $(departamento).val() === "Departameto*" || $(rol).val() === "Rol*" || $(fecha).val() === "" || $(sexo).val() === "Sexo*" || $(codigoEmpresa).val() === "") {
        return false
    } else {
        return true
    }
};

const test = () => {
    $.ajax({
        type: 'POST',
        url: "PendientesExterna.aspx/BuscarInformacionCombosPendientes",
        data: null,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var response = jQuery.parseJSON(data.d);
            console.log(response);
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            console.log(xmlHttpRequest.responseText);
        }
    })
};

function GuardarDatos() {
    if (ValidarCompaos() === false) {
        alert("¡Por favor Diligenciar todo los campos!");
    } else {
        GuardarEmpleado();
    }  
};

function CrearJson() {
    var data = {
        "nombre": $(nombre).val(),
        "apellido": $(apellido).val(),
        "direccion": $(direccion).val(),
        "telefono": $(telefono).val(),
        "salario": $(salario).val(),
        "departamento": $(departamento).val(),
        "rol": $(rol).val(),
        "fecha": $(fecha).val(),
        "sexo": $(sexo).val(),
        "codigoempresa": $(codigoEmpresa).val()
    }
    return data
};

function GuardarEmpleado() {
    var Parametros = {};
    Parametros.sTexto = CrearJson();
    Parametros.Consulta = "BuscarAreas";
    var Data = JSON.stringify(Parametros)
    $.ajax({
        type: "POST",
        url: "PendientesExterna.aspx/BuscarInformacionCombosPendientes",
        data: JSON.stringify({ sDatosJson: Data }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var sResultado = jQuery.parseJSON(data.d);
            if (sResultado.TipoMensaje != 'Error' && sResultado.TipoMensaje != 'NA') {
                json_Data.success(sResultado.Datos);
            } else if (sResultado.TipoMensaje === 'NA') {
                json_Data.success([]);
            } else {
                alert(sResultado.Mensaje);
            }
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            alert(xmlHttpRequest.responseText);
        }
    })
};

const post = ({ typeHTTP, method, data }) => {
    const request = new XMLHttpRequest();

    if (!request) {
        console.log(new Error('el navegador no soporta XmlHttpRequest'));
        return;
    }

    request.open('POST', `${window.location.href}/RegistrarEmpleado`, true);
    //request.open('POST', 'Default.aspx', true);

    request.onreadystatechange = function () {
        if (request.readyState === XMLHttpRequest.DONE) {
            if (request.status === 200) {
                const response = JSON.parse(request.responseText).d;
                console.log(response);
            }
            else {
                console.log('problemas con la peticion');
            }
        } 
    };

    request.setRequestHeader('Cache-Control', 'no-cache');
    request.setRequestHeader('Content-Type', 'application/json; charset=UTF-8');

    request.send();
};