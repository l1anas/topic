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
    public partial class Topic5Test1 : Form
    {
		private int userId;
		private int n = 0;
        private int points = 0;
        private String[] questions = new string[10] {
                //"Продолжаете ли Вы работать после окончания рабочего дня?"
                "Какую систему компенсации  предпочтительнее использовать для\n" +
                "мотивации IT-специалистов?",
                "Какую роль играют нематериальные бонусы в системе стимулиро-\n" +
                "вания IT-персонала?",
                "Как лучше всего  использовать бонусы для поощрения результа-\n" +
                "тивности?",
                "Какой  подход к компенсации  считается наиболее  эффективным\n" +
                "для удержания талантов в IT-сфере?",
                "Какую стратегию следует выбрать для мотивации сотрудников на\n" +
                "участие в долгосрочных проектах?",
                "Как наиболее эффективно стимулировать сотрудников, работающ-\n" +
                "их удаленно?",
                "Какую  роль в системе стимулирования играют опционы на акции\n" +
                "компании для IT-специалистов?",
                "Как лучше всего  мотивировать сотрудников через систему ком-\n" +
                "пенсации в условиях жесткой конкуренции на рынке IT?",
                "Какую  роль в системе  стимулирования играет обеспечение со-\n" +
                "трудников социальными пакетами?",
                "Как лучше всего стимулировать командную работу в рамках сис-\n" +
                "темы компенсации?"};
        private String[] answer1 = new string[10] {
                "Фиксированная зарплата без бонусов и премий",
                "Нематериальные бонусы не важны, если зарплата достаточно вы-\n" +
                "сокая",
                "Не выплачивать бонусы, если сотрудники получают высокую зар-\n" +
                "плату",
                "Предлагать  высокую  начальную зарплату, но  без перспективы\n" +
                "роста",
                "Не предоставлять никаких дополнительных вознаграждений, если\n" +
                "проект является частью обязанностей сотрудников",
                "Установить  четкий график и контролировать его выполнение,не\n" +
                "предлагая дополнительных бонусов",
                "Опционы на акции не важны для сотрудников, если они получают\n" +
                "хорошие зарплаты",
                "Ограничиваться стандартной зарплатой, ориентируясь на рыноч-\n" +
                "ный уровень",
                "Социальные  пакеты не играют  значительной  роли в мотивации\n" +
                "сотрудников",
                "Выплачивать бонусы только за индивидуальные достижения",
        };
        private String[] answer2 = new string[10] {
                "Бонусная  система, где  сотрудники  получают  вознаграждение\n" +
                "только за выполнение конкретных задач",
                "Они  могут  быть  полезными, но не  влияют  на мотивацию так\n" +
                "сильно, как финансовое вознаграждение",
                "Выплачивать бонусы только в конце года по итогам работы",
                "Внедрять разовые премии вместо увеличения зарплаты",
                "Ежегодные  бонусы, основанные  на  коллективных  результатах\n" +
                "проекта",
                "Платить фиксированную зарплату независимо от результа, пола-\n" +
                "гаясь на самоорганизацию сотрудников",
                "Опционы  могут быть интересны, но их недостаточно  для повы-\n" +
                "шения вовлеченности",
                "Повышать зарплату до уровня выше среднего рынка",
                "Социальные  пакеты полезны, но  менее важны, чем  зарплата и\n" +
                "бонусы",
                "Оплачивать только результативность лидера команды, без учета\n" +
                "вклада других сотрудников",
        };
        private String[] answer3 = new string[10] {
                "Комбинированная  система: фиксированная зарплата плюс бонусы\n" +
                "за достижения",
                "Нематериальные бонусы, такие как признание, возможности обу-\n" +
                "чения и гибкий график, имеют важное значение для сотрудников",
                "Предоставлять бонусы за достижение  конкретных краткосрочных\n" +
                "целей",
                "Предлагать конкурентную зарплату с возможностями  регулярных\n" +
                "пересмотров и карьерного роста",
                "Долгосрочные бонусы за успешное завершение проектов и дости-\n" +
                "жения ключевых вех",
                "Предоставить сотрудникам  гибкий график, доверяя им в выборе\n" + 
                "рабочего времени, а также поддерживать обратную связь",
                "Это важный инструмент, который мотивирует сотрудника на дол-\n" +
                "госрочную лояльность к компании",
                "Предоставлять индивидуальные  премии за личные  достижения,а\n" +
                "также конкурентные пакеты компенсаций",
                "Это важный фактор, который усиливает общую привлекательность\n" + 
                "компании и стимулирует лояльность",
                "Предоставлять коллективные  бонусы за командные  результаты,\n" + 
                "дополнительно поощряя вклад каждого участника",
        };
		private RoundedPanel[] progressPanels;
		public Topic5Test1(int userId)
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
			button2.Hide();
            if (points <= 5)
            {
                label3.Text = $"Ваш результат: {points} баллов\n\n" +
                "Ваши подходы к компенсации и стимулированию требуют доработки.\n" +
				"Обратите  внимание на важность нематериальных бонусов, возмож-\n" +
                "ностей карьерного роста и гибких условий труда.";
            }
            else if (points >= 6 && points <= 12)
            {
                label3.Text = $"Ваш результат: {points} баллов\n\n" +
				"У вас есть некоторые эффективные стратегии, но стоит пересмот-\n" +
				"реть подходы к компенсации для долгосрочной  мотивации и удер-\n" +
                "жания сотрудников";
            }
            else if (points >= 13 && points <= 16)
            {
                label3.Text = $"Ваш результат: {points} баллов\n\n" +
                "Ваши методы компенсации и стимулирования уже работают неплохо,\n" +
                "но можно усилить акцент на коллективных бонусах и долгосрочных\n" +
                "мотивационных программах";
            }
            else if (17 <= points && points <= 20)
            {
                label3.Text = $"Ваш результат: {points} баллов\n\n" +
                "Ваша система  компенсации и стимулирования на высоком уровне,\n" +
				"и вы эффективно поддерживаете как мотивацию сотрудников,так и\n" +
                "и их долгосрочную лояльность.";
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
				command.Parameters.AddWithValue("@topicNumber", 5); // Тема 2 - Делегирование полномочий
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
            Topic5Test2 test2 = new Topic5Test2(userId);
            test2.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainWindow main = new MainWindow(userId);
            main.Show();
        }
    }
}
