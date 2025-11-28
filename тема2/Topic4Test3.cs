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
using static тема_1.Form1;

namespace тема2
{
	public partial class Topic4Test3 : Form
	{
		private int userId;
		private int n = 0;
		private int points = 0;
		private String[] questions = new string[10] {
				//"Продолжаете ли Вы работать после окончания рабочего дня?"
				"Какой фактор чаще всего вызывает у IT-сотрудников чув-\n" +
				"ство удовлетворенности на работе?",
				"Как эффективнее всего мотивировать сотрудников к повы-\n" +
				"шению их квалификации?",
				"Как  лучше всего  поощрять IT-сотрудников за  успехи в\n" +
				"выполнении сложных проектов?",
				"Какую роль играют карьерные перспективы в мотивации со\n" +
				"трудников?",
				"Какую мотивационную стратегию лучше всего использовать\n" + 
				"для сотрудников, которые испытывают выгорание?",
				"Как мотивация  через признание влияет на  результатив-\n" +
				"ность команды?",
				"Как мотивировать  сотрудников на работу в условиях не-\n" +
				"определенности?",
				"Что лучше всего помогает удерживать талантливых сотруд\n" +
				"ников в IT-компании?",
				"Как можно мотивировать команду в условиях жестких сро-\n" +
				"ков проекта?",
				"Что может  улучшить мотивацию  сотрудников к участию в\n" +
				"корпоративных инициативах?"
		};
		private String[] answer1 = new string[10] {				
			//"Продолжаете ли Вы работать после окончания рабочего дня?"
			"Минимальный объем работы без больших нагрузок",
			"Обязательные внутренние курсы повышения квалификации",
			"Отсутствие изменений в условиях работы",
			"Карьерный рост не важен, если зарплата высокая",
			"Усилить контроль за выполнением задач, чтобы устранить\n" +
			"пробелы в работе",
			"Признание не оказывает существенного влияния, если зар\n" +
			"плата достойная",
			"Усиливать контроль и регламентировать все процессы",
			"Стабильные условия работы без изменений",
			"Увеличить количество рабочих часов до выполнения прое-\n" +
			"кта",
			"Принуждение к участию для повышения общего духа компа-\n" +
			"нии",
		};
		private String[] answer2 = new string[10] {
			//"Продолжаете ли Вы работать после окончания рабочего дня?"
			"Постоянные премии и материальные бонусы",
			"Ежегодная проверка навыков с целью контроля качества",
			"Присуждение премий и бонусов",
			"Это дополнительный, но не самый важный аспект мотивации",
			"Увеличить бонусы за производительность, чтобы стимули-\n" +
			"ровать активность",
			"Признание полезно, но не влияет наn долгосрочную моти-\n" +
			"вацию",
			"Постоянно  предоставлять им точные указания и инструк-\n" +
			"ции",
			"Высокая зарплата и ежегодные бонусы",
			"Вводить дополнительные премии за выполнение задач рань\n" +
			"ше срока",
			"Периодические обязательные мероприятия с фиксированными\n" +
			"наградами",
		};
		private String[] answer3 = new string[10] {
			//"Продолжаете ли Вы работать после окончания рабочего дня?"
			"Вовлеченность в интересные проекты и задачи",
			"Предоставление доступа к обучающим материалам и поддерж-\n" +
			"ка инициативы сотрудников",
			"Предоставление новых возможностей для роста и профессио-\n" +
			"нальных вызовов",
			"Это ключевой фактор, который помогает сотрудникам чувст-\n" +
			"вовать себя значимыми,мотивированными на долгую работу",
			"Обеспечить временный отдых и предложить  возможности для\n" +
			"перезагрузки через обучение или новые задачи",
			"Это помогает повысить самооценку сотрудников и способст-\n" +
			"вует их стремлению достигать больших целей",
			"Поддерживать их автономию, предоставляя доверие и ресур-\n" + 
			"сы для выполнения задач",
			"Возможности карьерного роста и  профессионального разви-\n" +
			"тия",
			"Усилить командное  взаимодействие и признание за  каждую\n" +
			"завершенную задачу",
			"Развитие  инициатив, основанных на  интересах  самих со-\n" +
			"трудников"
		};
		private RoundedPanel[] progressPanels;

		public Topic4Test3(int userId)
		{
			InitializeComponent();
			label3.Hide();
			groupBox1.Hide();
			button2.Hide();
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
			if (points <= 6)
			{
				label3.Text = $"Ваш результат: {points} баллов\n" +
				//"Продолжаете ли Вы работать после окончания рабочего дня?"
				"Ваши методы мотивации нуждаются в пересмотре. Следует боль-\n" +
				"ьше внимания уделять развитию сотрудников и созданию благо-\n" +
				"приятной атмосферы.";
			}
			else if (points >= 7 && points <= 12)
			{
				label3.Text = $"Ваш результат: {points} баллов\n" +
				//"Продолжаете ли Вы работать после окончания рабочего дня?"
				"Ваши подходы к мотивации полезны, но есть место для улучше-\n" +
				"ний в области карьерного роста и гибкости рабочих условий.";
			}
			else if (points >= 13 && points <= 18)
			{
				label3.Text = $"Ваш результат: {points} баллов\n" +
				//"Продолжаете ли Вы работать после окончания рабочего дня?"
				"У вас хорошие практики мотивации, но можно больше акценти-\n" +
				"вать внимание на профессиональном развитии и признании до-\n" +
				"стижений сотрудников.";
			}
			else if (points >= 19 && points <= 24)
			{
				label3.Text = $"Ваш результат: {points} баллов\n" +
				//"Продолжаете ли Вы работать после окончания рабочего дня?"
				"Ваши методы мотивации эффективны, и вы создаете благоприят-\n" +
				"ную среду для роста и вовлеченности команды";
			}
			SaveTestResult();
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
				command.Parameters.AddWithValue("@topicNumber", 4); // Тема 2 - Делегирование полномочий
				command.Parameters.AddWithValue("@testNumber", 3); // Тест 1 в теме
				command.Parameters.AddWithValue("@score", points);
				command.Parameters.AddWithValue("@maxScore", 24); // Максимальный балл для этого теста

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
