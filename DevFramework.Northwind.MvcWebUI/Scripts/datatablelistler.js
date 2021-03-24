//sporcu listele sil düzenle KategoriAdi
$(document).ready(function () {
    var oTable = $('#dataTables-sporculist').DataTable({
        responsive: true,
        "fnRowCallback": function (nRow, data, iDisplayIndex) {
            if ( data.KategoriAdi == "Boks" ) {
                //$('td:eq(1)', nRow).css('background-color', '#dff0d8');
                $('td', nRow).css('background-color', '#dff0d8');
            }
            else {
                $('td', nRow).css('background-color', '#f2dede');
            }
            return nRow;
        },
        "ajax": {
            "url": '/Sporcu/SporcuGetir',
            "type": "get",
            "datatype": "json",
            "urlHata":'/Account/Giris',
            "error": function () {
                window.location.href = '/Account/Giris';
            }
        },
        "columns": [
            { "data": "KategoriAdi", "autoWidth": true },
            { "data": "AdSoyad", "autoWidth": true },
            { "data": "TelNo", "autoWidth": true },
            { "data": "DogumTarihi", "autoWidth": true },
            { "data": "Aciklama", "autoWidth": true },
            { "data": "VeliAdi", "autoWidth": true },
            { "data": "VeliTelNo", "autoWidth": true },
            {
              "data": "Id", "width": "50px", "render": function (data) {
                  return '<a class="popup btn btn-success" href="/Sporcu/SporcuKayit/' + data + '">Düzenle</a>';
                                                                       }
            },
            {
                "data": "Id", "width": "50px", "render": function (data) {
                  return '<a class="popup btn btn-danger"  href="/Sporcu/SporcuSil/' + data + '">Sil</a>';
                                                                       }
            },
            {
                   "data": "Id", "width": "50px", "render": function (data) {
                       return '<a class="btn btn-warning"  href="/sporcuodemeleri/Aylik/' + data + '">Aylik Odeme</a>';
                   }
            },
            {
                   "data": "Id", "width": "50px", "render": function (data) {
                       return '<a class="btn btn-info"  href="/kusakodemeleri/index/' + data + '">Kuşak Odeme</a>';
                   }
            },
        ],

    })


    $('.tablecontainer').on('click', 'a.popup', function (e) {
        e.preventDefault();
        OpenPopup($(this).attr('href'));
    })

    function OpenPopup(pageUrl) {
        var $pageContent = $('<div/>');
        $pageContent.load(pageUrl, function () {
            $('#popupForm', $pageContent).removeData('validator');
            $('#popupForm', $pageContent).removeData('unobtrusiveValidation');
            $.validator.unobtrusive.parse('form');

        });

        $dialog = $('<div class="popupWindow" style="overflow:auto"></div>')
                  .html($pageContent)
                  .dialog({
                      draggable: false,
                      autoOpen: false,
                      resizable: false,
                      model: true,
                      title: 'Sporcu Düzenleme Formu',
                      height: 550,
                      width: 900,
                      close: function () {
                          $dialog.dialog('destroy').remove();
                      }
                  })

        $('.popupWindow').on('submit', '#popupForm', function (e) {
            var url = $('#popupForm')[0].action;
            $.ajax({
                type: "POST",
                url: url,
                data: $('#popupForm').serialize(),
                success: function (data) {
                    if (data.status) {
                        $dialog.dialog('close');
                        oTable.ajax.reload();
                    }
                }
            })

            e.preventDefault();
        })

        $dialog.dialog('open');
    }

});



