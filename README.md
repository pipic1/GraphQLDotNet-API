# GraphQLDotNet-API

A GraphQL TodoList Web API

Using Dotnet Core 3.0 
Graphql: https://graphql-dotnet.github.io/docs/getting-started/introduction/

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

`cd TodoList`

`New-Item -ItemType file TodoListData.cs`

`New-Item -ItemType file TodoListQuery.cs`

`New-Item -ItemType file TodoListMutation.cs`

`New-Item -ItemType file TodoListSchema.cs`

`mkdir Types`

`cd .\Types\`

`New-Item -ItemType file TodoItem.cs`

`New-Item -ItemType file TodoItemInterface.cs`

`New-Item -ItemType file SecondaryTodo.cs`

`New-Item -ItemType file ImportantTodo.cs`

`New-Item -ItemType file StatusEnum.cs`

### Create the API 




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






