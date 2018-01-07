var grid = $("#grid").kendoGrid({
    dataSource: {
        transport: {
            read: {
                url: "Profesional/JsonData",
                data: {
                    format: "json"
                },
                dataType: "json", // "jsonp" is required for cross-domain requests; use "json" for same-domain requests                
            }
        },
        schema: {
            //data: "items",
            model: {
                fields: {
                    fechaCreacion: { type: "date" }
                }
            }
        }
    },
    columns: [
      { field: "nombres", title: "Nombres" },
      { field: "telefonos", title: "Telefonos" },
      { field: "email", title: "Email" },
      { field: "estado", title: "Estado" },
      { field: "profesionalTipo", title: "Profesional Tipo", template: "#= GetProfesionalTipo(profesionalTipo) #" },
      { field: "profesionalId", title: " ", template: "#= Comandos(profesionalId) #" }
    ],
    height: 500,
    scrollable: true,
    selectable: true
});

var template = "";
var templateComandos = "";

function Comandos(id) {
    templateComandos = "<ul class='list-unstyled list-inline'><li><a href='/Profesional/Edit/" + id + "'><span class='glyphicon glyphicon-pencil'></span></a></li>";
    templateComandos += "<li><a href='/Profesional/Details/" + id + "'><span class='glyphicon glyphicon-search'></span></a></li>";
    templateComandos += "<li><a href='/Profesional/Delete/" + id + "'><span class='glyphicon glyphicon-trash'></span></a></li>";
    templateComandos += "</ul>";
    return templateComandos;
}

function GetProfesionalTipo(tipo) {
    template = tipo.descripcion;

    return template;
}