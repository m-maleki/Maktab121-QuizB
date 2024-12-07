using QuizB.Entities;

namespace QuizB.Contracts.Repositories
{
    public interface ICodeVerifyRepository
    {
        public void Add(string code);
        public CodeVerify GetCode();
    }
}
