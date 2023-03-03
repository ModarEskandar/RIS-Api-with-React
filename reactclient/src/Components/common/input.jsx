import React from "react";
const Input = ({ error, name, label, ...rest }) => {
  return (
    <div className="form-floating">
      <input {...rest} className="form-control" id={name} name={name} />
      <label htmlFor={name}>{label}</label>
      {error && <div className="alert alert-danger">{error}</div>}
    </div>
  );
};

export default Input;
