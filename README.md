ToDo app template API

A template repository for a ToDo app API with .NET8 and PostgreSQL. REPR (FastEndpoints), CQRS (MediatR) and partially Clean Architecture patterns are used. The API is easily extensible and can be used as a starting point for a new project.

Functionality:

Create, read, update and delete ToDos

User registration, login, option to reset user's password. Accounts are stored in the database, authentication is done using JWT.

Email templates and sending emails via Smtp or SendGrid is supported. Email templates are written in Liquid templating language.
