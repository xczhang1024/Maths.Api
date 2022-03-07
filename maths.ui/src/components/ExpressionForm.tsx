import { AxiosError, AxiosResponse } from "axios";
import React, { useState } from "react";
import { Button, Col, Container, Form, Row } from "react-bootstrap";
import ErrorProps from "../props/ErrorProps";
import Service from "../services/Service";
import Expression from "../types/Expression";
import Result from "../types/Result";
import ErrorComponent from "./ErrorComponent";

function ExpressionForm() : JSX.Element {
    const initialExpressionState = {
        expression: ""
    };

    const initialResultState = {
        result: 0
    };

    const [expression, setExpression] = useState<Expression>(initialExpressionState);
    const [error, setError] = useState<ErrorProps>({message: ""});
    const [result, setResult] = useState<Result>(initialResultState);
    const [showResult, setShowResult] = useState<Boolean>(false);

    function onExpressionChanged(event: React.ChangeEvent<HTMLInputElement>) {
        const expr: Expression = {
            expression: event.target.value
        };
        setExpression(expr);
    }

    const handleClick = async () => {
        if(expression.expression.length === 0) {
            setError({message: "Please provide an expression"});
            setShowResult(false);
            return;
        }
        
        setError({message: ""});

        Service.sendExpression(expression)
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
                
                setShowResult(false);
            })
            .catch((e : Error) => {
                setError({message: "Failed to evaluate expression."});
                setShowResult(false);
            });
    }

    return (
        <>
            <Container>
                <h1>Evaluate Expression</h1>
                <Row>&nbsp;</Row>

                {error.message.length > 0 && 
                    <Container>
                        <ErrorComponent message={error.message}/>
                        <Row>&nbsp;</Row>
                    </Container>
                }

                <Row>
                    <Form>
                        <Col xs={5}>
                            <Form.Control placeholder="Expression" 
                                onChange={onExpressionChanged} />
                        </Col>
                        <Row>&nbsp;</Row>
                        <Button 
                            className="btn btn-primary btn-large"
                            onClick={handleClick}>
                            Evaluate
                        </Button>
                    </Form>
                </Row>

                {showResult && 
                    <>
                        <Row>&nbsp;</Row> 
                        <Row>
                            <p>The result of evaluation is: </p>
                            <p>{result.result}</p>
                        </Row>
                    </>
                }
            </Container>
            
        </>
    )
}

export default ExpressionForm;