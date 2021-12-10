var dates = function () {
    return {
        init: function () {
            $('.datepicker').datepicker({
                format: 'dd MM yyyy',
                todayHighlight: true
            });

            $('.nofuturedate').datepicker({
                format: 'dd MM yyyy',
                todayHighlight: true,
                endDate: '+0d'
            });

            $('.dob').datepicker({
                format: 'dd MM yyyy',
                todayHighlight: true,
                endDate: '-18y'
            });

            $('.monthpicker').datepicker({
                autoclose: true,
                minViewMode: 1,
                format: 'MM yyyy'
            });

            $(".chosen").chosen();

            $(".chosen-multi").chosen({ disable_search_threshold: 10, multiple: true });
        }
    };
}();

jQuery(document).ready(function () {
    dates.init();
});

var btns = function () {
    return {
        init: function () {
            $(".save-btn").bind("click", function () {
                $(".save-btn").val("Saving...");
                $(".save-btn").attr("disabled", true);
            });
            $(".submit-btn").bind("click", function () {
                $(".submit-btn").val("Submitting...");
                $(".submit-btn").attr("disabled", true);
            });
            $(".add-btn").bind("click", function () {
                $(".add-btn").val("Adding...");
                $(".add-btn").attr("disabled", true);
            });
            $(".upload-btn").bind("click", function () {
                $(".add-btn").val("Uploading...");
                $(".add-btn").attr("disabled", true);
            });
        }
    };
}();

jQuery(document).ready(function () {
    btns.init();
});

var validations = function () {
    return {
        init: function () {
            $('.numeric').keypress(function (evt) {
                var charCode = (evt.which) ? evt.which : event.keyCode;
                if ((charCode >= 48 && charCode <= 57) || charCode == 8 || charCode == 190 || charCode == 188 || charCode == 46 || charCode == 44) {
                    return true;
                }
                else {
                    notify("This field requires numbers only!", "error", "center");
                    return false;
                }
            });

            $('.phone').keypress(function (evt) {
                var charCode = (evt.which) ? evt.which : event.keyCode;
                if ((charCode >= 48 && charCode <= 57) || charCode == 8 || charCode == 47 || charCode == 45 || charCode == 32 || charCode == 43) {
                    return true;
                }
                else {
                    notify("Enter valid phone number characters only!", "error", "center");
                    return false;
                }
            });

            $('.text-only').keypress(function isTextOnly(evt) {
                var charCode = (evt.which) ? evt.which : event.keyCode;
                if ((charCode >= 48 && charCode <= 57) || charCode == 190 || charCode == 188 || charCode == 46 || charCode == 44) {
                    notify("Numeric input not allowed for this field!", "error", "center");
                    return false;
                }
                else {
                    return true;
                }
            });
        }
    };
}();

jQuery(document).ready(function () {
    validations.init();
});

$(function () {
    $('.btn-disable').bind("click", function () {
        //$("[id*=btnDisburse]").val("Updating...");
        $('.btn-disable').attr("disabled", true);
    });
});
var config = {
    '.chosen-select': {},
    '.chosen-select-deselect': { allow_single_deselect: true },
    '.chosen-select-no-single': { disable_search_threshold: 10 },
    '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
    '.chosen-select-width': { width: "95%" }
}
for (var selector in config) {
    $(selector).chosen(config[selector]);
};

function disableButton(ctl, msg) {
    //$(ctl).prop('disabled', true);
    //$(ctl).attr("disabled", true);
    //$(ctl).val(msg);
    return true;
};

function notify(txt, noteType, layout) {
    layout = layout || 'top';
    var n = noty({
        layout: layout,
        theme: 'relax',
        type: noteType,
        text: txt,
        timeout: 10000
    });
};

function isDelete() {
    return confirm("Are you sure you want to delete this record?");
};

function isnumeric(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if ((charCode >= 48 && charCode <= 57) || charCode == 8 || charCode == 190 || charCode == 188 || charCode == 46 || charCode == 44) {
        return true;
    }
    else {
        notify("This field requires numbers only!", "error", "center");
        return false;
    }
};

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if ((charCode >= 48 && charCode <= 57) || charCode == 8 || charCode == 190 || charCode == 188 || charCode == 46 || charCode == 44) {
        return true;
    }
    else {
        notify("This field requires numbers only!", "error", "center");
        return false;
    }
};

function isPhoneNo(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if ((charCode >= 48 && charCode <= 57) || charCode == 8 || charCode == 47 || charCode == 45 || charCode == 32 || charCode == 43) {
        return true;
    }
    else {
        notify("Enter valid phone number characters only!", "error", "center");
        return false;
    }
};

function isTextOnly(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if ((charCode >= 48 && charCode <= 57) || charCode == 190 || charCode == 188 || charCode == 46 || charCode == 44) {
        notify("Numeric input not allowed for this field!", "error", "center");
        return false;
    }
    else {
        return true;
    }
};