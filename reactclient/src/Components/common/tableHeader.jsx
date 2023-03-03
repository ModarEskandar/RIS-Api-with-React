import React, { Component } from "react";

// columns: array
// onSort: func
// sortColumn
class TableHeader extends Component {
  raiseSort = (targetProp) => {
    let sortColumn = this.props.sortColumn;
    if (sortColumn.targetProp === targetProp && targetProp)
      sortColumn.order = sortColumn.order === "asc" ? "desc" : "asc";
    else if (sortColumn.targetProp !== targetProp && targetProp)
      sortColumn = { targetProp, order: "asc" };
    this.props.onSort(sortColumn);
  };
  render() {
    return (
      <thead>
        <tr>
          {this.props.columns.map((column) => (
            <th
              key={column.label || column.key}
              onClick={() => this.raiseSort(column.targetProp)}
              sortColumn={this.props.sortColumn}
              style={{ cursor: "pointer" }}
            >
              {column.label}
            </th>
          ))}
        </tr>
      </thead>
    );
  }
}

export default TableHeader;
