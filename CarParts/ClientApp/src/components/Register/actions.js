import registerService from './registerService';
import * as types from './types';
import { push } from 'connected-react-router';

export const registerActions = {
    started: () => {
        return {
            type: types.REGISTER_STARTED
        }
    },

    success: () => {
        return {
            type: types.REGISTER_SUCCESS
        }
    },

    failed: (response) => {
        return {
            type: types.REGISTER_FAILED,
            errors: response.data
        }
    },

    setErrors: (errors) => {
        return {
            type: types.REGISTER_SET_ERRORS,
            errors
        }
    }
}

export const setErrors = (errors) => {
    return (dispatch) => {
        dispatch(registerActions.setErrors(errors));
    };
}

export const registerUser = (model) => {
    return (dispatch) => {
        dispatch(registerActions.started());
        registerService.registerUser(model)
            .then((response)=>
            {
                console.log('Server message', response.data);
                dispatch(registerActions.success());
                dispatch(push('/'));
            }, err => {
                dispatch(registerActions.failed(err.response));;
            })
            .catch(err=> {
                console.log('Global Server problen in controler message', err);
            });
    };
}


