$(document).ready(function () {
 
    //jQuery DataTables initialization 
    $('#StockEntryHistory').DataTable({
        "processing": true, // for show processing bar
        "serverSide": true, // for process on server side
        "orderMulti": false, // for disable multi column order
        "dom": 'rt', // for hide default global search box // little confusion? don't worry I explained in the tutorial website
        "ajax": {
            "url": "LoadData",
            "type": "POST",
            "datatype": "json"
        },
        "columns" : [
                { "data": "PRODUCT_NAME", "name": "PRODUCT_NAME", "autoWidth": true }, //index 0
                { "data": "UNIT_PRICE", "name": "UNIT_PRICE", "autoWidth": true }, //index 1
                { "data": "SUPPLIER_NAME", "name": "SUPPLIER_NAME", "autoWidth": true },             //index 2
                { "data": "QUANTITY", "name": "QUANTITY", "autoWidth": true },         //index 3
                { "data": "ENTRY_DATE", "name": "ENTRY_DATE", "autoWidth": true },   //index 4
            ]
    });

    //Apply Custom search on jQuery DataTables here
    oTable = $('#StockEntryHistory').DataTable();
    $('input#productName').on('input',function () {
        //Apply search for Employee Name // DataTable column index 0
        oTable.columns(0).search($('#productName').val().trim());
        //Apply search for Country // DataTable column index 3
        //hit search on server
        oTable.draw();
    });

    $('input#entryDate').on('input',function () {
        //Apply search for Employee Name // DataTable column index 0
        oTable.columns(4).search($('#entryDate').val().trim());
        //Apply search for Country // DataTable column index 3
        //hit search on server
        oTable.draw();
    });

    $('#supplier').change(function () {
        //Apply search for Employee Name // DataTable column index 0
        oTable.columns(2).search($('#supplier').val().trim());
        //Apply search for Country // DataTable column index 3
        //hit search on server
        oTable.draw();
    });
});