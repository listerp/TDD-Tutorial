# TDD-Tutorial #
####Lister Potter####
#####lister@listerpotter.com#####
#####www.listerpotter.com#####

## What are we learning ##
The intention of this tutorial is to show how to use TDD in a real world type application, we will be showing how to create an application using TDD, and DI.

## Technologies Used ##
* C# - Visual Studio 2015
	* C# Library
	* Console Application
	* Web Api Application
	* MVC Web Application
* Machine Specifications (MSpec) - TDD Framework
	* Machine Specifications Should (Assertion Library)
	* Machine Specifications Fakes (Faking Framework)
* Ninject - DI Framework


## The Application ##
We are building a library that will encode a sentence by replacing all words using the following scheme:

* First letter, followed by the number of distinct characters between the first and last character, followed by the last letter.
* If the word only has two letters it should not display the number of characters between the letters.
* Spacing and special characters should be maintained in their original order in the encoded sentence. 

For example:
 * Smooth would become S3h
 * to would become to
 * dog would become d1g

## The Projects ##
### TDD.Core ###
The core library code for our application.

### TDD.Core.Tests ###
The TDD tests for the core library.

### TDD.Console ###
A console app that uses the core library.

### TDD.Console.Tests ###
The TDD tests for the console applicaiton.

### TDD.Api ###
An MVC Web Api Application that users our core library.

### TDD.Api.Tests ###
The TDD tests for the Api.

### TDD.Mvc ###
An MVC Web Application that users our core library.

### TDD.Mvc.Tests ###
The TDD Tests for the MVC Web Applicaiton.

## Getting Started ##
We'll start off by creating out VS solution, and adding two empty C# library projects:

* TDD.Core
* TDD.Core.Tests

Before we can start writing unit tests, we will need to install some NuGet packages in our TDD.Core.Tests project.

We will be using the Machine Specifications (MSpec) testing framework for this tutorial, I chose MSpec because I like the way the code reads while creating and running the tests.

To install these packages open up the Package Manage Console, making sure you are in the TDD.Core.Tests project and type these commands

```
Install-Package Machine.Specifications
Install-Package Machine.Specifications.Should
```

### Adding our First Test ###

Before we add our first test lets talk about some conventions for creating our tests.

From the Machine.Specifications wiki:

>MSpec is called a "context/specification" test framework because of the "grammar" that is used in describing and coding the tests or "specs". That grammar reads roughly like this

>>When the system is in such a state, and a certain action occurs, it should do such-and-such or be in some end state.

>You should be able to see the components of the traditional [Arrange-Act-Assert][9] model in there. To support readability and remove as much "noise" as possible, MSpec eschews the traditional attribute-on-method model of test construction. It instead uses custom .NET delegates that you assign anonymous methods and asks you to name them following a certain convention.

#### Naming ####
