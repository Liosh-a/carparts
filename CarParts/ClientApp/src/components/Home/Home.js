import React, { Component } from "react";
import HomeContainer from './HomeContainer';
import SelectForm from './Select/SelectForm';
import './home.css';

export class Home extends Component {

    state = {

    };

    render() {
        return (
            <div>
                <div className="row-advanced">
                    <div className="box-advanced-search container">
                        <div className="so_advanced_search">
                            <div className="sas_wrap">
                                <div className="sas_inner">
                                    <div className="heading-title">
                                        <h2>Найдите вашу запчасть</h2>
                                    </div>
                                    <div className="sas_inner_box_search">
                                        <div>
                                            <SelectForm/>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <HomeContainer />
            </div>
        );
    }
}

export default Home;







