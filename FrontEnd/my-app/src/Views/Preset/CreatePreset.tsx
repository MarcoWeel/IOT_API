import React, { useState } from "react";
import logo from "./logo.svg";
import "../../App.css";
import axios from "axios";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";

function CreatePreset() {
  const [id, setId] = useState("");
  const [name, setName] = useState("");
  const [Analogue, setAnalogue] = useState("");
  const [Digital, setDigital] = useState("");
  const [submitMessage, setSubmitMessage] = useState(<div></div>);

  const handleSubmit = (event: any) => {
    event.preventDefault();
    var bodyFormData = new FormData();
    bodyFormData.append("Floor.Id", id);
    bodyFormData.append("Floor.Name", name);
    bodyFormData.append("Floor.Length", Analogue);
    bodyFormData.append("Floor.Width", Digital);
    axios({
      method: "post",
      url: "http://localhost:5006/Floor/",
      data: bodyFormData,
      headers: { "Content-Type": "multipart/form-data" },
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
  let Pins = [];
  for (let index = 0; index < Number(Analogue); index++) {
    Pins.push(<div>A</div>);
  }
  for (let index = 0; index < Number(Digital); index++) {
    Pins.push(<div>B</div>);
  }

  return (
    <div>
      <Form onSubmit={(e: any) => handleSubmit(e)}>
        <Form.Group controlId="formBasicName">
          <Form.Control
            type="name"
            placeholder="Enter name"
            onChange={(e: any) => setName(e.target.value)}
            className="textarea"
            required
            value={name}
          ></Form.Control>
        </Form.Group>

        <Form.Group controlId="formBasicLength">
          <Form.Control
            type="number"
            placeholder="Enter length"
            onChange={(e: any) => setAnalogue(e.target.value)}
            className="textarea"
            required
            value={Analogue}
          ></Form.Control>
        </Form.Group>

        <Form.Group controlId="formBasicWidth">
          <Form.Control
            type="number"
            placeholder="Enter width"
            onChange={(e: any) => setDigital(e.target.value)}
            className="textarea"
            required
            value={Digital}
          ></Form.Control>
        </Form.Group>
        {Pins}
        <div className="form-group">
          <Button type="submit" className="btn btnpos">
            Save
          </Button>
          {submitMessage}
        </div>
      </Form>
    </div>
  );
}

export default CreatePreset;
