using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SnakeApp
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      //create a counter for number of clicks
      int counter = 0;
      //initialize a random variable
      Random randomColor = new Random();
      //create a list of point values for coordinates
      private PointCollection points = new PointCollection();
      public MainWindow()
      {
         InitializeComponent();
         snakeLine.Points = points;
      }

      private void Canvas_MouseEnter(object sender, MouseEventArgs e)
      {
         //make line and ellipsis visible
         snakeHead.Visibility = Visibility.Visible;
         snakeLine.Visibility = Visibility.Visible;

      }

      private void Canvas_MouseMove(object sender, MouseEventArgs e)
      {
         //get position of the mouse
         var snakePosition = e.GetPosition((Canvas)sender);
         //set the position of the ellispis to the position of the mouse
         Canvas.SetLeft(snakeHead, (snakePosition.X - 10));
         Canvas.SetTop(snakeHead, (snakePosition.Y - 10));

         //if line has more than 150 points
         if (points.Count > 150)
         {
            //remove the first index and add a new one
            points.RemoveAt(0);
            points.Add(e.GetPosition(drawCanvas));
         }
         else
         {
            //otherwise just add a new one until at 150
            points.Add(e.GetPosition(drawCanvas));
         }

      }

      private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
      {
         //add to the counter every click
         counter++;
         //if counter divided by 5 remainder is not equal to 0
         //create a random color for the snake head and line
         //and set those colors to the fill and stroke of those
         if (!(counter % 5 == 0))
         {
            byte randomR = Convert.ToByte(randomColor.Next(1, 255));
            byte randomG = Convert.ToByte(randomColor.Next(1, 255));
            byte randomB = Convert.ToByte(randomColor.Next(1, 255));

            Brush brushColor = new SolidColorBrush(Color.FromRgb(randomR, randomG, randomB));
            snakeHead.Fill = brushColor;
            snakeLine.Stroke = brushColor;
         }
         // if counter divided by 5 remainder is equal to 0
         //create a random color for the background
         //and set that color to the background of the canvas
         if (counter % 5 == 0)
         {
            byte randomCanvasR = Convert.ToByte(randomColor.Next(1, 255));
            byte randomCanvasG = Convert.ToByte(randomColor.Next(1, 255));
            byte randomCanvasB = Convert.ToByte(randomColor.Next(1, 255));

            Brush canvasBackground = new SolidColorBrush(Color.FromRgb(randomCanvasR, randomCanvasG, randomCanvasB));
            drawCanvas.Background = canvasBackground;
         }
      }

   }
}
