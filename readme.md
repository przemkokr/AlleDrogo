# AlleDrogo
This is Auction Portal Project designed and implemented during sixth semester of WSB college.
Contributors:
1. Przemysław Król 11332
2. Bartłomiej Baca 11325
3. Marcin Milewski 11339

The main purpose of this project is to identify, define and implement source code with best practices and design patterns, to make code readable, robust, loosely coupled and easily managed.

To make above possible, we used several techniques and design patterns, both structural and architectural as well.
The project is written in hexagonal architecture, the following layers are indicated:

1. Domain namespace
  - The highest level of abstraction, this is where basic domain models with their logic are defined. This layer is free from dependencies due to Inversion of Control principle.

2. Application layer
  - This layer is responsible for handling user actions. It uses persistance layer for database access using repository interfaces. Actions are handled by throwing events on mediator bus and catching them in this layer and then performing logic related to specific event.

3. Persistance layer
  - Persistance layer includes primarily a way to access the database. Entry point of this library is ApplicationDbContext class, which defines tables, entities mapping and logic for creating models using Entity Framework Core migrations feature. This layer also defines great, simple to use and reusable repository interface, written in generic repository pattern. It means that this interface can be defined once, and then used with multiple objects, which are defined by generic constraint (this case is EntityBase class constraint)

4. Infrastructure layer
  - interlayer, used mostly for defining middleware used in applications, but also contains some interfaces used across all application

5. Internal.Contracts layer
  - This layer is used to hold data objects, which are transported from frontend to backend. It holds commands and queries, enum representations for frontend app, requests used by Mediator bus. This way of creating some sort of DTO objects allows us to reuse all libraries in different solutions - e.g. this layer and all above could be used in desktop or mobile app, because they don't know anything about presentation layer which used it. 

6. Web layer
  - Web application layer contains separate web app written in Angular 8 and SPA technique (single page application). It also contains API with multiple endpoints defined, which main purpose is to route user requests to specific actions in application layer, and controllers are mapping requests to provide data in specific view where user actually is. This layer is written both in MVC and MVVM pattern - MVC for mapping requests to views by API controller, and MVVM for Angular application, based of views and components.

API specification

Application provides several endpoints which are used to map user request to application code via Mediator & Command pattern

/api/auction/get-all/ [HTTPGET]
Gets all auctions available form database

/api/auction/get-by-id/?id [HTTPGET]
Get concrete auction by its Id property

/api/auction/create/ [HTTPPOST]
Maps request body to command, which is used by Mediator to create and save new auction to database

/api/auction/get-by-user/?queryType?userName [HTTPGET]
Gets specific user auctions - based od URI parameters, which are created by Factory on backend and Strategy & State on frontend design patterns

/api/bid/bid [HTTPPOST]
Maps user request to bid command, which is then used to add new bid to auction

/api/bid/buyNow [HTTPPOST]
Maps user request to buy now command, which is then used to instantly buy item, which has BuyNow flag set to true

Design Patterns Used
1. Factory 
  - Query Factory in Internal.Contracts
2. Builder 
  - ModelBuilder (via EF Core) - responsible for creating POCO models from DbContext
3. Singleton 
  - Infrastructure/IUserService - singleton implementation is provided by AspNetCore.DependencyInjection - registered service with singleton lifetime scope
4. Facade 
  - In Web/ClientApp/Autenthication module - AuthenticationService is used to aggregate functions related to authentication and autorization functions in Angluar App
5. Command 
  - In Web/ClientApp on client side and Application library on server side - commands are used to transport data via Mediator bus to their handlers, which then performs logic operations on them
6. Mediator 
  - Command and Query Bus are structured into mediator pattern. All operations are only sent to bus, and then mediator choose which handler should be used for specific operation
7. Observer 
  - on client side, observer pattern is used to two-way data binding in typescript viewmodel and html document. It allows to constantly monitor objects state, reacts for their changes and informs viewmodel about those changes. Provided by Angular binding engine
8. Strategy 
  - on client side, strategy is used to choose which type of user auctions should be loaded from database - buttongroup with several button are responsible for choosing correct state, and this state is then factored by QueryFactory into specific request, and then handled in Application library QueryHandler

Architectural Patterns & SOLID Implementations
1. MVC 
  - standart AspNetCore engine used to map routes to specific views and data
2. MVVM 
  - on client side - helps to manage data on viewmodels working under the view

3. CQRS 
  - Command Query Responsibility Separation - this is one of the best ways to implement Single Responsibility Pattern. Every user request is wrapped into command or query, and every command and query has their own handler.
4. 
  - Dependency Injection - used standard AspNetCore dependency injection library. With this, loosely coupled architecture is provided. It helps to care about Inversion of Control and manage dependencies all across the project.


