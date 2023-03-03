import React from "react";
import propTypes from "prop-types";

const GroupList = ({
  items,
  selectedItems,
  onGroupChange,
  textProp,
  valueProp,
}) => {
  return (
    <div className="list-group">
      {items.map((item) => (
        <a
          href="#a"
          key={item[valueProp]}
          onClick={() => onGroupChange(item)}
          className={
            selectedItems.includes(item[valueProp])
              ? "list-group-item active"
              : "list-group-item"
          }
        >
          {item[textProp]}
        </a>
      ))}
    </div>
  );
};
GroupList.defaultProps = {
  textProp: "name",
  valueProp: "_id",
};
GroupList.propTypes = {
  items: propTypes.array.isRequired,
  onGroupChange: propTypes.func.isRequired,
  selectedItems: propTypes.array.isRequired,
};

export default GroupList;
