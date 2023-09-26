bool successParse = false; 

const string mistake = "\nНекоректный ввод\nПовторите попытку\n";
const int poundsToShilling = 20, shillingsToPennies = 12;

int CorrectInput(bool isSum)
{
    int allPennies = 0;
    string message = isSum == true ? "сумму" : "количество денег";

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

        allPennies += (pounds * poundsToShilling + shillings) * shillingsToPennies;
        allPennies += pennies;
        successParse = true;
    }
    Console.WriteLine($"Итог: {allPennies} пенсов\n");
    return allPennies;
}

int costInPennies = CorrectInput(true);
successParse = false;
int sumInPennies = CorrectInput(false); 



