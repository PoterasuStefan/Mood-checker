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
using System.IO;
using Path = System.IO.Path;

namespace Mood_checker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int negative, positive, i, n, m, q, percent_positive, percent_negative;
        string[] negative_index = new string[] { "sadness", "dejection", "depression", "despondency", "dismal", "feeling", "gloom", "gloominess", "grief", "heartache", "self-pity", "misery", "pain", "sorrow", "unhappiness", "woe", "death", "sad", "depressing", "grievous", "heartbreaking", "plaintive", "mournful", "tragic" };
        string[] positive_index = new string[] { "happiness", "bliss", "cheerfulness", "contentment", "delight", "elation", "euphoria", "gladness", "good feelings", "joy", "mirth", "pleasure", "satisfaction", "happy", "happily", "cheerful", "cheerfully", "chipper", "content" };


        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        public MainWindow()
        {
            InitializeComponent();

            n = negative_index.Length;
            m = positive_index.Length;

        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                negative = 0;
                positive = 0;

                for (i = 0; i < n; i++)
                {
                    if (Input.Text.Contains(negative_index[i]))
                    {
                        negative++;
                    }
                }

                for (i = 0; i < m; i++)
                {
                    if (Input.Text.Contains(positive_index[i]))
                    {
                        positive++;
                    }
                }
                if (positive + negative > 0)
                {
                    q = 100 / (positive + negative);
                    percent_positive = q * positive;
                    percent_negative = q * negative;


                    if (percent_negative > percent_positive)
                    {

                        Accuracy_Label.Content = percent_negative + "%";
                        Emoji.Source = new BitmapImage(new Uri("/Mood checker;component/images/Sad-Face-Emoji.png", UriKind.Relative));


                        MessageBox.Show("You are sad");

                    }
                    else if (percent_negative < percent_positive)
                    {

                        Accuracy_Label.Content = percent_positive + "%";
                        Emoji.Source = new BitmapImage(new Uri("/Mood checker;component/images/happyface.jpg", UriKind.Relative));
                        MessageBox.Show("You are happy");

                    }
                    else
                    {
                        Accuracy_Label.Content = "100%";
                        Emoji.Source = new BitmapImage(new Uri("/Mood checker;component/images/Shrug.jpg", UriKind.Relative));
                        MessageBox.Show("You are just as happy as you are sad 🤷 ");
                    }
                }
                else
                {
                    MessageBox.Show("I'm not sure if you are happy or sad");
                }

            }
        }
    }
}