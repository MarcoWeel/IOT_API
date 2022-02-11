import { useAxiosGet } from "../../Hooks/HttpRequest";
// import React, { useState, useEffect } from "react";
// import Header from "../../Components/Header";
// import Button from "react-bootstrap/Button";
// import Form from "react-bootstrap/Form";
// import { useParams } from "react-router";

// function ArduinoState(state, ownProps) {
//   let id = useParams();
//   const [isLoading, setisLoading] = useState(true);
//   const MINUTE_MS = 60000;

//   useEffect(() => {
//     const interval = setInterval(() => {
//       console.log("Logs every minute");
//     }, MINUTE_MS);

//     return () => clearInterval(interval); // This represents the unmount function, in which you need to clear your interval to prevent memory leaks.
//   }, []);

//   const url = "http://localhost:8080/pins/states" + id.ArduinoId;
//   let Arduinos = useAxiosGet(url);
//   console.log(Arduinos.data);
//   let arduino = <div></div>;
//   if (Arduinos.data) {
//     console.log(Arduinos.data);
//     if (isLoading == true) {
//       setisLoading(false);
//     }
//     arduino = Arduinos.data.map((item) => (
//       <div>
//         <div>
//           <div>AnaloguePin {item.pinNameString}</div>
//           <Form.Group controlId={item.id}>
//             <Form.Control
//               type="number"
//               placeholder="Enter Mode"
//               className="textarea"
//               required
//               defaultValue={item.pinMode}
//               id={item.id}
//             ></Form.Control>
//           </Form.Group>
//         </div>
//       </div>
//     ));
//   }
//   return (
//     <div>
//       <Header />
//       <Form>
//         {arduino}
//         <div className="form-group">
//           <Button type="submit" className="btn btnpos">
//             Save preset
//           </Button>
//           {/* {submitMessage} */}
//         </div>
//       </Form>
//     </div>
//   );
// }
