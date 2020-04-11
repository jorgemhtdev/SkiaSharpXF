namespace SkiaSharpXF
{
    using SkiaSharp;
    using SkiaSharp.Views.Forms;

    // https://docs.microsoft.com/en-us/dotnet/api/skiasharp.skpaint?view=skiasharp-1.68.1
    // https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/graphics/skiasharp/effects/
    public class CustomControl : SKCanvasView
    {

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;

            // Background
            var rect = new SKRect(0, 0, e.Info.Width, e.Info.Height);

            // Paint => All operations that add a drawing to the canvas require a paint for the form that gets drawn
            //          Color => The color of the paint
            //          StrokeWidth => The size of the stroke
            //          Style => You can either only 
            //                   * Draw the path (Stroke)
            //                   * Fill the form created by the path (Fill)     
            //                   * Fill the form and draw the path (StrokeAndFill) which will add the StrokeWidth to the form

            var backgroundPaint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Shader = SKShader.CreateLinearGradient(new SKPoint(0, 0),
                    new SKPoint(e.Info.Width, e.Info.Height),
                    new[] { SKColors.Red, SKColors.Blue },
                    new float[] { 0, 1 },
                    SKShaderTileMode.Repeat),
                BlendMode = SKBlendMode.SrcOut
            };

            canvas.DrawRect(rect, backgroundPaint);
        }
    }
}
