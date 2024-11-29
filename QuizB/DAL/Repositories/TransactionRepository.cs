using QuizB.Dtos;
using QuizB.Entities;
using QuizB.Contracts.Repositories;

namespace QuizB.DAL.Repositories;
public class TransactionRepository : ITransactionRepository
{
    #region Fields

    private readonly AppDbContext _appDbContext;

    #endregion

    #region Ctor
    public TransactionRepository()
    {
        _appDbContext = new AppDbContext();
    }
    #endregion

    #region Implementations
    public void Add(Transaction transaction)
    {
        _appDbContext.Transactions.Add(transaction);
        _appDbContext.SaveChanges();
    }

    public List<GetTransactionsDto> GetListOfTransactions(string cardNumber)
    {
        return _appDbContext.Transactions
            .Where(x => x.SourceCard.CardNumber == cardNumber || x.DestinationCard.CardNumber == cardNumber)
            .Select(x=> new GetTransactionsDto
            {
                SourceCardNumber = x.SourceCard.CardNumber,
                DestinationsCardNumber = x.DestinationCard.CardNumber,
                ActionAt = x.ActionAt,
                Amount = x.Amount,
                IsSuccess = x.IsSuccess,
            }).ToList();
    }

    public float DailyWithdrawal(string cardNumber)
    {
        var amountOfTransactions = _appDbContext.Transactions
            .Where(x => x.ActionAt.Date == DateTime.Now.Date && x.SourceCard.CardNumber == cardNumber)
            .Sum(x => x.Amount);

        return amountOfTransactions;
    }
    #endregion
}