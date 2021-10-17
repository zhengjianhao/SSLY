<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<script type="text/javascript"> 
    $(function () {
        initDataGrid();
    });
    var isFist = false;
    var rowID = 0;
    function initDataGrid() {
        $('#ttSup').combogrid({
            url: '/Supplier/LoadData',
            panelWidth: 440,
            value: 'ID',
            idField: 'ID',
            textField: 'Company',
            columns: [[ 
                    { field: 'ID', title: '编码', width: 80, align: 'center' }, 
                    {
                        field: 'Url', title: '公司名称', width: 200, align: 'center', editor: 'text',
                        formatter: function (value, row, index) {
                            if (value.length < 1) {
                                return row.Company;
                            }
                            return "<a target='_blank' href='" + value + "'>" + row.Company + "</a>";
                        }
                    },
                    {
                        field: 'CreateTime', title: '创建时间', width: 130, align: 'center',
                        formatter: function (value, row, index) {
                            return (eval(value.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"))).pattern("yyyy-MM-dd hh:mm");
                        }
                    }
            ]],
            onClickRow: function (index, row) {
                $("#SupplierID").val(row.ID);
            }
        });
    } 
</script>
<table id="ttSup"></table>
<input type="hidden" id="SupplierID" name="SupplierID" value="" />
