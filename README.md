# Truck API

Api for truck management.

## Installation

Data are stored in SQL database.

Fluent migrator runs migrations for database, table and stored procedures creation.

Ensure that in the appsettings.json configuration files two connection strings are defined. 
One to the system master database ("MasterDb") which is use for checking if the TruckDb database exists. The second connection string ("truckDb") is for the TruckDb database.
