using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using тема2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static тема_1.Form1;
using static тема2.MainWindow;

namespace тема_1
{
	public partial class Test3 : Form
	{
		private int n = 0;
		private int points = 0;
		private String[] questions = new string[10] {
				//"Продолжаете ли Вы работать после окончания рабочего дня?
				"Что такое делегирование полномочий?",
				"Какой из следующих факторов не влияет на делегирование?",
				"Какой из этих навыков особенно важен для успешного\n"+" делегирования?",
				"Какой этап не входит в процесс принятия решений?",
				"Какой из следующих методов можно использовать для оценки\n"+"альтернативных решений?  ",
				"Какой из следующих вариантов является преимуществом\n" + "делегирования?",
				"Что может стать причиной неудачи в делегировании полномочий?",
				"Как называется процесс, при котором руководитель проверяет\n"+ "выполнение задания после делегирования?",
				"Что из следующего не является признаком эффективного\n"+"делегирования?",
				"Какая из приведённых стратегий может помочь в принятии\n"+"сложных решений?"};
		private String[] answer1 = new string[10] {
			"Отказ от выполнения обязанностей  ",
			"Уровень доверия к подчинённым",
			"Умение избегать общения",
			"Определение проблемы",
			"Демонстрация силы",
			"Увеличение рабочей нагрузки для руководителя",
			"Чёткие инструкции",
			"Процесс планирования",
			"Сотрудник понимает свои обязанности",
			"Подход «все или ничего»",
		};
		private String[] answer2 = new string[10] {
			"Принятие судьбоносных решений",
			"Степень сложности задачи",
			"Умение контролировать всех сотрудников",
			"Генерация альтернатив ",
			"Эмоциональное восприятие",
			"Замедление принятия решений",
			"Доверие к команде ",
			"Оценка эффективности ",
			"Сотрудник чувствует себя уверенным в своих действиях",
			"Игнорирование собственных эмоций",
		};
		private String[] answer3 = new string[10] {
			"Передача задач другим сотрудникам",
			"Количество сотрудников в компании ",
			"Умение ясно формулировать задачи",
			"Игнорирование последствий",
			"SWOT-анализ",
			"Повышение мотивации подчинённых",
			"Неопределённость в задачах",
			"Контроль",
			"Сотрудник постоянно обращается за консультацией",
			"Использование коллективного мнения",
		};
		private RoundedPanel[] progressPanels;
		public Test3()
		{
			InitializeComponent();
			groupBox1.Hide();
			button2.Hide();
			progressPanels = new RoundedPanel[]
			{
				roundedPanel10, roundedPanel1, roundedPanel2, roundedPanel3, roundedPanel4,
				roundedPanel5, roundedPanel6, roundedPanel7, roundedPanel8,
				roundedPanel9
			};

			UpdatePanelColors();
		}
		private void UpdatePanelColors()
		{
			for (int i = 0; i < progressPanels.Length; i++)
			{
				if (i < n)
				{
					progressPanels[i].BackColor = Color.DimGray;
				}
				else
				{
					progressPanels[i].BackColor = Color.Silver;
				}
			}
		}
		private void Button1_Click(object sender, EventArgs e)
		{
			label2.Text = (n + 1).ToString() + "/10";
			Button1.Hide();
			radioButton1.Text = answer1[n];
			radioButton2.Text = answer2[n];
			radioButton3.Text = answer3[n];
			groupBox1.Visible = true;
			button2.Visible = true;
			n++;
		}
		private void ShowAnswer(int p)
		{
			
			label2.Hide();
			button2.Hide();
			radioButton1.Hide();
			radioButton2.Hide();
			radioButton3.Hide();
			for (int i = 0; i < progressPanels.Length; i++)
			{
				progressPanels[i].Hide();
			}
			if (points <= 6)
			{
				label3.Text = $"Ваш результат: {points} баллов\n" +
				
				"Рекомендации: Вы имеете начальное представление о делегирова-\n" +
				"нии и принятии решений. Рекомендуется изучить основные конце-\n" +
				"пты и подходы к делегированию. Прочитайте  книги или пройдите\n" +
				"курсы по управлению, чтобы углубить свои знания.";
			}
			else if (points >= 7 && points <= 12)
			{
				label3.Text = $"Ваш результат: {points} баллов\n" +
				"Рекомендации: У вас достаточно понимания тематики, однако есть\n" +
				"области, требующие улучшения. Сфокусируйтесь на практике деле-\n" +
				"гирования и принимайте участие в обсуждениях по принятию реше-\n" +
				"ний в команде. Попробуйте применять полученные знания в реаль-\n" +
				"ных ситуациях.\n";
			}
			else if (points >= 13 && points <= 18)
			{
				label3.Text = $"Ваш результат: {points} баллов\n" +
				"Рекомендации: Вы обладаете хорошими знаниями о делегировании \n" +
				"и процессе принятия решений. Чтобы еще больше  улучшить свои \n" +
				"навыки, начните применять их на практике и работайте  над со-\n" +
				"зданием более эффективных команд.";
			}
			else if (points >= 19 && points <= 24)
			{
				label3.Text = $"Ваш результат: {points} баллов\n" +
				//Похоже, что делегирование полномочий и ответственности пред-\n
				"Рекомендации: Вы эксперт в области делегирования  и  принятия\n" +
				"решений! Продолжайте развивать свои навыки и делитесь знания-\n" +
				"ми с другими.Рассмотрите возможность наставничества новых со-\n" +
				"трудников или участия в тренингах для развития управленческих\n" +
				"навыков.\n";
			}
		}
		private void NextQuestion(int num)
		{
			if (num < 10)
			{
				label2.Text = (n + 1).ToString() + "/10";
				label3.Text = questions[n];
				radioButton1.Text = answer1[n];
				radioButton2.Text = answer2[n];
				radioButton3.Text = answer3[n];
				UpdatePanelColors();
			}
			if (num == 10)
				ShowAnswer(points);
			radioButton1.Checked = false;
			radioButton2.Checked = false;
			radioButton3.Checked = false;
			n++;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked)
			{
				MessageBox.Show("Выберите один из вариантов ответа");
				return;
			}
			if (radioButton1.Checked)
			{
				NextQuestion(n);
			}
			else if (radioButton2.Checked)
			{
				points++;
				NextQuestion(n);
			}
			else if (radioButton3.Checked)
			{
				points = points + 2;
				NextQuestion(n);
			}
		}


		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.Hide();
			MainWindow main = new MainWindow(1);
			main.Show();
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{

		}
		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{

		}
		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{

		}
	}
}
