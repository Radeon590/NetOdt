﻿using NetCoreOdt.Enumerations;
using NetCoreOdt.Helper;
using NetOdt.Enumerations;
using System;
using System.Text;

namespace NetCoreOdt
{
    /// <summary>
    /// Class to create and write ODT documents
    /// </summary>
    public sealed partial class OdtDocument
    {
        /// <summary>
        /// Append a single line with a unformatted value to the document
        /// </summary>
        /// <param name="value">The value to write into the document</param>
        public void Append(in ValueType value)
            => Append(value, TextStyle.Normal);

        /// <summary>
        /// Append a single line with a unformatted text to the document (Note: line breaks "\n" will currently not working)
        /// </summary>
        /// <param name="text">The text to write into the document</param>
        public void Append(in string text)
            => Append(text, TextStyle.Normal);

        /// <summary>
        /// Append the content of the given <see cref="StringBuilder"/> as unformatted text into the document (Note: line breaks "\n" will currently not working)
        /// </summary>
        /// <param name="content">The <see cref="StringBuilder"/> that contains the content for the document</param>
        public void Append(in StringBuilder content)
            => Append(content, TextStyle.Normal);

        /// <summary>
        /// Append a single line with a styled value to the document
        /// </summary>
        /// <param name="value">The value to write into the document</param>
        /// <param name="style">The text style of the value</param>
        public void Append(in ValueType value, in TextStyle style)
        {
            var styleName = StyleHelper.GetStyleName(style);

            TextContent.Append($"<text:p text:style-name=\"{styleName}\">");
            TextContent.Append(value);
            TextContent.Append("</text:p>");
        }

        /// <summary>
        /// Append a single line with a styled text to the document (Note: line breaks "\n" will currently not working)
        /// </summary>
        /// <param name="text">The text to write into the document</param>
        /// <param name="style">The text style of the text</param>
        public void Append(in string text, in TextStyle style)
        {
            var styleName = StyleHelper.GetStyleName(style);

            if(text.Length == 0 || !text.Contains("\n"))
            {
                TextContent.Append($"<text:p text:style-name=\"{styleName}\">");
                TextContent.Append(text);
                TextContent.Append("</text:p>");
                return;
            }

            foreach(var textBlock in text.Split('\n'))
            {
                TextContent.Append($"<text:p text:style-name=\"{styleName}\">");
                TextContent.Append(textBlock);
                TextContent.Append("</text:p>");
            }
        }

        /// <summary>
        /// Append the content of the given <see cref="StringBuilder"/> as styled text the document (Note: line breaks "\n" will currently not working)
        /// </summary>
        /// <param name="content">The <see cref="StringBuilder"/> that contains the content for the document</param>
        /// <param name="style">The text style of the content</param>
        public void Append(in StringBuilder content, in TextStyle style)
        {
            var styleName = StyleHelper.GetStyleName(style);

            if(content.Length == 0 || !StringBuilderHelper.ContainsLineBreaks(content))
            {
                TextContent.Append($"<text:p text:style-name=\"{styleName}\">");
                TextContent.Append(content);
                TextContent.Append("</text:p>");
                return;
            }

            foreach(var contentBlock in content.ToString().Split('\n'))
            {
                TextContent.Append($"<text:p text:style-name=\"{styleName}\">");
                TextContent.Append(contentBlock);
                TextContent.Append("</text:p>");
            }
        }

        /// <summary>
        /// Append the given count of empty lines
        /// </summary>
        /// <param name="countOfEmptyLines">The count of empty lines to write</param>
        public void AppendEmptyLines(int countOfEmptyLines)
        {
            for(var index = 0; index < countOfEmptyLines; index++)
            {
                Append(string.Empty, TextStyle.Normal);
            }
        }

