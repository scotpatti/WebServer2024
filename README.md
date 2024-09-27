# Homework 6 Directions for WebServer2024

In this assignment, you will develop a simple HTTP/1.0 compliant web server in C# that can handle multiple connections. 
Requirements:
1. Use the accompanying skeleton code that contains unit tests. Follow the directions in the files themselves – it's self-documenting.
   1. You must modify RequestHandler.cs and WebServerMain.cs
   1. You may add additional classes to your project
   1. You MAY NOT edit or otherwise modify any of my code. I will check to make sure that it has not been tampered with. 
   1. Do not edit the WebServerXUnitTests project at all. Just use it to run the tests.
1. Your web server must answer TCP requests on port 8080 (See the Constants.cs file)
1. Your web server must be able to handle Windows or Linux style path separators (See Constants and Program objects)
1. Your web server must comply with HTTP/1.0 requests: GET only! 
1. Your web server must be able to reply with standard HTTP codes:
    1. 200 OK
    1. 400 Bad Requests
    1. 404 Not Found
    1. 500 Internal Server Error (You may not need this one. I eventually did not)
1. I should not be able to crash your server or access files outside of the wwwroot directory. I.e. handle any possible errors with appropriate responses. 
1. Use the files in wwwroot for error page content. Do not change them.

Advice: 

Read every file that ends in .cs and .html before you do any coding. When you ask for help that will be the first question that I ask you. 

Mac Users:

Yes you can do this project using your Mac. Download Visual Studio for Mac and use that. HOWEVER, when you go to upload the zip file. Make sure it doesn’t have the __MACOSX and .DSStore folders included. To remove them do the following at the command prompt:
```
	zip -d webserver.zip -d ___MACOSX/\*
	zip -d webserver.zip -d \*/.DS_Store
```
Grading:

Upload a zip file of your project (similar to my zip file skeleton that I gave you) to Gradescope HW06
Gradescope will run my unit tests and give you a score and feedback. 

