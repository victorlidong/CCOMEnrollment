
jQuery.fn.contextPopup = function (menuData) {

    // Build popup menu HTML
    function createMenu(obj) {
        var menu = $('<ul class=contextMenuPlugin><div class=gutterLine></div></ul>')
          .appendTo(document.body);
        if (menuData.title) {
            $('<li class=header></li>').text(menuData.title).appendTo(menu);
        }
        menuData.items.forEach(function (item) {
            if (item) {
                var row = $('<li><a href="javascript:void(0);"><span></span></a></li>').appendTo(menu);
                row.find('span').text(item.label);
                if (item.action) {
                    row.find('a').click(
                        function () {
                            //回调函数传递参数，直接执行
                            item.action(obj);
                        });
                }
            } else {
                $('<li class=divider></li>').appendTo(menu);
            }
        });
        menu.find('.header').text(menuData.title);
        return menu;
    }

    // cbedit
    //添加回调函数
    this.bind('contextmenu click', function (e) {
        // Create and show menu
        var menu = createMenu(this)
          .show()
          .css({ zIndex: 1000001, left: e.pageX + 5 /* nudge to the right, so the pointer is covering the title */, top: e.pageY })
          .bind('contextmenu click', function () { return false; });
        // Cover rest of page with invisible div that when clicked will cancel the popup.
        var bg = $('<div></div>')
          .css({ left: 0, top: 0, width: '100%', height: '100%', position: 'absolute', zIndex: 1000000 })
          .appendTo(document.body)
          .bind('contextmenu click', function () {
              // If click or right click anywhere else on page: remove clean up.
              bg.remove();
              menu.remove();
              return false;
          });
        // When clicking on a link in menu: clean up (in addition to handlers on link already)
        menu.find('a').click(function () {
            bg.remove();
            menu.remove();
        });

        // Cancel event, so real browser popup doesn't appear.
        return false;
    });
    return this;
};
