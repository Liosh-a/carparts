import CategoryService from './categoryService';

export const FETCH_CATEGORIES_STARTED = "categories/FETCH_CATEGORIES_STARTED";
export const FETCH_CATEGORIES_SUCCESS = "categories/FETCH_CATEGORIES_SUCCESS";
export const FETCH_CATEGORIES_FAILED = "categories/FETCH_CATEGORIES_FAILED";


const initialState = {
    data: [],
    failed: false,
    loading: false,
    success: false
}


export const categoriesReducer = (state = initialState, action) => {
    let newState = state;

    switch (action.type) {
        case FETCH_CATEGORIES_STARTED: {
            newState = {
                ...state,
                loading: true,
                success: false
            };
            break;
        }

        case FETCH_CATEGORIES_SUCCESS: {
            newState = {
                ...state,
                loading: false,
                success: true,
                data: action.payload
            };
            break;
        }

        case FETCH_CATEGORIES_FAILED: {
            newState = {
                ...state,
                loading: false,
                data: []
            };
            break;
        }

        default: {
            return newState;
        }
    }
    return newState;
}

export const getCategories = () => {
    return (dispatch) => {
        dispatch(categoriesGetActions.started());

        CategoryService.getCategories()
            .then((response) => {
                dispatch(categoriesGetActions.success(response.data.data));
            })
            .catch(() => {
                dispatch(categoriesGetActions.failed());
            });
    }
}

export const categoriesGetActions = {
    started: () => {
        return {
            type: FETCH_CATEGORIES_STARTED
        }
    },
    success: (data) => {
        return {
            type: FETCH_CATEGORIES_SUCCESS,
            payload: data
        }
    },
    failed: (error) => {
        return {
            type: FETCH_CATEGORIES_FAILED,
            error
        }
    }
}
