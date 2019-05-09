using Microsoft.Xna.Framework.Graphics;
using SharpFont;
using System;
using System.Collections.Generic;
using System.IO;

namespace FNT
{
    /// <summary>Responsible for creating Font instances from a given file.</summary>
    public sealed partial class FontLibrary : IDisposable
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="fontStream">A stream to the TTF/OTF file that will be used. The stream will be copied internally but will NOT be disposed.</param>
        /// <param name="graphicsDevice">XNA GraphicsDevice which will be used to create textures.</param>
        public FontLibrary(Stream fontStream, GraphicsDevice graphicsDevice)
        {
            GraphicsDevice = graphicsDevice;

            using (var ms = new MemoryStream())
            {
                fontStream.CopyTo(ms);
                fontBytes = ms.ToArray();
            }
        }

        /// <summary>
        /// Create an instance of a Font with the given size.
        /// If called multiple times with the same size, the same Font instance will always be returned.
        /// </summary>
        /// <param name="size">Font size</param>
        /// <returns>The created Font</returns>
        public IFont CreateFont(int size)
        {
            if (!fonts.TryGetValue(size, out var font))
                font = new Font(size, fontBytes, GraphicsDevice);

            return font;
        }

        /// <summary>Disposes all Fonts tracked by this FontLibrary.</summary>
        public void Dispose()
        {
            foreach (var font in fonts.Values)
                font.Dispose();

            _lib.Dispose();
        }

        private readonly Dictionary<int, IFont> fonts = new Dictionary<int, IFont>();
        private static Library _lib = new Library();
        private readonly GraphicsDevice GraphicsDevice;
        private readonly byte[] fontBytes;
    }
}