//sporcu kategorileri listele sil düzenle 
$(document).ready(function () {
    var oTable = $('#dataTables-sporcukategorilist').DataTable({
        responsive: true,
        "ajax": {
            "url": '/SporcuKategori/SporcuKategoriGetir',
            "type": "get",
            "datatype": "json"
        },
        "columns": [
            //{ "data": "Id", "autoWidth": true },
            { "data": "KategoriAdi", "autoWidth": true },
            {
                "data": "Id", "width": "50px", "render": function (data) {
                    return '<a class="popup btn btn-success" href="/SporcuKategori/SporcuKategoriKayit/' + data + '">Düzenle</a>';
                }
            },
            {
                "data": "Id", "width": "50px", "render": function (data) {
                    return '<a class="popup btn btn-danger"  href="/SporcuKategori/SporcuKategoriSil/' + data + '">Sil</a>';
                }
            },
        ]
    })


    $('.tablecontainerkategori').on('click', 'a.popup', function (e) {
        e.preventDefault();
        OpenPopup($(this).attr('href'));
    })

    function OpenPopup(pageUrl) {
        var $pageContent = $('<div/>');
        $pageContent.load(pageUrl, function () {
            $('#popupForm', $pageContent).removeData('validator');
            $('#popupForm', $pageContent).removeData('unobtrusiveValidation');
            $.validator.unobtrusive.parse('form');

        });

        $dialog = $('<div class="popupWindow" style="overflow:auto"></div>')
                  .html($pageContent)
                  .dialog({
                      draggable: false,
                      autoOpen: false,
                      resizable: false,
                      model: true,
                      title: 'Sporcu Kategori Düzenleme Formu',
                      height: 200,
                      width: 300,
                      close: function () {
                          $dialog.dialog('destroy').remove();
                      }
                  })

        $('.popupWindow').on('submit', '#popupForm', function (e) {
            var url = $('#popupForm')[0].action;
            $.ajax({
                type: "POST",
                url: url,
                data: $('#popupForm').serialize(),
                success: function (data) {
                    if (data.status) {
                        $dialog.dialog('close');
                        oTable.ajax.reload();
                    }
                }
            })

            e.preventDefault();
        })

        $dialog.dialog('open');
    }

});


//sporcu  aylik sil düzenle 
$(document).ready(function () {
    var oTable = $('#dataTables-sporcuayliklist').DataTable({
        responsive: true,
        "fnRowCallback": function (nRow, data, iDisplayIndex) {
            //if (data.KategoriAdi == "Boks") {
            //    //$('td:eq(1)', nRow).css('background-color', '#dff0d8');
            //    $('td', nRow).css('background-color', '#dff0d8');
            //}
            //else {
            //    $('td', nRow).css('background-color', '#f2dede');
            //}
            //return nRow;
            var currentdate = new Date();
            if (currentdate.getMonth()+1==1) {
                if (data.Ocak == null) {
                    $('td', nRow).css('background-color', '#f2dede');
                }
            }
            if (currentdate.getMonth() + 1 == 2) {
                if (data.Subat == null) {
                    $('td', nRow).css('background-color', '#f2dede');
                }
            }
            if (currentdate.getMonth() + 1 == 3) {
                if (data.Mart == null) {
                    $('td', nRow).css('background-color', '#f2dede');
                }
            }
            if (currentdate.getMonth() + 1 == 4) {
                if (data.Nisan == null) {
                    $('td', nRow).css('background-color', '#f2dede');
                }
            }
            if (currentdate.getMonth() + 1 == 5) {
                if (data.Mayis == null) {
                    $('td', nRow).css('background-color', '#f2dede');
                }
            }
            if (currentdate.getMonth() + 1 == 6) {
                if (data.Haziran == null) {
                    $('td', nRow).css('background-color', '#f2dede');
                }
            }
            if (currentdate.getMonth() + 1 == 7) {
                if (data.Temmuz == null) {
                    $('td', nRow).css('background-color', '#f2dede');
                }
            }
            if (currentdate.getMonth() + 1 == 8) {
                if (data.Agustos == null) {
                    $('td', nRow).css('background-color', '#f2dede');
                }
            }
            if (currentdate.getMonth() + 1 == 9) {
                if (data.Eylul == null) {
                    $('td', nRow).css('background-color', '#f2dede');
                }
            }
            if (currentdate.getMonth() + 1 == 10) {
                if (data.Ekim == null) {
                    $('td', nRow).css('background-color', '#f2dede');
                }
            }
            if (currentdate.getMonth() + 1 == 11) {
                if (data.Kasim == null) {
                    $('td', nRow).css('background-color', '#f2dede');
                }
            }
            if (currentdate.getMonth() + 1 == 12) {
                if (data.Aralik == null) {
                    $('td', nRow).css('background-color', '#f2dede');
                }
            }
        },
        "ajax": {
            "url": '/SporcuOdemeleri/SporcuOdemelerGetir/' + $('#sporcuodemeler-sporcuid').text(),
            "type": "get",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "Id", "width": "50px", "render": function (data) {
                                return '<a class="popup btn btn-success" href="/SporcuOdemeleri/SporcuOdemelerKayit/' + data + '">Düzenle</a>';
                  }
            },
            {
                "data": "Id", "width": "50px", "render": function (data) {
                    return '<a class="popup btn btn-danger"  href="/SporcuOdemeleri/SporcuOdemelerSil/' + data + '">Sil</a>';
                }
            },
            //{ "data": "Id", "autoWidth": true },
            { "data": "AdSoyad", "autoWidth": true },
            { "data": "Yil", "autoWidth": true },
            { "data": "KiyafetParasi", "autoWidth": true },
            { "data": "Ocak", "autoWidth": true },
            { "data": "Subat", "autoWidth": true },
            { "data": "Mart", "autoWidth": true },
            { "data": "Nisan", "autoWidth": true },
            { "data": "Mayis", "autoWidth": true },
            { "data": "Haziran", "autoWidth": true },
            { "data": "Temmuz", "autoWidth": true },
            { "data": "Agustos", "autoWidth": true },
            { "data": "Eylul", "autoWidth": true },
            { "data": "Ekim", "autoWidth": true },
            { "data": "Kasim", "autoWidth": true },
            { "data": "Aralik", "autoWidth": true },


        ]
    })


    $('.tablecontaineraylik').on('click', 'a.popup', function (e) {
        e.preventDefault();
        OpenPopup($(this).attr('href'));
    })

    function OpenPopup(pageUrl) {
        var $pageContent = $('<div/>');
        $pageContent.load(pageUrl, function () {
            $('#popupForm', $pageContent).removeData('validator');
            $('#popupForm', $pageContent).removeData('unobtrusiveValidation');
            $.validator.unobtrusive.parse('form');

        });

        $dialog = $('<div class="popupWindow" style="overflow:auto"></div>')
                  .html($pageContent)
                  .dialog({
                      draggable: false,
                      autoOpen: false,
                      resizable: false,
                      model: true,
                      title: 'Sporcu Aylik Düzenleme Formu',
                      height: 550,
                      width: 900,
                      close: function () {
                          $dialog.dialog('destroy').remove();
                      }
                  })

        $('.popupWindow').on('submit', '#popupForm', function (e) {
            var url = $('#popupForm')[0].action;
            $.ajax({
                type: "POST",
                url: url,
                data: $('#popupForm').serialize(),
                success: function (data) {
                    if (data.status) {
                        $dialog.dialog('close');
                        oTable.ajax.reload();
                    }
                }
            })

            e.preventDefault();
        })

        $dialog.dialog('open');
    }

});


