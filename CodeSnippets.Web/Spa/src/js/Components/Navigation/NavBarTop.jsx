import React from 'react';
import { Link } from 'react-router-dom'
import '../../../css/navbar.css';

import {Navbar, Nav, Container} from 'react-bootstrap'

import NavBarUserBlock from './NavBarUserBlock.jsx';


const NavbarTop = (props) => {
    return (
        <Navbar collapseOnSelect expand="lg" bg="dark" variant="dark">
            <Container>
                <Navbar.Brand href="#home">Code Snippets</Navbar.Brand>
                <Navbar.Toggle aria-controls="responsive-navbar-nav" />
                <Navbar.Collapse id="responsive-navbar-nav">
                    <Nav className="mr-auto">
                    <Nav.Link href="#snippets">Snippets</Nav.Link>
                    <Nav.Link href="#users">Users</Nav.Link>
                </Nav>
                    <NavBarUserBlock />
                </Navbar.Collapse>
            </Container>
        </Navbar>
    )
}
 
export default NavbarTop;