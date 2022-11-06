using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SHAVERMA2
{
    public class Shavuh1n
    {
        private class Svoistva
        {
            public static Haracteristika lavash = new Haracteristika();
            public static Haracteristika size = new Haracteristika();
            public static Haracteristika spice = new Haracteristika();
            public static Haracteristika pita = new Haracteristika() ;
            public static Haracteristika vegan = new Haracteristika();
            public static Haracteristika colour = new Haracteristika();
        }
        private class Haracteristika
        {
            public string title;
            public int price = 0;
        }
        public class MainParam
        {
            public string title;
            public int sub;
        }
        public static void SubmitOrder()
        {
            string data = DateTime.Now.ToLongDateString();
            Order order = GetOrder();
            File.AppendAllText("C:\\Users\\magal\\Videos\\Desktop\\orders.txt", $"\nЗаказ от {data}\n{order.text}");
            Console.Clear();
            Console.WriteLine("Заказ оформлен\nНажмите Esc чтобы закрыть или Enter чтобы продолжить");
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            Svoistva.lavash = new Haracteristika();
            Svoistva.size = new Haracteristika();
            Svoistva.spice = new Haracteristika();
            Svoistva.pita = new Haracteristika();
            Svoistva.vegan = new Haracteristika();
            Svoistva.colour = new Haracteristika();
        }
        public static List<MainParam> MainMenu()
        {
            return new List<MainParam>() {
                new MainParam() { title = "Лаваш", sub = 1},
                new MainParam() { title = "Размер", sub = 2},
                new MainParam() { title = "Острота", sub = 3},
                new MainParam() { title = "В пите", sub = 4},
                new MainParam() { title = "Веганская" , sub = 5},
                new MainParam() { title = "Цвет лаваша", sub = 6},
                new MainParam() { title = "Заказать шаверму", sub = 7}
            };
        }
        public class SubParam
        {
            public string title;
            public int price;
        }
        public class Order
        {
            public string text;
            public int price;
            public bool valid = true;
        }
        public static Order GetOrder()
        {

            Order order = new Order();
            List<Haracteristika> haracteristiks = new List<Haracteristika>
            {
                Svoistva.lavash,
                Svoistva.size,
                Svoistva.spice,
                Svoistva.pita,
                Svoistva.vegan,
                Svoistva.colour
            };
            foreach (Haracteristika hrk in haracteristiks)
            {
                if (hrk.title != null)
                {
                    order.text += $"{hrk.title} - {hrk.price}\n";
                    order.price += hrk.price;
                }
                else
                {
                    order.valid = false;
                }
            }
            order.text = $"Итоговая цена: {order.price}\n{order.text}";
            return order;
        }
        public static List<SubParam> SubMenu(int prp)
        {
            List<SubParam> response;
            switch (prp)
            {
                case 1:
                    response = new List<SubParam>()
                    {
                        new SubParam() { title = "Стандартный лаваш", price = 50 },
                        new SubParam() { title = "Сырный лаваш", price = 55 }
                    };
                    break;
                case 2:
                    response = new List<SubParam>()
                    {
                        new SubParam() { title = "Большая", price = 300 },
                        new SubParam() { title = "Маленькая", price = 175 },
                        new SubParam() { title = "Субмаринечевская жи есть", price = 10000 }
                    };
                    break;
                case 3:
                    response = new List<SubParam>()
                    {
                        new SubParam() { title = "Не острая", price = 0 },
                        new SubParam() { title = "50% острая", price = 10 },
                        new SubParam() { title = "Типа острый (c) Рома Шавухин", price = 25 }
                    };
                    break;
                case 4:
                    response = new List<SubParam>()
                    {
                        new SubParam() { title = "Да", price = 100 },
                        new SubParam() { title = "Нет", price = 0 }
                    };
                    break;
                case 5:
                    response = new List<SubParam>()
                    {
                        new SubParam() { title = "Кавказская", price = 20 },
                        new SubParam() { title = "Веганская", price = 40 },
                        new SubParam() { title = "Азиатская (Возможно мяуканье)", price = 60 },
                    };
                    break;
                case 6:
                    response = new List<SubParam>()
                    {
                        new SubParam() { title = "Серый", price = 40 },
                        new SubParam() { title = "Серый", price = 40 },
                        new SubParam() { title = "Синий", price = 40 },
                        new SubParam() { title = "Белый", price = 0 },
                        new SubParam() { title = "Чёрный", price = 40 },
                    };
                    break;
                default:
                    response = new List<SubParam>();
                    break;
            }
            return response;
        }
        public static void ChangeProperty(int prp, string title, int price)
        {
            switch (prp)
            {
                case 1:
                    Svoistva.lavash = new Haracteristika() { title = title, price = price };
                    break;
                case 2:
                    Svoistva.size = new Haracteristika() { title = title, price = price };
                    break;
                case 3:
                    Svoistva.spice = new Haracteristika() { title = title, price = price };
                    break;
                case 4:
                    Svoistva.pita = new Haracteristika() { title = title, price = price };
                    break;
                case 5:
                    Svoistva.vegan = new Haracteristika() { title = title, price = price };
                    break;
                case 6:
                    Svoistva.colour = new Haracteristika() { title = title, price = price };
                    break;
            }
        }
    }
}
