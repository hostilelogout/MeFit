
const ExerciseSelectionList = props => {

    return (
        <div className="d-flex flex-column flex-fill align-items-center wp-100 hp-100 min-h-0 p-2">
            <p>Exercises:</p>
            <div className="d-flex flex-column flex-fill text-center overflow-y-scroll wp-100">
                {props.exercises === null ? <div className="spinner-border align-self-center" role="status"/> :
                props.exercises.map(exercise => 
                    <div className="d-flex flex-column" key={exercise.id}>
                        <input onChange={e => props.exerciseSelected(e, exercise)} type={props.type} name={"exercise-list-" + props.k} id={`exercise-${props.k}-${exercise.id}`} className="btn-check"/>
                        <label htmlFor={`exercise-${props.k}-${exercise.id}`} className="btn btn-secondary border">{exercise.name}</label>
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