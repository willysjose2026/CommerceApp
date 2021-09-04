$(document).ready(function(){
    $('#product').val(0);
    $('#customer').val(0);
    $('#product').change(function(){
        var productId = $('#product').val();
        GetUnitPrice(productId);
        GetUnitMeasure(productId);
        GetStockAvailability(productId);
         
    });

    $('#customer').change(function(){
        var customerId = $('#customer').val();
        GetSuscriptionType(customerId);
    })

    $('#txtQuantity').change(function(){
        CalculateSubtotal();
    });

    $('#AddItem').click(function(){
        AddProductToList();
    })

    $('#Billing').click(function(){
        CalculateTotalBilling();
    })

    $('#CheckIn').click(function(){
        CheckIn();
    })
});

function CalculateTotalBilling(){
    var billSubtotal = $('#txtTotal').val();
    var billDiscount = 0
    $('#productTable').find("tr:gt(0)").each(function(){
        var discount = parseFloat($(this).find('td:eq(6)').text());
        billDiscount += discount;
    })

    $('#billSubtotal').val(parseFloat(billSubtotal).toFixed(2));
    $('#totalDiscount').val(parseFloat(-1*billDiscount).toFixed(2));
    var customerName = $('#customer option:selected').text()
    $('#customerName').text(customerName);
    var totalBT = billSubtotal-billDiscount;
    
    GetItbis(totalBT);
}

function GetItbis(totalBT){
    $.ajax({
        async: true,
        type: 'GET',
        dataType: 'JSON',
        contentType: 'application/json charset=utf-8',
        data: {totalBT: totalBT},
        url: 'GetItbis',
        success: function(data){
            $('#billITBIS').val(parseFloat(data.ITBIS).toFixed(2));
            $('#billTotal').val(parseFloat(data.Total).toFixed(2));
        },
        error: function(){
            alert('Error al calcular ITBIS!')
        }
    })
}

function CheckIn(){
    var Invoice = {}
    var ListInvoiceItems = new Array();

    Invoice.customerId = $('#customer').val()
    Invoice.invoiceTotal = $('#billTotal').val()
    Invoice.Discount = $('#totalDiscount').val() * -1

    $('#productTable').find("tr:gt(0)").each(function(){
        var InvoiceItemsDTO = {};
        InvoiceItemsDTO.ProductId = parseInt($(this).find('td:eq(0)').text());
        InvoiceItemsDTO.Quantity = parseFloat($(this).find('td:eq(4)').text());
        InvoiceItemsDTO.TotalPrice = parseFloat($(this).find('td:eq(7)').text());
        InvoiceItemsDTO.Discount = parseFloat($(this).find('td:eq(6)').text());

        ListInvoiceItems.push(InvoiceItemsDTO);
    })

    Invoice.ListInvoiceItems = ListInvoiceItems;

    $.ajax({
        async: true,
        type: 'POST',
        dataType: 'JSON',
        contentType: 'application/json',
        data: JSON.stringify(Invoice),
        url: 'Index',
        success: function(){

        },
        error: function(){
            alert('Error al guardar los datos!')
        }
    })
    
    $('#product').val(0);
    $('#client').val(0);
    $('#txtUnitMeasure').val('');
    $('#txtUnitPrice').val(parseFloat(0).toFixed(2));
    $('#txtQuantity').val(00);
    $('#txtSubtotal').val(parseFloat(0).toFixed(2));
    $('#txtProductDiscount').val(parseFloat(0).toFixed(2));
    $('#txtAvailability').val(00);

    $('#productTable').find("tr:gt(0)").each(function(){
        Remove(this);
    })

}

function GetDiscount(customerId, price){
    $.ajax({
        async: true,
        type: 'GET',
        dataType: 'JSON',
        contentType: 'application/json charset=utf-8',
        data: {customerId: customerId,
                price: price},
        url: 'GetDiscount',
        success: function(data){
            AddProductToList(data)
        },
        error: function(){
            alert("Error al calcular descuento!")
        }
    })
}



