<h2>Hawker Center Finder Tool</h2>

<h4>The tool to find the nearest N  hawker Centres. </h4>

Pre-requisites
 In order to connect the docker to internet for resolving NuGet package url, add the following to Docker Desktop -> Settings -> Docker Engine :
	"dns": ["10.1.2.3","8.8.8.8"]

<h3>Steps to run the Solution:</h3>


  Using the Docker (Docker Target OS :Windows)
      
      1. In the command prompt, open the root directory of the solution i.e ./HawkerCenterFinder
      2. docker build -t HawkerCenterFinder.
      3. docker run -p 8080:80 --rm hawkercenterfinder
      4. Run the swagger on http://localhost:8080/swagger
      5. Now follow Run The APIs Section

    API Endpoints For Docker
		POST http://localhost:8080/api/v1/Authenticate/login - Post the credentials and retrieve JWT Token
		POST http://localhost:8080/api/v1/hawkercenter/refreshdata - GET the latest data
		POST http://localhost:8080/api/v1/hawkercenter/searchclosest  - Get N closest hawker centers


  Using VS (IIS Express)
  
    1. Open Visual Studio
    2. Set HawkerCenterFinder.Api as the startup project
    3. Run the solution by clicking IIS Express button
    4. Run the swagger on https://localhost:44374/swagger
    5. Now follow Run The APIs Section

	API Endpoints For Docker
		POST http://localhost:44379/api/v1/Authenticate/login - Post the credentials and retrieve JWT Token
		POST http://localhost:44379/api/v1/hawkercenter/refreshdata - GET the latest data
		POST http://localhost:44379/api/v1/hawkercenter/searchclosest  - Get N closest hawker centers


<h4> Run the APIs with Credentials( Username : 'HawkerCenter',  Password : 'Password' )</h4>

	1. Post the body { "username": "HawkerCenter","password": "Password"} to api/v1/Authenticate/login API.
	2. On successful authentication, the API will respond with JWT token.
	3. Copy the token and paste in the dialog by clicking Authorize button as 'Bearer {token}',
	4. Now the APIs can be accessed successfully. 
