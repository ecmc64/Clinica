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
      { field: "nombre", title: "Nombre" },
      { field: "categorias", title: "Categorías", template: "#= Simple(categorias) #" },
      { field: "fechaCreacion", title: "Fecha de Creación" },
      { field: "imagen", title: "Imagen", template: "#= MostrarImagen(imagen) #" },
      { field: "id", title: "", template: "#= Comandos(id) #" }
    ],
    height: 500,
    scrollable: true,
    selectable: true
});