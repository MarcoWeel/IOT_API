import React, { useState } from "react";
import logo from "./logo.svg";
import "../../App.css";
import axios from "axios";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import Header from "../../Components/Header";

function CreatePreset() {
  const [id, setId] = useState("");
  const [Name, setName] = useState("");
  const [Analogue, setAnalogue] = useState("");
  const [Digital, setDigital] = useState("");
  const [submitMessage, setSubmitMessage] = useState(<div></div>);

  let data = {
    name: Name,
    digitalPinCount: [
      {
        pinMode: 0,
        id: 0,
        pinNumber: null,
        arduinoModel: {
          name: "string",
          preset: {
            presetId: 0,
            name: "string",
            digitalPinCount: 0,
            analoguePinCount: 0,
          },
          presetId: 0,
        },
        arduinoId: 0,
      },
    ],
    analoguePinCount: [
      {
        pinMode: 0,
        id: 0,
        pinString: null,
        arduinoModel: {
          name: "string",
          preset: {
            presetId: 0,
            name: "string",
            digitalPinCount: 0,
            analoguePinCount: 0,
          },
          presetId: 0,
        },
        arduinoId: 0,
      },
    ],
  };

  const handleSubmit = (event: any) => {
    event.preventDefault();
    console.log(event);
    for (let index = 3; index < event.target.length - 1; index++) {
      const PinValue = event.target[index].value;
      if (event.target[index].id == "Digital") {
        if (data.digitalPinCount[0].pinNumber == null) {
          data.digitalPinCount[0].pinNumber = PinValue;
        } else {
          data.digitalPinCount.push({
            pinMode: 0,
            id: 0,
            pinNumber: PinValue,
            arduinoModel: {
              name: "string",
              preset: {
                presetId: 0,
                name: "string",
                digitalPinCount: 0,
                analoguePinCount: 0,
              },
              presetId: 0,
            },
            arduinoId: 0,
          });
        }
      }
      if (event.target[index].id == "Analogue") {
        if (data.analoguePinCount[0].pinString == null) {
          data.analoguePinCount[0].pinString = PinValue;
        } else {
          data.analoguePinCount.push({
            pinMode: 0,
            id: 0,
            pinString: PinValue,
            arduinoModel: {
              name: "string",
              preset: {
                presetId: 0,
                name: "string",
                digitalPinCount: 0,
                analoguePinCount: 0,
              },
              presetId: 0,
            },
            arduinoId: 0,
          });
        }
      }
    }
    console.log(data);
    axios({
      method: "post",
      url: "http://localhost:8080/Arduino/preset",
      data: data,
      headers: { "Content-Type": "application/json" },
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
    let id = "Analogue";
    Pins.push(
      <div>
        <div>Analogue Pin</div>
        <Form.Group controlId="formBasicPinString">
          <Form.Control
            type="name"
            placeholder="Enter Analogue Pin ID"
            className="textarea"
            required
            id={id}
          ></Form.Control>
        </Form.Group>
      </div>
    );
  }
  for (let index = 0; index < Number(Digital); index++) {
    let id = "Digital";
    Pins.push(
      <div>
        <div>Digital Pin</div>
        <Form.Group controlId="formBasicPinId">
          <Form.Control
            type="number"
            placeholder="Enter Digital Pin ID"
            className="textarea"
            required
            id={id}
          ></Form.Control>
        </Form.Group>
      </div>
    );
  }

  return (
    <div>
      <Header />
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

        <Form.Group controlId="formBasicAnaloguePinCount">
          <Form.Control
            type="number"
            placeholder="Enter Analogue pin count"
            onChange={(e: any) => setAnalogue(e.target.value)}
            className="textarea"
            required
            value={Analogue}
          ></Form.Control>
        </Form.Group>

        <Form.Group controlId="formBasicDigitalPinCount">
          <Form.Control
            type="number"
            placeholder="Enter Digital pin count"
            onChange={(e: any) => setDigital(e.target.value)}
            className="textarea"
            required
            value={Digital}
          ></Form.Control>
        </Form.Group>
        {Pins}
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

export default CreatePreset;
