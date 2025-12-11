using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using static тема_1.Form1;

namespace тема2
{
	public partial class Topic3Test3 : Form
	{
		private int userId;
		private int n = 0;
		private int points = 0;
		private String[] questions = new string[10] {
			  //"Продолжаете ли Вы работать после окончания рабочего дня?"
				"Как лучше всего помочь новому сотруднику понять задачи и\n" +
				"цели компании?",
				"Какую роль играет HR в процессе адаптации нового сотруд-\n" +
				"ника?",
				"Какой метод наиболее  эффективен  для снижения стресса у\n" +
				"нового сотрудника в первые дни работы?",
				"Как можно сделать первые недели работы нового сотрудника\n" +
				"максимально комфортными?",
				"Что наиболее важно при адаптации сотрудник в мультикуль-\n" +
				"турной команде?",
				"Какую роль  играют регулярные  встречи с руководителем в\n" +
				"процессе адаптации?",
				"Как лучше всего интегрировать нового сотрудника в команду?",
				"Как важна адаптация  на уровне технологий для нового IT-\n" +
				"сотрудника?",
				"Как лучше всего помочь сотруднику,если он испытывает труд-\n" +
				"ности в адаптации?",
				"Какой из  факторов наиболее  важен для успешной  адаптации\n" +
				"нового сотрудника?"};
		private String[] answer1 = new string[10] {
			//"Продолжаете ли Вы работать после окончания рабочего дня?"
			"Попросить изучить информацию на сайте компании",
			"HR поддерживает нового сотрудника только в вопросах офор-\n" +
			"мления документов",
			"Ожидать, что сотрудник самостоятельно  адаптируется к но-\n" +
			"вому окружению",
			"Дать сотруднику  полный контроль  над задачами без вмеша-\n" +
			"тельства",
			"Не обращать  внимания на культурные  различия,ожидая, что\n" +
			"сотрудник сам адаптируется",
			"Встречи нужны только для подведения  итогов в конце испы-\n" +
			"тательного срока",
			"Ожидать, что новый  сотрудник сам наладит контакты с кол-\n" +
			"легами",
			"Сотрудник  должен сам  разобраться с инструментами в про-\n" +
			"цессе работы",
			"Подождать, пока он сам справится с проблемами",
			"Предоставление всех необходимых документов и инструкций в\n" +
			"первый день работы",
		};
		private String[] answer2 = new string[10] {
			//"Продолжаете ли Вы работать после окончания рабочего дня?"
			"Раздать  печатные  материалы о миссии  и видении компании\n" +
			"для самостоятельного изучения",
			"HR консультирует нового сотрудника только на этапе подпи-\n" +
			"сания контракта",
			"Оставить сотруднику время для освоения в собственном тем-\n" +
			"пе, без давления",
			"Попросить команду уделять  внимание новому сотруднику при\n" +
			"необходимости",
			"Дать доступ к курсам по межкультурному взаимодействию для\n" +
			"изучения в свободное время",
			"Встречи должны проходить раз в месяц для оценки работы",
			"Дать новому сотруднику время для самостоятельного знаком-\n" +
			"ства с командой",
			"Важно только  предоставить доступ к основным системам,ос-\n" +
			"тальное не критично",
			"Снизить  количество задач, чтобы  дать больше  времени на\n" +
			"адаптацию",
			"Наличие четкого плана задач и регулярной отчетности",
		};
		private String[] answer3 = new string[10] {
			//"Продолжаете ли Вы работать после окончания рабочего дня?"
			"Провести  вводную встречу с руководством, где объясняются\n" +
			"миссия и ценности компании",
			"HR  помогает решать  возникающие  вопросы, организовывает\n" +
			"вводное обучение и следит за адаптацией",
			"Назначить ментора, который будет  помогать с техническими\n" +
			"и организационными вопросами",
			"Составить четкий план задач на первые  недели и организо-\n" +
			"вать регулярные встречи с командой",
			"Ознакомить нового  сотрудника с  различиями в  культурных\n" + 
			"особенностях и нормами общения",
			"Эти встречи помогают отслеживать прогресс, выявлять труд-\n" +
			"ности на ранних этапах",
			"Организовать  командные  мероприятия и пригласить  нового\n" +
			"сотрудника активно участвовать",
			"Важно провести  обучение по использованию всех внутренних\n" +
			"систем и инструментов компании",
			"Оказать индивидуальную поддержку, выявить конкретные про-\n" +
			"блемы и предложить решения",
			"Создание  благоприятной рабочей атмосферы и открытого об-\n" +
			"щения с коллегами и руководством",
		};
		private RoundedPanel[] progressPanels;

		public Topic3Test3(int userId)
		{
			InitializeComponent();
			label3.Hide();
			groupBox1.Hide();
			button2.Hide();
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
				"Рекомендации: Вы имеете начальное представление о\n" +
				"делегировании и принятии решений. Рекомендуется изучить\n" +
				"основные концепты и подходы к делегированию. Прочитайте\n" +
				"книги или пройдите курсы по управлению, чтобы углубить \n" + "свои знания.";
			}
			else if (points >= 7 && points <= 12)
			{
				label3.Text = $"Ваш результат: {points} баллов\n" +
				"Рекомендации: У вас достаточно понимания тематики, однако\n" +
				"есть области, требующие улучшения. Сфокусируйтесь на\n" +
				"практике делегирования и принимайте участие в обсуждениях\n" +
				"по принятию решений в команде. Попробуйте применять\n" +
				"полученные знания в реальных ситуациях.\n";
			}
			else if (points >= 13 && points <= 18)
			{
				label3.Text = $"Ваш результат: {points} баллов\n" +
				"Рекомендации: Вы обладаете хорошими знаниями о\n" +
				"делегировании и процессе принятия решений. Чтобы еще\n" +
				"больше улучшить свои навыки, начните применять их на\n" +
				"практике и работайте над созданием более эффективных\n" + "команд.";
			}
			else if (points >= 19 && points <= 24)
			{
				label3.Text = $"Ваш результат: {points} баллов\n" +
				"Рекомендации: Вы эксперт в области делегирования и \n" +
				"принятия решений! Продолжайте развивать свои навыки и\n" +
				"делитесь знаниями с другими. Рассмотрите возможность\n" +
				"наставничества новых сотрудников или участия в тренингах для\n" + "развития управленческих навыков.\n";
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
				command.Parameters.AddWithValue("@topicNumber", 3); // Тема 2 - Делегирование полномочий
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
