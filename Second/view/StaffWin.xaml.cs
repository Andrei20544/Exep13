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
    public partial class StaffWin : Window
    {
        public StaffWin()
        {
            InitializeComponent();
            GetPred(0);
            this.WindowState = WindowState.Maximized;
        }

        private void GetPred(int index)
        {
            using (Model1 model = new Model1())
            {

                var query = from s in model.Сотрудники
                            select s;

                foreach (var item in query)
                {
                    if (item.Код_сотрудника == index)
                    {
                        CodeDis.Text = item.Код_сотрудника.ToString();
                        name.Text = item.ФИО;
                        simpt.Text = item.Возраст.ToString();
                        continuied.Text = item.Пол;
                        aftermath.Text = item.Адрес;
                        CodeLec1.Text = item.Телефон.ToString();
                        CodeBol.Text = item.Паспортные_данные.ToString();
                        CodeSotr.Text = item.Код_должности.ToString();



                        IndexText.Text = item.Код_сотрудника.ToString();
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
                    Сотрудники сотрудники = model.Сотрудники.Where(p => p.Код_сотрудника == int.Parse(CodeDis.Text)).FirstOrDefault();

                    сотрудники.ФИО = name.Text;
                    сотрудники.Возраст = int.Parse(simpt.Text);
                    сотрудники.Пол = continuied.Text;
                    сотрудники.Адрес = aftermath.Text;
                    сотрудники.Телефон = CodeLec1.Text;
                    сотрудники.Паспортные_данные = CodeBol.Text;
                    сотрудники.Код_должности = int.Parse(CodeSotr.Text);

                    model.Entry(сотрудники).State = System.Data.Entity.EntityState.Modified;
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

                    Сотрудники сотрудники = model.Сотрудники.Where(p => p.Код_сотрудника == int.Parse(CodeDis.Text)).FirstOrDefault();

                    model.Сотрудники.Remove(сотрудники);
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            GetPred(1);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            using (Model1 model = new Model1())
            {
                var query = from s in model.Сотрудники
                            select new
                            {
                                ID = s.Код_сотрудника
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
