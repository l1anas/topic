using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using тема_1;

namespace тема2
{
	public partial class SignIn_Up : Form
	{
		// Счетчик неудачных попыток входа
		private Dictionary<string, int> failedLoginAttempts = new Dictionary<string, int>();
		private Dictionary<string, DateTime> lockedUsers = new Dictionary<string, DateTime>();

		// Флаг для отслеживания инициализации
		private bool isInitialized = false;

		public SignIn_Up()
		{
			InitializeComponent();
			InitializeLoginForm();
			InitializeRegisterForm();
			ShowLoginForm();
			isInitialized = true;
		}

		private void InitializeLoginForm()
		{
			// Панель входа
			pnlLogin = new Panel
			{
				Size = new Size(500, 400),
				BorderStyle = BorderStyle.FixedSingle,
				BackColor = Color.White
			};

			// Заголовок
			Label lblLoginTitle = new Label
			{
				Text = "Вход в систему психологического тестирования",
				Font = new Font("Arial", 16, FontStyle.Bold),
				Location = new Point(50, 40),
				Size = new Size(400, 30),
				TextAlign = ContentAlignment.MiddleCenter
			};

			// Поле логина
			Label lblUsername = new Label
			{
				Text = "Логин:",
				Location = new Point(100, 100),
				Size = new Size(100, 25),
				Font = new Font("Arial", 11)
			};

			txtLoginUsername = new TextBox
			{
				Location = new Point(100, 130),
				Size = new Size(300, 35),
				Font = new Font("Arial", 11)
			};

			// Поле пароля
			Label lblPassword = new Label
			{
				Text = "Пароль:",
				Location = new Point(100, 180),
				Size = new Size(100, 25),
				Font = new Font("Arial", 11)
			};

			txtLoginPassword = new TextBox
			{
				Location = new Point(100, 210),
				Size = new Size(300, 35),
				Font = new Font("Arial", 11),
				UseSystemPasswordChar = true
			};

			// Кнопка входа
			btnLogin = new Button
			{
				Text = "Войти",
				Location = new Point(100, 270),
				Size = new Size(300, 45),
				BackColor = Color.SteelBlue,
				ForeColor = Color.White,
				Font = new Font("Arial", 12, FontStyle.Bold),
				Cursor = Cursors.Hand
			};
			btnLogin.Click += BtnLogin_Click;

			// Ссылка на регистрацию
			linkToRegister = new LinkLabel
			{
				Text = "Нет аккаунта? Зарегистрируйтесь",
				Location = new Point(150, 330),
				Size = new Size(200, 25),
				TextAlign = ContentAlignment.MiddleCenter,
				Font = new Font("Arial", 10)
			};
			linkToRegister.LinkClicked += LinkToRegister_LinkClicked;

			// Добавляем элементы на панель входа
			pnlLogin.Controls.AddRange(new Control[] {
				lblLoginTitle, lblUsername, txtLoginUsername,
				lblPassword, txtLoginPassword, btnLogin, linkToRegister
			});

			this.Controls.Add(pnlLogin);
		}

