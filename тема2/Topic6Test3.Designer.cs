﻿namespace тема2
{
    partial class Topic6Test3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Topic6Test3));
            label4 = new Label();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            groupBox1 = new GroupBox();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            label3 = new Label();
            Button1 = new Button();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(56, 12);
            label4.Name = "label4";
            label4.Size = new Size(156, 40);
            label4.TabIndex = 55;
            label4.Text = "Вернуться в главное \r\nменю";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.ErrorImage = (Image)resources.GetObject("pictureBox1.ErrorImage");
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(39, 40);
            pictureBox1.TabIndex = 54;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button2.Location = new Point(432, 494);
            button2.Name = "button2";
            button2.Size = new Size(241, 31);
            button2.TabIndex = 53;
            button2.Text = "Следующий вопрос";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(133, 240);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(811, 228);
            groupBox1.TabIndex = 52;
            groupBox1.TabStop = false;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            radioButton3.Location = new Point(28, 155);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(68, 32);
            radioButton3.TabIndex = 2;
            radioButton3.TabStop = true;
            radioButton3.Text = "Нет";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            radioButton2.Location = new Point(28, 91);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(68, 32);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "Нет";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            radioButton1.Location = new Point(28, 26);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(58, 32);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Да";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(133, 188);
            label3.Name = "label3";
            label3.Size = new Size(664, 25);
            label3.TabIndex = 51;
            label3.Text = "Продолжаете ли Вы работать после окончания рабочего дня?";
            // 
            // Button1
            // 
            Button1.Location = new Point(451, 188);
            Button1.Name = "Button1";
            Button1.Size = new Size(193, 46);
            Button1.TabIndex = 50;
            Button1.Text = "Начать тест 3";
            Button1.UseVisualStyleBackColor = true;
            Button1.Click += Button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(495, 127);
            label2.Name = "label2";
            label2.Size = new Size(102, 22);
            label2.TabIndex = 49;
            label2.Text = "Тест 3 из 3";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(215, 70);
            label1.Name = "label1";
            label1.Size = new Size(674, 34);
            label1.TabIndex = 48;
            label1.Text = "Управление проблемными сотрудниками в IT-сфере";
            // 
            // Topic6Test3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 670);
            Controls.Add(label4);
            Controls.Add(pictureBox1);
            Controls.Add(button2);
            Controls.Add(groupBox1);
            Controls.Add(label3);
            Controls.Add(Button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Topic6Test3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Topic6Test3";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private PictureBox pictureBox1;
        private Button button2;
        private GroupBox groupBox1;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label label3;
        private Button Button1;
        private Label label2;
        private Label label1;
    }
}