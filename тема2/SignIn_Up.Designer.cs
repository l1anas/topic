namespace тема2
{
	partial class SignIn_Up
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		// Элементы управления для входа
		private Panel pnlLogin;
		private TextBox txtLoginUsername;
		private TextBox txtLoginPassword;
		private Button btnLogin;
		private LinkLabel linkToRegister;

		// Элементы управления для регистрации
		private Panel pnlRegister;
		private TextBox txtRegFirstName;
		private TextBox txtRegLastName;
		private TextBox txtRegUsername;
		private TextBox txtRegPassword;
		private TextBox txtRegEmail;
		private Button btnRegister;
		private LinkLabel linkToLogin;

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
			this.SuspendLayout();
			// 
			// SignIn_Up
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LightGray;
			this.ClientSize = new System.Drawing.Size(600, 500);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SignIn_Up";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Вход в систему психологического тестирования";
			this.ResumeLayout(false);
		}

		#endregion
	}
}