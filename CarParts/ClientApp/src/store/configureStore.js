import { applyMiddleware, combineReducers, compose, createStore } from 'redux';
import thunk from 'redux-thunk';
import { connectRouter, routerMiddleware } from 'connected-react-router';
import { createBrowserHistory } from 'history';
import {registerReducer} from '../components/Register/RegisterReducer';
import {confirmEmailReducer} from '../components/ConfirmEmail/ConfirmEmailReducer';
import {loginReducer} from '../components/Auth/LoginReducer';
import {partsReducer} from '../components/Parts/reducer';
import {cartReducer} from '../components/Cart/reducer';
import {categoriesReducer} from '../components/Categories/reducer';
import {selectReducer} from '../components/Home/Select/reducer';
// Create browser history to use in the Redux store
const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
export const history = createBrowserHistory({ basename: baseUrl });

export default function configureStore(history, initialState) {
  const reducers = {
    register: registerReducer,
    confirmEmail: confirmEmailReducer,
    login: loginReducer,
    parts: partsReducer,
    cart: cartReducer,
    categories: categoriesReducer,
    select: selectReducer
  };

  const middleware = [
    thunk,
    routerMiddleware(history)
  ];

  // In development, use the browser's Redux dev tools extension if installed
  const enhancers = [];
  const isDevelopment = process.env.NODE_ENV === 'development';
  if (isDevelopment && typeof window !== 'undefined' && window.devToolsExtension) {
    enhancers.push(window.devToolsExtension());
  }

  const rootReducer = combineReducers({
    ...reducers,
    router: connectRouter(history)
  });

  return createStore(
    rootReducer,
    initialState,
    compose(applyMiddleware(...middleware), ...enhancers)
  );
}
