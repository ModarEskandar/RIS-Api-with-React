import React, { useState } from "react";
import constants from "../Utilities/Constants";
import PatientCreateForm from "./PatientCreateForm";
import PatientUpdateForm from "./PatientUpdateForm";
export default function Patients() {
  const [patients, setPatients] = useState([]);
  const [showCreateForm, setShowCreateForm] = useState(false);
  const [patientBiengUpdated, setPatientBiengUpdated] = useState(null);

  function getPatients() {
    const url = constants.API_URL_GET_ALL_PATIENTS;
    // const url = "https://localhost:7025/get-all-patients";
    console.log(constants.API_URL_GET_ALL_PATIENTS);
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
  }
  function deletePatient(patientId) {
    const url = `${constants.API_URL_DELETE_PATIENT}/${patientId}`;
    // const url = "https://localhost:7025/delete-patient";
    console.log(constants.API_URL_GET_ALL_PATIENTS);
    fetch(url, {
      method: "Delete",
    })
      .then((response) => response.json())
      .then((responseFromServer) => {
        console.log(responseFromServer);
        onPatientDeleted(patientId);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }

  return (
    <div className="row min-vh-100">
      <div className="col d-flex flex-column justify-content-center align-items-center">
        {showCreateForm === false && patientBiengUpdated === null && (
          <div>
            <h1>ASP.NET React Patients Application</h1>
            <div className="mt-5">
              <button
                className="btn btn-primary btn-lg w-100"
                onClick={getPatients}
              >
                Get Patients
              </button>{" "}
              <button
                className="btn btn-primary btn-lg w-100 mt-4"
                onClick={() => {
                  setShowCreateForm(true);
                }}
              >
                Create New Patient
              </button>
            </div>
          </div>
        )}

        {patients.length > 0 &&
          showCreateForm === false &&
          patientBiengUpdated === null &&
          renderPatientsTable()}
        {showCreateForm && (
          <PatientCreateForm onPatientCreated={onPatientCreated} />
        )}
        {patientBiengUpdated && (
          <PatientUpdateForm
            patient={patientBiengUpdated}
            onPatientUpdated={onPatientUpdated}
          />
        )}
      </div>
    </div>
  );
  function renderPatientsTable() {
    return (
      <div className=" mt-5">
        <table className="table table-borderd border-dark">
          <thead>
            <th scope="col">PatientId</th>
            <th scope="col">NAME</th>
            <th scope="col">Given Id</th>
            <th scope="col">Date</th>
            <th scope="col">CRUD Operations</th>
          </thead>
          <tbody>
            {patients.map((patient) => (
              <tr key={patient.id}>
                <th scope="row">{patient.id}</th>
                <td>{patient.firstname}</td>
                <td>{patient.givenid}</td>
                <td>{patient.insertdate}</td>
                <td>
                  <button
                    className="btn btn-dark btn-lg mx-3 my-3"
                    onClick={() => setPatientBiengUpdated(patient)}
                  >
                    Update
                  </button>
                  <button
                    className="btn btn-secondary btn-lg mx-3 my-3"
                    onClick={() => {
                      if (
                        window.confirm(
                          `Are you Sure deleting patient "${patient.Firstname}"`
                        )
                      )
                        deletePatient(patient.patientId);
                    }}
                  >
                    Delete
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
        <button
          className="btn btn-danger btn-lg w-100"
          onClick={() => setPatients([])}
        >
          Clear The Patient table
        </button>
      </div>
    );
  }
  function onPatientCreated(createdPatient) {
    setShowCreateForm(false);
    if (createdPatient === null) {
      return;
    }
    alert(`Patient "${createdPatient.title}" Successfully Created :)`);
    // getPatients();
  }
  function onPatientUpdated(updatedPatient) {
    setPatientBiengUpdated(null);
    if (updatedPatient === null) return;
    let patientsCopy = [...patients];
    const index = patientsCopy.findIndex(
      (patientsCopypatient, currentIndex) => {
        if (patientsCopypatient.patientId === updatedPatient.patientId) {
          return true;
        }
      }
    );
    if (index !== -1) patientsCopy[index] = updatedPatient;
    setPatients(patientsCopy);
    alert(`Patient "${updatedPatient.title}" Successfully Updated`);
    // getPatients();
  }
  function onPatientDeleted(deletedPatientId) {
    let patientsCopy = [...patients];
    const index = patientsCopy.findIndex(
      (patientsCopypatient, currentIndex) => {
        if (patientsCopypatient.patientId === deletedPatientId) {
          return true;
        }
      }
    );
    if (index !== -1) patientsCopy.splice(index, 1);
    setPatients(patientsCopy);
    alert(`Patient "${deletedPatientId}" Successfully Deleted`);
  }
}
