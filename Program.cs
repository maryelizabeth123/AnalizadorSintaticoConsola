using Microsoft.VisualBasic;
using System;

namespace AnalisisSintaticoConsola
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\n*********************************");
            Console.WriteLine("\n**    ANALIZADOR SINTÁNTICO    **");
            Console.WriteLine("\n** MARY ELIZABETH PEÑA PAULINO **");
            Console.WriteLine("\n*********************************");
            Console.WriteLine("\nDIGITE UNA EXPRESION: ");

            string expresion = Console.ReadLine();
        
            string[] exp = new string[Strings.Len(expresion) + 1];
            int x = 0;
            int y = 0;
            int z = 1;

            foreach (char myChar in expresion)
             {
                if (myChar.Equals('+')| myChar.Equals('-') | myChar.Equals('/') | myChar.Equals('*') | myChar.Equals('=') | myChar.Equals('^'))
                {
                    exp[x] = "op";

                }
                else if (myChar.Equals('a') | myChar.Equals('b') | myChar.Equals('c') | myChar.Equals('d') | myChar.Equals('e') | myChar.Equals('f') | myChar.Equals('g') | myChar.Equals('h') | myChar.Equals('x') | myChar.Equals('y') | myChar.Equals('k') | myChar.Equals('l'))
                {
                    exp[x] = "exp";
                }
                else if (myChar.Equals('1') | myChar.Equals('2') | myChar.Equals('3') | myChar.Equals('4') | myChar.Equals('5') | myChar.Equals('6') | myChar.Equals('7') | myChar.Equals('8') | myChar.Equals('9'))
                {
                    exp[x] = "num";
                }
                else if (myChar.Equals('"'))
                {
                    exp[x] = "par_d";
                }
                else if (myChar.Equals('"'))
                {
                    exp[x] = "par_iz";
                }
            }

            foreach(char myChar in expresion)
            {
                if (myChar.Equals('a') | myChar.Equals('b') | myChar.Equals('c') | myChar.Equals('d') | myChar.Equals('e') | myChar.Equals('f') | myChar.Equals('g') | myChar.Equals('h') | myChar.Equals('x') | myChar.Equals('y') | myChar.Equals('k') | myChar.Equals('l'))
                {
                    z = z + 1;
                }
            }

            y = 0;
            z = 1;

            foreach (char myChar in expresion)
            {
                if (myChar.Equals('a') | myChar.Equals('b') | myChar.Equals('c') | myChar.Equals('d') | myChar.Equals('e') | myChar.Equals('f') | myChar.Equals('g') | myChar.Equals('h') | myChar.Equals('x') | myChar.Equals('y') | myChar.Equals('k') | myChar.Equals('l'))
                {
                    z = z + 1;
                }
            }

            Console.WriteLine(" ");
            int parentisis = 0;
            int comprobacion = 1;
            int e = 0;

             foreach(char myChar in expresion)
            {
                if (x == 0)
                {
                    if (myChar.Equals('('))
                        parentisis = parentisis + 1;
                    else if (myChar.Equals('+') | myChar.Equals('*') | myChar.Equals('/') | myChar.Equals('^') | myChar.Equals('='))
                    {
                        comprobacion = 0;
                    }
                }
                else
                    switch (exp[x])
                    {
                        case "exp":
                            {
                                if (expresion[x - 1].Equals("(") || exp[x - 1] == "op")
                                {
                                }
                                else
                                {
                                    comprobacion = 0;
                                }

                                break;
                            }

                        case "num":
                            {
                                if (expresion[x - 1].Equals("(") || exp[x - 1] == "op")
                                {
                                }
                                else
                                {
                                    Console.WriteLine("\nERROR! CARACTER: " + x + " :");
                                    Console.WriteLine("\nNo se dos expresiones seguidas");
                                    comprobacion = 0;
                                }

                                break;
                            }

                        case "op":
                            {
                                if (exp[x - 1] == "par_d" | expresion[x - 1].Equals("="))
                                {
                                    if (myChar.Equals('-'))
                                    {
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nERROR! CARACTER: " + x + " :");
                                        Console.WriteLine("\nNo puede colocar el operador " + expresion[x] + " luego de " + expresion[x - 1]);
                                        comprobacion = 0;
                                    }
                                }
                                else if (exp[x - 1] == "exp" | exp[x - 1] == "num")
                                {
                                }
                                else if (expresion[x - 1].Equals(')'))
                                {
                                }
                                else
                                {
                                    Console.WriteLine("\nERROR! CARACTER: " + x + " :");
                                    Console.WriteLine("\nNo puede colocarse un operador luego de otro");
                                    comprobacion = 0;
                                }

                                break;
                            }

                        case "par_d":
                            {
                                parentisis = parentisis + 1;


                                if (expresion[x - 1].Equals("(") || exp[x - 1] == "op")
                                {
                                }
                                else
                                {
                                    Console.WriteLine("\nERROR! CARACTER: " + x + " :");
                                    Console.WriteLine("\nLos parentesis están colocando al revez");
                                    comprobacion = 0;
                                }

                                break;
                            }

                        case "par_iz":
                            {
                                e = e + 1;
                                if (exp[x - 1] == "exp" | exp[x - 1] == "num")
                                {
                                }
                                else if (exp[x - 1] == "par_iz")
                                {
                                }
                                else
                                {
                                    if (exp[x - 1] == "op")
                                    {
                                        Console.WriteLine("\nERROR! CARACTER: " + x + " :");
                                        Console.WriteLine("\nDebe de cerrar el parentesis antes del operador");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nERROR! CARACTER: " + x + " :");
                                        Console.WriteLine("\nDebe existir un contenido dentro de los parentesis");
                                    }
                                    comprobacion = 0;
                                }

                                break;
                            }
                    }
            }

            if (comprobacion == 1)
                Console.WriteLine("\nLA EXPRESIÓN NO TIENE ERRORES\n");
    
            if (comprobacion == 1)
            {
                if (e == parentisis)
                    Console.WriteLine("\nLA EXPRESION CORRECTA");
                else
                    Console.WriteLine("\nREQUIERE UN PARENTESIS");
            }
            else
               Console.WriteLine("\nERROR EN LA EXPRESION");
            
        }
    }
}
