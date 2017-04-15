var cart = function () {


    var vueInit = function () {
        var vm = new Vue({
            el: '#app',
            data: {
                percent: 10,
                carts: [],
            },

            mounted: function () {
                var self = this;
                $.ajax({
                    url: '/Home/GetCarts',
                    type: 'get',
                    dataType: 'json',
                    success: function (res) {
                        self.carts = $.extend([], res);
                    }
                });
            },
            computed: {
                TotalPrice: function () {
                    var self = this;
                    var Total = 0;
                    var len = self.carts.length;
                    for (len; len--;)
                    {
                        if (self.carts[len].Selected)
                        {
                            Total += self.carts[len].Total;
                        }
                    }
                    return Total;
                },
                TotalNum: function () {
                    var self = this;
                    var Num = 0;
                    var len = self.carts.length;
                    for (len; len--;) {
                        if (self.carts[len].Selected) {
                            Num += self.carts[len].Num;
                        }
                    }
                    return Num;
                },
                SelectedAll: {
                    get: function () {
                        var self = this;
                        var flag = true;
                        var len = self.carts.length;
                        if (len == 0)
                        {
                            flag = false;
                        }
                        for (len; len--;) {
                            if (!self.carts[len].Selected) {
                                flag = false;
                                break;
                            }
                        }
                        return flag;
                    },
                    set: function (newvalue) {
                        var self = this;
                        var flag = true;
                        var len = self.carts.length;
                        for (len; len--;) {
                            self.carts[len].Selected = newvalue;
                        }
                    }
                }
            },
            methods: {
                add: function (index) {
                    var self = this;
                    var value = self.carts[index].Num;
                    self.carts[index].Num = ++value;
                    self.carts[index].Total = self.carts[index].Price * self.carts[index].Num;
                    $.ajax({
                        url: '/Home/AddNum',
                        type: 'post',
                        data: {
                            RowGuid: self.carts[index].RowGuid
                        },
                        dataType: 'json',
                        success: function (res) {
                        }
                    });

                },
                minus: function (index) {
                    var self = this;
                    var value = self.carts[index].Num;
                    if (value > 0) {
                        self.carts[index].Num = --value;
                        $.ajax({
                            url: '/Home/MinusNum',
                            type: 'post',
                            data: {
                                RowGuid: self.carts[index].RowGuid
                            },
                            dataType: 'json',
                            success: function (res) {
                            }
                        });
                    }
                    self.carts[index].Total = self.carts[index].Price * self.carts[index].Num;
                },
                del: function (index) {
                    var self = this;
                    $.ajax({
                        url: '/Home/DeleteCart',
                        type: 'post',
                        data: {
                            RowGuid: self.carts[index].RowGuid
                        },
                        dataType: 'json',
                        success: function (res) {
                        }
                    });
                    self.carts.splice(index, 1);
                },
                settlement: function () {
                    location.href = '/Home/Order';
                }
            }
        });
    };
    var init = function () {
        vueInit();
    }

    init();
}();