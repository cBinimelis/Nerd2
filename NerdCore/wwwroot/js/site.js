$(window).on('load', function () {
    Contar()
});

function Contar() {
    $('.count').each(function () {
        $(this).prop('Counter', 0).animate({
            Counter: $(this).text()
        }, {
            duration: 3000,
            easing: 'swing',
            step: function (now) {
                $(this).text(Math.ceil(now));
            }
        });
    });
}

$(".txtb input").on("focus", function () {
    $(this).addClass("focus");
});

$(".txtb input").on("blur", function () {
    if ($(this).val() == "")
        $(this).removeClass("focus");
});

//Exito al agregar un nuevo Anime a la lista del usuario
function AUAdded(){
    Swal.fire(
        '¡Felicidades!',
        'Más vicio para tu vida',
        'success'
    )
};

//error al agregar un nuevo Anime a la lista del usuario
function AUFailed() {
    Swal.fire(
        'Oh oh...',
        'Algo no salió bien',
        'error'
    )
};