using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS426.node;

//comment
namespace CS426.analysis
{
    class SemanticAnalyzer : DepthFirstAdapter
    {
        // Symbol Tables
        LinkedList<Dictionary<string, Definition>> _previousSymbolTables = new LinkedList<Dictionary<string, Definition>>();
        Dictionary<string, Definition> _currentSymbolTable = new Dictionary<string, Definition>();  // for main function
        Dictionary<string, Definition> _globalSymbolTable = new Dictionary<string, Definition>();   // for constants
        Dictionary<string, Definition> _functionSymbolTable = new Dictionary<string, Definition>(); // for other functions

        // ParseTree Decoration
        Dictionary<Node, Definition> _decoratedParseTree = new Dictionary<Node, Definition>();

        //List<Dictionary<VariableDefinition, TypeDefinition>> paramList = new List<Dictionary<VariableDefinition, TypeDefinition>>();
        Dictionary<string, Definition> _paramSymbolTable = new Dictionary<string, Definition>();

        public override void InAProgram(AProgram node)
        {
            // Build definitions for allowed types according to grammar. CS246 grammar only allows int, string, and float
            BasicTypeDefinition intType;
            intType = new BasicTypeDefinition();
            intType.name = "int";

            StringTypeDefinition stringType = new StringTypeDefinition();
            stringType.name = "string";

            BasicTypeDefinition floatType = new BasicTypeDefinition();
            floatType.name = "float";

            // Create and seed the symbolTable
            _globalSymbolTable = new Dictionary<string, Definition>();
            _globalSymbolTable.Add("int", intType);
            _globalSymbolTable.Add("string", stringType);
            _globalSymbolTable.Add("float", floatType);
        }

        //DONE
        public override void InAMainProgram(AMainProgram node)
        {
            // Build definitions for allowed types according to grammar. CS246 grammar only allows int, string, and float
            BasicTypeDefinition intType;
            intType = new BasicTypeDefinition();
            intType.name = "int";

            StringTypeDefinition stringType = new StringTypeDefinition();
            stringType.name = "string";

            BasicTypeDefinition floatType = new BasicTypeDefinition();
            floatType.name = "float";

            // Create and seed the symbolTable
            _currentSymbolTable = new Dictionary<string, Definition>();
            _currentSymbolTable.Add("int", intType);
            _currentSymbolTable.Add("string", stringType);
            _currentSymbolTable.Add("float", floatType);
        }

        //DONE
        public override void InAFunctionFunctionDeclaration(AFunctionFunctionDeclaration node)
        {
            // Save current symbol table.
            _previousSymbolTables.AddFirst(_currentSymbolTable);

            // Build definitions for allowed types according to grammar. CS426 only allows int and string and float
            BasicTypeDefinition intType;
            intType = new BasicTypeDefinition();
            intType.name = "int";

            StringTypeDefinition stringType = new StringTypeDefinition();
            stringType.name = "string";

            BasicTypeDefinition floatType;
            floatType = new BasicTypeDefinition();
            floatType.name = "float";            

            // Create and seed the symbol table.
            //_functionSymbolTable = new Dictionary<string, Definition>();
            if (!_functionSymbolTable.ContainsKey("int"))
            {
                _functionSymbolTable.Add("int", intType);
                _functionSymbolTable.Add("string", stringType);
                _functionSymbolTable.Add("float", floatType);
            }
        }

        //DONE
        public override void OutAFunctionFunctionDeclaration(AFunctionFunctionDeclaration node)
        {
            // Restore previous symbol table
            //_functionSymbolTable = _previousSymbolTables.First();
            //_previousSymbolTables.RemoveFirst();

            Definition def;
            
            String methodName = node.GetId().Text;

            // Ensure submethod name isn't used
            if (_functionSymbolTable.TryGetValue(methodName, out def))
            {
                Console.WriteLine("[" + node.GetOpenpar().Line + "] : " + methodName + " is already declared.");

            // Build function definition and add to symbol table 
            }
            else
            {
                def = new MethodDefinition();
                def.name = node.GetId().Text;
                //((MethodDefinition)def).paramList = new List<VariableDefinition>();

                // ToyLanguage doens't allow parameters, so the parameter list will be empty.
                //((MethodDefinition)def).paramList.Clear();

                _functionSymbolTable.Add(methodName, def);
            }
        }

