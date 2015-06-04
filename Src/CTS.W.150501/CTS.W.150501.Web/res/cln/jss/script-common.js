﻿//menu mobi
jQuery.noConflict();
jQuery(function () {
    jQuery('nav#menu_mb_ll').mmenu();
});

function DropDown(el) {
    this.dd = el;
    this.placeholder = this.dd.children('span');
    this.opts = this.dd.find('ul.dropdown > li');
    this.val = '';
    this.index = -1;
    this.initEvents();
}
DropDown.prototype = {
    initEvents: function () {
        var obj = this;

        obj.dd.on('click', function (event) {
            jQuery(this).toggleClass('active');
            return false;
        });

        obj.opts.on('click', function () {
            var opt = jQuery(this);
            obj.val = opt.html();
            obj.index = opt.index();
            obj.placeholder.html(obj.val);
        });
    },
    getValue: function () {
        return this.val;
    },
    getIndex: function () {
        return this.index;
    }
}

jQuery(function () {

    var dd = new DropDown(jQuery('#dd'));

    jQuery(document).click(function () {
        // all dropdowns
        jQuery('.wrapper-dropdown-1').removeClass('active');
    });

});
