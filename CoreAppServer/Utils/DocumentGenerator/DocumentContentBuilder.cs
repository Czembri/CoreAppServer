using API.DTOs;
using System.Text;

namespace API.Utils.DocumentGenerator
{
    public static class DocumentContentBuilder
    {
        public static string BuildDocumentContent(DocumentInfoDto dto)
        {
            var sb = new StringBuilder();

            foreach (var property in typeof(DocumentInfoDto).GetProperties())
            {
                var value = property.GetValue(dto);
                var name = property.Name;

                if (value != null && !object.Equals(value, GetDefault(property.PropertyType)))
                {
                    if (name == "Date")
                    {
                        var date = ((DateTime?)value).HasValue ? ((DateTime?)value).Value.Date : DateTime.UtcNow.Date;
                        sb.AppendLine($"Data sporządzenia dokumentu: {date}");
                    }
                    else
                    {
                        sb.AppendLine($"{GetDisplayName(name)}: {value}");
                    }
                }
            }

            return sb.ToString();
        }

        private static object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }

        private static string GetDisplayName(string propertyName)
        {
            var displayNameMap = new Dictionary<string, string>
        {
            { "Title", "Tytuł dokumentu" },
            { "Content", "Zawartość dokumentu" },
            { "City", "Miejsce gdzie został sporządzony dokument" },
            { "Recipient", "Adresat" },
            { "RecipientAddress", "Adres adresata" },
            { "RecipientPhone", "Telefon adresata" },
            { "Sender", "Nadawca" },
            { "SenderAddress", "Adres nadawcy" },
            { "SenderPhone", "Telefon nadawcy" },
            { "Header", "Nagłówek" },
            { "Footer", "Stopka" },
            { "Type", "Typ dokumentu" },
            { "Scale", "Skala" }
        };

            return displayNameMap.TryGetValue(propertyName, out var displayName) ? displayName : propertyName;
        }
    }

}