        public override void OutAFormalParameter(AFormalParameter node)
        {
            Definition typeDef, varDef;
            String typeName = node.GetType().Text;
            String varName = node.GetVarName().Text;

            // Check that the type name is defined
            if (!_functionSymbolTable.TryGetValue(typeName, out typeDef))
            {
                Console.WriteLine("[" + node.GetType().Line + "] : " + typeName + " is not defined.");

                // Check that the type name is defined as a type
            }
            else if (!(typeDef is TypeDefinition))
            {
                Console.WriteLine("[" + node.GetType().Line + "] : " + typeName + " is not a valid type.");

            }
            else if (_functionSymbolTable.TryGetValue(varName, out varDef))
            {
                Console.WriteLine("[" + node.GetVarName().Line + "] : " + varName + " is already a parameter.");
            }
            else
            {
                VariableDefinition newDef = new VariableDefinition();
                newDef.name = varName;
                newDef.vartype = (TypeDefinition)typeDef;
                _functionSymbolTable.Add(varName, newDef);

                _paramSymbolTable.Add(varName, newDef);

                //Definition def;
                //def = new MethodDefinition();
                //def.name = varName;

                //((MethodDefinition)def).paramList = new List<VariableDefinition>();
                //((MethodDefinition)def).paramList.Add(newDef);

                //_functionSymbolTable.Add(def.name, def);
            }
        }

        //WORKING - constant declarations need global scope
        public override void OutAConstantConstantDeclaration(AConstantConstantDeclaration node)
        {
            // Checking the declaration portion...

            Definition typeDef, varDef;
            String typeName = node.GetType().Text;
            String varName = node.GetVarName().Text;

            // Check that the type name is defined
            if (!_globalSymbolTable.TryGetValue(typeName, out typeDef))
            {
                Console.WriteLine("[" + node.GetType().Line + "] : " + typeName + " is not defined.");

                // Check that the type name is defined as a type
            }
            else if (!(typeDef is TypeDefinition))
            {
                Console.WriteLine("[" + node.GetType().Line + "] : " + typeName + " is not a valid type.");

                // check that the var name is not defined
            }
            else if (_globalSymbolTable.TryGetValue(varName, out varDef))
            {
                Console.WriteLine("[" + node.GetVarName().Line + "] : " + varName + " is already defined.");

                // Add variable name and definition to symbol table
            }
            else
            {
                VariableDefinition newDef = new VariableDefinition();
                newDef.name = varName;
                newDef.vartype = (TypeDefinition)typeDef;
                _globalSymbolTable.Add(varName, newDef);
            }

            // Checking the assignment portion

            Definition idDef, exprDef;

            // Ensure that ID has been declared
            if (!_globalSymbolTable.TryGetValue(varName, out idDef))
            {
                Console.WriteLine("[" + node.GetVarName().Line + "] : " + varName + " is not defined.");
            }
            // Ensure that addition_expr node has been decorated
            else if (!_decoratedParseTree.TryGetValue(node.GetExpression(), out exprDef))
            {
                Console.WriteLine("[" + node.GetVarName().Line + "] : right hand side was not decorated.");

            // Ensure that addition_expr and ID have the same types
            }
            else if (!exprDef.name.Equals(((VariableDefinition)idDef).vartype.name))
            {
                Console.WriteLine("[" + node.GetType().Line + "] : Invalid assignment. Can not assign " + exprDef.name + " to " +
                    idDef.name + ".");
            }
        }

