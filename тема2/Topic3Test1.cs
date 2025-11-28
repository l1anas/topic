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
	public partial class Topic3Test1 : Form
	{
		private int n = 0;
		private int points = 0;
		private String[] questions = new string[10] {
				"Какой фактор является ключевым для успешной адаптации\n"+
				"нового сотрудника в IT-компании?",
				"Какова роль наставника (ментора) в процессе адаптации?",
				"Какую роль играют тимбилдинги в адаптации сотрудников?",
				"Как лучше всего ознакомить нового сотрудника с корпо-\n" +
				"ративной культурой компании?",
				"Какой лучший способ измерить успешность адаптации но-\n" +
				"вого сотрудника?",
				"Что наиболее важно в первый день нового сотрудника в\n" +
				"компании?",
				"Какой подход наиболее эффективен для введения сотруд-\n" +
				"ника в работу над проектами?",
				"Как адаптировать удаленного сотрудника к рабочим про-\n" +
				"цессам?",
				"Как справиться с трудностями адаптации у нового сотру-\n" +
				"дника?",
				"Как мотивировать нового сотрудника в процессе адаптации?"};
		private String[] answer1 = new string[10] {

			"Полная самостоятельность с первого дня",
			"Ментор назначается для помощи в технических вопросах",
			"Тимбилдинги не влияют на адаптацию сотрудников",
			"Передать  корпоративную  книгу и попросить изучить её\n" +
			"самостоятельно",
			"Оценить эффективность работы через месяц",
			"Оставить  нового сотрудника в свободном режиме на са-\n" +
			"мастоятельное освоение.",
			"Погрузить его в основную задачу команды с первого дня",
			"Ожидать, что он быстро освоится, так как работает уда-\n" +
			"ленно",
            //"Какой из следующих языков программирования наиболее
            "Оставить сотрудника справляться с трудностями самосто-\n" +
			"ятельно, чтобы ускорить адаптацию",
			"Предоставить премии за быструю интеграцию в работу",
		};
		private String[] answer2 = new string[10] {
            //"Какой из следующих языков программирования наиболее
            "Прохождение формальных обучающих курсов перед началом\n" +
			"работы",
			"Ментор должен контролировать сотрудника на протяжении\n" +
			"всего испытательного срока",
			"Тимбилдинги нужны только для повышения мотивации сот-\n" +
			"рудников",
			"Показать видеоролики с корпоративными мероприятиями и\n" +
			"интервью с руководством",
			"Оценить выполнение KPI через первые три месяца работы",
			"Дать доступ ко всем  системам и объяснить текущие за-\n" +
			"дачи",
			"Предоставить доступ ко всем проектам для ознакомления\n" +
			"без конкретных задач",
			"Устанавливать регулярные еженедельные встречи для об-\n" +
			"суждения общих вопросов",
			"Дать больше времени на освоение и снизить нагрузку",
			"Проводить регулярные тренинги и встречи для улучшения\n" +
			"навыков",
		};
		private String[] answer3 = new string[10] {
            //"Какой из следующих языков программирования наиболее
            "Постепенное  вовлечение в задачи команды с поддержкой\n" +
			"ментора",
			"Ментор помогает  новому сотруднику  интегрироваться в\n" +
			"команду и разобраться с рабочими процессами",
			"Тимбилдинги  улучшают взаимодействия в команде и соз-\n" +
			"дают благоприятной атмосферы",
			"Организовать  серию встреч  с ключевыми  сотрудниками\n" +
			"для передачи ценностей  компании и обсуждения их",
			"Проводить  регулярные встречи и  опросы сотрудника и\n" +
			"команды, чтобы оценить его интеграцию.",
			"Ознакомить  с рабочей  средой, командой и корпоратив-\n" +
			"ными процессами",
			"Постепенно  вводить с отрудника в проекты,  начиная с\n" +
			"более простых задач",
			"Организовать постоянную связь через  видеоконференции\n" +
			"и мессенджеры для вовлечения в процессы",
			"Оказать  дополнительную поддержку и  организовать об-\n" +
			"ратную связь для выявления сложностей",
			"Создать  благоприятную  атмосферу, регулярно отмечать\n" +
			"достижения и давать позитивную обратную связь",
		};

		private RoundedPanel[] progressPanels;
		public Topic3Test1()
		{
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
			button2.Hide();
			radioButton1.Hide();
			radioButton2.Hide();
			radioButton3.Hide();
			for (int i = 0; i < progressPanels.Length; i++)
			{
				progressPanels[i].Hide();
			}
			if (points <= 5)
			{
				label3.Text = $"Ваш результат: {points} баллов\n\n" +
				"Ваши методы адаптации требуют доработки,\n" + "стоит уделить больше внимания поддержке сотрудников";
			}
			else if (points >= 6 && points <= 12)
			{
				label3.Text = $"Ваш результат: {points} баллов\n\n" +
				"У вас есть понимание адаптационных процессов,\n" + "но есть возможности для улучшения.";
			}
			else if (points >= 13 && points <= 16)
			{
				label3.Text = $"Ваш результат: {points} баллов\n\n" +
				"Хорошие процессы адаптации, но есть моменты,\n" + "которые можно усилить для большего эффекта";
			}
			else if (17 <= points && points <= 20)
			{
				label3.Text = $"Ваш результат: {points} баллов\n\n" +
					"Превосходные методы адаптации, сотрудники смогут\n" + "быстро и успешно интегрироваться в команду.";
			}
			button3.Visible = true;
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
			Topic3Test2 test2 = new Topic3Test2();
			test2.Show();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.Hide();
			MainWindow main = new MainWindow(1);
			main.Show();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}
	}
}
