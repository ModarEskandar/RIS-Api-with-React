import React, { Component, useEffect, useState } from "react";
import Pagination from "./common/pagination";
import { paginate } from "../utils/paginate";
import GroupList from "./common/groupList";
import PatientsTable from "./patientsTable";
import _ from "lodash";
import { NavLink } from "react-router-dom";
import constants from "../Utilities/Constants";
const Patients = () => {
  const [patients, setPatients] = useState([]);
  const [pageSize, setPagesize] = useState(4);
  const [currentPage, setCurrentPage] = useState(1);
  const [sortColumn, setSortColumn] = useState({
    targetProp: "firstname",
    order: "asc",
  });
  const url = "https://localhost:7025/api/Patients";

  useEffect(() => {
    const getPatients = async () => {
      fetch(url, {
        method: "Get",
      })
        .then((response) => response.json())
        .then((patientsFromServer) => {
          setPatients(patientsFromServer);
        })
        .catch((error) => {
          console.log(error);
          alert(error);
        });
    };
    getPatients();
    console.log("Patients fetched");
  }, []);
  const handleDelete = (patient) => {
    const updatedPatients = patients.filter((m) => m._id !== patient._id);
    setPatients(updatedPatients);
  };
  const handleLikeClick = (patient) => {
    const updatedPatients = patients;
    const index = patients.indexOf(patient);
    updatedPatients[index].liked = !updatedPatients[index].liked;
    setPatients(updatedPatients);
  };
  const handlePageChange = (currentPage) => {
    setCurrentPage(currentPage);
  };

  const handleSort = (sortColumn) => {
    console.log(sortColumn);
    setSortColumn(sortColumn);
  };

  const sortedPatients = _.orderBy(
    patients,
    sortColumn.targetProp,
    sortColumn.order
  );
  //   setPatients(paginate(sortedPatients, currentPage, pageSize));
  const count = sortedPatients.length;
  return (
    <div>
      <div className="row">
        <div className="col">
          <h1>{`showing ${count} patients`}</h1>
          <NavLink
            className="btn btn-lg btn-primary"
            to="/patients/:patientId"
            patientid="new"
          >
            Add Patient
          </NavLink>
          <PatientsTable
            patients={patients}
            onLike={handleLikeClick}
            onDelete={handleDelete}
            sortColumn={sortColumn}
            onSort={handleSort}
          ></PatientsTable>
          <Pagination
            itemsCount={count}
            pageSize={pageSize}
            onPageChange={handlePageChange}
            currentPage={currentPage}
          ></Pagination>
        </div>
      </div>
    </div>
  );
};

export default Patients;
