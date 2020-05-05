# Mw String Utilities
## Overview
This library contains string utility functions which, along with their unit tests, 
I seem to end up writing in too many projects.  Since I have better things to do with my time, I've 
created this library to save myself future effort.

The library is written in C# and targets .NET Standard 2.0
## Functions
### Left()
Returns a string containing the leftmost n characters.
```
string result = "one,two,three".Left( 3 );
Assert.AreEqual( "one", result );
```
### Right()
Returns a string containing the leftmost n characters.
```
string result = "one,two,three".Right( 3 );
Assert.AreEqual( "ree", result );
```
### LeftOfFirst()
Returns the part of the source string before any occurrence of the specified characters.
```
string result = "one,two,three".LeftOfFirst( "," );
Assert.AreEqual( "one", result );
```
### LeftOfLast()
Returns the part of the source string before any occurrence of the specified characters.
```
string result = "one,two,three".LeftOfLast( "," );
Assert.AreEqual( "one,two", result );
```
### RightOfFirst()
Returns the part of the source string after any occurrence of the specified characters.
```
string result = "one,two,three".RightOfFirst( "," );
Assert.AreEqual( "two,three", result );
```
### RightOfLast()
Returns the part of the source string before any occurrence of the specified characters.
```
string result = "one,two,three".RightOfLast( "," );
Assert.AreEqual( "three", result );
```
### Reverse()
Returns a reversed copy of the string.
```
string result = "one".Reverse( "," );
Assert.AreEqual( "eno", result );
```
### RemoveLeft()
Returns a string without the initial n characters.
```
string result = "one,two,three".RemoveRight( "4" );
Assert.AreEqual( "two,three", result );
```
### RemoveRight()
Returns a string without the trailing n characters.
```
string result = "one,two,three".RemoveRight( "6" );
Assert.AreEqual( "one,two", result );
```
### IsNaturalNumber()
Indicates if the string is a positive integer (including zero)
```
bool result = "123456789012345678901234567890".IsNaturalNumber();
Assert.AreEqual( true, result );
```
