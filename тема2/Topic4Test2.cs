using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static тема_1.Form1;
using MySqlConnector;

namespace тема2
{
    public partial class Topic4Test2 : Form
    {
		private int userId;
		private int n = 0;
        private int points = 0;
        private String[] questions = new string[10] {
                //"Продолжаете ли Вы работать после окончания рабочего дня?"
				"Какую стратегию лучше всего использовать для повышения\n" +
                "вовлеченности сотрудников?",
                "Какую роль играет  гибкость рабочего графика в мотива-\n" +
                "ции сотрудников?",
                "Что наиболее важно для долгосрочного удержания IT-спе-\n" +
                "циалистов?",
                "Как лучше всего демонстрировать  признание сотрудникам\n" +
                "за их достижения?",
                "Что может негативно повлиять на мотивацию IT-сотрудни-\n" +
                "ков?",
                "Как поддерживать высокую мотивацию сотрудников во вре-\n" +
                "мя длительных проектов?",
                "Какую роль играют социальные  мероприятия в  мотивации\n" +
                "команды?",
                "Какой фактор чаще всего повышает лояльность IT-сотруд-\n" +
                "ников к компании?",
                "Как мотивировать сотрудников в условиях быстрого роста\n" +
                "та компании?",
                "Какую стратегию стоит использовать для улучшения моти-\n" +
                "вации сотрудников, работающих в стрессовой среде?"};
        private String[] answer1 = new string[10] {
            //"Продолжаете ли Вы работать после окончания рабочего дня?"
			"Четко прописанные обязанности без возможности изменений",
            "Гибкий график не оказывает  значительного влияния на моти-\n" +
            "вацию",
            "Привлечение новых сотрудников для разгрузки текущих",
            "Признание не обязательно, если сотрудник  получает достой-\n" +
            "ную зарплату",
            "Долгосрочные проекты без быстрых результатов",
            "Не вмешиваться и позволить  сотрудникам самостоятельно ор-\n" +
            "ганизовать работу",
            "Социальные мероприятия  отвлекают от работы и снижают кон-\n" +
            "центрацию",
            "Увеличение количества выходных дней",
            "Поддерживать прежние условия работы без изменений",
            "Повысить требования, чтобы сотрудники  справлялись с труд-\n" +
            "ностями быстрее"
		};
        private String[] answer2 = new string[10] {
            //"Продолжаете ли Вы работать после окончания рабочего дня?"
			"Увеличение рабочего  времени для достижения  максимальной-\n" +
            "продуктивности",
			"Гибкость не критична, если работа  оплачивается выше сред-\n" +
            "него",
            "Постоянное повышение зарплаты",
            "Редкие премии за особые достижения",
            "Высокие требования к качеству работы",
            "Постоянно напоминать о финальной цели проекта",
            "Это приятно, но не оказывает  большого влияния на  продук-\n" +
            "тивность и мотивацию",
            "Ежегодные премии",
            "Привлекать внешних специалистов для распределения нагрузки",
            "Уменьшить  количество рабочих часов, но не  решать кореных\n" +
            "причин стресса"
		};
        private String[] answer3 = new string[10] {
            //"Продолжаете ли Вы работать после окончания рабочего дня?"
			"Постоянные обсуждения с сотрудниками  их карьерных целей и\n" +
			"их участие в принятии решений",
			"Это основной фактор, повышающий  удовлетворенность и моти-\n" +
			"вацию",
			"Возможности карьерного  роста, профессиональное развитие и\n" +
			"поддержка руководства",
			"Регулярные публичные признания успехов сотрудника на общих\n" +
			"собраниях",
			"Микроменеджмент и отсутствие доверия со стороны руководст-\n" +
			"ва",
			"Делить  проекты на  этапы и праздновать  успехи по мере их\n" +
			"завершения",
			"Они помогают сплотить команду и улучшить внутренние комму-\n" +
			"никации",
			"Возможности обучения и участия в профессиональных конфере-\n" +
			"нциях",
			"Создавать новые возможности для лидерства и повышения\n",
			"Предоставить сотрудникам доступ  к ресурсам для управления\n" +
			"стрессом, таким как коучинг или медитация"
		};
		private RoundedPanel[] progressPanels;

		public Topic4Test2(int userId)
        {
			this.userId = userId;
			InitializeComponent();
            label3.Hide();
            groupBox1.Hide();
            button2.Hide();
            button3.Hide();
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
			if (points <= 10)
            {
                label3.Text = $"Ваш результат: {points} баллов\n\n" +
				//"Продолжаете ли Вы работать после окончания рабочего дня?"
				"Ваши методы мотивации требуют значительных улучшений.Важно\n" + 
                "больше фокусироваться на признании, карьерных возможностях\n" +
                "и балансе между работой и личной жизнью";
            }
            else if (points >= 11 && points <= 20)
            {
                label3.Text = $"Ваш результат: {points} баллов\n\n" +
				//"Продолжаете ли Вы работать после окончания рабочего дня?"
				"У вас есть базовые идеи по мотивации, но нужно уделить бо-\n" +
                "льше внимания  индивидуальным  потребностям  сотрудников и\n" +
                "созданию более поддерживающей среды.";
            }
            else if (points >= 21 && points <= 30)
            {
                label3.Text = $"Ваш результат: {points} баллов\n\n" +
				//"Продолжаете ли Вы работать после окончания рабочего дня?"
				"Хорошие методы мотивации, но есть возможность развить под-\n" +
                "ходы к долгосрочной мотивации и созданию благоприятных ус-\n" +
                "ловий для профессионального роста";
            }
            else if (points >= 31 && points <= 40)
            {
                label3.Text = $"Ваш результат: {points} баллов\n\n" +
				//"Продолжаете ли Вы работать после окончания рабочего дня?"
				"Вы эффективно управляете  мотивацией сотрудников, создавая\n" +
                "оптимальные условия для их развития и вовлеченности";
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
				command.Parameters.AddWithValue("@testNumber", 2); // Тест 1 в теме
				command.Parameters.AddWithValue("@score", points);
				command.Parameters.AddWithValue("@maxScore", 40); // Максимальный балл для этого теста

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
            Topic4Test3 test3 = new Topic4Test3(userId);
            test3.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainWindow main = new MainWindow(userId);
            main.Show();
        }
    }
}
