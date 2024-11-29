using QuizB.DAL;
using QuizB.Dtos;
using ConsoleTables;
using QuizB.Services;
using QuizB.Framework;
using QuizB.Contracts.Services;

ICardService cardService = new CardService();
ITransactionService transactionService = new TransactionService();
AppDbContext appDbContext = new AppDbContext();

appDbContext.Database.EnsureCreated();

Result passwordValidationResult;
string cardNumber;

do
{
    Console.Clear();

    Console.Write("CardNumber : ");
    cardNumber = Console.ReadLine();

    Console.Write("Password : ");
    var password = Console.ReadLine();

    passwordValidationResult = cardService.PasswordIsValid(cardNumber, password);

    Console.WriteLine(passwordValidationResult.Message);
    Console.ReadKey();

} while (!passwordValidationResult.IsSuccess);

while (true)
{
    Console.Clear();

    Console.WriteLine("1.Transfer Money");
    Console.WriteLine("2.Show Transactions");

    var selectedItem = Console.ReadKey();

    Console.Clear();

    var sourceCardNumber = cardNumber;
    Console.WriteLine($"Source CardNumber Is {cardNumber} ");
    Console.WriteLine();

    switch (selectedItem.KeyChar)
    {
        case '1':
            {
                TransferMoney(sourceCardNumber);
                break;
            }
        case '2':
            {
                ShowListOfTransactions();
                break;
            }
    }
}

void TransferMoney(string sourceCardNumber)
{
    Console.Write("Please Insert Destination CardNumber : ");
    var destinationCardNumber = Console.ReadLine();

    Console.Write("Amount : ");
    var amount = float.Parse(Console.ReadLine() ?? string.Empty);

    var transactionStatus = transactionService.TransferMoney(sourceCardNumber, destinationCardNumber, amount);

    Console.WriteLine(transactionStatus);

    Console.ReadKey();
}
void ShowListOfTransactions()
{
    var transactions = transactionService.GetListOfTransactions(cardNumber);

    ConsoleTable
        .From<GetTransactionsDto>(transactions)
        .Configure(o => o.NumberAlignment = Alignment.Right)
        .Write(Format.Minimal);

    Console.ReadKey();
}
