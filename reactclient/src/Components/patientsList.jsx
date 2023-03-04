import React, { Component, useEffect, useState } from "react";
import Pagination from "./common/pagination";
import { paginate } from "../utils/paginate";
import { ToastContainer, toast } from "react-toastify";
import GroupList from "./common/groupList";
import PatientsTable from "./patientsTable";
import _ from "lodash";
import { NavLink } from "react-router-dom";
import constants from "../Utilities/Constants";
const Patients = () => {
  const [patients, setPatients] = useState([]);
  const [patientsInPage, setPatientsInPage] = useState([]);
  const [pageSize, setPagesize] = useState(2);
  const [currentPage, setCurrentPage] = useState(1);
  const [sortColumn, setSortColumn] = useState({
    targetProp: "firstname",
    order: "asc",
  });
  const url = constants.API_URL_GET_ALL_PATIENTS;

  useEffect(() => {
    const getPatients = async () => {
      await fetch(url, {
        method: "Get",
      })
        .then((response) => response.json())
        .then((patientsFromServer) => {
          setPatients(patientsFromServer);
          setPatientsInPage(
            paginate(patientsFromServer, currentPage, pageSize)
          );
        })
        .catch((error) => {
          console.log(error);
          alert(error);
        });
    };
    getPatients();

    console.log("Patients fetched");
  }, []);

  const handleUpdate = async (patient) => {
    const originalPatients = [...patients];
    const index = patients.indexOf(patient);
    let updatedPatients = [...patients];
    patient.firstname = `fi${patient.id}`;
    patient.middlename = `mid${patient.id}`;
    updatedPatients[index] = patient;
    setPatients(updatedPatients);
    const patientId = patient.id;
    let updatedPatient = patient;
    delete updatedPatient.orders; // or delete patient["orders"];
    delete updatedPatient.id; // or delete patient["id"];
    console.log(JSON.stringify(updatedPatient));
    try {
      const response = await fetch(`${url}/${patientId}`, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
          accept: "*/*",
        },
        body: JSON.stringify(updatedPatient),
      });
      if (!response.ok) {
        setPatients(originalPatients);

        const error = await response.json();

        throw error ? error : "Something bad happended";
      }

      toast.success("Patient updated successfully :)", {
        position: toast.POSITION.TOP_LEFT,
      });
    } catch (error) {
      setPatients(originalPatients);
      console.log(error);
      const resMessage = error.message || error.detail || error.toString();
      toast.error(resMessage, {
        position: "top-right",
      });
    }
  };
  const deletePatient = async (patient) => {
    const originalPatients = [...patients];
    const updatedPatients = [...patients.filter((p) => p.id !== patient.id)];
    setPatients(updatedPatients);
    try {
      const response = await fetch(`${url}/${patient.id}`, {
        method: "DELETE",
      });
      if (!response.ok) {
        const error = await response.json();
        setPatients(originalPatients);
        throw error ? error : "Something bad happended";
      }

      toast("Patient deleted successfully", {
        type: "warning",
        position: "top-right",
      });
    } catch (error) {
      const resMessage = error.message || error.detail || error.toString();
      toast.error(resMessage, {
        position: "top-right",
      });
    }
  };

  const handleDelete = (patientId) => {
    if (window.confirm("Are you sure")) {
      deletePatient(patientId);
    }
  };
  // const handleDelete = async (patient) => {
  //   const originalPatients = [...patients];
  //   const updatedPatients = [...patients.filter((p) => p.id !== patient.id)];
  //   setPatients(updatedPatients);
  //   try {
  //     await axios.delete(`${endpointAPI}/${patient.id}`);
  //     throw new Error("");
  //   } catch (error) {
  //     alert("server error! deleteng patient failed");
  // setPatients(originalPatients);
  //   }
  // };
  // const handleDelete = (patient) => {
  //   const updatedPatients = patients.filter((m) => m.id !== patient.id);
  //   setPatients(updatedPatients);
  // };
  // const handleUpdate = (patient) => {
  //   const updatedPatients = patients;
  //   const index = patients.indexOf(patient);
  //   updatedPatients[index].liked = !updatedPatients[index].liked;
  //   setPatients(updatedPatients);
  // };
  const handlePageChange = (currentPage) => {
    setCurrentPage(currentPage);
  };

  const handleSort = (sortColumn) => {
    setSortColumn(sortColumn);
    const sortedPatients = _.orderBy(
      patients,
      sortColumn.targetProp,
      sortColumn.order
    );
    setPatients(sortedPatients);
    setPatientsInPage(paginate(sortedPatients, currentPage, pageSize));
  };

  // useEffect(() => {
  //   console.log("WOOOOOOOOOOOOOw1", patients);

  //   const sortedPatients = _.orderBy(
  //     patients,
  //     sortColumn.targetProp,
  //     sortColumn.order
  //   );
  //   console.log("WOOOOOOOOOOOOOw2", sortedPatients);
  //   console.log("WOOOOOOOOOOOOOw2", sortColumn);

  //   setPatients(sortedPatients);
  // }, [sortColumn]);
  useEffect(() => {
    setPatientsInPage(paginate(patients, currentPage, pageSize));
  }, [currentPage]);

  const count = patients.length;
  return (
    <div>
      <div className="row">
        <div className="col-2">
          {" "}
          <ToastContainer />
        </div>
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
            patients={patientsInPage}
            onUpdate={handleUpdate}
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
