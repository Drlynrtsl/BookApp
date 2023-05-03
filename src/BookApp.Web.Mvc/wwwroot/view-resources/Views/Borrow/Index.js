(function ($) {
    var _borrowAppService = abp.services.app.borrow;
    l = abp.localization.getSource('BookApp');
    var _$form = $('form[name=BorrowInformationForm]');

    $(document).on('click', '.delete-button', function () {
        var borrowId = parseInt($(this).attr("borrow-id"));
        deleteId(borrowId);
    });

    function deleteId(borrowId) {
        abp.message.confirm(
            abp.utils.formatString(l('Are you sure want to delete this?')), null,
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