(function ($) {
    var _departmentAppService = abp.services.app.department;
    l = abp.localization.getSource('BookApp');
    var _$form = $('form[name=DepartmentInformationForm]');
    var _indexPage = "/Department";

    $(document).on('click', '.delete-button', function () {
        var departmentId = parseInt($(this).attr("department-id"));
        var departmentName = $(this).attr("department-name");

        deleteId(departmentId, departmentName);
    });

    function deleteId(departmentId, departmentName) {
        abp.message.confirm(
            abp.utils.formatString(l('AreYouSureWantToDelete', departmentName)), null,
            function (isConfirmed) {
                if (isConfirmed) {
                    if (departmentId != 0) {
                        _departmentAppService.delete({ id: departmentId }).done(function () {
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

