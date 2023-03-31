(function ($) {
    var _studentAppService = abp.services.app.student;
    l = abp.localization.getSource('BookApp');
    var _$form = $('form[name=StudentInformationForm]');
    var _indexPage = "/Student";

    $(document).on('click', '.delete-button', function () {
        var studentId = parseInt($(this).attr("student-id"));
        var studentName = $(this).attr("student-name");

        deleteId(studentId, studentName);
    });

    function deleteId(studentId, studentName) {
        abp.message.confirm(
            abp.utils.formatString(l('AreYouSureWantToDelete', studentName)), null,
            function (isConfirmed) {
                if (isConfirmed) {
                    if (studentId != 0) {
                        _studentAppService.delete({ id: studentId }).done(function () {
                            abp.message.success('Deleted.', '');
                            location.reload(true);
                        });
                    }
                }

            });
    }

    function update() {
        window.location.href = "/Student/Create/@students.Id";
    }
    _$form.closest('div#form')
        .find(".back-button")
        .click(function (e) {
            e.preventDefault();
            cancel();
        });
    //_$form.closest('div#form')
    //    .find(".update-button")
    //    .click(function (e) {
    //        e.preventDefault();
    //        update();
    //    });
})(jQuery);

