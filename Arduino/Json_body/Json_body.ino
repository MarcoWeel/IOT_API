#include <LinkedList.h>
#include <ArduinoJson.h>
#include <ESP8266WiFi.h>
#include <ESP8266WebServer.h>
#include <ESP8266HTTPClient.h>


ESP8266WebServer server(80);

//Setup values
const char* ssid = "ThuisgroepOW";
const char* password =  "sukkel67919772!";
const int Id = 7;
String serverGetName = "http://192.168.2.27:8080/pins/";
String serverPostPath = "http://192.168.2.27:8080/State/";
String serverSignUpPath = "http://192.168.2.27:8080/State/";
String UsedCommands = "[0, 1]";
//End Setup values

int TESTER = D5;

bool HasSetup = false;
LinkedList<int> activePins = LinkedList<int>();
LinkedList<int> pinTypes = LinkedList<int>();
LinkedList<int> pinModes = LinkedList<int>();
LinkedList<double> States = LinkedList<double>();

WiFiClient client;

void setup() {
  Serial.begin(115200);
  WiFi.begin(ssid, password);  //Connect to the WiFi network

  while (WiFi.status() != WL_CONNECTED) {  //Wait for connection

    delay(500);
    Serial.println("Waiting to connect...");
    Serial.println(TESTER);

  }
  Serial.print("IP address: ");
  Serial.println(WiFi.localIP());  //Print the local IP
  String payload;
  while (!HasSetup)
  {

    HTTPClient http;


    String serverGetPath = serverGetName + Id;
    Serial.print(serverGetPath);
    http.begin(client, serverGetPath);

    int httpResponseCode = http.GET();

    if (httpResponseCode > 0) {
      Serial.print("HTTP Response code: ");
      Serial.println(httpResponseCode);
      payload = http.getString();
      DynamicJsonDocument doc(2048);
      deserializeJson(doc, payload);
      //      Serial.print("Size: ");
      JsonArray array = doc.as<JsonArray>();
      //      Serial.println(array.size());
      delay(10);
      for (int i = 0; i < array.size(); i++) {
        if (array[i]["pinMode"].as<int>() == 0) {
          pinMode(array[i]["pinNameString"].as<int>(), INPUT) ;
        }
        else {
          pinMode(array[i]["pinNameString"].as<int>(), OUTPUT) ;
        }

        //        Serial.println(i);
        //        Serial.println(array[i]["pinNameString"].as<int>());
        //        Serial.println(array[i]["pinMode"].as<int>());
        activePins.add(array[i]["pinNameString"].as<int>());
        pinModes.add(array[i]["pinMode"].as<int>());
        pinTypes.add(array[i]["pinType"].as<int>());
        States.add(0);
      }
      HasSetup = true;
    }
    else {
      Serial.print("Error code: ");
      Serial.println(httpResponseCode);
    }

  }
  HTTPClient http;
  DynamicJsonDocument doc(1024);
  for(i = 0; i < UsedCommands.length; i++){
    doc[""][i] = UsedCommands[i];
  }
  String Path = serverSignUpPath + Id + "/" + WiFi.localIP().toString();
  http.begin(client, Path);
  Serial.println(Path);
  http.POST(UsedCommands);
  http.end();
  Serial.print("IP address: ");
  Serial.println(WiFi.localIP());  //Print the local IP
  server.on("/body", handleBody); //Associate the handler function to the path
  server.on("/time", handleTime);
  server.begin(); //Start the server
  Serial.println("Server listening");
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
  String message = "Body received:\n";
  message += server.arg("plain");
  message += "\n";

  //server.send(200, "text/plain", message);
  server.send(200, "text/plain" , " received " );
  DynamicJsonDocument doc(1024);
  deserializeJson(doc, server.arg("plain"));
  int Pin = doc["pin"];
  int Type = doc["type"];
  int State = doc["state"];
  if (Type == 0) {
    analogWrite(Pin, State);
  }
  else {
    digitalWrite(Pin, State);
  }
  Serial.println(Pin);
  Serial.println(State);
  Serial.println(Type);
}

void handleTime(){
   if (server.hasArg("plain") == false) { //Check if body received

    server.send(200, "text/plain", "Body not received");
    return;

  }
  String message = "Body received:\n";
  message += server.arg("plain");
  message += "\n";

  //server.send(200, "text/plain", message);
  server.send(200, "text/plain" , " received " );
  DynamicJsonDocument doc(1024);
  deserializeJson(doc, server.arg("plain"));
  String Time = doc["time"];
  Serial.println(Time);
}

void CheckStates() {
  HTTPClient PostClient;

  for (int i = 0; i < activePins.size(); i++) {
    if (pinTypes.get(i) == 1) {
      if (pinModes.get(i) == 0) {
        double pinVal = digitalRead(activePins.get(i));
        if (pinVal != States.get(i)) {
          String URL = serverPostPath + activePins.get(i) + "/" + pinVal;
          Serial.println(URL);
          States.set(i, pinVal);
          PostClient.begin(client, URL);
          PostClient.POST({});
          Serial.print("Pin: ");
          Serial.print(activePins.get(i));
          Serial.print(" State: ");
          Serial.println(States.get(i));
        }
      }
    }
    else if (pinTypes.get(i) == 1) {
      if (pinModes.get(i) == 0) {
        double pinVal = analogRead(activePins.get(i));
        if (pinVal != States.get(i)) {
          String URL = serverPostPath + activePins.get(i) + "/" + pinVal;
          Serial.println(URL);
          States.set(i, pinVal);
          PostClient.begin(client, URL);
          PostClient.POST({});
          Serial.print("Pin: ");
          Serial.print(activePins.get(i));
          Serial.print(" State: ");
          Serial.println(States.get(i));
        }
      }
    }
  }
  PostClient.end();
}
