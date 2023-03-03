import React from "react";
import AuthContext from "./Store/auth-context";
import Patients from "./Components/Patients";
import Navbar from "./Components/navbar";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Login from "./Components/login";
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
        <Route path="/login" element={<Login />} />
        <Route path="/patients" element={<Patients />} />
      </Routes>
    </React.Fragment>
  );
};
export default App;
