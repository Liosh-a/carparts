import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Login from './components/Auth/Login';
import Registration from './components/Auth/Register/Registration'
import ForgotPassword from './components/Auth/ForgotPassword';
import ConfirmEmailPage from './components/Auth/ConfirmEmail/ConfirmEmailPage';

export default () => (
  <Layout>
    <Route exact path='/' component={Home} />
    <Route path='/login' component={Login} />
    <Route path='/registration' component={Registration} />
    <Route path='/forgot-password' component={ForgotPassword} />
    <Route path='/confirmemail' component={ConfirmEmailPage} />
  </Layout>
);
