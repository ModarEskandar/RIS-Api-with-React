import React, { Component } from "react";
import { Link } from "react-router-dom";
import Like from "./common/Like";
import TableBody from "./common/tableBody";
import TableHeader from "./common/tableHeader";

const PatientsTable = (props) => {
  const columns = [
    {
      label: "Name",
      targetProp: "firstname",
      content: (patient) => (
        <Link to={`/patients/${patient.id}`} patientid={patient.id}>
          {patient.firstname}
        </Link>
      ),
    },
    { label: "Given Id", targetProp: "givenid" },
    { label: "Insertion date", targetProp: "insertdate" },
    { label: "NID", targetProp: "nationalidnumber" },
    {
      key: "Update",
      content: (patient) => (
        <button className="btn btn-primary" onClick={() => onUpdate(patient)}>
          Update
        </button>
      ),
    },
    {
      key: "Delete",
      content: (patient) => (
        <button className="btn btn-danger" onClick={() => onDelete(patient)}>
          Delete
        </button>
      ),
    },
  ];
  const { patients, onUpdate, onDelete, sortColumn, onSort } = props;

  return (
    <table className="table">
      <TableHeader
        columns={columns}
        sortColumn={sortColumn}
        onSort={onSort}
      ></TableHeader>
      <TableBody data={patients} columns={columns}></TableBody>
    </table>
  );
};

export default PatientsTable;
