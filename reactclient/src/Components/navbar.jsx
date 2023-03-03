import React from "react";
import { NavLink } from "react-router-dom";

const NavBar = () => {
  return (
    <nav className="navbar navbar-expand-md navbar-dark mb-4">
      <div className="container-fluid">
        <a className="nav-item nav-link disabled" href="/">
          VidApp
        </a>
        <div className="collapse navbar-collapse">
          <div className="navbar navbar-nav">
            <NavLink className="nav-item nav-link" to="/movies">
              Movies
            </NavLink>
            <NavLink className="nav-item nav-link" to="/form">
              form1
            </NavLink>
            <NavLink className="nav-item nav-link" to="/posts">
              Posts
            </NavLink>
            <NavLink className="nav-item nav-link" to="/customers">
              Customers
            </NavLink>

            <NavLink className="nav-item nav-link" to="/rentals">
              Rentals
            </NavLink>
            <NavLink className="nav-item nav-link" to="/login">
              Login
            </NavLink>
            <NavLink className="nav-item nav-link" to="/register">
              Register
            </NavLink>
          </div>
        </div>
      </div>
    </nav>
  );
};

export default NavBar;
