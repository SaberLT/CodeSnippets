import React from 'react';
import SignInForm from '../ReduxForms/Account/SignInForm.jsx'
import '../../../css/account.css'
import GitHubAuth from '../Auth/GithubAuth.jsx'
import VkAuth from '../Auth/VkAuth.jsx';

const SignInPage = props => {
    return (
        <div className="row">
            <div className="col-12 col-lg-6">
                <p className="h3">Oldschool sign in:</p>
                <SignInForm />
            </div>
            <div className="col-12 col-lg-6">
                <p className="h3">Modern OAuth sign up:</p>
                <GitHubAuth />
                <VkAuth />
            </div>
        </div> );
}
 
export default SignInPage;