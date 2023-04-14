(function ($) {    
    /*import { formatDate } from './main.js';*/
    var _borrowAppService = abp.services.app.borrow;
    var _$form = $('form[name=BorrowInformationForm]');
    var _indexPage = "/Borrow";

    function save() {
        if (!_$form.valid()) {
            return;
        }
        var borrow = _$form.serializeFormToObject();
        borrow.BookId = parseInt(borrow.BookId);
        borrow.StudentId = parseInt(borrow.StudentId);
        abp.ui.setBusy(_$form);
        if (borrow.Id != 0) {
            _borrowAppService.update(borrow).done(function () {
                window.location.href = _indexPage;
            }).always(function () {
                abp.ui.clearBusy(_$form);
            });
        } else {
            document.getElementById("ReturnDate").disabled = true;
            _borrowAppService.create(borrow).done(function () {
            }).always(function () {
                abp.ui.clearBusy(_$form);
            });
        }
    }

    $('#BorrowDate').on('change', function () {
        var borrowDate = new Date(document.getElementById("BorrowDate").value);

        document.getElementById("ExpectedReturnDate").value = borrowDate.addDays(7).toLocaleDateString('fr-CA');
    })

    $('#books').on('change', function () {
        var students = $('#books').Student();
        if (students == 0) {
            $('#books').attr('disabled', true);
        } else {
            $('#books').attr('disabled', false);
        }
    })


    function cancel() {
        window.location.href = _indexPage;
    }

   
    _$form.closest('div#form')
        .find(".save-button")
        .click(function (e) {
            e.preventDefault();
            save();
        });
    _$form.closest('div#form')
        .find(".back-button")
        .click(function (e) {
            e.preventDefault();
            cancel();
        });
})(jQuery);

