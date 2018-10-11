// push 42
iconst 42

// call FUNC with 1 argument (42)
call FUNC: 1
halt

// FUNC
FUNC:

// get an argument from SP-3 and push it into stack
// SP-3 = func argument
// SP-2 = num arguments
// SP-1 = old frame pointer (save)
// SP = return address (IP)
load -3

// push 3
iconst 3

// add 42+3
iadd

// pop and print 45
print
ret
