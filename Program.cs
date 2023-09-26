bool successParse = false; //Отметка корректного ввода 

const string mistake = "\nНекорректный ввод\nПовторите попытку\n"; 
const int poundsToShilling = 20, shillingsToPennies = 12; //Валюты для преобразования

int CorrectInput(bool isCost)
{
    int allPennies = 0; //Суммарное количество пенсов
    string message = isCost == true ? "сумму" : "количество денег"; //Для различия какое данные сейчас вводятся стоимость или деньги покупателя
    //Считывание данных пока все не будут корректны 
    while (!successParse)
    {
        Console.WriteLine($"----Введите {message}----");

        Console.Write("Фунты: ");
        if (!int.TryParse(Console.ReadLine(), out int pounds))
        {
            Console.WriteLine(mistake);
            continue;
        }

        Console.Write("Шиллинги: ");
        if (!int.TryParse(Console.ReadLine(), out int shillings))
        {
            Console.WriteLine(mistake);
            continue;
        }

        Console.Write("Пенсы: ");
        if (!int.TryParse(Console.ReadLine(), out int pennies))
        {
            Console.WriteLine(mistake);
            continue;
        }

        allPennies += (pounds * poundsToShilling + shillings) * shillingsToPennies; //Преобразование фунтов и шиллингов в пенсы
        allPennies += pennies;
        successParse = true;
    }
    Console.WriteLine($"Итог: {allPennies} пенсов\n");
    return allPennies;
}

int costInPennies = CorrectInput(true); //Преобразование стоимости в пенсы
successParse = false; 
int sumInPennies = CorrectInput(false); //Преобразование денег покупателя



