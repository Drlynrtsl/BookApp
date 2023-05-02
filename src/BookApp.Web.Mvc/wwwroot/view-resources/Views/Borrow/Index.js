(function ($) {
    var _borrowAppService = abp.services.app.borrow;
    l = abp.localization.getSource('BookApp');
    var _$form = $('form[name=BorrowInformationForm]');
    var _indexPage = "/Borrow";

    $(document).on('click', '.delete-button', function () {
        var borrowId = parseInt($(this).attr("borrow-id"));
        var borrowBookId = ($(this).attr("borrow-book-id"));
        var borrowBookName = ($(this).attr("borrow-book-name"));
        var borrowStudentId = ($(this).attr("borrow-book-id"));
        var borrowStudentName = ($(this).attr("borrow-student-name"));
        deleteId(borrowId, borrowBookId, borrowBookName, borrowStudentId, borrowStudentName);
    });

    function deleteId(borrowId, borrowBookName, borrowStudentName) {
        abp.message.confirm(
            abp.utils.formatString(l('AreYouSureWantToDelete', borrowBookName, borrowStudentName)), null,
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