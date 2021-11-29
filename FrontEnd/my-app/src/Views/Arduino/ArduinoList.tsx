import React, { useState } from "react";
import { Link } from "react-router-dom";
import Header from "../../Components/Header";
import { useAxiosGet } from "../../Hooks/HttpRequest";

function ArduinoList() {
  const url = "http://localhost:8080/Arduino";
  let Arduinos = useAxiosGet(url);
  console.log(Arduinos.data);
  let arduino = <div></div>;
  if (Arduinos.data) {
    console.log(Arduinos.data);
    let URL = "/arduino/edit/";
    arduino = Arduinos.data.map((item) => (
      <li>
        {item.name}
        <nav>
          <Link to={URL + item.arduinoId}>Edit</Link>
        </nav>
      </li>
    ));
  }
  return (
    <div>
      <Header />
      <nav>
        <Link to="/arduino/create">Create new arduino</Link>
      </nav>
      <ul>{arduino}</ul>
    </div>
  );
}

export default ArduinoList;
