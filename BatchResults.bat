:::::::::::::::::::::::::::::
:: This is the LEXDRIVER it runs the test cases for my language from CS426
::
:: use double :'s for a line comment
:: use > to create and redirect output to a file
:: use >> to append output to a file
:::::::::::::::::::::::::::::

:: Run good test cases
echo C1C Mikey Baldinger and C1C Caden Kulp's 426 Semantic Analyzer > results.txt
echo Running Correct Test Cases >> results.txt
echo. >> results.txt

echo Testing a while control structure >> results.txt
bin\Debug\ConsoleApplication.exe tests\While.txt >> results.txt
echo. >> results.txt

echo ----------------------------------- >> results.txt

echo Running Failure Test Cases >> Results.txt
echo. >> results.txt

echo y x; – fails if x already declared >> results.txt
bin\Debug\ConsoleApplication.exe tests\Fail1.txt >> results.txt
echo. >> results.txt

echo y x; – fails if y is not declared >> results.txt
bin\Debug\ConsoleApplication.exe tests\Fail2.txt >> results.txt
echo. >> results.txt

echo y x; – fails if y is declared, but not a type >> results.txt
bin\Debug\ConsoleApplication.exe tests\Fail3.txt >> results.txt
echo. >> results.txt

echo final y x:z; - fails if x already declared >> results.txt
bin\Debug\ConsoleApplication.exe tests\Fail4.txt >> results.txt
echo. >> results.txt

echo final y x:z; - fails if y is not declared >> results.txt
bin\Debug\ConsoleApplication.exe tests\Fail5.txt >> results.txt
echo. >> results.txt

echo final y x=z; - fails if y is declared, but not a type >> results.txt
bin\Debug\ConsoleApplication.exe tests\Fail6.txt >> results.txt
echo. >> results.txt

echo final y x:z; - fails if types of y, z don’t match >> results.txt
bin\Debug\ConsoleApplication.exe tests\Fail7.txt >> results.txt
echo. >> results.txt

echo arithmatic fail when types don’t match >> results.txt
bin\Debug\ConsoleApplication.exe tests\Fail12.txt >> results.txt
echo. >> results.txt

echo arithmatic fail when types aren’t integer or float >> results.txt
bin\Debug\ConsoleApplication.exe tests\Fail13.txt >> results.txt
echo. >> results.txt

echo Assignment: x:y fails when x is not declared >> results.txt
bin\Debug\ConsoleApplication.exe tests\Fail18.txt >> results.txt
echo. >> results.txt

echo Assignment: x:y fails when x is declared, but not a variable >> results.txt
bin\Debug\ConsoleApplication.exe tests\Fail19.txt >> results.txt
echo. >> results.txt

echo Assignment: x:y fails when x is constant >> results.txt
bin\Debug\ConsoleApplication.exe tests\Fail20.txt >> results.txt
echo. >> results.txt

echo Assignment: x:y fails when types don’t match >> results.txt
bin\Debug\ConsoleApplication.exe tests\Fail21.txt >> results.txt
echo. >> results.txt

echo Procedures: reports failure when procedure name already used >> results.txt
bin\Debug\ConsoleApplication.exe tests\Fail22.txt >> results.txt
echo. >> results.txt

echo Procedures: reports failure when formal parameter declared incorrectly (e.g. x x) >> results.txt
bin\Debug\ConsoleApplication.exe tests\Fail23.txt >> results.txt
echo. >> results.txt

echo Procedures: reports failure when formal parameter declared twice (e.g. int x, int x) >> results.txt
bin\Debug\ConsoleApplication.exe tests\Fail24.txt >> results.txt
echo. >> results.txt

echo x(y,z) : reports failure when x is not declared >> results.txt
bin\Debug\ConsoleApplication.exe tests\Fail25.txt >> results.txt
echo. >> results.txt

echo x(y,z) : reports failure when x is declared, but not a procedure >> results.txt
bin\Debug\ConsoleApplication.exe tests\Fail26.txt >> results.txt
echo. >> results.txt




