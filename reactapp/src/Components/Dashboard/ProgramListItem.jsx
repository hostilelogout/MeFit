const ProgramListItem = props => {

    return (
        <li>
            <input onChange={props.programSelected} type="radio" name="ProgramItemRadio" id={"radio" + props.program.id} className="btn-check"/>
            <label htmlFor={"radio" + props.program.id} className="list-group-item btn btn-danger bg-red">
                {props.program.name}
            </label>
        </li>
    )
}

export default ProgramListItem