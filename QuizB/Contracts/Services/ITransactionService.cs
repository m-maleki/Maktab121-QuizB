using QuizB.Dtos;

namespace QuizB.Contracts.Services;
public interface ITransactionService
{
    string TransferMoney(string sourceCardNumber, string destinationCardNumber, float amount);
    List<GetTransactionsDto> GetListOfTransactions(string cardNumber);
}