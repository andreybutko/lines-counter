# Lines counter

Requirements: [.NET Core 3.1](https://dotnet.microsoft.com/download)  
Supported OS: Windows, Linux, MacOS

## How it works? ##

Console app reads file lines with numbers enumeration (splitted by ',') and finds the line with a maximum sum.  
The max result will be printed to console windows as well as bad formed (invalid) lines.

## How to use? ##

Clone repository using

     git clone https://github.com/andreybutko/lines-counter.git

1. Run solution with Visual Studio

    Navigate to `..\lines-counter\` and run the solution file `LinesCounter.sln`

    File path can be set in 2 ways:
     1. launchSettings.json 
        ```
        "profiles": {
            "LineCounter": {
              "commandName": "Project",
              "commandLineArgs": "\"argument1\""
          }
        }
        ```
     2. proggram will ask you in CLI if nothing provided in settings file
2. Run with CLI

    Navigate to `..\lines-counter\LineCounter` and open CLI  
    Use this command to run an app:
   ```
        dotnet run 
   ```

## Tests ##
Solution contains UnitTest project with tests cases.  
You can run it with `Visual Studio`  
or using command inside test project folder `LinesCounter.UnitTests`:
```
    dotnet test
```

Tests cases descrived inside class `DataProvider` and could be easily extended.


