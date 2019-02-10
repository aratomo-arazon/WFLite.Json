/*
 * DeserializeConverter.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using WFLite.Interfaces;

namespace WFLite.Json.Converters
{
    public class DeserializeConverter : Bases.Converter<object>
    {
        public IOutVariable<JsonSerializerSettings> Settings
        {
            private get;
            set;
        }

        public IOutVariable<JsonConverter[]> Converters
        {
            private get;
            set;
        }

        public IOutVariable<Type> Type
        {
            private get;
            set;
        }

        public IOutVariable<JsonSerializer> Serializer
        {
            private get;
            set;
        }

        public DeserializeConverter()
        {
        }

        public DeserializeConverter(
            IOutVariable<JsonSerializerSettings> settings = null,
            IOutVariable<JsonConverter[]> converters = null,
            IOutVariable<Type> type = null,
            IOutVariable<JsonSerializer> serializer = null)
        {
            Settings = settings;
            Converters = converters;
            Type = type;
            Serializer = serializer;
        }

        protected sealed override object convert(object value)
        {
            if (value is JToken)
            {
                if (Serializer == null)
                {
                    return (value as JToken).ToObject(Type.GetValue());
                }
                else
                {
                    return (value as JToken).ToObject(Type.GetValue(), Serializer.GetValue());
                }
            }
            else
            {
                if (Type == null)
                {
                    if (Settings != null)
                    {
                        return JsonConvert.DeserializeObject(System.Convert.ToString(value), Settings.GetValue());
                    }
                    else
                    {
                        return JsonConvert.DeserializeObject(System.Convert.ToString(value));
                    }
                }
                else
                {
                    if (Settings != null)
                    {
                        return JsonConvert.DeserializeObject(System.Convert.ToString(value), Type.GetValue(), Settings.GetValue());
                    }
                    else if (Converters != null)
                    {
                        return JsonConvert.DeserializeObject(System.Convert.ToString(value), Type.GetValue(), Converters.GetValue());
                    }
                    else
                    {
                        return JsonConvert.DeserializeObject(System.Convert.ToString(value), Type.GetValue());
                    }
                }
            }
        }
    }

    public class DeserializeConverter<TOutValue> : Bases.Converter<TOutValue>
    {
        public IOutVariable<JsonSerializerSettings> Settings
        {
            private get;
            set;
        }

        public IOutVariable<JsonConverter[]> Converters
        {
            private get;
            set;
        }

        public IOutVariable<JsonSerializer> Serializer
        {
            private get;
            set;
        }

        public DeserializeConverter()
        {
        }

        public DeserializeConverter(
            IOutVariable<JsonSerializerSettings> settings = null,
            IOutVariable<JsonConverter[]> converters = null,
            IOutVariable<JsonSerializer> serializer = null)
        {
        }

        protected sealed override TOutValue convert(object value)
        {
            if (value is JToken)
            {
                if (Serializer == null)
                {
                    return (value as JToken).ToObject<TOutValue>();
                }
                else
                {
                    return (value as JToken).ToObject<TOutValue>(Serializer.GetValue());
                }
            }
            else
            {
                if (Settings != null)
                {
                    return JsonConvert.DeserializeObject<TOutValue>(System.Convert.ToString(value), Settings.GetValue());
                }
                else if (Converters != null)
                {
                    return JsonConvert.DeserializeObject<TOutValue>(System.Convert.ToString(value), Converters.GetValue());
                }
                else
                {
                    return JsonConvert.DeserializeObject<TOutValue>(System.Convert.ToString(value));
                }
            }
        }
    }
}
