import { useEffect, useState } from "react"
import ProgramListItem from "./ProgramListItem"

const ProgramList = props => {
    const [state, setState] = useState({
		programs: [{id:0, name:"Test Program"}]
	})

	useEffect(() => { // Lifecylce - ComponentDidMount

		// fetchPrograms()
		// 	.then(programs => {
		// 		setState({
		// 			...state,
		// 			programs
		// 		})
		// 	})
		// 	.catch(error => {
		// 		console.error(error.message)
		// 	})

        let programs = [{id:1, name:"Program A"}, {id:2, name:"Program B"}]
        setState(s => ({...s, programs}))

        return () => { // Lifecycle - ComponentWillUnmount
            // For Clean up code.
        }

	}, []) // - Lifecyle - ComponentDidUpdate

    // const handleProgramSelected = program => {
    //     console.log(program)
    //     props.programSelected(program)
    // }

    return (
        <ul className="list-group overflow-y-scroll flex-shrink-0 wp-100 p-2">
            { state.programs.map(program => <ProgramListItem programSelected={() => props.programSelected(program)} key={program.id} program={program}/>) }
        </ul>
    )
}

export default ProgramList