        //DONE
        public override void OutAAssignmentLine(AAssignmentLine node)
        {
            Definition idDef, addition_exprDef;
            String varName = node.GetId().Text;

            // Ensure variable is not already a constant
            if (_globalSymbolTable.TryGetValue(varName, out idDef))
            {
                Console.WriteLine("[" + node.GetId().Line + "] : " + varName + " is already a constant.");
            }

            // Ensure that ID has been declared
            if (!_currentSymbolTable.TryGetValue(varName, out idDef))
            {
                Console.WriteLine("[" + node.GetId().Line + "] : " + varName + " is not defined.");

                // Ensure that ID is a variable
            }
            else if (!(idDef is VariableDefinition))
            {
                Console.WriteLine("[" + node.GetId().Line + "] : " + varName + " is not a valid variable.");

                // Ensure that addition_expr node has been decorated
            }
            else if (!_decoratedParseTree.TryGetValue(node.GetAdditionExpr(), out addition_exprDef))
            {
                Console.WriteLine("[" + node.GetId().Line + "] : right hand side was not decorated.");

                // Ensure that addition_expr and ID have the same types
            }
            else if (!addition_exprDef.name.Equals(((VariableDefinition)idDef).vartype.name))
            {
                Console.WriteLine("[" + node.GetId().Line + "] : Invalid assignment. Can not assign " + addition_exprDef.name + " to " +
                    idDef.name + ".");

            }
        }

        //DONE
        public override void OutADeclarationLine(ADeclarationLine node)
        {
            Definition typeDef, varDef;
            String typeName = node.GetType().Text;
            String varName = node.GetVarName().Text;

            // Ensure variable is not already a constant
            if (_globalSymbolTable.TryGetValue(varName, out typeDef))
            {
                Console.WriteLine("[" + node.GetType().Line + "] : " + varName + " is already a constant.");
            }

            // Check that the type name is defined
            if (!_currentSymbolTable.TryGetValue(typeName, out typeDef))    // Checking in main program (currentSybmolTable)
            {
                if (!_functionSymbolTable.TryGetValue(typeName, out typeDef))    // Checking in function declaration (functionSybmolTable)
                {
                    Console.WriteLine("[" + node.GetType().Line + "] : " + typeName + " is not defined.");
                }

                // Check that the type name is defined as a type
            }
            else if (!(typeDef is TypeDefinition))
            {
                Console.WriteLine("[" + node.GetType().Line + "] : " + typeName + " is not a valid type.");

                // check that the var name is not defined
            }
            else if (_currentSymbolTable.TryGetValue(varName, out varDef))
            {
                Console.WriteLine("[" + node.GetVarName().Line + "] : " + varName + " is already defined.");

                // Add variable name and definition to symbol table
            }
            else
            {
                VariableDefinition newDef = new VariableDefinition();
                newDef.name = varName;
                newDef.vartype = (TypeDefinition)typeDef;
                _currentSymbolTable.Add(varName, newDef);
            }
        }

        //DONE
        public override void OutAFunctionCallLine(AFunctionCallLine node)
        {
            Definition idDef, exprDef, typeDef, test;
            String funcName = node.GetId().Text;

            String param = node.GetActualParameters().ToString();
            param = param.Substring(0, param.Length - 1);

            //String check = _paramSymbolTable[0].ToString();

            //if (!_currentSymbolTable.TryGetValue(param, out test)) 
            //{
            //    Console.WriteLine("[" + param + "] : " + funcName + " is not defined.");
            //}

            // Ensure that function name has been declared
            if (!_currentSymbolTable.TryGetValue(funcName, out idDef))
            {
                if (!_functionSymbolTable.TryGetValue(funcName, out idDef))
                {
                    Console.WriteLine("[" + node.GetId().Line + "] : " + funcName + " is not defined.");
                }

                // Ensure that ID is a method
            }
            else if (!(idDef is MethodDefinition))
            {
                Console.WriteLine("[" + node.GetId().Line + "] : " + funcName + " is not a method.");

                // Ensure that argument has been decorated
            }

            //if (test.GetType() != _paramSymbolTable)

            //else if (!_decoratedParseTree.TryGetValue(node.GetActualParameters(), out exprDef))
            //{
            //    Console.WriteLine("[" + node.GetId().Line + "] : argument was not decorated.");

                // Ensure that expr is a string or basic type
            //}
            //else if (!_paramSymbolTable.TryGetValue(node.GetActualParameters().GetType(), out typeDef))
            //{
            //    Console.WriteLine("[" + node.GetId().Line + "] : CS426 only allows strings and basic types as arguments.");
            //}
        }

