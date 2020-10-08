(function ($) {
    var $t = $.telerik;
    function seprate3Digit(str, start, end, keyCode, seprate) {
        var array = str.replace('-', '').split('.');
        var str1 = array[0];
        var count = 0;
        if (seprate) {
            for (var i = 0; i < start && i < array[0].length; i++)
                if (str1.charAt(i) == ',')
                    count++;
            str1 = str1.replace(/\,/g, '');
            var strTemp = "", j = 1;
            for (var i = str1.length; i > 0; i--) {
                strTemp = str1.charAt(i - 1) + strTemp;
                if (j == 3) {
                    j = 0;
                    if (i > 1)
                        strTemp = ',' + strTemp
                }
                j++;
            }
            var newCount = 0;
            var tempStart = start;
            if (strTemp.length % 4 == 1 && keyCode != 8)
                tempStart = start + 1;
            if (strTemp.length % 4 == 3 && keyCode == 8)
                tempStart = start - 1;
            for (var i = 0; i < tempStart && i < strTemp.length; i++)
                if (strTemp.charAt(i) == ',')
                    newCount++;
        }
        else
            strTemp = array[0];
        if (array.length > 1)
            strTemp += '.' + array[1];
        var pos = start + 1;
        if (keyCode == 8)
            pos = start - 1;
        if (keyCode == 46)
            pos = start;
        if (seprate) {
            if (newCount < count && (keyCode == 8 || keyCode == 46))
                pos--;
            else
                if (newCount > count)
                    pos++;
        }
        if (str.length > 0 && str[0] == '-')
            strTemp = '-' + strTemp;
        return { text: strTemp, pos: pos };
    }
    function removeStr(str, start, end, keyCode, seprate) {
        if (start == end) {
            var strTemp = "";
            if (keyCode == 8) {
                for (var i = 0; i < str.length; i++)
                    if (i != start - 1 || str[start - 1] == ',')
                        strTemp += str.charAt(i);
            }
            else {
                for (var i = 0; i < str.length; i++)
                    if (i != start || str[start] == ',')
                        strTemp += str.charAt(i);
            }
        } else {
            var strTemp = "";
            for (var i = 0; i < str.length; i++)
                if (i < start || i >= end)
                    strTemp += str.charAt(i);
        }
       
        return seprate3Digit(strTemp, start, end, keyCode, seprate);
    }
    function updateValue(element, key, total, digit, seprate) {
        if (key >= 96 && key < 106)
            key -= 48;
        var value = $(element).val(), flag = key == 190 || key == 110;
        if (digit == 0 && key == 110 || key == 190)
            return;
        var selection = $(element).getSelection();
        if (key == 8 || key == 46) {
            var obj = removeStr(value, selection.start, selection.end, key, seprate);
            $(element).val(obj.text);
            $(element).setCursorPosition(obj.pos, obj.pos);
            return;
        }
        var index = value.indexOf('.');
        if (index > -1) {
            if (value.replace(/\,/g, '').length > total)
                return;
            flag = false;
            var array = value.split('.');
            if (selection.start > index && array[1].length >= digit)
                return;
        }
        else {
            if (!flag && value.replace(/\,/g, '').length >= total && key != 37 && key != 39) {
                return;
            }
        }
        if (selection.start == 0 && (key == 109 || key == 173) && (value.indexOf('-') == -1))
            flag = true;
        if (key >= 48 && key < 58 || flag) {
            var chr = key - 48;
            var len = value.length;
            if (key == 190 || key == 110) {
                chr = '.';
                if (value.length - selection.end > digit)
                    len = selection.end + digit;
            }
            if (key == 109 || key == 173) 
                chr = '-'
            var str = value.substr(0, selection.start) + chr + value.substring(selection.end, len);
            var obj = seprate3Digit(str, selection.start, selection.end, key, seprate);
            $(element).val(obj.text);
            $(element).setCursorPosition(obj.pos, obj.pos);
        }
        if (key == 35) {
            var len = $(element).val().length;
            $(element).setCursorPosition(len, len);
        }
        if (key == 36)
            $(element).setCursorPosition(0, 0);
        if (key == 37 && selection.start > 0)
            $(element).setCursorPosition(selection.start - 1, selection.start - 1);
        if (key == 39)
            $(element).setCursorPosition(selection.start + 1, selection.start + 1);

    }
    function enableLable(element) {
        var id = $(element).attr('id');

        if ($(element).is('[disabled=disabled]'))
            $('label[for=' + id + ']').css('color', '#e5e2e2');
        else
            $('label[for=' + id + ']').css('color', '');
    }
    $t.textbox = function (element, options) {
        updateFlag = true;
        $.extend(this, options);
        $(element).mouseenter(function () {
            $(this).parent().addClass('t-state-hover');
        });
        $(element).mouseleave(function () {
            $(this).parent().removeClass('t-state-hover');
        });
        if (this.maskedText)
            $(element).mask(this.maskedText);
        this.id = $(element).attr('id');
        var thisObj = this;
        $(element).parent().find('a').click(function () {
            if (thisObj.enabled)
                thisObj.showHelpWindow();
        });
        this.element = element;
        var self = this;
        enableLable(element);
        var $element = this.$element = $(element)
            .bind({
                focus: function (e) {
                    var input = e.target;
                    if (self.errorMessage)
                        $t.showErrorMessage($(self.element).closest('.t-widget')[0], self.errorMessage)
                    setTimeout(function () {
                        if ($.browser.msie)
                            input.select();
                        else {
                            input.selectionStart = 0;
                            input.selectionEnd = input.value.length;
                        }
                    }, 10);
                    $(input).parent().removeClass('t-state-hover');
                },
                keydown: $.proxy(this._keydown, this),
                keypress: $.proxy(this._keypress, this),
                keyup: function (e) {
                    thisObj.keyIsOperate = false;
                }
            }).bind("paste", $.proxy(this._paste, this));
        var builder = new $t.stringBuilder();
        this.keyIsOperate = false;
        this.enabled = !$element.is('[disabled]');
        builder.buffer = [];
        builder.cat('[ |').cat(this.groupSeparator).catIf('|' + this.symbol, this.symbol).cat(']');
        this.replaceRegExp = new RegExp(builder.string(), 'g');
        builder.buffer = [];
        this.$text = $(builder.string()).insertBefore($element)
            .click(function (e) {
                element.focus();
            });
        this[this.enabled ? 'enable' : 'disable']();
        if (this.type != 'string') {
            this.numFormat = this.numFormat === undefined ? this.type.charAt(0) : this.numFormat;
            var separator = this.separator;
            this.step = this.parse(this.step, separator);
            this.val = this.parse(this.val, separator);
            this.minValue = this.parse(this.minValue, separator);
            this.maxValue = this.parse(this.maxValue, separator);
            this.decimals = { '190': '.', '188': ',', '110': separator };
        }
        $t.bind(this, {
            load: this.onLoad,
            valueChange: this.onValueChange,
            ekeyPress: this.onKeyPress,
            change: this.onChange
        });
        $(element).blur(function () {
            $t.hideErrorMessage($(element).closest('.t-widget')[0], self.errorMessage);
            thisObj._blur();
        });
        $(element).focus(function () {
            thisObj._focus();
        });
        if (this.group && this.type != 'string') {
            $(element).val($t.get3Digit($(element).val()));
        }
    }

    $t.textbox.prototype = {
        selection: function () {
            return $(this.element).getSelection();
        },
        updateValue: function (value) {
            this.value(value);
            this._blur();
        },
        showErrorMessage: function (msg) {
            
        },
        setKeyValues: function (items) {
            var str = "";
            var array = new Array();
            for (var i = 0; i < items.length; i++) {
                var item = items[i];
                str += item.value;
                array.push(item.key);
                if (i < items.length - 1)
                    str += ' - ';
            }
            this.keyValue = array;
            this.$element.val(str);
        },
        _paste: function (e) {
            var val = this.$element.val();
            if ($.browser.msie) {
                var selectedText = this.element.document.selection.createRange().text;
                var text = window.clipboardData.getData("Text");
                if (selectedText && selectedText.length > 0) 
                    val = val.replace(selectedText, text);
                else 
                    val += text;
            }

            if (val == '-') return true;

            var parsedValue = this.parse(val, this.separator);
            if (parsedValue || parsedValue == 0) {
                this._update(parsedValue);
            }
        },
        updateState: function (options) {
            $.extend(this, options);
            if (options.focused) 
                this.focus();
        },
        _keydown: function (e) {
            this.key = e.keyCode;
            var key = e.keyCode || e.which,
                $element = this.$element;
            var thisObj = this;
            if (this.simpleSearchUrl)
                this.type = "string";
            if (this.type != "string") {
                if (!this.digits)
                    this.digits = 0;
                if (!this.total)
                    this.total = 8;
                this.seprate = ',';
                var maxLength = $(this.element).attr("maxlength"), flag = !$(e.target).attr('readonly');
                if (maxLength) {
                    maxLength = parseInt(maxLength);
                    if ($(this.element).val().replace(/\,/g, '').length >= maxLength && (key >= 48 && key <= 58 ||
                        key >= 96 && key < 106))
                        flag = false;
                }
                if (flag) {
                    var oldValue = this.value();
                    updateValue(this.element, key, this.total, this.digits, this.group);
                    if (oldValue != this.value() && this.bindingType == 2)
                        $t.trigger(this.element, 'changeValue');
                }
                if (key == 13 || key == 9 || key == 27)
                    return true;
                return false;
            }
            setTimeout($.proxy(function () {
                
                var key = e.keyCode || e.which;
                if (key == 8) {
                    this.keyIsOperate = true;
                }
                var self_ = this;
                if (this.searchForm) {
                    //this.searchForm.open();
                }
                if (this.type == "string" && self_.valueOld !== self_.value() && this.bindingType == 2)
                    $t.trigger(this.element, 'changeValue');
                self_.valueOld = self_.value();  
            }, this));
        },
        _keypress: function (e) {
            key = e.keyCode || e.which;
            $t.trigger(this.element, 'ekeyPress', e);
            if (this.type == 'string') {
                if (this.checkNumeric && (key < 48 || key > 57))
                    e.preventDefault();
                setTimeout($.proxy(function () {

                }, this));
            }
            else
                if (key != 9)
                    e.preventDefault();
        },
        focus: function () {
            this._focus();
            this.$element.focus();
        },
        _focus: function () {
            this.tempValue = this.value();
            this.$element.css('color', this.$text.css("color"));
            this.$text.hide();
        },
        _blur: function () {
            this.$element.removeClass('t-state-error');
            if (this.type != 'string') {
                var min = this.minValue,
                max = this.maxValue,
                parsedValue = this.parse(this.$element.val());
                if (parsedValue) {
                    if (min != null && parsedValue < min) {
                        parsedValue = min;
                    } else if (max != null && parsedValue > max) {
                        parsedValue = max;
                    }
                    parsedValue = parseFloat(parsedValue.toFixed(this.digits));
                }
            }
            else
                parsedValue = this.parse(this.$element.val());
            var value = this.value();

            if (value != this.tempValue) {
                $t.trigger(this.element, 'changeValue', { dataItem: value});
            }
            if (this.closeOnBlur) {
                this.searchForm.close();
            }
        },
        _clearTimer: function (e) {
            clearTimeout(this.timeout);
            clearInterval(this.timer);
            clearInterval(this.acceleration);
        },
        _stepper: function (e, stepMod) {
            if (e.which == 1) {

                var step = this.step;

                this._modify(stepMod * step);

                this.timeout = setTimeout($.proxy(function () {
                    this.timer = setInterval($.proxy(function () {
                        this._modify(stepMod * step);
                    }, this), 80);

                    this.acceleration = setInterval(function () { step += 1; }, 1000);
                }, this), 200);
            }
        },
        _modify: function (step) {
            if (this.type != 'string') {
                var value = this.parse(this.element.value),
                min = this.minValue,
                max = this.maxValue;

                value = value ? value + step : step;

                if (min !== null && value < min) {
                    value = min;
                } else if (max !== null && value > max) {
                    value = max;
                }
                this._update(parseFloat(value.toFixed(this.digits)));
            }
        },
        _update: function (val) {
            if (this.val != val) {
                if ($t.trigger(this.element, 'valueChange', { oldValue: this.val, newValue: val })) {
                    val = this.val;
                }
            }
            this._value(val);
        },
        _value: function (value) {
            if (this.type != 'string') {
                var parsedValue = (typeof value === "number") ? value : this.parse(value, this.separator),
                text = this.enabled ? this.text : '',
                isNull = parsedValue === null;

                if (parsedValue != null) {
                    parsedValue = parseFloat(parsedValue.toFixed(this.digits));
                }
                if (this.group && value) {
                    this.$element.val($t.get3Digit(value));
                    this.$text.html($t.get3Digit(value));
                }
                else {
                    this.$element.val(isNull ? '' : this.formatEdit(parsedValue));
                    this.$text.html(isNull ? text : this.format(parsedValue));
                }
                this.val = parsedValue;


            }
            else {

                this.$element.val(this.parse(value));
                this.val = value;
                this.$text.html(value);
            }
        },
        enable: function () {
            this.enabled = true;
            this.$element.removeAttr("disabled");
            this.$element.closest('.t-widget').removeClass('t-state-disabled');
            enableLable(this.element);
        },
        disable: function () {
            this.enabled = false;
            this.$element.attr('disabled', 'disabled');
            this.$element.closest('.t-widget').addClass('t-state-disabled');
            if (!this.val && this.val != 0)
                this.$text.html('');
            else if (true == $.browser.msie)
                this.$text.hide();
            enableLable(this.element);
        },
        value: function (value) {
            if (arguments.length == 1 && value == null) {
                this.$element.val('');
                return;
            }
            if (this.type == 'numeric') {
                if (arguments.length == 0) {
                    var val = this.$element.val().replace(/\,/g, '');
                    if (val == '')
                        return null;
                    if (this.maskedText && val.indexOf('_') != -1)
                        return null;
                    return parseFloat(val);
                }
                
                if (value && value.replace)
                    value = value.replace(/\,/g, '');
                var parsedValue = (typeof value === "number") ? value : this.parse(value, this.separator);
                if (!this.inRange(parsedValue, this.minValue, this.maxValue)) {
                    parsedValue = null;
                }

                this._value(parsedValue);
            }
            else {
                if (arguments.length == 0) {
                    var val = this.$element.val().replace(/\ي/g, 'ی').replace(/\ك/g, "ک");
                    
                    if (this.maskedText && val.indexOf('_') != -1)
                        return null;
                    return val;
                }
                this._value(value);
            }
        },
        formatEdit: function (value) {
            var separator = this.separator;
            if (value && separator != '.')
                value = value.toString().replace('.', separator);
            return value;
        },
        format: function (value) {
            return $t.textbox.formatNumber(value,
                                           this.numFormat,
                                           this.digits,
                                           this.separator,
                                           this.groupSeparator,
                                           this.groupSize,
                                           this.positive,
                                           this.negative,
                                           this.symbol,
                                           true);
        },
        inRange: function (key, min, max) {
            return key === null || ((min !== null ? key >= min : true) && (max !== null ? key <= max : true));
        },
        parse: function (value, separator) {
            if (this.type != 'string') {
                var result = null;
                if (value || value == "0") {
                    if (typeof value == typeof 1) return value;

                    value = value.replace(this.replaceRegExp, '');
                    if (separator && separator != '.')
                        value = value.replace(separator, '.');

                    var negativeFormatPattern = $.fn.tTextBox.patterns[this.type].negative[this.negative]
                        .replace(/(\(|\))/g, '\\$1').replace('*', '').replace('n', '([\\d|\\.]*)'),
                    negativeFormatRegEx = new RegExp(negativeFormatPattern);

                    if (negativeFormatRegEx.test(value))
                        result = -parseFloat(negativeFormatRegEx.exec(value)[1]);
                    else
                        result = parseFloat(value);
                }
                return isNaN(result) ? null : result;
            }
            else {
                return value;
            }
        }
    }
    $.fn.tTextBox = function (options) {
        var type = 'numeric';
        if (options && options.type)
            type = options.type;
        if (type != "string") {
            var defaults = $.fn.tTextBox.defaults[type];
            defaults.digits = $t.cultureInfo[type + 'decimaldigits'];
            defaults.separator = $t.cultureInfo[type + 'decimalseparator'];
            defaults.groupSize = $t.cultureInfo[type + 'groupsize'];
            defaults.positive = $t.cultureInfo[type + 'positive'];
            defaults.negative = $t.cultureInfo[type + 'negative'];
            defaults.symbol = $t.cultureInfo[type + 'symbol'];

            options = $.extend({}, defaults, options);
        }
        else
            $.extend(this, options);
        options.type = type;
        return this.each(function () {
            var $element = $(this);
            options = $.meta ? $.extend({}, options, $element.data()) : options;

            if (!$element.data('tTextBox')) {
                $element.data('tTextBox', new $t.textbox(this, options));
                $t.trigger(this, 'load');
            }

        });
    };
    var commonDefaults = {
        val: null,
        text: '',
        inputAttributes: ''
    };
    $.fn.tTextBox.defaults = {
        numeric: $.extend(commonDefaults, {
            minValue: -100,
            maxValue: 100
        }),
        currency: $.extend(commonDefaults, {
            minValue: 0,
            maxValue: 1000
        }),
        percent: $.extend(commonDefaults, {
            minValue: 0,
            maxValue: 100
        })
    };

    // * - placeholder for the symbol
    // n - placeholder for the number
    $.fn.tTextBox.patterns = {
        numeric: {
            negative: ['(n)', '-n', '- n', 'n-', 'n -']
        },
        currency: {
            positive: ['*n', 'n*', '* n', 'n *'],
            negative: ['(*n)', '-*n', '*-n', '*n-', '(n*)', '-n*', 'n-*', 'n*-', '-n *', '-* n', 'n *-', '* n-', '* -n', 'n- *', '(* n)', '(n *)']
        },
        percent: {
            positive: ['n *', 'n*', '*n'],
            negative: ['-n *', '-n*', '-*n']
        }
    };

    if (!$t.cultureInfo.numericnegative)
        $.extend($t.cultureInfo, { //default en-US settings
            currencydecimaldigits: 2,
            currencydecimalseparator: '.',
            currencygroupseparator: ',',
            currencygroupsize: 3,
            currencynegative: 0,
            currencypositive: 0,
            currencysymbol: '$',
            numericdecimaldigits: 2,
            numericdecimalseparator: '.',
            numericgroupseparator: ',',
            numericgroupsize: 3,
            numericnegative: 1,
            percentdecimaldigits: 2,
            percentdecimalseparator: '.',
            percentgroupseparator: ',',
            percentgroupsize: 3,
            percentnegative: 0,
            percentpositive: 0,
            percentsymbol: '%'
        });

    var customFormatRegEx = /[0#?]/;

    function reverse(str) {
        return str.split('').reverse().join('');
    }

    function injectInFormat(val, format, appendExtras) {
        var i = 0, j = 0,
            fLength = format.length,
            vLength = val.length,
            builder = new $t.stringBuilder();

        while (i < fLength && j < vLength && format.substring(i).search(customFormatRegEx) >= 0) {

            if (format.charAt(i).match(customFormatRegEx))
                builder.cat(val.charAt(j++));
            else
                builder.cat(format.charAt(i));

            i++;
        }

        builder.catIf(val.substring(j), j < vLength && appendExtras)
               .catIf(format.substring(i), i < fLength);

        var result = reverse(builder.string()),
            zeroIndex;

        if (result.indexOf('#') > -1)
            zeroIndex = result.indexOf('0');

        if (zeroIndex > -1) {
            var first = result.slice(0, zeroIndex),
                second = result.slice(zeroIndex, result.length);
            result = first.replace(/#/g, '') + second.replace(/#/g, '0');
        } else {
            result = result.replace(/#/g, '');
        }

        if (result.indexOf(',') == 0)
            result = result.replace(/,/g, '');

        return appendExtras ? result : reverse(result);
    }

    $t.textbox.formatNumber = function (number,
                                        format,
                                        digits,
                                        separator,
                                        groupSeparator,
                                        groupSize,
                                        positive,
                                        negative,
                                        symbol,
                                        isTextBox) {

        if (!format) return number;

        var type, customFormat, negativeFormat, zeroFormat, sign = number < 0;

        format = format.split(':');
        format = format.length > 1 ? format[1].replace('}', '') : format[0];

        var isCustomFormat = format.search(customFormatRegEx) != -1;

        if (isCustomFormat) {
            format = format.split(';');
            customFormat = format[0];
            negativeFormat = format[1];
            zeroFormat = format[2];
            format = (sign && negativeFormat ? negativeFormat : customFormat).indexOf('%') != -1 ? 'p' : 'n';
        }

        switch (format.toLowerCase()) {
            case 'd':
                return Math.round(number).toString();
            case 'c':
                type = 'currency'; break;
            case 'n':
                type = 'numeric'; break;
            case 'p':
                type = 'percent';
                if (!isTextBox) number = Math.abs(number) * 100;
                break;
            default:
                return number.toString();
        }

        var zeroPad = function (str, count, left) {
            for (var l = str.length; l < count; l++)
                str = left ? ('0' + str) : (str + '0');

            return str;
        }

        var addGroupSeparator = function (number, groupSeperator, groupSize) {
            if (groupSeparator && groupSize != 0) {
                var regExp = new RegExp('(-?[0-9]+)([0-9]{' + groupSize + '})');
                while (regExp.test(number)) {
                    number = number.replace(regExp, '$1' + groupSeperator + '$2');
                }
            }
            return number;
        }

        var cultureInfo = cultureInfo || $t.cultureInfo,
            patterns = $.fn.tTextBox.patterns,
            undefined;

        //define Number Formating info.
        digits = digits || digits === 0 ? digits : cultureInfo[type + 'decimaldigits'];
        separator = separator !== undefined ? separator : cultureInfo[type + 'decimalseparator'];
        groupSeparator = groupSeparator !== undefined ? groupSeparator : cultureInfo[type + 'groupseparator'];
        groupSize = groupSize || groupSize == 0 ? groupSize : cultureInfo[type + 'groupsize'];
        negative = negative || negative === 0 ? negative : cultureInfo[type + 'negative'];
        positive = positive || positive === 0 ? positive : cultureInfo[type + 'positive'];
        symbol = symbol || cultureInfo[type + 'symbol'];

        var exponent, left, right;

        if (isCustomFormat) {
            var splits = (sign && negativeFormat ? negativeFormat : customFormat).split('.'),
                leftF = splits[0],
                rightF = splits.length > 1 ? splits[1] : '',
                lastIndexZero = $t.lastIndexOf(rightF, '0'),
                lastIndexSharp = $t.lastIndexOf(rightF, '#');
            digits = (lastIndexSharp > lastIndexZero ? lastIndexSharp : lastIndexZero) + 1;
        }

        var factor = Math.pow(10, digits);
        var rounded = (Math.round(number * factor) / factor);
        number = isFinite(rounded) ? rounded : number;

        var split = number.toString().split(/e/i);
        exponent = split.length > 1 ? parseInt(split[1]) : 0;
        split = split[0].split('.');

        left = split[0];
        left = sign ? left.replace('-', '') : left;

        right = split.length > 1 ? split[1] : '';

        if (exponent) {
            if (!sign) {
                right = zeroPad(right, exponent, false);
                left += right.slice(0, exponent);
                right = right.substr(exponent);
            } else {
                left = zeroPad(left, exponent + 1, true);
                right = left.slice(exponent, left.length) + right;
                left = left.slice(0, exponent);
            }
        }

        var rightLength = right.length;
        if (digits < 1 || (isCustomFormat && lastIndexZero == -1 && rightLength === 0))
            right = ''
        else
            right = rightLength > digits ? right.slice(0, digits) : zeroPad(right, digits, false);

        var result;
        if (isCustomFormat) {
            if (left == 0) left = '';

            left = injectInFormat(reverse(left), reverse(leftF), true);
            left = leftF.indexOf(',') != -1 ? addGroupSeparator(left, groupSeparator, groupSize) : left;

            right = right && rightF ? injectInFormat(right, rightF) : '';

            result = number === 0 && zeroFormat ? zeroFormat
                : (sign && !negativeFormat ? '-' : '') + left + (right.length > 0 ? separator + right : '');

        } else {

            left = addGroupSeparator(left, groupSeparator, groupSize)
            patterns = patterns[type];
            var pattern = sign ? patterns['negative'][negative]
                        : symbol ? patterns['positive'][positive]
                        : null;

            var numberString = left + (right.length > 0 ? separator + right : '');

            result = pattern ? pattern.replace('n', numberString).replace('*', symbol) : numberString;
        }
        return result;
    }

    $.extend($t.formatters, {
        number: $t.textbox.formatNumber
    });
})(jQuery);