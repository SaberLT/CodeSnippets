import React from 'react';
import {Navbar, Nav, Container} from 'react-bootstrap'
import { withRouter } from 'react-router-dom';
import '../../../css/navbar.css';

import NavBarUserBlock from './NavBarUserBlock.jsx';

const NavbarTop = (props) => {
    const { history } = props
    return (
        <Navbar collapseOnSelect expand="lg" bg="dark" variant="dark">
            <Container>
                <Navbar.Brand onClick={()=>history.push('/')}>Code Snippets</Navbar.Brand>
                <Navbar.Toggle aria-controls="responsive-navbar-nav" />
                <Navbar.Collapse id="responsive-navbar-nav">
                    <Nav className="mr-auto">
                    <Nav.Link onClick={()=>history.push('/viewSnippets')}>Snippets</Nav.Link>
                    <Nav.Link onClick={()=>history.push('/viewUsers')}>Users</Nav.Link>
                </Nav>
                    <NavBarUserBlock />
                </Navbar.Collapse>
            </Container>
        </Navbar>
    )
}
 
export default withRouter(NavbarTop);