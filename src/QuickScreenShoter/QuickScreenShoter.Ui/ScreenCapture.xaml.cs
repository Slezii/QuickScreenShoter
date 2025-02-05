using Microsoft.UI.Windowing;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using System;
using System.Threading.Tasks;
using Windows.Graphics;
using WinRT.Interop;
using System.Drawing;
using QuickScreenShoter.Ui.Extensions;


namespace QuickScreenShoter.Ui
{
    public sealed partial class ScreenCapture : ContentDialog
    {
        private Point startPoint;
        private bool isSelecting;
        private Rectangle? selectedRegion;
        private bool isCancelled;
        //private FullScreenHelper? fullScreenHelper;

        public ScreenCapture()
        {
            this.InitializeComponent();
            SetupWindow();

            RootGrid.PointerPressed += OnPointerPressed;
            RootGrid.PointerMoved += OnPointerMoved;
            RootGrid.PointerReleased += OnPointerReleased;
        }

        private void SetupWindow()
        {
            //fullScreenHelper = new FullScreenHelper(this);
            //fullScreenHelper.MakeFullScreen();
        }

        private void OnPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            RootGrid.CapturePointer(e.Pointer);
            startPoint = e.GetCurrentPoint(RootGrid).Position.ToSystemDrawingPoint();
            isSelecting = true;

            SelectionRectangle.Width = 0;
            SelectionRectangle.Height = 0;
            Canvas.SetLeft(SelectionRectangle, startPoint.X);
            Canvas.SetTop(SelectionRectangle, startPoint.Y);
            SelectionRectangle.Visibility = Visibility.Visible;
        }

        private void OnPointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (!isSelecting) return;

            var currentPoint = e.GetCurrentPoint(RootGrid).Position;

            double left = Math.Min(startPoint.X, currentPoint.X);
            double top = Math.Min(startPoint.Y, currentPoint.Y);
            double width = Math.Abs(currentPoint.X - startPoint.X);
            double height = Math.Abs(currentPoint.Y - startPoint.Y);

            Canvas.SetLeft(SelectionRectangle, left);
            Canvas.SetTop(SelectionRectangle, top);
            SelectionRectangle.Width = width;
            SelectionRectangle.Height = height;

            DimensionsText.Text = $"{(int)width} x {(int)height}";
            DimensionsDisplay.Visibility = Visibility.Visible;

            Canvas.SetLeft(DimensionsDisplay, left);
            Canvas.SetTop(DimensionsDisplay, top - 30);
        }

        private void OnPointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (!isSelecting) return;

            RootGrid.ReleasePointerCapture(e.Pointer);
            isSelecting = false;

            var currentPoint = e.GetCurrentPoint(RootGrid).Position;

            double left = Math.Min(startPoint.X, currentPoint.X);
            double top = Math.Min(startPoint.Y, currentPoint.Y);
            double width = Math.Abs(currentPoint.X - startPoint.X);
            double height = Math.Abs(currentPoint.Y - startPoint.Y);

            if (width > 10 && height > 10)
            {
                selectedRegion = new Rectangle(
                    (int)left,
                    (int)top,
                    (int)width,
                    (int)height
                );
                CompleteSelection();
            }
        }

        private void OnEscapePressed(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
        {
            isCancelled = true;
            CompleteSelection();
        }

        private void CompleteSelection()
        {
            //this.Tag = isCancelled ? null : selectedRegion;
            //this.Hide();
            //fullScreenHelper?.ExitFullScreen();
        }

        public void OnNavigatedTo(object parameter)
        {
        }
    }
}
