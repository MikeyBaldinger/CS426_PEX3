:: SableCC Batch File

java -jar "C:\Users\C21Caden.Kulp\CS426\sablecc-3-beta.3.altgen.20041114\lib\sablecc.jar" -t csharp,csharp-build simple.grammar
pause
del test_parser.cs
del test_lexer.cs