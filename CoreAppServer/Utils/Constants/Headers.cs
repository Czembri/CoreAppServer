﻿using API.DTOs;
using Newtonsoft.Json;

namespace API.Utils.Constants
{
    public static class Headers
    {
        public static readonly string SecretHeader;
        public static readonly string AnotherProperty;
        static Headers()
        {
            try
            {
                //string json = File.ReadAllText("../Config/Headers.json"); // may not work
                //HeadersConfigurationDto config = JsonConvert.DeserializeObject<HeadersConfigurationDto>(json);

                SecretHeader = "secret";
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message, "Headers.json file not found");
                throw;
            }
        }
    }
}
