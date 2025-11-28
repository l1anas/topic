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
    public partial class Topic6Test2 : Form
    {
		private int userId;
		private int n = 0;
        private int points = 0;
        private String[] questions = new string[10] {
			    "Какой первый шаг следует предпринять при обнаружении про-\n" +
		        "блем с производительностью сотрудника?",
				"Как лучше всего подойти к обсуждению проблем с поведени-\n" +
				"ем сотрудника?",
				"Как следует поступить, если сотрудник систематически  не\n" +
				"выполняет свои обязанности?",
				"Какую роль играют регулярные обратные связи в управлении\n" +
				"проблемными сотрудниками?",
				"Как следует поступать, если сотрудник неадекватно реаги-\n" +
				"рует на конструктивную критику?",
				"Как лучше всего реагировать на жалобы коллег о поведении\n" +
				"проблемного сотрудника?",
				"Какой подход наиболее эффективен для  мотивации проблем-\n" +
				"ного сотрудника к улучшению его работы?",
				"Как следует действовать, если проблемы с сотрудником  не\n" +
				"решаются после предоставления помощи и обратной связи?",
				"Какую роль играет создание позитивного рабочего  климата\n" +
				"в управлении проблемными сотрудниками?",
				"Какой метод лучше всего использовать для контроля за вы-\n" +
				"полнением плана по улучшению работы проблемного сотруд-\n" +
				"ника?"
		};
        private String[] answer1 = new string[10] {
		        "Не предлагать бонусы, если проект является частью регуля-\n" +
                "рных обязанностей",
                "Использовать обвинительный тон и критиковать действия со-\n" +
                "трудника",
                "Игнорировать проблему и надеяться, что сотрудник сам нач-\n" +
                "нет работать лучше",
                "Они не имеют большого значения, если есть официальные от-\n" +
                "четы о производительности",
                "Игнорировать его реакцию и продолжать давать  критику",
                "Игнорировать жалобы, если они не подтверждаются официаль-\n" +
                "ными отчетами",
                "Установить строгие штрафы за невыполнение  задач",
                "Немедленно уволить сотрудника без дополнительных обсужде-\n" +
                "ний",
                "Позитивный климат не имеет большого значения,  если  сот-\n" +
                "рудник нарушает правила",
                "Довериться сотруднику и не вмешиваться в процесс, если он\n" +
                "пообещал улучшение"
		};
        private String[] answer2 = new string[10] {
		        "Немедленно принять меры дисциплинарного характера",
                "Обсуждать проблему только в частном порядке, не учитывая\n" +
                "мнение самого сотрудника",
                "Вынести  предупреждение и в случае повторения  проблемы,\n" +
                "уволить сотрудника",
                "Обратные связи имеют значение т олько в случае серьезных\n" +
                "нарушений",
                "Прекратить давать критику и не принимать никаких мер",
                "Сразу принимать меры дисциплинарного  характера на осно-\n" +
                "ве жалоб",
                "Снизить рабочие нагрузки, чтобы избежать проблем в буду-\n" +
                "щем",
                "Обсудить с  сотрудником возможные варианты решения проб-\n" +
                "лемы и предложить более строгие меры",
                "Позитивный климат важен только для сотрудников с хороши-\n" +
                "ми показателями",
                "Проводить оценки только по окончании установленного сро-\n" +
                "ка без регулярного контроля"

		};
        private String[] answer3 = new string[10] {
		        "Провести беседу с сотрудником, чтобы выяснить возможные\n" +
                "причины проблем",
                "Обсуждать  проблемы в конструктивном тоне, сосредоточив\n" +
                "внимание на конкретных фактах и поведении",
                "Провести анализ причин невыполнения обязанностей и пред\n" +
                "ложить помощь или обучение для улучшения результатов",
                "Регулярные обратные связи помогают своевременно выявлять\n" +
                "проблемы и корректировать поведение",
                "Попытаться понять причины его реакции и предложить под-\n" +
				"держку для улучшения восприятия критики",
                "Исследовать жалобы, проводя беседы с  коллегами и выяс-\n" +
				"няя детали ситуации",
                "Предложить поддержку, обучение и возможности для карье-\n" +
				"рного роста при выполнении задач",
                "Продолжить  работу с сотрудником, рассматривая  возмож-\n" +
                "ность изменения его роли или задач",
                "Позитивный  рабочий климат  способствует более открытой\n" +
				"коммуникации и снижает конфликты",
                "Проводить регулярные  проверки и встречи для обсуждения\n" +
                "прогресса и предоставления обратной связи"

		};
		private RoundedPanel[] progressPanels;
		public Topic6Test2(int userId)
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
                "Вам нужно больше внимания уделить конструктивному\n"+
                "подходу  к управлению  проблемными сотрудниками и\n"+
                "улучшению коммуникации.";
            }
            else if (points >= 11 && points <= 20)
            {
                label3.Text = $"Ваш результат: {points} баллов\n\n" +
				"У вас есть некоторые хорошие практики, но стоит\n" +
				"улучшить подходы к предоставлению обратной свя-\n" +
                "зи и решению проблем.";
            }
            else if (points >= 21 && points <= 30)
            {
                label3.Text = $"Ваш результат: {points} баллов\n\n" +
                "Вы уже применяете эффективные методы управления\n"+
                "проблемными  сотрудниками, но есть  возможности\n"+
                "для дальнейшего улучшения.";
            }
            else if (points >= 31 && points <= 40)
            {
                label3.Text = $"Ваш результат: {points} баллов\n\n" +
                "Ваш подход к управлению проблемными сотрудника-\n"+
                "ми очень хорошо проработан, и вы эффективно ис-\n"+
				"пользуете стратегии для их поддержки, мотивации.";
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
				command.Parameters.AddWithValue("@topicNumber", 6); // Тема 2 - Делегирование полномочий
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
            Topic6Test3 test3 = new Topic6Test3(userId);
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
