////$(document).ready(function () {


////});

let vista = 0;
function ValidarCompos() {
    if ($(nombre).val() === "" || $(apellido).val() === "" || $(direccion).val() === "" || $('#telefono').val() === "" || $(salario).val() === "" ||
        $(departamento).val() === 0 || $(rol).val() === 0 || $('#fecha').val() === "" || $('#sexo').val() === 0 || $('#codigoCompania').val() === "") {
        return false
    } else {
        return true
    }
};

function ValidarComposDepartamento() {
    if ($(departa).val() === "") {
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
function GuardarDatosDepartamento() {
    if (!ValidarComposDepartamento()) {
        alert("¡Por favor Diligenciar todo los campos!");
    } else {
        GuardarDepartamento();
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

function CrearJsonDepartamento() {
    return {
        "departamento1": $('#departa').val()
    };
};

function GuardarDepartamento() {
    const id = new URLSearchParams(window.location.search).get('id');
    let data = CrearJsonDepartamento();
    
    data = {
        'departamento': data
    };

    if (typeof id !== undefined && id !== '') {
        data.id = id;
        post({ typeHTTP: 'POST', method: 'RegistrarDeparta', data: data });
    } else {
        post({ typeHTTP: 'POST', method: 'RegistrarDeparta', data: data });
    }
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

function EliminarDepartamento(id) {
    post({ typeHTTP: 'POST', method: 'Eliminar', data: { 'id': id } });
}

function eliminarEmpleado(id) {
    post({ typeHTTP: 'POST', method: 'Eliminar', data: { 'id': id } });

}

//function arrow
const post = ({ typeHTTP, method, data }) => {
    const request = new XMLHttpRequest();

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

                    mensajes(response);
                    console.log(response);
                } catch (ex) {
                    console.log(ex);
                    console.log(responseText);
                    mensajes(response);
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
};

function mensajes(response) {

    const redirect = () => window.location.href = 'Default.aspx';
    const redirectDepar = () => window.location.href = 'GrillaDepartamento.aspx';

    switch (response) {
        case 'ok':
            swal('Acción realizada correctamente ', '', "success").then(() => redirect()).catch(() => redirect());
            break;
        case 'okDepar':
            swal('Acción realizada correctamente ', '', "success").then(() => redirectDepar()).catch(() => redirectDepar());
            break;
        default:
            swal('Oops', 'Hubo problemas con su petición. por favor intente más tarde.').then(() => redirect()).catch(() => redirect());
            break;
    }
}