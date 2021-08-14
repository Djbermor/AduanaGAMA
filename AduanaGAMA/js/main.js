﻿////$(document).ready(function () {


////});

function ValidarCompos() {
    if ($(nombre).val() === "" || $(apellido).val() === "" || $(direccion).val() === "" || $('#telefono').val() === "" || $(salario).val() === "" ||
        $(departamento).val() === 0 || $(rol).val() === 0 || $('#fecha').val() === "" || $('#sexo').val() === 0 || $('#codigoCompania').val() === "") {
        return false
    } else {
        return true
    }
};

function GuardarDatos() {
    if (!ValidarCompos()) {
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
        "Fecha": $('#fecha').val() || '',
        "Sexo": $('#sexo').val() || '',
        "CodigoEmpresa": $('#codigoCompania').val() || ''
    };
};

function GuardarEmpleado() {
    const id = new URLSearchParams(window.location.search).get('id');
    let data = CrearJson();

    data = {
        'empleado': data
    };

    if (typeof id !== undefined && id !== '') {
        data.id = id;
        post({ typeHTTP: 'POST', method: 'Registrar', data: data});
    } else {
        post({ typeHTTP: 'POST', method: 'Registrar', data: data});
    }
};

function eliminarEmpleado(id) {
    post({ typeHTTP: 'POST', method: 'Eliminar', data: { 'id': id } });

    console.log();
}

//function arrow
const post = ({ typeHTTP, method, data }) => {
    const request = new XMLHttpRequest();
    let respuesta = '';

    if (!request) {
        console.log(new Error('el navegador no soporta XmlHttpRequest'));
        return;
    }

    let pathname = window.location.pathname === '/' ? 'Default.aspx' : window.location.pathname;

    request.open(typeHTTP, `${pathname}/${method}`, true);
    //request.open('POST', 'Default.aspx', true);

    request.onreadystatechange = function () {
        if (request.readyState === XMLHttpRequest.DONE) {
            if (request.status === 200) {
                let responseText = request.responseText;
                try {
                    let response = JSON.parse(responseText).d;
                    console.log(response);

                    respuesta = response;
                } catch (ex) {
                    console.log(ex);
                    console.log(responseText);
                }
            }
            else {
                console.log('problemas con la peticion');
            }
        } 
    };

    request.setRequestHeader('Cache-Control', 'no-cache');
    request.setRequestHeader('Content-Type', 'application/json; charset=UTF-8');

    //envia la peticion
    request.send(JSON.stringify(data));

    return respuesta;
};