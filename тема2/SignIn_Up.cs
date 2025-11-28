using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace тема2
{
	public partial class SignIn_Up : Form
	{
		// Счетчик неудачных попыток входа
		private Dictionary<string, int> failedLoginAttempts = new Dictionary<string, int>();
		private Dictionary<string, DateTime> lockedUsers = new Dictionary<string, DateTime>();

		// Константы для размеров и отступов
		private const int FORM_WIDTH = 650;
		private const int FORM_HEIGHT = 900;
		private const int PANEL_WIDTH = 500;
		private const int LOGIN_PANEL_HEIGHT = 450;
		private const int REGISTER_PANEL_HEIGHT = 700;
		private const int MARGIN = 30;
		private const int ELEMENT_SPACING = 20;
		private const int LABEL_HEIGHT = 25;
		private const int TEXTBOX_HEIGHT = 35;
		private const int BUTTON_HEIGHT = 45;


		public SignIn_Up()
		{
			InitializeComponent();
			InitializeForm();
			InitializeLoginForm();
			InitializeRegisterForm();
			ShowLoginForm();
		}

		private void InitializeForm()
		{
			// Настройка основной формы
			this.Size = new Size(FORM_WIDTH, FORM_HEIGHT);
			this.MinimumSize = new Size(FORM_WIDTH, FORM_HEIGHT);
			this.MaximumSize = new Size(FORM_WIDTH, FORM_HEIGHT);
			this.StartPosition = FormStartPosition.CenterScreen;
			this.BackColor = Color.LemonChiffon;
			this.Text = "Система психологического тестирования";
			this.Padding = new Padding(0);
			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
		}

		private void InitializeLoginForm()
		{
			// Панель входа
			pnlLogin = new Panel
			{
				Size = new Size(PANEL_WIDTH, LOGIN_PANEL_HEIGHT),
				BackColor = Color.White,
				BorderStyle = BorderStyle.FixedSingle,
				Location = new Point(((FORM_WIDTH - PANEL_WIDTH) / 2)-10, MARGIN)
			};

			int currentY = MARGIN;
			int contentWidth = PANEL_WIDTH - (2 * MARGIN);

			// Заголовок
			Label lblLoginTitle = new Label
			{
				Text = "Вход",
				Font = new Font("Times New Roman", 16, FontStyle.Bold),
				ForeColor = Color.LightSkyBlue,
				Location = new Point(MARGIN, currentY),
				Size = new Size(contentWidth, 43),
				TextAlign = ContentAlignment.MiddleCenter
			};
			currentY += lblLoginTitle.Height + ELEMENT_SPACING * 2;

			// Логин
			Label lblUsername = new Label
			{
				Text = "Логин:",
				Location = new Point(MARGIN, currentY-7),
				Size = new Size(contentWidth, LABEL_HEIGHT+5),
				Font = new Font("Times New Roman", 10, FontStyle.Bold),
				ForeColor = Color.DimGray
			};
			currentY += LABEL_HEIGHT + 5;

			txtLoginUsername = new TextBox
			{
				Location = new Point(MARGIN, currentY),
				Size = new Size(contentWidth, TEXTBOX_HEIGHT),
				Font = new Font("Times New Roman", 10),
				BackColor = Color.WhiteSmoke,
				BorderStyle = BorderStyle.FixedSingle
			};
			currentY += TEXTBOX_HEIGHT + ELEMENT_SPACING;

			// Пароль
			Label lblPassword = new Label
			{
				Text = "Пароль:",
				Location = new Point(MARGIN, currentY-7),
				Size = new Size(contentWidth, LABEL_HEIGHT+5),
				Font = new Font("Times New Roman", 10, FontStyle.Bold),
				ForeColor = Color.DimGray
			};
			currentY += LABEL_HEIGHT + 5;

			txtLoginPassword = new TextBox
			{
				Location = new Point(MARGIN, currentY),
				Size = new Size(contentWidth, TEXTBOX_HEIGHT),
				Font = new Font("Times New Roman", 10),
				UseSystemPasswordChar = true,
				BackColor = Color.WhiteSmoke,
				BorderStyle = BorderStyle.FixedSingle
			};
			currentY += TEXTBOX_HEIGHT + ELEMENT_SPACING * 2;

			// Кнопка входа
			btnLogin = new Button
			{
				Text = "Войти",
				Location = new Point(MARGIN, currentY),
				Size = new Size(contentWidth, BUTTON_HEIGHT),
				BackColor = Color.LightSkyBlue,
				ForeColor = Color.White,
				Font = new Font("Times New Roman", 11, FontStyle.Bold),
				FlatStyle = FlatStyle.Flat,
				Cursor = Cursors.Hand
			};
			btnLogin.FlatAppearance.BorderSize = 0;
			btnLogin.Click += BtnLogin_Click;
			currentY += BUTTON_HEIGHT + ELEMENT_SPACING * 2;

			// Ссылка на регистрацию
			linkToRegister = new LinkLabel
			{
				Text = "Нет аккаунта? Зарегистрироваться",
				Location = new Point(MARGIN, currentY),
				Size = new Size(contentWidth, 25),
				TextAlign = ContentAlignment.MiddleCenter,
				Font = new Font("Times New Roman", 9),
				LinkColor = Color.LightSkyBlue
			};
			linkToRegister.LinkClicked += LinkToRegister_LinkClicked;

			// Добавление элементов на панель
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
				Size = new Size(PANEL_WIDTH, REGISTER_PANEL_HEIGHT),
				BackColor = Color.White,
				BorderStyle = BorderStyle.FixedSingle,
				Location = new Point(((FORM_WIDTH - PANEL_WIDTH) / 2)-10, MARGIN),
				Visible = false,
				AutoScroll = true
			};

			int currentY = MARGIN;
			int contentWidth = PANEL_WIDTH - (2 * MARGIN);

			// Заголовок
			Label lblRegTitle = new Label
			{
				Text = "Регистрация",
				Font = new Font("Arial", 16, FontStyle.Bold),
				ForeColor = Color.LightSkyBlue,
				Location = new Point(MARGIN, currentY),
				Size = new Size(contentWidth, 43),
				TextAlign = ContentAlignment.MiddleCenter
			};
			currentY += lblRegTitle.Height + ELEMENT_SPACING * 2;

			// Имя
			Label lblFirstName = new Label
			{
				Text = "Имя:",
				Location = new Point(MARGIN, currentY-7),
				Size = new Size(contentWidth, LABEL_HEIGHT+5),
				Font = new Font("Arial", 10, FontStyle.Bold),
				ForeColor = Color.DimGray
			};
			currentY += LABEL_HEIGHT + 5;

			txtRegFirstName = new TextBox
			{
				Location = new Point(MARGIN, currentY),
				Size = new Size(contentWidth, TEXTBOX_HEIGHT),
				Font = new Font("Arial", 10),
				BackColor = Color.WhiteSmoke,
				BorderStyle = BorderStyle.FixedSingle
			};
			currentY += TEXTBOX_HEIGHT + ELEMENT_SPACING;

			// Фамилия
			Label lblLastName = new Label
			{
				Text = "Фамилия:",
				Location = new Point(MARGIN, currentY-7),
				Size = new Size(contentWidth, LABEL_HEIGHT+5),
				Font = new Font("Arial", 10, FontStyle.Bold),
				ForeColor = Color.DimGray
			};
			currentY += LABEL_HEIGHT + 5;

			txtRegLastName = new TextBox
			{
				Location = new Point(MARGIN, currentY),
				Size = new Size(contentWidth, TEXTBOX_HEIGHT),
				Font = new Font("Arial", 10),
				BackColor = Color.WhiteSmoke,
				BorderStyle = BorderStyle.FixedSingle
			};
			currentY += TEXTBOX_HEIGHT + ELEMENT_SPACING;

			// Логин
			Label lblRegUsername = new Label
			{
				Text = "Логин:",
				Location = new Point(MARGIN, currentY - 7),
				Size = new Size(contentWidth, LABEL_HEIGHT + 5),
				Font = new Font("Arial", 10, FontStyle.Bold),
				ForeColor = Color.DimGray
			};
			currentY += LABEL_HEIGHT + 5;

			txtRegUsername = new TextBox
			{
				Location = new Point(MARGIN, currentY),
				Size = new Size(contentWidth, TEXTBOX_HEIGHT),
				Font = new Font("Arial", 10),
				BackColor = Color.WhiteSmoke,
				BorderStyle = BorderStyle.FixedSingle
			};
			currentY += TEXTBOX_HEIGHT + ELEMENT_SPACING;

			// Пароль
			Label lblRegPassword = new Label
			{
				Text = "Пароль:",
				Location = new Point(MARGIN, currentY-7),
				Size = new Size(contentWidth, LABEL_HEIGHT+5),
				Font = new Font("Arial", 10, FontStyle.Bold),
				ForeColor = Color.DimGray
			};
			currentY += LABEL_HEIGHT + 5;

			txtRegPassword = new TextBox
			{
				Location = new Point(MARGIN, currentY),
				Size = new Size(contentWidth, TEXTBOX_HEIGHT),
				Font = new Font("Arial", 10),
				UseSystemPasswordChar = true,
				BackColor = Color.WhiteSmoke,
				BorderStyle = BorderStyle.FixedSingle
			};
			currentY += TEXTBOX_HEIGHT + ELEMENT_SPACING;

			// Email
			Label lblEmail = new Label
			{
				Text = "Email:",
				Location = new Point(MARGIN, currentY-7),
				Size = new Size(contentWidth, LABEL_HEIGHT+5),
				Font = new Font("Arial", 10, FontStyle.Bold),
				ForeColor = Color.DimGray
			};
			currentY += LABEL_HEIGHT + 5;

			txtRegEmail = new TextBox
			{
				Location = new Point(MARGIN, currentY),
				Size = new Size(contentWidth, TEXTBOX_HEIGHT),
				Font = new Font("Arial", 10),
				BackColor = Color.WhiteSmoke,
				BorderStyle = BorderStyle.FixedSingle
			};
			currentY += TEXTBOX_HEIGHT + ELEMENT_SPACING * 2;

			// Кнопка регистрации
			btnRegister = new Button
			{
				Text = "Зарегистрироваться",
				Location = new Point(MARGIN, currentY),
				Size = new Size(contentWidth, BUTTON_HEIGHT),
				BackColor = Color.LightSkyBlue,
				ForeColor = Color.White,
				Font = new Font("Arial", 11, FontStyle.Bold),
				FlatStyle = FlatStyle.Flat,
				Cursor = Cursors.Hand
			};
			btnRegister.FlatAppearance.BorderSize = 0;
			btnRegister.Click += BtnRegister_Click;
			currentY += BUTTON_HEIGHT + ELEMENT_SPACING * 2;

			// Ссылка на вход
			linkToLogin = new LinkLabel
			{
				Text = "Уже есть аккаунт? Войти",
				Location = new Point(MARGIN, currentY),
				Size = new Size(contentWidth, 25),
				TextAlign = ContentAlignment.MiddleCenter,
				Font = new Font("Arial", 9),
				LinkColor = Color.LightSkyBlue,
			};
			linkToLogin.LinkClicked += LinkToLogin_LinkClicked;

			// Добавление элементов на панель
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
			this.Text = "Вход в систему";
			CenterPanelVertically(pnlLogin);
		}

		private void ShowRegisterForm()
		{
			pnlLogin.Visible = false;
			pnlRegister.Visible = true;
			this.Text = "Регистрация";
			CenterPanelVertically(pnlRegister);
		}

		private void CenterPanelVertically(Panel panel)
		{
			if (panel != null)
			{
				panel.Location = new Point(
					panel.Location.X,
					(this.ClientSize.Height - panel.Height) / 2
				);
			}
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

			if (IsUserLocked(username))
			{
				MessageBox.Show("Ваш аккаунт временно заблокирован. Попробуйте позже.",
					"Аккаунт заблокирован", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			CheckLoginPassword(username, password);
		}

		private bool IsUserLocked(string username)
		{
			if (lockedUsers.ContainsKey(username))
			{
				DateTime lockTime = lockedUsers[username];
				if (DateTime.Now < lockTime)
				{
					return true;
				}
				else
				{
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
					// Успешный вход
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
					string role = user["role"].ToString().ToLower();
					int userId = Convert.ToInt32(user["id"]);

					MessageBox.Show($"{firstName} {lastName}, Вы успешно авторизовались!\nРоль: {GetRoleDisplayName(role)}",
						"Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

					this.Hide();

					if (role == "hr")
					{
						HRForm hrForm = new HRForm(userId);
						hrForm.Show();
					}
					else
					{
						MainWindow mainForm = new MainWindow(userId);
						mainForm.Show();
					}
				}
				else
				{
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

		private string GetRoleDisplayName(string roleString)
		{
			switch (roleString.ToLower())
			{
				case "hr": return "HR специалист";
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