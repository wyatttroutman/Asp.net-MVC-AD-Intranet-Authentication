# Asp.net MVC Active Directory Intranet Authentication
A simple additive that allows you to authenticate users with an Active Directory Group on an ASP.NET MVC Intranet application.

## Requirements
- You must be using Windows authentication on your ASP.NET MVC project.

## Installation
Copy the code from IntranetAuthorizeAttribute.cs into a equally named file in a supplemental code folder in your ASP.NET MVC project, or download the IntranetAuthorizeAttribute.cs file from this directory and add it manually. 

For example, I have a folder named "Classes" that contains the file IntranetAuthorizeAttribute.cs.

## Usage
To use, simply add the attribute to your controller function that you wish to authenticate the user for. Of course, you'll have to include a reference to the previously added Class file.

````C#
using MyProject.Classes;
namespace MyProject.Areas.MyArea.Controllers
{

    public class MyController : Controller
    {

        // GET: MyArea/MyController
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // GET:MyArea/MyController/AuthenticatedAction
        [HttpGet]
        [IntranetAuthorize(Roles = "DOMAIN\\AUTHENTICATION GROUP NAME")]
        public async Task<ActionResult> AuthenticatedAction()
        {
            MyService service = new MyService();
            return View(await service.GetData());
        }
   }
}
````    
If the current user is a member of the AD group, then they will be allowed to access the method. If not, then a 403 error will be generated. 

You can also automatically authenticate every action in the controller by setting the attribute on the controller itself.
````C#
using MyProject.Classes;
namespace MyProject.Areas.MyArea.Controllers
{
    [IntranetAuthorize(Roles = "DOMAIN\\AUTHENTICATION GROUP NAME")]
    public class MyController : Controller
    {

        // GET: MyArea/MyController
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // GET:MyArea/MyController/AuthenticatedAction
        [HttpGet]
        public async Task<ActionResult> AuthenticatedAction()
        {
            MyService service = new MyService();
            return View(await service.GetData());
        }
   }
}
````  

## Known Issues
- You may needed to deny anonymous users by adding the following line to your Web.Config in some cases.
````
<system.web>
  <authentication mode="Windows" />
  <authorization>
    <deny users="?" />
  </authorization>
</system.web> 
````

## Liability
This repository is provided as is. I make no representations or warranties of any kind concerning the legality, safety, suitability, lack of viruses, inaccuracies, typographical errors, or other harmful components of this repository. There are inherent dangers in the use of any software, and you are solely responsible for determining whether this software is compatible with your equipment and other software installed on your equipment. You are also solely responsible for the protection of your equipment and backup of your data, and I will not be liable for any damages you may suffer in connection with using, modifying, or distributing this software. This software was written for educational purposes only.
