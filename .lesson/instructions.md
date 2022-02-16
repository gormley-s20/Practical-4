## COM741 Web Applications Development

### Practical 4 (Introduction to MVC)

***Note:*** If you want to complete the practical using VSCode, but also wish to maintain a copy on replit to submit for feedback, then please review question 7 and the notes on use of Git/Github at end of lecture slides. We will be configuring our weekly exercises to use this approach going forward.

1. Create a new MVC project by opening the Command/Shell window and typing the command below. If you make a mistake then simply delete any folder created and re-execute the command. 

    - ```$ dotnet new mvc -o SMS.Web```

    - **IMPORTANT:** To enable the project to run in both replit.com and locally *we need to make two small changes to the created project*. Note this is normally not required when only running a project on your own computer.
  
        - Edit ```Properties/launchsettings.json``` and edit the ```applicationUrl``` property value in the ```SMS.Web``` configuration to the following ```"applicationUrl": "http://0.0.0.0:5000",```

        - Edit ```Program.cs``` and comment out the command ```//app.UseHttpsRedirection();``` to stop the server trying to automatically redirect all traffic to https.

    - To ensure the project is configured correctly - execute the project using the following command in the Command/Shell ```$ dotnet run --project SMS.Web```. If using replit, the project should start and open in a mini-browser window within the repl. To open a browser in a new tab, click the arrow icon in the top right hand corner of the mini-browser window. If using VSCode on a local computer then simply open a browser window and enter the url ```http://localhost:5000``` to view the application. 

    - To stop the project press ```Ctrl-C``` in the Command/Shell.

    - To configure the Repl run button to start the project, edit the .replit file and change the run command to ```run="dotnet run --project SMS.Web"``` 
 
    - **NOTE:** When using replit for development, each time you modify the solution you have to stop and restart the server as outlined above, then refresh the mini-browser or external browser tab window (it might take a few seconds for the server to recompile and load the changed application). When developing on your local computer using VSCode, you can make use of a hot-reload option (watch) that reduces the number of times you have to stop/start the server ``` $ dotnet watch run --project SMS.Web```

2. In the ```Views\Home``` folder, open the ```Index.cshtml``` file, remove all existing content and add a ```<div>``` with a class of ```text-center```. Inside this div create a ```<h1>``` containing text 'Home Page' and a ```<p>``` containing the text 'This is the default page displayed when the application loads'. 

3. Again modify the ```Index.cshtml``` file and add a second paragraph tag as outlined below. Note the use of the razor command (prefixed with @) to display current date/time in long date format 
   
   ```
   <p>Today is <b>@DateTime.Now.ToLongDateString()</b></p>
   ```

4. Generating data directly in the View is not a good idea. We want the view to be mostly html and contain the minimal amount of C# code. We therefore need some way to pass data to the View. One simple way is to use the controller ```ViewBag``` container. Open the ```HomeController.cs``` file located in the ```Controllers``` folder and modify the ```Index()``` action:
   
   * Add two new properties to the ViewBag, named ```LongTime``` containing current date/time formatted to a LongTimeString, and ```Message``` containing text "Time Now".
   
   * Modify the Index.cshtml file and add another ```div``` to end of file with a class of ```text-center```. In this div add a ```<p>``` tag containing a message constructed using the ```@ViewBag.Message``` and ```@ViewBag.LongTime``` values. (note how we can access the elements placed in the Viewbag by the Index controller action using the @ razor syntax)


5. The second (and preferred way) we can pass data to the view is to use a model (either a Data model or a ViewModel). In this example we will create a ViewModel. Remember a ViewModel is just a model that contains a custom representation of the data for display in a view.
   
   - In the Models folder, create a new view model named AboutViewModel.cs, and add the following code. Note that it is just a plain C# class containing properties.
     
     ```
     using System;
     
     namespace SMS.Web.Models
     {
        public class AboutViewModel
        {
           public string Title { get; set; }
           public string Message { get; set; }
           public DateTime Formed { get; set; } = DateTime.Now;
           public string FormedString => Formed.ToLongDateString();
           public int Days => (DateTime.Now - Formed).Days;
        }
     }
     ```
   
   - Add a new Controller Action and View as follows: 
     
     - In the ```HomeController``` create a new Action method named ```About``` and in this method create an instance of the new ```AboutViewModel```, setting the Title, Message and Formed properties to values of your choice. The ```Formed``` property can be initialised using ```new DateTime(2022,1,1)``` ( 1st Jan 2022). Note if you don't supply a value for Formed then it defaults to the current DateTime. Finally return the View passing the viewmodel as a parameter. Review the notes and existing methods in the controller for guidance on creating an action.
     
     - Create a View in the ```Views\Home``` folder named ```About.cshtml``` to display the model properties. Use some suitable html elements and appropriate bootstrap components/styles to display the model data. Ensure you begin the .cshtml file with a declaration of the model type
       
       ```
       @model AboutViewModel
       
       <!-- place html content here -->

       ```
   
   * To view the new page, in the browser address bar, add ```/home/about``` to the end of the url 
   
   * To create a permanent menu option for the ```About``` page. Modify the layout file found in ```Views/Shared/_Layout.cshtml``` and add a new nav menu element (below the Privacy nav link) to provide a link to the new About action. Copy one of the other nav ```<li>``` items and amend as necessary. A new menu option ```About``` should appear on the menu bar and clicking it should take you to the about view. We will learn more about this command next week.
     

6. In this question practice using bootstrap layouts/components to modify the presentation of the About page. 
   
   * Update the ```About.cshtml``` file and apply a bootstrap card style. Consider applying e.g. border shadows, colour etc.
   
   * Add following styles to the ```styles.css``` file found in ```wwwroot\css folder```.   
   - add a style called ```callout``` that is configured as follows: 
     
     ```
     .callout {
         padding: 1.25rem;
         margin-top: 1.25rem;
         margin-bottom: 1.25rem;
         border: 1px solid lightgray;
         border-left-color: silver;
         border-left-width: .50rem;
         border-radius: .25rem;
     }
     
     .callout-info {
          border-left-color: deepskyblue;
     }
     ```
   * Now apply these classes to format the first div in the ```Index.cshtml``` file (```<div class="callout callout-info">```). Feel free to add further colour configurations eg. ```.callout-warning``` with colour red etc.

7.  ***OPTIONAL*** To allow us to edit a single project instance both locally using VSCode and in replit, we can make use of the Git source code management tool and the Github cloud repository. The overriding majority of software development companies would use Git/Github so this is a skill you need to learn. 

    - We should firsly create a ```.gitignore``` file using the following command in the replit version of the project ``` $ dotnet new gitignore```. This file will tell git to ignore any files that are not part of our project source code.
    - Next, follow the guidance notes at the end of the lecture slides
