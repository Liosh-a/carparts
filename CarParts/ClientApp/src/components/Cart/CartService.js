import axios from 'axios';

export default class CartService{
    
    static orderProducts(model){
        return axios.post('api/cart/order-products', model);
    }
}