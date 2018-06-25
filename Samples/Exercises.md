# I. Basics of Unit Testing

1. Write a full unit test coverage for the `StringParser` class from `Samples\StringParser.cs`

# II. Core Techniques for GOOD Unit Tests

## Mocks vs Stubs

1. Implement full unit test coverage for the `PersonLogger` class from `Samples\12_StubVsMock`. In each test make a clear distinction between Stubs and Mocks.

    a. Take into account the GOOD Unit Test properties for each test you write


# The Unit Test Code

## Unit Test Types

1. Refactor the unit test from `Samples\12_StubVsMock` test `PersonLoggerTests.Log_CanLogToFile_MessageLoggedInFile` to be a state test. You should not use the `Moq` library.


# The Threee Pillars of GOOD Unit Tests

1. Refactor all the tests that you have written at I.1. taking into account the *GOOD Unit Tests* properties and the best practices for having *Readable*, *Maintanable* and *Trustworthy* tests.

1. Refactor the tests in `LogAnalyzerTests` from `Samples.UnitTests\Overspecifying2` so it does not