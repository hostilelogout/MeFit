// FETCH
export const fetchPrograms = async () => {
    console.log(process.env.REACT_APP_API_URL + "/trainingprograms")
    try {
        const request = await fetch(process.env.REACT_APP_API_URL + "/trainingprograms", {
            headers: {
                'Access-Control-Allow-Origin': '*'
            }
        })
            .then(response => response.json())
            .then(results => {
                return results
            })
        return request
    } catch (error) {
        console.log(error)
    }
}