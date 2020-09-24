using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpertSystemWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            float BallFlegmatik = 0;  // Объявляем переменные для каждого вида темперамента
            float BallMelanholik = 0;
            float BallHolerik = 0;
            float BallSangvinik = 0;
            int count = 0; // Для подсчёта положительных ответов

            //  Вопросы в тесте относящиеся к темпераменту флегматика: 1, 5, 9, 13, 17

            //Вопросы в тесте относящиеся к темпераменту меланхолика: 2, 6, 10, 14, 18

            //Вопросы в тесте относящиеся к темпераменту холерика: 3, 7, 11, 15, 19

            //Вопросы в тесте относящиеся к темпераменту сангвиника: 4, 8, 12, 16, 20


            if (radioButton1.Checked) { BallFlegmatik ++; count++; } // Вопрос 1
                                                                     // Считаем баллы по темпераменту и считаем общее число положительных ответов 



            if (radioButton5.Checked) { BallMelanholik++; count++; } // Вопрос 2
            // Считаем баллы по темпераменту и считаем общее число положительных ответов 



            if (radioButton7.Checked) { BallHolerik++; count++; } // Вопрос 3
                                                                    // Считаем баллы по темпераменту и считаем общее число положительных ответов 




            if (radioButton9.Checked) { BallSangvinik++; count++; } // Вопрос 4
                                                                    // Считаем баллы по темпераменту и считаем общее число положительных ответов 



            if (radioButton11.Checked) { BallFlegmatik++; count++; } // Вопрос 5
                                                                    // Считаем баллы по темпераменту и считаем общее число положительных ответов 



            if (radioButton13.Checked) { BallMelanholik++; count++; } // Вопрос 6
            // Считаем баллы по темпераменту и считаем общее число положительных ответов 



            if (radioButton15.Checked) { BallHolerik++; count++; } // Вопрос 7
                                                                  // Считаем баллы по темпераменту и считаем общее число положительных ответов 




            if (radioButton3.Checked) { BallSangvinik++; count++; } // Вопрос 8
                                                                    // Считаем баллы по темпераменту и считаем общее число положительных ответов 


            if (radioButton17.Checked) { BallFlegmatik++; count++; } // Вопрос 9
                                                                    // Считаем баллы по темпераменту и считаем общее число положительных ответов 



            if (radioButton19.Checked) { BallMelanholik++; count++; } // Вопрос 10
            // Считаем баллы по темпераменту и считаем общее число положительных ответов 



            if (radioButton21.Checked) { BallHolerik++; count++; } // Вопрос 11
                                                                  // Считаем баллы по темпераменту и считаем общее число положительных ответов 




            if (radioButton23.Checked) { BallSangvinik++; count++; } // Вопрос 12
                                                                    // Считаем баллы по темпераменту и считаем общее число положительных ответов 


            if (radioButton25.Checked) { BallFlegmatik++; count++; } // Вопрос 13
                                                                    // Считаем баллы по темпераменту и считаем общее число положительных ответов 



            if (radioButton27.Checked) { BallMelanholik++; count++; } // Вопрос 14
            // Считаем баллы по темпераменту и считаем общее число положительных ответов 



            if (radioButton29.Checked) { BallHolerik++; count++; } // Вопрос 15
                                                                  // Считаем баллы по темпераменту и считаем общее число положительных ответов 




            if (radioButton31.Checked) { BallSangvinik++; count++; } // Вопрос 16
                                                                    // Считаем баллы по темпераменту и считаем общее число положительных ответов 


            if (radioButton33.Checked) { BallFlegmatik++; count++; } // Вопрос 17
                                                                    // Считаем баллы по темпераменту и считаем общее число положительных ответов 



            if (radioButton37.Checked) { BallMelanholik++; count++; } // Вопрос 18
            // Считаем баллы по темпераменту и считаем общее число положительных ответов 



            if (radioButton39.Checked) { BallHolerik++; count++; } // Вопрос 19
                                                                  // Считаем баллы по темпераменту и считаем общее число положительных ответов 




            if (radioButton41.Checked) { BallSangvinik++; count++; } // Вопрос 20
                                                                    // Считаем баллы по темпераменту и считаем общее число положительных ответов 






            BallFlegmatik = BallFlegmatik / count * 100; // Вычисляем процентный состав темперамента человека
            BallMelanholik = BallMelanholik / count * 100;
            BallHolerik = BallHolerik / count * 100;
            BallSangvinik = BallSangvinik / count * 100;

            int Flegmatik = Convert.ToInt32(BallFlegmatik); // Преобразуем переменные в int чтобы результат был целым
            int Melanholik = Convert.ToInt32(BallMelanholik);
            int Holerik = Convert.ToInt32(BallHolerik);
            int Sangvinik = Convert.ToInt32(BallSangvinik);

            label22.Text = $"По результатам теста вы Флегматик на {Flegmatik}% " +
                $"Меланхолик на {Melanholik}% Холерик на {Holerik}% Сангвинник на {Sangvinik}%";

            Func<ChartPoint, string> labelPoint = chartPoint =>
               string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            pieChart1.Series = new SeriesCollection
            {new PieSeries{
                Title = "Флегматик",
                Values = new ChartValues<int> {Flegmatik},
                DataLabels = true,
                LabelPoint = labelPoint
            }, new PieSeries{
                Title = "Меланхолик",
                Values = new ChartValues<int> {Melanholik},
                DataLabels = true,
                LabelPoint = labelPoint
            }, new PieSeries{
                Title = "Холерик",
                Values = new ChartValues<int> {Holerik},
                DataLabels = true,
                LabelPoint = labelPoint
            }, new PieSeries{
                Title = "Сангвинник",
                Values = new ChartValues<int> {Sangvinik},
                DataLabels = true,
                LabelPoint = labelPoint
            }};

            pieChart1.LegendLocation = LegendLocation.Bottom;

        }

  
        private void pieChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int a = 10;

            
            int t = 17; 
        }
    }
}
