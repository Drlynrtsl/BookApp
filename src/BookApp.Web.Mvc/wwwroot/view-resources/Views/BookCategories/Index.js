(function ($) {
    var _bookCategoriesAppService = abp.services.app.bookCategories;
    l = abp.localization.getSource('BookApp');
    var _$form = $('form[name=BookCategoryInformationForm]');
    var _indexPage = "/Borrow";

    $(document).on('click', '.delete-button', function () {
        var bookCategoryId = parseInt($(this).attr("bookcategory-id"));
        var bookCategoryName = ($(this).attr("bookcategory-name"));

        deleteId(bookCategoryId, bookCategoryName);
    });

    function deleteId(bookCategoryId, bookCategoryName) {
        abp.message.confirm(
            abp.utils.formatString(l('AreYouSureWantToDelete', bookCategoryName)), null,
            function (isConfirmed) {
                if (isConfirmed) {
                    if (bookCategoryId != 0) {
                        _bookCategoriesAppService.delete({ id: bookCategoryId }).done(function () {
                            abp.message.success('Deleted.', '');
                            location.reload(true);
                        });
                    }
                }

            });
    }


    function update() {
        window.location.href = "/BookCategories/Create/@bookcategory.Id";
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