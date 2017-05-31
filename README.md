# SmartHive

[![Build status](https://ci.appveyor.com/api/projects/status/prvecc8bafmvdwnh?svg=true)](https://ci.appveyor.com/project/Branimir123/fmi-iot-teamwork)
[![Coverage Status](https://coveralls.io/repos/github/Branimir123/FMI-IoT-Teamwork/badge.svg?branch=master)](https://coveralls.io/github/Branimir123/FMI-IoT-Teamwork?branch=master)

![Logo](/logo.jpg)

#### SmartHive is a platform for beehive monitoring developed as a course project in Internet Of Things @ Faculty of Mathematics and Informatics, Sofia University "St. Kliment Ohridski"

-------------------------------------
### The board

#### As a main board we use the ESP8266 based Wemos D1 mini which has wifi and is easy to program in the Arduino IDE
![Wemos D1](https://hobbytronics.com.pk/wp-content/uploads/wemos-pinout.jpg)

--------------------------------------
### The sensors

#### Currently we only use one sensor - BME280, which measures temperature and humidity, but our plan is to connect more sensors in the future and add additional functionality
![BME 280](http://i.ebayimg.com/images/g/dK0AAOSwLVZVyWJl/s-l300.jpg)

--------------------------------------

### The application

#### Our web application uses the ASP.NET MVC5 framework. The whole app is divided into several projects each having its own concern. We have introduced the core principles of good and maintainable code (SOLID principles). To resolve dependencies we use the IoC container Ninject
![Screenshot](/Screenshots/webapp.jpg)

--------------------------------------

