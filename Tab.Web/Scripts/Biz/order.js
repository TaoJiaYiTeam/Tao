var order = function () {
    var vueInit = function () {
        var vm = new Vue({
            el: '#app',
            data: {
                percent: 10,
                collapseValue: [1, 2, 3, 4, 5],
               
                proColumns: [
                    {
                        title: '产品名称',
                        key: 'Name'
                    },
                    {
                        title: '单价',
                        key: 'Price'
                    },
                    {
                        title: '数量',
                        key: 'Num'
                    },
                    {
                        title: '总价',
                        key: 'Total'
                    }
                ],
                products: [],
                totalPrice: 0,
                provinceList: [{ value: '江苏', label: "江苏" }],
                cityList: [{ value: '苏州', label: "苏州" }],
                areaList: [{ value: '吴中区', label: "吴中区" }, { value: '园区', label: "园区" }],
                formValidate: {
                    Province: '',
                    City: '',
                    Area: '',
                    AddrDetail: '',
                    Name: '',
                    Phone: '',
                    ICCard: '',
                    Paytype: 'weixin',
                },
                ruleValidate: {
                    Province: [
                        { required: true, message: '省份不能为空', trigger: 'blur' }
                    ],
                    City: [
                       { required: true, message: '城市不能为空', trigger: 'blur' }
                    ],
                    Area: [
                        { required: true, message: '区域不能为空', trigger: 'blur' }
                    ],
                    AddrDetail: [
                      { required: true, message: '详细地址不能为空', trigger: 'blur' }
                    ],
                    Name: [
                      { required: true, message: '姓名不能为空', trigger: 'blur' }
                    ],
                    Phone: [
                      { required: true, message: '手机号不能为空', trigger: 'blur' }
                    ],
                    ICCard: [
                     { required: true, message: '身份证不能为空', trigger: 'blur' }
                    ]
                }
            },
            mounted: function () {
                var self = this;
                $.ajax({
                    url: '/Home/GetSelectProduct',
                    type: 'get',
                    dataType: 'json',
                    success: function (res) {
                        self.products = $.extend([], res.Products);
                        self.totalPrice = res.TotalPrice;
                    }
                });
            },
            methods: {
                createOrder: function (name) {
                    var self = this;
                    self.$refs[name].validate((valid) => {
                        if (valid && self.products.length > 0) {
                            this.$Message.success('提交成功!');
                        } else {
                            this.$Message.error('表单验证失败!');
                        }
                    })
                }
            }
        });
    };
    var init = function () {
        vueInit();
    }
    init();
}();