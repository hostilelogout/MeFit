import GoalCreator from "../Components/Dashboard/GoalCreator";
import GoalCalendar from "../Components/Dashboard/GoalCalendar";
import GoalProgress from "../Components/Dashboard/GoalProgress";

const Dashboard = () => {
  return (
    <>
    <div className="d-flex gap-5 justify-content-center p-5">
      <div>
        <GoalCreator/>
      </div>
      <div>
        <GoalCalendar/>
        <GoalProgress/>
      </div>
    </div>
    </>
  );
}

export default Dashboard;