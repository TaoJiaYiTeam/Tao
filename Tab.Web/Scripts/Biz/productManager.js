$(function () {

    var studentDaily = function () {
        var $table = $("#myTable");

        var defaults = {
            searchForm: {
                Name: '',
                ImgUrl: '',
                Price: '',
                Stock: '',
                Category:'',
            },
        }
        var vms = {
            searchVm: null,
            detailVm: null
        };
        var VueInit = function () {
            vms.searchVm = new Vue({
                el: '#app',
                data: {
                    form: $.extend({}, defaults.searchForm),
                    roles: []
                },
                mounted: function () {
                    var self = this;
                    //$.ajax({
                    //    url: '/Config/GetRoles',
                    //    type: 'get',
                    //    dataType: 'json',
                    //    success: function (res) {
                    //        console.log(res);
                    //        self.roles = $.extend([], res);
                    //    }
                    //});
                },
                methods: {
                    add: function () {
                        var self = this;
                        $.ajax({
                            url: '/Config/InsertProduct',
                            data: self.form,
                            type: 'post',
                            dataType: 'json',
                            success: function (res) {
                                if (res) {
                                    toastr.info('添加成功', '');
                                    self.form = $.extend({}, defaults.searchForm)
                                    $('#myTable').bootstrapTable('refresh');
                                } else {
                                    toastr.error('添加失败', '');
                                }
                            }
                        });
                    },
                }
            });
        }
        var tableInit = function () {
            $table.bootstrapTable({
                url: '/Config/GetProductList',
                dataType: "json",
                pagination: true, //分页
                showRefresh:true,
                queryParams: function (params) {
                    return $.extend({}, { pagesize: params.limit, offset: params.offset }, vms.searchVm.searchForm);
                },
                sidePagination: "server", //服务端处理分页
                columns: [{
                    field: 'Name',
                    title: '产品名称',
                }, {
                    field: 'SupplierName',
                    title: '供应商'
                }, {
                    field: 'ImgUrl',
                    title: '图片路径'
                }, {
                    field: 'Price',
                    title: '售价'
                }, {
                    field: 'Stock',
                    title: '库存'
                }, {
                    field: 'Category',
                    title: '分类'
                },
                {
                    field: 'SelledNum',
                    title: '已售数量'
                }, {
                    title: '操作',
                    align: 'center',
                    formatter: function () {
                        return '<a class="btn btn-danger btn-outline detail" href="javascript:void(0);"><i class="fa fa-trash"></i>删除</button>'
                    },
                    events: {
                        'click .detail': function (event, value, row, index) {
                            $.ajax({
                                url: '/Config/DeleteProduct',
                                type: 'post',
                                data: row,
                                success: function (res) {
                                    if (res) {
                                        toastr.info('删除成功', '');
                                        $('#myTable').bootstrapTable('refresh');
                                    } else {
                                        toastr.error('删除失败', '');
                                    }

                                }

                            })
                        }
                    }
                }],

            });
        };


        var init = function () {
            VueInit();
            tableInit();
        };

        init();
    }();
})