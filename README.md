# GraphQLDotNet-API
A GraphQL TodoList Web API
Command

`dotnet new sln`

`dotnet new classlib TodoList

dotnet new webapi -n WebApiTodoList`
`
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
New-Item -ItemType file StatusEnum.cs`



# Mutation and query 
`
query GetTodo {
  importanttodo(id: "57a8d913-460e-41af-8cc3-a3ddd04a9d73") {
		id
    name
    description
    priority
  }
}

query GetAllImportantTodos{
  
}

mutation CreateTaskImportant($task: ImportantTodoInput!) {
  createImportantTask(task: $task) {
    id
    name
  }
}
`






