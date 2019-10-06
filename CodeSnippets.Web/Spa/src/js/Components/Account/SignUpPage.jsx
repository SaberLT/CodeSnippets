import React from 'react';
import SignUpForm from '../ReduxForms/Account/SignUpForm.jsx'
import '../../../css/account.css'
import GitHubAuth from '../Auth/GithubAuth.jsx';
import VkAuth from '../Auth/VkAuth.jsx';

const SignUpPage = props => {
    return ( <div className="row">
    {/* <ReactSVG src='../../../icons/github.svg' /> */}
    <div className="col-12 col-lg-6">
        <p className="h3">Oldschool sign up:</p>
        <SignUpForm />
    </div>
    <div className="col-12 col-lg-6">
        <p className="h3">Modern OAuth sign up:</p>
        <GitHubAuth />
        <VkAuth />
    </div>
</div>);
}
 
export default SignUpPage;