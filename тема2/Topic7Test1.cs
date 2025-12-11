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
    public partial class Topic7Test1 : Form
    {
		private int userId;
		private int n = 0;
        private int points = 0;
        private String[] questions = new string[10] {
            	//"Продолжаете ли Вы работать после окончания рабочего дня?"
                "Какой подход наиболее эффективен для формирования команды\n" + 
                "с разнообразными навыками?",
                "Какой метод лучше всего использовать для повышения коман-\n" +
                "дного духа?",
                "Как следует управлять распределением задач внутри команды\n" + 
                "для достижения максимальной эффективности?",
                "Как лучше всего обеспечивать, чтоб члены команды понимали\n" + 
                "общие цели и задачи проекта?",
                "Как лучше всего  справляться с конфликтами  между членами\n" +
                "команды?",
                "Какой способ наиболее эффективен для обеспечения выполне-\n" +
                "ния сроков проекта?",
                "Какую роль играет  обратная связь в процессе создания эф-\n" +
                "фективной команды?",
                "Как лучше всего  подходить к созданию и поддержанию пози-\n" +
                "тивной рабочей атмосферы?",
                "Какой метод лучше всего использовать для развития и повы-\n" +
                "шения квалификации членов команды?",
                "Как следует реагировать на предложения по улучшению рабо-\n" +
                "ты от членов команды?"
        };
        private String[] answer1 = new string[10] {
                "Игнорировать проблему и надеяться, что ситуация улучшится\n" +
                "сама собой",
                "Использовать обвинительный тон и критиковать действия со-\n" +
                "трудника",
                "Игнорировать проблему и надеяться, что сотрудник сам нач-\n" +
                "нет работать лучше",
                "Они не имеют большого значения, если есть официальные от-\n" +
                "четы о производительности",
                "Игнорировать его реакцию и продолжать давать критику",
                "Игнорировать жалобы, если они не подтверждаются официаль-\n" +
                "ными отчетами",
                "Установить строгие штрафы за невыполнение задач",
                "Немедленно уволить сотрудника без дополнительных обсуждений",
                "Позитивный климат не имеет большого значения, если сотруд\n" +
                "ник нарушает правила",
                "Довериться сотруднику и не вмешиваться в процесс, если он\n" +
                "пообещал улучшение",
        };
        private String[] answer2 = new string[10] {
                "Немедленно принять меры дисциплинарного характера",
                "Обсуждать проблему  только в частном порядке, не учитывая\n" +
                "мнение самого сотрудника",
                "Вынести  предупреждение и в  случае  повторения проблемы,\n" +
                "уволить сотрудника",
                "Обратные  связи имеют значение  только в случае серьезных\n" +
                "нарушений",
                "Прекратить давать критику и не принимать никаких мер",
                "Сразу принимать меры  дисциплинарного характера на основе\n" +
                "жалоб",
                "Снизить рабочие нагрузки, чтобы избежать проблем в будущем",
                "Обсудить с сотрудником возможные варианты решения пробле-\n" +
                "мы и предложить более строгие меры",
                "Позитивный климат важен только для сотрудников с хорошими\n" +
                "показателями",
                "Проводить оценки только по окончании установленного срока\n" + 
                "без регулярного контроля",
        };
        private String[] answer3 = new string[10] {
                "Провести  беседу с сотрудником, чтобы выяснить  возможные\n" +
                "причины проблем",
                "Обсуждать  проблемы  в конструктивном  тоне, сосредоточив\n" +
                "внимание на конкретных фактах и поведении",
                "Провести анализ причин  невыполнения обязанностей и пред-\n" +
                "ложить помощь или обучение для улучшения результатов",
                "Регулярные обратные связи помогают  своевременно выявлять\n" + 
                "проблемы и корректировать поведение",
                "Попытаться понять  причины его реакции и  предложить под-\n" +
                "держку для улучшения восприятия критики",
                "Исследовать жалобы, проводя  беседы с коллегами и выясняя\n" + 
                "детали ситуации",
                "Предложить поддержку, обучение и возможности  для карьер-\n" +
                "ного роста при выполнении задач",
                "Продолжить работу с сотрудником, рассматривая возможность\n" + 
                "изменения его роли или задач",
                "Позитивный  рабочий  климат  способствует  более открытой\n" + 
                "коммуникации и снижает конфликты",
                "Проводить  регулярные  проверки и встречи  для обсуждения\n" +
                "прогресса и предоставления обратной связи",
        };
		private RoundedPanel[] progressPanels;
		public Topic7Test1(int userId)
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
				"Вам следует улучшить подходы к созданию и управлению командой.\n" +
				"Сосредоточьте внимание на эффективной  коммуникации и развитии\n" +
                "команды";
            }
            else if (points >= 6 && points <= 12)
            {
                label3.Text = $"Ваш результат: {points} баллов\n\n" +
                "Вы применяете некоторые хорошие методы, но есть возможности для\n" +
                "улучшения в управлении и взаимодействии внутри команды.";
            }
            else if (points >= 13 && points <= 16)
            {
                label3.Text = $"Ваш результат: {points} баллов\n\n" +
				"Ваши подходы к созданию эффективной команды весьма эффективны,\n" +
				"но всегда можно найти способы для дополнительного улучшения.";
            }
            else if (17 <= points && points <= 20)
            {
                label3.Text = $"Ваш результат: {points} баллов\n\n" +
				"Вы отлично справляетесь с созданием и управлением эффективной\n" +
                "командой, применяя продуманные стратегии и подходы";
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
            Topic7Test2 test2 = new Topic7Test2(userId);
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
