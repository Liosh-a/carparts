import Registration from './Registration';
import {registerUser, setErrors} from './actions';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';

const mapState = (state) => {
    return {
        loading: state.register.loading,
        errors: state.register.errors,
    }
}

Registration.propTypes = {
    loading: PropTypes.bool.isRequired,
    errors: PropTypes.any
}

export default connect(mapState, { registerUser, setErrors })(Registration);
