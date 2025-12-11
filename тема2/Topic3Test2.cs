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
using тема_1;
using static тема_1.Form1;
using MySqlConnector;

namespace тема2
{
    public partial class Topic3Test2 : Form
    {
		private int userId;
		private int n = 0;
        private int points = 0;
        private String[] questions = new string[10] {
                //"Продолжаете ли Вы работать после окончания рабочего дня?"
                "Какой подход лучше всего помогает новому сотруднику адап-\n" +
                "тироваться к корпоративной культуре?",
                "Как помочь  новому сотруднику  быстро освоить  внутренние\n" +
                "процессы компании?",
                "Какую роль играет обратная связь в процессе адаптации?",
                "Как эффективно  организовать  адаптацию нового сотрудника\n" + 
                "в удаленной команде?",
                "Какой из методов является наименее эффективным для знако-\n" +
                "мства нового сотрудника с командой?",
                "Как лучше всего  организовать процесс обучения нового со-\n" +
                "трудника?",
                "Как можно помочь новому сотруднику быстрее освоить корпо-\n" +
                "ративные инструменты?",
                "Как поддерживать мотивацию сотрудника в первые недели пос-\n" +
                "ле адаптации?",
                "Какой  способ наиболее  эффективен  для выявления проблем\n" +
                "адаптации у нового сотрудника?",
                "Что следует делать, если новый сотрудник испытывает труд-\n" +
                "ности с адаптацией?"};
        private String[] answer1 = new string[10] {
            //"Продолжаете ли Вы работать после окончания рабочего дня?"
            "Ожидание, что сотрудник сам освоит культуру через выпол-\n" +
            "нение задач",
            "Попросить коллегу объяснить процессы во время работы",
            "Обратная связь  не важна, если у  сотрудника есть четкий\n" +
            "план работы",
            "Оставить  нового сотрудника  работать  удаленно без пос-\n" +
            "тоянной связи",
            "Попросить сотрудника изучить профили коллег в корпорати-\n" +
            "вной сети самостоятельно",
            "Дать возможность  сотруднику проходить  обучение по мере\n" +
            "необходимости без строгих сроков",
            "Предоставить  полный доступ ко  всем инструментам сразу,\n" +
            "не давая инструкций",
            "Дать сотруднику время для  самостоятельного освоения без\n" +
            "вмешательства",
            "Ожидать, что  сотрудник  сам сообщит о  проблемах, когда\n" +
            "они возникнут",
            "Снизить нагрузку и ожидать, что проблемы решатся сами",
        };
        private String[] answer2 = new string[10] {
            //"Продолжаете ли Вы работать после окончания рабочего дня?"
            "Ознакомление с политиками компании через документы",
            "Дать доступ к документам с описанием всех процессов",
            "Обратная связь помогает сотруднику освоить свои обязанно\n" +
            "сти только после испытательного срока",
            "Дать сотруднику возможность  самому управлять своим вре-\n" +
            "менем и задачами",
            "Привлечение сотрудника к командным проектам с первых дней",
            "Предоставить  сразу доступ к  различным обучающим  мате-\n" +
            "риалам и оставить время на их изучение",
            "Дать доступ к инструкциям по использованию  инструментов\n" + 
            "и ожидать самостоятельного освоения",
            "Дать новые сложные задачи для проверки его возможностей",
            "Опросить коллег и руководителя  через месяц после начала\n" +
            "работы",
            "Дать больше  времени для  самостоятельного освоения обя-\n" +
            "занностей",
        };
        private String[] answer3 = new string[10] {
            //"Продолжаете ли Вы работать после окончания рабочего дня?"
            "Интерактивные воркшопы  и обсуждения с коллегами, чтобы-\n" +
            "увидеть корпоративную культуру в действии.",
            "Провести  детальный  инструктаж по процессам  компании с\n" +
            "практическими примерами",
            "Обратная связь помогает корректировать действия  сотруд-\n" +
            "ника и быстрее улучшать результаты",
            "Проводить ежедневные утренние созвоны для обсуждения за-\n" +
            "дач и вопросов",
            "Организация виртуальной встречи с командой  и обсуждение\n" + 
            "общих целей",
            "Организовать пошаговое обучение с выполнением практичес-\n" +
            "ких задач под руководством наставника",
            "Организовать серию тренингов по работе  с основными инс-\n" +
            "трументами компании",
            "Проводить регулярные встречи и давать  признание за дос-\n" +
            "тигнутые успехи.",
            "Проводить регулярные встречи  для обсуждения прогресса и\n" +
            "трудностей, начиная с первой недели",
            "Поговорить  с сотрудником о  его проблемах и  предложить\n" +
            "поддержку, пересмотрев задачи",
        };
		private RoundedPanel[] progressPanels;
		public Topic3Test2(int userId)
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
			button2.Hide();
			radioButton1.Hide();
			radioButton2.Hide();
			radioButton3.Hide();
			for (int i = 0; i < progressPanels.Length; i++)
			{
				progressPanels[i].Hide();
			}
			if (points <= 10)
            {
                label3.Text = $"Ваш результат: {points} баллов\n\n" +
                "Требуется улучшение процессов адаптации,\n"+"важно уделить больше внимания поддержке новых сотрудников.";
            }
            else if (points >= 11 && points <= 20)
            {
                label3.Text = $"Ваш результат: {points} баллов\n\n" +
                "Основные принципы адаптации понимаются,\n"+"но есть пробелы, которые стоит закрыть.";
            }
            else if (points >= 21 && points <= 30)
            {
                label3.Text = $"Ваш результат: {points} баллов\n\n" +
                "Хороший уровень организации адаптации, однако\n"+"можно добавить больше обратной связи и поддержки";
            }
            else if (points >= 31 && points <= 40)
            {
                label3.Text = $"Ваш результат: {points} баллов\n\n" +
                "Отличное понимание процессов адаптации,\n"+"ваши методы могут значительно ускорить\n"+"интеграцию новых сотрудников";
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
				command.Parameters.AddWithValue("@topicNumber", 3); // Тема 2 - Делегирование полномочий
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
            Topic3Test3 test3 = new Topic3Test3(userId);
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
