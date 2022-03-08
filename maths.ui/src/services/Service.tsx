import http from "../HttpCommon";
import ApiInput from "../types/ApiInput"

/** Send expression to the Api */
const sendExpression = ( expression : string) => {
    const apiInput : ApiInput = {
        expression: expression
    }

    return http.post("/Maths/expression/evaluate", apiInput)
}

/** Service for interacting with Maths.Api */
const Service = {
    sendExpression
};

export default Service;