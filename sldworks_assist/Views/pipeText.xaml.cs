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

namespace sldworks_assist.Views
{
    /// <summary>
    /// pipeText.xaml の相互作用ロジック
    /// </summary>
    public partial class pipeText : UserControl
    {
        static public pipeTextChildern[] demention1Main;
        static public pipeTextChildern[] demention2Main;

        public pipeText()
        {
            InitializeComponent();
            
        }


        private void Demention1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Key.ToString().StartsWith("D?") && !e.Key.ToString().StartsWith("Num"))
            {
                MessageBox.Show(e.Key.ToString());
                MessageBox.Show("数値を入力してください。");
                e.Handled = true;
            }
            
        }

        private void Demention2_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Key.ToString().StartsWith("D?") && !e.Key.ToString().StartsWith("Num"))
            {
                MessageBox.Show(e.Key.ToString());
                MessageBox.Show("数値を入力してください。");
                e.Handled = true;
                
            }
        }

        private void Demention2Text_KeyUp(object sender, KeyEventArgs e)
        {
            demention2.Children.Clear();
            if (Demention2Text.Text != "")
            {
                demention2Main = new pipeTextChildern[int.Parse(Demention2Text.Text)];
                for (int i = 0; i < int.Parse(Demention2Text.Text.ToString()); i++)
                {
                    demention2Main[i] = new pipeTextChildern();
                    demention2.Children.Add(demention2Main[i]);
                }
            }
        }

        private void Demention1Text_KeyUp(object sender, KeyEventArgs e)
        {
            demention1.Children.Clear();
            if (Demention1Text.Text != "")
            {
                demention1Main = new pipeTextChildern[int.Parse(Demention1Text.Text)];
                for (int i = 0; i < int.Parse(Demention1Text.Text.ToString()); i++)
                {
                    demention1Main[i] = new pipeTextChildern();
                    demention1.Children.Add(demention1Main[i]);
                }
            }
        }
    }
}
