import React from 'react';

export const FormInputField = props => <input type={props.isPassword?'password':'text'}
    {...props.input}
    placeholder={props.placeholder}
    width={props.width}
    className={`form-control ${props.classes}`}

    />;