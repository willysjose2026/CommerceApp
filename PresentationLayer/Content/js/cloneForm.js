const container = document.getElementById("formContainer");
const productForm = document.getElementsByClassName("selectForm");

console.log(productForm)
console.log(productForm.length)


function cloneForm(){
    if(productForm.length < 5)
    {
        console.log(productForm);
    
        var formClone = productForm[0].cloneNode(true);
        formClone.id = (productForm.length+1).toString()

        container.append(formClone);
    }
    else{

        window.alert("Solo se pueden tener 5 productos por factura");
    }   
}

function eraseForm(btn){
    var parent = btn.parentNode
    var formContainer = parent.parentNode

    if(formContainer.id != '1'){
        formContainer.remove(parent.id)
    }
    
    
}



