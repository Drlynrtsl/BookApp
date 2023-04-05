(function ($) {
    var _borrowAppService = abp.services.app.borrow;
    var _$form = $('form[name=BorrowInformationForm]');
    var _indexPage = "/Borrow";

    function save() {
        if (!_$form.valid()) {
            return;
        }
        var borrow = _$form.serializeFormToObject();
        //borrow.BookId = parseInt($(this).attr("borrow-book"));
        //borrow.StudentId = parseInt($(this).attr("borrow-student"));
        borrow.BookId = parseInt(borrow.BookId);
        borrow.BookTitle = parseInt(borrow.BookTitle);
        borrow.StudentId = parseInt(borrow.StudentId);
        borrow.StudentName = parseInt(borrow.StudentName);
        /*borrow.Student = parseInt($(this).attr("borrow-student"));*/
        abp.ui.setBusy(_$form);
        if (borrow.Id != 0) {
            _borrowAppService.update(borrow).done(function () {
                window.location.href = _indexPage;
            }).always(function () {
                abp.ui.clearBusy(_$form);
            });
        } else {
            _borrowAppService.create(borrow).done(function () {
                window.location.href = _indexPage;
            }).always(function () {
                abp.ui.clearBusy(_$form);
            });
        }
    }


    function cancel() {
        window.location.href = _indexPage;
    }
    //Handle save button click 
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

