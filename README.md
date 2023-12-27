# Mess About
Experiments around Clean Architecture & Testing

## SQL Server
Docker SQL images defaults to using `master` database. I don't want to waste time running SQL scripts when spinning up a new container in order to create a named DB so Migrations are just run against `master` for now.