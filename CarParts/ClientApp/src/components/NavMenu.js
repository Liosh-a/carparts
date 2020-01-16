import React from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

export default class NavMenu extends React.Component {
  constructor (props) {
    super(props);

    this.toggle = this.toggle.bind(this);
    this.state = {
      isOpen: false
    };
  }
  toggle () {
    this.setState({
      isOpen: !this.state.isOpen
    });
  }
  render () {
    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm border-bottom box-shadow mb-3" light >
          <Container>
            <NavbarBrand tag={Link} to="/">TheBestCRUD</NavbarBrand>
            <NavbarToggler onClick={this.toggle} className="mr-2" />
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={this.state.isOpen} navbar>
              <ul className="navbar-nav flex-grow">
                <li className="nav-li">
                  <input className="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search" />
                </li>
                <li>
                  <button className="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
                </li>
                <NavItem>
                  <NavLink tag={Link} className="txt-dark" to="/">Home</NavLink>
                </NavItem>  
                <NavItem>
                  <NavLink tag={Link} className="txt-dark" to="/login">Вход</NavLink>
                </NavItem>
              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}
