# Contact Manager Site

Basic web application for managing contacts. App offers all operations on contacts such as creating new contact, editing and deleting existing ones. App also offers base **JWT** authentication and authorization.

## Used Technologies

### Backend:
Backend was implemented with help of .NET infrastructure. Main frameworks and libraries used:
* **ASP.NET Core**: Main framework for handling backend structure
* **Entity Framework Core**: Framework for handling database operations
* **JwtBearer**: Library responsible for creating and authorizing JWT tokens
* **FluentValidation**: Library that supports advanced data validation
* **DotNetEnv**: Library that allows to use .env variables inside backend architecture
* **BCrypt.Net-Next**: Key library for safe password encryption

### Database:
**SQLite** is the database that is used in this project

### Frontend:
Frontend was implemented with TypeScript. Main frameworks and libraries used:
* **React**: Main framework that supports building single page application UI
* **React-Router-Dom**: Library responsible for page navigation

## Builduing and Running application
### Prerequisities
* Installed version 9.0 of **.NET SDK**
* Installed **Node.js** environment with **npm** packages manager
* Added `.env` file in main folder with example values:

```
JWT__SECRET=secret_key
JWT__EXPIRATIONDATE=111
JWT__ISSUER=exampleIssuer
JWT__AUDIENCE=exampleAudience
```

### Running Backend:
* Open terminal and go to `Backend` folder (e.g. `cd Backend`)
* Run command `dotnet build` to build project
* Run command `dotnet ef database update` to run database migrations
* Run command `dotnet watch` to run the server
* Server should be now available at `http://localhost:5183`

### Running Frontend:
* Open second terminal and go to `Frontend` folder (e.g. `cd Frontend`)
* Run command `npm install` to install required packages
* Run command `npm run dev` to run the vite developer server
* Application should now be available at `http://localhost:5173`

## Main Classes and Methods

### Backend
* **Controllers**: contains all controllers that handle requests
    * **CategoryController**
        * `[HttpGet] GetAll()` returns all categories
    * **ContactController**: 
        * `[HttpPost] Create()` creates new contact
        * `[HttpGet] GetAll()` returns key informations about all contacts
        * `[HttpGet("{id}")] GetById()` returns all details about specific contact
        * `[HttpDelete("{id}")] DeleteById()` removes specific contact from database
        * `[HttpPut("{id}")] Update()` modifies already existing contact
    * **SubcategoryController**:
        * `[HttpGet] GetAll()` returns all subcategoires
    * **UserController**:
        * `[HttpPost] Register()` creates new user account
        * `[HttpPost] Login()` authenticates user, if authentication went successfully returns jwt token for authenticated user
* **Models**: contains classes that represent entities inside database tables
    * **Category** represents dicitonary entity which holds name of specific category
    * **Contact** entity that stores details about contact such as name, surname, email, phone number, etc.
    * **Subcategory** represents dicitonary entity which holds name of specific subcategory
    * **User** represents user entity that holds informations needed for authentication
* **Services**: contains classes that are responsible for business logic
    * **CategoryService** handles every operation where Category entity is directly involved
    * **ContactService** handles every operation where Contact entity is directly involved
    * **SubcategoryService** handles every operation where Subcategory entity is directly involved
    * **UserService** handles every operation where User entity is directly involved
    * **TokenProvider** handles generating JWT tokens for authenticated users
* **DTOs** contains classes that are used in data transfer between backend and frontend infrastructures
* **Validators** contains classes that are used to validate DTOs

### Frontend
* **commonElements**: stores `Navbar.tsx` which represents navigation bar used in multiple components
* **hooks**: folder which has custom hooks. Main custom hook is `useApi.tsx` which is responsible for fethcing requests to backend server
* **pages**: stores main pages components such as `MainPage.tsx` which shows contact list or `CreateContact.tsx` that allows creating new contacts for authenticated users

