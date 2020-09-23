import React, { Component } from "react";
import {Button} from 'reactstrap';
import HomeContainer from './HomeContainer';
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
                                        <div className="row">
                                            <SelectItem className="select-part" selectName="Год выпуска"/>
                                            <SelectItem className="select-part" selectName="Марка"/>
                                            <SelectItem className="select-part" selectName="Модель"/>
                                            <div className="col-lg-3 col-md-3 col-sm-6 col-xs-12 searchButton">
                                                <button type="button" id="sas_search_button0">Поиск</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <HomeContainer/>
            </div>
        );
    }
}

export default Home;

const SelectItem = ({selectName = "Select", options}) => {
    return (
        <div className="col-lg-3 col-md-3 col-sm-6 col-xs-12 search-boxes">
            <select name="make" id="so_make0" className="select-part">
                <option>{selectName}</option>
            </select>
        </div>
    )
}





