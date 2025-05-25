namespace PullCourse.Service;

public class TableMenu
{
    public static string[] Items = ["Ввести курс валют", "Изменить курс валют", "Показать таблицу изменений", "Выход"];
    
    public static void RenderChoiseMenu(int index)
    {
        for (int i = 0; i < Items.Length; i++)
        {
            if (i == index)
            {
                Console.ForegroundColor = ConsoleColor.Green;   
                Console.BackgroundColor = ConsoleColor.Red;
            }
            Console.WriteLine($"{i+1}) {Items[i]}");
            Console.ResetColor();
        }
    }

    public void ChoiseСurrency()
    {
        Console.WriteLine(" ----- Вы попали в таблицу (Ввод валют) ----- ");
        
        Console.WriteLine(" <<<<<< 1) Внести курс валюты (USD):  ");
        Console.WriteLine(" <<<<<< 2) Внести курс валюты (EUR):  ");
        Console.WriteLine(" <<<<<< 3) Внести курс валюты (GBP):  ");
        Console.WriteLine(" <<<<<< 4) Внести курс валюты (CNY):  ");
        
        Console.WriteLine(" ------ 5) Вернуться на главную");
       
    }
    public void ChoiseChange()
    {
        Console.WriteLine(" ----- Вы попали в таблицу (Изменить валюту) ----- ");
        
        Console.WriteLine(" <<<<<< 1) Изменить курс валюты (USD):  ");
        Console.WriteLine(" <<<<<< 2) Изменить курс валюты (EUR):  ");
        Console.WriteLine(" <<<<<< 3) Изменить курс валюты (GBP):  ");
        Console.WriteLine(" <<<<<< 4) Изменить курс валюты (CNY):  ");
        
        Console.WriteLine(" ------ 5) Вернуться на главную");
    }
    public void ChoiseShowTableChanges()
    {
        Console.WriteLine("1) Показать всю статистику");
        Console.WriteLine("2) Показать нынешний курс валют");
        Console.WriteLine("3) Показать таблицу с изменениями");
        Console.WriteLine(" ------ 4) Вернуться на главную");
    }
    
    
}