(function ($) {
    var _departmentAppService = abp.services.app.department;
    var _$form = $('form[name=DepartmentInformationForm]');
    var _indexPage = "/Department";

    function save() {
        if (!_$form.valid()) {
            return;
        }
        var department = _$form.serializeFormToObject();
        abp.ui.setBusy(_$form);
        if (department.Id != 0) {
            _departmentAppService.update(department).done(function () {
                window.location.href = _indexPage;
            }).always(function () {
                abp.ui.clearBusy(_$form);
            });
        } else {
            _departmentAppService.create(department).done(function () {
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

