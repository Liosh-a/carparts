import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Counter from './components/Counter';
import FetchData from './components/FetchData';
import ProductPage from './components/products/list';
import Login from './components/Auth/Login';
import Registration from './components/Auth/Register/Registration'
import ForgotPassword from './components/Auth/ForgotPassword';
import ConfirmEmailPage from './components/Auth/ConfirmEmail/ConfirmEmailPage';

export default () => (
  <Layout>
    <Route exact path='/' component={Home} />
    <Route path='/counter' component={Counter} />
    <Route path='/fetch-data/:startDateIndex?' component={FetchData} />
    <Route path='/products' component={ProductPage} />
    <Route path='/login' component={Login} />
    <Route path='/registration' component={Registration} />
    <Route path='/forgot-password' component={ForgotPassword} />
    <Route path='/confirm-email' component={ConfirmEmailPage} />
  </Layout>
);
