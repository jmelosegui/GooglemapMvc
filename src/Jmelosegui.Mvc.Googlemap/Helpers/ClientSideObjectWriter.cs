// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.Collections;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

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
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (textWriter == null)
            {
                throw new ArgumentNullException(nameof(textWriter));
            }

            this.id = id;
            this.type = type;
            this.writer = textWriter;
        }

        public virtual ClientSideObjectWriter Start()
        {
            if (this.hasStarted)
            {
                throw new InvalidOperationException("You cannot call start more than once");
            }

            var selector = @";&,.+*~':""!^$[]()|/".ToCharArray().Aggregate(this.id, (current, chr) => current.Replace(chr.ToString(), @"\\" + chr));

            this.writer.Write("jQuery('#{0}').{1}(", selector, this.type);
            this.hasStarted = true;

            return this;
        }

        public virtual ClientSideObjectWriter Append(string keyValuePair)
        {
            this.EnsureStart();

            if (!string.IsNullOrEmpty(keyValuePair))
            {
                if (!this.writeExplicitObject)
                {
                    this.writer.Write(this.appended ? ", " : "{");
                }

                this.writeExplicitObject = false;
                this.writer.Write(keyValuePair);

                if (!this.appended)
                {
                    this.appended = true;
                }
            }

            return this;
        }

        public virtual ClientSideObjectWriter Append(string name, string value)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (value.HasValue())
            {
                string formattedValue = QuoteString(value);

                this.Append(string.Format(CultureInfo.InvariantCulture, "{0}:'{1}'", name, formattedValue));
            }

            return this;
        }

        public virtual ClientSideObjectWriter AppendNullableString(string name, string value)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (value != null)
            {
                string formattedValue = QuoteString(value);

                this.Append(string.Format(CultureInfo.InvariantCulture, "{0}:'{1}'", name, formattedValue));
            }

            return this;
        }

        public virtual ClientSideObjectWriter Append(string name, int value)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            this.Append(string.Format(CultureInfo.InvariantCulture, "{0}:{1}", name, value));

            return this;
        }

        public virtual ClientSideObjectWriter Append(string name, int value, int defaultValue)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (value != defaultValue)
            {
                this.Append(name, value);
            }

            return this;
        }

        public virtual ClientSideObjectWriter Append(string name, int? value)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (value.HasValue)
            {
                this.Append(name, value.Value);
            }

            return this;
        }

        public virtual ClientSideObjectWriter Append(string name, double value)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            this.Append(string.Format(CultureInfo.InvariantCulture, "{0}:'{1}'", name, value));

            return this;
        }

        public virtual ClientSideObjectWriter Append(string name, double? value)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (value.HasValue)
            {
                this.Append(name, value.Value);
            }

            return this;
        }

        public virtual ClientSideObjectWriter Append(string name, decimal value)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            this.Append(string.Format(CultureInfo.InvariantCulture, "{0}:'{1}'", name, value));

            return this;
        }

        public virtual ClientSideObjectWriter Append(string name, decimal? value)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (value.HasValue)
            {
                this.Append(name, value.Value);
            }

            return this;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase", Justification = "JSON representation of boolean values should be lower case.")]
        public virtual ClientSideObjectWriter Append(string name, bool value)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            this.Append(string.Format(CultureInfo.InvariantCulture, "{0}:{1}", name, value.ToString(CultureInfo.InvariantCulture).ToLower(CultureInfo.InvariantCulture)));

            return this;
        }

        public virtual ClientSideObjectWriter Append(string name, bool value, bool defaultValue)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (value != defaultValue)
            {
                this.Append(name, value);
            }

            return this;
        }

        public virtual ClientSideObjectWriter Append<TEnum>(string name, TEnum value)
            where TEnum : IComparable, IFormattable
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            var valueAttribute = value.GetType().GetField(value.ToString())
                                                .GetCustomAttributes(true)
                                                .OfType<ClientSideEnumValueAttribute>()
                                                .FirstOrDefault();

            if (valueAttribute != null)
            {
                this.Append(string.Format(CultureInfo.InvariantCulture, "{0}:{1}", name, valueAttribute.Value));
            }

            return this;
        }

        public virtual ClientSideObjectWriter Append<TEnum>(string name, TEnum value, TEnum defaultValue)
            where TEnum : IComparable, IFormattable
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (!value.Equals(defaultValue))
            {
                this.Append(name, value);
            }

            return this;
        }

        public virtual ClientSideObjectWriter Append(string name, Action action)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (action != null)
            {
                this.Append(string.Format(CultureInfo.InvariantCulture, "{0}:", name));
                action();
            }

            return this;
        }

        public virtual ClientSideObjectWriter Append(string name, Func<object, object> func)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            object result = func?.Invoke(this);

            if (result != null)
            {
                this.Append(string.Format(CultureInfo.InvariantCulture, "{0}:{1}", name, result));
            }

            return this;
        }

        public virtual ClientSideObjectWriter AppendCollection(string name, IEnumerable value)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return this.Append(string.Format(CultureInfo.InvariantCulture, "{0}:{1}", name, JsonConvert.SerializeObject(value, GetJsonSerializerSettings())));
        }

        public virtual ClientSideObjectWriter AppendObject(string name, object value)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return this.Append(string.Format(CultureInfo.InvariantCulture, "{0}:{1}", name, JsonConvert.SerializeObject(value, GetJsonSerializerSettings())));
        }

        public virtual ClientSideObjectWriter AppendClientEvent(string name, ClientEvent clientEvent)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (clientEvent == null)
            {
                throw new ArgumentNullException(nameof(clientEvent));
            }

            if (clientEvent.CodeBlock != null)
            {
                this.Append(name, clientEvent.CodeBlock);
            }
            else
            {
                if (clientEvent.InlineCodeBlock != null)
                {
                    this.Append(name, clientEvent.InlineCodeBlock);
                }
                else
                {
                    if (clientEvent.HandlerName.HasValue())
                    {
                        this.Append(string.Format(CultureInfo.InvariantCulture, "{0}:{1}", name, clientEvent.HandlerName));
                    }
                }
            }

            return this;
        }

        public virtual ClientSideObjectWriter AppendClientEventObject(string name, IClientEventObject clientEvents)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (clientEvents == null)
            {
                throw new ArgumentNullException(nameof(clientEvents));
            }

            this.EnsureStart();
            this.writer.Write(this.appended ? ", " : "{");
            this.writer.Write("{0}:{{", name);
            this.writeExplicitObject = true;
            clientEvents.SerializeTo(this);
            this.writer.Write("}");
            this.writeExplicitObject = false;
            return this;
        }

        public virtual ClientSideObjectWriter Append(string name, HtmlTemplate htmlTemplate)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (htmlTemplate == null)
            {
                throw new ArgumentNullException(nameof(htmlTemplate));
            }

            if (htmlTemplate.HasValue())
            {
                if (htmlTemplate.Content != null)
                {
                    this.EnsureStart();
                    this.writer.Write(this.appended ? ", " : "{");
                    this.writer.Write("{0}:'", name);
                    htmlTemplate.Content();
                    this.writer.Write("'");
                    return this;
                }

                if (htmlTemplate.Html.HasValue())
                {
                    string formattedValue = QuoteString(htmlTemplate.Html);
                    this.Append(string.Format(CultureInfo.InvariantCulture, "{0}:'{1}'", name, formattedValue));
                    return this;
                }

                if (htmlTemplate.InlineTemplate != null)
                {
                    object inlineTemplate = htmlTemplate.InlineTemplate(null);
                    if (inlineTemplate != null)
                    {
                        string formattedValue2 = QuoteString(inlineTemplate.ToString());
                        this.Append(string.Format(CultureInfo.InvariantCulture, "{0}:'{1}'", name, formattedValue2));
                    }
                }
            }

            return this;
        }

        public virtual void Complete()
        {
            this.EnsureStart();
            if (this.appended)
            {
                this.writer.Write("}");
            }

            this.writer.Write(");");
            this.hasStarted = false;
            this.appended = false;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
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

        private static JsonSerializerSettings GetJsonSerializerSettings()
        {
            var settings = new JsonSerializerSettings
            {
                // TODO: camelCase for javascript serialization
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            settings.Converters.Add(new SizeJsonConverter());
            settings.Converters.Add(new PointJsonConverter());
            settings.Converters.Add(new LocationJsonConverter());
            return settings;
        }

        private void EnsureStart()
        {
            if (!this.hasStarted)
            {
                throw new InvalidOperationException("You must have to call start prior calling this method");
            }
        }
    }
}