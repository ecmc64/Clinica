Array.prototype.remove = function (x) {
    //    for (i in this) {
    //        if (this[i].toString() == x.toString()) {
    //            this.splice(i, 1)
    //        }
    //    }
    this.splice($.inArray(x, this), 1);
};

String.prototype.trim = function () {
    return this.replace(/^\s+|\s+$/g, '');
};

String.prototype.safe = function () {
    var s = this.replace(/"/ig, "\\\"");
    s = s.replace(/'/ig, "’");
    return s;
};

var ConstGenericas =
{
    RespuestaCorrecto: 1,
    RespuestaErrorGen: 2,
    CodeError: "#Error#",
    Usuario: "A61E3FFA-E5B4-4C0E-8787-FBAEA4B75CBF",
    Eliminado: 1,
    NoEliminado: 0,
    EstadoInicialProfesional: 1,
    EProfesional: 1,
    ETecnico: 2,
    OrdenAsc: 1,
    OrdenDesc: 2,
    ProcesoAcredPostulante: 1,
    ProcesoAcredSeleccionado: 2,
    ProcesoAcredDocumentosRemitidos: 3,
    ProcesoAcredMatriculado: 4,
    ProcesoAcredAprobado: 5
};

var Helper =
{
    LlenarCombo: function (comboID, aData, value, texto, valorSeleccionado,
            tieneValorPredeterminado, valorPredeterminadoValue, valorPredeterminadoTexto) {

        var html = "";
        var valorPredeterminadoValue = valorPredeterminadoValue == null || valorPredeterminadoValue === "undefined" ? "0" : valorPredeterminadoValue;
        var valorPredeterminadoTexto = valorPredeterminadoTexto == null || valorPredeterminadoTexto === "undefined" ? "- Selecione - " : valorPredeterminadoTexto;

        if (tieneValorPredeterminado != false) {
            html = "<option value=\"" + valorPredeterminadoValue + "\">" + valorPredeterminadoTexto + "</option>";
        }

        for (var i = 0; i < aData.length; i++) {
            html += "<option value=\"";
            if (aData[i][value] == valorSeleccionado)
                html += aData[i][value] + "\" selected>";
            else
                html += aData[i][value] + "\">";

            html += aData[i][texto] + "</option>";
        }

        $("#" + comboID).empty().append(html);
    },

    BaseURL: function () {
        return location.protocol + "//" + location.hostname +
        (location.port && ":" + location.port) + "/" + location.pathname.split('/')[1];
    },

    CurrentURL: function () {
        var loc = window.location.href;
        loc = loc.split('?')[0];

        return loc;
    },

    ValidaDatos: function (form, msgError, rules) {
        var resultValidate = false;
        var validator = null;

        if (rules === undefined || rules == null) {
            validator = $("#" + form).kendoValidator(
                {
                    validateOnBlur: true,
                    hideMessages: true
                }).data("kendoValidator");
        }
        else {
            validator = $("#" + form).kendoValidator(
                {
                    validateOnBlur: true,
                    hideMessages: true,
                    rules: rules
                }).data("kendoValidator");
        }

        resultValidate = validator.validate()

        if (!resultValidate && msgError != null && msgError !== undefined) {
            Helper.MostrarMensaje(msgError, false);
        }

        return resultValidate;
    },

    MostrarMensaje: function (mensaje, isOK) {
        if (isOK) {
            $("#windowMessage").removeClass("windowMessageError windowMessageOK").addClass("windowMessageOK");
        }
        else {
            $("#windowMessage").removeClass("windowMessageError windowMessageOK").addClass("windowMessageError");
        }

        $("#windowMessage").html(mensaje);
        $("#windowMessage").show();
        window.setTimeout(function () {
            Helper.OcultarMensaje();
        }, 4000);
    },

    OcultarMensaje: function () {
        $("#windowMessage").html("");
        $("#windowMessage").hide();
    },

    LlenarComboDpto: function (comboID) {
        $.ajax(
        { type: "POST",
            url: Helper.BaseURL() + "/WebService/Servicio.asmx/ObtenerListaUbigeoByID",
            data: "{ubigeoID:'%%0000'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var aData = JSON.parse(data.d);
                Helper.LlenarCombo(comboID, aData, "UbigeoID", "Nombre", null, true, null, "- Seleccione Departamento -");
                //var html = "<option id=\"0\">Seleccione Departamento</option>";                

            }
        });
    },
    LlenarComboProv: function (comboID, parentID, valorSeleccionado) {
        $.ajax(
        { type: "POST",
            url: Helper.BaseURL() + "/WebService/Servicio.asmx/ObtenerListaUbigeoByID",
            data: "{ubigeoID:'" + parentID.substring(0, 2) + "%%00'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var aData = JSON.parse(data.d);
                Helper.LlenarCombo(comboID, aData, "UbigeoID", "Nombre", valorSeleccionado, true, null, "- Seleccione Provincia -");
            }
        });
    },
    LlenarComboDist: function (comboID, parentID, valorSeleccionado) {
        $.ajax(
        { type: "POST",
            url: Helper.BaseURL() + "/WebService/Servicio.asmx/ObtenerListaUbigeoByID",
            data: "{ubigeoID:'" + parentID.substring(0, 4) + "%%'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var aData = JSON.parse(data.d);
                Helper.LlenarCombo(comboID, aData, "UbigeoID", "Nombre", valorSeleccionado, true, null, "- Seleccione Distrito -");
            }
        });
    },

    FormatoFecha: "dd/MM/yyyy",

    FormatoControlFecha: "{0:dd/MM/yyyy}",

    FormatoControlFechaMA: "{0:MM/yyyy}",

    FormatearFechaISO: function (fecha) {
        return kendo.parseDate(fecha, "dd/MM/yyyy");
    },

    FormatearFechaMAISO: function (fecha) {
        fecha = "01/" + fecha;
        return kendo.parseDate(fecha, "dd/MM/yyyy");
    },

    FormatearFechaJSON: function (fechaJSON) {
        if (fechaJSON != null && fechaJSON != '')
            return new Date(parseInt(fechaJSON.substring(6)));
        else
            return null;
    },

    MostrarFecha: function (fecha, formato) {
        if (fecha != null && fecha != '') {
            if (formato === undefined || formato == null) {
                return kendo.toString(fecha, Helper.FormatoFecha);
            }
            else {
                return kendo.toString(fecha, formato);
            }
        }
        else {
            return "";
        }
    },

    MostrarFechaJSON: function (fechaJSON) {
        if (fechaJSON != null && fechaJSON != '')
            return Helper.MostrarFecha(Helper.FormatearFechaJSON(fechaJSON));
        else
            return "";

    },

    QueryString: function () {
        // This function is anonymous, is executed immediately and 
        // the return value is assigned to QueryString!
        var query_string = {};
        var query = window.location.search.substring(1);
        var vars = query.split("&");
        for (var i = 0; i < vars.length; i++) {
            var pair = vars[i].split("=");
            // If first entry with this name
            if (typeof query_string[pair[0]] === "undefined") {
                query_string[pair[0]] = pair[1];
                // If second entry with this name
            } else if (typeof query_string[pair[0]] === "string") {
                var arr = [query_string[pair[0]], pair[1]];
                query_string[pair[0]] = arr;
                // If third or later entry with this name
            } else {
                query_string[pair[0]].push(pair[1]);
            }
        }
        return query_string;
    },

    AutogenerarID: function (aDatos, campo) {
        var aIDs = new Array();
        var autogenerado = 1;

        if (aDatos !== undefined && aDatos != null && aDatos.length > 0) {
            $.each(aDatos, function (i, o) {
                aIDs.push(o[campo]);
            });

            autogenerado = Math.max.apply(Math, aIDs) + 1;
        }


        return autogenerado;
    },

    BuscarRegistro: function (aDatos, campo, valorABuscar) {
        var dato = null;

        if (aDatos !== undefined && aDatos != null) {
            $.each(aDatos, function (i, o) {
                if (o[campo] == valorABuscar) {
                    dato = o;
                    return;
                }
            });
        }
        return dato;
    },

    LlenarGrid: function (gridID, aDatos, campoFiltro, valorFiltro) {
        var grid = $("#" + gridID).data("kendoGrid");
        var aDatosFiltrado = aDatos;
        if (campoFiltro !== undefined && campoFiltro != null) {
            aDatosFiltrado = new Array();
            $.each(aDatos, function (i, o) {
                if (o[campoFiltro] == valorFiltro) {
                    aDatosFiltrado.push(o);
                }
            });

        }

        grid.dataSource.data(aDatosFiltrado);
        grid.refresh();
    },

    ObtenerOrden: function (tipoOrden) {
        if (tipoOrden == "asc")
            return ConstGenericas.OrdenAsc;
        else
            return ConstGenericas.OrdenDesc;
    },

    OpenWindow: function (param, nameWindow) {
        /*
        param:
        width: width of page
        height: height of page
        title: title of the page
        url: url of page to show
        modal: show the page in mode modal or no
        onClose: event when the window is closed,
        center: the window is center or no
        */

        if (nameWindow === undefined || nameWindow == null) {
            nameWindow = "divPopupTemplate";
        }

        var wPopup;

        if ($("#" + nameWindow).length == 0) {
            $("body").append("<div id='" + nameWindow + "' style='overflow: hidden;' ></div>");
        }

        wPopup = $("#" + nameWindow); //.clone(true);

        if (param === undefined || param == null) param = {};
        if (param.width === undefined || param.width == null) param.width = 600;
        if (param.height === undefined || param.height == null) param.height = 600;
        if (param.title === undefined || param.title == null) param.title = "";
        if (param.url === undefined || param.url == null) param.url = "";
        if (param.modal === undefined || param.modal == null) param.modal = true;
        if (param.onClose === undefined || param.onClose == null) param.onClose = null;
        if (param.center === undefined || param.center == null) param.center = true;

        wPopup.kendoWindow({
            iframe: true,
            width: param.width,
            height: param.height,
            title: param.title,
            content: param.url,
            modal: param.modal,
            visible: false,
            resizable: false,

            close: function () {
                wPopup.data("kendoWindow").destroy();
                if (param.onClose != null)
                    param.onClose();
            },
            animation: {
                open: {
                    effects: { fadeIn: {} },
                    duration: 1,
                    show: true
                },
                close: {
                    effects: { fadeOut: {} },
                    duration: 1,
                    hide: true
                }
            }
        });

        if (param.center) {
            wPopup.data("kendoWindow").open();
            wPopup.data("kendoWindow").center();
        }
        else {
            wPopup.data("kendoWindow").open();
        }


        return false;
    },

    CloseWindow: function (parametros, nameWindow) {
        if (nameWindow === undefined || nameWindow == null) {
            nameWindow = "divPopupTemplate";
        }

        if (parametros === undefined) {
            window.parent.$("#" + nameWindow).data("kendoWindow").close();
        }
        else {
            window.parent.$("#" + nameWindow).data("kendoWindow").close(parametros);
        }
    },

    HtmlEncode: function (value) {
        var result = "";
        result = $('<div />').text(value).html();
        result = result.replace(/"/ig, "&quot;");
        result = result.replace(/'/ig, "&quot;");

        return result;
    },

    HtmlDecode: function (value) {
        var result = "";
        result = $('<div />').html(value).text();
        result = result.replace(/&quot;/ig, '"');

        return result;
    },

    PreventBackspace: function (e) {
        var evt = e || window.event;
        if (evt) {
            var keyCode = evt.charCode || evt.keyCode;
            if (keyCode === 8) {
                if (evt.preventDefault) {
                    evt.preventDefault();
                } else {
                    evt.returnValue = false;
                }
            }
        }
    },

    ConvertNull: function (value) {
        if (value == null || value == 'null')
            value = ''

        return value;
    }



};