/*
 * Localized default methods for the jQuery validation plugin.
 * Locale: PT_BR
 */

/*as validaçoes do Jquery Validate são no formato americano como estamos no Brasil temos que colocar no formato PT-BR
as validações de moeda (R$) e data (DD/MM/YYYY)
Essa alteração vai sobreescrever as validações*/
jQuery.extend(jQuery.validator.methods, {
    date: function (value, element) {
        return this.optional(element) || /^\d\d?\/\d\d?\/\d\d\d?\d?$/.test(value);
    },
    number: function (value, element) {
        return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:\.\d{3})+)(?:,\d+)?$/.test(value);
    }
});

/*Jquery Money*/