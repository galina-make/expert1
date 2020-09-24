using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace ASLab1
{
    class Program
    {
        public static UdpClient udpClient;

        private static void SendMessage()
        {
            try
            {
                Console.Write("Введите сообщение:");
                string message = Console.ReadLine(); // сообщение для отправки
                byte[] data = Encoding.Unicode.GetBytes(message);
                // адрес и порт сервера к которому подключаемся
                udpClient.Send(data, data.Length, "127.0.0.1", 8001);//отправка
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ReceiveMessage()
        {
            IPEndPoint remoteIp = (IPEndPoint)udpClient.Client.LocalEndPoint;//адрес вх
            try
            {
                byte[] data = udpClient.Receive(ref remoteIp);//получаем данные
                string message = Encoding.Unicode.GetString(data);
                Console.WriteLine("Ответ от сервера: {0}", message);
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
        }



        static void Main(string[] args)
        {
            udpClient = new UdpClient(8002); // создаем UdpClient
            Console.WriteLine("Клиент работает");

            try
            {
                SendMessage();// Отправляем сообщение
                ReceiveMessage();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); Console.ReadKey();
            }

           
                Console.ForegroundColor = ConsoleColor.Blue;   // меняем цвет чтобы не запутаться в количестве информации
            Console.WriteLine("Вы открыли базу данных стран мира");
            Console.WriteLine("Что вы хотите сделать?");
            Console.ResetColor();

            Console.WriteLine("Полная информация о странах мира (1) "); // вывод
            Console.WriteLine("Вывод записи по номеру строки (2)");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Добавить  данные в базу  (3)"); // запись
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red; //удаление
            Console.WriteLine("Удалить данные из базы (4)");
            Console.ResetColor();

            int choice;
            choice = Int32.Parse(Console.ReadLine());
             switch(choice)
             {
                case 1:
                    Console.WriteLine("Вывод полной информации");
                    using (StreamReader sr = new StreamReader("statefile.csv", Encoding.Default))
                    {
                        Console.WriteLine(sr.ReadToEnd());
                    }

                    break;
                case 2:
                    Console.WriteLine("Вывод записи по номеру строки");
                    Console.WriteLine("Введите номер строки:");
                    int nomer = Convert.ToInt32(Console.ReadLine());

                    StreamReader num = new StreamReader(@"statefile.csv");
                    for (int i = 1; i < nomer; i++)
                    {
                        num.ReadLine();
                    }
                    string str = num.ReadLine();
                    
                    Console.Write(str);
                    Console.ReadKey();

                    break;

                case 3:
                    Console.WriteLine("Добавление данных в базу");
                  

                    using (StreamWriter sw = new StreamWriter("statefile.csv", true, System.Text.Encoding.Default))
                    {
                        char key = 'д';

                        do
                        {
                            State one = new State();
                            Console.Write("\nВведите название государства: ");
                            one.Name += $"{Console.ReadLine()}\t";
                            //sw.Write(one.Name);



                            Console.Write("\nСтолица: ");
                            one.Capital += $"{Console.ReadLine()}\t";
                            //sw.WriteLine(one.Capital);

                            Console.Write("\nЯзык: ");
                            one.Lang += $"{Console.ReadLine()}\t";
                            //sw.WriteLine(one.Lang);

                            Console.Write("\nНаселение: ");
                            one.Num += $"{Console.ReadLine()}\t";
                            //sw.WriteLine(one.Num);

                            try
                            { 
                             Console.Write("\nПлощадь: ");
                             one.S += Int32.Parse($"{Console.ReadLine()}\t");
                             
                            }
                            catch
                            {
                                Console.WriteLine("Упс, кажется вы ввели неверное значение!");
                                Console.Write("\nПлощадь: ");
                                one.S += Int32.Parse($"{Console.ReadLine()}\t");
                            }
                            finally
                            {
                                //sw.WriteLine(one.S);
                            }

                            Console.Write("\nВалюта: ");
                            one.Valute += $"{Console.ReadLine()}\t";
                            //sw.WriteLine(one.Valute);

                            Console.Write("\nКурс валюты страны по отношению к рублю ");
                            one.Ruble += Decimal.Parse($"{Console.ReadLine()}\t");
                            //sw.WriteLine(one.Ruble);

                            Console.Write("\nМировая активность ");
                            one.Activity = bool.Parse($"{Console.ReadLine()}\t");
                            sw.WriteLine(one.Name + ", " + one.Capital + ", " + one.Lang
                            + "," + one.Num + ", " + one.S + ", " + one.Valute + ", " + one.Ruble + ", " +one.Activity );

                            Console.WriteLine("Запись выполнена");

                            Console.Write("Нажмите Д чтобы ввести информацию заново"); key = Console.ReadKey(true).KeyChar;
                        } while (char.ToLower(key) == 'д');

                        Console.ReadKey();
                        sw.Flush();
                        sw.Close();
                    }
                    break;

                case 4:
                    Console.WriteLine("Удаление данных из базы");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Для удаления всех записей из файла нажмите 1");
                    Console.WriteLine("Чтобы удалить одну строчку из файла нажмите 2 ");
                    Console.WriteLine("Удаление диапазона строк - 3 ");
                    Console.ResetColor();
                    int delete=Int32.Parse(Console.ReadLine()); ;
                    switch (delete) // уточняем что конкретно хочет пользователь
                    {
                        case 1:

                            Console.WriteLine("Для удаления всех записей нажмите любую клавишу");

                            using (StreamWriter sw = new StreamWriter("statefile.csv", false, System.Text.Encoding.Default))
                            {
                                sw.WriteLine(" ");

                                Console.ReadKey();
                                sw.Flush();
                                sw.Close();
                            }

                            Console.WriteLine("\tУдаление успешно завершено!");
                            break;

                        case 2:
                            Console.WriteLine("Удаление строки в файле");
                            Console.WriteLine("Введите номер строки:");
                            int numdelete = Convert.ToInt32(Console.ReadLine()); // пользователь вводит номер строки

                            int count = File.ReadAllLines("statefile.csv").Length; //подсчитываем количество строк в файле
                            Console.WriteLine($" количество строк в файле: { count}");
                            string[] array = new string[count]; // начинаем считывать данные из файла в массив

                            Console.WriteLine("Данные после удаления:");
                            
                            using (StreamReader sr = new StreamReader("statefile.csv", Encoding.Default))
                            {
                                for (int i = 0; i < count; i++)
                                {
                                    array[i] = sr.ReadLine();
                                    Array.Clear(array, numdelete, 1);//удаляем нужную строчку 
                                    Console.WriteLine(array[i]); // выводим в консоль оставшиеся данные
                                }

                                sr.Close();
                            }

                            using (StreamWriter sw = new StreamWriter("statefile.csv", false, System.Text.Encoding.Default))// выставляем данные на перезапись
                            {
                                for(int i =0; i<count;i++)
                                {
                                    if(array[i]!=null)
                                    {
                                        sw.WriteLine(array[i]);
                                    }
                                    
                                }
                                
                                
                                sw.Flush();
                                sw.Close();
                            }
                            Console.WriteLine("Данные успешно перезаписаны");

                            Console.ReadKey();

                            break;

                        case 3:
                            Console.WriteLine("Удаление диапазона строк - 3 ");
                            int a, b;
                            Console.WriteLine($"Удалить строки начиная с {a = Convert.ToInt32(Console.ReadLine())} по {b = Convert.ToInt32(Console.ReadLine())}");

                            int c = b - a;

                            int count2 = File.ReadAllLines("statefile.csv").Length; //подсчитываем количество строк в файле

                            string[] array2 = new string[count2]; // начинаем считывать данные из файла в массив

                            Console.WriteLine("Данные после удаления:");

                            using (StreamReader sr = new StreamReader("statefile.csv", Encoding.Default))
                            {
                                for (int i = 0; i < count2; i++)
                                {
                                    array2[i] = sr.ReadLine();

                                    Array.Clear(array2, a, c);
                                    Console.WriteLine(array2[i]); //удаляем нужную строчку и выводим в консоль оставшиеся данные
                                }
                                sr.Close();
                            }

                            using (StreamWriter sw = new StreamWriter("statefile.csv", false, System.Text.Encoding.Default))// выставляем данные на перезапись
                            {
                                for(int i =0;i<count2; i++)
                                {
                                    sw.WriteLine(array2[i]);
                                }
                                

                                sw.Flush();
                                sw.Close();
                            }
                            Console.WriteLine("Данные успешно перезаписаны");

                            Console.ReadKey();


                            break;

                            
                    }
                    
                break;
             }

            Console.ReadKey();

        }
        
    }
}
