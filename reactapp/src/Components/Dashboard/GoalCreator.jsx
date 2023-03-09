import { useState } from "react"
import ProgramList from "./ProgramList"

const GoalCreator = () => {
    const [state, setState] = useState({
		selectedProgram: {}
	})

    const handleProgramSelected = selectedProgram => {
        setState({...state, selectedProgram})
        console.log(selectedProgram)
    }

    return (
        <div className="d-flex flex-column text-center bg-container w-480 h-600 p-4">
            <div>
                <h2>GoalCreator</h2>
            </div>
            <div className="d-flex flex-fill justify-content-center">
                <div className="d-flex flex-column wp-50">
                    <div className="p-2">Filter</div>
                    <div className="d-flex flex-fill overflow-hidden bg-box p-2">
                        <ProgramList programSelected={handleProgramSelected}/>
                    </div>
                </div>
                <div className="bg-box wp-50 p-2">Details</div>
            </div>
        </div>
    )
}

export default GoalCreator