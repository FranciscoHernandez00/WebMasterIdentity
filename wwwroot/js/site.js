const selectElement = document.querySelector('#Productos');
const selectTienda = document.querySelector('#Tiendas');


selectElement.addEventListener('change', (event) => {
    var Ids = selectElement.value;

    $.ajax({
        url: "/Administracion/GetShopList",
        type: "POST",
        data: "Id=" + Ids,
        dataType: "json",
        success: function (PrecioBase) {
            var datap = PrecioBase;
            var preciodata = datap.precio
            var nombredata = datap.nombreProducto;
            var precioInput = document.getElementById('PrecioMul');
            var nombreInput = document.getElementById('ProductoNombre');
            var precios = preciodata;
            var nombres = nombredata
            nombreInput.value = nombres;
            precioInput.value = precios;
            //console.log(precios);
        }
    })
});

$("#Cantidad").on("input", function () {
    var precio = document.getElementById('PrecioMul').value;
    var cantidad = document.getElementById('Cantidad').value;
    var multiplicacion = +precio * +cantidad;
    var totalinput = document.getElementById('Total');
    totalinput.value = multiplicacion;
    console.log(multiplicacion);
});

function NuevaColumna() {
    //Desactivar dropdown

    //Captar datos
    var tiendaSelect = selectTienda.value;
    var precio = document.getElementById('PrecioMul').value;
    var cantidad = document.getElementById('Cantidad').value;
    var total = document.getElementById('Total').value;
    var producto = document.getElementById('Productos').value;
    var nombre = document.getElementById('ProductoNombre').value;

    if (total == 0) {

        alert("Por favor complete los campos solicitados.");
    }
    else {

        //Añadir datos a la tabla
        var table = document.getElementById('ProductosTabla').insertRow();
        table.innerHTML = "<tr class='row' id='ListaProductos'>" +
            "<td>" + "<input type='number' name='rowproducto' value=" + producto + "  hidden />" + producto + "</td>" +
            "<td>" + nombre + "</td>" +
            "<td>" + precio + "</td>" +
            "<td>" + "<input type='number' name='rowcantidad' value=" + cantidad + "  hidden />" + cantidad + "</td>" +
            "<td hidden>" + "<input type='number' name='rowtienda' value=" + tiendaSelect + "  hidden />" + tiendaSelect + "</td>" +
            "<td>" + "<input type='number' name='rowtotal' value=" + total + " hidden />" + total + "</td>" +
            "<td>" + "<button type='button' class='btn btn-danger' onclick='deleteRow(this)'> <i class='fas fa-trash-alt'></i></button>" + "</td>" +
            "</tr>";

        $('input[name=Cantidad').val(0);
        $('input[name=Total').val(0);
        $('input[name=PrecioMul').val(0);
        $("#Productos option:eq(0)").prop("selected", true);

        console.log("Añadido con exito.");
    }
};

function deleteRow(r) {
    alert("Producto de la lista eliminado.");
    var i = r.parentNode.parentNode.rowIndex;
    document.getElementById("ProductosTabla").deleteRow(i);
};

function GuardarVenta() {

    //Trayendo los datos necesarios
    $("#ProductosTabla tr").find("td:eq(0)").each(function () {
        var row = $(this).parents("tr");
        var producto = row.find("input[name=rowproducto]").val();
        var tienda = row.find("input[name=rowtienda]").val();
        var cantidad = row.find("input[name=rowcantidad]").val();
        var total = row.find("input[name=rowtotal]").val();

        $.ajax({
            url: "/Administracion/GuardarVenta",
            type: "POST",
            data: { "producto": producto, "tienda": tienda, "cantidad": cantidad, "total": total },
            success: function () {
                alert("Producto añadido");
                location.reload();
            }
        });

    })

};

