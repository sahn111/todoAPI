# Welcome to my ASP .NET Web API Project

     - This project is created by using .NET. 

     - MongoDB is used as the default database.

<br>

## Note

- User need to create a new database in local to work properly.

<br>

## Here is the guide to create a new MongoDB database :

Use this command to create a path to database folder, it is not really important, just create a folder and give the path.
    
    mongod --dbpath <data_directory_path>
    
Write this command to start mongo

    mongosh

Switch user

    use ToDoList

Create collection

    db.createCollection('ToDos')

Define a schema for collection

    db.ToDos.insertMany([{ "Name": "Design Database", "TargetDuration": "Week", "Report": "This is a new design database test report"}])

<b>Now you can start the API and use endpoints by typing `` dotnet run ``.

----------------------------------------------------------------

<br>

<b>Sample Post Model for developers

    {
      "taskName": "testTask",
      "targetDuration": "gunluk",
      "report": "bu bir testdir"
    }

.
<br>
.
<br>
<b>To use this API, you need to LogIn first. To make easy use I will gave them as
<br>

    username : "test",
    password : "test123"

<b> After you get the key, enter it to the Authorization part and LogIn.
After the, you can start to use API.
<br>
.
<br>
.
<br>

<b>>>> Project is created by using Microsoft sources ( learn.microsoft.com )