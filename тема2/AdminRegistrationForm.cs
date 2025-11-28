using MySqlConnector;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace тема2
{
	public partial class AdminRegistrationForm : Form
	{
		public AdminRegistrationForm()
		{
			InitializeComponent();

			// Заполняем ComboBox после инициализации
			cmbRole.Items.AddRange(new string[] { "admin", "psychologist", "user" });
			cmbRole.SelectedIndex = 0;
		}

		private void btnRegister_Click(object sender, EventArgs e)
		{
			string firstName = txtFirstName.Text.Trim();
			string lastName = txtLastName.Text.Trim();
			string username = txtUsername.Text.Trim();
			string password = txtPassword.Text;
			string email = txtEmail.Text.Trim();
			string role = cmbRole.SelectedItem?.ToString() ?? "user";

			if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
				string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
				string.IsNullOrEmpty(email))
			{
				MessageBox.Show("Пожалуйста, заполните все поля", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (password.Length < 6)
			{
				MessageBox.Show("Пароль должен содержать минимум 6 символов", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			RegisterAdminUser(firstName, lastName, username, password, email, role);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void RegisterAdminUser(string firstName, string lastName, string username,
									 string password, string email, string role)
		{
			BDConnection database = new BDConnection();

			try
			{
				database.openConnection();

				if (IsUsernameTaken(username, database))
				{
					MessageBox.Show("Этот логин уже занят", "Ошибка",
						MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				string query = @"INSERT INTO users (first_name, last_name, login, password, phone, role, is_active) 
                              VALUES (@firstName, @lastName, @username, @password, @email, @role, @isActive)";

				MySqlCommand command = new MySqlCommand(query, database.getConnection());
				command.Parameters.AddWithValue("@firstName", firstName);
				command.Parameters.AddWithValue("@lastName", lastName);
				command.Parameters.AddWithValue("@username", username);
				command.Parameters.AddWithValue("@password", HashPassword(password));
				command.Parameters.AddWithValue("@email", email);
				command.Parameters.AddWithValue("@role", role);
				command.Parameters.AddWithValue("@isActive", 1);

				int rowsAffected = command.ExecuteNonQuery();

				if (rowsAffected > 0)
				{
					MessageBox.Show($"Пользователь {firstName} {lastName} успешно зарегистрирован как {role}!",
						"Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка при регистрации: {ex.Message}", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				database.closeConnection();
			}
		}

		private bool IsUsernameTaken(string username, BDConnection database)
		{
			string checkQuery = "SELECT COUNT(*) FROM users WHERE login = @username";
			MySqlCommand checkCommand = new MySqlCommand(checkQuery, database.getConnection());
			checkCommand.Parameters.AddWithValue("@username", username);

			var result = checkCommand.ExecuteScalar();
			return result != null && Convert.ToInt32(result) > 0;
		}

		private string HashPassword(string password)
		{
			using (var sha256 = System.Security.Cryptography.SHA256.Create())
			{
				var bytes = System.Text.Encoding.UTF8.GetBytes(password);
				var hash = sha256.ComputeHash(bytes);
				return Convert.ToBase64String(hash);
			}
		}
	}
}