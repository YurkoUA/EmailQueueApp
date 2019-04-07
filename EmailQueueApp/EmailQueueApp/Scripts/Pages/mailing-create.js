var MailingCreate = MailingCreate || {};

(function () {
    var self = this;

    var datePickerSelector = '#MainContent_SendingDatePicker';

    self.Initialize = function () {
        $(datePickerSelector).datetimepicker({

        });
    };

}).apply(MailingCreate);