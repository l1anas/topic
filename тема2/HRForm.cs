using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
		private Button btnViewResume;
		private Button btnInvite;
		private Button btnReject;
		private Button btnExit; // Новая кнопка выхода

		// Кастомная кнопка с закругленными углами
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

		public HRForm(int userId)
		{
			hrUserId = userId;
			InitializeComponent();
			this.ActiveControl = null; // Убираем фокус с поля поиска
			LoadUsers();
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();

			// Настройка формы
			this.Text = "HR Panel - Управление кандидатами";
			this.Size = new Size(1700, 1300); // Увеличили высоту формы для кнопки выхода
			this.StartPosition = FormStartPosition.CenterScreen;
			this.BackColor = Color.LemonChiffon;

			// Заголовок
			Label lblTitle = new Label
			{
				Text = "Управление кандидатами",
				Font = new Font("Times New Roman", 20, FontStyle.Bold),
				ForeColor = Color.FromArgb(64, 64, 64),
				Location = new Point(20, 20),
				Size = new Size(1660, 60),
				TextAlign = ContentAlignment.MiddleCenter
			};

			// Панель для поиска (для центрирования)
			Panel searchPanel = new Panel
			{
				Location = new Point(20, 90),
				Size = new Size(1660, 50),
				BackColor = Color.Transparent,
			};

			// Поле поиска (центрированное)
			txtSearch = new TextBox
			{
				Size = new Size(1300, 40),
				Font = new Font("Arial", 12),
				PlaceholderText = "Поиск по имени, фамилии или email...",
				BackColor = Color.White,
				ForeColor = Color.FromArgb(64, 64, 64),
				TabStop = false // Отключаем табуляцию на это поле
			};

			// Центрируем поле поиска
			txtSearch.Location = new Point((searchPanel.Width - txtSearch.Width) / 2, 5);
			txtSearch.TextChanged += TxtSearch_TextChanged;

			// DataGridView для отображения пользователей
			dgvUsers = new DataGridView
			{
				Location = new Point(20, 160),
				Size = new Size(1660, 850),
				AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None,
				SelectionMode = DataGridViewSelectionMode.FullRowSelect,
				ReadOnly = true,
				AllowUserToAddRows = false,
				AllowUserToDeleteRows = false,
				RowHeadersVisible = false,
				Font = new Font("Arial", 10),
				ScrollBars = ScrollBars.Both,
				AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
				BackgroundColor = Color.White,
				BorderStyle = BorderStyle.None,
				GridColor = Color.LightGray
			};

			// Панель для центрирования основных кнопок
			Panel mainButtonPanel = new Panel
			{
				Location = new Point(20, 1020),
				Size = new Size(1660, 80),
				BackColor = Color.Transparent
			};

			// Панель для кнопки выхода
			Panel exitButtonPanel = new Panel
			{
				Location = new Point(20, 1110),
				Size = new Size(1660, 80),
				BackColor = Color.Transparent
			};

			// Кнопка просмотра резюме (размер как был)
			btnViewResume = new RoundButton
			{
				Size = new Size(400, 70),
				Text = "Просмотреть резюме",
				BackColor = Color.LightSkyBlue, // Нежно-голубой
				ForeColor = Color.FromArgb(64, 64, 64),
				Font = new Font("Arial", 12, FontStyle.Bold),
				Cursor = Cursors.Hand
			};
			btnViewResume.Click += BtnViewResume_Click;

			// Кнопка пригласить (размер как был)
			btnInvite = new RoundButton
			{
				Size = new Size(250, 70),
				Text = "Пригласить",
				BackColor = Color.LightSkyBlue, // Нежно-зеленый
				ForeColor = Color.FromArgb(64, 64, 64),
				Font = new Font("Arial", 12, FontStyle.Bold),
				Cursor = Cursors.Hand
			};
			btnInvite.Click += BtnInvite_Click;

			// Кнопка отклонить (размер как был)
			btnReject = new RoundButton
			{
				Size = new Size(250, 70),
				Text = "Отклонить",
				BackColor = Color.LightSkyBlue, // Нежно-коралловый
				ForeColor = Color.FromArgb(64, 64, 64),
				Font = new Font("Arial", 12, FontStyle.Bold),
				Cursor = Cursors.Hand
			};
			btnReject.Click += BtnReject_Click;

			// Кнопка выхода (отдельно под основными кнопками)
			btnExit = new RoundButton
			{
				Size = new Size(200, 70), // Чуть меньше основных кнопок
				Text = "Выйти",
				BackColor = Color.LightCoral,
				ForeColor = Color.FromArgb(64, 64, 64),
				Font = new Font("Arial", 12, FontStyle.Bold),
				Cursor = Cursors.Hand
			};
			btnExit.Click += BtnExit_Click;

			// Выравниваем основные кнопки на верхней панели
			int totalMainButtonsWidth = btnViewResume.Width + btnInvite.Width + btnReject.Width + 40;
			int startXMain = (mainButtonPanel.Width - totalMainButtonsWidth) / 2;

			btnViewResume.Location = new Point(startXMain, 10);
			btnInvite.Location = new Point(startXMain + btnViewResume.Width + 20, 10);
			btnReject.Location = new Point(startXMain + btnViewResume.Width + btnInvite.Width + 40, 10);

			// Центрируем кнопку выхода на нижней панели
			btnExit.Location = new Point((exitButtonPanel.Width - btnExit.Width) / 2, 10);

			// Добавляем элементы на панели
			searchPanel.Controls.Add(txtSearch);
			mainButtonPanel.Controls.AddRange(new Control[] { btnViewResume, btnInvite, btnReject });
			exitButtonPanel.Controls.Add(btnExit);

			// Добавляем элементы на форму
			this.Controls.AddRange(new Control[] {
				lblTitle,
				searchPanel,
				dgvUsers,
				mainButtonPanel,
				exitButtonPanel
			});

			this.ResumeLayout(false);
		}

		private void BtnExit_Click(object sender, EventArgs e)
		{
			var result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение выхода",
				MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				Application.Exit(); // или this.Close() если хотите только закрыть эту форму
			}
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
                COALESCE(SUM(tr.score), 0) as total_score,
                u.resume_text,
                u.status
            FROM users u 
            LEFT JOIN test_results tr ON u.id = tr.user_id
            WHERE u.role = 'user' 
            AND u.status = 'pending'
            AND u.is_active = 1";

				if (!string.IsNullOrEmpty(searchTerm))
				{
					query += @" AND (u.first_name LIKE @search 
                          OR u.last_name LIKE @search 
                          OR u.phone LIKE @search)";
				}

				query += " GROUP BY u.id, u.first_name, u.last_name, u.phone, u.resume_text, u.status";
				query += " ORDER BY total_score DESC";

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
				dgvUsers.Columns["empty"].DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
				dgvUsers.Columns["empty"].DefaultCellStyle.Font = new Font("Arial", 12);
				dgvUsers.Columns["empty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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

			// Настраиваем стили для заголовков
			dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSkyBlue;
			dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
			dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
			dgvUsers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

			// Настраиваем стили для строк
			dgvUsers.DefaultCellStyle.BackColor = Color.White;
			dgvUsers.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
			dgvUsers.DefaultCellStyle.Font = new Font("Arial", 10);
			dgvUsers.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
			dgvUsers.DefaultCellStyle.SelectionForeColor = Color.FromArgb(64, 64, 64);

			// Альтернативный цвет строк
			dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon;

			// Настраиваем ширину колонок так, чтобы они занимали все доступное пространство
			int totalWidth = dgvUsers.Width - 40;
			int[] columnWidths = CalculateColumnWidths(totalWidth);

			dgvUsers.Columns["first_name"].Width = columnWidths[0];
			dgvUsers.Columns["last_name"].Width = columnWidths[1];
			dgvUsers.Columns["email"].Width = columnWidths[2];
			dgvUsers.Columns["total_score"].Width = columnWidths[3];
			dgvUsers.Columns["resume_preview"].Width = columnWidths[4];

			// Настраиваем выравнивание
			dgvUsers.Columns["total_score"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
			dgvUsers.RowTemplate.Height = 40;
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
				MaximizeBox = true,
				BackColor = Color.LemonChiffon
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
				WordWrap = true,
				BackColor = Color.White,
				ForeColor = Color.FromArgb(64, 64, 64)
			};

			RoundButton btnClose = new RoundButton
			{
				Location = new Point(300, 540),
				Size = new Size(100, 40),
				Text = "Закрыть",
				BackColor = Color.LightSkyBlue,
				ForeColor = Color.FromArgb(64, 64, 64),
				Font = new Font("Arial", 10, FontStyle.Bold),
				DialogResult = DialogResult.OK
			};

			resumeForm.Controls.AddRange(new Control[] { txtResume, btnClose });
			resumeForm.AcceptButton = btnClose;
			resumeForm.ShowDialog();
		}

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

						string subject, body;

						if (actionType == "invite")
						{
							subject = "Приглашение на работу в нашу компанию";
							body = $@"
<html>
<body style='font-family: Arial, sans-serif; line-height: 1.6;'>
    <h2 style='color: #2E8B57;'>Уважаемый(ая) {firstName} {lastName}!</h2>
    
    <p>Мы рады сообщить, что Вы успешно прошли отбор и мы хотим пригласить Вас 
    на позицию в нашу компанию!</p>
    
    <p>Ваши результаты тестирования и резюме произвели на нас очень хорошее впечатление.</p>
    
    <h3 style='color: #2E8B57;'>Следующие шаги:</h3>
    <ul>
        <li>Наш HR-менеджер свяжется с Вами в течение 2 рабочих дней</li>
        <li>Обсудим детали сотрудничества и ответим на все Ваши вопросы</li>
        <li>Запланируем собеседование с техническим специалистом</li>
    </ul>
    
    <p>Если у Вас есть срочные вопросы, Вы можете ответить на это письмо.</p>
    
    <p>С уважением,<br>
    <strong>HR-отдел</strong><br>
    Наша компания</p>
    
    <hr style='border: none; border-top: 1px solid #eee;'>
    <p style='font-size: 12px; color: #666;'>
        Это письмо сгенерировано автоматически. Пожалуйста, не отвечайте на него.
    </p>
</body>
</html>";
						}
						else // reject
						{
							subject = "Ответ на вашу заявку";
							body = $@"
<html>
<body style='font-family: Arial, sans-serif; line-height: 1.6;'>
    <h2 style='color: #D9534F;'>Уважаемый(ая) {firstName} {lastName}!</h2>
    
    <p>Благодарим Вас за проявленный интерес к нашей компании и время, 
    уделенное на прохождение отбора.</p>
    
    <p>После тщательного рассмотрения Вашей кандидатуры и результатов тестирования, 
    мы, к сожалению, не можем предложить Вам позицию в нашей компании на данный момент.</p>
    
    <p>Это решение не является оценкой Ваших профессиональных качеств. 
    Мы сохраним Ваше резюме в нашей базе и свяжемся с Вами, 
    если появится подходящая возможность в будущем.</p>
    
    <p>Желаем Вам успехов в поиске работы и надеемся на возможность 
    сотрудничества в будущем!</p>
    
    <p>С уважением,<br>
    <strong>HR-отдел</strong><br>
    Наша компания</p>
    
    <hr style='border: none; border-top: 1px solid #eee;'>
    <p style='font-size: 12px; color: #666;'>
        Это письмо сгенерировано автоматически. Пожалуйста, не отвечайте на него.
    </p>
</body>
</html>";
						}

						// Отправляем email
						bool emailSent = EmailService.SendEmail(email, subject, body);

						if (emailSent)
						{
							Console.WriteLine($"Email успешно отправлен на {email}: {subject}");
						}
						else
						{
							MessageBox.Show($"Не удалось отправить email на {email}", "Ошибка отправки",
								MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка при подготовке email: {ex.Message}", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				database.closeConnection();
			}
		}
	}
}