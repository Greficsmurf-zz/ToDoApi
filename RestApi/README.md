# Project Title

RestApi для ToDoList

## Getting Started

Здесь расписаны все варианты запросов к api

### Перед запуском в корне проекта запустить следующее

* dotnet ef migrations add InitialCreate
* dotnet ef database update

### Запросы

* GET api/goals -- вывод всех задач
* GET api/goals/name/{Name} -- вывод задачи по ее имени
* GET api/goals/id/{Id} -- вывод задачи по ее id

* POST api/goals -- загрузка задачи
* POST api/goals/upload/name/{Name} -- загрузка файла в задачу по ее имени в виде IFormFie
* POST api/goals/upload/id/{Id} -- загрузка файла в задачу по ее id в виде IFormFie

* Delete api/goals/name/{Name} -- удаление задачи по имени
* Delete api/goals/id/{Id} -- удаление задачи по id

* PUT api/goals/name/{Name} -- обновление задачи по имени
* PUT api/goals/id/{Id} -- обновление задачи по id

минимальный вид goal: 

* "Name" : "Task1",
* "Description" : "task1",
* "EndDate" : "2020-04-23T18:25:43.511Z",
* "CategoryId" : 2


поля goal: 
* public long TaskId { get; set; }
* public string Name { get; set; }
* public string Description { get; set; }
* public Byte[] File { get; set; }
* public DateTime EndDate { get; set; }
* public long CategoryId { get; set; }
* public string Status { get; set; }

Категорий 3 по id: 1(High priority),2(Medium priority),3(low priority)
	
