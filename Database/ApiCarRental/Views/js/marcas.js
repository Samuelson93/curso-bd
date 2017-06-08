$(document).ready(function () {

    function GetMarcas() {
        var urlAPI = 'http://localhost:52673/api/marcas';

        $.get(urlAPI, function (respuesta, estado) {

            console.log(respuesta);
            $('#resultados').html('');
            // COMPRUEBO EL ESTADO DE LA LLAMADA
            if (estado === 'success') {
                // SI LLEGO HASTA AQUÍ QUIERE DECIR

                var relleno = '';

                $.each(respuesta.dataMarcas, function (indice, elemento) {

                    relleno = '<ul>';
                    relleno += '    <li>';
                    relleno += elemento.denominacion;
                    relleno += '    </li>';
                    relleno += '</ul>';

                    $('#resultados').append(relleno);
                });
            }
        });
    }

    $('#btnAddMarca').click(function () {
        //debugger;
        var nuevaMarca = $('#txtMarcaDenominacion').val();
        var urlAPI = 'http://localhost:52673/api/marcas';

        var dataNuevaMarca = {
            id: 0,
            denominacion: nuevaMarca
        };
        //debugger;

        $.ajax({
            url: urlAPI,
            type: "POST",
            dataType: 'json',
            data: dataNuevaMarca,
            success: function (respuesta) {
                //debugger;
                console.log(respuesta);
            },
            error: function (respuesta) {
                console.log(respuesta);
            }
        });
    });

    GetMarcas();

});