$(function () {

    $('form').each(function (index, item) { 

        var settngs = $.data(item, 'validator').settings;

        var oldErrorFunction = settngs.errorPlacement;

        settngs.errorPlacement = function (error, inputElement) {

            if (error.text() == "") {
                inputElement.closest(".inp-wrap").removeClass("error");

                inputElement.closest('.controlHolder').removeClass('invalid');

                inputElement.closest('.controlHolder').children().remove('.error-message');
            }
            else {
                inputElement.closest(".inp-wrap").addClass("error");

                inputElement.closest('.controlHolder').addClass('invalid');

                inputElement.closest('.controlHolder').children().remove('.error-message');

                inputElement.closest('.controlHolder').append('<strong class="' + 'error-message' + '">' + error.text() + '</strong>')
            }
            oldErrorFunction.call(item, error, inputElement);
        };

    });

    $.validator.addMethod("date", function (value, element) {
        var bits = value.match(/([0-9]+)/gi), str;
        if (!bits)
            return this.optional(element) || false;
        str = bits[1] + '/' + bits[0] + '/' + bits[2];
        return this.optional(element) || !/Invalid|NaN/.test(new Date(str));
        }, "");
});