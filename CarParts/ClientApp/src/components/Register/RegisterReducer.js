import * as types from './types';

const initialState = {
    loading: false,
    success: false,
    failed: false,
    errors: {}
}

export const registerReducer = (state = initialState, action) => {
    let newState = state;
    switch (action.type) {
        case types.REGISTER_STARTED: {
            console.log('-----Begin register User--------');
            newState = {...state, loading: true};
            break;
        }
        case types.REGISTER_SUCCESS: {
            console.log('-----Success register User--------');
            newState = {...state, loading: false};
            break;
        }
        case types.REGISTER_FAILED: {
            console.log('-----Failed register User--------');
            newState = {
                ...state, 
                loading: false, 
                errors: action.servErrors
            };
            break;
        }
        case types.REGISTER_SET_ERRORS:{
            newState = {
                ...state, 
                errors: !!!action.errors ? {} : {...state.errors, ...action.errors },
            };
            break;
        }
        default: {
            return state;
        }
    }
    return newState;
}