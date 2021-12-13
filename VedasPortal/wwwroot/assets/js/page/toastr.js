window.toastrVedas = function(){


    "use strict";

    $("#toastr-1").click(function () {
        iziToast.info({
            title: 'Bilgi!',
            message: 'Bu alanda iþlem yapmak için yetkiliniz ile görüþün.',
            position: 'topRight'
        });
    });

    $("#toastr-2").click(function () {
        iziToast.success({
            title: 'Tamamlandý',
            message: 'Ýþleminiz baþarýlý bir þekilde tamamlandý.',
            position: 'topRight'
        });
    });

    $("#toastr-3").click(function () {
        iziToast.warning({
            title: 'Uyarý!',
            message: 'Bu alana girme yetkiniz yoktur!',
            position: 'topRight'
        });
    });

    $("#toastr-4").click(function () {
        iziToast.error({
            title: 'Hata!',
            message: 'Ýþlem sýrasýnda bir hata ile karþýlaþýldý!',
            position: 'topRight'
        });
    });

    $("#toastr-5").click(function () {
        iziToast.show({
            title: 'Bilgi!',
            message: 'Bu alanda iþlem yapmak için yetkiliniz ile görüþün.',
            position: 'bottomRight'
        });
    });

    $("#toastr-6").click(function () {
        iziToast.show({
            title: 'Tamamlandý',
            message: 'Ýþleminiz baþarýlý bir þekilde tamamlandý.',
            position: 'bottomCenter'
        });
    });

    $("#toastr-7").click(function () {
        iziToast.show({
            title: 'Uyarý!',
            message: 'Bu alana girme yetkiniz yoktur!',
            position: 'bottomLeft'
        });
    });

    $("#toastr-8").click(function () {
        iziToast.show({
            title: 'Hata!',
            message: 'Ýþlem sýrasýnda bir hata ile karþýlaþýldý!',
            position: 'topCenter'
        });
    });

}