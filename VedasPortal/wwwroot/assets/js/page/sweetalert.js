window.sweetAlert = function () {
"use strict";

$("#swal-1").click(function () {
  swal('Merhaba');
});

$("#swal-2").click(function () {
  swal('Baþarýlý', 'Ýþleminiz Baþarýlý Bir Þekilde Gerçekleþti...', 'success');
});

$("#swal-3").click(function () {
  swal('Uyarý', 'Bu Alana Girmeye Yetkiniz Yok', 'warning');
});

$("#swal-4").click(function () {
  swal('Bilgi', 'Bu Ýþlem Ýçin Yöneticinize Baþvurunuz...', 'info');
});

$("#swal-5").click(function () {
  swal('Hata', 'Ýþleminiz Gerçekleþtirilirken Bir Hata Ýle Karþýlaþýldý...', 'error');
});

$("#swal-6").click(function () {
  swal({
    title: 'Bu Ýþlemi Yapmak Ýstediðinize Emin Misiniz?',
    text: 'Bu Dosya Geri Alýnamayacak Biçimde Silinecektir!',
    icon: 'warning',
    buttons: true,
    dangerMode: true,
  })
    .then((willDelete) => {
      if (willDelete) {
        swal('Silme Ýþlemi Baþarýlý Bir Þekilde Gerçekleþtirildi!', {
          icon: 'success',
        });
      } else {
        swal('Dosya Silme Ýþleminden Vazgeçildi. Dosya Güvende!');
      }
    });
});

$("#swal-7").click(function () {
  swal({
    title: 'Adýnýz Nedir?',
    content: {
      element: 'input',
      attributes: {
        placeholder: 'Adýnýzý Yazýn',
        type: 'text',
      },
    },
  }).then((data) => {
    swal('Merhaba, ' + data + '!');
  });
});

$("#swal-8").click(function () {
  swal('Zaman bazlý uyarý!', {
    buttons: false,
    timer: 3000,
  });
});
}
