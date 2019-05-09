using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using FNT;
using System;

//  This class is deliberately not in a namespace so you can use it without "using" anything

/// <summary>Utility class to assist in rendering text to a SpriteBatch.</summary>
public static class FontRenderer
{
    /// <summary>
    /// Draw textto SpriteBatch with the given Font.
    /// This method is SLOWER than the override that takes an IText instead of a string, as it will create and discard the glyphs every time.
    /// </summary>
    /// <param name="spriteBatch">This</param>
    /// <param name="font">The Font to use when rendering the string</param>
    /// <param name="text">The string to render.</param>
    /// <param name="position">Position at which to render the string</param>
    /// <param name="color">Color with which to render the string</param>
    [Obsolete("This method is not performant! Use the DrawString() override that takes a parameter of FontLibrary.IText")]
    public static void DrawString(this SpriteBatch spriteBatch, FontLibrary.IFont font, string text, Vector2 position, Color color)
    {
        spriteBatch.DrawString(font.MakeText(text), position, color);
    }

    /// <summary>
    /// Draw text to SpriteBatch with the given Font.
    /// </summary>
    /// <param name="spriteBatch">This</param>
    /// <param name="font">The Font to use when rendering the string</param>
    /// <param name="text">The text to render.</param>
    /// <param name="position">Position at which to render the text</param>
    /// <param name="color">Color with which to render the text</param>
    public static void DrawString(this SpriteBatch spriteBatch, FontLibrary.IText text, Vector2 position, Color color)
    {
        text.Draw(spriteBatch, position, color);
    }
}