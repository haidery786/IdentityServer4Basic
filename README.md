 IdentityServer4Basic
Implementing IdentityServer4 on ASP.NET Core and .NET Core

Features
 ASP.NET Core Web Application template is used to develop IdentityServer4InMem by setting configuration in the middleware.
 Users, clients and scopes are all set in memory for this project.
 ASP.net Core MVC Web Application template is used to develop client 

Pre-requisites
.Net core 3.1 SDK
Visual studio 2019 OR VSCode with C# extension
 
Installation
Clone the repo:
git clone https://github.com/haidery786/IdentityServer4Basic.git

Restore packages:
dotnet restore IdentityServer4Basic.sln

1. debug the IdentityServer4InMem project alone to test by signing in a test user ( username: alice, password: alice ).
2. Run both the MvcClient.Portal and IdentityServer4InMem projects together by setting up to run multiple projects from properties of sln.
3. Click on Privacy (secure) link, it will redirect to Identity server to authenticate and redirect back.

Please use official IdServer4 documentation at this link for detail https://identityserver4.readthedocs.io/en/latest/quickstarts/2_interactive_aspnetcore.html
