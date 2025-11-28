using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace тема2
{
	public partial class HRForm : Form
	{
		private int hrUserId;
		private DataTable usersData;

		// Элементы управления
		private DataGridView dgvUsers;
		private TextBox txtSearch;
		private Button btnInvite;
		private Button btnReject;
		private Button btnViewResume;

		public HRForm(int userId)
		{
			hrUserId = userId;
			InitializeComponent();
			LoadUsers();
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();

			// Настройка формы
			this.Text = "HR Panel - Управление кандидатами";
			this.Size = new Size(1700, 1220);
			this.StartPosition = FormStartPosition.CenterScreen;
			this.BackColor = Color.White;

			// Панель для поиска (для центрирования)
			Panel searchPanel = new Panel
			{
				Location = new Point(0, 10),
				Size = new Size(1700, 30),
				BackColor = Color.Transparent,
			};

			// Поле поиска (центрированное)
			txtSearch = new TextBox
			{
				Size = new Size(1300, 20),
				Font = new Font("Arial", 10),
				PlaceholderText = "Поиск по имени, фамилии или email..."
			};

			// Центрируем поле поиска
			txtSearch.Location = new Point((searchPanel.Width - txtSearch.Width) / 2, 0);
			txtSearch.TextChanged += TxtSearch_TextChanged;

			// DataGridView для отображения пользователей
			dgvUsers = new DataGridView
			{
				Location = new Point(20, 70),
				Size = new Size(1660, 1000),
				AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None,
				SelectionMode = DataGridViewSelectionMode.FullRowSelect,
				ReadOnly = true,
				AllowUserToAddRows = false,
				AllowUserToDeleteRows = false,
				RowHeadersVisible = false,
				Font = new Font("Arial", 9),
				ScrollBars = ScrollBars.Both,
				AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
			};

			// Панель для центрирования кнопок
			Panel buttonPanel = new Panel
			{
				Location = new Point(20, 1080),
				Size = new Size(1660, 50),
				BackColor = Color.Transparent
			};

			// Кнопка просмотра резюме
			btnViewResume = new Button
			{
				Size = new Size(250, 50),
				Text = "Просмотреть",
				BackColor = Color.Gold,
				ForeColor = Color.Black,
				Font = new Font("Arial", 12, FontStyle.Bold)
			};
			btnViewResume.Click += BtnViewResume_Click;

			// Кнопка пригласить
			btnInvite = new Button
			{
				Size = new Size(250, 50),
				Text = "Пригласить",
				BackColor = Color.SeaGreen,
				ForeColor = Color.White,
				Font = new Font("Arial", 12, FontStyle.Bold)
			};
			btnInvite.Click += BtnInvite_Click;

			// Кнопка отклонить
			btnReject = new Button
			{
				Size = new Size(250, 50),
				Text = "Отклонить",
				BackColor = Color.IndianRed,
				ForeColor = Color.White,
				Font = new Font("Arial", 12, FontStyle.Bold)
			};
			btnReject.Click += BtnReject_Click;

			// Центрируем кнопки на панели
			int totalButtonsWidth = btnViewResume.Width + btnInvite.Width + btnReject.Width + 40;
			int startX = (buttonPanel.Width - totalButtonsWidth) / 2;

			btnViewResume.Location = new Point(startX, 5);
			btnInvite.Location = new Point(startX + btnViewResume.Width + 20, 5);
			btnReject.Location = new Point(startX + btnViewResume.Width + btnInvite.Width + 40, 5);

			// Добавляем элементы на панели
			searchPanel.Controls.Add(txtSearch);
			buttonPanel.Controls.AddRange(new Control[] { btnViewResume, btnInvite, btnReject });

			// Добавляем элементы на форму
			this.Controls.AddRange(new Control[] {
				searchPanel, dgvUsers, buttonPanel
			});

			this.ResumeLayout(false);
		}

		private void LoadUsers(string searchTerm = "")
		{
			usersData = new DataTable();
			BDConnection database = new BDConnection();

			try
			{
				database.openConnection();

				string query = @"
                    SELECT 
                        u.id,
                        u.first_name,
                        u.last_name, 
                        u.phone as email,
                        u.total_score,
                        u.resume_text,
                        u.status
                    FROM users u 
                    WHERE u.role = 'user' 
                    AND u.status = 'pending'
                    AND u.is_active = 1";

				if (!string.IsNullOrEmpty(searchTerm))
				{
					query += @" AND (u.first_name LIKE @search 
                              OR u.last_name LIKE @search 
                              OR u.phone LIKE @search)";
				}

				query += " ORDER BY u.total_score DESC";

				MySqlCommand command = new MySqlCommand(query, database.getConnection());

				if (!string.IsNullOrEmpty(searchTerm))
				{
					command.Parameters.AddWithValue("@search", $"%{searchTerm}%");
				}

				MySqlDataAdapter adapter = new MySqlDataAdapter(command);
				adapter.Fill(usersData);

				// Настраиваем DataGridView
				ConfigureDataGridView();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				database.closeConnection();
			}
		}

		private void ConfigureDataGridView()
		{
			dgvUsers.Columns.Clear();

			// Проверяем, есть ли данные для отображения
			if (usersData.Rows.Count == 0)
			{
				dgvUsers.DataSource = null;
				dgvUsers.Columns.Add("empty", "Нет данных для отображения");
				return;
			}

			// Создаем колонки вручную
			dgvUsers.Columns.Add("id", "ID");
			dgvUsers.Columns.Add("first_name", "Имя");
			dgvUsers.Columns.Add("last_name", "Фамилия");
			dgvUsers.Columns.Add("email", "Email");
			dgvUsers.Columns.Add("total_score", "Баллы");
			dgvUsers.Columns.Add("resume_preview", "Превью резюме");
			dgvUsers.Columns.Add("status", "Статус");

			// Скрываем ID и статус
			dgvUsers.Columns["id"].Visible = false;
			dgvUsers.Columns["status"].Visible = false;

			// Настраиваем ширину колонок так, чтобы они занимали все доступное пространство
			int totalWidth = dgvUsers.Width - 40;
			int[] columnWidths = CalculateColumnWidths(totalWidth);

			dgvUsers.Columns["first_name"].Width = columnWidths[0];
			dgvUsers.Columns["last_name"].Width = columnWidths[1];
			dgvUsers.Columns["email"].Width = columnWidths[2];
			dgvUsers.Columns["total_score"].Width = columnWidths[3];
			dgvUsers.Columns["resume_preview"].Width = columnWidths[4];

			// Заполняем данными
			foreach (DataRow row in usersData.Rows)
			{
				int currentUserId = Convert.ToInt32(row["id"]);
				bool hasFileResume = CheckIfUserHasFileResume(currentUserId);
				string resumeText = row["resume_text"]?.ToString();

				string resumePreview;
				if (hasFileResume)
				{
					resumePreview = "📎 Файл резюме прикреплен";
				}
				else if (!string.IsNullOrEmpty(resumeText))
				{
					resumePreview = resumeText.Length > 150
						? resumeText.Substring(0, 150) + "..."
						: resumeText;
				}
				else
				{
					resumePreview = "Резюме отсутствует";
				}

				dgvUsers.Rows.Add(
					row["id"],
					row["first_name"],
					row["last_name"],
					row["email"],
					row["total_score"],
					resumePreview,
					row["status"]
				);
			}

			// Настраиваем стили для лучшего отображения
			dgvUsers.RowTemplate.Height = 35;
			dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
			dgvUsers.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
		}

		private bool CheckIfUserHasFileResume(int userId)
		{
			BDConnection database = new BDConnection();

			try
			{
				database.openConnection();

				string query = "SELECT COUNT(*) FROM user_resumes WHERE user_id = @userId";
				MySqlCommand command = new MySqlCommand(query, database.getConnection());
				command.Parameters.AddWithValue("@userId", userId);

				long count = Convert.ToInt64(command.ExecuteScalar());
				return count > 0;
			}
			catch (Exception)
			{
				return false;
			}
			finally
			{
				database.closeConnection();
			}
		}

		private int[] CalculateColumnWidths(int totalWidth)
		{
			int[] widths = new int[5];
			double[] ratios = { 0.15, 0.15, 0.25, 0.1, 0.35 };

			for (int i = 0; i < widths.Length; i++)
			{
				widths[i] = (int)(totalWidth * ratios[i]);
			}

			return widths;
		}

		private void TxtSearch_TextChanged(object sender, EventArgs e)
		{
			LoadUsers(txtSearch.Text.Trim());
		}

		private void BtnViewResume_Click(object sender, EventArgs e)
		{
			if (dgvUsers.SelectedRows.Count == 0)
			{
				MessageBox.Show("Выберите пользователя для просмотра резюме", "Информация",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			int selectedUserId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["id"].Value);
			string userName = dgvUsers.SelectedRows[0].Cells["first_name"].Value + " " +
							dgvUsers.SelectedRows[0].Cells["last_name"].Value;

			// Показываем диалог выбора действия
			var result = MessageBox.Show($"Что вы хотите сделать с резюме кандидата {userName}?\n\n" +
										"Да - Скачать файл резюме\nНет - Просмотреть текстовое резюме\nОтмена - Закрыть",
										"Резюме кандидата",
										MessageBoxButtons.YesNoCancel,
										MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				DownloadResumeFile(selectedUserId, userName);
			}
			else if (result == DialogResult.No)
			{
				ViewResumeText(selectedUserId);
			}
		}

		private void DownloadResumeFile(int userId, string userName)
		{
			BDConnection database = new BDConnection();

			try
			{
				database.openConnection();

				string query = "SELECT file_name, file_data, file_size FROM user_resumes WHERE user_id = @userId";
				MySqlCommand command = new MySqlCommand(query, database.getConnection());
				command.Parameters.AddWithValue("@userId", userId);

				using (MySqlDataReader reader = command.ExecuteReader())
				{
					if (reader.Read())
					{
						string fileName = reader["file_name"].ToString();
						long fileSize = Convert.ToInt64(reader["file_size"]);
						byte[] fileData = (byte[])reader["file_data"];

						// Диалог сохранения файла
						using (SaveFileDialog saveFileDialog = new SaveFileDialog())
						{
							saveFileDialog.FileName = $"Резюме_{userName.Replace(" ", "_")}_{fileName}";
							saveFileDialog.Filter = "Все файлы (*.*)|*.*";
							saveFileDialog.Title = "Сохранить резюме";

							if (saveFileDialog.ShowDialog() == DialogResult.OK)
							{
								// Сохраняем файл
								File.WriteAllBytes(saveFileDialog.FileName, fileData);

								MessageBox.Show($"Резюме успешно сохранено!\nФайл: {saveFileDialog.FileName}",
									"Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
							}
						}
					}
					else
					{
						MessageBox.Show("Файл резюме не найден для выбранного пользователя", "Информация",
							MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка загрузки резюме: {ex.Message}", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				database.closeConnection();
			}
		}

		private void ViewResumeText(int userId)
		{
			BDConnection database = new BDConnection();

			try
			{
				database.openConnection();

				// Сначала пробуем получить текстовое резюме
				string textQuery = "SELECT resume_text FROM users WHERE id = @userId";
				MySqlCommand textCommand = new MySqlCommand(textQuery, database.getConnection());
				textCommand.Parameters.AddWithValue("@userId", userId);

				object textResult = textCommand.ExecuteScalar();
				string resumeText = textResult?.ToString();

				// Если текстового резюме нет, пробуем получить файл
				if (string.IsNullOrEmpty(resumeText))
				{
					string fileQuery = "SELECT file_name, file_data FROM user_resumes WHERE user_id = @userId";
					MySqlCommand fileCommand = new MySqlCommand(fileQuery, database.getConnection());
					fileCommand.Parameters.AddWithValue("@userId", userId);

					using (MySqlDataReader reader = fileCommand.ExecuteReader())
					{
						if (reader.Read())
						{
							string fileName = reader["file_name"].ToString();
							byte[] fileData = (byte[])reader["file_data"];

							// Для текстовых файлов показываем содержимое
							if (fileName.ToLower().EndsWith(".txt"))
							{
								resumeText = System.Text.Encoding.UTF8.GetString(fileData);
							}
							else
							{
								resumeText = $"Файл резюме: {fileName}\n\nЭто бинарный файл. Для просмотра скачайте его.";
							}
						}
						else
						{
							resumeText = "Резюме отсутствует";
						}
					}
				}

				// Показываем резюме в форме
				ShowResumeForm(resumeText ?? "Резюме отсутствует");
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка загрузки резюме: {ex.Message}", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				database.closeConnection();
			}
		}

		private void ShowResumeForm(string resumeText)
		{
			Form resumeForm = new Form
			{
				Text = "Резюме кандидата",
				Size = new Size(700, 600),
				StartPosition = FormStartPosition.CenterParent,
				MaximizeBox = true
			};

			TextBox txtResume = new TextBox
			{
				Location = new Point(10, 10),
				Size = new Size(660, 520),
				Multiline = true,
				ScrollBars = ScrollBars.Both,
				ReadOnly = true,
				Text = resumeText,
				Font = new Font("Arial", 10),
				WordWrap = true
			};

			Button btnClose = new Button
			{
				Location = new Point(300, 540),
				Size = new Size(80, 30),
				Text = "Закрыть",
				DialogResult = DialogResult.OK
			};

			resumeForm.Controls.AddRange(new Control[] { txtResume, btnClose });
			resumeForm.AcceptButton = btnClose;
			resumeForm.ShowDialog();
		}

		// Остальные методы без изменений
		private void BtnInvite_Click(object sender, EventArgs e)
		{
			if (dgvUsers.SelectedRows.Count == 0)
			{
				MessageBox.Show("Выберите пользователя для приглашения", "Информация",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			int selectedUserId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["id"].Value);
			string userName = dgvUsers.SelectedRows[0].Cells["first_name"].Value + " " +
							dgvUsers.SelectedRows[0].Cells["last_name"].Value;

			var result = MessageBox.Show($"Пригласить кандидата {userName}?",
				"Подтверждение приглашения", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				UpdateUserStatus(selectedUserId, "invited", "invited");
				SendEmail(selectedUserId, "invite");
				LoadUsers(txtSearch.Text.Trim());
				MessageBox.Show("Кандидат приглашен!", "Успех",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void BtnReject_Click(object sender, EventArgs e)
		{
			if (dgvUsers.SelectedRows.Count == 0)
			{
				MessageBox.Show("Выберите пользователя для отклонения", "Информация",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			int selectedUserId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["id"].Value);
			string userName = dgvUsers.SelectedRows[0].Cells["first_name"].Value + " " +
							dgvUsers.SelectedRows[0].Cells["last_name"].Value;

			var result = MessageBox.Show($"Отклонить кандидата {userName}?",
				"Подтверждение отклонения", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				UpdateUserStatus(selectedUserId, "rejected", "rejected");
				SendEmail(selectedUserId, "reject");
				LoadUsers(txtSearch.Text.Trim());
				MessageBox.Show("Кандидат отклонен!", "Успех",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void UpdateUserStatus(int userId, string status, string action)
		{
			BDConnection database = new BDConnection();

			try
			{
				database.openConnection();

				string updateQuery = "UPDATE users SET status = @status WHERE id = @userId";
				MySqlCommand updateCommand = new MySqlCommand(updateQuery, database.getConnection());
				updateCommand.Parameters.AddWithValue("@status", status);
				updateCommand.Parameters.AddWithValue("@userId", userId);
				updateCommand.ExecuteNonQuery();

				string logQuery = @"INSERT INTO hr_actions (hr_user_id, target_user_id, action) 
                                  VALUES (@hrUserId, @targetUserId, @action)";
				MySqlCommand logCommand = new MySqlCommand(logQuery, database.getConnection());
				logCommand.Parameters.AddWithValue("@hrUserId", hrUserId);
				logCommand.Parameters.AddWithValue("@targetUserId", userId);
				logCommand.Parameters.AddWithValue("@action", action);
				logCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка обновления статуса: {ex.Message}", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				database.closeConnection();
			}
		}

		private void SendEmail(int userId, string actionType)
		{
			BDConnection database = new BDConnection();

			try
			{
				database.openConnection();

				string query = "SELECT first_name, last_name, phone FROM users WHERE id = @userId";
				MySqlCommand command = new MySqlCommand(query, database.getConnection());
				command.Parameters.AddWithValue("@userId", userId);

				using (var reader = command.ExecuteReader())
				{
					if (reader.Read())
					{
						string firstName = reader["first_name"].ToString();
						string lastName = reader["last_name"].ToString();
						string email = reader["phone"].ToString();

						string subject = actionType == "invite" ?
							"Приглашение на работу" : "Отказ по заявке";

						string body = actionType == "invite" ?
							$"Уважаемый(ая) {firstName} {lastName}, мы рады пригласить Вас на работу!" :
							$"Уважаемый(ая) {firstName} {lastName}, к сожалению, мы не можем предложить Вам работу на данный момент.";

						Console.WriteLine($"Email отправлен на {email}: {subject}");
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка отправки email: {ex.Message}");
			}
			finally
			{
				database.closeConnection();
			}
		}
	}
}