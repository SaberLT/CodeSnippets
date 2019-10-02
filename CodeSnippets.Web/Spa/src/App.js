import React from 'react';
import { BrowserRouter, Route } from 'react-router-dom';
import TestComponent from "./js/TestComponent.jsx";
import NavbarTop from './js/Components/Navigation/NavBarTop.jsx';
import { Container } from 'react-bootstrap';

const App = () => {
  return (
    <BrowserRouter>
      <div className="app">
        <NavbarTop />
          <Container>
            <TestComponent /> 
          </Container>
      </div>
    </BrowserRouter>
  );
}

export default App;
