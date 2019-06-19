/*Andrea Bonafini
June 16,2019
Simulation of the old CD player symbol
*/
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
using System.Windows.Threading;

namespace _319481CDplayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        Point play = new Point();
        Rectangle Player = new Rectangle();
        public enum Direction { RIGHT, LEFT, UP, DOWN };
        Direction direction;

        public MainWindow()
        {
            InitializeComponent();
            Player.Width = 130;
            Player.Height = 100;
            Player.Fill = Brushes.Red;
            BitmapImage bitmapImage = new BitmapImage(new Uri("logo.PNG", UriKind.Relative));
            ImageBrush imageBrush = new ImageBrush(bitmapImage);
            Player.Fill = imageBrush;
            
            //Player.Fill =("DVDLogog.bmp");
            canvas.Children.Add(Player);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 5);
            timer.Tick += tick;
            Canvas.SetLeft(Player, play.X * 10);
            Canvas.SetTop(Player, play.Y * 10);
            timer.Start();
        }
        public void tick(object sender, EventArgs e)
        {
            if (play.X > 645 && direction == Direction.UP)
            {
                direction = Direction.RIGHT;
            }
            else if (play.X > 645 && direction == Direction.LEFT)
            {
                direction = Direction.DOWN;
            }
            else if (play.X < 0 && direction == Direction.DOWN)
            {
                direction = Direction.LEFT;
            }
            else if (play.X < 0 && direction == Direction.RIGHT)
            {
                direction = Direction.UP;
            }
            else if (play.Y > 465 && direction == Direction.RIGHT)
            {
                direction = Direction.DOWN;
            }
            else if (play.Y > 465 && direction == Direction.UP)
            {
                direction = Direction.LEFT;
            }
            else if (play.Y < 0 && direction == Direction.LEFT)
            {
                direction = Direction.UP;
            }
            else if (play.Y < 0 && direction == Direction.DOWN)
            {
                direction = Direction.RIGHT;
            }
            switch (direction)
            {
                case (Direction.RIGHT):
                    play = new Point(play.X - Math.Sqrt(2.4), play.Y + (Math.Sqrt(3) / 2));
                    break;
                case (Direction.LEFT):
                    play = new Point(play.X + Math.Sqrt(3), play.Y - (Math.Sqrt(5) / 2));
                    break;
                case (Direction.DOWN):
                    play = new Point(play.X - Math.Sqrt(3.4), play.Y - (Math.Sqrt(3) / 2));
                    break;
                case (Direction.UP):
                    play = new Point(play.X + Math.Sqrt(3), play.Y + (Math.Sqrt(19) / 8));
                    break;
            }
            Canvas.SetLeft(Player, play.X);
            Canvas.SetTop(Player, play.Y);
        }
    }
}
