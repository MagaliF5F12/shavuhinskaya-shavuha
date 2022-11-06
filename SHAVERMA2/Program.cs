using System.Reflection;

namespace SHAVERMA2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int SUBMENU = 0, pos = 1;
            string cursor = "|:^) ";

            while (true)
            {
                int max_pos = 0;
                Console.Clear();
                Console.WriteLine("Шаурмешная \"JI EST!\"");
                if (SUBMENU == 0)
                {
                    foreach (Shavuh1n.MainParam param in Shavuh1n.MainMenu())
                    {
                        Console.WriteLine("     " + param.title);
                        max_pos += 1;
                    }
                }
                else
                {
                    foreach (Shavuh1n.SubParam param in Shavuh1n.SubMenu(SUBMENU))
                    {
                        Console.WriteLine("     " + param.title + " - " + param.price);
                        max_pos += 1;
                    }
                }
                Console.WriteLine("\n**********************************************************************************************************************");
                Console.WriteLine(Shavuh1n.GetOrder().text);
                Console.SetCursorPosition(0, pos);
                Console.Write(cursor);
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        if (pos != max_pos)
                        {
                            pos++;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (pos != 1)
                        {
                            pos--;
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (SUBMENU == 0)
                        {
                            if (pos == 7)
                            {
                                if (Shavuh1n.GetOrder().valid == false)
                                {
                                    pos = 1;
                                }
                                else
                                {
                                    Shavuh1n.SubmitOrder();
                                    pos = 1;
                                }
                            }
                            else
                            {
                                SUBMENU = pos;
                                pos = 1;
                            }
                        }
                        else
                        {
                            List<Shavuh1n.SubParam> subs = Shavuh1n.SubMenu(SUBMENU);
                            Shavuh1n.ChangeProperty(SUBMENU, subs[pos-1].title, subs[pos-1].price);
                            pos = SUBMENU;
                            SUBMENU = 0;
                        }
                        break;
                }
            }
        }
    }
}