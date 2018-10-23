# unsw app
The application uses aspnetcore 2.1 for backend and angular 5 as the front-end framework. It uses aspnet Identity for user accounts and uses webtokens for authentication.
The application has two roles 1. Admin and 2. Medical User. A user can sign-up to the application using the link provided in the home page. An admin has to login and activate the user in-order for the user to login and see the patient data.
An admin account has been seeded in the application with username: admin@admin.com and password:admin1234. 
A medical user can login and see the patient data in real time. To simulate the real time data we can send a post request to http://localhost:49944/api/message with a body of {'patientId':1,occupation:"living room"} and we can see the change being updated in the patient data page.
