import { Row } from "react-bootstrap";
import ErrorProps from "../props/ErrorProps";

/** Component for displaying error in a row */
function ErrorComponent({ message }:ErrorProps) : JSX.Element {
    return <Row className="Error">{message}</Row>;
}

export default ErrorComponent;
