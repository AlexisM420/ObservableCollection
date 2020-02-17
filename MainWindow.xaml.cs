using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Databinding_E_game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Game currentGame;

        public ObservableCollection<Game> games { get; set; }
        private int maxIndex;

        public Game CurrentGame {
            get => currentGame;
            set
            {
                currentGame = value;
                OnPropertyChanged();
            }
        }

        public int MaxIndex { get => maxIndex; set => maxIndex = value; }

        public MainWindow()
        {
            games = new ObservableCollection<Game>()
            {
                new Game {Title = "Super Mario Bros.",
                    Console="Switch", CoverPath="images/super_mario.png",
                    Description="Plumber who's never tired of saving the Princess.",
                    Editor="Nintendo", Rating=10, Year=1985},

                new Game {Title = "Ark",
                    Console="XBox", CoverPath="images/ark.jpg",
                    Description="Survive in a dinosaur world",
                    Editor="I don't remember", Rating=7, Year=2014},

                new Game {Title = "Balloon Fight",
                    Console="PS4", CoverPath="images/balloon_fight.jpg",
                    Description="Ballon nerds fighting",
                    Editor="Something nintendo", Rating=8, Year=1988},

            };

            CurrentGame = games[0];
            MaxIndex = games.Count - 1;
            games[0].Info = games[0].Title+" : "+games[0].Description;
            games[1].Info = games[1].Title + " : " + games[1].Description;
            games[2].Info = games[2].Title + " : " + games[2].Description;

            InitializeComponent();
            cbbox.SelectedIndex = 0;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            CurrentGame.Rating = e.NewValue;
        }

        private void ScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Debug.WriteLine((int)e.NewValue);

            int newIndex = (int)e.NewValue;

            CurrentGame = games[newIndex];

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int newIndex = lstview.SelectedIndex;

            CurrentGame = games[newIndex];
            cbbox.SelectedIndex = newIndex;
        }
    }
}
