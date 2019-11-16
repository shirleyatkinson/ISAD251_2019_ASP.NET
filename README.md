# ISAD251_2019_ASP.NET
My Repository for demonstrating ISAD251 database application development

Welcome to the repository for demonstrating the sample application, the **Student Help In Tutorials** application.  This application is designed to allow students to register their request for help within a tutorial in SMB109 which then uses the smart lights to alert the lecturer of where a student is looking for support.

## Requirements
The functional requirements are as follows:
1.	As a student I wish to alert the lecturer that I need some help
2.	As a student I wish to see that my request for help has been acknowledged
3.	As a lecturer I wish to acknowledge the request
4.	As a lecturer I wish to reset the request

## Non-functional requirements
**Technical** : The application needs to be a web-based application that interacts with the Hue Lights in SMB109.  It runs on a web-server and is written in ASP.NET using the hosted Microsoft SQL Server database.  The interface for the student is via a desktop browser but the interface for the lecturer must be tailored for a mobile phone.

**Performance** : Response times are not within the scope of this application.  These are determined by the network set up within the lab.

**Usability** : The interfaces must conform to accessibility rules and good interface design.  Testing to be carried out via the W3 validator.

**Reliability** : These are outside of the scope of the application and are dependent upon the set up of the labs and servers.

**Security** : OWASP top 10 vulnerabilities are to be examined and addressed where appropriate.  Lecturers will be required to log in but students do not.  Only name information will be available to the lecturer to view.
