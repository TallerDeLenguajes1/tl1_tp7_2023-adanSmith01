using spaceCalc;
// Objeto tipo calculadora
Calculadora calcu = new();

string operadores, num = String.Empty, op_act, op_ant = String.Empty;
operadores = @"+*-/C=O"; // Operadores válidos
double a;
bool prendido = true, cambiarInter = false;

do{
    if(!cambiarInter){
        Console.Write("\nNum: ");
        num = Console.ReadLine();
        Console.Write("Op ( +, -, *, /, C, =, APAGAR(O) ): ");
        op_act = Console.ReadLine();

        if(!double.TryParse(num, out a) || !operadores.Contains(op_act)){
            Console.WriteLine("\nSyntax error\n");
        } else{
            if(op_ant == "/" && a == 0){
                Console.WriteLine("\nERROR. No se puede dividir por cero\n");
                calcu.Limpiar();
                op_ant = String.Empty;
            } else{
                if(String.IsNullOrEmpty(op_ant)){
                    calcu.Sumar(a);
            
                    if(op_act == "*"){
                        calcu.Multiplicar(1);
                    } else{
                        if(op_act == "/"){
                            calcu.Dividir(1);
                        }
                    }

                    op_ant = op_act;
                    
                } else{
                    switch(op_ant){
                        case "+":
                        calcu.Sumar(a);
                        break;
                        case "-":
                        calcu.Restar(a);
                        break;
                        case "*":
                        calcu.Multiplicar(a);
                        break;
                        case "/":
                        calcu.Dividir(a);
                        break;
                    }

                }

                if(op_act == "O"){
                    prendido = false;
                } else{
                    if(op_act == "C" || op_act == "c"){
                        calcu.Limpiar();
                        op_ant = String.Empty;
                    } else{
                        if(op_act == "="){
                            Console.WriteLine($"\nANS: {calcu.Resultado}\n");
                            cambiarInter = true;
                        } else{
                            op_ant = op_act;
                        }
                    }

                }

            }
        }
    } else{
        // Se activa en el caso de mostrar el resultado luego de las operaciones sucesivas
        Console.Write("Op ( +, -, *, /, C, =, APAGAR(O) ): ");
        op_act = Console.ReadLine();

        if(op_act != "=" && op_act != "C" && op_act != "O"){
            Console.Write("\nNum: ");
            num = Console.ReadLine();
            if(!double.TryParse(num, out a) || !operadores.Contains(op_act)){
                Console.WriteLine("\nSyntax error\n");
            } else{
                switch(op_act){
                    case "+":
                    calcu.Sumar(a);
                    break;
                    case "-":
                    calcu.Restar(a);
                    break;
                    case "*":
                    calcu.Multiplicar(a);
                    break;
                    case "/":
                    if(a != 0){
                        calcu.Dividir(a);
                    } else{
                        Console.WriteLine("\nERROR. No se puede dividir por cero\n");
                        calcu.Limpiar();
                        op_ant = String.Empty;
                        cambiarInter = false;
                    }
                    break;
                }
            }

        } else{
            if(op_act == "="){
                Console.WriteLine($"\nANS: {calcu.Resultado}\n");
            } else{
                if(op_act == "C"){
                    calcu.Limpiar();
                    cambiarInter = false;
                    op_ant = String.Empty;
                } else{
                    if(op_act == "O"){
                        prendido = false;
                    }
                }
            }
        }
    }

}while(prendido);

