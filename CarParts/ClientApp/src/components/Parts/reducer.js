import PartsService from './PartsService';


export const FETCH_PARTS_STARTED = "parts/FETCH_PARTS_STARTED";
export const FETCH_PARTS_SUCCESS = "parts/FETCH_PARTS_SUCCESS";
export const FETCH_PARTS_FAILED = "parts/FETCH_PARTS_FAILED";
export const SET_PARTS = "parts/SET_PARTS";


const initialState = {
    data: [],
    failed: false,
    loading: false,
    success: false
}

export const partsReducer = (state = initialState, action) => {
    let newState = state;

    switch (action.type) {

        case FETCH_PARTS_STARTED: {
            newState = {
                ...state,
                loading: true,
                success: false
            };
            break;
        }

        case FETCH_PARTS_SUCCESS: {
            newState = {
                ...state,
                loading: false,
                success: true,
                ...action.payload.data
            };
            break;
        }

        case FETCH_PARTS_FAILED: {
            newState = {
                ...state,
                loading: false,
                data: []
            };
            break;
        }

        case SET_PARTS: {
            newState = {
                ...state,
                data: action.payload
            };
            break;
        }

        default: {
            return newState;
        }
    }
    return newState;
}

export const getParts = (model) => {
    return (dispatch) => {
        AddUpdateParts(model, dispatch);
    }
}

export const partsGetActions = {
    started: () => {
        return {
            type: FETCH_PARTS_STARTED
        }
    },
    success: (data) => {
        return {
            type: FETCH_PARTS_SUCCESS,
            payload: data
        }
    },
    failed: (error) => {
        return {
            type: FETCH_PARTS_FAILED,
            error
        }
    },
    setParts: (Parts) => ({
        type: SET_PARTS,
        payload: Parts
    })
}

const AddUpdateParts = (model, dispatch) => {

    dispatch(partsGetActions.started());

    PartsService.getParts(model)
        .then((response) => {
            dispatch(partsGetActions.success(response));
        })
        .catch(() => {
            dispatch(partsGetActions.failed());
        });
}
