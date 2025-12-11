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
using static тема_1.Form1;
using MySqlConnector;

namespace тема_1
{
	public partial class Test2 : Form
	{
		private int n = 0;
		private int points = 0;
		private int userId; // Добавляем ID пользователя

		private String[] questions = new string[10] {
			"Как Вы обычно реагируете на задачи, требующие делегирования?",
			"Как Вы принимаете решения в вашей работе?",
			"Как Вы относитесь к идеи, что ваши подчинённые могут\n"+"важные задачи?",
			"Как Вы реагируете, если ваши решения вызывают критику?",
			"Как Вы отзываете свои делегированные задачи?",
			"Как Вы выбираете, кому делегировать задание?",
			"Как Вы воспринимаете свою роль как руководителя в вопросах\n"+"делегирования?",
			"Как часто Вы анализируете результаты принятых решений?",
			"Как Вы относитесь к предложениям команды в процессе\n"+"принятия решений?",
			"Как Вы реагируете на ошибки, допущенные подчинёнными?"};

		private String[] answer1 = new string[10] {
			"Я предпочитаю делать все сам ",
			"Опираюсь только на собственный опыт ",
			"Я сомневаюсь в их способности",
			"Игнорирую критику",
			"Проверяю только в конце",
			"Опираюсь на личные симпатии",
			"Я единственный, кто несет ответственность",
			"Не делаю этого",
			"Считаю, что такое не нужно",
			"Вижу это как повод для критики",
		};

		private String[] answer2 = new string[10] {
			"Делаю, но чувствую себя неуверенно",
			"Учитываю мнения нескольких коллег",
			"Иногда позволяю, но контролирую каждое действие",
			"Анализирую, но не принимаю во внимание мнения других ",
			"Проверяю иногда",
			"Выбираю только тех, кто меньше загружен",
			"Я контролирую, но иногда позволяю другим участвовать",
			"Редко, только если что-то пошло не так",
			"Прислушиваюсь, но редко пользуюсь их мнением",
			"Приложу усилия, чтобы исправить их",
		};

		private String[] answer3 = new string[10] {
			"Делаю, если доверяю кому-то",
			"Применяю систематический подход и анализ данных",
			"Доверяю, но остаюсь на связи",
			"Слушаю критику и готов обсудить  ",
			"Проверяю регулярно, но без излишнего контроля ",
			"Оцениваю навыки и опыт ",
			"Я делегирую и обучаю своих сотрудников",
			"Обычно делаю это, чтобы учиться на опыте",
			"Учитываю, если они мне нравятся ",
			"Обсуждаю ошибки и вывожу уроки",
		};

		private String[] answer4 = new string[10] {
			"Открыт к делегированию и чувствую себя комфортно",
			"Обсуждаю с командой и принимаю решение вместе ",
			"Полностью доверяю и поддерживаю их инициативу",
			"Использую критику как возможность для улучшения",
			"Поддерживаю открытость и общение в процессе выполнения",
			"Учитываю сильные стороны команды и их интересы",
			"Я считаю, что роль руководителя - это поддержка и развитие\n"+ "команды",
			"Всегда, чтобы постоянно улучшать процесс",
			"Всегда обсуждаю и включаю в процесс",
			"Воспринимаю ошибки как часть обучения",
		};

		private RoundedPanel[] progressPanels;

