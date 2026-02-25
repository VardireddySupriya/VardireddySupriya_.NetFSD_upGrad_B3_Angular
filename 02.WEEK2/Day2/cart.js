import { mappedCart,total } from "./export.js";

window.simpleCart = function(){
    let cart=[
        {"name":"Laptop","price":50000,"quantity":1},
        {"name":"mouse","price":500,"quantity":1},
        {"name":"keyboard","price":2500,"quantity":1},
        {"name":"mobile","price":20000,"quantity":1},
    ];
    const mappedCart1= mappedCart(cart);
 
   console.log(mappedCart1);
    const cartValue=total(cart);
     console.log(cartValue);
    }
