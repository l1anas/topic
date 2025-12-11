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
    public partial class Topic5Test3 : Form
    {
		private int userId;
		private int n = 0;
        private int points = 0;
        private String[] questions = new string[10] {
				"Как лучше всего структурировать систему премирования для IT\n" +
                "команды, pаботающей над проектом с четкими сроками?",
                "Какой подход наиболее эффективен для стимулирования сотруд-\n" +
                "ников, работающих над инновационными разработками?",
                "Какую роль играют регулярные пересмотры  заработной платы в\n" +
                "системе компенсации?",
                "Как лучше всего использовать систему опционов для привлече-\n" +
                "ния талантливых сотрудников?",
                "Какой метод  стимулирования  будет наиболее эффективным для\n" +
                "удержания сотрудников в условиях быстро меняющегося рынка?",
                "Как лучше всего  компенсировать сотрудников за работу в вы-\n" +
                "ходные и праздничные дни?",
                "Какую роль играют корпоративные мероприятия и тимбилдинги в\n" +
                "системе стимулирования?",
                "Как лучше всего  управлять системой  вознаграждений для со-\n" +
                "труддников, работающих над проектами с высокой степенью не-\n" +
				"определенности?",
                "Какую стратегию следует использовать для компенсации сотру-\n" +
                "дников, работающих над многозадачными проектами?",
                "Как можно улучшить систему компенсации для сотрудников, ко-\n" +
                "торые работают над долгосрочными проектами?"
		};
        private String[] answer1 = new string[10] {
			    "Не предлагать премии, если проект является частью обычной\n" +
                "работы",
                "Не предоставлять дополнительных вознаграждений за иннова-\n" +
                "ции, полагаясь на основную зарплату",
                "Пересмотры зарплаты не нужны, если зарплата изначально вы-\n" +
                "сокая",
                "Не использовать  опционы в системе компенсации, полагаясь\n" +
                "только на денежные вознаграждения",
                "Увеличивать рабочее время  и требования для повышения про\n" +
                "дуктивности",
                "Оплачивать работу в выходные дни  по обычной ставке",
                "Корпоративные мероприятия  не имеют значительного влияния\n" +
                "на мотивацию",
                "Не предлагать  бонусов, сосредоточив внимание на основной\n" +
                "зарплате",
                "Не предоставлять  дополнительных вознаграждений за много-\n" +
                "задачность",
                "Не  предлагать  никаких дополнительных  вознаграждений за\n" +
                "долгосрочные проекты"
		};
        private String[] answer2 = new string[10] {
			    "Предоставлять премии только после завершения  проекта",
                "Выплачивать бонусы за количество созданных  идей, незави-\n" +
                "симо от их реализации",
                "Пересмотры  зарплаты не так важны, если есть дополнителн-\n" +
                "ные бонусы и премии",
                "Предлагать  опционы только  для топ-менеджеров и ключевых\n" +
                "специалистов",
                "Предлагать бонусы за достижения и результаты  работы",
                "Предлагать небольшие бонусы за работу в выходные  дни",
                "Тимбилдинги полезны, но не так важны, как финансовое воз-\n" +
                "награждение",
                "Предлагать фиксированные бонусы за  выполнение задач, не-\n" +
                "смотря на неопределенность",
                "Выплачивать бонусы за количество выполненных  задач",
                "Предоставлять одноразовую премию в конце  проекта"
		};
        private String[] answer3 = new string[10] {
				"Устанавливать промежуточные премии за выполнение ключевых\n" +
                "этапов и достижение определенных результатов",
                "Предлагать премии за успешную реализацию и внедрение  ин-\n" +
                "новационных идей в продукцию",
                "Регулярные пересмотры зарплаты помогают поддерживать  мо-\n" +
                "тивацию сотрудников, учитывая их рост и достижения",
                "Включать опционы в пакеты вознаграждений для всех сотруд-\n" +
                "ников, чтобы стимулировать долгосрочную лояльность",
                "Создавать возможности для профессионального роста и  обу-\n" +
                "чения, что поможет адаптироваться к изменениям",
                "Предоставлять двойную оплату или дополнительные  выходные\n" +
                "дни в обмен на работу в праздничные дни",
                "Они способствуют укреплению  командного духа и  повышению\n" +
                "мотивации сотрудников",
                "Устанавливать бонусы и вознаграждения на основе достигну-\n" +
                "тых результатов и успешных решений проблем",
                "Предоставлять премии за успешное  выполнение всех задач в\n" +
                "рамках одного проекта",
                "Предлагать  регулярные маленькие  бонусы за промежуточные\n" +
                "результаты и достижения"

		};
		private RoundedPanel[] progressPanels;
		public Topic5Test3(int userId)
        {
			this.userId = userId;
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
                "Ваши методы компенсации и стимулирования нуждаются в улучшении.\n"+
                "Рассмотрите возможность внедрения промежуточных бонусов\n"+
                "и дополнительных льгот для повышения мотивации";
            }
            else if (points >= 7 && points <= 12)
            {
                label3.Text = $"Ваш результат: {points} баллов\n" +
                "У вас есть некоторые эффективные подходы, но стоит\n"+
                "обратить внимание на элементы, которые могут улучшить\n"+
                "долгосрочную мотивацию и адаптацию к изменениям";
            }
            else if (points >= 13 && points <= 18)
            {
                label3.Text = $"Ваш результат: {points} баллов\n" +
                "Ваши методы компенсации и стимулирования уже показывают\n"+
                "хорошие результаты, но можно усилить акцент на инновации,\n"+
                "профессиональном росте и регулярных вознаграждениях";
            }
            else if (points >= 19 && points <= 24)
            {
                label3.Text = $"Ваш результат: {points} баллов\n" +
                "Ваша система компенсации и стимулирования очень\n"+
                "хорошо разработана, эффективно поддерживает мотивацию\n"+
                "сотрудников и способствует их долгосрочной лояльности";
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
				command.Parameters.AddWithValue("@topicNumber", 5); // Тема 2 - Делегирование полномочий
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
    }
}
