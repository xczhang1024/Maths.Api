import { Row } from "react-bootstrap";
import ErrorProps from "../props/ErrorProps";

function ErrorComponent({ message }:ErrorProps) : JSX.Element {
    return <Row className="Error">{message}</Row>;
}

export default ErrorComponent;
