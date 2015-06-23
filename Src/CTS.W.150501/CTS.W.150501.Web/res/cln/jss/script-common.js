
//menu mobi
jQuery.noConflict();
jQuery(function () {
    jQuery('nav#menu_mb_ll').mmenu();
});
jQuery(document).ready(function () {
    //jQuery('.flags').prepend(jQuery('.flags li:last'));
    menu_cate();
});
function menu_cate() {
    jQuery('.nav-list li').each(function (i) {
        var html = jQuery(this).html();
        html = "<li class='mn_top_mb-item'>" + html + "</li>";
        jQuery('#mm-0').append(html);

    });
}
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




///////////////////////////////
var isBoolean = function (data) {
    return data === true
      || data === 'True'
      || data === 'true'
      || data === false
      || data === 'False'
      || data === 'false';
};
var toBoolean = function (data) {
    return data === true
      || data === 'True'
      || data === 'true'
      || data === '1';
};
var toJSON = function (data) {
    // Khởi tạo biến cục bộ
    var json = {}, array = [];
    // Duyệt danh sách dữ liệu 
    for (var i in data) {
        // Khởi tạo biến cục bộ
        var obj = data[i];
        // Trường hợp kiểu dữ liệu là đối tượng
        if (jQuery.isPlainObject(obj)) {
            // Khởi tạo biến cục bộ
            var pn = obj.name || obj.key || obj.Key;
            var pv = obj.value || obj.Value;
            // Gán giá trị vào đối tượng json
            if (jQuery.isArray(pv)) {
                json[pn] = toJSON(pv);
            } else {
                if (typeof (pv) === 'string') {
                    if (isBoolean(pv)) {
                        pv = toBoolean(pv);
                    }
                }
                json[pn] = pv;
            }
        } // Trường hợp kiểu dữ liệu là mảng
        else if (jQuery.isArray(obj)) {
            // Thêm vào dữ liệu vào mảng
            array.push(toJSON(obj));
        } // Trường hợp kiểu dữ liệu là chuỗi
        else if (typeof (obj) === 'string') {
            if (isBoolean(obj)) {
                obj = toBoolean(obj);
            }
            array.push(obj);
        }
    }
    // Trường hợp dữ liệu là mảng
    if (array.length !== 0) {
        return array;
    }
    // Kết quả xử lý
    return json;
};

/*form send mail*/
var $ = (jQuery);
var m_validator = null;
var isLoaded_validator = false;
this.get_validator = function () {
    if (!isLoaded_validator) {
        m_validator = $(".alert_textbox_inputText");
    }
    isLoaded_validator = true;
}

// Hide span validator
this.hideValidator = function () {
    this.get_validator();
    if (m_validator != null) {
        m_validator.css("display", "none");
    }
    $('.alert_textbox_inputText').css('display', 'none');

}

function ResetForm() {
    var arrInput = $(".contact_form :text, .contact_form textarea");
    if (arrInput && arrInput.length > 0) {
        for (var i = 0; i < arrInput.length; i++)
            arrInput[i].value = "";
    }
}
