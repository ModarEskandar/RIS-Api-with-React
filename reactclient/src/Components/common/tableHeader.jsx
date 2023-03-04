import React, { Component, useState } from "react";

// columns: array
// onSort: func
// sortColumn
const TableHeader = (props) => {
  const [sortColumn, setSortColumn] = useState(props.sortColumn);
  const raiseSort = (targetProp) => {
    if (sortColumn.targetProp === targetProp && targetProp)
      setSortColumn({
        targetProp,
        order: sortColumn.order === "asc" ? "desc" : "asc",
      });
    else if (sortColumn.targetProp !== targetProp && targetProp)
      setSortColumn({ targetProp, order: "asc" });
    props.onSort(sortColumn);
  };

  return (
    <thead>
      <tr>
        {props.columns.map((column) => (
          <th
            key={column.label || column.key}
            onClick={() => raiseSort(column.targetProp)}
            style={{ cursor: "pointer" }}
          >
            {column.label}
          </th>
        ))}
      </tr>
    </thead>
  );
};

export default TableHeader;
