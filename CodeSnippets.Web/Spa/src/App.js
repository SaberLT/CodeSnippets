import React from 'react';
import { BrowserRouter, Route } from 'react-router-dom';
import TestComponent from "./Components/TestComponent.jsx";

const App = () => {
  return (
    <BrowserRouter>
      <div className="app">
        <TestComponent /> 
      </div>
    </BrowserRouter>
  );
}

export default App;
