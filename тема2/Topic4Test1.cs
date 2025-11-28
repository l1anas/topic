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
	public partial class Topic4Test1 : Form
	{
		private int userId;
		private int n = 0;
		private int points = 0;
		private String[] questions = new string[10] {

				"Какой фактор является наиболее важным для мотивации IT-\n" +
				"сотрудников?",
				"Как эффективнее всего мотивировать сотрудника на удален-\n" +
				"ной работе?",
				"Что важнее всего для повышения мотивации сотрудников в IT\n" +
				"компании?",
				"Какую роль играет признание и обратная связь в мотивации\n" +
				"сотрудников?",
				"Какую мотивационную программу стоит внедрить для повыше-\n" +
				"ния вовлеченности сотрудников?",
				"Что может быть демотивирующим фактором для IT-сотрудников?",
				"Какую роль играют возможности обучения и развития в мо-\n" +
				"тивации сотрудников?",
				"Как влияет корпоративная культура на мотивацию сотрудников?",
				"Как лучше всего поддерживать мотивацию сотрудников в дол-\n" +
				"госрочной перспективе?",
				"Что является наиболее эффективным для мотивации команды в\n" +
				"условиях напряженных сроков?"};
		private String[] answer1 = new string[10] {
			"Высокая зарплата без дополнительных бонусов и гибкости",
			"Дать ему полный контроль над своим  графиком без ожиданий\n" +
			"со стороны компании",
			"Контролировать  выполнение  задач и  строго наказывать за\n" +
			"ошибки",
			"Признание  и обратная связь не  критичны, если сотрудники\n" +
			"получают свои зарплаты вовремя",
			"Введение штрафов за невыполнение планов",
			"Сложные задачи и проекты, требующие глубокого вовлечения",
			"Обучение и развитие не  оказывают сильного влияния на мо-\n" +
			"тивацию сотрудников",
			"Корпоративная культура не оказывает значительного влияния\n" +
			"на мотивацию сотрудников",
			"Постоянный контроль за выполнением задач и требований",
		  //"Продолжаете ли Вы работать после окончания рабочего дня?"
			"Увеличение рабочей нагрузки для быстрого выполнения прое-\n" +
			"кта",
		};
		private String[] answer2 = new string[10] {
		  //"Продолжаете ли Вы работать после окончания рабочего дня?"
			"Бесплатные обеды и корпоративы",
			"Устанавливать строгие  дедлайны и следить  за выполнением\n" +
			"задач",
			"Увеличить зарплату и предоставить больше выходных",
			"Обратная  связь важна, но признание не оказывает сильного\n" +
			" влияния",
			"Премии за выполнение квартальных задач",
			"Недостаток удобных рабочих мест",
			"Возможности обучения полезны, но не так важны, как бонусы",
			"Поддержка руководства  важна, но  культура в целом не так\n" +
			" значима",
			"Регулярные повышения зарплаты и премии",
			"Обещание бонусов за выполнение проекта вовремя",
		};
		private String[] answer3 = new string[10] {
		  //"Продолжаете ли Вы работать после окончания рабочего дня?"
			"Конкурентная зарплата в сочетании с  возможностями роста\n" +
			"и развития. ",
			"Поддерживать постоянную связь,предоставляя гибкий график\n"
			+"и доверяя результатам работы",
			"Предоставить новые профессиональные вызовы и проекты",
			"Это один из ключевых факторов мотивации, который показы-\n" +
			"вает сотруднику, что его вклад ценят",
			"Программу  с наградами  за успехи, карьерное  развитие и\n" +
			"обучение",
			"Отсутствие карьерного роста и профессионального развития",
			"Это один из главных стимулов для  долгосрочной мотивации\n" +
			"сотрудников",
			"Открытая и поддерживающая культура сильно повышает моти-\n" +
			"вацию и вовлеченность",
			"Постоянное развитие навыков, новые  вызовы и возможности\n" +
			"для роста",
			"Признание их усилий и предоставление ресурсов для успеш-\n" +
			"ного выполнения задачи",
		};

		private RoundedPanel[] progressPanels;
		public Topic4Test1(int userId)
		{
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
			  //"Продолжаете ли Вы работать после окончания рабочего дня?"
				"Подходы к мотивации требуют пересмотра.Нужно обратить вни-\n" +
				"мание на признание,возможности для развития и гибкость ус-\n" +
				"ловий.";
			}
			else if (points >= 6 && points <= 12)
			{
				label3.Text = $"Ваш результат: {points} баллов\n\n" +
			  //"Продолжаете ли Вы работать после окончания рабочего дня?"
				"Вы  используете некоторые эффективные методы  мотивации,но \n" +
				"есть пространство для роста, особенно в части поддержки во-\n" +
				"влеченности и развития сотрудников";
			}
			else if (points >= 13 && points <= 16)
			{
				label3.Text = $"Ваш результат: {points} баллов\n\n" +
			  //"Продолжаете ли Вы работать после окончания рабочего дня?"
				"У вас хорошие методы мотивации, но можно усилить  акцент\n" +
				"на обучении, поддержке  и создании благоприятной  корпо-\n" +
				"ративной культуры";
			}
			else if (17 <= points && points <= 20)
			{
				label3.Text = $"Ваш результат: {points} баллов\n\n" +
				   //"Продолжаете ли Вы работать после окончания рабочего дня?"
					"Отличный  уровень организации мотивации персонала. Ваш\n" +
					"подход стимулирует как профессиональное развитие,так и\n" +
					"личную удовлетворенность сотрудников";
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
				command.Parameters.AddWithValue("@topicNumber", 4); // Тема 2 - Делегирование полномочий
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
			Topic4Test2 test2 = new Topic4Test2(userId);
			test2.Show();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.Hide();
			MainWindow main = new MainWindow(userId);
			main.Show();
		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}
	}
}
