var EditableTable = function () {

    return {

        //main function to initiate the module
        init: function () {

            var oTable = $('#listTable').dataTable({
                "aLengthMenu": [
                    [-1],
                    ["All"] // change per page values here
                ],
                // set the initial value
                "iDisplayLength": 2000,
                "sDom": "<'row-fluid'<'span6'l><'span6'f>r>t<'row-fluid'<'span6'i><'span6'p>>",
                "sPaginationType": "bootstrap",
                "oLanguage": {
                    "sLengthMenu": "_MENU_ records per page",
                    "oPaginate": {
                        "sPrevious": "Prev",
                        "sNext": "Next"
                    }
                },
                "aoColumnDefs": [{
                        'bSortable': false,
                        'aTargets': [0]
                    }
                ]
            });
        }

    };

}();