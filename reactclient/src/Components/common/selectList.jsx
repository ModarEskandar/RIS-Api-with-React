import React from "react";

const SelectList = ({ items, error, name, label, ...rest }) => {
  return (
    <div className="form-floating">
      <select
        id={name}
        name={name}
        {...rest}
        className="form-select"
        aria-label={label}
      >
        <option value=""></option>
        {items.map((item) => (
          <option key={item._id} value={item._id}>
            {item.name}
          </option>
        ))}
      </select>
      {error && <div className="alert alert-danger">{error}</div>}
    </div>
  );
};

export default SelectList;
