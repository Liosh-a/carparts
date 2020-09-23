import React, { Component } from 'react';
import "./home.css";

class HomeContainer extends Component {
    state = {  }
    render() { 
        return ( 
            <div className="container">
                <div className="extra_layout">
                    <div className="pre_text">
                        Категории
                    </div>
                    <h3 className="modtitle"><span>Автозапчасти</span></h3>
                </div>
            </div>
         );
    }
}
 
export default HomeContainer;