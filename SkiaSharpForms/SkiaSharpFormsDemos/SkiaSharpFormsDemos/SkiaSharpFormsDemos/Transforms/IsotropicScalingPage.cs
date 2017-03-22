﻿using System;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Transforms
{
    public class IsotropicScalingPage : ContentPage
    {
        public IsotropicScalingPage()
        {
            Title = "Isotropic Scaling";

            SKCanvasView canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            Content = canvasView;
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            SKPath path = HendecagramArrayPage.HendecagramPath;
            SKRect pathBounds = path.Bounds;

            using (SKPaint fillPaint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = SKColors.Pink
            })
            using (SKPaint strokePaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Blue,
                StrokeWidth = 3,
                StrokeJoin = SKStrokeJoin.Round
            })
            {
                canvas.Scale(info.Width / pathBounds.Width,
                             info.Height / pathBounds.Height);
                canvas.Translate(-pathBounds.Left, -pathBounds.Top);

                canvas.DrawPath(path, fillPaint);
                canvas.DrawPath(path, strokePaint);
            }
        }
    }
}