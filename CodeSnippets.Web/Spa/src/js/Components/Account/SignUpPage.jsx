import React from 'react';
import SignUpForm from '../ReduxForms/Account/SignUpForm.jsx'
import '../../../css/account.css'
import GitHubAuth from '../Auth/GithubAuth.jsx';
import VkIcon from '../../../icons/vk.svg';

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
        <button className="btn btn-outline-info offset-1 col-10 oauth-button">Sign up with vk.com <VkIcon /></button>
    </div>
</div>);
}
 
export default SignUpPage;