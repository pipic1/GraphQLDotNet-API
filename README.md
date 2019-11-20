# GraphQLDotNet-API ⚛️

A GraphQL TodoList Web API. 
Query, Mutation, Schema.

[![Dotnet Core 3.0](https://img.shields.io/badge/dotnet%20core-3.0.0-blue)](https://dotnet.microsoft.com/download)

[![Graphql](https://img.shields.io/badge/graphql-documentation-%23e535ab)](https://graphql-dotnet.github.io/docs/getting-started/introduction/)

[![GitPitch](https://gitpitch.com/assets/badge.svg)](https://gitpitch.com/pipic1/GraphQLDotNet-API)


## Prerequisites

Visual studio code:
[![Visual studio code](https://img.shields.io/badge/sutdio%20code-latest-blue)](https://code.visualstudio.com/)

Extention OmniSharp:
[![OmniSharp](https://img.shields.io/badge/OmniSharp-latest-blue)](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)

.NET Core 3.0:
[![Dotnet Core 3.0](https://img.shields.io/badge/dotnet%20core-3.0.0-blue)](https://dotnet.microsoft.com/download)

.NET Framework 4.8 (for OmniSharp):
[![.NET Framework 4.8](https://img.shields.io/badge/dotnet%20framework-latest-blue)](https://dotnet.microsoft.com/download/dotnet-framework/net48)

## Start and run

Init solution and projects.

`dotnet restore`

`dotnet build`

Run the WebAPI.

`dotnet run -p .\WebApiTodoList`

Now go to 

http://localhost:3000/ui/playground

## From scratch

Init solution and projects.

`dotnet new sln`

`dotnet new classlib TodoList`

`dotnet new webapi -n WebApiTodoList`

Add project to your solution.

`dotnet sln add WebApiTodoList`

`dotnet sln add TodoList`

### Data structure

Create all necessary files.

```
cd TodoList

New-Item -ItemType file TodoListData.cs

New-Item -ItemType file TodoListQuery.cs

New-Item -ItemType file TodoListMutation.cs

New-Item -ItemType file TodoListSchema.cs

mkdir Types

cd .\Types\

New-Item -ItemType file TodoItem.cs

New-Item -ItemType file TodoItemInterface.cs

New-Item -ItemType file SecondaryTodo.cs

New-Item -ItemType file ImportantTodo.cs

New-Item -ItemType file StatusEnum.cs

```

### Create the API 


### Build and Run

Simply launch the following command:


`dotnet build`

Run the WebAPI.

`dotnet run -p .\WebApiTodoList`

Now go to 




# Mutation and query 
```
query GetTodo {
	importanttodo(id: "57a8d913-460e-41af-8cc3-a3ddd04a9d73") {
		id
		name
		description
		priority
	}
}
```

```
query GetAllImportantTodos{
  
}
```


```
mutation CreateTaskImportant($task: ImportantTodoInput!) {
  createImportantTask(task: $task) {
    id
    name
  }
}
```






