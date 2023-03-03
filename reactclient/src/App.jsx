import React from "react";
import AuthContext from "./Store/auth-context";
import Patients from "./Components/patientsList";
import Navbar from "./Components/navbar";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Login from "./Components/logincopy";
import useToken from "./useToken";
const App = () => {
  const { token, setToken } = useToken();
  if (!token) {
    {
      return <Login setToken={setToken} />;
    }
  }
  return (
    <React.Fragment>
      <Navbar></Navbar>

      <Routes>
        <Route path="/logincopy" element={<Login />} />
        <Route path="/patients" element={<Patients />} />
      </Routes>
    </React.Fragment>
  );
};
export default App;
