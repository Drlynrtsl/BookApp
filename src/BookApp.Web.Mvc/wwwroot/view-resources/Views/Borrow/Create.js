(function ($) {    
    var _borrowAppService = abp.services.app.borrow;
    var _$form = $('form[name=BorrowInformationForm]');
    var _indexPage = "/Borrow";

    function save() {
        if (!_$form.valid()) {
            return;
        }
        var borrow = _$form.serializeFormToObject();
        borrow.BookId = parseInt(borrow.BookId);
        borrow.StudentId = parseInt(borrow.StudentId);        
        borrow.BookCategoriesId = parseInt(borrow.BookCategoriesId);        
        borrow.DepartmentId = parseInt(borrow.DepartmentId);
        borrow.StudentDepartmentId = parseInt(borrow.StudentDepartmentId);
        borrow.StudentDepartmentId = borrow.DepartmentId;
        abp.ui.setBusy(_$form);
        if (borrow.Id != 0) {
            _borrowAppService.update(borrow).done(function () {
                window.location.href = _indexPage;
            }).always(function () {
                abp.ui.clearBusy(_$form);
            });
        } else {
            _borrowAppService.create(borrow).done(function () {
                window.location.href = _indexPage;
            }).always(function () {
                abp.ui.clearBusy(_$form);
            });
        }
    }
    //function getStudentBook() {
    //    var student 
    //}

    //$('#students').on('change', function () {
    //    var student = document.getElementById("students").value;
    //    var book = document.getElementById("books").value;


    //    document.getElementById("books").value = getStudentBook(student);
    //})


    $('#BorrowDate').on('change', function () {
        
        var borrowDate = new Date(document.getElementById("BorrowDate").value);

        document.getElementById("ExpectedReturnDate").value = formatDate(borrowDate.addDays(7));
    })  

    function formatDate(date) {
        var d = new Date(date);
        date = [
            d.getFullYear(),
            ('0' + (d.getMonth() + 1)).slice(-2),
            ('0' + d.getDate()).slice(-2)
        ].join('-');
        return date;
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

