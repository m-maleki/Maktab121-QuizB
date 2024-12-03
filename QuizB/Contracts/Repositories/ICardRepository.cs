using QuizB.Entities;

namespace QuizB.Contracts.Repositories;
public interface ICardRepository
{
    bool PasswordIsValid(string cardNumber, string password);
    void Withdraw(string cardNumber, float amount);
    void Deposit(string cardNumber, float amount);
    void SetWrongPasswordTry(string cardNumber);
    int GetWrongPasswordTry(string cardNumber);
    bool CardIsActive(string cardNumber);
    Card GetCardBy(string cardNumber);
    void ClearWrongPasswordTry(string cardNumber);
    void SaveChanges();
}