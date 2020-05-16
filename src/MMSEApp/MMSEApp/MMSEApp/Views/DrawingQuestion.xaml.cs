using MMSEApp.ViewModels;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MMSEApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DrawingQuestion : ContentPage
    {
		private readonly Dictionary<long, SKPath> temporaryPaths = new Dictionary<long, SKPath>();
		private readonly List<SKPath> paths = new List<SKPath>();
		private ExamViewModel examViewModel;
		public DrawingQuestion(ExamViewModel examView)
        {
			examViewModel = examView;
            InitializeComponent();
        }



		private void OnPainting(object sender, SKPaintSurfaceEventArgs e)
		{

			var surface = e.Surface;			
			var canvas = surface.Canvas;
			canvas.Clear(SKColors.White);

			var textPaint = new SKPaint
			{
				IsAntialias = true,
				Style = SKPaintStyle.Fill,
				Color = SKColors.Black,
				TextSize = 40
			};
			
			canvas.DrawText("Draw a Square", 60, 160, textPaint);

			var touchPathStroke = new SKPaint
			{
				IsAntialias = true,
				Style = SKPaintStyle.Stroke,
				Color = SKColors.Blue,
				StrokeWidth = 5
			};

			foreach (var touchPath in temporaryPaths)
			{
				canvas.DrawPath(touchPath.Value, touchPathStroke);
			}
			foreach (var touchPath in paths)
			{
				canvas.DrawPath(touchPath, touchPathStroke);
			}
		}

		private void OnTouch(object sender, SKTouchEventArgs e)
		{
			switch (e.ActionType)
			{
				case SKTouchAction.Pressed:
					var p = new SKPath();
					p.MoveTo(e.Location);
					temporaryPaths[e.Id] = p;
					break;
				case SKTouchAction.Moved:
					if (e.InContact && temporaryPaths.TryGetValue(e.Id, out var moving))
						moving.LineTo(e.Location);
					break;
				case SKTouchAction.Released:
					if (temporaryPaths.TryGetValue(e.Id, out var releasing))
						paths.Add(releasing);
					temporaryPaths.Remove(e.Id);
					break;
				case SKTouchAction.Cancelled:
					temporaryPaths.Remove(e.Id);
					break;
			}


			if (e.InContact)
				((SKCanvasView)sender).InvalidateSurface();

			e.Handled = true;
		}

		private void Back_Clicked(object sender, EventArgs e)
		{
			Navigation.PopAsync();
		}

		private void Finish_Clicked(object sender, EventArgs e)
		{
			//update db
			//examViewModel.SaveExamResult();
			Navigation.PushAsync(new CorrectExam(examViewModel));
			//Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
			//Navigation.PopAsync();

		}
	}
}