//kusaklar listele sil düzenle 
$(document).ready(function () {
    var oTable = $('#dataTables-kusaklarlist').DataTable({
        responsive: true,
        "ajax": {
            "url": '/Kusaklar/KusaklarGetir',
            "type": "get",
            "datatype": "json"
        },
        "columns": [
            //{ "data": "Id", "autoWidth": true },
            { "data": "KusakAdi", "autoWidth": true },
            {
                "data": "Id", "width": "50px", "render": function (data) {
                    return '<a class="popup btn btn-success" href="/Kusaklar/KusaklarKayit/' + data + '">Düzenle</a>';
                }
            },
            {
                "data": "Id", "width": "50px", "render": function (data) {
                    return '<a class="popup btn btn-danger"  href="/Kusaklar/KusaklarSil/' + data + '">Sil</a>';
                }
            },
        ]
    })


    $('.tablecontainerkusaklar').on('click', 'a.popup', function (e) {
        e.preventDefault();
        OpenPopup($(this).attr('href'));
    })

    function OpenPopup(pageUrl) {
        var $pageContent = $('<div/>');
        $pageContent.load(pageUrl, function () {
            $('#popupForm', $pageContent).removeData('validator');
            $('#popupForm', $pageContent).removeData('unobtrusiveValidation');
            $.validator.unobtrusive.parse('form');

        });

        $dialog = $('<div class="popupWindow" style="overflow:auto"></div>')
                  .html($pageContent)
                  .dialog({
                      draggable: false,
                      autoOpen: false,
                      resizable: false,
                      model: true,
                      title: 'Kuşak Düzenleme Formu',
                      height: 200,
                      width: 300,
                      close: function () {
                          $dialog.dialog('destroy').remove();
                      }
                  })

        $('.popupWindow').on('submit', '#popupForm', function (e) {
            var url = $('#popupForm')[0].action;
            $.ajax({
                type: "POST",
                url: url,
                data: $('#popupForm').serialize(),
                success: function (data) {
                    if (data.status) {
                        $dialog.dialog('close');
                        oTable.ajax.reload();
                    }
                }
            })

            e.preventDefault();
        })

        $dialog.dialog('open');
    }

});

    //alert($("#sporcugoster option:selected").val())
    //kusakodemeleri listele sil düzenle 
