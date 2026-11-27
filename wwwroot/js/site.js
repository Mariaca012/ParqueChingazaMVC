
document.addEventListener("DOMContentLoaded", function () {

    const boton = document.getElementById("btn-agregar");
    const entrada = document.getElementById("nueva-actividad");
    const lista = document.getElementById("lista-actividades");

    if (boton && entrada && lista) {

        boton.addEventListener("click", function () {

            const actividad = entrada.value.trim();

            if (actividad === "") {
                alert("Escribe una actividad.");
                return;
            }

            const elemento = document.createElement("li");

            elemento.className = "list-group-item";
            elemento.textContent = actividad;

            lista.appendChild(elemento);

            entrada.value = "";
        });
    }

    const cantidad = document.getElementById("cantidadPersonas");
    const total = document.getElementById("totalReserva");

    if (cantidad && total) {

        function calcularTotal() {

            const personas = Number(cantidad.value);

            const precio = personas > 0
                ? personas * 15000
                : 0;

            total.textContent =
                "$" + precio.toLocaleString("es-CO") + " COP";
        }

        cantidad.addEventListener("input", calcularTotal);

        calcularTotal();
    }

});