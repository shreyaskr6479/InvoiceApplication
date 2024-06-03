Invoicing Application
***********************

API Endpoints

Product
GET /api/Product 
GET /api/Product/{id} 
POST /api/Product
PUT /api/Product/{id}
DELETE /api/Product/{id}

Category
GET /api/Category 
GET /api/Category/{id}
POST /api/Category
PUT /api/Category/{id} 
DELETE /api/Category/{id}

Customer
GET /api/Customer
GET /api/Customer/{id}
POST /api/Customer
PUT /api/Customer/{id} 
DELETE /api/Customer/{id}

Invoice
GET /api/Invoice
GET /api/Invoice/{id} 
POST /api/Invoice 
PUT /api/Invoice/{id}
DELETE /api/Invoice/{id}

*****************
Running the Application 

1. Clone the repository. 
2. Configure the database connection in `appsettings.json`. 
3. Run `dotnet ef database update` to create the database. 
4. Start the application using `dotnet run`. This should provide a comprehensive guide to implementing the Invoicing System using ASP.NET Core Web API. 