		private void InitializeRegisterForm()
		{
			// Панель регистрации
			pnlRegister = new Panel
			{
				Size = new Size(500, 600),
				BorderStyle = BorderStyle.FixedSingle,
				BackColor = Color.White,
				Visible = false
			};

			// Заголовок
			Label lblRegTitle = new Label
			{
				Text = "Регистрация в системе психологического тестирования",
				Font = new Font("Arial", 16, FontStyle.Bold),
				Location = new Point(50, 30),
				Size = new Size(400, 30),
				TextAlign = ContentAlignment.MiddleCenter
			};

			// Поле имени
			Label lblFirstName = new Label
			{
				Text = "Имя:",
				Location = new Point(100, 80),
				Size = new Size(100, 25),
				Font = new Font("Arial", 11)
			};

			txtRegFirstName = new TextBox
			{
				Location = new Point(100, 110),
				Size = new Size(300, 35),
				Font = new Font("Arial", 11)
			};

			// Поле фамилии
			Label lblLastName = new Label
			{
				Text = "Фамилия:",
				Location = new Point(100, 160),
				Size = new Size(100, 25),
				Font = new Font("Arial", 11)
			};

			txtRegLastName = new TextBox
			{
				Location = new Point(100, 190),
				Size = new Size(300, 35),
				Font = new Font("Arial", 11)
			};

			// Поле логина
			Label lblRegUsername = new Label
			{
				Text = "Логин:",
				Location = new Point(100, 240),
				Size = new Size(100, 25),
				Font = new Font("Arial", 11)
			};

			txtRegUsername = new TextBox
			{
				Location = new Point(100, 270),
				Size = new Size(300, 35),
				Font = new Font("Arial", 11)
			};

			// Поле пароля
			Label lblRegPassword = new Label
			{
				Text = "Пароль:",
				Location = new Point(100, 320),
				Size = new Size(100, 25),
				Font = new Font("Arial", 11)
			};

			txtRegPassword = new TextBox
			{
				Location = new Point(100, 350),
				Size = new Size(300, 35),
				Font = new Font("Arial", 11),
				UseSystemPasswordChar = true
			};

			// Поле email
			Label lblEmail = new Label
			{
				Text = "Email:",
				Location = new Point(100, 400),
				Size = new Size(100, 25),
				Font = new Font("Arial", 11)
			};

			txtRegEmail = new TextBox
			{
				Location = new Point(100, 430),
				Size = new Size(300, 35),
				Font = new Font("Arial", 11),
				PlaceholderText = "example@mail.com"
			};

			// Кнопка регистрации
			btnRegister = new Button
			{
				Text = "Зарегистрироваться",
				Location = new Point(100, 490),
				Size = new Size(300, 45),
				BackColor = Color.SeaGreen,
				ForeColor = Color.White,
				Font = new Font("Arial", 12, FontStyle.Bold),
				Cursor = Cursors.Hand
			};
			btnRegister.Click += BtnRegister_Click;

			// Ссылка на вход
			linkToLogin = new LinkLabel
			{
				Text = "Уже есть аккаунт? Войдите",
				Location = new Point(150, 550),
				Size = new Size(200, 25),
				TextAlign = ContentAlignment.MiddleCenter,
				Font = new Font("Arial", 10)
			};
			linkToLogin.LinkClicked += LinkToLogin_LinkClicked;

			// Добавляем элементы на панель регистрации
			pnlRegister.Controls.AddRange(new Control[] {
				lblRegTitle, lblFirstName, txtRegFirstName,
				lblLastName, txtRegLastName, lblRegUsername, txtRegUsername,
				lblRegPassword, txtRegPassword, lblEmail, txtRegEmail,
				btnRegister, linkToLogin
			});

			this.Controls.Add(pnlRegister);
		}

		private void ShowLoginForm()
		{
			pnlLogin.Visible = true;
			pnlRegister.Visible = false;

			// Центрируем панель входа
			CenterPanel(pnlLogin);

			this.ClientSize = new Size(600, 500);
			this.MinimumSize = new Size(600, 500);
			this.Text = "Вход в систему психологического тестирования";
			CenterToScreen();
		}

		private void ShowRegisterForm()
		{
			pnlLogin.Visible = false;
			pnlRegister.Visible = true;

			// Центрируем панель регистрации
			CenterPanel(pnlRegister);

			this.ClientSize = new Size(600, 700);
			this.MinimumSize = new Size(600, 700);
			this.Text = "Регистрация в системе психологического тестирования";
			CenterToScreen();
		}

		private void CenterPanel(Panel panel)
		{
			if (panel != null)
			{
				panel.Location = new Point(
					(this.ClientSize.Width - panel.Width) / 2,
					(this.ClientSize.Height - panel.Height) / 2
				);
			}
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);

