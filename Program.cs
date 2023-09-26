bool successParse = false; //Отметка корректного ввода 

const string mistake = "\nНекорректный ввод\nПовторите попытку\n"; 
const int poundsToShilling = 20, shillingsToPennies = 12; //Валюты для преобразования
int poundsToPennies = poundsToShilling * shillingsToPennies;

const string poundsStr = "Фунты", shillingsStr = "Шиллинги", penniesStr = "Пенсы";

uint CorrectInput(bool isCost)
{
    uint allPennies = 0; //Суммарное количество пенсов
    string message = isCost == true ? "стоимость" : "количество денег"; //Для различия какие данные сейчас вводятся стоимость или деньги покупателя
    //Считывание данных пока все не будут корректны 
    while (!successParse)
    {
        Console.WriteLine($"---- Введите {message} ----");

        Console.Write($"{poundsStr}: ");
        if (!uint.TryParse(Console.ReadLine(), out uint pounds))
        {
            Console.WriteLine(mistake);
            continue;
        }

        Console.Write($"{shillingsStr}: ");
        if (!uint.TryParse(Console.ReadLine(), out uint shillings))
        {
            Console.WriteLine(mistake);
            continue;
        }

        Console.Write($"{penniesStr}: ");
        if (!uint.TryParse(Console.ReadLine(), out uint pennies))
        {
            Console.WriteLine(mistake);
            continue;
        }

        allPennies = (uint)(pounds * poundsToPennies + shillings * shillingsToPennies + pennies); //Преобразование фунтов и шиллингов в пенсы
        successParse = true;
    }
    Console.WriteLine($"Итог: {allPennies} пенсов\n");
    return allPennies;
}

uint costInPennies = CorrectInput(true); //Преобразование стоимости в пенсы
successParse = false; 
uint sumInPennies = CorrectInput(false); //Преобразование денег покупателя

if (costInPennies == sumInPennies)
    Console.WriteLine("Нет сдачи");
else if (costInPennies > sumInPennies)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Ошибка");
    Console.ResetColor();
}
else
{
    Console.WriteLine("---- Сдача ----");
    //Преобразование валюты 
    uint changeInPennies = sumInPennies - costInPennies;
    uint changePounds = (uint)(changeInPennies / poundsToPennies),
        changeShilling = (uint)(changeInPennies % poundsToPennies) / shillingsToPennies,
        changePennies = (uint)(changeInPennies % poundsToPennies % shillingsToPennies);
    //Вывод сдачи
    if (changePounds > 0) Console.WriteLine($"{poundsStr}: {changePounds}");
    if (changeShilling > 0) Console.WriteLine($"{shillingsStr}: {changeShilling}");
    if (changePennies > 0) Console.WriteLine($"{penniesStr}: {changePennies}");
}

