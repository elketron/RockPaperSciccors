using System;

namespace schaarSteenPapier
{
    class Program
    {
        static int boardSizex = Console.WindowWidth/2;
        static int boardSizey = Console.WindowHeight/2;

        static void Main(string[] args)
        {
            int pointsAI = 0;
            int pointsH = 0;
            int pointDraw = 0;

            //sprites voor de handen
            string Rock = "0   _______0---'  ____)0    (_____)0    (_____)0     (____)0---.__(___)";
            string Paper = "0    _______0---'    ____)____0           ______)0          _______)0         _______)0---.__________)";
            string Siccors = "0    _______0---'   ____)____0          ______)0       __________)0      (____)0---.__(___)";
            //Start the spel

            Console.WriteLine("let's play rock paper siccors! press any key to continue");
            Console.ReadLine();
            Console.Clear();
            System.Console.CursorVisible = false;

            Random num = new Random();

            while (pointsAI != 10 || pointsH != 10)
            {

                System.Console.Write("choose between: Rock (1), Paper (2), Sciccors (3): ");
                int choice = Convert.ToInt32(Console.ReadLine());
                int choiceAI = num.Next(1,4);


                // checks for who the points are
                if (choiceAI == choice) // when a draw occurs
                {
                    if (choice == 1)
                    {
                        DrawShape(Rock, -20 );
                        DrawShape(Rock, 20);
                    }
                    else if (choice == 2)
                    {
                        DrawShape(Paper, -20 );
                        DrawShape(Paper, 20);
                    }
                    else if (choice == 3)
                    {
                        DrawShape(Siccors, -20 );
                        DrawShape(Siccors, 20);
                    }
                    pointDraw++;
                }
                else if (choiceAI == 1 && choice == 2) // AI: Rock, H: Paper 
                {
                    DrawShape(Rock, -20 );
                    DrawShape(Paper, 20);
                    pointsH++;
                }
                else if (choiceAI == 1 && choice == 3) // AI: Rock, H: Sciccors
                {
                    DrawShape(Rock, -20 );
                    DrawShape(Siccors, 20);
                    pointsAI++;   
                }
                else if (choiceAI == 2 && choice == 1) // AI: Paper, H: Rock
                {
                    DrawShape(Paper, -20 );
                    DrawShape(Rock, 20);
                    pointsAI++;
                }
                else if (choiceAI == 2 && choice == 3) // AI: Paper, H: Sciccors
                {
                    DrawShape(Paper, -20 );
                    DrawShape(Siccors, 20);
                    pointsH++;
                }
                else if (choiceAI == 3 && choice == 1) // AI: Sciccors, H: Rock
                {
                    DrawShape(Siccors, -20 );
                    DrawShape(Rock, 20);
                    pointsH++;
                }
                else if (choiceAI == 3 && choice == 2) // AI: Sciccors, H: Paper
                {
                    DrawShape(Siccors, -20 );
                    DrawShape(Paper, 20);
                    pointsAI++;
                }
                //toont de score
                Console.SetCursorPosition(boardSizex - 10,5);
                System.Console.Write(pointsH);
                Console.SetCursorPosition(boardSizex,5);
                System.Console.Write(pointDraw);
                Console.SetCursorPosition(boardSizex + 10,5);
                System.Console.Write(pointsAI);
                
                // wacht 3 seconden en clear het scherm
                System.Threading.Thread.Sleep(3000); 
                
                Console.Clear();


            }
            System.Console.CursorVisible = true;


        }
        //parses over the given string and displays it to the screen
        static void DrawShape(string GetShape, int StartPos){
            int CursorPos  = 1;
            foreach (char I in GetShape)
            {          
                if (Convert.ToInt32(I) == 48) // checks if the string is ascii 0
                {
                    Console.SetCursorPosition(boardSizex + StartPos, (boardSizey - 20) + CursorPos);
                    CursorPos++;
                    continue;
                }
                else
                {
                    Console.Write(I);
                }
            }
        }
    }
}
