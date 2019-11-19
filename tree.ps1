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
New-Item -ItemType file PriorityEnum.cs