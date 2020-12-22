using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Банк_Выдача_кредита
{
    class bank:person
    {        
        public string bank_name; //Название банка
        public int bank_money; //Деньги банка
        public byte bank_percent; //% годовых
       
         public  bank(string bn, int bm, byte bp) //Конструктор банка
        {
            bank_name = bn;
            bank_money = bm;
            bank_percent = bp;
        }

         public void bank_info()
         {
             Console.WriteLine("НАЗВАНИЕ БАНКА: {0}, ДЕНЬГИ БАНКА: {1} бел.руб., ГОДОВЫЕ: {2} %", bank_name, bank_money, bank_percent);
         }

         public int give_money(int a, int b) //Метод дать кредит (a-СРОК b-СУММА)
         {
             bank_money = bank_money - b;
             return b;
         }

         public int vozvrat_money(int a, int b) //Метод вернуть кредит (a-СРОК b-СУММА)
         {
             double summa = b;
             double all=b;
             double percent = bank_percent;
             percent = percent / 100;
             for (int i=0; i < a; i++) //цикл с параметром, вычисление суммы возврата в зависимости от срока кредита
             {
                 summa = summa * percent;
                 all = summa + all; 
                 summa = all;
             } 
             bank_money = bank_money +Convert.ToInt32(summa);
             Console.WriteLine("\nВЕРНУЛИ КРЕДИТ НА СУММУ: " + summa + " бел.руб.");
             return a; 
         }
    }

    class person
    {
        public int person_money_kredit; //Желаемая сумма кредита
        public int person_money; //Деньги человека
        public byte person_srok; //Срок кредита
        public string person_name; //Имя человека
        public byte person_age; //Сколько лет человеку
        public int person_zarplata; //среднемесячная зарплата человека
        public byte person_stazh; //Стаж рабботы человека
        public string person_kredit; //имеется ли текущий кредит
        public string person_history; //кредитная история
        public string person_rabota;    //Вы работаете?

        public void person_info()
        {
            Console.WriteLine("ВАШИ ДЕНЬГИ: {0} бел.руб., СУМММА КРЕДИТА: {1} бел.руб., СРОК КРЕДИТА: {2} год(а)", person_money, person_money_kredit , person_srok);
        }

        public void give_money2() //Метод дать кредит
        {
            person_money = person_money + person_money_kredit;
            
        }
        public int vozvrat_money2(int a, int b, int c,double d) //Метод вернуть кредит a-срок, b-сумма, d-проценты
        {
            double summa = b;
            double all = b;
            double percent = d;
            percent = percent / 100;
            for (int i = 0; i < a; i++)
            {
                summa = summa * percent;
                all = summa + all;
                summa = all;
            }
            person_money = person_money - Convert.ToInt32(summa);
            return a;
        }
    }

    class Program
    {
        static void Main()
        {
            int percent2=0; //переменная % годовых
            person vasya = new person();    //Экземпляр класса 
            bank belarusbank = new bank("Беларусбанк", 1000000, 10); //Экземпляр класса 

            try
            {
                Console.Write("Ваше имя: ");
                vasya.person_name = Console.ReadLine();
                
                Console.Write("Ваш возраст (от 1 до 100) : ");
                vasya.person_age = Convert.ToByte(Console.ReadLine());

                Console.Write("Вы работаете? (ДА или НЕТ): ");
                vasya.person_rabota = Console.ReadLine();

                if (vasya.person_rabota == "да")
                {
                    Console.Write("Ваша среднемесячная зарплата (в бел.руб.): ");
                    vasya.person_zarplata = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Стаж работы (в годах): ");
                    vasya.person_stazh = Convert.ToByte(Console.ReadLine());
                }
                else
                {
                    vasya.person_rabota = "нет";
                }
                

                Console.Write("Имеется ли текущий кредит (ДА или НЕТ): ");
                vasya.person_kredit = Console.ReadLine();

                Console.Write("Кредитная история (ХОРОШАЯ или ПЛОХАЯ): ");
                vasya.person_history = Console.ReadLine();

                Console.Write("ВАШИ ДЕНЬГИ (в бел.руб.): ");
                int dengi = Convert.ToInt32(Console.ReadLine());

                Console.Write("СУММА КРЕДИТА (в бел.руб.): ");
                int summa = Convert.ToInt32(Console.ReadLine());
                
                Console.Write("СРОК КРЕДИТА (в годах): ");
                int srok = Convert.ToInt32(Console.ReadLine());
            
            vasya.person_money = dengi;
            vasya.person_money_kredit = summa;
            vasya.person_srok = Convert.ToByte(srok);

            Console.WriteLine();
            belarusbank.bank_info(); //Выводим данные о банке и человеке
            vasya.person_info();
           
            Console.WriteLine();
                int age=vasya.person_srok+vasya.person_age;
            if (age>=85)
            {
                Console.WriteLine(vasya.person_name + " ,ваш кредит на сумму " + vasya.person_money_kredit + " бел.руб. ОТКЛОНЕН. Срок+лет>=85");
            }



            if (vasya.person_age < 18)
            {
                Console.WriteLine(vasya.person_name + " ,ваш кредит на сумму " + vasya.person_money_kredit + " бел.руб. ОТКЛОНЕН. Вам нет 18 лет");
            }
            switch (vasya.person_rabota)
            {
                case "да":
                    {
                        
                        if (vasya.person_zarplata < 300)
                        {
                            Console.WriteLine( vasya.person_name+ " ,ваш кредит на сумму " + vasya.person_money_kredit + " бел.руб. ОТКЛОНЕН. Ваша среднемесячная зарплата меньше 300 бел. руб.");
                        }

                        if (vasya.person_stazh < 1)
                        {
                            Console.WriteLine(vasya.person_name + " ,ваш кредит на сумму " + vasya.person_money_kredit + " бел.руб. ОТКЛОНЕН. Ваш стаж менее 1 года");
                        }
                    }
                    break;
                case "нет":
                    {
                        Console.WriteLine(vasya.person_name + " ,ваш кредит на сумму " + vasya.person_money_kredit + " бел.руб. ОТКЛОНЕН. Вы не где не работаете");
                    }
                    break;
            }
            switch (vasya.person_kredit)
            {
                case "да":
                    {
                        Console.WriteLine(vasya.person_name + " ,ваш кредит на сумму " + vasya.person_money_kredit + " бел.руб. ОТКЛОНЕН. У вас уже имеется кредит");
                    }
                    break;
            }

            switch (vasya.person_history)
                {
                case "плохая":
                    {
                        Console.WriteLine(vasya.person_name + " ,ваш кредит на сумму " + vasya.person_money_kredit + " бел.руб. ОТКЛОНЕН. У вас плохая кредитная история");
                    }
                    break;
                }

            if (vasya.person_money_kredit > belarusbank.bank_money)
            {
                Console.WriteLine(vasya.person_name + " ,ваш кредит на сумму " + vasya.person_money_kredit + " бел.руб. ОТКЛОНЕН. У банка недостаточно денег");
            }

            if (vasya.person_age >= 18 & vasya.person_zarplata >= 300 & vasya.person_stazh >= 1 & vasya.person_kredit == "нет" & vasya.person_history == "хорошая" & vasya.person_money_kredit <= belarusbank.bank_money & vasya.person_rabota == "да" & age <= 85)
            {

                Console.WriteLine(vasya.person_name + " ,ваш кредит на сумму " + vasya.person_money_kredit + " бел.руб. ОДОБРЕН!!\n");
                Console.WriteLine("\nДАЛИ КРЕДИТ НА СУММУ: " + summa + " бел.руб."); //Даем кредит
                vasya.give_money2();
                belarusbank.give_money(srok, summa);
                belarusbank.bank_info();
                vasya.person_info();

                percent2 = belarusbank.bank_percent;    //Возврат кредита
                belarusbank.vozvrat_money(srok, summa);
                vasya.vozvrat_money2(srok, summa, dengi, percent2);

                belarusbank.bank_info(); //Выводим данные о банке и человеке
                vasya.person_info();
            }
           }
            catch
            {
                Console.WriteLine("Ошибка. Данные введены не верно!");
            }
            Console.ReadKey();
        }
    }
}
