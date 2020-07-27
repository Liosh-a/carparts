import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home/Home';
import Login from './components/Auth';
import Registration from './components/Register';
import ForgotPassword from './components/ForgotPassword/ForgotPassword';
import ConfirmEmailPage from './components/ConfirmEmail/ConfirmEmailPage';
import UserPage from './components/UserPage/UserPage';
import ListParts from './components/Parts/ListParts';
import Category from './components/Categories/Category';
import Cart from './components/Cart/Cart';


export default () => (
  <Layout>
    <Route exact path='/' component={Home} />
    <Route path='/login' component={Login} />
    <Route path='/registration' component={Registration} />
    <Route path='/forgot-password' component={ForgotPassword} />
    <Route path='/confirm-email' component={ConfirmEmailPage} />
    <Route path='/user-page' component={UserPage} />
    <Route path='/parts-list' component={ListParts}/>
    <Route path='/cart' component={Cart}/>
  </Layout>
);
