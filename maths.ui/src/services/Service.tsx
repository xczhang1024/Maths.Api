import http from "../HttpCommon";
import Expression from "../types/Expression"

const sendExpression = ( expression : Expression) => {
    return http.post("/Maths/Expression/Evaluate", expression)
}

const Service = {
    sendExpression
};

export default Service;