$(document).ready(function () {

        var oTable = $('#dataTables-kusakodemelerilist').DataTable({
            responsive: true,
            "ajax": {
                "url": '/KusakOdemeleri/KusakOdemeleriGetir/' + +$('#kusakodemeleri-sporcuid').text(),
                "type": "get",
                "datatype": "json"
            },
            "columns": [
                //{ "data": "Id", "autoWidth": true },
                { "data": "KusakAdi", "autoWidth": true },
                { "data": "AdSoyad", "autoWidth": true },
                { "data": "OdemeTarihi", "autoWidth": true },
                { "data": "OdemeTutari", "autoWidth": true },
                {
                    "data": "Id", "width": "50px", "render": function (data) {
                        return '<a class="popup btn btn-success" href="/KusakOdemeleri/KusakOdemeleriKayit/' + data + '">Düzenle</a>';
                    }
                },
                {
                    "data": "Id", "width": "50px", "render": function (data) {
                        return '<a class="popup btn btn-danger"  href="/KusakOdemeleri/KusakOdemeleriSil/' + data + '">Sil</a>';
                    }
                },
            ]
        })

        $.fn.dataTable.ext.errMode = 'none';
        $('.tablecontainerkusakodemeleri').on('click', 'a.popup', function (e) {
            e.preventDefault();
            OpenPopup($(this).attr('href'));
        })

        function OpenPopup(pageUrl) {
            var $pageContent = $('<div/>');
            $pageContent.load(pageUrl, function () {
                $('#popupForm', $pageContent).removeData('validator');
                $('#popupForm', $pageContent).removeData('unobtrusiveValidation');
                $.validator.unobtrusive.parse('form');

            });

            $dialog = $('<div class="popupWindow" style="overflow:auto"></div>')
                      .html($pageContent)
                      .dialog({
                          draggable: false,
                          autoOpen: false,
                          resizable: false,
                          model: true,
                          title: 'Kuşak Ödemeleri Düzenleme Formu',
                          height: 400,
                          width: 600,
                          close: function () {
                              $dialog.dialog('destroy').remove();
                          }
                      })

            $('.popupWindow').on('submit', '#popupForm', function (e) {
                var url = $('#popupForm')[0].action;
                $.ajax({
                    type: "POST",
                    url: url,
                    data: $('#popupForm').serialize(),
                    success: function (data) {
                        if (data.status) {
                            $dialog.dialog('close');
                            oTable.ajax.reload();
                        }
                    }
                })

                e.preventDefault();
            })

            $dialog.dialog('open');
        }

    });



//tesisodemeleri listele sil düzenle 
$(document).ready(function () {
    var oTable = $('#dataTables-tesisodemelerilist').DataTable({
        responsive: true,
        "ajax": {
            "url": '/TesisFaturam/TesisFaturamGetir',
            "type": "get",
            "datatype": "json"
        },
        "columns": [
            //{ "data": "Id", "autoWidth": true },
            { "data": "TesisFaturaTuru", "autoWidth": true },
            { "data": "TesisFaturaTutari", "autoWidth": true },
            { "data": "IslemTarihi", "autoWidth": true },
            { "data": "SonOdeme", "autoWidth": true },
            {
                "data": "Id", "width": "50px", "render": function (data) {
                    return '<a class="popup btn btn-success" href="/TesisFaturam/TesisFaturamKayit/' + data + '">Düzenle</a>';
                }
            },
            {
                "data": "Id", "width": "50px", "render": function (data) {
                    return '<a class="popup btn btn-danger"  href="/TesisFaturam/TesisFaturamSil/' + data + '">Sil</a>';
                }
            },
        ]
    })


    $('.tablecontainertesisfaturam').on('click', 'a.popup', function (e) {
        e.preventDefault();
        OpenPopup($(this).attr('href'));
    })

    function OpenPopup(pageUrl) {
        var $pageContent = $('<div/>');
        $pageContent.load(pageUrl, function () {
            $('#popupForm', $pageContent).removeData('validator');
            $('#popupForm', $pageContent).removeData('unobtrusiveValidation');
            $.validator.unobtrusive.parse('form');

        });

        $dialog = $('<div class="popupWindow" style="overflow:auto"></div>')
                  .html($pageContent)
                  .dialog({
                      draggable: false,
                      autoOpen: false,
                      resizable: false,
                      model: true,
                      title: 'TesisFatura Düzenleme Formu',
                      height: 200,
                      width: 300,
                      close: function () {
                          $dialog.dialog('destroy').remove();
                      }
                  })

        $('.popupWindow').on('submit', '#popupForm', function (e) {
            var url = $('#popupForm')[0].action;
            $.ajax({
                type: "POST",
                url: url,
                data: $('#popupForm').serialize(),
                success: function (data) {
                    if (data.status) {
                        $dialog.dialog('close');
                        oTable.ajax.reload();
                    }
                }
            })

            e.preventDefault();
        })

        $dialog.dialog('open');
    }

});