        /// <summary>
        /// Append a value with the given header style
        /// </summary>
        /// <param name="value">The value for the header</param>
        /// <param name="style">The style of the header</param>
        public void Append(in ValueType value, in HeaderStyle style)
        {
            var styleName = StyleHelper.GetStyleName(style);

            switch(style)
            {
                case HeaderStyle.Title:
                case HeaderStyle.Subtitle:
                case HeaderStyle.Signature:
                case HeaderStyle.Quotations:
                case HeaderStyle.Endnote:
                case HeaderStyle.Footnote:
                    TextContent.Append($"<text:p text:style-name=\"{styleName}\">");
                    TextContent.Append(value);
                    TextContent.Append("</text:p>");
                    break;

                case HeaderStyle.HeadingLevel01:
                case HeaderStyle.HeadingLevel02:
                case HeaderStyle.HeadingLevel03:
                case HeaderStyle.HeadingLevel04:
                case HeaderStyle.HeadingLevel05:
                case HeaderStyle.HeadingLevel06:
                case HeaderStyle.HeadingLevel07:
                case HeaderStyle.HeadingLevel08:
                case HeaderStyle.HeadingLevel09:
                case HeaderStyle.HeadingLevel10:
                    TextContent.Append($"<text:h text:style-name=\"{styleName}\" text:outline-level=\"{(int)style}\">");
                    TextContent.Append(value);
                    TextContent.Append("</text:h>");
                    break;
            }
        }

        /// <summary>
        /// Append a text with the given header style
        /// </summary>
        /// <param name="text">The text for the header</param>
        /// <param name="style">The style of the header</param>
        public void Append(in string text, in HeaderStyle style)
        {
            var styleName = StyleHelper.GetStyleName(style);

            switch(style)
            {
                case HeaderStyle.Title:
                case HeaderStyle.Subtitle:
                case HeaderStyle.Signature:
                case HeaderStyle.Quotations:
                case HeaderStyle.Endnote:
                case HeaderStyle.Footnote:
                    TextContent.Append($"<text:p text:style-name=\"{styleName}\">");
                    TextContent.Append(text);
                    TextContent.Append("</text:p>");
                    break;

                case HeaderStyle.HeadingLevel01:
                case HeaderStyle.HeadingLevel02:
                case HeaderStyle.HeadingLevel03:
                case HeaderStyle.HeadingLevel04:
                case HeaderStyle.HeadingLevel05:
                case HeaderStyle.HeadingLevel06:
                case HeaderStyle.HeadingLevel07:
                case HeaderStyle.HeadingLevel08:
                case HeaderStyle.HeadingLevel09:
                case HeaderStyle.HeadingLevel10:
                    TextContent.Append($"<text:h text:style-name=\"{styleName}\" text:outline-level=\"{(int)style}\">");
                    TextContent.Append(text);
                    TextContent.Append("</text:h>");
                    break;
            }
        }

        /// <summary>
        /// Append a content with the given header style
        /// </summary>
        /// <param name="content">The content for the header</param>
        /// <param name="style">The style of the header</param>
        public void Append(in StringBuilder content, in HeaderStyle style)
        {
            var styleName = StyleHelper.GetStyleName(style);

            switch (style)
            {
                case HeaderStyle.Title:
                case HeaderStyle.Subtitle:
                case HeaderStyle.Signature:
                case HeaderStyle.Quotations:
                case HeaderStyle.Endnote:
                case HeaderStyle.Footnote:
                    TextContent.Append($"<text:p text:style-name=\"{styleName}\">");
                    TextContent.Append(content);
                    TextContent.Append("</text:p>");
                    break;

                case HeaderStyle.HeadingLevel01:
                case HeaderStyle.HeadingLevel02:
                case HeaderStyle.HeadingLevel03:
                case HeaderStyle.HeadingLevel04:
                case HeaderStyle.HeadingLevel05:
                case HeaderStyle.HeadingLevel06:
                case HeaderStyle.HeadingLevel07:
                case HeaderStyle.HeadingLevel08:
                case HeaderStyle.HeadingLevel09:
                case HeaderStyle.HeadingLevel10:
                    TextContent.Append($"<text:h text:style-name=\"{styleName}\" text:outline-level=\"{(int)style}\">");
                    TextContent.Append(content);
                    TextContent.Append("</text:h>");
                    break;
            }
        }
    }
}
