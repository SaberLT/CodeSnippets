import React from 'react';
import { Nav, NavDropdown } from 'react-bootstrap'
import { connect } from 'react-redux';
import '../../../css/navbar.css';

const NavBarUserBlock = (props) => {
    let { account } = props;
    console.log(account);

    let isAuthed = account.token!=='';

        return ( <div>
            { isAuthed 
                ?
                <Nav>
                    <NavDropdown title={`Hello, ${account.username}`} id="collasible-nav-dropdown">
                        <NavDropdown.Item href="#profile">Profile</NavDropdown.Item>
                        <NavDropdown.Item href="#logout">Log out</NavDropdown.Item>
                    </NavDropdown>
                </Nav>
                : 
                <Nav>
                    <Nav.Link href="#signin">Sign in</Nav.Link>
                    <Nav.Link href="#signup">Sign up</Nav.Link>
                </Nav>}
            </div>
    );
}

const mapStateToProps = ({ account }) => ({
    account
});

export default connect(mapStateToProps)(NavBarUserBlock);