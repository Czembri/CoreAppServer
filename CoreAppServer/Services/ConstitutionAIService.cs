using API.Data;
using API.DTOs;
using API.Entities;

namespace API.Services
{
    public interface IConstitutionAIService
    {
        Task<bool> SaveChat(ConstitutionChatDTO dto, int userId);
    }
    public class ConstitutionAIService : IConstitutionAIService
    {
        private readonly DataContext _context;
        public ConstitutionAIService(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> SaveChat(ConstitutionChatDTO dto, int userId)
        {
            try
            {
                var map = new ConstitutionChat
                {
                    ResponsesAndQuestions = dto.ResponsesAndQuestions,
                    UserId = userId
                };

                _context.ConstitutionChat.Add(map);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
