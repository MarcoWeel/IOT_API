import React, { useState } from "react";
import logo from "./logo.svg";
import "../../App.css";
import DropDown from "./Component/DropDown";
import Header from "../../Components/Header";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import axios from "axios";

function AddArduino() {
  const [Name, setName] = useState("");
  const [submitMessage, setSubmitMessage] = useState(<div></div>);
  const [isVisible, setIsVisible] = useState(false);
  const [value, setValue] = useState("");
  console.log(value);
  const handleSubmit = (event: any) => {
    event.preventDefault();
    console.log(event);
    axios({
      method: "post",
      url: "http://localhost:8080/Arduino/" + Name + "/" + value,
    })
      .then((res) => {
        console.log(res);
        console.log(res.data);
        setSubmitMessage(<div className="succes">Succes</div>);
      })
      .catch((error) => {
        console.log(error.response);
        console.log(error);
        setSubmitMessage(
          <div className="unsuccesfull">Unsuccesfull try again later</div>
        );
      });
  };

  return (
    <div>
      <Header />
      <DropDown setValue={setValue} />
      <Form onSubmit={(e: any) => handleSubmit(e)}>
        <Form.Group controlId="formBasicName">
          <Form.Control
            type="name"
            placeholder="Enter name"
            onChange={(e: any) => setName(e.target.value)}
            className="textarea"
            required
            value={Name}
          ></Form.Control>
        </Form.Group>

        <div className="form-group">
          <Button type="submit" className="btn btnpos">
            Save preset
          </Button>
          {submitMessage}
        </div>
      </Form>
    </div>
  );
}

export default AddArduino;
