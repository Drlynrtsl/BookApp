(function ($) {
    var _borrowAppService = abp.services.app.borrow;
    l = abp.localization.getSource('BookApp');
    var _$form = $('form[name=BorrowInformationForm]');
    var _indexPage = "/Borrow";

    $(document).on('click', '.delete-button', function () {
        var borrowId = parseInt($(this).attr("borrow-id"));
        var borrowBookName= parseInt($(this).attr("borrow-book-name"));

        deleteId(borrowId, borrowBookName);
    });

    function deleteId(borrowId, borrowBookName) {
        abp.message.confirm(
            abp.utils.formatString(l('AreYouSureWantToDelete', borrowBookName)), null,
            function (isConfirmed) {
                if (isConfirmed) {
                    if (borrowId != 0) {
                        _borrowAppService.delete({ id: borrowId }).done(function () {
                            abp.message.success('Deleted.', '');
                            location.reload(true);
                        });
                    }
                }

            });
    }


    function update() {
        window.location.href = "/Borrow/Create/@borrows.Id";
    }
    _$form.closest('div#form')
        .find(".back-button")
        .click(function (e) {
            e.preventDefault();
            cancel();
        });
    _$form.closest('div#form')
        .find(".return-button")
        .click(function (e) {
            e.preventDefault();
            update();
        });
})(jQuery);

