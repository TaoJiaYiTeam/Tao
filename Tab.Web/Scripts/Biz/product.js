var product = function () {


    var vueInit = function () {
        var vm = new Vue({
            el: '#app',
            data: {
                Products: [],
                CartsNum:0
            },
            mounted: function () {
                var self = this;
                $.ajax({
                    url: '/Home/InitInfo',
                    type: 'get',
                    dataType: 'json',
                    success: function (res) {
                        self.Products = $.extend([], res.Products);
                        self.CartsNum = res.CartsNum != null ? res.CartsNum : 0;
                    }
                });
            },
            methods: {
                addToCart: function (rowGuid) {
                    var self = this;
                    $.ajax({
                        url: '/Home/AddToCart',
                        type: 'post',
                        data: {
                            RowGuid: rowGuid
                        },
                        dataType: 'json',
                        success: function (res) {
                            self.CartsNum = self.CartsNum+1;
                        }
                    });

                }
            }
        });
    };
    var init=function(){
        vueInit();
    }

    init();
}();