using API.Data;
using API.DTOs;
using API.Entities;

namespace API.Services
{
    public interface ILawAIService
    {
        Task<bool> SaveChat(int userId);
    }
    public class LawAIService : ILawAIService
    {
        private readonly DataContext _context;
        private static readonly string _lawAPIUrl = "http://localhost:8001/api/v1/law-ai";

        public LawAIService(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> SaveChat(int userId)
        {
            try
            {
                var messagesString = await GetAllMessagesFromCurrentContext();
                if (string.IsNullOrEmpty(messagesString))
                    return false;

                var map = new LawChat
                {
                    Messages = messagesString,
                    UserId = userId
                };

                _context.LawChat.Add(map);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        private static async Task<string> GetAllMessagesFromCurrentContext()
        {
            using HttpClient client = new();
            HttpResponseMessage response = await client.GetAsync(_lawAPIUrl + "/get-messages");

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return null;
            }
        }

    }
}