        // swap(x, y, z, a, b);

        // Condition check
        public override void OutACondCondition(ACondCondition node)
        {
            Definition lhs, rhs;

            // Ensure lhs of the plus is decorated
            if (!_decoratedParseTree.TryGetValue(node.GetFirst(), out lhs))
            {
                Console.WriteLine("[" + node.GetOperator() + "] : left hand side of operator was not decorated.");

                // Ensure rhs of the plus is decorated
            }
            else if (!_decoratedParseTree.TryGetValue(node.GetAdditionExpr(), out rhs))
            {
                Console.WriteLine("[" + node.GetOperator() + "] : right hand side of operator was not decorated.");

                // Ensure sides are the same type
            }
            else if (!lhs.name.Equals(rhs.name))
            {
                Console.WriteLine("[" + node.GetOperator() + "] : Type mismatch.  Cannot compare " + lhs.name + " with " +
                    rhs.name + ".");

                // Ensure that lhs and rhs are basic types
            }
            else if (!(lhs is BasicTypeDefinition))
            {
                Console.WriteLine("[" + node.GetOperator() + "] : Invalid Type.  Cannot add " + lhs.name + "s.");

                // Decorate this node
            }
            else
            {
                TypeDefinition currNodeType = new BasicTypeDefinition();
                currNodeType.name = lhs.name;
                _decoratedParseTree.Add(node, currNodeType);
            }
        }

        //DONE
        public override void OutAAddAdditionExpr(AAddAdditionExpr node)
        {
            Definition lhs, rhs;

            // Ensure lhs of the plus is decorated
            if (!_decoratedParseTree.TryGetValue(node.GetAdditionExpr(), out lhs))
            {
                Console.WriteLine("[" + node.GetPlus().Line + "] : left hand side of '+' was not decorated.");

                // Ensure rhs of the plus is decorated
            }
            else if (!_decoratedParseTree.TryGetValue(node.GetMultiExpr(), out rhs))
            {
                Console.WriteLine("[" + node.GetPlus().Line + "] : right hand side of '+' was not decorated.");

                // Ensure sides are the same type
            }
            else if (!lhs.name.Equals(rhs.name))
            {
                Console.WriteLine("[" + node.GetPlus().Line + "] : Type mismatch.  Cannot add " + lhs.name + " to " +
                    rhs.name + ".");

                // Ensure that lhs and rhs are basic types
            }
            else if (!(lhs is BasicTypeDefinition))
            {
                Console.WriteLine("[" + node.GetPlus().Line + "] : Invalid Type.  Cannot add " + lhs.name + "s.");

                // Decorate this node
            }
            else
            {
                TypeDefinition currNodeType = new BasicTypeDefinition();
                currNodeType.name = lhs.name;
                _decoratedParseTree.Add(node, currNodeType);
            }
        }

        //DONE
        public override void OutAPassAdditionExpr(APassAdditionExpr node)
        {
            Definition multiExprDef;

            // Ensure multi_expr node is decorated.
            if (!_decoratedParseTree.TryGetValue(node.GetMultiExpr(), out multiExprDef))
            {
                //  There is no token here, so we can't output an error with meaning.  
                //    However, it will propagate up the parse tree

                // Decorate this node
            }
            else
            {
                _decoratedParseTree.Add(node, multiExprDef);
            }

        }

