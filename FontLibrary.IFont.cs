using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;

namespace FNT
{
    public partial class FontLibrary
    {
        /// <summary>
        /// Represents a configuration of a given font face with a specific size.
        /// </summary>
        public interface IFont : IDisposable
        {
            /// <summary>The character to render in the event that a given character is not found in the font</summary>
            char? DefaultCharacter { get; set; }

            /// <summary>The nominal height of one line of text</summary>
            int LineHeight { get; }

            /// <summary>Font Face size</summary>
            int Size { get; }

            /// <summary>How many spaces should be advanced for one occurrence of the '\t' character</summary>
            int TabSpaces { get; set; }

            /// <summary> Create a text object that can be rendered or measured</summary>
            /// <param name="text">The string to convert into a text object</param>
            IText MakeText(string text);

            /// <summary>Render all given characters to the internal glyph cache</summary>
            /// <param name="chars">Characters to precache</param>
            void PreheatCache(IEnumerable<char> chars);
        }

        /// <summary>Represents an object that can be rendered as text</summary>
        public interface IText
        {
            /// <summary>Width of the given string</summary>
            float Width { get; }

            /// <summary>Height of the given string</summary>
            float Height { get; }
            
            /// <summary>The string that produced this text object</summary>
            string String { get; }
            
            /// <summary>
            /// Render this text with the given SpriteBatch
            /// </summary>
            /// <param name="spriteBatch">SpriteBatch to render to</param>
            /// <param name="position">Position at which to render the text</param>
            /// <param name="color">Color to render the text with</param>
            void Draw(SpriteBatch spriteBatch, Vector2 position, Color color);
        }
    }
}