import { useEffect, useState } from "react";
import { fetchExercises } from "../../API/ExerciseAPI";

const ExerciseSelectionList = props => {
    const [exercises, setExercises] = useState([])
    const [loading, setLoading] = useState(true)

    useEffect(() => {
        const getExercises = async () => {
            const es = await fetchExercises()
                .finally(setLoading(false))
            console.log(es)
            setExercises(es)
        }
        getExercises()
    }, [])

    return (
        <div className="d-flex flex-column flex-fill align-items-center border wp-100 min-h-0 p-2">
            <p>Choose exercises:</p>
            <div className="d-flex flex-column flex-fill text-center overflow-y-scroll wp-100">
                {loading && <div className="spinner-border align-self-center" role="status"/>}
                {exercises.map(exercise => 
                    <div className="d-flex flex-column" key={exercise.id}>
                        <input onChange={e => props.exerciseSelected(e, exercise)} type="checkbox" name="exercise-list-checkbox" id={`exercise-checkbox-${exercise.id}`} className="btn-check"/>
                        <label htmlFor={`exercise-checkbox-${exercise.id}`} className="btn btn-outline-secondary">{exercise.name}</label>
                    </div>
                    )}
                {/* <input onChange={e => exerciseSelected(e, {id: 1, name: "Exercise A"})} type="checkbox" name="exercise-list-checkbox" id="exercise-checkbox-1" className="btn-check"/>
                <label htmlFor="exercise-checkbox-1" className="btn btn-outline-secondary">Exercise A</label>
                <input onChange={e => exerciseSelected(e, {id: 2, name: "Exercise B"})} type="checkbox" name="exercise-list-checkbox" id="exercise-checkbox-2" className="btn-check"/>
                <label htmlFor="exercise-checkbox-2" className="btn btn-outline-secondary">Exercise B</label> */}
            </div>
        </div>
    )
}

export default ExerciseSelectionList