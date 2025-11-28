using System.Drawing.Drawing2D;

namespace тема2
{
    partial class MainWindow
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


		public class RoundButton : Button
        {
            GraphicsPath GetRoundPath(RectangleF Rect, int radius)
            {
                float r2 = radius / 2f;
                GraphicsPath GraphPath = new GraphicsPath();

                GraphPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
                GraphPath.AddLine(Rect.X + r2, Rect.Y, Rect.Width - r2, Rect.Y);
                GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
                GraphPath.AddLine(Rect.Width, Rect.Y + r2, Rect.Width, Rect.Height - r2);
                GraphPath.AddArc(Rect.X + Rect.Width - radius,
                                    Rect.Y + Rect.Height - radius, radius, radius, 0, 90);
                GraphPath.AddLine(Rect.Width - r2, Rect.Height, Rect.X + r2, Rect.Height);
                GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90);
                GraphPath.AddLine(Rect.X, Rect.Height - r2, Rect.X, Rect.Y + r2);

                GraphPath.CloseFigure();
                return GraphPath;
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                RectangleF Rect = new RectangleF(0, 0, this.Width, this.Height);
                GraphicsPath GraphPath = GetRoundPath(Rect, 50);

                this.Region = new Region(GraphPath);
                using (Pen pen = new Pen(Color.White, 2.95f))
                {
                    pen.Alignment = PenAlignment.Inset;
                    e.Graphics.DrawPath(pen, GraphPath);
                }
            }
        }
		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			buttTest1 = new RoundButton();
			buttTest2 = new RoundButton();
			buttTest4 = new RoundButton();
			buttText5 = new RoundButton();
			buttTest3 = new RoundButton();
			buttTest7 = new RoundButton();
			buttTest6 = new RoundButton();
			label1 = new Label();
			SuspendLayout();
			// 
			// buttTest1
			// 
			buttTest1.BackColor = Color.YellowGreen;
			buttTest1.Font = new Font("Times New Roman", 16.125F);
			buttTest1.ForeColor = Color.FromArgb(64, 64, 64);
			buttTest1.Location = new Point(382, 234);
			buttTest1.Margin = new Padding(5);
			buttTest1.Name = "buttTest1";
			buttTest1.Size = new Size(995, 70);
			buttTest1.TabIndex = 0;
			buttTest1.Text = "Делегирование полномочий и принятие решений";
			buttTest1.UseVisualStyleBackColor = false;
			buttTest1.Click += button1_Click;
			// 
			// buttTest2
			// 
			buttTest2.BackColor = Color.YellowGreen;
			buttTest2.Font = new Font("Times New Roman", 16.125F);
			buttTest2.ForeColor = Color.FromArgb(64, 64, 64);
			buttTest2.Location = new Point(382, 330);
			buttTest2.Margin = new Padding(5);
			buttTest2.Name = "buttTest2";
			buttTest2.Size = new Size(995, 70);
			buttTest2.TabIndex = 1;
			buttTest2.Text = "Отбор персонала";
			buttTest2.UseVisualStyleBackColor = false;
			buttTest2.Click += roundButton1_Click;
			// 
			// buttTest4
			// 
			buttTest4.BackColor = Color.YellowGreen;
			buttTest4.Font = new Font("Times New Roman", 16.125F);
			buttTest4.ForeColor = Color.FromArgb(64, 64, 64);
			buttTest4.Location = new Point(382, 533);
			buttTest4.Margin = new Padding(5);
			buttTest4.Name = "buttTest4";
			buttTest4.Size = new Size(995, 70);
			buttTest4.TabIndex = 2;
			buttTest4.Text = "Мотивация персонала";
			buttTest4.UseVisualStyleBackColor = false;
			buttTest4.Click += buttTest4_Click;
			// 
			// buttText5
			// 
			buttText5.BackColor = Color.YellowGreen;
			buttText5.Font = new Font("Times New Roman", 16.125F);
			buttText5.ForeColor = Color.FromArgb(64, 64, 64);
			buttText5.Location = new Point(382, 629);
			buttText5.Margin = new Padding(5);
			buttText5.Name = "buttText5";
			buttText5.Size = new Size(995, 70);
			buttText5.TabIndex = 3;
			buttText5.Text = "Системы компенсации и стимулирования персонала";
			buttText5.UseVisualStyleBackColor = false;
			buttText5.Click += buttText5_Click;
			// 
			// buttTest3
			// 
			buttTest3.BackColor = Color.YellowGreen;
			buttTest3.Font = new Font("Times New Roman", 16.125F);
			buttTest3.ForeColor = Color.FromArgb(64, 64, 64);
			buttTest3.Location = new Point(382, 429);
			buttTest3.Margin = new Padding(5);
			buttTest3.Name = "buttTest3";
			buttTest3.Size = new Size(995, 70);
			buttTest3.TabIndex = 4;
			buttTest3.Text = "Адаптация сотрудников";
			buttTest3.UseVisualStyleBackColor = false;
			buttTest3.Click += buttTest3_Click;
			// 
			// buttTest7
			// 
			buttTest7.BackColor = Color.YellowGreen;
			buttTest7.Font = new Font("Times New Roman", 16.125F);
			buttTest7.ForeColor = Color.FromArgb(64, 64, 64);
			buttTest7.Location = new Point(382, 826);
			buttTest7.Margin = new Padding(5);
			buttTest7.Name = "buttTest7";
			buttTest7.Size = new Size(995, 70);
			buttTest7.TabIndex = 5;
			buttTest7.Text = "Создание эффективной команды";
			buttTest7.UseVisualStyleBackColor = false;
			buttTest7.Click += buttTest7_Click;
			// 
			// buttTest6
			// 
			buttTest6.BackColor = Color.YellowGreen;
			buttTest6.Font = new Font("Times New Roman", 16.125F);
			buttTest6.ForeColor = Color.FromArgb(64, 64, 64);
			buttTest6.Location = new Point(382, 726);
			buttTest6.Margin = new Padding(5);
			buttTest6.Name = "buttTest6";
			buttTest6.Size = new Size(995, 70);
			buttTest6.TabIndex = 6;
			buttTest6.Text = "Управление проблемными сотрудниками";
			buttTest6.UseVisualStyleBackColor = false;
			buttTest6.Click += buttTest6_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
			label1.ForeColor = Color.FromArgb(64, 64, 64);
			label1.Location = new Point(272, 42);
			label1.Name = "label1";
			label1.Size = new Size(1216, 110);
			label1.TabIndex = 7;
			label1.Text = "                                            Тесты по\r\nпсихологии управления и развития человеческих ресурсов";
			// 
			// MainWindow
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.LemonChiffon;
			ClientSize = new Size(1734, 1054);
			Controls.Add(label1);
			Controls.Add(buttTest6);
			Controls.Add(buttTest7);
			Controls.Add(buttTest3);
			Controls.Add(buttText5);
			Controls.Add(buttTest4);
			Controls.Add(buttTest2);
			Controls.Add(buttTest1);
			Margin = new Padding(5);
			Name = "MainWindow";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Меню тестов";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private RoundButton buttTest1;
        private RoundButton buttTest2;
        private RoundButton buttTest4;
        private RoundButton buttText5;
        private RoundButton buttTest3;
        private RoundButton buttTest7;
        private RoundButton buttTest6;
		private Label label1;

	}
}
