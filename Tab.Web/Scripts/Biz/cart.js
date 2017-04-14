var cart = function () {


    var vueInit = function () {
        var vm = new Vue({
            el: '#app',
            data: {
                percent: 10,
                carts: [{
                    selected: true,
                    src: '../Content/images/pro0.jpg',
                    name: '123',
                    type: '123',
                    price: 30,
                    num: 0,
                    total: 30,

                },{
                selected: true,
                src: '../Content/images/pro0.jpg',
                name: '123',
                type: '123',
                price: 30,
                num: 0,
                total: 30,

            }],
            },
            computed: {
                TotalPrice: function () {
                    var self = this;
                    var total = 0;
                    var len = self.carts.length;
                    for (len; len--;)
                    {
                        if (self.carts[len].selected)
                        {
                            total += self.carts[len].total;
                        }
                    }
                    return total;
                },
                TotalNum: function () {
                    var self = this;
                    var num = 0;
                    var len = self.carts.length;
                    for (len; len--;) {
                        if (self.carts[len].selected) {
                            num += self.carts[len].num;
                        }
                    }
                    return num;
                },
                SelectedAll: {
                    get: function () {
                        var self = this;
                        var flag = true;
                        var len = self.carts.length;
                        for (len; len--;) {
                            if (!self.carts[len].selected) {
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
                            self.carts[len].selected = newvalue;
                        }
                    }
                }
            },
            methods: {
                add: function (index) {
                    var self = this;
                    var value = self.carts[index].num;
                    self.carts[index].num = ++value;
                    self.carts[index].total = self.carts[index].price * self.carts[index].num;
                },
                minus: function (index) {
                    var self = this;
                    var value = self.carts[index].num;
                    if (value > 0) {
                        self.carts[index].num=--value;
                    }
                    self.carts[index].total = self.carts[index].price * self.carts[index].num;
                },
                del: function () { },
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