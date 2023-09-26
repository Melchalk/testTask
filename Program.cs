int pounds, shillings, pennies;
int sum;
bool successParse = false;
const string mistake = "Некоректный ввод\nПовторите попытку";
while (!successParse)
{
    Console.WriteLine("----Введите сумму----");

    Console.WriteLine("Фунты:");
    if (!int.TryParse(Console.ReadLine(), out pounds))
    {
        Console.WriteLine(mistake);
        continue;
    }
}
