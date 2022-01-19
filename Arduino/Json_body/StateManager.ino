LinkedList<int> activePins = LinkedList<int>();
LinkedList<int> pinTypes = LinkedList<int>();
LinkedList<int> pinModes = LinkedList<int>();
LinkedList<double> States = LinkedList<double>();


String payload;


void SetupStateManager() {
  HTTPClient http;


  String serverGetPath = serverGetName + Id;
  Serial.println(serverGetPath);
  http.begin(client, serverGetPath);

  int httpResponseCode = http.GET();

  if (httpResponseCode > 0) {
    Serial.print("HTTP Response code: ");
    Serial.println(httpResponseCode);
    payload = http.getString();
    Serial.println(payload);
    DynamicJsonDocument doc(4096);
    deserializeJson(doc, payload);
    JsonArray array = doc.as<JsonArray>();
    delay(10);
    for (int i = 0; i < array.size(); i++) {
      if (array[i]["pinMode"].as<int>() == 0) {
        pinMode(array[i]["pinNameString"].as<int>(), INPUT) ;
      }
      else {
        pinMode(array[i]["pinNameString"].as<int>(), OUTPUT) ;
      }
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

void SignUpArduino(){
  HTTPClient http;
  String Path = serverPostPath + Id + "/" + WiFi.localIP().toString();
  http.begin(client, Path);
  Serial.println(Path);
  Serial.println(UsedCommands);
  http.addHeader("Content-Type", "application/json");
  http.POST(UsedCommands);
  http.end();
}

void CheckStates() {
  HTTPClient PostClient;

  for (int i = 0; i < activePins.size(); i++) {
    if (pinTypes.get(i) == 1) {
      if (pinModes.get(i) == 0) {
        double pinVal = digitalRead(activePins.get(i));
        if (pinVal != States.get(i)) {
          String URL = serverPostPath + activePins.get(i) + "/" + pinVal + "/" + Id;
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
    else if (pinTypes.get(i) == 0) {
      if (pinModes.get(i) == 0) {
        double pinVal = analogRead(activePins.get(i));
        if (pinVal != States.get(i)) {
          String URL = serverPostPath + activePins.get(i) + "/" + pinVal+ "/" + Id;
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
