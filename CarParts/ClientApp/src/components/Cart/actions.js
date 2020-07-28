import * as types from './types';

export const addToCart = (key) => {
    return {
        type: types.ADD_TO_CART,
        obj
    }
}

export const removeFromCart = (key) => {
    return {
        type: types.REMOVE_FROM_CART,
        id
    }
}

export const orderProducts = (obj) => {
    return {
        type: types.ORDER_PRODUCTS,
        obj 
    }
}