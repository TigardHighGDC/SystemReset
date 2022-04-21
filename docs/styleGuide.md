# Style Guide and Naming Documentation

## C\# File naming

Files should follow the camel case naming convention. Where the begining of the
first word is lowercase and any new word that follows is capitalized.

Example:
```
thisIsAExampleFile.cs
```

## C\# Variable naming

Variable naming should follow the same convention as file naming.

The begining of the first word in a variable name should be lowercase and any new
word that follows should be capitalized.

Example:
```cs
private float thisIsAExampleVariable;
```

## C\# Class naming

Class naming in C\# also follows the camel case naming convention. Except the
first word in the class name should be capitalized. Then every new word that
follows should be capitalized.

Example:
```cs
public class ThisIsAExampleClass
{
}
```

This rule cannot be applied to overarching scripts. This is because of how
the Unity Game Engine works. For a script to be run the class must have the same 
name as the file name, in this instance the file name takes priority.

Example:
File name:
```
thisIsAExampleScript.cs
```
Script name:
```cs
public class thisIsAExampleScript : MonoBehaviour
{
}
```

Notice how the name of the class exactly matches the file name. Even the lowercase
first word of the class name.

## C\# If Statements, For Loops, and While 

C\# exactly like C, requires the use of curly braces to indicate the start and end
of an if statement, for loop, or while loop.

In C\# the curly braces start on the next line.

Example:
```cs
if (exampleBoolean)
{
    doSomething();
}

for (int i = 0; i < 10; i++)
{
    doSomething();
}

while (exampleBoolean)
{
    doSomething();
}
```

After every closing curly brace there should be a new line, unless the new
line is another closing curly brace.

Example:
```cs
if (exampleBoolean)
{
    doSomething();
}

if (exampleBoolean)
{
    for (int i = 0; i < 10; i++)
    {
        doSomething();
    }
}
```

## C\# Function naming

All functions should be treated as objects, and as such should follow the same
naming convention as class naming.

Example:
```cs
public void ThisIsAExampleFunction()
{
}
```

## C\# Unity functions, functions and variable access specifiers

Unity provides neumerous functions such as Start and Awake.
These functions should be marked as private.

Example:
```cs
private void Awake()
{
}
```

All other functions should be marked as needed. If they are accessed by other
scrips using the GetComponent<>() function, they should be marked as public.
Else they should be marked as private.

Thanks to the Unity class structure there are no global variables.
However each script is contained in a class. Any variables that are stored
in the main script class scope that are marked as public are presented as an 
option within the game engine. If this is intended, then the variable should
the public keyword. Else the variable should be marked as private.

Example:
```cs
public class exampleScript : MonoBehaviour
{
    public int publicExampleVariable; // Should be changed outside the script.
    private int privateExampleVariable; // Should not be changed outside the script.
}
```

This same idea will be followed by classes as well. Note that all overarching 
classes for a script should be marked as public, regardless if it is accessed
by another script or not.

## C\# Comments

All comments should be use the '//' symbol. Unless the comment is intended to be
a title for other comments that follow. Even if there is more than one line of
comment, it should still use the '//' symbol.

Example:
```cs
/* Title for the following comments */
// This is a comment.
// This is another comment.
```

Each comment should be a full sentence with proper punctuation.

## C\# Character Line Limits

As per the standard set by microsoft, the maximum number of characters per line 
is set to 80.
Thanks to C\#'s similar syntax to C there should be no need no go over the 
line limit.

Certain things such as if statements, for loops, and while loops can be 
easily broken up into multiple lines.

Example:
```cs
if (reallyLongClassName.ReallyLongFunctionNaame(reallyLongVariableName) &&
        reallyLongClassName.ReallyLongFunctionNaame(reallyLongVariableName))
{
    doSomething();
}
```

Other lines such as arithmetic statemts can be harder to break up.
However these types of lines should be separated into separate variables.
Since the compiler will need to compute these separate values and store them
in memory anyways, this will not cause any memory or performance overhead.

