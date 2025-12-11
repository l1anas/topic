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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static тема_1.Form1;

namespace тема2
{
	public partial class Topic7Test2 : Form
	{
		private int userId;
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
		public Topic7Test2(int userId)
		{
			InitializeComponent();
			label3.Hide();
			groupBox1.Hide();
			button2.Hide();
			button3.Hide();
			radioButton1.Text = "Да";
			radioButton2.Text = "Нет";
			this.FormBorderStyle = FormBorderStyle.FixedDialog;    // Фиксированные границы
			this.MaximizeBox = false;                              // Убрать кнопку максимизации
			this.MinimizeBox = false;                              // Убрать кнопку минимизации
			progressPanels = new RoundedPanel[]
			{
				roundedPanel10, roundedPanel1, roundedPanel2, roundedPanel3, roundedPanel4,
				roundedPanel5, roundedPanel6, roundedPanel7, roundedPanel8,
				roundedPanel9
			};

			UpdatePanelColors();
			this.userId = userId;
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
				command.Parameters.AddWithValue("@topicNumber", 7); // Тема 2 - Делегирование полномочий
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
			Topic7Test3 test3 = new Topic7Test3(userId);
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
