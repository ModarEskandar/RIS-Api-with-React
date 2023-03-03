import React, { Component, useState } from "react";
import Joi from "joi-browser";
import Form, {
  renderInput,
  renderButton,
  validateProp,
  validate,
} from "./common/form";
// import PropTypes from "prop-types";

async function LoginUser(credentials) {
  console.log(JSON.stringify(credentials));
  return fetch("https://localhost:7025/Api/Accounts/Login", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(credentials),
  })
    .then((data) => data.json())
    .catch((error) => {
      console.log(error);
      alert(error);
    });
}
const Login = ({ setToken }) => {
  const [data, setData] = useState({
    email: "",
    password: "",
  });
  const [errors, setErrors] = useState({});
  const schema = {
    email: Joi.string().email().required(),
    password: Joi.string().required(),
  };
  const handleChange = ({ currentTarget: input }) => {
    const inputData = { ...data };
    inputData[input.name] = input.value;
    setData(inputData);
    setErrors(validateProp(input, schema));
  };
  const doSubmit = () => {
    console.log("signed in");
  };
  const handleSubmit = async (e) => {
    e.preventDefault();
    setErrors({ errors: validate(data, schema) || {} });

    if (errors) console.log(errors);
    const token = await LoginUser(data);
    console.log(token);

    setToken(token);
  };
  return (
    <main className="form-signin w-50 m-auto">
      <form onSubmit={handleSubmit}>
        <h1 className="h3 mb-3 fw-normal">Please sign in</h1>
        {renderInput(data, errors, handleChange, "email", "Username")}
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
// Login.propTypes = {
//   setToken: PropTypes.func.isRequired,
// };
export default Login;
