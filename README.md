# EmployeeTracker
This is a ASP.NET Web API for an Employee Management System. This uses C#, .NET Framework, Entity Framework and MS-SQL  for the back end and Swagger UI for the front-end.

# Running This Application
To run this application, you have to clone this to your local machine. 
<img src="/EmployeeTrackerSccreenShotseven.png"/>

# How To Create Account
Creating an Account : To create an account, the user must use the `api/Account/Register` endpoint. 
<br/>
<br/>
Create your Token : To create your token after successfully registering for an account, you must use the `api/token`</span> endpoint. 
<br>
<br/>
`grant-type: password`<br/><br/>
`username: <your email>` <br/><br/>
`password: <your password>`<br/>


After successfully creating your token, you must put that token in your headers if you are using Postman. However, in Swagger it will say `Authorization`. This is where you type `Bearer` `<token>`.
<br>
<br/>

Do not use quotation marks for your token when you place it in authorization and do not lose it.

After you successfully create an account and token, you can start using the endpoints provided in Swagger. 

<img src="/EmployeeTrackerScreenshotFour.png" height="300px"/>

<img src="/EmployeeTrackerScreenshotSix.png" height="280px"/>
