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
using System.Windows.Shapes;

namespace Second.view
{
    public partial class IllnessWin : Window
    {
        private Dictionary<int, Болезни> realtors = new Dictionary<int, Болезни>();
        public IllnessWin()
        {
            InitializeComponent();
            GetSpec(0);
            this.WindowState = WindowState.Maximized;
        }

        private void GetSpec(int index)
        {
            using (Model1 model = new Model1())
            {

                var query = from s in model.Болезни
                            select s;

                foreach (var item in query)
                {
                    if (item.Код_болезни == index)
                    {
                        CodeDis.Text = item.Код_болезни.ToString();
                        name.Text = item.Наиенование.ToString();
                        simpt.Text = item.Симптомы.ToString();
                        continuied.Text = item.Продолжительнось.ToString();
                        aftermath.Text = item.Последствия.ToString();
                        CodeLec1.Text = item.Код_лекарства_1.ToString();
                        CodeLec2.Text = item.Код_лекарства_2.ToString();
                        CodeLec3.Text = item.Код_лекарства_3.ToString();

                        IndexText.Text = index.ToString();
                    }

                    realtors.Add(index + 1, item);

                    index++;
                }

            }
        }

        //Переключение записей
        private void NextEntry(int index)
        {
            try
            {
                int _maxLenth = realtors.Count;

                if (index <= _maxLenth && index > 0)
                {
                    CodeDis.Text = realtors[index + 1].Код_болезни.ToString();
                    name.Text = realtors[index + 1].Наиенование.ToString();
                    simpt.Text = realtors[index + 1].Симптомы.ToString();
                    continuied.Text = realtors[index + 1].Продолжительнось.ToString();
                    aftermath.Text = realtors[index + 1].Последствия.ToString();
                    CodeLec1.Text = realtors[index + 1].Код_лекарства_1.ToString();
                    CodeLec2.Text = realtors[index + 1].Код_лекарства_2.ToString();
                    CodeLec3.Text = realtors[index + 1].Код_лекарства_3.ToString();

                    IndexText.Text = index.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveEntry(int index)
        {
            try
            {
                int _maxLenth = realtors.Count;

                if (index <= _maxLenth && index > 0)
                {
                    using (Model1 model = new Model1())
                    {
                        Болезни болезни = new Болезни
                        {
                            Наиенование = name.Text,
                            Симптомы = simpt.Text,
                            Продолжительнось = continuied.Text,
                            Последствия = aftermath.Text,
                            Код_лекарства_1 = long.Parse(CodeLec1.Text),
                            Код_лекарства_2 = long.Parse(CodeLec2.Text),
                            Код_лекарства_3 = long.Parse(CodeLec3.Text)
                        };

                        model.Болезни.Add(болезни);
                        model.SaveChanges();

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось сохранить изменения");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NextEntry(int.Parse(IndexText.Text) + 1);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NextEntry(int.Parse(IndexText.Text) - 1);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NextEntry(0);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NextEntry(realtors.Count);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            SaveEntry(int.Parse(IndexText.Text));
        }
    }
}
