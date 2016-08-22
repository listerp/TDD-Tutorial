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

Before we can start writing unit tests, we need to do a couple of things:

* First we need to install some NuGet packages in our TDD.Core.Tests project.

We will be using the Machine Specifications (MSpec) testing framework for this tutorial, I chose MSpec because I like the way the code reads while creating and running the tests.

To install these packages open up the Package Manage Console, making sure you are in the TDD.Core.Tests project and type these commands

```
Install-Package Machine.Specifications
Install-Package Machine.Specifications.Should
```

* Next we need to be sure to add a project reference to our TDD.Core project.

## Test Conventions ##

From the Machine.Specifications wiki:

>MSpec is called a "context/specification" test framework because of the "grammar" that is used in describing and coding the tests or "specs". That grammar reads roughly like this

>>When the system is in such a state, and a certain action occurs, it should do such-and-such or be in some end state.

>You should be able to see the components of the traditional [Arrange-Act-Assert][9] model in there. To support readability and remove as much "noise" as possible, MSpec eschews the traditional attribute-on-method model of test construction. It instead uses custom .NET delegates that you assign anonymous methods and asks you to name them following a certain convention.

#### Project Layout ####
To help us organize and find our tests I recommend creating folders in our test project for our tests, the folders allow us to 
group our tests together by area and function I like to create a folder for each namespace for the project we are testing.  

### Naming our tests ###
Because MSpec is a "context/specification" test framework, all of our tests should start out with the word "when" so for anyone 
looking over our test knows exactly what we are testing and when.

## Our First Test ##

What? We're adding a test already? But we haven't even written any code to test!

Relax, this is the whole concept behind TDD (Test Driven Development) another developer pointed out to me that the third "D" in
TDD should really be Design not Development because what we are really doing by writing our tests first is ensuring we have a 
good design in our solution that is easily testable. Before this I really struggled with why should I ever write a test before
I wrote even one line of code, now it makes perfect sense. I also found out that if I write my code first and then go back to 
create tests for it, I spend extra time refactoring the code to make it more easily testable, so by writing the tests first 
I save myself and my customer valuable time and money.

### Design ###
Now we have to decide how we are going to implment our solution. Before we can encode an entire sentence, paragraph, whatever 
we need to be able to encode a single word, so we will implment the encode function as an extension to the string object. Based 
on the decision to arrange our tests in project folders based on the namespace of the class being tested we need to create a 
folder in our TDD.Core.Tests project called Extensions, under that folder create another folder called StringExtensionTests.

### The Test ###
After the folders have been created add a new class to the StringExtensionTests folder called when_a_simple_word_is_encoded. I know 
what you are thinking what is with all the ugly underscores in our class name, wouldn't it be better to call it WhenASimpleWordIsEncoded? 
This is done due to the conventions most test runners use, when the tests are shown in the test runner's GUI the underscores are 
replaced with spaces making the test names very readable.

#### Components of the Test ####

##### Subject Attribute #####
Each test should have a subject attribute, this describes the context of the test.  This can be a litteral Type under test or
a description. I prefer to use the litteral type for most tests so all tests for a given type are grouped together in the test runner. 
So lets set the subject attribute of our test to 

`Subject(typeof(StringExtensions))`

Of course now we have written code that won't compile because we have referenced a type that doesn't yet exist, that is ok this 
is the first step in our TDD process, remember the basic TDD steps are Red, Green, Refactor, here we are in the "red".

#### Arranging our test ####
Here we use the `Establish` delegate to setup ("Arrange") any pre-requisits for the test, for a small test like we are doing here 
we don't really need to use the `Establish` delegate but for consistency I like to always include it.

In your test add the following code:

```
private static string wordToEncode;
private static string expectedEncodedWord;
private static string actualEncodedWord;

Establish context = () =>
{
    wordToEncode = "Dog";
    expectedEncodedWord = "D1g";
};
```

#### Acting on our test ####
Here we use the `Because` delegate to perform the single action we are testing, again for a small test like this one we don't 
really need to use the `Because` delegate but for consistency lets do so.

In your test add the following code:

```
Because of = () =>
{
    actualEncodedWord = wordToEncode.Encode();
};
```

Here we have our second bit of "red", we are trying to call an extension method that doesn't exist, again this is the way this 
is supposed to work, remember we are designing our solution here we will create our most basic implemntation of this shortly.

#### Getting Assertive ####
Now that we have Arranged, and Acted on our class, we need to Assert that it correctly performed the task, to do this we will
use the `It` delegate. When writing `It` delgates when to ensure that we are only testing one aspect of the expected results, 
so it is not uncommon for a test to have multipe `It` delegates, and since the `It` delegate only tests one thing they are 
not usually multi-line methods and normally won't need squiggly brackets.

For this particular test we only have one thing to assert, so add the following code to your test class:

```
It should_set_actualEncodedWord_to_D1g = () =>
    actualEncodedWord.ShouldEqual(expectedEncodedWord);
```