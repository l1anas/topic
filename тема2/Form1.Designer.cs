﻿using System.Drawing.Drawing2D;
using static тема2.MainWindow;

namespace тема_1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			label1 = new Label();
			label2 = new Label();
			button1 = new Button();
			label3 = new Label();
			groupBox1 = new RoundedGroupBox();
			roundedPanel9 = new RoundedPanel();
			roundedPanel8 = new RoundedPanel();
			roundedPanel7 = new RoundedPanel();
			roundedPanel6 = new RoundedPanel();
			roundedPanel5 = new RoundedPanel();
			roundedPanel4 = new RoundedPanel();
			roundedPanel3 = new RoundedPanel();
			roundedPanel2 = new RoundedPanel();
			roundedPanel1 = new RoundedPanel();
			roundedPanel10 = new RoundedPanel();
			radioButton2 = new RadioButton();
			radioButton1 = new RadioButton();
			button2 = new RoundButton();
			button3 = new Button();
			pictureBox1 = new PictureBox();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.BackColor = Color.Transparent;
			label1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label1.ForeColor = Color.Black;
			label1.Location = new Point(475, 52);
			label1.Margin = new Padding(5, 0, 5, 0);
			label1.Name = "label1";
			label1.Size = new Size(809, 36);
			label1.TabIndex = 0;
			label1.Text = "Тест №1: делегирование полномочий и принятие решений";
			// 
			// label2
			// 
			label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			label2.AutoSize = true;
			label2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label2.Location = new Point(801, 189);
			label2.Margin = new Padding(5, 0, 5, 0);
			label2.Name = "label2";
			label2.Size = new Size(162, 36);
			label2.TabIndex = 1;
			label2.Text = "Тест 1 из 3";
			// 
			// button1
			// 
			button1.Anchor = AnchorStyles.None;
			button1.Location = new Point(738, 322);
			button1.Margin = new Padding(5);
			button1.Name = "button1";
			button1.Size = new Size(314, 74);
			button1.TabIndex = 2;
			button1.Text = "Начать тест 1";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// label3
			// 
			label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			label3.AutoSize = true;
			label3.Font = new Font("Times New Roman", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label3.ForeColor = Color.FromArgb(64, 64, 64);
			label3.Location = new Point(47, 112);
			label3.Margin = new Padding(5, 0, 5, 0);
			label3.Name = "label3";
			label3.Size = new Size(973, 42);
			label3.TabIndex = 3;
			label3.Text = "Продолжаете ли Вы работать после окончания рабочего дня?";
			// 
			// groupBox1
			// 
			groupBox1.Anchor = AnchorStyles.None;
			groupBox1.BackColor = Color.Transparent;
			groupBox1.Controls.Add(roundedPanel9);
			groupBox1.Controls.Add(roundedPanel8);
			groupBox1.Controls.Add(roundedPanel7);
			groupBox1.Controls.Add(roundedPanel6);
			groupBox1.Controls.Add(roundedPanel5);
			groupBox1.Controls.Add(roundedPanel4);
			groupBox1.Controls.Add(roundedPanel3);
			groupBox1.Controls.Add(roundedPanel2);
			groupBox1.Controls.Add(roundedPanel1);
			groupBox1.Controls.Add(roundedPanel10);
			groupBox1.Controls.Add(radioButton2);
			groupBox1.Controls.Add(radioButton1);
			groupBox1.Controls.Add(button2);
			groupBox1.Controls.Add(label3);
			groupBox1.CornerRadius = 60;
			groupBox1.Location = new Point(300, 163);
			groupBox1.Margin = new Padding(5);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(5);
			groupBox1.Size = new Size(1160, 647);
			groupBox1.TabIndex = 4;
			groupBox1.TabStop = false;
			// 
			// roundedPanel9
			// 
			roundedPanel9.BackColor = Color.Silver;
			roundedPanel9.CornerRadius = 20;
			roundedPanel9.ForeColor = SystemColors.AppWorkspace;
			roundedPanel9.Location = new Point(913, 67);
			roundedPanel9.Name = "roundedPanel9";
			roundedPanel9.Size = new Size(80, 20);
			roundedPanel9.TabIndex = 15;
			// 
			// roundedPanel8
			// 
			roundedPanel8.BackColor = Color.Silver;
			roundedPanel8.CornerRadius = 20;
			roundedPanel8.ForeColor = SystemColors.AppWorkspace;
			roundedPanel8.Location = new Point(818, 67);
			roundedPanel8.Name = "roundedPanel8";
			roundedPanel8.Size = new Size(80, 20);
			roundedPanel8.TabIndex = 14;
			// 
			// roundedPanel7
			// 
			roundedPanel7.BackColor = Color.Silver;
			roundedPanel7.CornerRadius = 20;
			roundedPanel7.ForeColor = SystemColors.AppWorkspace;
			roundedPanel7.Location = new Point(723, 67);
			roundedPanel7.Name = "roundedPanel7";
			roundedPanel7.Size = new Size(80, 20);
			roundedPanel7.TabIndex = 13;
			// 
			// roundedPanel6
			// 
			roundedPanel6.BackColor = Color.Silver;
			roundedPanel6.CornerRadius = 20;
			roundedPanel6.ForeColor = SystemColors.AppWorkspace;
			roundedPanel6.Location = new Point(628, 67);
			roundedPanel6.Name = "roundedPanel6";
			roundedPanel6.Size = new Size(80, 20);
			roundedPanel6.TabIndex = 12;
			// 
			// roundedPanel5
			// 
			roundedPanel5.BackColor = Color.Silver;
			roundedPanel5.CornerRadius = 20;
			roundedPanel5.ForeColor = SystemColors.AppWorkspace;
			roundedPanel5.Location = new Point(533, 67);
			roundedPanel5.Name = "roundedPanel5";
			roundedPanel5.Size = new Size(80, 20);
			roundedPanel5.TabIndex = 11;
			// 
			// roundedPanel4
			// 
			roundedPanel4.BackColor = Color.Silver;
			roundedPanel4.CornerRadius = 20;
			roundedPanel4.ForeColor = SystemColors.AppWorkspace;
			roundedPanel4.Location = new Point(438, 67);
			roundedPanel4.Name = "roundedPanel4";
			roundedPanel4.Size = new Size(80, 20);
			roundedPanel4.TabIndex = 10;
			// 
			// roundedPanel3
			// 
			roundedPanel3.BackColor = Color.Silver;
			roundedPanel3.CornerRadius = 20;
			roundedPanel3.ForeColor = SystemColors.AppWorkspace;
			roundedPanel3.Location = new Point(343, 67);
			roundedPanel3.Name = "roundedPanel3";
			roundedPanel3.Size = new Size(80, 20);
			roundedPanel3.TabIndex = 9;
			// 
			// roundedPanel2
			// 
			roundedPanel2.BackColor = Color.Silver;
			roundedPanel2.CornerRadius = 20;
			roundedPanel2.ForeColor = SystemColors.AppWorkspace;
			roundedPanel2.Location = new Point(248, 67);
			roundedPanel2.Name = "roundedPanel2";
			roundedPanel2.Size = new Size(80, 20);
			roundedPanel2.TabIndex = 8;
			// 
			// roundedPanel1
			// 
			roundedPanel1.BackColor = Color.Silver;
			roundedPanel1.CornerRadius = 20;
			roundedPanel1.ForeColor = SystemColors.AppWorkspace;
			roundedPanel1.Location = new Point(153, 67);
			roundedPanel1.Name = "roundedPanel1";
			roundedPanel1.Size = new Size(80, 20);
			roundedPanel1.TabIndex = 7;
			// 
			// panel1
			// 
			roundedPanel10.BackColor = Color.Silver;
			roundedPanel10.CornerRadius = 20;
			roundedPanel10.ForeColor = SystemColors.AppWorkspace;
			roundedPanel10.Location = new Point(58, 67);
			roundedPanel10.Name = "roundedPanel10";
			roundedPanel10.Size = new Size(80, 20);
			roundedPanel10.TabIndex = 6;
			// 
			// radioButton2
			// 
			radioButton2.AutoSize = true;
			radioButton2.Font = new Font("Times New Roman", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 204);
			radioButton2.ForeColor = Color.FromArgb(64, 64, 64);
			radioButton2.Location = new Point(52, 317);
			radioButton2.Margin = new Padding(5);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new Size(121, 53);
			radioButton2.TabIndex = 1;
			radioButton2.TabStop = true;
			radioButton2.Text = "Нет";
			radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			radioButton1.AutoSize = true;
			radioButton1.Font = new Font("Times New Roman", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 204);
			radioButton1.ForeColor = Color.FromArgb(64, 64, 64);
			radioButton1.Location = new Point(52, 257);
			radioButton1.Margin = new Padding(5);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new Size(101, 53);
			radioButton1.TabIndex = 0;
			radioButton1.TabStop = true;
			radioButton1.Text = "Да";
			radioButton1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			button2.Anchor = AnchorStyles.None;
			button2.BackColor = Color.YellowGreen;
			button2.Font = new Font("Times New Roman", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
			button2.ForeColor = Color.FromArgb(64, 64, 64);
			button2.Location = new Point(758, 493);
			button2.Margin = new Padding(5);
			button2.Name = "button2";
			button2.Size = new Size(336, 98);
			button2.TabIndex = 5;
			button2.Text = "Вперед";
			button2.UseVisualStyleBackColor = false;
			button2.Click += button2_Click;
			// 
			// button3
			// 
			button3.Anchor = AnchorStyles.None;
			button3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
			button3.Location = new Point(730, 851);
			button3.Margin = new Padding(5);
			button3.Name = "button3";
			button3.Size = new Size(322, 74);
			button3.TabIndex = 6;
			button3.Text = "Перейти к тесту 2";
			button3.UseVisualStyleBackColor = true;
			button3.Click += button3_Click;
			// 
			// pictureBox1
			// 
			pictureBox1.BackColor = Color.Transparent;
			pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
			pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
			pictureBox1.ErrorImage = null;
			pictureBox1.InitialImage = null;
			pictureBox1.Location = new Point(21, 24);
			pictureBox1.Margin = new Padding(5);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(63, 64);
			pictureBox1.TabIndex = 7;
			pictureBox1.TabStop = false;
			pictureBox1.Click += pictureBox1_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
			BackgroundImageLayout = ImageLayout.Stretch;
			ClientSize = new Size(1734, 1072);
			Controls.Add(pictureBox1);
			Controls.Add(button3);
			Controls.Add(groupBox1);
			Controls.Add(button1);
			Controls.Add(label2);
			Controls.Add(label1);
			DoubleBuffered = true;
			Margin = new Padding(5);
			Name = "Form1";
			StartPosition = FormStartPosition.CenterScreen;
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		public class RoundedPanel : Panel
		{
			private int cornerRadius = 15; // Радиус закругления

			public int CornerRadius
			{
				get { return cornerRadius; }
				set
				{
					cornerRadius = value;
					this.Invalidate();  // Перерисовываем панель при изменении радиуса
				}
			}

			// Конструктор
			public RoundedPanel()
			{
				this.DoubleBuffered = true; // Увеличиваем производительность
			}

			protected override void OnPaint(PaintEventArgs e)
			{
				base.OnPaint(e);

				// Создаем путь для закругленной панели
				using (GraphicsPath path = new GraphicsPath())
				{
					path.StartFigure();
					path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90); // Верхний левый угол
					path.AddArc(Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90); // Верхний правый угол
					path.AddArc(Width - cornerRadius, Height - cornerRadius, cornerRadius, cornerRadius, 0, 90); // Нижний правый угол
					path.AddArc(0, Height - cornerRadius, cornerRadius, cornerRadius, 90, 90); // Нижний левый угол
					path.CloseFigure();
					
					this.Region = new Region(path);
				}
			}

			protected override void OnResize(EventArgs e)
			{
				base.OnResize(e);
				this.Invalidate(); 
			}
		}


		public class RoundedGroupBox : GroupBox
		{
			private int cornerRadius = 60; // Радиус закругления

			public int CornerRadius
			{
				get { return cornerRadius; }
				set
				{
					cornerRadius = value;
					this.Invalidate(); // Перерисовываем контейнер при изменении радиуса
				}
			}

			// Конструктор
			public RoundedGroupBox()
			{
				this.DoubleBuffered = true; // Увеличиваем производительность
				this.Padding = new Padding(10); // Отступ для текста заголовка
			}

			protected override void OnPaint(PaintEventArgs e)
			{
				base.OnPaint(e);

				// Создаем путь для закругленной группы
				using (GraphicsPath path = new GraphicsPath())
				{
					path.StartFigure();
					path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90); // Верхний левый угол
					path.AddArc(Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90); // Верхний правый угол
					path.AddArc(Width - cornerRadius, Height - cornerRadius, cornerRadius, cornerRadius, 0, 90); // Нижний правый угол
					path.AddArc(0, Height - cornerRadius, cornerRadius, cornerRadius, 90, 90); // Нижний левый угол
					path.CloseFigure();

					
					this.Region = new Region(path);

					// Заливаем цветом
					e.Graphics.FillPath(Brushes.White, path); // Замените цвет по необходимости

					// Рисуем заголовок
					TextRenderer.DrawText(e.Graphics, this.Text, this.Font, new Point(5, 5), this.ForeColor);
				}
			}

			protected override void OnResize(EventArgs e)
			{
				base.OnResize(e);
				this.Invalidate();
			}
		}

		private Label label1;
        private Label label2;
        private Button button1;
        private Label label3;
        private RoundedGroupBox groupBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private RoundButton button2;
        private Button button3;
        private PictureBox pictureBox1;
		private RoundedPanel roundedPanel10;
		private RoundedPanel roundedPanel4;
		private RoundedPanel roundedPanel3;
		private RoundedPanel roundedPanel2;
		private RoundedPanel roundedPanel1;
		private RoundedPanel roundedPanel9;
		private RoundedPanel roundedPanel8;
		private RoundedPanel roundedPanel7;
		private RoundedPanel roundedPanel6;
		private RoundedPanel roundedPanel5;
	}
}
