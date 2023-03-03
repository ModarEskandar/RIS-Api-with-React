import React, { Component } from "react";
import _ from "lodash";
const TableBody = (props) => {
  const renderCell = (item, column) => {
    if (column.content) return column.content(item);
    if (column.route) return column.route(item);
    else return _.get(item, column.targetProp);
  };
  const { data, columns } = props;
  return (
    <tbody>
      {data.map((item) => (
        <tr key={item._id}>
          {columns.map((column) => (
            <td key={column.label || column.key}>{renderCell(item, column)}</td>
          ))}
        </tr>
      ))}
    </tbody>
  );
};

export default TableBody;
