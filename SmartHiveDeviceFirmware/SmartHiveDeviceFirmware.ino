#include <Arduino.h>
#include <ESP8266WiFi.h>
#include <ESP8266WiFiMulti.h>
#include <ESP8266HTTPClient.h>
#include <Wire.h>
#include <SPI.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_BME280.h>

ESP8266WiFiMulti WiFiMulti;
Adafruit_BME280 bme;
bool status;
String temp;
String humidity;

// SHA1 fingerprint of the certificate
const char* FINGERPRINT = "78 60 18 44 81 35 BF DF 77 84 D4 0A 22 0D 9B 4E 6C DC 57 2C";

/* 
 *  CONFIGURATION
 */
const int SEND_DATA_INTERVAL = 1000;         // time interval in milliseconds
const String DEVICE_KEY = "IPLVKT0HDOBNMP54"; // the device key
const char* WI_FI_SSID = "TUPKACHITE";       // the Wi-FI network's name
const char* WI_FI_PASSWORD = "badjamal";              // the Wi-FI network's password
/* 
 *  CONFIGURATION
 */

void setup()
{
    Serial.begin(115200);
    Wire.begin(D6, D7);
    status = bme.begin(0x76);
    WiFiMulti.addAP(WI_FI_SSID, WI_FI_PASSWORD);
}

void loop() 
{
    if (status)
    {
        temp = (String)bme.readTemperature();
        humidity = (String)bme.readHumidity();
    }
    
    delay(50);
    
    // wait for WiFi connection
    if((WiFiMulti.run() == WL_CONNECTED)) 
    {
        HTTPClient http;
        http.begin(("https://api.thingspeak.com/update?key="+DEVICE_KEY+"&field2="+humidity), FINGERPRINT); // sends current humidty
        http.GET();
        http.end();
        delay(16000);
        http.begin(("https://api.thingspeak.com/update?key="+DEVICE_KEY+"&field1="+temp), FINGERPRINT); // sends current temperature
        http.GET();
        http.end();
    }
    
    delay(SEND_DATA_INTERVAL);
}
