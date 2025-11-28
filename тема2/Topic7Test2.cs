using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static тема_1.Form1;

namespace тема2
{
	public partial class Topic7Test2 : Form
	{
		private int n = 0;
		private int points = 0;
		private String[] questions = new string[10] {
				"Является ли разнообразие навыков и опыта членов команды\n"+
				"важным для ее эффективности?",
				"Регулярные командные мероприятия и совместные обсуждения\n"+
				"помогают улучшить взаимодействие в команде?",
				"Распределение задач по компетенциям каждого члена команды\n"+
				"способствует лучшему выполнению работы?",
				"Регулярные встречи для обсуждения целей и прогресса проекта\n"+
				"помогают команде оставаться в курсе и достигать целей?",
				"Игнорирование конфликтов в команде может привести к их\n"+"самостоятельному разрешению?",
				"Реалистичное определение сроков и регулярный мониторинг\n"+"прогресса помогают команде соблюдать дедлайны?",
				"Регулярная обратная связь помогает членам команды понимать\n"+"свои сильные и слабые стороны?",
				"Открытое общение и признание достижений сотрудников способствуют\n"+"поддержанию позитивной рабочей атмосферы?",
				"Предоставление возможностей для обучения и карьерного роста важно\n"+"для развития членов команды?",
				"Рассмотрение предложений по улучшению работы от членов команды\n"+"может помочь в оптимизации рабочих процессов?"};
		
		private RoundedPanel[] progressPanels;
		public Topic7Test2()
		{
			InitializeComponent();
			label3.Hide();
			groupBox1.Hide();
			button2.Hide();
			button3.Hide();
			radioButton1.Text = "Да";
			radioButton2.Text = "Нет";
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
			label3.Visible = true;
			label3.Text = questions[n];
			groupBox1.Visible = true;
			button2.Visible = true;
			n++;
		}
		private void ShowAnswer(int p)
		{
			label2.Hide();
			radioButton1.Hide();
			radioButton2.Hide();
			for (int i = 0; i < progressPanels.Length; i++)
			{
				progressPanels[i].Hide();
			}
			button2.Hide();
			if (points <= 3)
			{
				label3.Text = $"Ваш результат: {points} баллов\n\n" +
				"Требуется развитие навыков создания команды";
			}
			else if (points >= 4 && points <= 7)
			{
				label3.Text = $"Ваш результат: {points} баллов\n\n" +
				"Средний уровень понимания, есть над чем поработать";
			}
			else if (points >= 8 && points <= 10)
			{
				label3.Text = $"Ваш результат: {points} баллов\n\n" +
				"Высокий уровень знаний по созданию эффективной команды";
			}
			button3.Visible = true;
		}
		private void NextQuestion(int num)
		{
			if (num < 10)
			{
				label2.Text = (n + 1).ToString() + "/10";
				label3.Text = questions[n];
				UpdatePanelColors();

			}
			if (num == 10)
				ShowAnswer(points);
			radioButton1.Checked = false;
			radioButton2.Checked = false;
			n++;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (!radioButton1.Checked && !radioButton2.Checked)
			{
				MessageBox.Show("Выберите один из вариантов ответа");
				return;
			}
			if (radioButton1.Checked)
			{
				points++;
				NextQuestion(n);
			}
			else if (radioButton2.Checked)
			{
				NextQuestion(n);
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.Hide();
			Topic7Test3 test3 = new Topic7Test3();
			test3.Show();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.Hide();
			MainWindow main = new MainWindow(1);
			main.Show();
		}

		private void label3_Click(object sender, EventArgs e)
		{

		}
	}
}
