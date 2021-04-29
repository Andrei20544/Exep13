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
    public partial class PositionsWin : Window
    {
        public PositionsWin()
        {
            InitializeComponent();
            GetPred(0);
            this.WindowState = WindowState.Maximized;
        }

        private void GetPred(int index)
        {
            using (Model1 model = new Model1())
            {

                var query = from s in model.Должности
                            select s;

                foreach (var item in query)
                {
                    if (item.Код_должности == index)
                    {
                        code.Text = item.Код_должности.ToString();
                        name.Text = item.Наименование_должности;
                        oklad.Text = item.Оклад.ToString();
                        duties.Text = item.Обязонности;
                        requirements.Text = item.Требования;

                        IndexText.Text = item.Код_должности.ToString();
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

                    Должности должности = model.Должности.Where(p => p.Код_должности == int.Parse(code.Text)).FirstOrDefault();

                    должности.Наименование_должности = name.Text;
                    должности.Оклад = Decimal.Parse(oklad.Text);
                    должности.Обязонности = duties.Text;
                    должности.Требования = requirements.Text;

                    model.Entry(должности).State = System.Data.Entity.EntityState.Modified;
                    model.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось сохранить изменения");
            }
        }

        private void DeleteEntry()
        {
            try
            {
                using (Model1 model = new Model1())
                {

                    Должности должности = model.Должности.Where(p => p.Код_должности == int.Parse(code.Text)).FirstOrDefault();

                    model.Должности.Remove(должности);
                    model.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось сохранить изменения");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetPred(int.Parse(IndexText.Text) - 1);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GetPred(int.Parse(IndexText.Text) + 1);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            GetPred(1);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            using (Model1 model = new Model1())
            {
                var query = from s in model.Должности
                            select new
                            {
                                ID = s.Код_должности
                            };
                int id = int.Parse(query.LastOrDefault().ID.ToString());

                GetPred(id);
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            SaveEntry();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            DeleteEntry();
        }
    }
}
