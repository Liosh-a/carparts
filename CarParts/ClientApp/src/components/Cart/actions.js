import * as types from './types';

export const addToCart = (key) => {
    return {
        type: types.ADD_TO_CART,
        key
    }
}

export const removeFromCart = (key) => {
    return {
        type: types.REMOVE_FROM_CART,
        key
    }
}

export const orderProducts = (obj) => {
    return {
        type: types.ORDER_PRODUCTS,
        obj 
    }
}