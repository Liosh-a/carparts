import React from 'react';
import { Container } from 'reactstrap';
import NavMenu from '../NavMenu';
import Category from '../components/Categories/Category'
export default props => (
  <div>
    <NavMenu />
    <Container>
      {props.children}
    </Container>
  </div>
);
