import React from 'react';
import SignInForm from '../ReduxForms/Account/SignInForm.jsx'
import '../../../css/account.css'
import GitHubAuth from '../Auth/GithubAuth.jsx'
import VkIcon from '../../../icons/vk.svg';

const SignInPage = props => {
    return (
        <div className="row">
            <div className="col-12 col-lg-6">
                <p className="h3">Oldschool sign in:</p>
                <SignInForm />
            </div>
            <div className="col-12 col-lg-6">
                <p className="h3">Modern OAuth sign in:</p>
                <GitHubAuth />
                <button className="btn btn-outline-info offset-1 col-10 oauth-button">Sign up with vk.com <VkIcon /></button>
            </div>
        </div> );
}
 
export default SignInPage;