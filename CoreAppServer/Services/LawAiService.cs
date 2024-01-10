using API.Data;
using API.DTOs;
using API.Entities;
using API.Utils.Constants;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace API.Services
{
    public interface ILawAIService
    {
        Task<bool> SaveChat(int userId, int? id);
        Task<List<AIChatsDto>> GetChats(int userId);
        Task<AIChatsDto> GetChat(int chatId);
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
                .Select(x => new { x.Id, x.Messages, x.CreationDate })
                .ToDictionaryAsync(x => x.Id);

            var dtoOfDtos = new List<AIChatsDto>();
            var output = new List<AIChatsDto>();

            foreach (var chat in chats)
            {
                var deserialized = JsonConvert.DeserializeObject<AIChatsDto>(chat.Value.Messages);
                deserialized.Id = chat.Key;
                deserialized.CreationDate = chat.Value.CreationDate;
                dtoOfDtos.Add(deserialized);
            }

            foreach (var dto in dtoOfDtos)
            {
                if (dto.Response.Count > 1)
                    output.Add(dto);
            }

            return output;
        }

        public async Task<AIChatsDto> GetChat(int chatId)
        {
            var chat = await _context.LawChat
                .AsNoTracking()
                .Where(x => x.Id == chatId)
                .FirstOrDefaultAsync();

            if (chat == null) return null;

            var deserializedChat = JsonConvert.DeserializeObject<AIChatsDto>(chat.Messages);

            if (deserializedChat == null) return null;

            deserializedChat.Id = chat.Id;

            return deserializedChat;
        }
        public async Task<bool> SaveChat(int userId, int? id)
        {
            try
            {

                var messagesString = await GetAllMessagesFromCurrentContext();
                if (id.HasValue)
                {
                    var chat = await _context.LawChat
                        .Where(x => x.Id == id)
                        .FirstOrDefaultAsync();
                    chat.Messages = messagesString;
                } 
                else
                {

                    var map = new LawChat
                    {
                        Messages = messagesString,
                        UserId = userId,
                        CreationDate = DateTime.Now
                    };

                    _context.LawChat.Add(map);
                }
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
            using var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, _lawAPIUrl + "/get-messages");
            request.Headers.Add("X-App-Key", Headers.SecretHeader);

            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

    }
}
