var Report = Report || {};

(function () {
    var self = this;
    var enabledStatuses = [Dictionaries.MailStatus.New];
    var changeableStatuses = [Dictionaries.MailStatus.Error];

    self.Initialize = function () {
        $('select.app-mail-status > option').each(function (index, element) {
            var value = +$(element).val();

            if (enabledStatuses.indexOf(value) == -1) {
                $(element).attr('disabled', 'true');
            }
        });

        $('select.app-mail-status').each(function (index, element) {
            var value = +$('#' + element.id + '  :selected').val();

            if (changeableStatuses.indexOf(value) == -1) {
                $(element).attr('disabled', 'true');
            }
        });
    };

}).apply(Report);