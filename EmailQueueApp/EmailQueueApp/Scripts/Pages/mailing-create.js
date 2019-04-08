var MailingCreate = MailingCreate || {};

(function () {
    var self = this;

    var datePickerSelector = '#MainContent_SendingDatePicker';

    self.Initialize = function () {
        $(datePickerSelector).datetimepicker({
            format: 'DD.MM.YYYY HH:mm',
            defaultDate: moment.utc().toDate()
        });
    };

}).apply(MailingCreate);