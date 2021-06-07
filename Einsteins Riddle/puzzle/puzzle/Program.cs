using System;
using System.Collections.Generic;

namespace puzzle
{
    class Program
    {
        enum Colors { Blue = 1, Green, Red, White, Yellow };
    enum Nationalities { Brit = 1, Dane, German, Norwegian, Swede };
    enum Drinks { Beer = 1, Coffee, Milk, Tea, Water };
    enum Cigarettes { Blends = 1, Blue_Master, Dunhill, Pall_Mall, Prince };
    enum Pets { Bird = 1, Cats, Dogs, Horses, Fish };
        static void Main(string[] args)
        {
            DateTime begin = DateTime.Now;
            string positions = "1,2,3,4,5"; // the number of colors in this puzzle are 5
            string[] combs = Combinations(positions);
            int solutions = 0;
            for (int nat = 0; nat < combs.Length; nat++)
            {

                //if (Check_Requirement(10, combs[nat]))
                {
                   

                    for (int col = 0; col < combs.Length; col++)
                    {

                        if ((Check_Requirement(2, combs[nat], combs[col]) == true) &&
                           (Check_Requirement(6, combs[nat], combs[col]) == true) &&
                            (Check_Requirement(15, combs[nat], combs[col]) == true))
                        {
                            for (int dri = 0; dri < combs.Length; dri++)
                            {
                                if ((Check_Requirement(4, combs[nat], combs[col], combs[dri]) == true) &&
                                (Check_Requirement(9, combs[nat], combs[col], combs[dri]) == true) &&
                                (Check_Requirement(5, combs[nat], combs[col], combs[dri]) == true))

                                    for (int cig = 0; cig < combs.Length; cig++)
                                    {
                                        if ((Check_Requirement(8, combs[nat], combs[col], combs[dri], combs[cig]) == true) &&
                                           (Check_Requirement(13, combs[nat], combs[col], combs[dri], combs[cig]) == true) &&
                                          (Check_Requirement(14, combs[nat], combs[col], combs[dri], combs[cig]) == true))
                                        {

                                            for (int pet = 0; pet < combs.Length; pet++)
                                            {

                                                if ((Check_Requirement(3, combs[nat], combs[col], combs[dri], combs[cig], combs[pet]) == true) &&
                                                   (Check_Requirement(7, combs[nat], combs[col], combs[dri], combs[cig], combs[pet]) == true) &&
                                                    (Check_Requirement(11, combs[nat], combs[col], combs[dri], combs[cig], combs[pet]) == true) &&
                                                    (Check_Requirement(12, combs[nat], combs[col], combs[dri], combs[cig], combs[pet]) == true))
                                                {
                                                    solutions = solutions + 1;
                                                    Display_Results(solutions, combs[nat], combs[col], combs[dri], combs[cig], combs[pet]);
                                                }
                                            }
                                        }

                                    }


                            }
                        }

                    }


                }
            }
            DateTime end = DateTime.Now;
            double diff = (end - begin).TotalMilliseconds;

            bool Check_Requirement(int number, string col, string nat = "", string dri = "", string cig = "", string pet = "")
            {
                switch (number)
                {
                    case 2://  The Brit lives in the Red house.
                        if (nat.Substring(col.IndexOf(((int)Colors.Red).ToString()), 1) == ((int)Nationalities.Brit).ToString())
                        {
                            return true;
                
                            }
                        break;
                    case 3:
                        if (nat.Substring(pet.IndexOf(((int)Pets.Dogs).ToString()), 1) == ((int)Nationalities.Swede).ToString())
                        {
                            return true;
                        }
                        break;


                    case 4://  The owner of the green house drinks coffee.
                        if (dri.Substring(col.IndexOf(((int)Colors.Green).ToString()), 1) == ((int)Drinks.Coffee).ToString())
                        {
                            return true;
                        }
                        break;
                    case 5://  The Dane drinks tea.
                        if (dri.Substring(nat.IndexOf(((int)Nationalities.Dane).ToString()), 1) == ((int)Drinks.Tea).ToString())
                        {
                            return true;
                        }
                        break;
                    case 6://The Green house is exactly to the left of the White house.
                        if (col.IndexOf(((int)Colors.Green).ToString()) - col.IndexOf(((int)Colors.White).ToString()) == 1)

                        {
                            return true;
                        }
                        break;
                    case 7:// The person who smokes Pall Mall rears Birds.
                        if (cig.Substring(pet.IndexOf(((int)Pets.Bird).ToString()), 1) == ((int)Cigarettes.Pall_Mall).ToString())
                        {
                            return true;
                        }
                        break;
                    case 8://The owner of the Yellow house smokes Dunhill.
                        if (cig.Substring(col.IndexOf(((int)Colors.Yellow).ToString()), 1) == ((int)Cigarettes.Dunhill).ToString())
                        {
                            return true;
                        }
                        break;

                    case 9://The man living in the centre house drinks Milk.
                        if (dri.Substring(2, 1) == ((int)Drinks.Milk).ToString())
                        {
                            return true;
                        }
                        break;
                    case 10://The Norwegian lives in the first house
                        if (nat.Substring(0,1) == ((int)Nationalities.Norwegian).ToString())
                        {
                            return true;
                        }
                        break;



                    case 11://The man who smokes Blends lives next to the one who keeps Cats.
                        if (Math.Abs(cig.IndexOf(((int)Cigarettes.Blends).ToString()) - pet.IndexOf(((int)Pets.Cats).ToString())) == 1)
                        {
                            return true;
                        }
                        break;
                    case 12://The man who keeps Horses lives next to the man who smokes Dunhill.
                        if (Math.Abs(pet.IndexOf(((int)Pets.Horses).ToString()) - cig.IndexOf(((int)Cigarettes.Dunhill).ToString())) == 1)
                        {
                            return true;
                        }
                        break;
                    case 13://The man who smokes Blue Master drinks Beer.
                        if (cig.Substring(dri.IndexOf(((int)Drinks.Beer).ToString()), 1) == ((int)Cigarettes.Blue_Master).ToString())
                        {
                            return true;
                        }
                        break;
                    case 14://The German smokes Prince.
                        if (cig.Substring(nat.IndexOf(((int)Nationalities.German).ToString()), 1) == ((int)Cigarettes.Prince).ToString())
                        {
                            return true;
                        }
                        break;
                    case 15://The Norwegian lives next to the Blue house.
                        if (Math.Abs(col.IndexOf(((int)Colors.Blue).ToString()) - nat.IndexOf(((int)Nationalities.Norwegian).ToString())) == 1)
                        {
                            return true;
                        }
                        break;
                    default:
                        break;

                }
                return false;
            }
            void Display_Results(int solution, string nationalities, string colors, string drinks, string cigarettes, string pets)
            {
                Console.WriteLine("EINSTEEN SOLN" + solution.ToString());
                Console.WriteLine("SUCCESS");
               Console.Write(string.Format("{0  , -1}  | ", "Structures"));
                Console.Write(string.Format("{0  , -6}  | ", "COLOR"));
                Console.Write(string.Format("{0  , -11}  | ", "NATIONALITY"));
                Console.Write(string.Format("{0  , -12}  | ", "DRINK"));
                Console.Write(string.Format("{0  , -12}  | ", "SMOKE"));
                Console.Write(string.Format("{0  , -6}  | ", "PET"));
                Console.WriteLine();


                for (int com = 0; com < colors.Length; com++)
                {
                    Console.Write(string.Format("{0  , -1}  | ", (com + 1)));
                    Console.Write(string.Format("{0  , -6}  | ", ((Colors)Convert.ToInt32(colors.Substring(com, 1))).ToString()));
                    Console.Write(string.Format("{0  , -11}  | ", ((Nationalities)Convert.ToInt32(nationalities.Substring(com, 1))).ToString()));
                    Console.Write(string.Format("{0  , -12}  | ", ((Drinks)Convert.ToInt32(drinks.Substring(com, 1))).ToString()));
                    Console.Write(string.Format("{0  , -12}  | ", ((Cigarettes)Convert.ToInt32(cigarettes.Substring(com, 1))).ToString()));
                    Console.Write(string.Format("{0  , -6}  | ", ((Pets)Convert.ToInt32(pets.Substring(com, 1))).ToString()));
                    Console.WriteLine();
                }

                Console.WriteLine();

            }
            string[] Combinations(string positions)
            {
                List<string> combs = new List<string>();
                for (int com = 0; com < positions.Length; com++)
                {
                    string single = positions.Substring(com, 1);
                    if (combs.Count == 0)
                    {
                        combs.Add(single);
                    }
                    else
                    {
                        List<string> newcombs = new List<string>();
                        for (int current = 0; current < combs.Count; current++)
                        {
                            for (int post = 0; post < combs[current].Length; post++)
                            {
                                newcombs.Add(combs[current].Substring(0, post) + single + combs[current].Substring(post));
                            }
                            newcombs.Add(combs[current] + single);
                        }

                        combs = newcombs;
                    }

                }
                return combs.ToArray();
            }

        }
    }
}

