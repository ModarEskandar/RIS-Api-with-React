import React, { Component } from "react";
import { useState } from "react";
import constants from "../Utilities/Constants";
export default function PatientCreateForm(props) {
  const initialFormData = Object.freeze({
    Insertdate: "2022-08-19T17:41:58.914Z",
    Givenid: "string",
    Nationalidnumber: "2022-08-17T",
    Firstname: "Fpatient",
    Middlename: "string",
    Lastname: "Lpatient",
    Gendre: 0,
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
    const patientToCreate = {
      patientId: 0,
      Insertdate: "",
      Givenid: formData.Givenid,
      Nationalidnumber: formData.Nationalidnumber,
      Firstname: formData.Firstname,
      Middlename: formData.Middlename,
      Lastname: formData.Lastname,
      Gendre: formData.Gendre,
    };
    const url = constants.API_URL_CREATE_PATIENT;
    console.log(url);
    fetch(url, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(patientToCreate),
    })
      .then((response) => response.json())
      .then((responseFromServer) => {
        console.log(responseFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
    props.onPatientCreated(patientToCreate);
  };
  return (
    <div>
      <form className="w-100 px-5">
        <h1 className="mt=5">Create new Patient</h1>
        <div className="mt=5">
          <label className="h3 form-label">Date</label>
          <input
            className="form-control"
            value={formData.Insertdate}
            name="Insertdate"
            type="text"
            onChange={handleChange}
          ></input>
        </div>
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
          <label className="h3 form-label">Patient Middle Name</label>
          <input
            className="form-control"
            value={formData.Middlename}
            name="Middlename"
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
        <div className="mt=4">
          <label className="h3 form-label">Patient Gendre</label>
          <input
            className="form-control"
            value={formData.Gendre}
            name="Gendre"
            type="number"
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
          onClick={() => props.onPatientCreated(null)}
        >
          Cancel
        </button>
      </form>
    </div>
  );
}
