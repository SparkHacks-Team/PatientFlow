import "./Main.css";
import { Link } from "react-router-dom";

function ButtonLink({linkref, desc, type}) {
  return (
    <div>
      {/* <Link to="https://react.semantic-ui.com/"> */}
      <Link to={linkref}>
        <button className="btn mx-2">{desc}</button>
      </Link>
    </div>
  )
}

export default ButtonLink