		// Конструктор с передачей ID пользователя
		public Test2(int userId = 0)
		{
			this.userId = userId;
			InitializeComponent();
			label2.Hide();
			groupBox1.Hide();
			button2.Hide();
			button3.Hide();
			this.FormBorderStyle = FormBorderStyle.FixedDialog;    // Фиксированные границы
			this.MaximizeBox = false;                              // Убрать кнопку максимизации
			this.MinimizeBox = false;                              // Убрать кнопку минимизации

			progressPanels = new RoundedPanel[]
			{
				roundedPanel10, roundedPanel1, roundedPanel2, roundedPanel3, roundedPanel4,
				roundedPanel5, roundedPanel6, roundedPanel7, roundedPanel8, roundedPanel9
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
			Button1.Hide();
			label2.Visible = true;
			label2.Text = questions[n];
			radioButton5.Text = answer1[n];
			radioButton6.Text = answer2[n];
			radioButton7.Text = answer3[n];
			radioButton8.Text = answer4[n];
			groupBox1.Visible = true;
			button2.Visible = true;
			n++;
		}

		private void ShowAnswer(int p)
		{
			radioButton5.Hide();
			radioButton6.Hide();
			radioButton7.Hide();
			radioButton8.Hide();
			roundButton2.Hide();

			for (int i = 0; i < progressPanels.Length; i++)
			{
				progressPanels[i].Hide();
			}

			string resultText = "";
			if (points <= 10)
			{
				resultText = $"Ваш результат: {points} баллов\n" +
				"Рекомендации: Вам стоит рассмотреть возможность улучшения ва-\n" +
				"ших навыков делегирования и  принятия решений. Попробуйте на-\n" +
				"чать с небольших задач, которые вы можете делегировать, и об-\n" +
				"ращайте  внимание на то, как  другие справляются с ними. Изу-\n" +
				"чите  литературу на тему эффективных методов  делегирования и\n" +
				"управления.";
			}
			else if (points >= 11 && points <= 20)
			{
				resultText = $"Ваш результат: {points} баллов\n" +
				"Рекомендации: У вас есть определенные навыки, но есть еще над\n" +
				"чем работать. Начните открыто обсуждать с командой важные ре-\n" +
				"шения, экспериментируйте с  делегированием и учитесь на своих\n" +
				"ошибках. Открытость к критике и  вовлечение  команды  поможет\n" +
				"вам развиваться в данной области.\n";
			}
			else if (points >= 21 && points <= 30)
			{
				resultText = $"Ваш результат: {points} баллов\n" +
				"Рекомендации: Вы на правильном пути! У вас достаточно уверен-\n" +
				"ности в делегировании и  принятии решений. Продолжайте разви-\n" +
				"вать свои  навыки, обучая других и создавая более эффективные\n" +
				"рабочие процессы. Рассмотрите возможность участия в тренингах\n" +
				"по управлению и лидерству для дальнейшего роста.";
			}
			else if (points >= 31 && points <= 40)
			{
				resultText = $"Ваш результат: {points} баллов\n" +
				"Рекомендации: Вы  обладаете высокими навыками делегирования и\n" +
				"принятия решений. Продолжайте  действовать в этом направлении\n" +
				"и развивайте свою команду. Рассмотрите  возможность наставни-\n" +
				"чества и  делегирования  еще  более значительных задач, чтобы\n" +
				"помочь вашему коллективу расти и развиваться.\n";
			}

			label2.Text = resultText;

			// Сохраняем результат в базу данных
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
				command.Parameters.AddWithValue("@topicNumber", 1); // Тема 1 - Делегирование полномочий
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
				label2.Text = questions[n];
				radioButton5.Text = answer1[n];
				radioButton6.Text = answer2[n];
				radioButton7.Text = answer3[n];
				radioButton8.Text = answer4[n];
				UpdatePanelColors();
			}
			if (num == 10)
				ShowAnswer(points);

			radioButton5.Checked = false;
			radioButton6.Checked = false;
			radioButton7.Checked = false;
			radioButton8.Checked = false;
			n++;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (!radioButton5.Checked && !radioButton6.Checked && !radioButton7.Checked && !radioButton8.Checked)
			{
				MessageBox.Show("Выберите один из вариантов ответа");
				return;
			}

			if (radioButton5.Checked)
			{
				NextQuestion(n);
			}
			else if (radioButton6.Checked)
			{
				points++;
				NextQuestion(n);
			}
			else if (radioButton7.Checked)
			{
				points = points + 2;
				NextQuestion(n);
			}
			else if (radioButton8.Checked)
			{
				points = points + 3;
				NextQuestion(n);
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.Hide();
			Test3 test3 = new Test3(userId); 
			test3.Show();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.Hide();
			MainWindow main = new MainWindow(userId);
			main.Show();
		}

		private void Test2_Load(object sender, EventArgs e) { }
		private void radioButton2_CheckedChanged(object sender, EventArgs e) { }
		private void label3_Click(object sender, EventArgs e) { }
		private void radioButton3_CheckedChanged(object sender, EventArgs e) { }
		private void groupBox1_Enter(object sender, EventArgs e) { }
	}
}