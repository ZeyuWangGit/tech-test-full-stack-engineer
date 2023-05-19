Your Solution Documentation
===========================

## Backend:

I utilized .NET Core for the backend, chosen for its cross-platform capabilities, performance, and robust tooling. Clean architecture was implemented to focus on separating concerns, centralizing business logic and domain entities for better manageability. CQRS (Command Query Responsibility Segregation) pattern and mediator pattern were also used, with the assistance of the MediatR library, to streamline application design and reduce system coupling.

The system exposes three APIs for data access and operations: job acceptance and decline. The APIs include:

```
GET /jobs?status=0: Fetches new jobs
GET /jobs?status=1: Fetches accepted jobs
PUT /jobs/:id: Updates a job
```
MySQL was used for data querying. Data retrieval across jobs, categories, and suburbs required complex query joins

## Frontend:

For the frontend, React was chosen as the primary framework. React's robust ecosystem and modular nature facilitate the creation of maintainable and performant user interfaces. As the application scales, the benefits of its component-based structure and the flexibility provided by its hooks API become increasingly apparent.

React Hooks provide a way to use stateful logic and lifecycle methods in functional components, enhancing reusability and separation of concerns. By leveraging hooks, the application can maintain state and manage side effects without the need for class-based components, leading to a more readable and maintainable codebase.

React Query, is employed for data fetching. As the application is mainly server-state dependent, React Query is an ideal fit, offering advanced features like caching, automatic refetching, and background updates, all out-of-the-box. This results in a more resilient, fast, and reactive application, greatly enhancing user experience.

Finally, Axios is used as the HTTP client to interface with the backend API. With its promise-based architecture and interceptors, handling API requests and responses is simplified, making error handling and request configuration more intuitive and robust

## Styling: Antd

For styling, I selected Ant Design. This comprehensive design system provides a suite of high-quality React components that are out-of-the-box usable and customizable. With its vast selection of components and intuitive API, Ant Design promotes consistency, efficiency, and an overall improved user experience across the application. The system's ability to cater to a variety of design requirements makes it an excellent choice for diverse projects. Furthermore, it encourages best practices in design and implementation, resulting in a more aesthetically pleasing and functional user interface.

## Future Improvements

While the current solution provides robust functionality, there are potential enhancements for future iterations:

1. Test Coverage: Comprehensive testing for both backend and frontend can be introduced to ensure system reliability and catch potential errors early.

2. Authentication: Implementing authentication would secure the system and allow for user-specific functionalities, improving the overall user experience.

3. PUT API Implementation: Fully implementing the PUT API would facilitate comprehensive data modifications, thereby increasing the versatility of the system.

## Running the Application
Ensure Docker is installed and running on your machine. Follow these steps to run the application:

Navigate to the root folder of the project.
```
 docker-compose up -d
 ```
Execute docker-compose up -d command. This will set up and run three containers: the backend service, the UI application, and the MySQL database.
Access the UI at http://localhost:3000.