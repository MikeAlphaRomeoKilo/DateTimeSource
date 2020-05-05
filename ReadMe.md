# Mw DateTimeSource
## Overview
The .NET DateTime class presents certain difficulties in unit tests.  This library provides an IDateTimeSource interface, which contains two functions, Now() and UtcNow(), both of which return a DateTime object.  Two implementations of this interface are provided, DateTimeSource and TestableDateTime source.

DateTimeSource is a simple wrapper around DateTiime's Now() and UtcNow() functions.

TestableDateTimeSource is designed for use in unit tests.  It allows the test to specify the DateTime object that will be returned.

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
