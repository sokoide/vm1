// How to assmeble:
// cd /Users/sokoide/repo/sokoide-compiler/vm1
// dotnet run -p vm1-assembler vm1-assembler/bin/Debug/netcoreapp2.1/vm1-assembler.dll -s vm1-assembler/Sample1.asm -o Sample1.bc
// 
// Dump:
// hexdump -C Sample1.bc
// 
// How to run:
// dotnet run -p vm1-console vm1-console/bin/Debug/netcoreapp2.1/vm1-console.dll -s Sample1.bc 
 
iconst 40
iconst 2
iadd
print
halt
