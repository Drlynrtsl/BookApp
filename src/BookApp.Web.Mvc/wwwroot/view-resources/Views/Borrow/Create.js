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

    $('#students').on('change', function () {
        var student = document.getElementById('students').value();
        var rowCount = student.rows.length;

        var studentSelected = $(this).val();
        var bookSelected = row.find('#books');
    })

    //$('#students').on('change', function () {
    //    var student = document.getElementById("students").value;
    //    var book = document.getElementById("books").value;
    //    var bookcategory = book.BookCategoriesId;


    //    student = _$form[0].querySelectorAll("input[name='students']");
    //    abp.ui.setBusy(_$form);
    //    if (student.StudentDepartmentId == book.DepartmentId) {
    //        for (var studentIndex in student) {
    //            student.options[student.options.length] = new Options(studentIndex, studentIndex);
    //        }
    //        for (var bookcategoryIndex in bookcategory[this.value]) {
    //            bookcategory.options[bookcategory.options.length] = new Option(bookcategoryIndex, bookcategoryIndex);
    //        }
    //        $('#books').on('change', function () {
    //            var bookcat = bookcategory[bookcategory.value][this.value];
    //            for (var bookIndex = 0; bookIndex < bookcat.length; bookIndex++) {
    //                book.Options[book.options.length] = new Options(bookcat[bookIndex], bookcat[bookIndex]);
    //            }
    //        })
    //    }
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

