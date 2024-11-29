using QuizB.Framework;

namespace QuizB.Contracts.Services;
public interface ICardService
{
    Result PasswordIsValid(string cardNumber, string password);
}