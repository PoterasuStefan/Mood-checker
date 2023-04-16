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


        int negative, positive, i, n, m, q, percent_positive, percent_negative ;
        string[] negative_index = new string[60];
        string[] positive_index = new string[60];
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        public MainWindow()
        {
            InitializeComponent();

            string[] negative_index = {"sadness", "dejection", "depression", "despondency", "dismal", "feeling", "gloom", "gloominess", "grief", "heartache", "self - pity", "misery", "pain", "sorrow", "unhappiness", "woe","death", "sad", "depressing", "grievous", "heartbreaking", "plaintive", "mournful", "tragic"};
            string[] positive_index = {"happiness", "bliss", "cheerfulness", "contentment", "delight", "elation", "euphoria", "gladness", "good feelings", "joy", "mirth", "pleasure", "satisfaction", "happy", "happily", "cheerful", "cheerfully", "chipper", "content"};
            n = negative_index.Length;
            m = positive_index.Length;

        }

        
        



        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter))
            {
               for(i=1; i < n; i++)
                {
                    if (Input.Text.Contains(negative_index[i]))
                    {
                        negative++;
                    }
                    else if (Input.Text.Contains(positive_index[i]))
                    {
                        positive++; 
                    }
                }

                q = 100 / (positive + negative);
                percent_positive = q * positive;
                percent_negative = q * negative;

                if(percent_negative>percent_positive)
                {
                    //Emoji.Source = new System.Uri(baseDirectory + "\images\Sad-Face-Emoji.png");
                    MessageBox.Show("Esti suparat");
                    Accuracy_Label.Content=percent_negative + "%";
                }
                else
                {
                    MessageBox.Show("Esti fericit");
                    Accuracy_Label.Content = percent_positive + "%";
                }
            }
        }
    }
}
