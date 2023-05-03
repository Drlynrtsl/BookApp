(function ($) {
    var _bookAppService = abp.services.app.book;
    l = abp.localization.getSource('BookApp');
    var _$form = $('form[name=BookInformationForm]');

    $(document).on('click', '.delete-button', function () {
        var bookId = parseInt($(this).attr("book-id"));
        var bookTitle = $(this).attr("book-title");

        deleteId(bookId, bookTitle);
    });

    function deleteId(bookId, bookTitle) {
        abp.message.confirm(
            abp.utils.formatString(l('AreYouSureWantToDelete', bookTitle)), null,            
            function (isConfirmed) {
                if(isConfirmed) {
                    if (bookId != 0) {
                        _bookAppService.delete({ id: bookId }).done(function() {
                            abp.message.success('Deleted.', '');
                            location.reload(true);
                        });
                    }
                }
                
            });
    }
    _$form.closest('div#form')
        .find(".back-button")
        .click(function (e) {
            e.preventDefault();
            cancel();
        });
})(jQuery);

