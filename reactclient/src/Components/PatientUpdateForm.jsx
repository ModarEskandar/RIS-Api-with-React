import React, { Component } from "react";
import { useState } from "react";
import constants from "../Utilities/Constants";
export default function PatientUpdateForm(props) {
  const initialFormData = Object.freeze({
    Insertdate: props.patient.Insertdate,
    Givenid: props.patient.Givenid,
    Nationalidnumber: props.patient.Nationalidnumber,
    Firstname: props.patient.Firstname,
    Middlename: props.patient.Middlename,
    Lastname: props.patient.Lastname,
    Gendre: props.patient.Gendre,
  });
  const [formData, setFormData] = useState(initialFormData);

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };
  const handleSubmit = (e) => {
    e.preventDefault();
    const patientToUpdate = {
      patientId: props.patient.patientId,
      Insertdate: "",
      Givenid: formData.Givenid,
      Nationalidnumber: formData.Nationalidnumber,
      Firstname: formData.Firstname,
      Middlename: formData.Middlename,
      Lastname: formData.Lastname,
      Gendre: formData.Gendre,
    };
    const url = constants.API_URL_UPDATE_PATIENT;
    console.log(url);
    fetch(url, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(patientToUpdate),
    })
      .then((response) => response.json())
      .then((responseFromServer) => {
        console.log(responseFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
    props.onPatientUpdated(patientToUpdate);
  };
  return (
    <div>
      <form className="w-100 px-5">
        <h1 className="mt=5">
          Updating Patient Titled "{props.patient.title}"
        </h1>
        <div className="mt=5">
          <label className="h3 form-label">Patient First Name</label>
          <input
            className="form-control"
            value={formData.Firstname}
            name="Firstname"
            type="text"
            onChange={handleChange}
          ></input>
        </div>
        <div className="mt=5">
          <label className="h3 form-label">Patient Last Name</label>
          <input
            className="form-control"
            value={formData.Lastname}
            name="Lastname"
            type="text"
            onChange={handleChange}
          ></input>
        </div>
        <div className="mt=4">
          <label className="h3 form-label">Patient Givenid</label>
          <input
            className="form-control"
            value={formData.Givenid}
            name="Givenid"
            type="text"
            onChange={handleChange}
          ></input>
        </div>
        <div className="mt=4">
          <label className="h3 form-label">Patient Nationalidnumber</label>
          <input
            className="form-control"
            value={formData.Nationalidnumber}
            name="Nationalidnumber"
            type="text"
            onChange={handleChange}
          ></input>
        </div>
        <button
          className="btn btn-dark btn-lg w-100 mt-5"
          onClick={handleSubmit}
        >
          Submit
        </button>
        <button
          className="btn btn-danger btn-lg w-100 mt-3"
          onClick={() => props.onPatientUpdated(null)}
        >
          Cancel
        </button>
      </form>
    </div>
  );
}
