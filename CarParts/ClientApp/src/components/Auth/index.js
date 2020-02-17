import Login from './Login';
import { loginUser, setErrors } from '../actions';

import { connect } from 'react-redux';
import PropTypes from 'prop-types';

const mapState = (state) => {
    return {
        loading: state.auth.loading,
        errors: state.auth.errors,
    }
}

Login.propTypes = {
    loading: PropTypes.bool.isRequired,
    errors: PropTypes.any,
};
 
export default connect(mapState, {loginUser, setErrors})(Login);