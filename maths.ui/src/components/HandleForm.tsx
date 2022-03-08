import { useState } from "react";

/** Component for handling form actions */
export const HandleForm = (callback: any, initialState = {}) => {
    const [values, setValues] = useState(initialState);

    /** When form values are changed, set values with the name of the input fields */
    const onChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setValues({ ...values, [event.target.name]: event.target.value });
    };

    /** Call the callback function when the submit button is pressed */
    const onSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        await callback();
    };

    return {
        onChange,
        onSubmit,
        values,
    };
}