using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NetOdt
{
    public sealed partial class OdtDocument
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeAsString"></param>
        public void AppendPureNode(string nodeAsString)
        {
            TextContent.Append(nodeAsString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        public void AppendPureNode(XmlNode node)
        {
            TextContent.Append(node.OuterXml);
        }
    }
}
