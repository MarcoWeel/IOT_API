import React, { useState } from "react";
import logo from "./logo.svg";
import "../../App.css";
import DropDown from "./Component/DropDown";
import Header from "../../Components/Header";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import axios from "axios";
import { useAxiosGet } from "../../Hooks/HttpRequest";
import { useParams } from "react-router";

function EditArduino(state, ownProps) {
  let id = useParams();
  console.log(id.ArduinoId);
  const [submitMessage, setSubmitMessage] = useState(<div></div>);
  const [value, setValue] = useState("");
  const [name, setName] = useState("");
  const [isLoading, setisLoading] = useState(true);
  console.log(value);

  const handleSubmit = (event: any) => {
    event.preventDefault();
    console.log(event);
    for (let index = 0; index < event.target.length; index++) {
      for (let index2 = 0; index2 < Arduinos.data.length; index2++) {
        console.log(event.target[index].id);
        console.log(Arduinos.data[index2].id);
        if (event.target[index].id == Arduinos.data[index2].id) {
          const pinMode = event.target[index].value;
          console.log(event.target[index].value);
          Arduinos.data[index2].pinMode = parseInt(pinMode);
          console.log(Arduinos.data[index2].pinMode);
          break;
        }
      }
    }

    console.log(Arduinos);
    axios({
      method: "put",
      url: "http://localhost:8080/pins/",
      data: Arduinos.data,
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

  const url = "http://localhost:8080/pins/" + id.ArduinoId;
  let Arduinos = useAxiosGet(url);
  console.log(Arduinos.data);
  let arduino = <div></div>;
  if (Arduinos.data) {
    console.log(Arduinos.data);
    if (isLoading == true) {
      setisLoading(false);
      setName(Arduinos.data[0].arduinoModel.name);
    }
    arduino = Arduinos.data.map((item) => (
      <div>
        {item.pinType == 0 && (
          <div>
            <div>AnaloguePin {item.pinNameString}</div>
            <Form.Group controlId={item.id}>
              <Form.Control
                type="number"
                placeholder="Enter Mode"
                className="textarea"
                required
                defaultValue={item.pinMode}
                id={item.id}
              ></Form.Control>
            </Form.Group>
          </div>
        )}
        {item.pinType == 1 && (
          <div>
            <div>DigitalPin {item.pinNameString}</div>
            <Form.Group controlId={item.id}>
              <Form.Control
                type="number"
                placeholder="Enter Mode"
                className="textarea"
                required
                defaultValue={item.pinMode}
                id={item.id}
              ></Form.Control>
            </Form.Group>
          </div>
        )}
      </div>
    ));
  }

  return (
    <div>
      <Header />
      <Form onSubmit={(e: any) => handleSubmit(e)}>
        <div>{name}</div>
        {arduino}
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

export default EditArduino;
