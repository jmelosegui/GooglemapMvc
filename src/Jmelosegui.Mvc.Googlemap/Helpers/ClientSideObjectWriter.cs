using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Jmelosegui.Mvc.Googlemap
{
    public class ClientSideObjectWriter
    {
        private readonly string id;
        private readonly string type;
        private readonly TextWriter writer;
        private bool appended;
        private bool hasStarted;
        private bool writeExplicitObject;

        public ClientSideObjectWriter(string id, string type, TextWriter textWriter)
        {
            if (id == null) throw new ArgumentNullException("id");
            if (type == null) throw new ArgumentNullException("type");
            if (textWriter == null) throw new ArgumentNullException("textWriter");

            this.id = id;
            this.type = type;
            writer = textWriter;
        }

        public virtual ClientSideObjectWriter Start()
        {
            if (hasStarted)
            {
                throw new InvalidOperationException("You cannot call start more than once");
            }
            var selector = @";&,.+*~':""!^$[]()|/".ToCharArray().Aggregate(id, (current, chr) => current.Replace(chr.ToString(), @"\\" + chr));

            writer.Write("jQuery('#{0}').{1}(", selector,type);
            hasStarted = true;

            return this;
        }

        public virtual ClientSideObjectWriter Append(string keyValuePair)
        {
            EnsureStart();

            if (!string.IsNullOrEmpty(keyValuePair))
            {
                if (!writeExplicitObject)
                {
                    writer.Write(appended ? ", " : "{");
                }
                writeExplicitObject = false;
                writer.Write(keyValuePair);

                if (!appended)
                {
                    appended = true;
                }
            }

            return this;
        }

        public virtual ClientSideObjectWriter Append(string name, string value)
        {
            if (name == null) throw new ArgumentNullException("name");

            if (value.HasValue())
            {
                string formattedValue = QuoteString(value);

                Append(String.Format("{0}:'{1}'", name, formattedValue));
            }

            return this;
        }

        public virtual ClientSideObjectWriter AppendNullableString(string name, string value)
        {
            if (name == null) throw new ArgumentNullException("name");

            if (value != null)
            {
                string formattedValue = QuoteString(value);

                Append(String.Format("{0}:'{1}'", name, formattedValue));
            }

            return this;
        }

        public virtual ClientSideObjectWriter Append(string name, int value)
        {
            if (name == null) throw new ArgumentNullException("name");
            Append(String.Format("{0}:{1}", name, value));

            return this;
        }

        public virtual ClientSideObjectWriter Append(string name, int value, int defaultValue)
        {
            if (name == null) throw new ArgumentNullException("name");

            if (value != defaultValue)
            {
                Append(name, value);
            }

            return this;
        }

        public virtual ClientSideObjectWriter Append(string name, int? value)
        {
            if (name == null) throw new ArgumentNullException("name");

            if (value.HasValue)
            {
                Append(name, value.Value);
            }

            return this;
        }

        public virtual ClientSideObjectWriter Append(string name, double value)
        {
            if (name == null) throw new ArgumentNullException("name");

            Append(String.Format("{0}:'{1}'", name, value));

            return this;
        }

        public virtual ClientSideObjectWriter Append(string name, double? value)
        {
            if (name == null) throw new ArgumentNullException("name");

            if (value.HasValue)
            {
                Append(name, value.Value);
            }

            return this;
        }

        public virtual ClientSideObjectWriter Append(string name, decimal value)
        {
            if (name == null) throw new ArgumentNullException("name");

            Append(String.Format("{0}:'{1}'", name, value));

            return this;
        }

        public virtual ClientSideObjectWriter Append(string name, decimal? value)
        {
            if (name == null) throw new ArgumentNullException("name");

            if (value.HasValue)
            {
                Append(name, value.Value);
            }

            return this;
        }

        public virtual ClientSideObjectWriter Append(string name, bool value)
        {
            if (name == null) throw new ArgumentNullException("name");

            Append(String.Format("{0}:{1}", name, value.ToString(CultureInfo.InvariantCulture).ToLower(CultureInfo.InvariantCulture)));

            return this;
        }

        public virtual ClientSideObjectWriter Append(string name, bool value, bool defaultValue)
        {
            if (name == null) throw new ArgumentNullException("name");

            if (value != defaultValue)
            {
                Append(name, value);
            }

            return this;
        }

        public virtual ClientSideObjectWriter Append<TEnum>(string name, TEnum value) where TEnum : IComparable, IFormattable
        {
            if (name == null) throw new ArgumentNullException("name");
            
            var valueAttribute = value.GetType().GetField(value.ToString())
                                                .GetCustomAttributes(true)
                                                .OfType<ClientSideEnumValueAttribute>()
                                                .FirstOrDefault<ClientSideEnumValueAttribute>();

            if (valueAttribute != null)
            {
                Append(String.Format("{0}:{1}", name,valueAttribute.Value));
            }

            return this;
        }

        public virtual ClientSideObjectWriter Append<TEnum>(string name, TEnum value, TEnum defaultValue) where TEnum : IComparable, IFormattable
        {
            if (name == null) throw new ArgumentNullException("name");

            if (!value.Equals(defaultValue))
            {
                Append(name, value);
            }
            return this;
        }

        public virtual ClientSideObjectWriter Append(string name, Action action)
        {
            if (name == null) throw new ArgumentNullException("name");

            if (action != null)
            {
                Append(String.Format("{0}:", name));
                action();
            }

            return this;
        }

        public virtual ClientSideObjectWriter Append(string name, Func<object, object> func)
        {
            if (name == null) throw new ArgumentNullException("name");

            if (func != null)
            {
                object result = func(this);
                if (result != null)
                {
                    Append(String.Format("{0}:{1}", name, result));
                }
            }

            return this;
        }

        public virtual ClientSideObjectWriter AppendCollection(string name, IEnumerable value)
        {
            if (name == null) throw new ArgumentNullException("name");
            
            return Append(String.Format("{0}:{1}", name, JsonConvert.SerializeObject(value, GetJsonSerializerSettings())));
        }

        public virtual ClientSideObjectWriter AppendObject(string name, object value)
        {
            if (name == null) throw new ArgumentNullException("name");

            return Append(String.Format("{0}:{1}", name, JsonConvert.SerializeObject(value, GetJsonSerializerSettings())));
        }

        public virtual ClientSideObjectWriter AppendClientEvent(string name, ClientEvent clientEvent)
        {
            if (name == null) throw new ArgumentNullException("name");

            if (clientEvent.CodeBlock != null)
            {
                Append(name, clientEvent.CodeBlock);
            }
            else
            {
                if (clientEvent.InlineCodeBlock != null)
                {
                    Append(name, clientEvent.InlineCodeBlock);
                }
                else
                {
                    if (clientEvent.HandlerName.HasValue())
                    {
                        Append(String.Format("{0}:{1}", name, clientEvent.HandlerName));
                    }
                }
            }
            return this;
        }

        public virtual ClientSideObjectWriter AppendClientEventObject(string name, IClientEventObject clientEvents)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (clientEvents == null) throw new ArgumentNullException("clientEvents");

            EnsureStart();
            writer.Write(appended ? ", " : "{");
            writer.Write("{0}:{{", name);
            writeExplicitObject = true;
            clientEvents.SerializeTo(this);
            writer.Write("}");
            writeExplicitObject = false;
            return this;
        }

        public virtual ClientSideObjectWriter Append(string name, HtmlTemplate htmlTemplate)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (htmlTemplate.HasValue())
            {
                if (htmlTemplate.Content != null)
                {
                    EnsureStart();
                    writer.Write(appended ? ", " : "{");
                    writer.Write("{0}:'", name);
                    htmlTemplate.Content();
                    writer.Write("'");
                    return this;
                }
                if (htmlTemplate.Html.HasValue())
                {
                    string formattedValue = QuoteString(htmlTemplate.Html);
                    Append(String.Format("{0}:'{1}'", name, formattedValue));
                    return this;
                }
                if (htmlTemplate.InlineTemplate != null)
                {
                    object inlineTemplate = htmlTemplate.InlineTemplate(null);
                    if (inlineTemplate != null)
                    {
                        string formattedValue2 = QuoteString(inlineTemplate.ToString());
                        Append(String.Format("{0}:'{1}'", name, formattedValue2));
                    }
                }
            }
            return this;
        }

        public virtual void Complete()
        {
            EnsureStart();
            if (appended)
            {
                writer.Write("}");
            }
            writer.Write(");");
            hasStarted = false;
            appended = false;
        }

        private static string QuoteString(string value)
        {
            var result = new StringBuilder();

            if (!string.IsNullOrEmpty(value))
            {
                int startIndex = 0;
                int count = 0;

                for (int i = 0; i < value.Length; i++)
                {
                    char c = value[i];

                    if (c == '\r' || c == '\t' || c == '\"' || c == '\'' || c == '<' || c == '>' ||
                        c == '\\' || c == '\n' || c == '\b' || c == '\f' || c < ' ')
                    {
                        if (count > 0)
                        {
                            result.Append(value, startIndex, count);
                        }

                        startIndex = i + 1;
                        count = 0;
                    }

                    switch (c)
                    {
                        case '\r':
                            result.Append("\\r");
                            break;
                        case '\t':
                            result.Append("\\t");
                            break;
                        case '\"':
                            result.Append("\\\"");
                            break;
                        case '\\':
                            result.Append("\\\\");
                            break;
                        case '\n':
                            result.Append("\\n");
                            break;
                        case '\b':
                            result.Append("\\b");
                            break;
                        case '\f':
                            result.Append("\\f");
                            break;
                        case '\'':
                        case '>':
                        case '<':
                            AppendAsUnicode(result, c);
                            break;
                        default:
                            if (c < ' ')
                            {
                                AppendAsUnicode(result, c);
                            }
                            else
                            {
                                count++;
                            }

                            break;
                    }
                }

                if (result.Length == 0)
                {
                    result.Append(value);
                }
                else if (count > 0)
                {
                    result.Append(value, startIndex, count);
                }
            }

            return result.ToString();
        }

        private static void AppendAsUnicode(StringBuilder builder, char c)
        {
            builder.Append("\\u");
            builder.AppendFormat(CultureInfo.InvariantCulture, "{0:x4}", (int)c);
        }

        private void EnsureStart()
        {
            if (!hasStarted)
            {
                throw new InvalidOperationException("You must have to call start prior calling this method");
            }
        }

        private static JsonSerializerSettings GetJsonSerializerSettings()
        {
            var settings = new JsonSerializerSettings
            {
                //TODO: camelCase for javascript serialization
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            settings.Converters.Add(new SizeJsonConverter());
            settings.Converters.Add(new PointJsonConverter());
            return settings;
        }
    }
}