# EmployeeTracker
This is a ASP.NET Web API for an Employee Management System. This uses C#, .NET Framework, Entity Framework and MS-SQL  for the back end and Swagger UI for the front-end.

# Running This Application
To run this application: <br/><br/> Step 1: you have to clone this to your local machine. 
<br/>
<img src="/EmployeeTrackerSccreenshotSeven.png"/>
<br/>
<br/>
Step 2: After you have successfully cloned this application, right click on EmployeeTracker.WebAPI and click on properties.
<br/>
<br/>
Step 3: Click web, there you will see an option for start url, click that option.
<br/>
<br/>
Step 4: After you clicked that add the <localhost:port>/swagger/ui/index. You can also just add `/swagger` to the url instead of this when you run this application.  
<br/>
Step 5: After that, make sure bin, roslyn and packages are in the project. You can check this with by clicking `show all files`. You should not run into this issue if you clone it. However, if you do, this is  how you resolve that issue. 
<br/>
<br/>
Now, you can successfully run the application. 


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
