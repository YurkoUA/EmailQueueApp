var MailingCreate = MailingCreate || {};

(function () {
    var self = this;

    var datePickerSelector = '#MainContent_SendingDatePicker';

    self.Initialize = function () {
        $(datePickerSelector).datetimepicker({
            format: 'DD.MM.YYYY HH:mm',
            defaultDate: moment.utc().toDate()
        });

        $('#MainContent_EmailAddressTextBox').change(self.ValidateAddAddressForm);
        $('#MainContent_RepeatCountTextBox').change(self.ValidateAddAddressForm);
        self.ValidateAddAddressForm();
    };

    self.ValidateAddAddressForm = function () {
        var divSelector = "#add-address-form";
        var addBtnSelector = "#MainContent_AddressAddBtn";
        var emailAddressTextBoxName = $('#MainContent_EmailAddressTextBox').attr('name');
        var repeatCountTextBoxName = $('#MainContent_RepeatCountTextBox').attr('name');
        var formId = $('form')[0].id;

        var rules = {};

        rules[emailAddressTextBoxName] = {
            required: true,
            email: true
        };

        rules[repeatCountTextBoxName] = {
            required: true,
            number: true,
            range: [1, 999]
        };

        var validator = $('#' + formId).validate({
            rules: rules,
            errorElement: 'span',
            errorClass: 'text-danger'
        });

        var isValid = validator.elements(divSelector).valid();
        $(addBtnSelector).prop('disabled', !isValid);
    };

}).apply(MailingCreate);