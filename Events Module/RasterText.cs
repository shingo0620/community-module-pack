using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using Blish_HUD;
using Blish_HUD.Content;
using Blish_HUD.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DrawingColor = System.Drawing.Color;
using DrawingFont = System.Drawing.Font;
using DrawingFontStyle = System.Drawing.FontStyle;
using DrawingGraphics = System.Drawing.Graphics;
using XnaPoint = Microsoft.Xna.Framework.Point;
using XnaRectangle = Microsoft.Xna.Framework.Rectangle;
using XnaColor = Microsoft.Xna.Framework.Color;

namespace Events_Module {

    /// <summary>
    /// Renders module text through an installed Windows font so CJK glyphs remain visible
    /// even though Blish HUD's default bitmap font only contains Latin glyphs.
    /// </summary>
    internal sealed class RasterText : Control {

        private static readonly string[] FontCandidates = {
            "Microsoft JhengHei UI",
            "Microsoft JhengHei",
            "Noto Sans CJK TC",
            "Noto Sans TC",
            "Microsoft YaHei UI",
            "Microsoft YaHei",
            "Arial Unicode MS"
        };

        private readonly Texture2D _texture;

        public bool HasTexture => _texture != null;

        public RasterText(string text, int fontSize, int maxWidth) {
            _texture = CreateTexture(text, fontSize, maxWidth);

            if (_texture != null) {
                Size = new XnaPoint(_texture.Width, _texture.Height);
            }
        }

        protected override void Paint(SpriteBatch spriteBatch, XnaRectangle bounds) {
            if (_texture != null) {
                spriteBatch.DrawOnCtrl(this,
                                       _texture,
                                       new XnaRectangle(0, 0, _texture.Width, _texture.Height),
                                       XnaColor.White);
            }
        }

        protected override void DisposeControl() {
            _texture?.Dispose();
            base.DisposeControl();
        }

        private static Texture2D CreateTexture(string text, int fontSize, int maxWidth) {
            if (string.IsNullOrEmpty(text)) return null;

            DrawingFont font = null;
            Bitmap bitmap = null;
            DrawingGraphics graphics = null;

            try {
                font = CreateFont(fontSize);
                if (font == null) return null;

                var measuredWidth = MeasureWidth(text, font);
                while (measuredWidth > maxWidth && font.Size > 10f) {
                    var nextSize = Math.Max(10f, font.Size - 1f);
                    font.Dispose();
                    font = CreateFont(nextSize);
                    measuredWidth = MeasureWidth(text, font);
                }

                var width = Math.Max(1, Math.Min(maxWidth, (int)Math.Ceiling(measuredWidth) + 2));
                var height = Math.Max(1, (int)Math.Ceiling(font.GetHeight()) + 2);

                bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
                graphics = DrawingGraphics.FromImage(bitmap);
                graphics.Clear(DrawingColor.Transparent);
                graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                graphics.DrawString(text,
                                    font,
                                    Brushes.White,
                                    new PointF(0, 0),
                                    StringFormat.GenericTypographic);

                var pixels = new XnaColor[width * height];
                for (var y = 0; y < height; y++) {
                    for (var x = 0; x < width; x++) {
                        var pixel = bitmap.GetPixel(x, y);
                        pixels[y * width + x] = new XnaColor(pixel.R, pixel.G, pixel.B, pixel.A);
                    }
                }

                var texture = new Texture2D(GameService.Graphics.GraphicsDevice, width, height);
                texture.SetData(pixels);
                return texture;
            } catch (Exception e) {
                Logger.GetLogger<RasterText>().Warn(e, "Unable to rasterize module text.");
                return null;
            } finally {
                graphics?.Dispose();
                bitmap?.Dispose();
                font?.Dispose();
            }
        }

        private static DrawingFont CreateFont(float size) {
            var installedFonts = new InstalledFontCollection();

            try {
                foreach (var candidate in FontCandidates) {
                    foreach (var family in installedFonts.Families) {
                        if (string.Equals(family.Name, candidate, StringComparison.OrdinalIgnoreCase)) {
                            return new DrawingFont(family, size, DrawingFontStyle.Regular, GraphicsUnit.Pixel);
                        }
                    }
                }

                return new DrawingFont(FontFamily.GenericSansSerif, size, DrawingFontStyle.Regular, GraphicsUnit.Pixel);
            } finally {
                installedFonts.Dispose();
            }
        }

        private static float MeasureWidth(string text, DrawingFont font) {
            using (var probe = new Bitmap(1, 1))
            using (var graphics = DrawingGraphics.FromImage(probe)) {
                return graphics.MeasureString(text, font, int.MaxValue, StringFormat.GenericTypographic).Width;
            }
        }
    }
}
