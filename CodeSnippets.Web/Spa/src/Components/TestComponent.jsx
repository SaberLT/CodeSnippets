import React from 'react';
import { withRouter } from 'react-router-dom';
import { connect } from 'react-redux';

const TestComponent = (props) => {
    console.log(props);
    return <div>
        <h3>Test component... Working nearly fine...</h3>
    </div>
}

const mapStateToProps = ( { account } ) => {
    return {
        account
    }
}

export default withRouter(
    connect(mapStateToProps)(TestComponent)
);