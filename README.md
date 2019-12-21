# README.md

## Projects

### Project Summary

* vm1-lib: .NET standard lib which has all common implementations
  * Core part of the stack machine
* vm1-test: xUnit test project for vm1-lib
  * CTRL-R CTRL-A to execute all tests in Visual Studio
* vm1-assembler: Read assembler source and output bytecode
* vm1-console: Bytecode runner which runs a specified bytecode on VM

### vm1-assembler

* Read source code and output bytecode as below

```cs
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

```cmd
dotnet run --project vm1-assembler -s vm1-assembler/Sample.asm -o Sample.bc
```

* Labels and label jump/label call are supported

```cs
// labels (FUNC:) are supported
iconst 42
call FUNC: 1
halt
FUNC:
load -3
print
ret
```

### vm1-console

* Read byte code (generated by vm1-assembler) and run it on the stack machine (VM)
* Sample usage

```cmd
dotnet run --project vm1-console -s Sample.bc -t true
```

## Calling Convention

* When you call a function, push arguments and call 'call' with the number of args
* For example, calling ADD(a, b) is as below.
* The call pushes nargs, fp and return adddress(ip) before jumping to the ADD function

```
iconst 42
// stack
// 0: 42

iconst 3
// stack
// 1: 3
// 0: 42

call ADD: 2
halt
ADD:
// stack
// 4: 7 <- return address = sp = fp
// 3: 0 <-old fp
// 2: 2 <-nargs
// 1: 3 <-2nd arg
// 0: 42 <-1st arg

load -4
// 1st arg (fp-4) is pushed
// stack
// 5: 42 <- local variable 1st arg = sp
// 4: 7 <- return address = fp
// 3: 0 <-old fp
// 2: 2 <-nargs
// 1: 3 <-2nd arg
// 0: 42 <-1st arg

load -3
// 2nd arg (fp-3) is pushed
// stack
// 6: 3 <- local variable 2nd arg = sp
// 5: 42 <- local variable 1st arg
// 4: 7 <- return address = fp
// 3: 0 <-old fp
// 2: 2 <-nargs
// 1: 3 <-2nd arg
// 0: 42 <-1st arg

iadd
// add 2 stack top variables and store the result on top
// stack
// 5: 45 <- 42+3
// 4: 7 <- return address = fp
// 3: 0 <-old fp
// 2: 2 <-nargs
// 1: 3 <-2nd arg
// 0: 42 <-1st arg

print
// pop and print stack top 45
// stack
// 4: 7 <- return address = fp
// 3: 0 <-old fp
// 2: 2 <-nargs
// 1: 3 <-2nd arg
// 0: 42 <-1st arg

ret
// restore old fp, unwind stack and return to ip
// stack (empty)
```

## Note

* Buildable/executable on both MacOS/VisualStudio for Mac and Windows/VisualStudio for Win
