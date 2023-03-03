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
      key: "Like",
      content: (patient) => (
        <Like liked={patient.liked} onLikeClick={() => onLike(patient)}></Like>
      ),
    },
    {
      key: "Control",
      content: (patient) => (
        <button className="btn btn-danger" onClick={() => onDelete(patient)}>
          Delete
        </button>
      ),
    },
  ];
  const { patients, onLike, onDelete, sortColumn, onSort } = props;

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
