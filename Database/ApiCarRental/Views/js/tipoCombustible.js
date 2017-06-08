$(document).ready(function () {

    function GetTipoCombustible() {
        var urlAPI = 'http://localhost:52673/api/TiposCombustibles';

        $.get(urlAPI, function (respuesta, estado) {

            console.log(respuesta);
            $('#combustibles').html('');
            // COMPRUEBO EL ESTADO DE LA LLAMADA
            if (estado === 'success') {
                // SI LLEGO HASTA AQUÍ QUIERE DECIR

                var relleno = '';

                $.each(respuesta.dataTiposCombustible, function (indice, elemento) {

                    relleno = '<ul>';
                    relleno += '    <li>';
                    relleno += elemento.denominacion;
                    relleno += '    </li>';
                    relleno += '</ul>';

                    $('#combustibles').append(relleno);
                });
            }
        });
    }

    $('#btnAddTipoCombustible').click(function () {
        //debugger;
        var nuevoTipoCombustible = $('#txtTipoCombustibleDenominacion').val();
        var urlAPI = 'http://localhost:52673/api/TiposCombustibles';
        

        var dataNuevoTipoCombustible = {
            id: 0,
            denominacion: nuevoTipoCombustible
        };
        //debugger;

            $.ajax({
                url: urlAPI,
                type: "POST",
                dataType: 'json',
                data: dataNuevoTipoCombustible,
                success: function (respuesta) {
                    //debugger;
                    console.log(respuesta);
                    GetTipoCombustible();
                },
                error: function (respuesta) {
                    console.log(respuesta);
                }
            });
        });

        GetTipoCombustible();

    });
