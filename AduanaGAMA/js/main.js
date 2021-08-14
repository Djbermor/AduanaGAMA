////$(document).ready(function () {


////});

function ValidarCompaos() {
    if ($(nombre).val() === "" || $(apellido).val() === "" || $(direccion).val() === "" || $('#telefono').val() === "" || $(salario).val() === "" ||
        $(departamento).val() === 0 || $(rol).val() === 0 || $('#fecha').val() === "" || $('#sexo').val() === 0 || $('#codigoCompania').val() === "") {
        return false
    } else {
        return true
    }
};

function GuardarDatos() {
    if (ValidarCompaos() === false) {
        alert("¡Por favor Diligenciar todo los campos!");
    } else {
        GuardarEmpleado();
    }  
};

function CrearJson() {
    return {
        "Nombre": $('#nombre').val(),
        "Apellido": $('#apellido').val(),
        "Direccion": $('#direccion').val(),
        "Telefono": $('#telefono').val(),
        "Salario": $('#salario').val(),
        "Departamento": $('#departamento').val() || '',
        "Rol": $('#rol').val() || '',
        "Fecha": $('#fecha').val(),
        "Sexo": $('#sexo').val() || '',
        "CodigoEmpresa": $('#codigoCompania').val()
    };
};

function GuardarEmpleado() {
    var Parametros = {};
    Parametros.sTexto = CrearJson();
    //Parametros.Consulta = "";
    //var Data = JSON.stringify(Parametros)

    let response = post({ typeHTTP: 'POST', method: 'Registrar', data: CrearJson() });

    //$.ajax({
    //    type: "POST",
    //    url: "PendientesExterna.aspx/BuscarInformacionCombosPendientes",
    //    data: JSON.stringify({ sDatosJson: Parametros }),
    //    contentType: "application/json; charset=utf-8",
    //    dataType: "json",
    //    success: function (data) {
    //        var sResultado = jQuery.parseJSON(data.d);
    //        if (sResultado.TipoMensaje != 'Error' && sResultado.TipoMensaje != 'NA') {
    //            json_Data.success(sResultado.Datos);
    //        } else if (sResultado.TipoMensaje === 'NA') {
    //            json_Data.success([]);
    //        } else {
    //            alert(sResultado.Mensaje);
    //        }
    //    },
    //    error: function (xmlHttpRequest, textStatus, errorThrown) {
    //        alert(xmlHttpRequest.responseText);
    //    }
    //})
};

const post = ({ typeHTTP, method, data }) => {
    const request = new XMLHttpRequest();
    let respuesta = '';

    if (!request) {
        console.log(new Error('el navegador no soporta XmlHttpRequest'));
        return;
    }

    request.open(typeHTTP, `${window.location.href}/${method}`, true);
    //request.open('POST', 'Default.aspx', true);

    request.onreadystatechange = function () {
        if (request.readyState === XMLHttpRequest.DONE) {
            if (request.status === 200) {
                const response = JSON.parse(request.responseText).d;
                console.log(response);

                respuesta = response;
            }
            else {
                console.log('problemas con la peticion');
            }
        } 
    };

    request.setRequestHeader('Cache-Control', 'no-cache');
    request.setRequestHeader('Content-Type', 'application/json; charset=UTF-8');

    data = {
        'empleado': data
    };

    //envia la peticion
    request.send(JSON.stringify(data));

    return respuesta;
};