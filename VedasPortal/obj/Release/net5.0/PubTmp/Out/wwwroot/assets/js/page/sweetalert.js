window.sweetAlert = function () {
"use strict";

$("#swal-1").click(function () {
  swal('Merhaba');
});

$("#swal-2").click(function () {
  swal('Ba�ar�l�', '��leminiz Ba�ar�l� Bir �ekilde Ger�ekle�ti...', 'success');
});

$("#swal-3").click(function () {
  swal('Uyar�', 'Bu Alana Girmeye Yetkiniz Yok', 'warning');
});

$("#swal-4").click(function () {
  swal('Bilgi', 'Bu ��lem ��in Y�neticinize Ba�vurunuz...', 'info');
});

$("#swal-5").click(function () {
  swal('Hata', '��leminiz Ger�ekle�tirilirken Bir Hata �le Kar��la��ld�...', 'error');
});

$("#swal-6").click(function () {
  swal({
    title: 'Bu ��lemi Yapmak �stedi�inize Emin Misiniz?',
    text: 'Bu Dosya Geri Al�namayacak Bi�imde Silinecektir!',
    icon: 'warning',
    buttons: true,
    dangerMode: true,
  })
    .then((willDelete) => {
      if (willDelete) {
        swal('Silme ��lemi Ba�ar�l� Bir �ekilde Ger�ekle�tirildi!', {
          icon: 'success',
        });
      } else {
        swal('Dosya Silme ��leminden Vazge�ildi. Dosya G�vende!');
      }
    });
});

$("#swal-7").click(function () {
  swal({
    title: 'Ad�n�z Nedir?',
    content: {
      element: 'input',
      attributes: {
        placeholder: 'Ad�n�z� Yaz�n',
        type: 'text',
      },
    },
  }).then((data) => {
    swal('Merhaba, ' + data + '!');
  });
});

$("#swal-8").click(function () {
  swal('Zaman bazl� uyar�!', {
    buttons: false,
    timer: 3000,
  });
});
}
