using Microsoft.VisualBasic.ApplicationServices;
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
	public partial class Topic2Test1 : Form
	{
		private int n = 0;
		private int points = 0;
		private int userId;
		private String[] questions = new string[10] {

				"Что такое Agile?",
				"Что обозначает термин 'MVC' в веб-разработке?",
				"Что такое Git?",
				"Какова основная цель использования Docker?",
				"Что такое REST API?",
				"Какой из этих языков считается объектно-ориентированным?",
				"Что такое CI/CD?",
				"Какова основная функция кэша?",
				"Что обозначает принцип DRY?",
				"Что такое SQL?"};
		private String[] answer1 = new string[10] {

			"Это методология, предназначенная для улучшения работы\n"+"аппаратного обеспечения",
			"Мобильная версия сайта",
			"Программа для автоматизации тестирования кода",
			"Создание виртуальных машин",
			"Язык программирования для работы с API",
			"SQL",
			"Это среда для разработки программного обеспечения",
			"Защита данных от несанкционированного доступа",
			"\"Don't Run Yourself\" — оптимизация производительности\n"+ "программ",
			"Это библиотека для работы с базами данных в Python.",
		};
		private String[] answer2 = new string[10] {

			"Это набор принципов управления проектами, который включает\n"+"гибкие подходы к разработке",
			"Методы валидации данных для веб-форм",
			"Язык программирования для работы с данными",
			"Упрощение разработки мобильных приложений",
			"Протокол передачи данных между веб-сервисами",
			"HTML",
			"Это система для управления версиями кода",
			"Хранение данных для экономии памяти",
			"\"Define, Repeat, Yield\" — цикл обработки данных в\n"+ "многопоточности",
			"Это программа для создания баз данных",
		};
		private String[] answer3 = new string[10] {

			"Это подход к разработке программного обеспечения,\n"+
			"основанный на гибкости и тесном взаимодействии с клиентом",
			"Модель, вид и контроллер, представляющие архитектурный\n"+
			"паттерн для создания приложений",
			"Система управления версиями программного обеспечения",
			"Изоляция приложений с использованием контейнеров для\n"+
			"более легкой развертки и масштабирования",
			"Архитектурный стиль, использующий HTTP для взаимодействия\n" +"между системами",
			"Python",
			"Это процессы для постоянной интеграции и непрерывной\n"+
			"доставки кода",
			"Ускорение доступа к часто используемым данным, временно\n"+
			"храня их в памяти. ",
			"\"Don't Repeat Yourself\" — избегание дублирования кода\n"+
			"для улучшения читаемости и поддерживаемости",
			"Это язык программирования для работы с базами данных",
		};

		private RoundedPanel[] progressPanels;
		public Topic2Test1(int userId)
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
		private void button1_Click(object sender, EventArgs e)
		{
			label2.Text = (n + 1).ToString() + "/10";
			button1.Hide();
			label3.Visible = true;
			label3.Text = questions[n];
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
			radioButton1.Hide();
			radioButton2.Hide();
			radioButton3.Hide();
			for (int i = 0; i < progressPanels.Length; i++)
			{
				progressPanels[i].Hide();
			}
			button2.Hide();
			if (points <= 5)
			{
				label3.Text = $"Ваш результат: {points} баллов\n\n" +
				"Вам необходимы базовые знания и навыки в IT-сфере.";
			}
			else if (points >= 6 && points <= 12)
			{
				label3.Text = $"Ваш результат: {points} баллов\n\n" +
				"Имеются частичные знания, но требуется больше практики и обу-\n" +
				"чения.\n";
			}
			else if (points >= 13 && points <= 16)
			{
				label3.Text = $"Ваш результат: {points} баллов\n\n" +
				"Достаточные знания для старта, можно развивать навыки в конк-\n" +
				"ретной области.";
			}
			else if (17 <= points && points <= 20)
			{
				label3.Text = $"Ваш результат: {points} баллов\n\n" +
					"Отличный результат, подходите для работы в IT-сфере!";
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
				command.Parameters.AddWithValue("@testNumber", 1); // Тест 1 в теме
				command.Parameters.AddWithValue("@score", points);
				command.Parameters.AddWithValue("@maxScore", 20); // Максимальный балл для этого теста

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

		private void button3_Click(object sender, EventArgs e)
		{
			this.Hide();
			Topic2Test2 test2 = new Topic2Test2(userId);
			test2.Show();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.Hide();
			MainWindow main = new MainWindow(userId);
			main.Show();
		}

		private void Topic2Test1_Load(object sender, EventArgs e)
		{

		}
	}
}
