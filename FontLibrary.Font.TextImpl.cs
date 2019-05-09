using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace FNT
{
    public partial class FontLibrary
    {
        private partial class Font : IFont
        {
            private class TextImpl : IText
            {
                public string String { get; }

                public float Width { get; }
                public float Height { get; }

                public TextImpl(string text, List<RenderGlyph> glyphs, float width, float height)
                {
                    String = text;
                    Glyphs = glyphs;
                    Width = width;
                    Height = height;
                }
                
                public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
                {
                    foreach (var glyph in Glyphs)
                        spriteBatch.Draw(glyph.Texture, glyph.Position + position, glyph.Bounds, color);
                }

                private readonly List<RenderGlyph> Glyphs;
            }
        }
    }
}