        //DONE
        public override void OutAMultiMultiExpr(AMultiMultiExpr node)
        {
            Definition lhs, rhs;

            // Ensure lhs of the plus is decorated
            if (!_decoratedParseTree.TryGetValue(node.GetMultiExpr(), out lhs))
            {
                Console.WriteLine("[" + node.GetMult().Line + "] : left hand side of '*' was not decorated.");

                // Ensure rhs of the plus is decorated
            }
            else if (!_decoratedParseTree.TryGetValue(node.GetMultiExpr(), out rhs))
            {
                Console.WriteLine("[" + node.GetMult().Line + "] : right hand side of '*' was not decorated.");

                // Ensure sides are the same type
            }
            else if (!lhs.name.Equals(rhs.name))
            {
                Console.WriteLine("[" + node.GetMult().Line + "] : Type mismatch.  Cannot multiply " + lhs.name + " to " +
                    rhs.name + ".");

                // Ensure that lhs and rhs are basic types
            }
            else if (!(lhs is BasicTypeDefinition))
            {
                Console.WriteLine("[" + node.GetMult().Line + "] : Invalid Type.  Cannot multiply " + lhs.name + "s.");

                // Decorate this node
            }
            else
            {
                TypeDefinition currNodeType = new BasicTypeDefinition();
                currNodeType.name = lhs.name;
                _decoratedParseTree.Add(node, currNodeType);
            }
        }

        //DONE
        public override void OutAPassMultiExpr(APassMultiExpr node)
        {
            Definition operandDef;

            // Ensure expr2 node is decorated.
            if (!_decoratedParseTree.TryGetValue(node.GetOperand(), out operandDef))
            {
                //  There is no token here, so we can't output an error with meaning.  
                //    However, it will propagate up the parse tree

                // Decorate this node
            }
            else
            {
                _decoratedParseTree.Add(node, operandDef);
            }
        }

        //DONE
        public override void OutAIntOperand(AIntOperand node)
        {
            // Decorate this node
            BasicTypeDefinition intDef = new BasicTypeDefinition();
            intDef.name = "int";
            _decoratedParseTree.Add(node, intDef);
        }

        //DONE
        public override void OutAIdOperand(AIdOperand node)
        {

            Definition varDef;
            String varName = node.GetId().Text;

            // check if varname is declared
            if (!_currentSymbolTable.TryGetValue(varName, out varDef))
            {
                Console.WriteLine("[" + node.GetId().Line + "] : " + varName + " is not defined.");

                // check that it is a variable definition
            }
            else if (!(varDef is VariableDefinition))
            {
                Console.WriteLine("[" + node.GetId().Line + "] : " + varName + " is not a valid variable.");

                // decorate this node
            }
            else
            {
                _decoratedParseTree.Add(node, ((VariableDefinition)varDef).vartype);
            }
        }

        //DONE
        public override void OutAFloatOperand(AFloatOperand node)
        {
            // Decorate this node
            BasicTypeDefinition floatDef = new BasicTypeDefinition();
            floatDef.name = "float";
            _decoratedParseTree.Add(node, floatDef);
        }

        // Override functions for constant variables - global scope

        //DONE
        public override void OutAIntExpression(AIntExpression node)
        {
            // Decorate this node
            BasicTypeDefinition intDef = new BasicTypeDefinition();
            intDef.name = "int";
            _decoratedParseTree.Add(node, intDef);
        }

        //DONE
        public override void OutAFloatExpression(AFloatExpression node)
        {
            // Decorate this node
            BasicTypeDefinition floatDef = new BasicTypeDefinition();
            floatDef.name = "float";
            _decoratedParseTree.Add(node, floatDef);
        }

        //DONE
        public override void OutAStringExpression(AStringExpression node)
        {
            // Decorate this node
            BasicTypeDefinition stringDef = new BasicTypeDefinition();
            stringDef.name = "string";
            _decoratedParseTree.Add(node, stringDef);
        }

        // End constant variables section


        //DONE
        public override void CaseEOF(EOF node)
        {
            base.CaseEOF(node);
            Console.WriteLine("Semantic Analyzation complete.");
        }
    }
}


//  Start -> id + start;