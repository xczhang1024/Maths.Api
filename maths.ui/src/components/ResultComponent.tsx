import { Row } from "react-bootstrap";
import ResultProps from "../props/ResultProps";

/** Component for displaying the result from Api */
function ResultComponent({ result }:ResultProps) : JSX.Element {
    return <>
        <Row>
            <p>
                The result of evaluation is: <b>{result}</b>
            </p>
        </Row>
    </>
}

export default ResultComponent;