# README.md

## Projects

### Project Summary

* vm1-lib: .NET standard lib which has all common implementations
   * Core part of the stack machine
* vm1-test: xUnit test project for vm1-lib
   * CTRL-R CTRL-A to execute all tests in Visual Studio
* vm1-assembler: Read assembler source and output bytecode
* vm1-console: Common console runner
   * Not implemented yet

### vm1-asembler

* Read source code and output bytecode as below
```bash
source file: Sample.asm
// any line starts with '//' is a comment
iconst 1
print // '//' works in the middle of lines
iconst 2
print
iconst 3
print
iconst 40
iconst 2
iadd
print
halt


output file (bytecode): Sample.bc
09 00 00 00 01 00 00 00  0E 00 00 00 09 00 00 00 
02 00 00 00 0E 00 00 00  09 00 00 00 03 00 00 00 
0E 00 00 00 09 00 00 00  28 00 00 00 09 00 00 00 
02 00 00 00 01 00 00 00  0E 00 00 00 12 00 00 00 
```

* Sample usage

```bash
dotnet vm1-assembler\bin\Debug\netcoreapp2.1\vm1-assembler.dll -s vm1-assembler\Sample.asm -o Sample.bc
```

### vm1-console

* Read byte code (generated by vm1-assembler) and run it on the stack machine (VM)
* Sample usage

```bash
dotnet vm1-console\bin\Debug\netcoreapp2.1\vm1-console.dll -s Sample.bc -t true
```

## Note

* Buildable/executable on both MacOS/VisualStudio for Mac and Windows/VisualStudio for Win