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

* **Web API Gateway** - This is the API gateway that acts as a Facade to the three microservices (Customer, vehicle, Vehicle ping) for the web app

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
* Azure Cosmos DB (for connections and ping requests)
* Microsoft SQL Server (for customers and vehicles data)
* Angular (SPA)

### Prerequisites
* .NET Core SDK 2.1, download from https://dotnet.microsoft.com/download/dotnet-core/2.1
* Download and install RabbitMQ locally or use RabbitMQ as a service (free tier available) https://www.cloudamqp.com/plans.html or you can pull the docker image available on the hub at https://hub.docker.com/_/rabbitmq

after installation is complete, modify the rabbitMQ section at vehicleConnection and vehiclePing API project app settings

<img src="https://github.com/MahmoudShaaban16/VehicleTracking-Microservices/blob/master/Screenshots/rabbitMQ_settings.png"/>

* Create a CosmosDB account; Please follow this link for more guide https://docs.microsoft.com/en-us/azure/cosmos-db/how-to-manage-database-account; create one database for Vehicle Connections , Vehicle Ping requests APIs; 

Modify the CosmosDB settings in app.settings.json with the keys from the portal
<img src="https://msdnshared.blob.core.windows.net/media/2017/09/20170912-CosmosDB-Keys.png"/>

<img src="https://github.com/MahmoudShaaban16/VehicleTracking-Microservices/blob/master/Screenshots/cosmosDb_settings.png"/>

* Modify the ocelot.json file of the api gateway project and use the right hosts and ports for the customer , vehicle, ping APIs

<img src="https://github.com/MahmoudShaaban16/VehicleTracking-Microservices/blob/master/Screenshots/ocelot-json.png"/>

* Last, change the return of getBaseURL of main.ts of Angular in VehicleTracking.Web project inside ClientApp/Src to point to the API gatway URL

### Installation Options
1. Run the APIs and api gateway and the web apps using dotnet run
2. Host your api and web apps on IIS. create a publish profile and publish to your IIS.
3. Run the applications using docker (all projects contain docker image file)
4. Deploy your APIs and the web app to the cloud (Azure App service, AWS BeansTalk).
5. Deploy the Vehicle Ping Azure function to Azure or run it locally.
