import { useEffect, useState } from "react"
import { fetchExercises } from "../API/ExerciseAPI"
import ExerciseSelectionList from "../Components/Exercise/ExerciseSelectionList"

const ExercisesOverview = () => {
    const [state, setState] = useState({
        selectedExercise: null
    })
    const [exercises, setExercises] = useState("loading")

    useEffect(() => {
        setExercises("loading")
        const getExercises = async () => {
            const es = await fetchExercises()
            console.log(es)
            setExercises(es.reverse())
        }
        getExercises()
    }, [])

    const exerciseSelected = (event, exercise) => {
        console.log(exercise)
        if (event.target.checked) setState({...state, selectedExercise: exercise})
        else setState({...state, selectedExercise: null})
    }

    return (
        <>
        <div className="d-flex flex-column align-items-center hpx-720 p-5">
            <div className="d-flex flex-fill border wp-100 min-h-0">
                <div className="d-flex flex-column text-center wp-100">
                    <ExerciseSelectionList type="radio" exercises={exercises} exerciseSelected={exerciseSelected}/>
                </div>
                <div className="d-flex flex-column text-center wp-100">
                    <h3>Details</h3>
                    <div className="d-flex flex-column justify-content-center hp-100">
                        {state.selectedExercise !== null &&
                        <>
                            <p>Exercise: {state.selectedExercise.name}</p>
                        </>
                        }
                    </div>
                </div>
            </div>
        </div>
        </>
    )
}

export default ExercisesOverview