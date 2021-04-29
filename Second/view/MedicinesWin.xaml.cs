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
    public partial class MedicinesWin : Window
    {
        public MedicinesWin()
        {
            InitializeComponent();
            GetPred(0);
            this.WindowState = WindowState.Maximized;
        }

        private void GetPred(int index)
        {
            using (Model1 model = new Model1())
            {

                var query = from s in model.Лекарства
                            select s;

                foreach (var item in query)
                {
                    if (item.Код_лекарства == index)
                    {
                        CodeDis.Text = item.Код_лекарства.ToString();
                        name.Text = item.Наименование;
                        simpt.Text = item.Показания.ToString();
                        continuied.Text = item.Противопоказания;
                        aftermath.Text = item.Упаковка;
                        CodeLec1.Text = item.Стоимость.ToString();


                        IndexText.Text = item.Код_лекарства.ToString();
                    }
                }

            }
        }

        private void SaveEntry()
        {
            try
            {
                using (Model1 model = new Model1())
                {
                    Лекарства лекарства = new Лекарства
                    {
                        Наименование = name.Text,
                        Показания = simpt.Text,
                        Противопоказания = continuied.Text,
                        Упаковка = aftermath.Text,
                        Стоимость = decimal.Parse(CodeLec1.Text),
                    };

                    model.Лекарства.Add(лекарства);
                    model.SaveChanges();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось сохранить изменения");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GetPred(int.Parse(IndexText.Text) + 1);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetPred(int.Parse(IndexText.Text) - 1);

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            using (Model1 model = new Model1())
            {
                var query = from s in model.Лекарства
                            select new
                            {
                                ID = s.Код_лекарства
                            };
                int id = int.Parse(query.LastOrDefault().ID.ToString());

                GetPred(id);
            }
            
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            SaveEntry();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            GetPred(1);
        }
    }
}
