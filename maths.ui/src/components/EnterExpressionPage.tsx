import { AxiosError, AxiosResponse } from "axios";
import { useState } from "react";
import { Button, Col, Container, Form, Row } from "react-bootstrap";
import ErrorProps from "../props/ErrorProps";
import Service from "../services/Service";
import Result from "../types/Result";
import ErrorComponent from "./ErrorComponent";
import { HandleForm } from "./HandleForm";
import ResultComponent from "./ResultComponent";

/** This is the main page for the application 
 * where the user can enter an expression to be evaluated */
function EnterExpressionPage() : JSX.Element {
    
    const initialFormState = {
        expression: ""
    };

    const initialResultState = {
        result: 0
    };

    const initalErrorState = {
        message: ""
    };

    const [error, setError] = useState<ErrorProps>(initalErrorState);
    const [result, setResult] = useState<Result>(initialResultState);
    const [showResult, setShowResult] = useState<Boolean>(false);

    /** Handle when the form Submit button is clicked
     *  Send expression to Api and get back the result
     */
    const handleSubmit = () => {
        setError(initalErrorState);
        setShowResult(false);

        const map = new Map(Object.entries(values));
        let exp : string = map.get("expression") as string;

        Service.sendExpression(exp)
            .then((response : AxiosResponse) => {
                setResult(response.data);
                setShowResult(true);
            })
            .catch((err : AxiosError) => {
                if(err.response != null 
                    && err.response.data != null) {
                    setError({message: err.response.data["message"]});
                }
                else {
                    setError({message: "Failed to evaluate expression."});
                }
            })
            .catch((e : Error) => {
                setError({message: "Failed to evaluate expression."});
            });
    }

    /** Use the HandleForm component to handle form change and submit */
    const { onChange, onSubmit, values } = HandleForm(
        handleSubmit,
        initialFormState
    );

    return (
        <>
            <Container>
                <h1 >Evaluate an Expression</h1>

                {error.message.length > 0 && 
                    <Container>
                        <ErrorComponent message={error.message}/>
                        <Row>&nbsp;</Row>
                    </Container>
                }

                <Row>
                    <Form onSubmit={onSubmit}>
                        <Col xs={5}>
                            <Form.Control placeholder="Expression" 
                                name = "expression"
                                id = "expression"
                                required
                                onChange={onChange} />
                        </Col>
                        <Row>&nbsp;</Row>
                        <Button 
                            className="btn btn-primary btn-large"
                            type="submit">
                            Evaluate
                        </Button>
                    </Form>
                </Row>

                <Container>
                    <Row>&nbsp;</Row>
                    {showResult && <ResultComponent result={result.result}/>}
                </Container>
            </Container>           
        </>
    )
}

export default EnterExpressionPage;