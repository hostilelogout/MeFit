import React, { useState } from 'react';
import { Form } from 'react-bootstrap';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import UserAddressModal from '../Modals/UserAddressModal';
import UserFitnessModal from '../Modals/UserFitnessModal';
import UserInformationModal from '../Modals/UserInformation';
import keycloak from '../../keycloak';




const UserProfileForm = () => {

    const token = keycloak.token;

    const [show, setShow] = useState(true);

    return (
        <>
            <UserInformationModal show={show} onHide={() => setShow(false)} />
            <h1>{console.log(token)}</h1>
        </>
    );
}

export default UserProfileForm;