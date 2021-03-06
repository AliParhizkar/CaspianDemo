﻿(function ($) {
    var $t = $.telerik, self_;

    function isLocalUrl(url) {
        var loweredUrl = url ? url.toLowerCase() : '';
        return loweredUrl && loweredUrl.indexOf('http') !== 0 && loweredUrl.indexOf('https') !== 0;
    }

    // zoom animation

    $t.fx.zoom = function (element) {
        this.element = element;
    };

    $t.fx.zoom.prototype = {
        play: function (options, end) {
            var $element = this.element.show();
            var parent = $element.offsetParent()[0];
            var left = ($(window).width() - $element.width()) / 2 - parent.offsetLeft;
            var startTop = (index % 2) == 1 ? 0 : 20;
            var index = $('.t-window').index($element);
            //if (index > 0 && !this.parentChaild) {
            //    startTop = $('.t-window').eq(index - 1).offset().top + 30;
            //}
            startTop -= parent.offsetTop;
            
            $element.css('display', 'block').css('left', left);
            $element.css({
                top: 0 + 10 * (index % 2)
            }).animate({
                top: startTop + 10 * (index % 2)
            }, options.openDuration);
        },

        rewind: function (options, end) {
            var $element = this.element;

            var resizeElement = $element.find('> .t-window-content');
            var endValues = {
                //width: resizeElement.width(),
                height: resizeElement.height(),
                //left: parseInt($element.css('left')),
                top: parseInt($element.css('top'))
            };


            $element.animate({
                left: endValues.left + 20,
                top: endValues.top + 20
            }, options.closeDuration, function () {
                $element.css({
                    left: endValues.left,
                    top: endValues.top
                }).hide();
                resizeElement.css({
                    width: endValues.width,
                    height: endValues.height
                });
                if (end)
                    end();
            });
        }
    }

    $t.fx.zoom.defaults = function () {
        return { list: [{ name: 'zoom'}], openDuration: 'fast', closeDuration: 'fast' };
    };

    $t.window = function (element, options) {
        this.element = element;
        var $element = $(element);
        $.extend(this, options);
        $(window).bind('resize', 'windowBindToResize__', function () {
            $element.css('left', $(window).scrollLeft() +
                Math.max(0, ($(window).width() - $element.width()) / 2) - 10);
            //$element.find('> .t-window-content').width($(window).width() - 20);
            //$element.css('top', $(window).scrollTop() + Math.max(0, ($(window).height() - $element.height()) / 2));
        });
        if (!$element.is('.t-window')) {
            $element.addClass('t-widget t-window');
            $t.window.create(element, options);
        }

        let windowActions = '.t-window-titlebar .t-window-action';
        let self_ = this;
        $element.find('.fa-time').click(function () {
            self_.close();
        });
        $element
            //.delegate(windowActions, 'mouseenter', $t.hover)
            //.delegate(windowActions, 'mouseleave', $t.leave)
            .delegate(windowActions, 'click', $.proxy(this.windowActionHandler, this));

        if (this.resizable) {
            $element
                .delegate('.t-window-titlebar', 'dblclick', $.proxy(this.toggleMaximization, this))
                .append($t.window.getResizeHandlesHtml());

           

            (function (wnd) {

                function start(e) {
                    var $element = $(wnd.element);

                    wnd.initialCursorPosition = $element.offset();

                    wnd.resizeDirection = e.$draggable.attr('className').replace('t-resize-handle t-resize-', '').split('');

                    wnd.resizeElement = $element.find('> .t-window-content');

                    wnd.initialSize = {
                        width: wnd.resizeElement.width(),
                        height: wnd.resizeElement.height()
                    };

                    wnd.outlineSize = {
                        left: wnd.resizeElement.outerWidth() - wnd.resizeElement.width()
                            + $element.outerWidth() - $element.width(),
                        top: wnd.resizeElement.outerHeight() - wnd.resizeElement.height()
                            + $element.outerHeight() - $element.height()
                            + $element.find('> .t-window-titlebar').outerHeight()
                    }

                    //$('<div class="t-overlay" />').appendTo(wnd.element);

                    $element.find('.t-resize-handle').not(e.$draggable).hide();

                    $(document.body).css('cursor', e.$draggable.css('cursor'));
                }

                function drag(e) {
                    var $element = $(wnd.element);
                    var resizeHandlers = {
                        'e': function () {
                            var width = e.pageX - wnd.initialCursorPosition.left - wnd.outlineSize.left;
                            wnd.resizeElement.width(width < wnd.minWidth
                                                        ? wnd.minWidth
                                                        : wnd.maxWidth && width > wnd.maxWidth
                                                        ? wnd.maxWidth
                                                        : width);
                        },
                        's': function () {
                            var height = e.pageY - wnd.initialCursorPosition.top - wnd.outlineSize.top;
                            wnd.resizeElement
                                    .height(height < wnd.minHeight ? wnd.minHeight
                                            : wnd.maxHeight && height > wnd.maxHeight ? wnd.maxHeight
                                            : height);
                        },
                        'w': function () {
                            var windowRight = wnd.initialCursorPosition.left + wnd.initialSize.width;

                            $element.css('left', e.pageX > windowRight - wnd.minWidth ? windowRight - wnd.minWidth
                                                : e.pageX < windowRight - wnd.maxWidth ? windowRight - wnd.maxWidth
                                                : e.pageX);

                            var width = windowRight - e.pageX;
                            wnd.resizeElement.width(width < wnd.minWidth ? wnd.minWidth
                                                    : wnd.maxWidth && width > wnd.maxWidth ? wnd.maxWidth
                                                    : width);

                        },
                        'n': function () {
                            var windowBottom = wnd.initialCursorPosition.top + wnd.initialSize.height;

                            $element.css('top', e.pageY > windowBottom - wnd.minHeight ? windowBottom - wnd.minHeight
                                                : e.pageY < windowBottom - wnd.maxHeight ? windowBottom - wnd.maxHeight
                                                : e.pageY);

                            var height = windowBottom - e.pageY;
                            wnd.resizeElement
                                    .height(height < wnd.minHeight ? wnd.minHeight
                                            : wnd.maxHeight && height > wnd.maxHeight ? wnd.maxHeight
                                            : height);
                        }
                    };

                    $.each(wnd.resizeDirection, function () {
                        resizeHandlers[this]();
                    });

                   

                    $t.trigger(wnd.element, 'resize');
                }

                function stop(e) {
                    var $element = $(wnd.element);
                    $element
                        .find('.t-overlay').remove().end()
                        .find('.t-resize-handle').not(e.$draggable).show();
                    $(document.body).css('cursor', '');
                    if (e.keyCode === 27) {
                        $element.css(wnd.initialCursorPosition);
                        wnd.resizeElement.css(wnd.initialSize);
                    }

                    return false;
                }

                new $t.draggable({
                    owner: wnd.element,
                    selector: '.t-resize-handle',
                    scope: wnd.element.id + '-resizing',
                    distance: 0,
                    start: start,
                    drag: drag,
                    stop: stop
                });
            })(this);
        }
        
        $t.bind(this, {
            open: this.onOpen,
            activated: this.onActivate,
            close: this.onClose,
            refresh: this.onRefresh,
            resize: this.onResize,
            error: this.onError,
            load: this.onLoad,
            move: this.onMove
        });
        $(window).resize($.proxy(this.onDocumentResize, this));
        if (isLocalUrl(this.contentUrl))
            this.ajaxRequest();
    };

    $t.window.prototype = {
        updateState: function (options) {
            
            $.extend(this, options);
            let $moveItem = $(this.element).find('.t-window-titlebar')
            $moveItem.unbind('mousedown.bindwindowdraging');
            $('body').unbind('mousemove.bindwindowdraging');
            $moveItem.css('cursor', 'default');
            
            if (this.draggable) {
                $moveItem.css('cursor', 'move');
                $moveItem.bind("mousedown.bindwindowdraging", function (e) {
                    self_ = $(e.target).closest('.t-window').data('tWindow');
                    self_.mousedown = true;
                    self_.mousePos = { left: e.pageX, top: e.pageY };
                    self_.windowpos = $(self_.element).offset();
                    
                });

                $('body').bind("mousemove.bindwindowdraging", function (e) {
                    if (self_ && self_.mousedown) {
                        
                        var parent = $(self_.element).offsetParent()[0];
                        let left = (e.pageX - self_.mousePos.left - parent.offsetLeft) + self_.windowpos.left;
                        let top = (e.pageY - self_.mousePos.top - parent.offsetTop) + self_.windowpos.top;
                        console.log(left);
                        $(self_.element).css('left', left).css('top', top);
                    }
                });
                $('body').mouseup(function () {
                    if (self_)
                        self_.mousedown = false;
                });
            }
            var $element = $(this.element);
            if (!this.parentChaild && !$element.parent().is('body')) {
                //var offset;
                //if ($element.is(':visible')) {
                //    offset = $element.offset();
                //    $element.css({ top: offset.top });
                //} else {
                //    $element.css({ visibility: 'hidden', display: '' });
                //    offset = $element.offset();
                //    $element.css({ top: offset.top, left: offset.left })
                //        .css({ visibility: 'visible', display: 'none' });
                //}
                $element
                    .toggleClass('t-rtl', $element.closest('.t-rtl').length > 0)
                    .appendTo(document.body);
            }
            switch (options.status) {
                case 1:
                    this.close();
                    break;
                case 2:
                    if (!this.isOpened)
                        this.open()
                    break;
            }
        },
        size: function (width, height) {
            var $element = this.element;
            var resizeElement = $(this.element).find('> .t-window-content');
            resizeElement.css('max-width', width);
            resizeElement.width($(window).width() - 20);
            resizeElement.css('min-height', height);
            resizeElement.height('auto');
        },

        overlay: function (visible) {
            if (!this.overlayItem) {
                var self_ = this;
                var $item = $('<div class="t-overlay" />').toggle(visible);
                if (this.windowId == 0)
                    $item.appendTo('body');
                else {
                    $('.t-window').each(function () {
                        var win = $(this).data('tWindow');
                        if (win && win.windowId == self_.windowId - 1)
                            if (($(this).css('display')) == 'block')
                                $item.appendTo(this);     
                    });
                }
                this.overlayItem = $item;
            }
            return this.overlayItem;
        },

        windowActionHandler: function (e) {
            var $target = $(e.target).closest('.t-window-action').find('.fa'),
                contextWindow = this;

            $.each({
                'fa-times': this.close,
                't-maximize': this.maximize,
                't-restore': this.restore,
                't-refresh': this.refresh
            }, function (commandName, handler) {
                if ($target.hasClass(commandName)) {
                    e.preventDefault();
                    handler.call(contextWindow);
                    return false;
                }
            });
        },

        center: function () {
            var $element = $(this.element),
                $window = $(window);
            $element.css({
                left: $window.scrollLeft() + Math.max(0, ($window.width() - $element.width()) / 2 - 10),
                top: $window.scrollTop() + 10
            });

            return this;
        },

        validateElements: function(){
            return !$(this.element).checkError();
        },

        title: function (text) {
            var $title = $('.t-window-titlebar > .t-window-title', this.element);

            if (!text)
                return $title.text();

            $title.text(text);
            return this;
        },

        content: function (html) {
            var $content = $('> .t-window-content', this.element);
            if (!html)
                return $content.html();
            $content.html(html);
            this.formContentUrl = null;
            return this;
        },
        position: function (left, top) {
            var $element = $(this.element), $window = $(window);
            if (left === null)
                left = $window.scrollLeft() + Math.max(0, ($window.width() - $element.width()) / 2);
            if (top === null)
                top = $window.scrollTop() + Math.max(0, ($window.height() - $element.height()) / 2);
            $(this.element).css('left', left);
            $(this.element).css('top', top);
        },
        bindPostAndCloseEvent: function () {
            var $element = $(this.element);
            var myWindow = this;
            $element.find('a span.t-button').each(function () {
                if ($(this).attr('class') === 't-button t-cancel') {
                    $(this).click(function () {
                        myWindow.close();
                    });
                }
                if ($(this).attr('class') === 't-button t-insert') {
                    $(this).click(function () {
                        if ($(this).attr('disabled') === 'disabled')
                            return;
                        if (myWindow.url === undefined)
                            throw new Error('خطا:Url Update or Insert not exist');
                        var obj = myWindow.getObject();
                        var url = $t.getUrlQueryString(myWindow.url, myWindow.gridName);
                        if (!$(myWindow.element).checkError()) {
                            var element = $('#' + myWindow.gridName).getGrid().element;
                            var arg = { Data: myWindow.getObject(true) };
                            $t.trigger(element, "post", arg);
                            if (arg.Cancel !== true) {
                                $t.post(url, { child: obj, search: $t.getSearchObject() }, function (result) {
                                    var res = $t.gridsDataBind(result);
                                    if (res !== false) {
                                        $t.clearSearchControl();
                                        $('#' + myWindow.gridName).getGrid().focus();
                                        $t.trigger(element, 'submitChanged');
                                    }
                                    myWindow.close();
                                });
                            }
                        }
                    });
                }
            });
        },
        open: function (e) {
            this.isOpened = true;
            var $element = $(this.element);
            if (!$element.is(':visible'))
                $t.fx.play(this.effects, $element, {}, function () {
                    $t.trigger($element[0], 'activated');
                });
            if (this.modal) {
                //this.overlay($element.is(':visible')).css({ opacity: 0.5 });
                var overlay = this.overlay(false);
                if (this.effects.list.length > 0 && this.effects.list[0].name !== 'toggle')
                    overlay.css('opacity', 0).show().animate({ opacity: 0.5 }, this.effects.openDuration);
                else
                    overlay.css('opacity', 0.5).show();
            } else
                $('.t-overlay').hide();
            

            return this;
        },

        encode: function (value) {
            return (value !== null ? value + '' : '').replace(/&/g, '&amp;')
                .replace(/</g, '&lt;')
                .replace(/>/g, '&gt;');
        },
        getObject: function (isClientSide) {
            var temp = this;
            var obj = new Object();
            $.extend(obj, this.selectedObject);
            $(this.element).find('input,fieldset').each(function () {
                var item = $t.getItem($(this).attr('id'));
                if (item !== undefined) {
                    var name = $(this).attr('name');
                    var id = $(this).attr('id');
                    var value = $t.getValueOfItem(id);
                    if ($t.datepicker && item instanceof $t.datepicker) {
                        name = name.substr(0, name.length - 5);
                        value = new $t.PersianDate_(value);
                    }
                    obj[name] = value;
                }
                if ($(this).data('tUpload')) {
                    var upload = $(this).data('tUpload');
                    obj[upload.fileNameField] = upload.fileUploadName;
                }
            });
            $(this.element).find('textarea').each(function () {
                var name = $(this).attr('name');
                obj[name] = $(this).val();
            });
            var thisObject = this;
            $(this.element).find('.t-widget.t-editor.t-header').each(function () {
                var val = $(this).data('tEditor').value();
                var id = $(this).attr('id');
                obj[id] = thisObject.encode(val);
            });
            $(this.element).find('.t-ForeignKeySelector').each(function () {
                var id = $(this).attr('id');
                obj[id] = $(this).data('tReportControl').values();
            });
            return $t.convertObject(obj);
        },

        close: function () {
            //$('html, body').css('overflow', 'auto');
            $('html, body').css('padding-right', '0px');
            $('html, body').css('padding-left', '0px');
            this.isOpened = false;
            var $element = $(this.element);
            if (this.relatedControlId !== undefined) {
                var item = $('#' + this.relatedControlId).data('tTextBox');
                item.focus();
            }
            $t.hideErrorMessage();
            //if (this.isMaximized)
            //    $('html, body').css('overflow', '');
            if (this.gridName) {
                var grid = $('#' + this.gridName).data('tGrid');
                if (grid)
                    grid.focus();
            }
            var hw = $('#helpWindow').data('tHelpWindow');
            if (hw)
                hw.close();
            if ($element.is(':visible')) {

                if (!$t.trigger(this.element, 'close')) {
                    var openedModalWindows = $('.t-window').filter(function () {
                        var window = $(this);
                        return window.is(':visible') && window.data('tWindow').modal;
                    });
                    var shouldHideOverlay = this.modal && openedModalWindows.length === 1;
                    var overlay = this.modal ? this.overlay(true) : $(undefined);
                    if (shouldHideOverlay) {
                        if (this.effects.list.length > 0 && this.effects.list[0].name !== 'toggle')
                            overlay.animate({ opacity: 0 }, this.effects.closeDuration);
                        else
                            overlay.hide();
                    }
                    $t.fx.rewind(this.effects, $element, null, function () {
                        $element.hide();
                        overlay.hide();
                    });
                }
            }
        },

        toggleMaximization: function (e) {
            if (e && $(e.target).closest('.t-window-action').length > 0) return;
            this[this.isMaximized ? 'restore' : 'maximize']();
        },

        restore: function () {
            if (!this.isMaximized)
                return;

            $(this.element)
                .css({
                    position: 'absolute',
                    left: this.restorationSettings.left,
                    top: this.restorationSettings.top
                })
                .find('> .t-window-content')
                    .css({
                        width: this.restorationSettings.width,
                        height: this.restorationSettings.height
                    }).end()
                .find('.t-resize-handle').show().end()
                .find('.t-window-titlebar .t-restore').addClass('t-maximize').removeClass('t-restore');

            //$('html, body').css('overflow', '');

            this.isMaximized = false;

            $t.trigger(this.element, 'resize');

            return this;
        },

        maximize: function (e) {
            if (this.isMaximized)
                return;

            var $element = $(this.element),
                resizeElement = $element.find('> .t-window-content');

            this.restorationSettings = {
                left: $element.position().left,
                top: $element.position().top,
                width: resizeElement.width(),
                height: resizeElement.height()
            };

            $element
                .css({ left: 0, top: 0, position: 'fixed' })
                .find('.t-resize-handle').hide().end()
                .find('.t-window-titlebar .t-maximize').addClass('t-restore').removeClass('t-maximize');

            $('html, body').css('overflow', 'hidden');

            this.isMaximized = true;

            this.onDocumentResize();

            return this;
        },

        onDocumentResize: function () {
            if (!this.isMaximized)
                return;

            var $element = $(this.element),
                resizeElement = $element.find('> .t-window-content');

            resizeElement
                .css({
                    width: $(window).width()
                        - (resizeElement.outerWidth() - resizeElement.width()
                        + $element.outerWidth() - $element.width()),
                    height: $(window).height()
                        - (resizeElement.outerHeight() - resizeElement.height()
                        + $element.outerHeight() - $element.height()
                        + $element.find('> .t-window-titlebar').outerHeight())
                });

           

            $t.trigger($element, 'resize');
        },

        refresh: function (callback) {
            var obj = this;
            var data = $t.convertObject(this.getObject());
            $.telerik.post(this.formContentUrl, data, function (data) {
                var $win = $('.t-widget.t-window');
                var height = $win.height();
                var $content = $(obj.element).find('.t-window-content.t-content');
                $content.html(data);
                var newHeight = $win.height();
                $win.height(height);
                $win.css('opacity', 0.7);
                $win.animate({ height: newHeight, opacity:1 }, 500, function () {
                    $win.css('height', 'auto');
                });
                if (callback)
                    callback();
                var temp = $(window).data('ObjectData__');
                if (temp && temp.control) 
                    temp.control();
                obj.bindPostAndCloseEvent();
            });
        },

        ajaxRequest: function (url) {
            var loadingIconTimeout = setTimeout(function () {
                $('.t-refresh', this.element).addClass('t-loading');
            }, 100);

            var data = {};

            $.ajax({
                type: 'GET',
                url: url || this.contentUrl,
                dataType: 'html',
                data: data,
                cache: false,
                error: $.proxy(function (xhr, status) {
                    if ($t.ajaxError(this.element, 'error', xhr, status))
                        return;
                }, this),

                complete: function () {
                    clearTimeout(loadingIconTimeout);
                    $('.t-refresh', this.element).removeClass('t-loading');
                },
                success: $.proxy(function (data, textStatus) {
                    $('.t-window-content', this.element).html(data);

                    $t.trigger(this.element, 'refresh');
                }, this)
            });
        },

        destroy: function () {
            $(this.element).remove();

            var openedModalWindows = $('.t-window').filter(function () {
                var window = $(this);
                return window.is(':visible') && window.data('tWindow').modal;
            });

            var shouldHideOverlay = this.modal && openedModalWindows.length === 0;

            if (shouldHideOverlay)
                this.overlay(false).remove();
        }
    };

    // client-side rendering
    $.extend($t.window, {
        create: function () {
            var element, options;

            if ($.isPlainObject(arguments[0]))
                options = arguments[0];
            else {
                element = arguments[0];
                options = $.extend({
                    html: element.innerHTML
                }, arguments[1]);
            }

            options = $.extend({
                title: '',
                html: '',
                actions: ['Close']
            }, options);

            var windowHtml = new $t.stringBuilder()
                .catIf('<div class="t-widget t-window">', !element)
                    .cat('<div class="t-window-titlebar t-header">')
                        .cat('&nbsp;<span class="t-window-title">').cat(options.title).cat('</span>')
                        .cat('<div class="t-window-actions t-header">');

            $.map(options.actions, function (command) {
                windowHtml.cat('<a href="javascript: void(0)" class="t-window-action t-link">')
                        .cat('<span class="t-icon t-').cat(command.toLowerCase()).cat('">')
                            .cat(command)
                        .cat('</span></a>');
            });

            windowHtml.cat('</div></div>')
                .cat('<div class="t-window-content t-content" style="');

            //if (options.width) windowHtml.cat('width:').cat(options.width).cat('px;');
            if (options.height) windowHtml.cat('height:').cat(options.height).cat('px;');

            windowHtml.cat('">').cat(options.html).cat('</div>')
                .catIf('</div>', !element);

            if (element)
                $(element).html(windowHtml.string());
            else
                return $(windowHtml.string()).appendTo(document.body).tWindow(options);
        },

        getResizeHandlesHtml: function () {
            var html = new $t.stringBuilder();

            $.each('n e s w se sw ne nw'.split(' '), function (i, item) {
                html.cat('<div class="t-resize-handle t-resize-').cat(item).cat('"></div>');
            });

            return html.string();
        }
    });

    // jQuery extender
    $.fn.tWindow = function (options) {
        var win = $t.create(this, {
            name: 'tWindow',
            init: function (element, options) {
                return new $t.window(element, options);
            },
            success: function (component) {
                var element = component.element,
                    $element = $(element);

                if ($element.is(':visible')) {
                    $t.trigger(element, 'open');
                    $t.trigger(element, 'activated');
                }
            },
            options: options
        });
        return win;
    };

    // default options
    $.fn.tWindow.defaults = {
        effects: { list: [{ name: 'zoom' }, { name: 'property', properties: ['opacity']}], openDuration: 'fast', closeDuration: 'fast' },
        minWidth: 50,
        minHeight: 50
    };
})(jQuery);