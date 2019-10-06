import React from 'react';
import SignUpForm from '../ReduxForms/Account/SignUpForm.jsx'
import '../../../css/account.css'
import GitHubIcon from '../../../icons/github.svg';
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
        <button className="btn btn-outline-info offset-1 col-10 oauth-button">Sign up with Github <GitHubIcon /></button>
        <button className="btn btn-outline-info offset-1 col-10 oauth-button">Sign up with vk.com <VkIcon /></button>
    </div>
</div>);
}
 
export default SignUpPage;