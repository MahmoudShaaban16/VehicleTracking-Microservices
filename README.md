# Vehicle Tracking App - Built with .NET Core and Microservices Architecture

[![Build Status](https://api.travis-ci.com/MahmoudShaaban16/VehicleTracking-Microservices.svg?branch=master)](https://api.travis-ci.com/MahmoudShaaban16/VehicleTracking-Microservices)

<p align="center">
    <img alt="Vehicle Tracking" src="https://github.com/MahmoudShaaban16/VehicleTracking-Microservices/blob/master/Screenshots/VehicleTracking-Web.png" />
</p>

## Application Business Overview

We are going to develop an application that keeps tracking of customer information and their connected vehicles that belongs to them.
	- They have a need to be able to view the status of the connection among these vehicles on a monitoring display.
	- The vehicles send the status of the connection one time per minute.
	- The status can be compared with a ping (network trace); no request from the vehicle means no connection. 
	- So, vehicle is either Connected or Disconnected.

## Architecture overview

<p align="center">
    <img alt="Vehicle Tracking Architecture" src="https://github.com/MahmoudShaaban16/VehicleTracking-Microservices/blob/master/Screenshots/Application%20Architecture.png" />
</p>

* **VehilceTracking.Web** - an Angular Single Page Application that provides a monitoring page to list vehicles of customers and their vehicles status

* **Web API Gateway** - This is the API gateway that aces as a Facade to the three microservices (Customer, vehicle, Vehicle ping) for the web app

* **Customer Service** - A service that lists customers in the system, In memory data is used 

* **Vehicle Service** - A service that lists vehicles in the system for specific customers.

* **Vehicle Connections Service** - A service that keeps tracking of connections posted from the vehicles (IOT devices)

* **Vehicle Ping Service** -  A service that pings vehicles and check its status if connected or disconnected

* **Vehicle Ping Azure Function** - An Azure function that simulates vehicle connections and ping status

## Tools Used
* .NET Core 2.1
* Entity Framework Core
* Entity Framework Core (In Memory database)
* MediatR (Implementing CQRS)
* Ocelot  (API Gateway)
* RawRabbit  (Message Queue)
* Microsoft Azure Function
* Angular (SPA)



