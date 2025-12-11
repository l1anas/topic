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
    public partial class Topic6Test3 : Form
    {
		private int userId;
		private int n = 0;
        private int points = 0;
        private String[] questions = new string[10] {
		    "Какой первичный шаг следует предпринять при работе с сот-\n" +
            "рудником, который систематически нарушает правила команды?",
            "Как лучше всего подходить к решению проблемы, если сотруд-\n" +
            "ник не справляется с поставленными задачами?",
            "Какой метод наиболее эффективен для изменения  негативно-\n" +
            "го отношения сотрудника к своей работе?",
            "Как лучше всего отслеживать и оценивать прогресс сотрудни-\n" +
            "ка, который работает над улучшением своей производитель-\n" +
            "ности?",
            "Как следует поступить, если сотрудник систематически опа-\n" +
            "здывает на работу?",
            "Какой подход лучше всего использовать для поддержки  сот-\n" +
            "рудника, который испытывает трудности в выполнении работы\n" +
            "из-за личных проблем?",
            "Какую роль играет создание четкого, справедливого процес-\n" +
            "са для решения проблемных ситуаций?",
            "Как лучше всего  справляться с ситуацией, когда сотрудник\n" +
			"не принимает критику конструктивно?",
            "Какой метод лучше всего использовать для обеспечения того,\n" +
            "чтобы сотрудник понял важность выполнения своих обязанно-\n" +
            "стей?",
            "Как следует действовать, если проблемы с сотрудником про-\n" +
            "должаются, несмотря на все предпринятые усилия?"
		};
        private String[] answer1 = new string[10] {

			"Наложить  немедленное наказание, чтобы предотвратить пов-\n" +
			"торение",
            "Дать сотруднику время для  самостоятельного  исправления-\n" +
            "ситуации без дополнительной поддержки",
            "Применять наказания за негативное отношение",
            "Проводить периодические  проверки без регулярного монито-\n" +
            "ринга",
            "Игнорировать опоздания, если это не  влияет на работу ко-\n" +
			"манды",
            "Игнорировать личные проблемы и сосредоточиться  только на\n" +
            "рабочих результатах",
            "Процесс не имеет большого значения, если результаты явля-\n" +
            "ются основным приоритетом",
            "Продолжать давать критику, не обращая внимания на реакцию\n" +
            "сотрудника",
            "Дать сотруднику  свободу в выполнении  задач без  строгих\n" +
			"тре бований",
            "Продолжить  работу с сотрудником без внесения  изменений,\n" +
			"полагаясь на улучшение ситуации со временем"
		};
        private String[] answer2 = new string[10] {
			"Сообщить команде о нарушении, чтобы создать давление на\n" +
			"сотрудника",
			"Перегруппировать  задачи сотруднику и увеличить рабочую\n" +
			"нагрузку",
			"Игнорировать отношение сотрудника и сосредоточиться на\n" +
			"выполнении его задач",
			"Оценивать прогресс только по итогам выполнения крупно-\n" +
			"го проекта",
			"Установить  строгие правила и штрафы за опоздания, без\n" +
			"обсуждения с сотрудником",
			"Потребовать, чтобы сотрудник решал личные проблемы вне\n" +
			"рабочее время, не предлагая поддержки",
			"Процесс решения проблем может быть гибким и изменчивым\n" +
			"в зависимости от ситуации",
			"Прекратить давать критические замечания и сосредоточи-\n" +
			"ться на положительных аспектах работы",
			"Периодически  напоминать сотруднику о его обязанностях\n" +
			"без конкретных целей",
			"Завершить  сотрудничество с сотрудником, не рассматри-\n" +
			"вая другие варианты"
		};
        private String[] answer3 = new string[10] {
			"Провести индивидуальную беседу с сотрудником для выяс-\n" +
			"нения причин нарушения правил",
            "Предложить дополнительные ресурсы или помощь, чтобы по\n" +
			"мочь сотруднику улучшить результаты",
            "Обсудить с сотрудником причины его негативного отноше-\n" +
			"ния и предложить пути решения",
            "Установить  регулярные встречи и отчеты для отслежива-\n" +
			"ния прогресса и предоставления обратной связи",
            "Обсудить с сотрудником последствия опозданий и предло-\n" +
			"жить решения для улучшения его пунктуальности",
            "Предложить  гибкий график или временную  помощь, чтобы\n" +
			"помочь сотруднику справиться с трудностями",
            "Четкий  процесс помогает  обеспечить справедливость  и\n" +
            "последовательность при решении проблемных ситуаций",
            "Попробовать  изменить подход к критике, делая ее более\n" +
            "конструктивной и конкретной",
            "Установить  четкие и измеримые цели и регулярно прове-\n" +
			"рять их выполнение",
            "Оценить возможности для изменения роли  сотрудника или\n" +
            "его задач, чтобы найти более подходящую позицию"

		};
		private RoundedPanel[] progressPanels;
		public Topic6Test3(int userId)
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
                "Вам следует пересмотреть методы управления проблемными\n"+
                "сотрудниками, сосредоточив внимание на  конструктивной\n"+
                "коммуникации и поддержке";
            }
            else if (points >= 7 && points <= 12)
            {
                label3.Text = $"Ваш результат: {points} баллов\n" +
                "У вас есть несколько правильных подходов, но стоит\n"+
                "улучшить стратегии и методы для более эффективного\n"+
                "управления проблемами";
            }
            else if (points >= 13 && points <= 18)
            {
                label3.Text = $"Ваш результат: {points} баллов\n" +
                "Вы применяете эффективные методы управления, но всегда\n"+
                "можно найти способы для дополнительного улучшения под-\n" +
                "ходов";
            }
            else if (points >= 19 && points <= 24)
            {
                label3.Text = $"Ваш результат: {points} баллов\n" +
                "Ваши методы управления проблемными сотрудниками хорошо\n"+
                "проработаны и  эффективно решают проблемы, поддерживая\n"+
                "продуктивность и командный дух";
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
				command.Parameters.AddWithValue("@topicNumber", 6); // Тема 2 - Делегирование полномочий
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
