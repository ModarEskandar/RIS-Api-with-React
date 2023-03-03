import Joi from "joi-browser";
import React from "react";
import Input from "./input";
import SelectList from "./selectList";

const Form = (props) => {
  return <div>{props.children}</div>;
};
export default Form;

export const validate = (data, schema) => {
  const result = Joi.validate(data, schema, {
    abortEarly: false,
  });
  if (!result.error) return null;
  const errors = {};
  for (let item of result.error.details) errors[item.path[0]] = item.message;
  return errors;
};
export const validateProp = (input, schema) => {
  const name = input.name;
  const value = input.value;
  const obj = { [name]: value };
  const inputSchema = { [name]: schema[name] };

  const result = Joi.validate(obj, inputSchema);
  return result.error ? { [name]: result.error.details[0].message } : {};
};

export const renderButton = (label, data, schema) => {
  return (
    <button
      disabled={validate(data, schema)}
      className="btn btn-primary"
      type="submit"
    >
      {label}
    </button>
  );
};

export const renderInput = (
  data,
  errors,
  handleChange,
  input,
  label,
  type = "text",
  placeholder = ""
) => {
  return (
    <Input
      name={input}
      label={label}
      onChange={handleChange}
      placeholder={placeholder}
      type={type}
      value={data[input]}
      error={errors[input]}
    ></Input>
  );
};
export function renderSelectList(
  data,
  errors,
  handleChange,
  items,
  input,
  label
) {
  return (
    <SelectList
      items={items}
      name={input}
      label={label}
      onChange={handleChange}
      value={data[input]}
      error={errors[input]}
    ></SelectList>
  );
}
