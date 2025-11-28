using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using тема_1;
using static тема_1.Form1;

namespace тема2
{
	public partial class Topic2Test2 : Form
	{
		private int n = 0;
		private int points = 0;
		private int userId;
		private String[] questions = new string[10] {
				
				"Имеете ли Вы опыт работы с языком программирования\n"+"Python не менее 2-х лет?",
				"Знаете ли Вы основы работы с базами данных (например, SQL)?",
				"Работали ли Вы с системами контроля версий (например, Git)?\n",
				"Имеете ли Вы опыт разработки веб-приложений?",
				"Знакомы ли Вы с методологиями разработки ПО, такими\n"+ "как Agile или Scrum?  ",
				"Готовы ли Вы к обучению новым технологиям и языкам\n"+"программирования?",
				"Имеете ли Вы опыт работы в команде разработчиков?\n",
				"Участвовали ли Вы в открытых проектах или программировании\n"+ "с использованием GitHub?",
				"Знаете ли Вы принципы тестирования и отладки кода?",
				"Способны ли Вы разрабатывать документацию для своего кода?"};

		private RoundedPanel[] progressPanels;
		public Topic2Test2(int userId)
		{
			this.userId = userId;
			InitializeComponent();
			label3.Hide();
			groupBox1.Hide();
			button2.Hide();
			button3.Hide();
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
			button2.Hide();
			if (points <= 3)
			{
				label3.Text = $"Ваш результат: {points} баллов\n\n" +
				"Низкий уровень квалификации.Рекомендуется дополнительное обу-\n"
				+"чение.\n";
			}
			else if (points >= 4 && points <= 6)
			{
				label3.Text = $"Ваш результат: {points} баллов\n\n" +
					"Средний уровень квалификации. Возможно, потребуется обучение.";
			}
			else if (points >= 7 && points <= 10)
			{
				label3.Text = $"Ваш результат: {points} баллов\n\n" +
					"Высокий уровень квалификации.\n" + "Кандидат подходит для ра-\n" +
					"боты.";
			}
			SaveTestResult();
			button3.Visible = true;
		}

		private void SaveTestResult()
		{
			if (userId == 0)
			{
				MessageBox.Show("Не удалось сохранить результат: пользователь не идентифицирован", "Информация",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			BDConnection database = new BDConnection();

			try
			{
				database.openConnection();

				// Сохраняем результат теста
				string query = @"INSERT INTO test_results (user_id, topic_number, test_number, score, max_score) 
                       VALUES (@userId, @topicNumber, @testNumber, @score, @maxScore)";

				MySqlCommand command = new MySqlCommand(query, database.getConnection());
				command.Parameters.AddWithValue("@userId", userId);
				command.Parameters.AddWithValue("@topicNumber", 2); // Тема 2 - Делегирование полномочий
				command.Parameters.AddWithValue("@testNumber", 2); // Тест 1 в теме
				command.Parameters.AddWithValue("@score", points);
				command.Parameters.AddWithValue("@maxScore", 10); // Максимальный балл для этого теста

				int rowsAffected = command.ExecuteNonQuery();

				if (rowsAffected > 0)
				{
					Console.WriteLine("Результат теста успешно сохранен в базу данных");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка сохранения результата теста: {ex.Message}", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				database.closeConnection();
			}
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
				MessageBox.Show("Выберите вариант 'да' или 'нет'");
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
			Topic2Test3 test3 = new Topic2Test3(userId);
			test3.Show();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.Hide();
			MainWindow main = new MainWindow(userId);
			main.Show();
		}

		private void label3_Click(object sender, EventArgs e)
		{

		}
	}
}
