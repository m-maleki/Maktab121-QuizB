using QuizB.Dtos;
using QuizB.Entities;
using QuizB.DAL.Repositories;
using QuizB.Contracts.Services;
using QuizB.Contracts.Repositories;

namespace QuizB.Services;
public class TransactionService : ITransactionService
{
    #region Fields
    private readonly ITransactionRepository _transactionRepository;
    private readonly ICardRepository _cardRepository;
    #endregion

    #region Ctor
    public TransactionService()
    {
        _cardRepository = new CardRepository();
        _transactionRepository = new TransactionRepository();
    }
    #endregion

    #region Implementations
    public List<GetTransactionsDto> GetListOfTransactions(string cardNumber)
        => _transactionRepository.GetListOfTransactions(cardNumber);

    public string TransferMoney(string sourceCardNumber, string destinationCardNumber, float amount)
    {
        var isSuccess = false;

        if (amount == 0)
            return "The transfer amount must be greater than 0";

        if (sourceCardNumber.Length < 16 || sourceCardNumber.Length > 16)
            return "sourceCardNumber is not valid";

        if (destinationCardNumber.Length < 16 || destinationCardNumber.Length > 16)
            return "sourceCardNumber is not valid";

        if (!_cardRepository.CardIsActive(sourceCardNumber))
            return "sourceCardNumber is not valid";

        if (!_cardRepository.CardIsActive(destinationCardNumber))
            return "destinationCardNumber is not valid";


        var sourceCard = _cardRepository.GetCardBy(sourceCardNumber);
        var destinationCard = _cardRepository.GetCardBy(destinationCardNumber);

        if (sourceCard.Balance < amount)
            return "your card doesn't have enough balance for this transaction";

        if ((_transactionRepository.DailyWithdrawal(sourceCardNumber) + amount)  > 250)
            return "Your daily transfer limit is full";

        _cardRepository.Withdraw(sourceCardNumber, amount);

        try
        {
            _cardRepository.Deposit(destinationCardNumber, amount);
            isSuccess = true;

        }
        catch (Exception e)
        {
            _cardRepository.Deposit(sourceCardNumber, amount);
            isSuccess = false;
            return "Transfer money failed";
        }
        finally
        {
            var transaction = new Transaction()
            {
                SourceCardId = sourceCard.Id,
                DestinationCardId = destinationCard.Id,
                Amount = amount,
                ActionAt = DateTime.Now,
                IsSuccess = isSuccess
            };

            _transactionRepository.Add(transaction);
        }
        return "The money transfer operation was successful";
    }

    #endregion
}
