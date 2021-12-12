import React, { Component } from "react";
import "./Header.css";
// import Logo from "../Media/images/isaac-logo-white.png";
import { Link } from "react-router-dom";

class Header extends Component {
  render() {
    return (
      <header className="page-header">
        <Link id="Logo" to="/">
          <img alt="ISAAC"></img>
          {/* src={Logo} */}
        </Link>
        <div id="Links">
          <div>
            <Link to="/arduino/preset">
              <img className="NavIcon FloorIcon" alt="" />
              Presets
            </Link>
          </div>
          <div>
            <Link to="/arduino">
              <img className="NavIcon AccesIcon" alt="" />
              Arduinos{" "}
            </Link>
          </div>
          {/* <div>
            <Link to="/errorlog">
              <img className="NavIcon ErrorIcon" alt="" />
              Error logs{" "}
            </Link>
          </div> */}
        </div>
      </header>
    );
  }
}

export default Header;
