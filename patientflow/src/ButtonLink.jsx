import "./Main.css";
import { Link } from "react-router-dom";

function ButtonLink() {
  return (
    <div>
      {/* <Link to="https://react.semantic-ui.com/"> */}
      <Link to="/test">
        <button>Start Here</button>
      </Link>
    </div>
  )
}

export default ButtonLink
