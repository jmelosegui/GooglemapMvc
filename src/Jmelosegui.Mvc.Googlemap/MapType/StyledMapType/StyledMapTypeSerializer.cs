using System.Collections.Generic;
using System.Linq;

namespace Jmelosegui.Mvc.GoogleMap
{
    public class StyledMapTypeSerializer : MapTypeSerializer
    {
        private readonly StyledMapType styledMapType;
        public StyledMapTypeSerializer(StyledMapType styledMapType) : base(styledMapType)
        {
            this.styledMapType = styledMapType;
        }

        public override IDictionary<string, object> Serialize()
        {
            var customStyles = new List<IDictionary<string, object>>();

            if (styledMapType.Styles.Any())
            {
                styledMapType.Styles.Each(cs => customStyles.Add(cs.Serialize()));
            }

            IDictionary<string, object> result = base.Serialize();
            FluentDictionary.For(result)
                .Add("styles", customStyles, () => styledMapType.Styles.Any());

            return result;
        }
    }
}