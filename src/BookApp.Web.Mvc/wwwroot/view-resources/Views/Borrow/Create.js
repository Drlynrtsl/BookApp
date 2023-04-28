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
        var student = $(this).val();
        if (student != 0) {
            _borrowAppService.getAllBooksByStudentId(student).done(function (book) {
                console.log(book);
                $('#books').empty();
                if (book && book.length != 0) {
                    $('#books').html("");
                    $('#books').append("<option value=''>--Select Book--</option>");
                    for (var i = 0; i < book.length; i++) {
                        $('#books').append("<option value='" + book[i].id + "'>" + book[i].bookTitle + "</option>");
                        $('#books').prop('disabled', false);
                    }
                } else {
                    $('#books').append($('<option disabled selected>No Books Available</option>').val(''));
                    $('#books').prop('disabled', true);
                    $('.save-button').prop('disabled', true);
                }
            });
        } else {
            $('#books').append($('<option disabled selected>No Student Available</option>').val(''));
        }
        
    });

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

