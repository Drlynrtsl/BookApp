(function ($) {
    var _bookAppService = abp.services.app.book;
    var _$form = $('form[name=BookInformationForm]');
    var _indexPage = "/Book";

    function save() {
        if (!_$form.valid()) {
            return;
        }
        var book = _$form.serializeFormToObject();
        abp.ui.setBusy(_$form);
        if (book.Id != 0) {
            _bookAppService.update(book).done(function () {
                window.location.href = _indexPage;
            }).always(function () {
                abp.ui.clearBusy(_$form);
            });
        } else {
            _bookAppService.create(book).done(function () {
                window.location.href = _indexPage;
            }).always(function () {
                abp.ui.clearBusy(_$form);
            });
        }
    }

    $(document).on('click', '.delete-button', function () {
        var bookId = $(this).attr("book-Id");
        var bookTitle = $(this).attr("book-Title");

        deleteUser(bookId, bookTitle);
    });

    function deleteId() {
        var book = _$form.serializeFormToObject();
        if (!_$form.valid()) {
            return;
        }
        abp.ui.setBusy(_$form);        
            swal('AreYouSureWantToDelete',bookTitle),
            (isConfirmed) => {
                if (book.Id != 0) {
                    _bookAppService.delete(book).done(() => {
                        swal(l('SuccessfullyDeleted'));
                        _bookAppService.ajax.reload();

                    });
                }
                swal("No changes has been made");
            };
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
    _$form.closest('div#form')
        .find(".delete-button")
        .click(function (e) {
            e.preventDefault();
            deleteId();
        });
})(jQuery);

