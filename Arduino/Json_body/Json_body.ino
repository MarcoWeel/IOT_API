#include <LinkedList.h>
#include <ArduinoJson.h>
#include <ESP8266WiFi.h>
#include <ESP8266WebServer.h>
#include <ESP8266HTTPClient.h>


ESP8266WebServer server(80);

//Setup values
const char* ssid = "Guests";
const char* password =  "grade!eight";
const int Id = 9;
const String Ip = "172.16.222.155";
String UsedCommands = "[1]";
//End Setup values

String serverGetName = "http://" + Ip + ":8080/pins/";
String serverPostPath = "http://" + Ip + ":8080/State/";
bool HasSetup = false;


WiFiClient client;

void setup() {
  Serial.begin(115200);
  WiFi.begin(ssid, password);  //Connect to the WiFi network

  while (WiFi.status() != WL_CONNECTED) {  //Wait for connection
    delay(500);
    Serial.println("Waiting to connect...");
  }
  Serial.print("IP address: ");
  Serial.println(WiFi.localIP());  //Print the local IP
  while (!HasSetup)
  {
    SetupStateManager();
  }
  //ADD SERVER LISTEN COMMANDS HERE
  server.on("/body", handleBody); //handles the states sent by the server
  server.on("/time", handleTime); //handles time sent by the server.

  ////////////////////////////////////////////////

  server.begin(); //Start the server
  Serial.println("Server listening");
  SignUpArduino();
}

void loop() {

  server.handleClient(); //Handling of incoming requests
  CheckStates();
}

void handleBody() { //Handler for the body path

  if (server.hasArg("plain") == false) { //Check if body received

    server.send(200, "text/plain", "Body not received");
    return;

  }
  server.send(200, "text/plain" , "received" );
  DynamicJsonDocument doc(1024);
  deserializeJson(doc, server.arg("plain"));
  int Pin = doc["pin"];
  int Type = doc["type"];
  int State = doc["state"];
  Serial.println(Pin);
  Serial.println(Type);
  Serial.println(State);
  if (Type == 0) {
    analogWrite(Pin, State);
  }
  else {
    digitalWrite(Pin, State);
    Serial.println("WRITELOCATION");
  }
}

void handleTime() {
  //Use this method as a template for other uses.
  if (server.hasArg("plain") == false) { //Check if body received

    server.send(200, "text/plain", "Body not received");
    return;

  }
  server.send(200, "text/plain" , " received " );
  DynamicJsonDocument doc(1024);
  deserializeJson(doc, server.arg("plain"));
  String Time = doc["time"];
  Serial.println(Time);
}
