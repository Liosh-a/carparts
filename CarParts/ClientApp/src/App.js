import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Login from './components/Auth';
import Registration from './components/Register/Registration'
import ForgotPassword from './components/ForgotPassword/ForgotPassword';
import ConfirmEmailPage from './components/ConfirmEmail/ConfirmEmailPage';

export default () => (
  <Layout>
    <Route exact path='/' component={Home} />
    <Route path='/login' component={Login} />
    <Route path='/registration' component={Registration} />
    <Route path='/forgot-password' component={ForgotPassword} />
    <Route path='/confirm-email' component={ConfirmEmailPage} />
  </Layout>
);
