(function ($) {
    var _bookAppService = abp.services.app.book;
    l = abp.localization.getSource('BookApp');
    var _$form = $('form[name=BookInformationForm]');
    var _indexPage = "/Book";

    $(document).on('click', '.delete-button', function () {
        var bookId = $(this).attr("book-Id");
        var bookTitle = $(this).attr("book-Title");

        deleteUser(bookId, bookTitle);
    });

    function deleteUser(bookId) {
        abp.message.confirm(
            swal(
                l('AreYouSureWantToDelete'),
                bookTitle),
            null,
            (isConfirmed) => {
                if (book.Id !=0) {
                    _bookAppService.delete(bookId).done(() => {
                        swal(l('SuccessfullyDeleted'));
                        _bookAppService.ajax.reload();

                    });
                }
            }
        );
    }
    _$form.closest('div#form')
        .find(".back-button")
        .click(function (e) {
            e.preventDefault();
            cancel();
        });
})(jQuery);

