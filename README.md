# Description

Application for managing plans and activities built as a part of an online course.
- **Backend**: 
  - `.NET 7.0`
  - `EntityFramework`
  - `MediatR`
  - `AutoMapper`
  - `MVC architecture`

- **Frontend**: 
  - `Typescript` - for static typing and safety
  - `React` - for building user interfaces
  - `Axios` - for making HTTP requests and handling responses
  - `MobX` - for state management
  - `Semantic UI` - for styling
  - `React router` - for routing to different pages
  - `Toastify` - for notifications and alerts
  - `Formik` - for form handling

Webpage is at:
`http://localhost:3000/`

Swagger is at:
`http://localhost:5000/swagger`

# How to run

To run the `backend` service:
```sh
cd API
dotnet run
```

To run the `frontend` service:
```sh
cd client-app
npm install
npm run build
npm start
```

If you find that database with activities became a complete mess, you can drop it and it will be seeded again on a startup of `API` service:
```sh
# You should be in the root directory of the project
# <some path>/Reactivities
dotnet ef database drop -s API -p Persistence
```