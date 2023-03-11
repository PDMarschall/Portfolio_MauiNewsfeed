# Portfolio_MauiNewsfeed

## Introduction

A newsreader app for consuming select "DR Nyheder" RSS feeds while allowing the user to filter the contents of said feeds. Developed as part of a .NET Maui-course at  Dania Academy.

Functional Requirements:
- [x] Display RSS Feeds from DR Nyheder
- [x] Developed specifically with Android devices in mind
- [x] Toggle Filtering of the News Feed
- [x] Blacklist Filter

Non-functional Requirements:
- [x] Userdefined Filters for up to 3 words per Filter.
- [x] Create, Edit, Save, and Deletion of Userdefined Filters. 
- [x] Use Local Storage for persisting filters
- [x] Whitelist Filter

### Implementation Details

1. The Application is a .NET Maui Blazor Hybrid solution. 
   - It leverages Maui for ease of deployment to all platforms natively.
   - The Front End is Component-Based and developed using Blazor
   - Following the Maui structure conventions, the application is a single project.

2. Persisting User Choices and Selections, such as whether to toggle filtering, is persisted using the Microsoft.Maui.Storage.Preferences static class.
   - Lightweight and easy to use for simple data types. For example, if I want the title of the active filter, I request the following:
   -
      ```cs
      string activeFilterTitle = Preferences.Get("ActiveFilter", "None");
      ```
