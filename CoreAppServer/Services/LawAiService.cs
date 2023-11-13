using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace API.Services
{
    public interface ILawAIService
    {
        Task<bool> SaveChat(int userId);
        Task<List<AIChatsDto>> GetChats(int userId);
    }
    public class LawAIService : ILawAIService
    {
        private readonly DataContext _context;
        private static readonly string _lawAPIUrl = "http://localhost:8001/api/v1/law-ai";

        public LawAIService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<AIChatsDto>> GetChats(int userId)
        {
            var chats = await _context.LawChat
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .Select(x => x.Messages)
                .ToListAsync();

            var dtoOfDtos = new List<AIChatsDto>();

            foreach (var chat in chats)
            {
                 dtoOfDtos.Add(JsonSerializer.Deserialize<AIChatsDto>(chat));
            }

            var outcome = new List<AIChatsDto>();

            dtoOfDtos.ForEach(res =>
            {
                res?.Response?.ForEach(message =>
                {
                    if (!string.IsNullOrEmpty(message?.Content))
                    {
                        outcome.Add(res);
                    }
                });
            });

            return outcome;
        }
        public async Task<bool> SaveChat(int userId)
        {
            try
            {
                 var messagesString = await GetAllMessagesFromCurrentContext();

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
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return null;
            }
        }

    }
}
