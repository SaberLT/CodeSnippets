import React from 'react';
import { BrowserRouter, Route } from 'react-router-dom';
import { Container } from 'react-bootstrap';

import NavbarTop from './js/Components/Navigation/NavBarTop.jsx';
import MainPage from './js/Components/MainPage.jsx';
import SignInPage from './js/Components/Account/SignInPage.jsx';
import SignUpPage from './js/Components/Account/SignUpPage.jsx';
import ViewSnippetsPage from './js/Components/Snippet/ViewSnippetsPage.jsx';
import ViewUsersPage from './js/Components/User/ViewUsersPage.jsx';
import GithubAuthResult from './js/Components/Auth/GithubAuthResult.jsx'


const App = () => {
  return (
    <BrowserRouter>
      <div className="app">
        <NavbarTop />
          <Container>
            <Route path="/" exact component={MainPage} />
            <Route path="/signin" component={SignInPage} />
            <Route path="/signup" component={SignUpPage} />
            <Route path="/viewSnippets" component={ViewSnippetsPage} />
            <Route path="/viewUsers" component={ViewUsersPage} />



            
            <Route path="/auth/github*" component={GithubAuthResult} />
          </Container>
      </div>
    </BrowserRouter>
  );
}

export default App;
