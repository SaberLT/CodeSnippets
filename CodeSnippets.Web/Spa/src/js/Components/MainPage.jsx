import React from 'react';
import { withRouter } from 'react-router-dom';
import { connect } from 'react-redux';

const MainPage = (props) => {
    return <div>
        <h3>Main Component... Working nearly fine...</h3>
    </div>
}

const mapStateToProps = ( { account } ) => {
    return {
        account
    }
}

export default withRouter(
    connect(mapStateToProps)(MainPage)
);