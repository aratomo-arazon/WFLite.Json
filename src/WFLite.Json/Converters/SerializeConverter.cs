/*
 * SerializeConverter.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using Newtonsoft.Json;
using System;
using WFLite.Interfaces;

namespace WFLite.Json.Converters
{
    public class SerializeConverter : Bases.Converter<string>
    {
        public IOutVariable<Formatting> Formatting
        {
            private get;
            set;
        }

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

        public SerializeConverter()
        {
        }

        public SerializeConverter(
            IOutVariable<Formatting> formatting = null,
            IOutVariable<JsonSerializerSettings> settings = null, 
            IOutVariable<JsonConverter[]> converters = null,
            IOutVariable<Type> type = null)
        {
            Formatting = formatting;
            Settings = settings;
            Converters = converters;
            Type = type;
        }

        protected sealed override string convert(object value)
        {
            if (Type == null)
            {
                if (Formatting == null)
                {
                    if (Settings != null)
                    {
                        return JsonConvert.SerializeObject(value, Settings.GetValue());
                    }
                    else if (Converters != null)
                    {
                        return JsonConvert.SerializeObject(value, Converters.GetValue());
                    }
                    else
                    {
                        return JsonConvert.SerializeObject(value);
                    }
                }
                else
                {
                    if (Settings != null)
                    {
                        return JsonConvert.SerializeObject(value, Formatting.GetValue(), Settings.GetValue());
                    }
                    else if (Converters != null)
                    {
                        return JsonConvert.SerializeObject(value, Formatting.GetValue(), Converters.GetValue());
                    }
                    else
                    {
                        return JsonConvert.SerializeObject(value, Formatting.GetValue());
                    }
                }
            }
            else
            {
                if (Formatting == null)
                {
                    return JsonConvert.SerializeObject(value, Type.GetValue(), Settings.GetValue());
                }
                else
                {
                    return JsonConvert.SerializeObject(value, Type.GetValue(), Formatting.GetValue(), Settings.GetValue());
                }
            }
        }
    }
}
