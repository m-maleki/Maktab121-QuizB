using QuizB.Entities;
using QuizB.Contracts.Repositories;

namespace QuizB.DAL.Repositories;
public class CardRepository : ICardRepository
{
    #region Fields

    private readonly AppDbContext _dbContext;

    #endregion

    #region Ctor
    public CardRepository()
    {
        _dbContext = new AppDbContext();
    }

    #endregion

    #region Implementations

    public bool PasswordIsValid(string cardNumber, string password)
        => _dbContext.Cards.Any(x => x.CardNumber == cardNumber && x.Password == password);

    public bool CardIsActive(string cardNumber)
        => _dbContext.Cards.Any(x => x.CardNumber == cardNumber && x.IsActive);

    public Card GetCardBy(string cardNumber)
    {
        var card = _dbContext.Cards.FirstOrDefault(x => x.CardNumber == cardNumber);

        if (card is null)
        {
            throw new Exception($"Card with number {cardNumber} not found");
        }
        else
        {
            return card;
        }

    }

    public void ClearWrongPasswordTry(string cardNumber)
    {
        var card = _dbContext.Cards
            .FirstOrDefault(x => x.CardNumber == cardNumber);

        if (card is null)
        {
            throw new Exception($"cannot found card with number {cardNumber}");
        }

        card.WrongPasswordTries = 0;
        _dbContext.SaveChanges();
    }

    public void Withdraw(string cardNumber, float amount)
    {
        var card = _dbContext.Cards
            .FirstOrDefault(x => x.CardNumber == cardNumber);

        if (card is null)
        {
            throw new Exception($"cannot found card with number {cardNumber}");
        }

        card.Balance -= amount;
        _dbContext.SaveChanges();
    }

    public void Deposit(string cardNumber, float amount)
    {
        var card = _dbContext.Cards
            .FirstOrDefault(x => x.CardNumber == cardNumber);

        if (card is null)
        {
            throw new Exception($"cannot found card with number {cardNumber}");
        }

        card.Balance += amount;
        _dbContext.SaveChanges();
    }

    public void SetWrongPasswordTry(string cardNumber)
    {
        var card = _dbContext.Cards
            .FirstOrDefault(x => x.CardNumber == cardNumber);

        if (card is null)
        {
            throw new Exception($"cannot found card with number {cardNumber}");
        }

        card.WrongPasswordTries++;
        _dbContext.SaveChanges();
    }

    public int GetWrongPasswordTry(string cardNumber)
    {
        var card = _dbContext.Cards
            .FirstOrDefault(x => x.CardNumber == cardNumber);

        if (card is null)
        {
            throw new Exception($"cannot found card with number {cardNumber}");
        }

        return card.WrongPasswordTries;
    }

    #endregion
}