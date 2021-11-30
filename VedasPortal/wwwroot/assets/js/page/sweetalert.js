window.sweetAlert = function () {

    "use strict";

    $("#swal-1").click(function () {
        swal('Merhaba');
    });

    $("#swal-2").click(function () {
        swal('Merhaba', 'işlemleriniz başarıyla  kaydedildi!', 'success');
    });

    $("#swal-3").click(function () {
        swal('Merhaba', 'Lütfen bilgileriniz kontrol edin!', 'warning');
    });

    $("#swal-4").click(function () {
        swal('Merhaba', 'Burası Bilgi mesajı alanıdır', 'info');
    });

    $("#swal-5").click(function () {
        swal('Merhaba', 'Merhaba bilgilerinizi hatalı girdiniz Lütfen tekrar deneyiniz.!', 'error');
    });

    $("#swal-6").click(function () {
        swal({
            title: 'Emin misiniz?',
            text: 'Bir kez silindiğinde bu dosyayı kaybedeceksiniz. ',
            icon: 'warning',
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    swal('Dosya silme işlemi başarılı ', {
                        icon: 'success',
                    });
                } else {
                    swal(' Dosyanız Güvende ');
                }
            });
    });

    $("#swal-7").click(function () {
        swal({
            title: 'Adınız Soyadınız',
            content: {
                element: 'input',
                attributes: {
                    placeholder: 'Adınız ve Soyadınızı Yazınız...',
                    type: 'text',
                },
            },
        }).then((data) => {
            swal('Merhaba , ' + data + '!');
        });
    });

    $("#swal-8").click(function () {
        swal('This modal will disappear soon!', {
            buttons: false,
            timer: 3000,
        });
    });
}