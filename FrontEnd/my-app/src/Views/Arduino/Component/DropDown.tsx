import React, { Component, useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import DropdownButton from "react-bootstrap/DropdownButton";
import Dropdown from "react-bootstrap/Dropdown";
import { useAxiosGet } from "../../../Hooks/HttpRequest";

function DropDown({ setValue }) {
  const url = "http://localhost:8080/Arduino/presets";
  let Presets = useAxiosGet(url);

  const [dropDownValue, setdropDownValue] = useState("Loading");
  const [isLoading, setisLoading] = useState(true);

  let preset = "loading";
  if (Presets.data) {
    if (isLoading == true) {
      setdropDownValue(Presets.data[0].name);
      setisLoading(false);
      console.log(Presets.data);
    }
    console.log(Presets.data);
    preset = Presets.data.map((item) => (
      <Dropdown.Item
        as="button"
        value={item.presetId}
        onClick={() => {
          setdropDownValue(item.name);
          setValue(item.presetId);
        }}
      >
        <div>{item.name}</div>
      </Dropdown.Item>
    ));
  }

  return (
    <div className="topRowDropdown">
      <DropdownButton id="dropdown-item-button" title={dropDownValue}>
        {preset}
      </DropdownButton>
    </div>
  );
}

export default DropDown;
