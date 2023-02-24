import React, { Component, useState } from "react";
import PropTypes from "prop-types";

async function LoginUser(credentials) {
  console.log(JSON.stringify(credentials));
  fetch("https://localhost:7025/Api/Accounts/Login", {
    method: "POST",
    header: {
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
  const [email, setEmail] = useState();
  const [password, setPassword] = useState();

  const handleSubmit = async (e) => {
    e.preventDefault();
    const token = await LoginUser({
      email,
      password,
    });
    setToken(token);
    console.log(token);
  };
  return (
    <form className="form">
      <div className="form-outline mb-4">
        <input
          type="email"
          id="form2Example1"
          className="form-control"
          onChange={(e) => setEmail(e.target.value)}
        />
        <label className="form-label" htmlFor="form2Example1">
          Email address
        </label>
      </div>

      <div className="form-outline mb-4">
        <input
          type="password"
          id="form2Example2"
          className="form-control"
          onChange={(e) => setPassword(e.target.value)}
        />
        <label className="form-label" htmlFor="form2Example2">
          Password
        </label>
      </div>

      <button
        type="button"
        className="btn btn-primary btn-block mb-4"
        onClick={handleSubmit}
      >
        Sign in
      </button>
    </form>
  );
};
Login.propTypes = {
  setToken: PropTypes.func.isRequired,
};
export default Login;
