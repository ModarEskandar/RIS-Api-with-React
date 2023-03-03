import React from "react";
import Joi from "joi-browser";
import { useState } from "react";
import Form, {
  renderInput,
  renderButton,
  validateProp,
  validate,
} from "./common/form";

const Login = (props) => {
  const [data, setData] = useState({
    username: "",
    password: "",
  });
  const [errors, setErrors] = useState({});
  const schema = {
    username: Joi.string().required(),
    password: Joi.string().required(),
  };
  const handleChange = ({ currentTarget: input }) => {
    console.log(schema);
    const inputData = { ...data };
    inputData[input.name] = input.value;
    setData(inputData);
    setErrors(validateProp(input, schema));
  };
  const doSubmit = () => {
    console.log("signed in");
  };
  const handleSubmit = (e) => {
    e.preventDefault();
    setErrors({ errors: validate(data, schema) || {} });
    if (errors) return;
    doSubmit();
  };
  return (
    <main className="form-signin w-50 m-auto">
      <form onSubmit={handleSubmit}>
        <h1 className="h3 mb-3 fw-normal">Please sign in</h1>
        {renderInput(data, errors, handleChange, "username", "Username")}
        {renderInput(
          data,
          errors,
          handleChange,
          "password",
          "Password",
          "password"
        )}

        <div className="checkbox mb-3">
          <label>
            <input type="checkbox" value="remember-me" /> Remember me
          </label>
        </div>
        {renderButton("Sign in", data, schema)}
        <p className="mt-5 mb-3 text-muted">&copy; 2017–2022</p>
      </form>
    </main>
  );
};

export default Login;
