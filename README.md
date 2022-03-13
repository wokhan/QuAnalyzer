# QuAnalyzer

![](https://img.shields.io/badge/.NET-6-blue)
![](https://img.shields.io/badge/UI-WPF-green)
![](https://img.shields.io/badge/Status-Unreleased-red)

## Disclaimer 🏴

⚠️Some features are not complete yet or might be buggy since I'm working on this during my free time (as for my other projects). Please do not complain if it doesn't work as expected.
Features might also change without notice.
Please do not use in a production environment.

## Description 🗃️

QuAnalyzer is another project I started almost 10 years ago and used for my own... and then forgot a little bit.
I partly rewrote it and migrated it to .NET Core 3.1 (now .NET 6) before deciding to push it as an open source initiative.

This application goal is to provide easy tooling around data management and exploration, such as:
- A complete data viewer with sorting / grouping abilities
- Data comparison from heterogenous sources (for instance a database versus a CSV or XLSX file)
- Statistics and automatic pattern analysis
- Monitoring (including a performance test)
- ...

Various data sources can be used (database, web service query, CSV/Xlsx, ...) and can be parameterized through the UI, making it easier to manage those. 

## Releases 🗄️

Releases will be published once the app reaches a stable state, so don't expect one before at least mid-2022.

As of now I've to double check that Providers are all OK (since I updated the underlying logic) and I should improve the Monitoring page. 
And of course I still have some known issues to deal with 😅

## How it works 🧰

QuAnalyzer relies on my Wokhan.Data.Providers libraries to access data, which in turn uses .NET LINQ's IQueryable features (meaning that everytime it's possible, a LINQ-to-whatever expression is built, allowing ordering, filtering, grouping... to occur on the server side for database accesses, for instance).

## Features / Screenshots 🖼️

About screen

<img src="https://user-images.githubusercontent.com/24826061/158075226-fcfdb079-e694-4b78-a73a-17e1d7ad4bb0.png" width=50% height=50% />

Data viewer with drag & drop based aggregations and filtering

<img src="https://user-images.githubusercontent.com/24826061/158077701-e28ae13a-7958-446a-8ed5-8e7b008feb21.png" width=50% height=50% />

Duplicates

<img src="https://user-images.githubusercontent.com/24826061/158075480-c980b73b-4f33-4525-94e7-5fa134349b49.png" width=50% height=50% />

Patterns

<img src="https://user-images.githubusercontent.com/24826061/158077740-b2a6de26-9dd0-4960-9600-a77acc9d41f1.png" width=50% height=50% />

Statistics

<img src="https://user-images.githubusercontent.com/24826061/158075492-5f88a427-83f4-438a-aa6d-2d508cb48a8e.png" width=50% height=50% />

Comparison

<img src="https://user-images.githubusercontent.com/24826061/158075493-3936f516-da5e-440c-b245-d560d2507f7a.png" width=50% height=50% />

Monitoring

<img src="https://user-images.githubusercontent.com/24826061/158075499-29785ed1-179c-46fc-8dfa-8139467ef843.png" width=50% height=50% />
