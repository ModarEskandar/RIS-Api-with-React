import React, { useState } from "react";
import useToken from "../useToken";
import Login from "./Login";

const Dashboard = () => {
  const { token, setToken } = useToken();
  if (!token) {
    {
      return <Login setToken={setToken} />;
    }
  }
  return <div className="text-white font-bold text-2xl">Dashboard</div>;
};

export default Dashboard;
