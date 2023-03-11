# Portfolio_MauiNewsfeed

## Introduction

A newsreader app for consuming select "DR Nyheder" RSS feeds while allowing the user to filter the contents of said feeds. Developed as part of a .NET Maui-course at  Dania Academy.

Functional Requirements:
- [x] Display RSS Feeds from DR Nyheder
- [x] Developed specifically with Android devices in mind
- [x] Toggle Filtering of the News Feed
- [x] Blacklist Filter
- [x] UI Localized in Danish 

Non-functional Requirements:
- [x] Userdefined Filters for up to 3 words per Filter.
- [x] Create, Edit, Save, and Deletion of Userdefined Filters. 
- [x] Use Local Storage for persisting filters
- [x] Whitelist Filter

## Visual Presentation

   
<p align-content="space-between">
   <img width="30%" height="auto" src="https://user-images.githubusercontent.com/76184606/224510513-f100979b-cf71-426a-bd8c-7578ffa245a2.png">
   <img width="30%" height="auto" src="https://user-images.githubusercontent.com/76184606/224510513-f100979b-cf71-426a-bd8c-7578ffa245a2.png">
  <img width="30%" height="auto" src="https://user-images.githubusercontent.com/76184606/224510513-f100979b-cf71-426a-bd8c-7578ffa245a2.png">
</p>
   
## Selected Implementation Details


1. The Application is a .NET Maui Blazor Hybrid solution. 
   - It leverages Maui for ease of deployment to all platforms natively.
   - The Front End is Component-Based and developed using Blazor
   - Following the Maui structure conventions, the application is a single project.



2. Persisting User Choices, Selections, such as whether to toggle filtering, is persisted using the Microsoft.Maui.Storage.Preferences static class.
   - Lightweight and easy to use for simple data types. For example, if I want the title of the active filter, I request the following:
   
      ```cs
      string activeFilterTitle = Preferences.Get("ActiveFilter", "None");
      ```
      
3. For storing the actual filters I leverage the FileSystem.AppDataDirector property to dynamically store local .json data in a platform agnostic "correct directory".
   - This is handled through an IAppDataService<T>-implementation, which makes it easy to extend the application to save other types of data and secures a low coupling between service and UI.

4. Validation of a new filter to be created presented an obstacle due to the whitelist and blacklist. 
   - Clearly it should not be a requirement to input any words in both, but there should be one in either for a valid submit of the inputform.
   - To handle this I extended the ValidationAttribute-class and developed an attribute [RequiredDisjunction], which allows a developer to specify any number of properties by name, of which at least 1 should have a valid value. Example usage:
   
      ```cs
      [RequiredDisjunction("PropertyName1", "PropertyName2", ErrorMessage = "At least one of these should be filled out."]
      ```
   
   - This attribute is applied to both the whitelist and blacklist on the NewsfeedFilterInputModel, whereby the user is required to specify at least one filter word.
