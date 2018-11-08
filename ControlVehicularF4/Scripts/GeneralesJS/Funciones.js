
//Muestra mensaje modal bootstrap por ID modal, ID Div donde mostrara mensaje y texto de mensaje
function muestraMensaje(idModal, idDivMensaje, mensaje) {
    $("#" + idDivMensaje).html(mensaje);
    $('#' + idModal).modal('show');
}


//Recarga control tipo chosen
function reloadChosenItem0(idSelect) {
    $("#" + idSelect).chosen();
    $("#" + idSelect).append('<option selected="selected" value="-1">-Seleccione-</option>');
    $("#" + idSelect).trigger("chosen:updated");
}

function reloadChosen(idSelect) {
    $("#" + idSelect).chosen();
}


//Tabla HTML dinamic
function HeadTablaHTML(idTable, columnsName, divIdCreateIn) {
    var fLen, i;
    fLen = columnsName.length;
    textTable = '<table class="table" style="background-color:white;font-size:9px;" id="' + idTable + '" >' +
                    '<thead class="thead">' +
                    '<tr>';
    for (i = 0; i < fLen; i++) {
        textTable += "<th>" + columnsName[i] + "</th>";
    }
    textTable += '</tr>' +
                 '</thead>' +
                '</table>';
    $("#" + divIdCreateIn).html(textTable);
}



// Crea encabezado de tabla HTML
function createTableHtml(idTable, idDiv) {
    var table = '<table data-toggle="table" id="' + idTable + '" >' +
                    '<thead style="font-size:9px;">' +
                    '<tr>' +
                        '<th>Clasificación</th>' +
                        '<th>Atributo</th>' +
                        '<th>Puntaje</th>' +
                        '<th>Evaluación</th>' +
                        '<th>Critico</th>' +
                        '<th>Observaciones</th>' +
                        '<th>Evidencia</th>' +
                    '</tr>' +
                    '</thead>' +
                '</table>';
    $("#" + idDiv).html(table);
}

//Create RowsTable
function RowsTableHtml(idTable, jsonData, columnsName) {
    var tbl = $('#' + idTable);
    //Recorremos el Json (Datos)
    for (var i = 0; i < jsonData.length; i++) {
        var textRow;
        var row = $("<tr />");
        //Recorremos el aarray de columnas
        for (var ii = 0; ii < columnsName.length; ii++) {
            textRow = "<td>" + jsonData[i][columnsName[ii]] + "</td>";
            row.append($(textRow));
        }
        row.appendTo(tbl);
    }
}

//Activa DataTable para GridView Jquery
function aplicarDataTableJquery(idTabla) {
    if ($.fn.DataTable.isDataTable("#" + idTabla)) {
        $("#" + idTabla).dataTable();
    } else {
        var oTable = $("#" + idTabla).dataTable({
            keys: true,
            "sScrollY": 500,
            "sScrollX": "100%",
            "sScrollXInner": "100%",
            "lengthMenu": [[-1, 50], ["Todo", 50]],
            "language": {
                "lengthMenu": "<i class='glyphicon glyphicon-sort-by-attributes'></i> Mostrar _MENU_ Filas por página", // icono bootstrsp
                "zeroRecords": "Sin resultados para mostrar...",
                "info": "<i class='glyphicon glyphicon-list-alt'></i> Página _PAGE_ de _PAGES_",  //icono bootstrap
                "infoEmpty": "Sin registros disponibles",
                "infoFiltered": "(filtered from _MAX_ total records)",
                "search": "<strong>Buscar</strong> <i class='glyphicon glyphicon-search'></i>", // icono buscar
                "loadingRecords": "Cargando...",
                "processing": "Procesando...",
                "paginate": {
                    "first": "Primero",
                    "last": "Ultimo",
                    "next": "<i class='glyphicon glyphicon-chevron-right'></i>",  //Siguiente
                    "previous": "<i class='glyphicon glyphicon-chevron-left'></i>" //Anterior
                }
            }
        });
    }
}