			// Проверяем, что инициализация завершена и панели созданы
			if (!isInitialized) return;

			// Перецентрируем панели при изменении размера формы
			if (pnlLogin != null && pnlLogin.Visible)
				CenterPanel(pnlLogin);
			else if (pnlRegister != null && pnlRegister.Visible)
				CenterPanel(pnlRegister);
		}

		private void LinkToRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			ShowRegisterForm();
		}

		private void LinkToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			ShowLoginForm();
		}

		private void BtnLogin_Click(object sender, EventArgs e)
		{
			string username = txtLoginUsername.Text.Trim();
			string password = txtLoginPassword.Text;

			if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
			{
				MessageBox.Show("Пожалуйста, заполните все поля", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// Проверка блокировки пользователя
			if (IsUserLocked(username))
			{
				MessageBox.Show("Ваш аккаунт временно заблокирован из-за слишком большого количества неудачных попыток входа. Попробуйте позже.",
					"Аккаунт заблокирован", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			CheckLoginPassword(username, password);
		}

		private bool IsUserLocked(string username)
		{
			// Проверяем, заблокирован ли пользователь
			if (lockedUsers.ContainsKey(username))
			{
				DateTime lockTime = lockedUsers[username];
				if (DateTime.Now < lockTime)
				{
					// Пользователь все еще заблокирован
					TimeSpan remainingTime = lockTime - DateTime.Now;
					return true;
				}
				else
				{
					// Время блокировки истекло, разблокируем пользователя
					lockedUsers.Remove(username);
					failedLoginAttempts.Remove(username);
					return false;
				}
			}
			return false;
		}

		private void CheckLoginPassword(string login, string password)
		{
			BDConnection database = new BDConnection();
			DataTable dataTable = new DataTable();

			try
			{
				database.openConnection();

				MySqlCommand command = new MySqlCommand(
					"SELECT * FROM users WHERE login = @ent_login AND password = @ent_password AND is_active = 1",
					database.getConnection());

				command.Parameters.Add("@ent_login", MySqlDbType.VarChar).Value = login;
				command.Parameters.Add("@ent_password", MySqlDbType.VarChar).Value = HashPassword(password);

				MySqlDataAdapter adapter = new MySqlDataAdapter(command);
				adapter.Fill(dataTable);

				if (dataTable.Rows.Count > 0)
				{
					// Успешный вход - сбрасываем счетчик неудачных попыток
					if (failedLoginAttempts.ContainsKey(login))
					{
						failedLoginAttempts.Remove(login);
					}
					if (lockedUsers.ContainsKey(login))
					{
						lockedUsers.Remove(login);
					}

					DataRow user = dataTable.Rows[0];
					string firstName = user["first_name"].ToString();
					string lastName = user["last_name"].ToString();

					// ВАЖНО: Получаем ID пользователя
					int userId = Convert.ToInt32(user["id"]); // Добавьте эту строку

					// Получаем роль пользователя из enum
					string roleString = user["role"].ToString();
					int userRole = GetRoleNumber(roleString);

					MessageBox.Show($"{firstName} {lastName}, Вы успешно авторизовались!\nРоль: {GetRoleDisplayName(roleString)}",
						"Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

					this.Hide();

					// Передаем роль И ID пользователя в главное окно
					MainWindow main = new MainWindow(userRole, userId); // Добавьте userId
					main.Show();
				}
				else
				{
					// Неудачная попытка входа
					IncrementFailedAttempts(login);

					int attempts = failedLoginAttempts.ContainsKey(login) ? failedLoginAttempts[login] : 1;
					int remainingAttempts = 3 - attempts;

					if (remainingAttempts > 0)
					{
						MessageBox.Show($"Неверный логин или пароль. Осталось попыток: {remainingAttempts}",
							"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					else
					{
						// Блокируем пользователя на 5 минут
						lockedUsers[login] = DateTime.Now.AddMinutes(5);
						MessageBox.Show("Превышено количество попыток входа. Ваш аккаунт заблокирован на 5 минут.",
							"Аккаунт заблокирован", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}",
					"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				database.closeConnection();
			}
		}

		private int GetRoleNumber(string roleString)
		{
			switch (roleString.ToLower())
			{
				case "admin": return 2;
				case "psychologist": return 3;
				case "user":
				default: return 1;
			}
		}

		private string GetRoleDisplayName(string roleString)
		{
			switch (roleString.ToLower())
			{
				case "admin": return "Администратор";
				case "psychologist": return "Психолог";
				case "user":
				default: return "Пользователь";
			}
		}

		private void IncrementFailedAttempts(string username)
		{
			if (failedLoginAttempts.ContainsKey(username))
			{
				failedLoginAttempts[username]++;
			}
			else
			{
				failedLoginAttempts[username] = 1;
			}
		}

		private void BtnRegister_Click(object sender, EventArgs e)
		{
			string firstName = txtRegFirstName.Text.Trim();
			string lastName = txtRegLastName.Text.Trim();
			string username = txtRegUsername.Text.Trim();
			string password = txtRegPassword.Text;
			string email = txtRegEmail.Text.Trim();

			if (!ValidateRegistrationData(firstName, lastName, username, password, email))
				return;

			try
			{
				RegisterNewUser(firstName, lastName, username, password, email);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка при регистрации: {ex.Message}",
					"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private bool ValidateRegistrationData(string firstName, string lastName, string username, string password, string email)
		{
			if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
				string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
				string.IsNullOrEmpty(email))
			{
				MessageBox.Show("Пожалуйста, заполните все обязательные поля",
					"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			if (password.Length < 6)
			{
				MessageBox.Show("Пароль должен содержать минимум 6 символов",
					"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			if (!IsValidEmail(email))
			{
				MessageBox.Show("Введите корректный email адрес",
					"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			return true;
		}

		private void RegisterNewUser(string firstName, string lastName, string username, string password, string email)
		{
			BDConnection database = new BDConnection();

			try
			{
				database.openConnection();

				if (IsUsernameTaken(username, database))
				{
					MessageBox.Show("Этот логин уже занят. Выберите другой.",
						"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				if (IsEmailTaken(email, database))
				{
					MessageBox.Show("Этот email уже используется. Выберите другой.",
						"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
				command.Parameters.AddWithValue("@role", "user");
				command.Parameters.AddWithValue("@isActive", 1);

				int rowsAffected = command.ExecuteNonQuery();

				if (rowsAffected > 0)
				{
					MessageBox.Show("Регистрация прошла успешно! Теперь вы можете войти в систему.",
						"Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

					ClearRegistrationFields();
					ShowLoginForm();
				}
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

		private bool IsEmailTaken(string email, BDConnection database)
		{
			string checkQuery = "SELECT COUNT(*) FROM users WHERE phone = @email";
			MySqlCommand checkCommand = new MySqlCommand(checkQuery, database.getConnection());
			checkCommand.Parameters.AddWithValue("@email", email);

			var result = checkCommand.ExecuteScalar();
			return result != null && Convert.ToInt32(result) > 0;
		}

		private bool IsValidEmail(string email)
		{
			if (string.IsNullOrEmpty(email))
				return false;

			string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
			return Regex.IsMatch(email, pattern);
		}

		private string HashPassword(string password)
		{
			if (string.IsNullOrEmpty(password))
				return string.Empty;

			using (var sha256 = System.Security.Cryptography.SHA256.Create())
			{
				var bytes = System.Text.Encoding.UTF8.GetBytes(password);
				var hash = sha256.ComputeHash(bytes);
				return Convert.ToBase64String(hash);
			}
		}

		private void ClearRegistrationFields()
		{
			txtRegFirstName.Text = "";
			txtRegLastName.Text = "";
			txtRegUsername.Text = "";
			txtRegPassword.Text = "";
			txtRegEmail.Text = "";
		}
	}
}