# unsw app
The application uses aspnetcore 2.1 for backend and angular 5 as the front-end framework. It uses aspnet Identity for user accounts and uses webtokens for authentication.
The application has two roles 1. Admin and 2. Medical User. A user can sign-up to the application using the link provided in the home page. An admin has to login and activate the user in-order for the user to login and see the patient data.
An admin account has been seeded in the application with ```username: admin@admin.com and password: admin1234.``` 
A medical user can login and see the patient data in real time. 

To simulate the real time data we can send a post request to    ```http://localhost:49944/api/message``` with a body of ```{'patientId':1,occupation:"living room"}``` and we can see the change being updated in the patient data page.
# deployment
The application can be deployed either on windows or linux as aspnetcore supports it. 
* Install Sqlserver(for the database)
* Install dotnet sdk 2.1
* Install the project dependencies using npm(inside ClientApp) and dotnet commands(inside project directory).
* Build the application using `dotnet build` inside the project directory.
* Run it using `dotnet run`
# Question answers
1. If I had more time I would focus more on error handling and asthetics of the application.
2. The authentication and the front-end application development took me the most amount of time because I have learnt angular development before but I did not have any practical experience with it.
3. I would suggest making provisions in the app to directly contact the customer from within the application. I would be able to give more suggestions If I have some more knowledge of the scope of the project.

# Final Interview questions
1. I liked that I got a chance to show my skills by developing the application.
2. I little heads-up about the interview would have great but not absolutely necessary after all we need to adapt to the situation. 
