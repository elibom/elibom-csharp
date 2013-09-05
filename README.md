<h1>Elibom .NET API Client</h1>
==========

A CSharp client of the Elibom REST API. <a href="http://www.elibom.com/developers/reference">The full API reference is here</a>


<h2>Requisites</h2>

Add System.Web.Extensions framework reference to your project.

<h2>Getting stared</h2>

1. Install
    
    Like a NuGet package https://www.nuget.org/packages/Elibom/1.0

    or
    
    download .dll file https://github.com/elibom/elibom-csharp/releases/download/1.0/Elibom.dll and add it like 
    reference in your project.

2. Create an ElibomClient object passing your credentials:

    ```c#
    using Elibom;

    ElibomClient elibom = new ElibomClient("your_email@domain.com", "your_api_token");
    ```
    
    Note: You can find your api password at http://www.elibom.com/api-password (make sure you are logged in).
    
    You are now ready to start calling the API methods!

<h2>API Methods</h2>

* [Send SMS](#send-sms)
* [Schedule SMS](#schedule-sms)
* [Show Delivery](#show-delivery)
* [List Scheduled SMS Messages](#list-scheduled-sms-messages)
* [Show Scheduled SMS Message](#show-scheduled-sms-message)
* [Cancel Scheduled SMS Message](#cancel-scheduled-sms-message)
* [List Users](#list-users)
* [Show User](#show-user)
* [Show Account](#show-account)

### Send SMS
```c#
//Return string
string deliveryId = elibom.sendMessage("3201111111","NET - TEST");
```

### Show Delivery
```c#
//Return dynamic
var delivery = elibom.getDelivery("<delivery_token>");
Console.WriteLine(delivery["numFailed"]);
foreach(var message in delivery["messages"]) {
    Console.WriteLine("message");
    Console.WriteLine("To : " + message["to"]);
    Console.WriteLine("Operator : " + message["operator"]);
}
```

### Schedule SMS 
```c#
//Return string
string scheduleId  = elibom.scheduleMessage("3201111111", "Test C#", "dd/MM/yyyy hh:mm");
```

### List Scheduled SMS Messages
```c#
//Return dynamic
var scheduledMessages = elibom.getScheduledMessages();
foreach(var schedule in scheduledMessage) {
	Console.WriteLine(schedule);
	Console.WriteLine(schedule["scheduledTime"]);
}
```

### Show Scheduled SMS Message
```c#
//Return dynamic
var schedule = elibom.getScheduledMessage("<schedule_id>");
Console.WriteLine(schedule);
//get scheduled time
Console.WriteLine(schedule["scheduledTime"]);
```

### Cancel Scheduled SMS Message
```c#
//Void
elibom.unscheduleMessage("<schedule_id>");
```

### List Users
```c#
//Return dynamic
var users = elibom.getUsers();
foreach(var user in users) {
        Console.WriteLine(user);
        //get name
        Console.WriteLine(user["name"]);
}
```

### Show User
```c#
//Return dynamic
var user = elibom.getUser("<user_id>");
Console.WriteLine(user);
Console.WriteLine(user["name"]);
```

### Show Account
```c#
//Return dynamic
var account = elibom.getAccount();
Console.WriteLine(account);
//get account credits
Console.WriteLine(account["credits"]);
```
