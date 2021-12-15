---
title: Regular Expressions
weight: 2
bookToc: true
---

# Regular Expressions

A **regular expression** (shortened as **regex** or **regexp**) is a sequence of characters that specifies a _search pattern_.

They are used for:

- validating text inputs (e.g. email address, phone number);
- extracting text from textual data (e.g. version number);
- replacing text;
- ...

All regular expression types are defined in `System.Text.RegularExpressions`.

## Basics

|                | Name          | Description                                                                        | Example                                                         |
| -------------- | ------------- | ---------------------------------------------------------------------------------- | --------------------------------------------------------------- |
| **Alternator** |               |                                                                                    |                                                                 |
| \|             | vertical bar  | separates alternatives.                                                            | `gray\|grey` matches "gray" or "grey".                          |
| **Grouping**   |               |                                                                                    |                                                                 |
| ()             | parentheses   | defines the scope and precedence of the operators                                   | `gr(a\|e)?y` matches "gray", "grey" or "gry"                    |
| **Quantifier** |               |                                                                                    |                                                                 |
| ?              | question mark | indicates _0_ or _1_ occurrences of the preceding element.                         | `colou?r` matches both "color" and "colour", but not "colouur". |
| \*             | asterisk      | indicates _0_ or _more_ occurrences of the preceding element.                      | `ab*c` matches "ac", "abc", "abbc", "abbbc", and so on.         |
| +              | plus sign     | indicates _1_ or _more_ occurrences of the preceding element.                      | `ab+c` matches "abc", "abbc", "abbbc", and so on, but not "ac". |
| {n}            |               | The preceding item is matched exactly _n_ times.                                   |                                                                 |
| {min,}         |               | The preceding item is matched _min_ or _more_ times.                               |                                                                 |
| {,max}         |               | The preceding item is matched up to _max_ times.                                   |                                                                 |
| {min,max}      |               | The preceding item is matched at least _min_ times, but not more than _max_ times. |                                                                 |
| **Wildcard**   |               |                                                                                    |                                                                 |
| .              | wildcard      | matches any character.                                                             | `a.b` matches "a1b", "acb" and so on.                           |

## Methods

`Regex.Match`.

`Regex.Match` searches for a _pattern_, whereas `string`'s `IndexOf` searches for a literal string.

```cs
var m = Regex.Match("12abcd", "ab?c");
Console.WriteLine(m.Success); // True
Console.WriteLine(m.Index); // 2
Console.WriteLine(m.Length); // 3
Console.WriteLine(m.Value); // abc
Console.WriteLine(m.ToString()); // abc
```

`Regex.Match` only returns first match. Use `NextMatch` method to return more matches.

```cs
var m1 = Regex.Match("abc ac", "ab?c"); // m1 is 'abc'
var m2 = m.NextMatch(); // m2 is 'ac'

// Iterate all matches
var match = regex.Match(input);
while (match.Success) {
    // Handle match here...
    match = match.NextMatch();
}
```

`Regex.IsMatch`.

`Regex.IsMatch("test", "te?")` is equivalent to `Regex.Match("test", "te?").Success`.

`Regex.Matches`.

`Regex.Matches` returns a collection of `Match` objects found by the search.

```cs
// Iterate all matches
foreach(var m in Regex.Matches("abc ac", "ab?c"))
    Console.WriteLine(m);
```

`RegexOptions`

`RegexMatchTimeoutException`

This exception is thrown when the execution time of a regular expression pattern-matching method exceeds its time-out interval.

```cs
try {
    var timeout = new TimeSpan(0, 0, 1);
    return Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase, timeout);
}
catch (RegexMatchTimeoutException e) {
    // time out
}
```