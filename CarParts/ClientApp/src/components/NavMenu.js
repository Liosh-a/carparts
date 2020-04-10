import React from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';


export default class NavMenu extends React.Component {
  constructor(props) {
    super(props);

    this.toggle = this.toggle.bind(this);
    this.state = {
      isOpen: false
    };
  }
  toggle() {
    this.setState({
      isOpen: !this.state.isOpen
    });
  }
  render() {
    return (
      <Navbar className="nav-container navbar-expand-sm navbar-toggleable-sm border-bottom box-shadow mb-3" light>
        <NavbarBrand tag={Link} to="/">Koparts</NavbarBrand>
        <NavbarToggler onClick={this.toggle} className="mr-2" />
        <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={this.state.isOpen} navbar>
          <ul className="navbar-nav flex-grow">
            <NavItem>
              <NavLink tag={Link} className="txt-dark" to="/">Home</NavLink>
            </NavItem>
            <NavItem>
              <NavLink tag={Link} className="txt-dark" to="/login">Вход</NavLink>
            </NavItem>
          </ul>
        </Collapse>
      </Navbar>
    );
  }
}



