using QuizB.Dtos;
using QuizB.Entities;

namespace QuizB.Contracts.Repositories;
public interface ITransactionRepository
{
    List<GetTransactionsDto> GetListOfTransactions(string cardNumber);
    float DailyWithdrawal(string cardNumber);
    void Add(Transaction transaction);
}