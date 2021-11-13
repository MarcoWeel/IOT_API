#include <ArduinoJson.h>
#include <ESP8266WiFi.h>
#include <ESP8266WebServer.h>
#include <ESP8266HTTPClient.h>

ESP8266WebServer server(80);

const char* ssid = "Guests";
const char* password =  "grade!eight";

bool HasSetup = false;
String serverName = "https://172.16.222.128:44300/pins/";
int Id = 1;

void setup() {
  Serial.begin(115200);
  WiFi.begin(ssid, password);  //Connect to the WiFi network

  while (WiFi.status() != WL_CONNECTED) {  //Wait for connection

    delay(500);
    Serial.println("Waiting to connect...");

  }
    Serial.print("IP address: ");
  Serial.println(WiFi.localIP());  //Print the local IP
  while(!HasSetup)
  {
    WiFiClient client;
  HTTPClient http;

  String serverPath = serverName + Id;
  Serial.print(serverPath);
  http.begin(client, serverPath);

  int httpResponseCode = http.GET();

  if (httpResponseCode>0) {
  Serial.print("HTTP Response code: ");
  Serial.println(httpResponseCode);
  String payload = http.getString();
  Serial.println(payload);
  HasSetup = true;
}
else {
  Serial.print("Error code: ");
  Serial.println(httpResponseCode);
}

  }
  pinMode(LED_BUILTIN, OUTPUT);
  Serial.print("IP address: ");
  Serial.println(WiFi.localIP());  //Print the local IP

  server.on("/body", handleBody); //Associate the handler function to the path

  server.begin(); //Start the server
  Serial.println("Server listening");

}

void loop() {

  server.handleClient(); //Handling of incoming requests

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
  server.send(200, "text/plain" , " hallo " );
  DynamicJsonDocument doc(1024);
  deserializeJson(doc, server.arg("plain"));
  int Pin = doc["pin"];
  int State = doc["state"];
  digitalWrite(Pin, State);
  Serial.println(Pin);
  Serial.println(State);
  Serial.println(message);
}
