# TDD-Tutorial #
*Lister Potter*
lister@listerpotter.com
www.listerpotter.com

## What are we learning ##
The intention of this tutorial is to show how to use TDD in a real world type application, we will be showing how to create an application using TDD, and DI

## Technologies Used ##
* C# - Visual Studio 2015
	* C# Library
	* Console Application
	* Web Api Application
	* MVC Web Application
* MSpec - TDD Framework
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

## The projects ##
### TDD.Core ###
### TDD.Core.Tests ###
### TDD.Console ###
### TDD.Console.Tests ###
### TDD.Api ###
### TDD.Api.Tests ###
### TDD.Mvc ###
### TDD.Mvc.Tests ###