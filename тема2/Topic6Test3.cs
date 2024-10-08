﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace тема2
{
    public partial class Topic6Test3 : Form
    {
        private int n = 0;
        private int points = 0;
        private String[] questions = new string[10] {
                "Какой подход наиболее эффективен для выявления причин\n"+"проблем с производительностью сотрудника?",
                "Как лучше всего действовать, если сотрудник демонстрирует\n"+"низкий уровень вовлеченности в проект?",
                "Какой метод следует использовать для обеспечения того,\n"+"чтобы сотрудник понял важность соблюдения сроков?",
                "Какое действие лучше всего предпринять при обнаружении\n"+"конфликтов между проблемным сотрудником и другими членами команды?",
                "Как следует поступать с сотрудником, который систематически\n"+"опаздывает на работу?",
                "Как лучше всего подходить к ситуации, когда сотрудник\n"+"демонстрирует низкую продуктивность на фоне высоких требований к работе?",
                "Какую роль играет четкая постановка целей в управлении\n"+"проблемными сотрудниками?",
                "Как следует реагировать, если проблемы с сотрудником\n"+"остаются даже после предоставления необходимой поддержки и обучения?",
                "Как можно эффективно использовать оценку 360 градусов\n"+"для управления проблемными сотрудниками?",
                "Как лучше всего обеспечить, чтобы сотрудник понял\n"+"и принял план по улучшению его работы?"
        };
        private String[] answer1 = new string[10] {
            "Сразу применять дисциплинарные меры, чтобы улучшить результаты",
            "Игнорировать его низкую вовлеченность и сосредоточиться\n"+"на других членах команды",
            "Пригрозить серьезными последствиями за несоблюдение сроков",
            "Игнорировать конфликты, полагая, что они решатся сами собой",
            "Игнорировать опоздания, если их количество незначительное",
            "Увеличить требования к сотруднику, надеясь на улучшение результатов",
            "Цели не так важны, если сотрудник знает, что от него требуется",
            "Продолжать предоставлять поддержку без внесения изменений",
            "Игнорировать отзывы коллег, если они не совпадают\n"+"с вашими собственными наблюдениями",
            "Принять план как окончательное решение и не обсуждать\n"+"его с сотрудником",
        };
        private String[] answer2 = new string[10] {
            "Оставить сотрудника наедине с его проблемами, надеясь,\n"+"что он сам их решит",
            "Увеличить рабочую нагрузку, чтобы «пригнать» сотрудника к работе",
            "Оставить сроки как есть и надеяться на лучшее",
            "Переместить сотрудника в другую команду без обсуждения конфликта",
            "Установить строгие правила и штрафы за опоздания",
            "Предлагать небольшие бонусы за работу в выходные дни",
            "Цели могут быть изменены в зависимости от текущих проблем,\n"+"что создает путаницу",
            "Уволить сотрудника, если улучшения не наблюдаются",
            "Проводить оценку только в случае серьезных проблем,\n"+"не обращая внимания на регулярные отзывы",
            "Составить план самостоятельно и требовать его выполнения\n"+"без возможности обсуждения",
        };
        private String[] answer3 = new string[10] {
            "Провести беседу с сотрудником, чтобы выяснить возможные\n"+"причины и препятствия",
            "Обсудить с сотрудником его мотивацию и предложить варианты\n"+"для улучшения вовлеченности",
            "Проводить регулярные обсуждения прогресса и предоставлять\n"+"четкие инструкции и поддержку",
            "Организовать медиаторскую встречу для обсуждения конфликтов\n"+"и поиска решений",
            "Обсудить с сотрудником возможные причины опозданий и предложить\n"+"гибкий график или другие решения",
            "Провести анализ нагрузки и предложить помощь или перераспределение\n"+"задач для улучшения продуктивности",
            "Четкие цели помогают сотруднику понять ожидания и направляют\n"+"его усилия на достижение результатов",
            "Оценить возможные изменения в его роли или задачах,\n"+"чтобы улучшить производительность",
            "Использовать отзывы как дополнительный инструмент для понимания\n"+"проблем и улучшения работы сотрудника",
            "Совместно разработать план по улучшению работы с учетом\n"+"мнения сотрудника и его проблем"
        };
        public Topic6Test3()
        {
            InitializeComponent();
            label3.Hide();
            groupBox1.Hide();
            button2.Hide();
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
            groupBox1.Hide();
            button2.Hide();
            if (points <= 6)
            {
                label3.Text = $"Ваш результат: {points} баллов\n" +
                "Вам следует пересмотреть методы управления проблемными\n"+
                "сотрудниками, сосредоточив внимание на конструктивной\n"+
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
                "можно найти способы для дополнительного улучшения подходов";
            }
            else if (points >= 19 && points <= 24)
            {
                label3.Text = $"Ваш результат: {points} баллов\n" +
                "Ваши методы управления проблемными сотрудниками хорошо\n"+
                "проработаны и эффективно решают проблемы, поддерживая\n"+
                "продуктивность и командный дух";
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
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}
