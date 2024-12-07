using QuizB.Contracts.Repositories;
using QuizB.Contracts.Services;
using QuizB.DAL.Repositories;

namespace QuizB.Services
{
    public class CodeVerifyService : ICodeVerifyService
    {
        private readonly ICodeVerifyRepository _codeVerifyRepository;

        public CodeVerifyService()
        {
            _codeVerifyRepository = new CodeVerifyRepository();
        }
        public void GenerateCode()
        {
            Random random = new Random();
            var result = Convert.ToString(random.Next(random.Next(10000, 99999)));
            _codeVerifyRepository.Add(result);
        }
    }
}
