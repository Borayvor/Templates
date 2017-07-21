# Asp.Net Core Server

More info for [The .NET Core command-line interface](https://docs.microsoft.com/en-us/dotnet/core/tools/)

## Restore dependencies

If you’re `VS 2017`, it will auto-restore the dependencies once the file is saved, otherwise run `dotnet restore`.

## Development server

Run `dotnet watch run` for a dev server. Navigate to `http://localhost:5000`. The `server` will automatically reload if you change any of the source files. But `client` needs manual refresh.

## Build

Run `dotnet build` to the project and its dependencies into a set of binaries. The build artifacts will be stored in the `wwwroot/` directory for `client` and in the `bin/Debug/` for `Server`.


## ===================================================================


# Angular 2 client

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 1.2.0.

## Restore dependencies

Use `npm install`.
If you have installed `yarn`, can use `yarn`.

## Development server

Run `npm start` for a dev server. Navigate to `http://localhost:4200`. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `-prod` flag for a production build.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).
Before running the tests make sure you are serving the app via `ng serve`.


## ===================================================================


## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).

How to build an Angular Application with ASP.NET Core in Visual Studio 2017 [visualized](https://medium.com/@levifuller/building-an-angular-application-with-asp-net-core-in-visual-studio-2017-visualized-f4b163830eaa).