function AddProductToList(){
    var customerId = $('#customer').val();
    var quantity = parseInt($('#txtQuantity').val());
    var price = $('#txtUnitPrice').val()*quantity;

    $.ajax({
        async: true,
        type: 'GET',
        dataType: 'JSON',
        contentType: 'application/json charset=utf-8',
        data: {customerId: customerId,
                price: price},
        url: 'GetDiscount',
        success: function(data){
            var table = $('#productTable');
            var productId = $('#product').val();
            var productName = $('#product option:selected').text();
            var unitMeasure = $('#txtUnitMeasure').val();
            var quantity = parseInt($('#txtQuantity').val());
            var price = $('#txtUnitPrice').val()*quantity;
            var totalPrice = data;

            var discountAmount = price - totalPrice;
            var row_product = ("<tr><td hidden>"+productId+"</td>"+
                                "<td>"+productName+"</td>"+
                                "<td>"+unitMeasure+"</td>"+
                                "<td>"+parseFloat($('#txtUnitPrice').val()).toFixed(2)+"</td>"+
                                "<td>"+quantity+"</td>"+
                                "<td>"+price.toFixed(2)+"</td>"+
                                "<td>"+discountAmount.toFixed(2)+"</td>"+
                                "<td>"+parseFloat(totalPrice).toFixed(2)+"</td>"+
                                "<td><input type='button' value='Eliminar' id='BtnRemove' name='BtnRemove' onclick='Remove(this)' class='btn btn-danger'></td></tr>")
        
            var inStock = parseInt($('#txtAvailability').val());
            
            if(inStock >= quantity){
                table.append(row_product);                /*
                if(productList.length < 1){
                    table.append(row_product);
                }
                else{
                    var actualProductName = new Array();
                    productList.each(function(){
                        actualProductName.push($(this).find('td:eq(1)').text());
                        
                    })
                    if(productName in actualProductName){
                        table.append(row_product);
                    }
                    else{
                        alert("Ya tiene este articulo registrado!");
                    }
                }
                */
            }
            else{
                alert("Lo sentimos, no tenemos la cantidad requerida de productos!")
            }
            
            FinalCost();
            $('#product').val(0);
            $('#txtUnitMeasure').val('');
            $('#txtUnitPrice').val(0.00);
            $('#txtQuantity').val(0.00);
            $('#txtSubtotal').val(0.00);
            $('#txtAvailability').val(0.00);
        },
        error: function(){
            alert("Error al calcular descuento!")
        }
    })
}

function FinalCost(){
    $('#txtTotal').val(0.00);
    var finalTotal = 0.00;
    $('#productTable').find("tr:gt(0)").each(function(){
        var total = parseFloat($(this).find('td:eq(5)').text());
        finalTotal += total;
    })

    $('#txtTotal').val(parseFloat(finalTotal).toFixed(2));
}

function Remove(productId){
    $(productId).closest('tr').remove();
    FinalCost();
}

function CalculateSubtotal(){
    var unitPrice = $('#txtUnitPrice').val();
    var quantity = $('#txtQuantity').val();

    $('#txtSubtotal').val(parseFloat(unitPrice*quantity).toFixed(2))
}

function GetUnitPrice(productId){
    $.ajax({
        async: true,
        type: 'GET',
        dataType: 'JSON',
        contentType: 'application/json charset=utf-8',
        data: {productId: productId},
        url: 'GetUnitPrice',
        success: function(data){
            $('#txtUnitPrice').val(parseFloat(data).toFixed(2));
            
        },
        error: function(){
            alert("Error cargando precios!")
        }
    })
}


function GetUnitMeasure(productId){
    $.ajax({
        async: true,
        type: 'GET',
        dataType: 'JSON',
        contentType: 'application/json charset=utf-8',
        data: {productId: productId},
        url: 'GetUnitMeasure',
        success: function(data){
            $('#txtUnitMeasure').val(data);
            
        },
        error: function(){
            alert("Error al cargar unidad de medida!")
        }
    })
}


function GetStockAvailability(productId){
    $.ajax({
        async: true,
        type: 'GET',
        dataType: 'JSON',
        contentType: 'application/json charset=utf-8',
        data: {productId: productId},
        url: 'GetStockAvailability',
        success: function(data){
            $('#txtAvailability').val(data);
            
        },
        error: function(){
            alert("Error al cargar stock!")
        }
    })
}


function GetSuscriptionType(customerId){
    $.ajax({
        async: true,
        type: 'GET',
        dataType: 'JSON',
        contentType: 'application/json charset=utf-8',
        data: {customerId: customerId},
        url: 'GetSuscriptionType',
        success: function(data){
             
            if(data=='PREMIUM'){
                $('#txtProductDiscount').val(0.05)
            }
            else{
                $('#txtProductDiscount').val(parseFloat(0).toFixed(2))
            }
            $('#txtSuscription').val(data);
            
        },
        error: function(){
            alert("Error al cargar suscripcion!")
        }
    })
}