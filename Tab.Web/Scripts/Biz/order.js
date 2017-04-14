var order = function () {
    var vueInit = function () {
        var vm = new Vue({
            el: '#app',
            data: {
                percent: 10,
                collapseValue: [1, 2, 3, 4, 5],
                paytype: 'weixin',
                columns1: [
                    {
                        title: '产品名称',
                        key: 'name'
                    },
                    {
                        title: '单价',
                        key: 'age'
                    },
                    {
                        title: '数量',
                        key: 'address'
                    },
                    {
                        title: '总价',
                        key: 'total'
                    }
                ],
                data1: [
                    {
                        name: '王小明',
                        age: 18,
                        address: '北京市朝阳区芍药居',
                        total:10
                    },
                    {
                        name: '张小刚',
                        age: 25,
                        address: '北京市海淀区西二旗',
                        total: 10
                    },
                    {
                        name: '李小红',
                        age: 30,
                        address: '上海市浦东新区世纪大道',
                        total: 10
                    },
                    {
                        name: '周小伟',
                        age: 26,
                        address: '深圳市南山区深南大道',
                        total: 10
                    }
                ],
                cityList: [{ value: '苏州', label: "苏州" }],
                areaList: [{ value: '吴中区', label: "吴中区" },{ value: '园区', label: "园区" }]
            },
            methods: {
                add: function () { },
                minus: function () { },
                del: function () { }

            }
        });
    };
    var init = function () {
        vueInit();
    }
    init();
}();