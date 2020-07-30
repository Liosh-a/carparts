import * as types from './types';


const initState = {
    items: [],
    orders: [],
    total: 0
}

export const cartReducer = (state = initState, action) => {
    let newState = state;
    switch (action.type) {
        case types.ADD_TO_CART: {
            break;
        }
        case types.REMOVE_FROM_CART: {

            break;
        }
        default: {
            return state;
        }
    }
}