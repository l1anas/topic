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
    public partial class Topic2Test3 : Form
    {
		private int userId;
		private int n = 0;
        private int points = 0;
        private String[] questions = new string[10] {
                //"Какой из следующих языков программирования наиболее
                "Какой из следующих языков программирования наиболее\n"+
                "популярен для веб-разработки?",
                "Какой метод разработки ПО предполагает итеративный\n"+
                "подход и тесное взаимодействие с клиентом?",
                "Какой инструмент управления версиями кода позволяет\n"+ 
                "отслеживать изменения и координировать разработчиков?",
                "Какое из следующих понятий связано с проектированием\n"+
                "баз данных?",
                "Какой тип тестирования ПО ориентирован на проверку\n"+ 
                "работы отдельных компонентов программы?",
                "Какой алгоритм поиска в массиве является наиболее\n"+
                "эффективным для отсортированных данных?",
                "Какой протокол используется для передачи данных по \n"+
                "сети в веб-браузере?",
                "Какой из следующих инструментов является средой\n"+
                "разработки для Python?",
                "Какой принцип ООП предполагает скрытие данных и доступ\n"+
                "к ним через методы?",
                "Какой из следующих подходов к разработке ПО помогает\n"+
                "поддерживать высокое качество кода и минимизировать ошибки?"};
        private String[] answer1 = new string[10] {
            "COBOL",
            "Водопадная модель ",
            "Trello ",
            "ООП",
            "Приемочное тестирование",
            "Поиск перебором ",
            "SMTP",
            "Eclipse",
            "Наследование",
            "Сетевой анализ",
        };
        private String[] answer2 = new string[10] {
            "PHP",
            "Итеративная модель ",
            "Jenkins ",
            "Дебаггинг",
            "Интеграционное тестирование ",
            "Линейный поиск ",
            "FTP",
            "Visual Studio Code ",
            "Полиморфизм ",
            "Прототипирование",
        };
        private String[] answer3 = new string[10] {
            "JavaScript",
            "Agile ",
            "Git",
            "Нормализация",
            "Модульное тестирование",
            "Двоичный поиск",
            "HTTP",
            "PyCharm ",
            "Инкапсуляция ",
            "Рефакторинг",
        };
		private RoundedPanel[] progressPanels;
		public Topic2Test3(int userId)
        {
			this.userId = userId;
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
			if (points <= 5)
            {
                label3.Text = $"Ваш результат: {points} баллов\n\n" +
				"Начальный уровень знаний, требуется дополнительное обучение.";
            }
            else if (points >= 6 && points <= 10)
            {
                label3.Text = $"Ваш результат: {points} баллов\n\n" +
				"Средний уровень знаний, возможно,потребуется практика и углу-\n"+
                "бленное изучение.\n";
            }
            else if (points >= 11 && points <= 15)
            {
                label3.Text = $"Ваш результат: {points} баллов\n" +
				"Хороший уровень знаний, достойный для большинства позиций  в \n"+
                "айти-сфере.\n";
            }
            else if (points >= 16 && points <= 20)
            {
                label3.Text = $"Ваш результат: {points} баллов\n" +
				"Отличный уровень знаний, подходящий для более сложных и отве-\n" +
                "тственных ролей в айти-сфере.\n";
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
				command.Parameters.AddWithValue("@topicNumber", 2); // Тема 2 - Делегирование полномочий
				command.Parameters.AddWithValue("@testNumber", 3); // Тест 1 в теме
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainWindow main = new MainWindow(userId);
            main.Show();
        }

    }
}
