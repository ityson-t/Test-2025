using System;

namespace Week1_Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write($"1、C To F\n2、F To C\n请选择：");
            
            while (true)
            {
                string userSelect = Console.ReadLine();
                if (int.TryParse(userSelect, out int select) && (select == 1 || select == 2))
                {
                    while (true)
                    {
                        Console.Write($"请输入温度：");
                        string temperature = Console.ReadLine();
                        switch (select)
                        {
                            case 1:
                                if (double.TryParse(temperature, out double temp))
                                {
                                    Console.WriteLine($"{temp:f1}摄氏度={temp * 9 / 5 + 32:f1}华氏度。");
                                    return;
                                }
                                else
                                {
                                    Console.Write($"输入错误：");
                                    break;
                                }
                            case 2:
                                if (double.TryParse(temperature, out temp))
                                {
                                    Console.WriteLine($"{temp:f1}华氏度={(temp - 32) * 5 / 9:f1}摄氏度。");
                                    return;
                                }
                                else
                                {
                                    Console.Write($"输入错误：");
                                    break;
                                }
                            default:
                                break;
                        }

                    }
                }
                else
                {
                    Console.Write($"选择错误，请重新选择：");
                }
                }
                        
            }
            
        }
    }

