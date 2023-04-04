(function ($) {
    var _studentAppService = abp.services.app.student;
    var _$form = $('form[name=StudentInformationForm]');
    var _indexPage = "/Student";

    function save() {
        if (!_$form.valid()) {
            return;
        }
        var student = _$form.serializeFormToObject();
        student.StudentDepartmentId = parseInt(student.StudentDepartmentId);
        //$('#StudentDepartmentId').val($('#StudentDepartment_StudentDepartmentId').find(":selected").val())
        abp.ui.setBusy(_$form);
        if (student.Id != 0) {
            _studentAppService.update(student).done(function () {
                window.location.href = _indexPage;
            }).always(function () {
                abp.ui.clearBusy(_$form);
            });
        } else {
            _studentAppService.create(student).done(function () {
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