//Activa DataTable Jquery con Alto Especifico
function aplicaDtTableAlto(idTabla, alto) {
    var Altura = alto;
    if ($.fn.DataTable.isDataTable("#" + idTabla)) {
        $("#" + idTabla).dataTable();
    } else {
        var oTable = $("#" + idTabla).dataTable({
            keys: true,
            "sScrollY": Altura,
            "sScrollX": "100%",
            "sScrollXInner": "100%",
            "lengthMenu": [[-1, 50], ["Todo", 50]],
            "language": {
                "lengthMenu": "<i class='glyphicon glyphicon-sort-by-attributes'></i> Mostrar _MENU_ Filas por página", // icono bootstrsp
                "zeroRecords": "Sin resultados para mostrar...",
                "info": "<i class='glyphicon glyphicon-list-alt'></i> Página _PAGE_ de _PAGES_",  //icono bootstrap
                "infoEmpty": "Sin registros disponibles",
                "infoFiltered": "(filtered from _MAX_ total records)",
                "search": "<strong>Buscar</strong> <i class='glyphicon glyphicon-search'></i>", // icono buscar
                "loadingRecords": "Cargando...",
                "processing": "Procesando...",
                "paginate": {
                    "first": "Primero",
                    "last": "Ultimo",
                    "next": "<i class='glyphicon glyphicon-chevron-right'></i>",  //Siguiente
                    "previous": "<i class='glyphicon glyphicon-chevron-left'></i>" //Anterior
                }
            }
        });
    }
}


function reloadTableGrouping(idTable) {
    if ($.fn.DataTable.isDataTable("#" + idTable)) {
        $("#" + idTable).dataTable();
    } else {
        $("#" + idTable).dataTable({
            paginate: false,
            info: false,
            "sScrollX": "100%",
            "sScrollXInner": "100%",
            "lengthMenu": [[-1, 50], ["Todo", 50]],
            "language": {
                "lengthMenu": "<i class='glyphicon glyphicon-sort-by-attributes'></i> Mostrar _MENU_ Filas por página", // icono bootstrsp
                "zeroRecords": "Sin resultados para mostrar...",
                "info": "<i class='glyphicon glyphicon-list-alt'></i> Página _PAGE_ de _PAGES_",  //icono bootstrap
                "infoEmpty": "Sin registros disponibles",
                "infoFiltered": "(filtered from _MAX_ total records)",
                "search": "<strong>Buscar</strong> <i class='glyphicon glyphicon-search'></i>", // icono buscar
                "loadingRecords": "Cargando...",
                "processing": "Procesando...",
                "paginate": {
                    "first": "Primero",
                    "last": "Ultimo",
                    "next": "<i class='glyphicon glyphicon-chevron-right'></i>",  //Siguiente
                    "previous": "<i class='glyphicon glyphicon-chevron-left'></i>" //Anterior
                }
            }
        }).rowGrouping({
            bExpandableGrouping: true,
            iGroupingColumnIndex: 0
        });
    }
}


// valida solo caracteres de tipo numero
function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}


function creaGridAgrupado(_mydata, _colNames, _ColModel, _gridID, _pagerID, _shortNameCol, _groupCols, _title, _groupsColShow) {
    $("#" + _gridID).jqGrid({
        data: _mydata,
        datatype: "local",
        height: null,
        width: null,
        shrinkToFit: false,
        rowNum: 100,
        rowList: [30, 50, 100],
        colNames: _colNames,
        colModel: _ColModel,
        pager: "#" + _pagerID,
        viewrecords: true,
        sortname: _shortNameCol,
        grouping: true,
        groupingView: {
            groupColumnShow: _groupsColShow
        },
        caption: _title
    });
    $("#" + _gridID).jqGrid('groupingGroupBy', _groupCols);

}

function setDateControl(idControl, startDate) {
    $('#' + idControl).datetimepicker({
        language: 'en',
        setStartDate: startDate,
        todayBtn: 1,
        autoclose: 1,
        todayHighlight: 1,
        startView: 2,
        minView: 2,
        forceParse: 0
    });
}


function sleep(milliseconds) {
    var start = new Date().getTime();
    for (var i = 0; i < 1e7; i++) {
        if ((new Date().getTime() - start) > milliseconds) {
            break;
        }
    }
}


