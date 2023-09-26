int pounds, shillings, pennies;
int sum;
bool successParse = false;
const string mistake = "Некоректный ввод\nПовторите попытку\n";
while (!successParse)
{
    Console.WriteLine("----Введите сумму----");

    Console.Write("Фунты: ");
    if (!int.TryParse(Console.ReadLine(), out pounds))
    {
        Console.WriteLine(mistake);
        continue;
    }

    successParse = true;
}
