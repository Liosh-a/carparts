import SelectService from './selectService';

export const FETCH_YEARS_STARTED = "select/FETCH_YEARS_STARTED";
export const FETCH_YEARS_SUCCESS = "select/FETCH_YEARS_SUCCESS";
export const FETCH_YEARS_FAILED = "select/FETCH_YEARS_FAILED";

export const FETCH_MARKS_STARTED = "select/FETCH_MARKS_STARTED";
export const FETCH_MARKS_SUCCESS = "select/FETCH_MARKS_SUCCESS";
export const FETCH_MARKS_FAILED = "select/FETCH_MARKS_FAILED";

export const FETCH_MODELS_STARTED = "select/FETCH_MODELS_STARTED";
export const FETCH_MODELS_SUCCESS = "select/FETCH_MODELS_SUCCESS";
export const FETCH_MODELS_FAILED = "select/FETCH_MODELS_FAILED";


const initialState = {
    years: {
        data: [],
        failed: false,
        loading: false,
        success: false
    },

    marks: {
        data: [],
        failed: false,
        loading: false,
        success: false
    },

    models: {
        data: [],
        failed: false,
        loading: false,
        success: false
    }
}


export const selectReducer = (state = initialState, action) => {
    let newState = state;

    switch (action.type) {
        case FETCH_YEARS_STARTED: {
            newState = {
                ...state,
                years: {
                    loading: true,
                    success: false
                }
            };
            break;
        }

        case FETCH_YEARS_SUCCESS: {
            newState = {
                ...state,
                years: {
                    loading: false,
                success: true,
                data: action.payload
                }
                
            };
            break;
        }

        case FETCH_YEARS_FAILED: {
            newState = {
                ...state,
                years: {
                    loading: false,
                    data: []
                }

            };
            break;
        }

        case FETCH_MARKS_STARTED: {
            newState = {
                ...state,
                marks:{
                    loading: true,
                    success: false
                }

            };
            break;
        }

        case FETCH_MARKS_SUCCESS: {
            newState = {
                ...state,
                marks:{
                    loading: false,
                    success: true,
                    data: action.payload
                }
            };
            break;
        }

        case FETCH_MARKS_FAILED: {
            newState = {
                ...state,
                marks:{
                    loading: false,
                    data: []
                }
            };
            break;
        }

        case FETCH_MODELS_STARTED: {
            newState = {
                ...state,
                models:{
                    loading: true,
                    success: false
                }
            };
            break;
        }

        case FETCH_MODELS_SUCCESS: {
            newState = {
                ...state,
                models:{
                    loading: false,
                    success: true,
                    data: action.payload
                }
            };
            break;
        }

        case FETCH_MODELS_FAILED: {
            newState = {
                ...state,
                models:{
                    loading: false,
                    data: []
                }
            };
            break;
        }
        default: {
            return newState;
        }
    }
    return newState;
}

export const getYears = () => {
    return (dispatch) => {
        dispatch(yearsGetActions.started());

        SelectService.getYears()
            .then((response) => {
                dispatch(yearsGetActions.success(response.data.data));
            })
            .catch(() => {
                dispatch(yearsGetActions.failed());
            });
    }
}

export const yearsGetActions = {
    started: () => {
        return {
            type: FETCH_YEARS_STARTED
        }
    },
    success: (data) => {
        return {
            type: FETCH_YEARS_SUCCESS,
            payload: data
        }
    },
    failed: (error) => {
        return {
            type: FETCH_YEARS_FAILED,
            error
        }
    }
}


export const getMarks = (year) => {
    return (dispatch) => {
        dispatch(marksGetActions.started());

        SelectService.getMarks(year)
            .then((response) => {
                dispatch(marksGetActions.success(response.data.data));
            })
            .catch(() => {
                dispatch(marksGetActions.failed());
            });
    }
}

export const marksGetActions = {
    started: () => {
        return {
            type: FETCH_MARKS_STARTED
        }
    },
    success: (data) => {
        return {
            type: FETCH_MARKS_SUCCESS,
            payload: data
        }
    },
    failed: (error) => {
        return {
            type: FETCH_MARKS_FAILED,
            error
        }
    }
}


export const getModels = (id) => {
    return (dispatch) => {
        dispatch(modelsGetActions.started());

        SelectService.getModel(id)
            .then((response) => {
                dispatch(modelsGetActions.success(response.data.data));
            })
            .catch(() => {
                dispatch(modelsGetActions.failed());
            });
    }
}

export const modelsGetActions = {
    started: () => {
        return {
            type: FETCH_MODELS_STARTED
        }
    },
    success: (data) => {
        return {
            type: FETCH_MODELS_SUCCESS,
            payload: data
        }
    },
    failed: (error) => {
        return {
            type: FETCH_MODELS_FAILED,
            error
        }
    }
}