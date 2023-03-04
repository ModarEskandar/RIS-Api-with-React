const API_URL_DEV = "https://localhost:7025/api";
const API_URL_PRODUCTION = "https://appname.azurewebsites.net";

const GET_ALL_PATIENTS = "Patients";
const GET_PATIENT_BY_ID = "get-patient-by-id";
const CREATE_PATIENT = "create-patient";
const UPDATE_PATIENT = "update-patient";
const DELETE_PATIENT = "delete-patient";

const DEVELOPMENT = {
  API_URL_GET_ALL_PATIENTS: `${API_URL_DEV}/${GET_ALL_PATIENTS}`,
  API_URL_GET_PATIENT_BY_ID: `${API_URL_DEV}/${GET_PATIENT_BY_ID}`,
  API_URL_CREATE_PATIENT: `${API_URL_DEV}/${CREATE_PATIENT}`,
  API_URL_UPDATE_PATIENT: `${API_URL_DEV}/${UPDATE_PATIENT}`,
  API_URL_DELETE_PATIENT: `${API_URL_DEV}/${DELETE_PATIENT}`,
};

const PRODUCTION = {
  API_URL_GET_ALL_PATIENTS: `${API_URL_PRODUCTION}/${GET_ALL_PATIENTS}`,
  API_URL_GET_PATIENT_BY_ID: `${API_URL_PRODUCTION}/${GET_PATIENT_BY_ID}`,
  API_URL_CREATE_PATIENT: `${API_URL_PRODUCTION}/${CREATE_PATIENT}`,
  API_URL_UPDATE_PATIENT: `${API_URL_PRODUCTION}/${UPDATE_PATIENT}`,
  API_URL_DELETE_PATIENT: `${API_URL_PRODUCTION}/${DELETE_PATIENT}`,
};

const constants =
  process.env.NODE_ENV === "development" ? DEVELOPMENT : PRODUCTION;
export default constants;
