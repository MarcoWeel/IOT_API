import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import App from "./App";
import reportWebVitals from "./reportWebVitals";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import CreatePreset from "./Views/Preset/CreatePreset";
import Home from "./Views/Home/Home";
import AddArduino from "./Views/Arduino/AddArduino";

ReactDOM.render(
  <BrowserRouter>
    <Routes>
      <Route path="/" element={<Home />} />
      <Route path="/arduino" element={<AddArduino />} />
      <Route path="/arduino/preset" element={<CreatePreset />} />
      {/* <Route path=":teamId" element={<Team />} /> */}
    </Routes>
  </BrowserRouter>,
  document.getElementById("root")
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
