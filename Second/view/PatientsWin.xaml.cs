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
    public partial class PatientsWin : Window
    {
        private Dictionary<int, Пациенты> realtors = new Dictionary<int, Пациенты>();
        public PatientsWin()
        {
            InitializeComponent();
            GetSpec(0);
            this.WindowState = WindowState.Maximized;
        }

        private void GetSpec(int index)
        {
            using (Model1 model = new Model1())
            {

                var query = from s in model.Пациенты
                            select s;

                foreach (var item in query)
                {
                    if (item.Код_сотрудника == index)
                    {
                        CodeDis.Text = item.ФИО_пациента.ToString();
                        name.Text = item.Возраст.ToString();
                        simpt.Text = item.Пол.ToString();
                        continuied.Text = item.Адрес.ToString();
                        aftermath.Text = item.Телефон.ToString();
                        CodeLec1.Text = item.Дата_обращения.ToString();
                        CodeBol.Text = item.Код_болезни.ToString();
                        CodeSotr.Text = item.Код_сотрудника.ToString();
                        Result.Text = item.Результат_лечения.ToString();

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
                    CodeDis.Text = realtors[index + 1].ФИО_пациента.ToString();
                    name.Text = realtors[index + 1].Возраст.ToString();
                    simpt.Text = realtors[index + 1].Пол.ToString();
                    continuied.Text = realtors[index + 1].Адрес.ToString();
                    aftermath.Text = realtors[index + 1].Телефон.ToString();
                    CodeLec1.Text = realtors[index + 1].Дата_обращения.ToString();
                    CodeBol.Text = realtors[index + 1].Код_болезни.ToString();
                    CodeSotr.Text = realtors[index + 1].Код_сотрудника.ToString();
                    Result.Text = realtors[index + 1].Результат_лечения.ToString();


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
                        Пациенты пациенты = new Пациенты
                        {
                            ФИО_пациента = name.Text,
                            Возраст = int.Parse(name.Text),
                            Пол = continuied.Text,
                            Адрес = aftermath.Text,
                            Телефон = CodeLec1.Text,
                            Дата_обращения = DateTime.Parse(CodeLec1.Text),
                            Код_болезни = long.Parse(CodeBol.Text),
                            Код_сотрудника = long.Parse(CodeSotr.Text),
                            Результат_лечения = Result.Text,
                        };

                        model.Пациенты.Add(пациенты);
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
