using System;
using System.Collections.Generic;

namespace DrawUMLDiagram
{
        class Program
    {


        class UmlDiagram
        {
            private static int DiagramWidth;
            private static readonly List<string> Infos = new List<string>();
            private static readonly List<int> RowIndexes = new List<int>();

            public void DrawDiagram()
            {
                Row();
                AddInfoInForm("Rectangle");
                Row();
                AddInfoInForm(true,"x:int");
                AddInfoInForm(true,"y:int");
                AddInfoInForm(true,"width:int");
                AddInfoInForm(true,"length:int");
                Row();
                AddInfoInForm(false,"Rectangle()");
                AddInfoInForm(false,"Rectangle(int x,int y,int length,int width)");
                AddInfoInForm(false,"SetX(int x):void");
                AddInfoInForm(false,"SetY(int y):void");
                AddInfoInForm(false,"GetX():int");
                AddInfoInForm(false,"GetY():int");
                AddInfoInForm(false,"GetLength():int");
                AddInfoInForm(false,"GetWidth():int");
                AddInfoInForm(false,"SetWidth(int width):void");
                AddInfoInForm(false,"SetLength(int length):void");
                AddInfoInForm(false,"CalculateArea():int");
                AddInfoInForm(false,"CalculateParimeter():int");
                AddInfoInForm(false,"GetInfo():string");
                Row();
                TidyUp();
                PrintLines(Infos);
            }

            private static void AddInfoInForm(string str)
            {
                if (str.Length > DiagramWidth)
                    DiagramWidth = str.Length;
                Infos.Add(str);
                int maxLength = 0;
                foreach (string s in Infos)
                {
                    if (s.Length > maxLength)
                        maxLength = s.Length;
                }
            }
            
            private static void AddInfoInForm(bool isHidden,string str)
            {
                string result = string.Empty;
                if (isHidden)
                    result += "- ";
                else
                {
                    result += "+ ";
                }

                result += str;
                
                AddInfoInForm(result);

            }

            private static void TidyUp()
            {
                for (int i = 0; i < Infos.Count; i++)
                {
                    if (Infos[i] == " ")
                    {
                        Infos[i] = new string('-', DiagramWidth);
                    }
                }
            }

            private static void PrintLines(IEnumerable<string> list)
            {
                // Calculate the max length
                int maxLength = 0;
                foreach (string s in Infos)
                {
                    if (s.Length > maxLength)
                        maxLength = s.Length;
                }

                foreach (string str in list)
                {
                    int leftBorder = (maxLength - str.Length) / 2;
                    int rightBorder = maxLength - leftBorder - str.Length;
                    Console.Write("|" + new string(' ', leftBorder));
                    Console.Write($"{str}");
                    Console.WriteLine(new string(' ', rightBorder) + "|");
                }
            }
            
            private static void Row()
            {
                Infos.Add(" ");
                RowIndexes.Add(Infos.Count);
            }
        }

        

        static void Main(string[] args)
        {
            UmlDiagram newDiagram = new UmlDiagram();
            newDiagram.DrawDiagram();
            Console.ReadKey();
        }
    }

}