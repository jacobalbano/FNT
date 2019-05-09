A small library that uses SharpFont to dynamically render text in XNA or FNA.

```
var font = new FontLibrary(File.OpenRead("path/to/font.ttf"), GraphicsDevice);
var fontFace = font.CreateFont(64);
var text = font.MakeText("Hello, world!");
var bounds = new Rectangle(0, 0, text.Width, text.Height);

sb.RenderString(text, Vector2.Zero, Color.White);
```