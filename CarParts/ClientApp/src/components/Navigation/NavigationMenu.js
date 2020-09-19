import React, { Component } from 'react';
import './Navigation.css';
import '../../../node_modules/font-awesome/css/font-awesome.css';
import HeaderTop from'./HeaderTop';
import HeaderMiddle from './HeaderMiddle';
import HeaderBottom from './HeaderBottom';

class NavigationMenu extends Component {
    state = {}

    render() {
        return (
            <div>
                <HeaderTop/>
                <HeaderMiddle/>
                <HeaderBottom/>
            </div>
        );
    }
}

export default NavigationMenu;


