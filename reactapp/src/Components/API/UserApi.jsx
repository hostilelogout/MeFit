import keycloak from "../../keycloak";

const fetchUserProfileById = async (id) => {
    try {
        const options = {
            method: 'GET',
            headers: {
                'Access-Control-Allow-Origin': '*',
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + keycloak.token
            }
        }
        const request = await fetch(`https://localhost:7101/${id}`, options)
            .then(response => response.json())
            .then(results => {
                return results
            })
        return request;
    } catch (error) {
        console.log(error);
    }
}

const fetchUserAddressById = async (id) => {
    try {
        const options = {
            method: 'GET',
            headers: {
                'Access-Control-Allow-Origin': '*',
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + keycloak.token
            }
        }
        const request = await fetch(`https://localhost:7101/api/addresses/${id}`, options)
            .then(response => response.json())
            .then(results => {
                return results
            })
        return request;
    } catch (error) {

    }
}

export const fetchUserById = async (id) => {
    try {
        const options = {
            method: 'GET',
            headers: {
                'Access-Control-Allow-Origin': '*',
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + keycloak.token
            }
        }

        const user = await fetch(`https://localhost:7101/api/users/${id}`, options)
            .then(response => response.json());

        if (user.status == "404") {
            return user.status;
        }
        else {

            const profile = await fetchUserProfileById(user.userProfiles[0]);
            const address = await fetchUserAddressById(profile.fkAddressId);

            const data = {
                userData: user,
                profileData: profile,
                adressData: address
            }

            return data;
        }


    } catch (error) {
        console.log(error);
    }
}

export const patchPersonalById = async (payload, data) => {
    try {
        const profilePatch = {
            method: 'PATCH',
            headers: {
                'Access-Control-Allow-Origin': '*',
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + keycloak.token
            },
            body: JSON.stringify({
                id: parseInt(data.profileData.id),
                fkUserId: payload.id,
                fkAddressId: parseInt(data.profileData.fkAddressId),
                weight: parseInt(data.profileData.weight),
                height: parseInt(data.profileData.height),
                medicalCondition: data.profileData.medicalCondition,
                disabilities: data.profileData.disabilities,
                firstname: payload.firstName,
                lastname: payload.lastName,
                phone: parseInt(payload.phoneNumber),
                picture: payload.profilePicture,
                email: payload.email,
            })
        }

        await fetch(`https://localhost:7101/${data.userData.userProfiles[0]}`, profilePatch);


    } catch (error) {
        console.log(error);
    }
}

export const patchFitnessById = async (payload, data) => {
    try {
        const fitnessPatch = {
            method: 'PATCH',
            headers: {
                'Access-Control-Allow-Origin': '*',
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + keycloak.token
            },
            body: JSON.stringify({
                id: parseInt(data.profileData.id),
                fkUserId: data.profileData.fkUserId,
                fkAddressId: parseInt(data.profileData.fkAddressId),
                weight: parseInt(payload.weight),
                height: parseInt(payload.height),
                medicalCondition: payload.medicalCondition,
                disabilities: payload.disabilities,
                firstname: data.profileData.firstname,
                lastname: data.profileData.lastname,
                phone: parseInt(data.profileData.phone),
                picture: data.profileData.picture,
                email: data.profileData.email,
            })
        }

        await fetch(`https://localhost:7101/${data.userData.userProfiles[0]}`, fitnessPatch);


    } catch (error) {
        console.log(error);
    }
}

export const patchAddressById = async (payload, data) => {
    try {
        const addressPatch = {
            method: 'PATCH',
            headers: {
                'Access-Control-Allow-Origin': '*',
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + keycloak.token
            },
            body: JSON.stringify({
                addressLine1: payload.address,
                addressLine2: payload.addressSecond,
                addressLine3: payload.addressThird,
                city: payload.city,
                country: payload.country,
                postalCode: payload.postalCode,
            })
        }

        await fetch(`https://localhost:7101/api/addresses/${data.profileData.fkAddressId}`, addressPatch);


    } catch (error) {
        console.log(error);
    }
}

const postAddress = async (payload) => {
    try {
        const postOptions = {
            method: 'POST',
            headers: {
                'Access-Control-Allow-Origin': '*',
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + keycloak.token
            },
            body: JSON.stringify({
                addressLine1: payload.adressData.address,
                addressLine2: payload.adressData.addressSecond,
                addressLine3: payload.adressData.addressThird,
                city: payload.adressData.city,
                country: payload.adressData.country,
                postalCode: payload.adressData.postalCode,
            })
        }

        const address = await fetch('https://localhost:7101/api/addresses', postOptions)
            .then(response => response.json());

        const data = {
            adressData: address
        }
        return data;

    } catch (error) {
        console.log(error)
    }
}

const postProfile = async (payload, address, user) => {
    console.log(user);
    console.log(address);
    console.log(payload);
    try {
        const postOptions = {
            method: 'POST',
            headers: {
                'Access-Control-Allow-Origin': '*',
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + keycloak.token
            },
            body: JSON.stringify({
                fkUserId: user.id,
                fkAddressId: parseInt(address.id),
                weight: parseInt(payload.profileData.weight),
                height: parseInt(payload.profileData.height),
                medicalCondition: payload.profileData.medicalCondition,
                disabilities: payload.profileData.disabilities,
                firstname: payload.userData.firstName,
                lastname: payload.userData.lastName,
                phone: parseInt(payload.userData.phoneNumber),
                picture: payload.userData.profilePicture,
                email: payload.userData.email,
            })
        }

        const profile = await fetch('https://localhost:7101/api/userprofiles', postOptions)
            .then(response => response.json());

        const data = {
            profileData: profile
        }

        return data;

    } catch (error) {
        console.log(error)
    }
}

export const postUser = async (payload, firstlogin) => {
    try {
        const address = await postAddress(payload);
        const userOptions = {
            method: 'POST',
            headers: {
                'Access-Control-Allow-Origin': '*',
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + keycloak.token
            },
            body: JSON.stringify({
                id: keycloak.tokenParsed.user_Id,
                username: payload.userData.email,
                firstLogin: !firstlogin,
            })
        }

        const user = await fetch('https://localhost:7101/api/users', userOptions)
            .then(response => response.json());


        const profile = await postProfile(payload, address.adressData, user);

        const data = {
            userData: user,
            profileData: profile,
            adressData: address
        }

        console.log(data);
        return data;
    } catch (error) {
        console.log(error)
    }
}

