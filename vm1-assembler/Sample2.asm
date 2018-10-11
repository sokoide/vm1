// pseudo code ---
// foo(42)
// foo(5)
// exit
// func foo(a) {
//   print a+1
// } 

// call FUNC with 1 argument (42)
iconst 42
call FUNC: 1

// call FUNC with 1 argument (5)
iconst 5
call FUNC: 1

// end of the program
halt

// FUNC
FUNC:

// get an argument from SP-3 and push it into stack
// SP-3 = func argument
// SP-2 = num arguments
// SP-1 = old frame pointer (save)
// SP = return address (IP)
load -3

// push 1
iconst 1

// add arg+1
iadd

// pop and print result (arg+1)
print
ret
