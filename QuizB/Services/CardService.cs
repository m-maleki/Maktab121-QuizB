using QuizB.Framework;
using QuizB.DAL.Repositories;
using QuizB.Contracts.Services;
using QuizB.Contracts.Repositories;

namespace QuizB.Services;
public class CardService : ICardService
{
    #region Fileds

    private readonly ICardRepository _cardRepository;

    #endregion

    #region Ctor
    public CardService()
    {
        _cardRepository = new CardRepository();
    }
    #endregion

    #region Implementations
    public Result PasswordIsValid(string cardNumber, string password)
    {
        var tryCount = _cardRepository.GetWrongPasswordTry(cardNumber);

        if (tryCount > 3)
            return new Result() { IsSuccess = false, Message = "You have entered the wrong password 3 times. Your account is permanently blocked" };

        var passwordIsValid = _cardRepository.PasswordIsValid(cardNumber, password);

        if (passwordIsValid == false)
        {
            _cardRepository.SetWrongPasswordTry(cardNumber);
            return new Result() { IsSuccess = false, Message = "Card number Or Password Is Wrong" };
        }
        else
        {
            _cardRepository.ClearWrongPasswordTry(cardNumber);
            return new Result() { IsSuccess = true, Message = "Welcome" };
        }
    }
    #endregion
}