using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WFLite.Json.HelloWorld.Entities
{
    public class Message
    {
        [JsonProperty("value")]
        public string Value
        {
            get;
            set;
        }
    }
}
