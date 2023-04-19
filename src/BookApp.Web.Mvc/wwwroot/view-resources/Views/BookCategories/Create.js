(function ($) {
    var _bookCategoriesAppService = abp.services.app.bookCategories;
    var _$form = $('form[name=BookCategoryInformationForm]');
    var _indexPage = "/BookCategories";

    function save() {
        if (!_$form.valid()) {
            return;
        }
        var bookcategory = _$form.serializeFormToObject();
        bookcategory.DepartmentId = parseInt(bookcategory.DepartmentId);
        abp.ui.setBusy(_$form);
        if (bookcategory.Id != 0) {
            _bookCategoriesAppService.update(bookcategory).done(function () {
                window.location.href = _indexPage;
            }).always(function () {
                abp.ui.clearBusy(_$form);
            });
        } else {
            _bookCategoriesAppService.create(bookcategory).done(function () {
                window.location.href = _indexPage;
            }).always(function () {
                abp.ui.clearBusy(_$form);
            });
        }
    }

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

