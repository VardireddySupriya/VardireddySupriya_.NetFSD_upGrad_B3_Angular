export const mappedCart = (cart)=>cart.map((item, index) =>
    `Item ${index + 1}: ${item.name} - ₹${item.price} x ${item.quantity}`
);
export const total=(cart)=>cart.reduce((sum,item)=>
    sum+item.price,0
    
);