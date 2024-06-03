Invoicing Application
***********************
*****************
Running the Application 

1. Clone the repository. 
2. Configure the database connection in `appsettings.json`. 
3. Run `dotnet ef database update` command (update-database) to create the database. Run the sample Data scripts for the tables in the database(datascripts.sql file), which is placed inside the solution file.
4. Start the application using `dotnet run`. This should provide a comprehensive guide to implementing the Invoicing System using ASP.NET Core Web API. 

******************
API Endpoints

Category
GET /api/Category/GetAllCategories 
GET /api/Category/{id}
POST /api/Category
PUT /api/Category/{id} 
DELETE /api/Category/{id}

Customer
GET /api/Customer/GetAllCustomers
GET /api/Customer/{id}
POST /api/Customer
PUT /api/Customer/{id} 
DELETE /api/Customer/{id}

Product
GET /api/Product/GetAllProducts 
GET /api/Product/{id} 
POST /api/Product
PUT /api/Product/{id}
DELETE /api/Product/{id}

InvoiceItem
PUT /api/InvoiceItem/{id} 
DELETE /api/InvoiceItem/{id}
POST /api/InvoiceItem/{customerId}/add

Invoice
GET /api/Invoice/{customerId}/generate

