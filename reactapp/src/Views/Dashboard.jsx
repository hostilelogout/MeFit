import { useEffect, useState } from "react";
import { Calendar } from "react-calendar";
import 'react-calendar/dist/Calendar.css';
import { Link } from "react-router-dom";
import { fetchGoals } from "../API/GoalAPI";
import GoalSelectionList from "../Components/Goal/GoalSelectionList";
import { getStatus } from "../Util/StatusHelper";
import Background from "../Images/backgrounds/hd-squad-color.jpeg";



const Dashboard = () => {
  const [state, setState] = useState({
    selectedGoal: null
  })
  const [goals, setGoals] = useState(null)

  useEffect(() => {
    const getGoals = async () => {
        const gs = await fetchGoals()
          .then(x => x.filter(y => getStatus(y.fkStatusId) === "Pending"))
        // console.log(gs)
        setGoals(gs.reverse())
    }
    getGoals()
  }, [])

  const goalSelected = (event, goal) => {
    // console.log(goal)
    if (event.target.checked) setState({...state, selectedGoal: goal})
    else setState({...state, selectedGoal: null})
  }

  const dateDiff = (first, second) => {
    return Math.ceil((second - first) / (1000 * 60 * 60 * 24)) + 1;
  }

  return (
    <>
      <div className="bg">
        <img src={Background} alt=""/>
      </div>
      <div id="Dashboard" className="d-flex flex-column align-items-center p-5">
        <div className="d-flex wpx-960 hpx-480">

          <div className="dashboard-item d-flex flex-column flex-fill align-items-center wp-50 hp-100 mt-2 mb-2 p-2">
            
            {/* <div className="dashboard-item flex-shrink-0 m-2 mb-0 wp-100 hp-100"> */}
              <GoalSelectionList type="radio" goals={goals} goalSelected={goalSelected}/>
            {/* </div> */}

            <div className="btn-group d-flex flex-fill justify-content-center wp-100">
              <Link to="/goals">
                <button className="btn btn-primary m-2">View all goals</button>
              </Link>
              <Link to="/goals/new">
                <button className="btn btn-secondary m-2">Create new goal</button>
              </Link>
            </div>
          </div>

          <div className="dashboard-item d-flex flex-column align-items-center flex-fill m-2 wp-50 p-2 hp-100">
                <h3>Progress</h3>
                {state.selectedGoal !== null ?
                  <>
                  <p>Goal {state.selectedGoal.id}</p>
                  {/* <p>You have {dateDiff(new Date(), new Date(state.selectedGoal.endDate))} day(s) to complete goal!</p> */}
                  {dateDiff(new Date(), new Date(state.selectedGoal.endDate)) > 0 ?
                    <p>You have {dateDiff(new Date(), new Date(state.selectedGoal.endDate))} day(s) to complete goal!</p>
                  :
                    <p>You have no more time to complete this goal.</p>
                  }
                  <p>You have completed {state.selectedGoal.workouts.filter(w => w.workoutStatus === "Completed").length} out of {state.selectedGoal.workouts.length} workouts!</p>
                  <Link to="/goals">View more details</Link>
                  </>
                : "No goal selected.."}
          </div>

        <div className="dashboard-item d-flex flex-column align-items-center p-2 mt-2 mb-2 hp-100">
          <Calendar className={["wpx-240"]}/>
        </div>

        </div>
      </div>

    </>
  );
}

export default Dashboard;