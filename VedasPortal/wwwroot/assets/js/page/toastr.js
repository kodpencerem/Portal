window.toastrVedas = function(){


    "use strict";

    $("#toastr-1").click(function () {
        iziToast.info({
            title: 'Bilgi!',
            message: 'Bu alanda i�lem yapmak i�in yetkiliniz ile g�r���n.',
            position: 'topRight'
        });
    });

    $("#toastr-2").click(function () {
        iziToast.success({
            title: 'Tamamland�',
            message: '��leminiz ba�ar�l� bir �ekilde tamamland�.',
            position: 'topRight'
        });
    });

    $("#toastr-3").click(function () {
        iziToast.warning({
            title: 'Uyar�!',
            message: 'Bu alana girme yetkiniz yoktur!',
            position: 'topRight'
        });
    });

    $("#toastr-4").click(function () {
        iziToast.error({
            title: 'Hata!',
            message: '��lem s�ras�nda bir hata ile kar��la��ld�!',
            position: 'topRight'
        });
    });

    $("#toastr-5").click(function () {
        iziToast.show({
            title: 'Bilgi!',
            message: 'Bu alanda i�lem yapmak i�in yetkiliniz ile g�r���n.',
            position: 'bottomRight'
        });
    });

    $("#toastr-6").click(function () {
        iziToast.show({
            title: 'Tamamland�',
            message: '��leminiz ba�ar�l� bir �ekilde tamamland�.',
            position: 'bottomCenter'
        });
    });

    $("#toastr-7").click(function () {
        iziToast.show({
            title: 'Uyar�!',
            message: 'Bu alana girme yetkiniz yoktur!',
            position: 'bottomLeft'
        });
    });

    $("#toastr-8").click(function () {
        iziToast.show({
            title: 'Hata!',
            message: '��lem s�ras�nda bir hata ile kar��la��ld�!',
            position: 'topCenter'
        });
    });

}