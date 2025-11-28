using MySqlConnector;
using System.Data;
using System.Windows.Forms.Design;
using тема_1;

namespace тема2
{
	public partial class MainWindow : Form
	{
		private int userRole;
		private int userId; // Добавляем ID пользователя

		public MainWindow(int role, int userId = 0)
		{
			this.userId = userId;
			InitializeComponent();
			userRole = role;

			if (userRole == 2) // HR
			{
				this.Text += " (HR)";
				ShowHRPanel();
			}
			else if (userRole == 3) // Психолог
			{
				this.Text += " (Психолог)";
				ShowPsychologistFeatures();
			}
			else // Обычный пользователь
			{
				this.Text += " (Пользователь)";
				ShowUserFeatures();
			}
		}

		private void ShowHRPanel()
		{
			Button btnHRPanel = new Button
			{
				Text = "Панель HR",
				Location = new Point(20, 20),
				Size = new Size(120, 40),
				BackColor = Color.SteelBlue,
				ForeColor = Color.White,
				Font = new Font("Arial", 10, FontStyle.Bold)
			};
			btnHRPanel.Click += (s, e) =>
			{
				HRForm hrForm = new HRForm(userId);
				hrForm.Show();
			};

			this.Controls.Add(btnHRPanel);
		}

		private void ShowUserFeatures()
		{
			// Кнопка "Прикрепить резюме"
			Button btnAttachResume = new Button
			{
				Text = "📎",
				Location = new Point(20, 20),
				Size = new Size(40, 40),
				BackColor = Color.Gold,
				ForeColor = Color.Black,
				Font = new Font("Arial", 24, FontStyle.Bold)
			};
			btnAttachResume.Click += BtnAttachResume_Click;

			this.Controls.Add(btnAttachResume);
		}

		private void ShowPsychologistFeatures()
		{
			// Здесь можно добавить функционал для психолога
			Label lblPsychologist = new Label
			{
				Text = "Панель психолога",
				Location = new Point(20, 20),
				Size = new Size(200, 30),
				Font = new Font("Arial", 12, FontStyle.Bold),
				ForeColor = Color.DarkBlue
			};

			this.Controls.Add(lblPsychologist);
		}

		private void BtnAttachResume_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "Документы (*.pdf;*.doc;*.docx;*.txt)|*.pdf;*.doc;*.docx;*.txt|Все файлы (*.*)|*.*";
				openFileDialog.FilterIndex = 1;
				openFileDialog.RestoreDirectory = true;
				openFileDialog.Title = "Выберите файл резюме";
				openFileDialog.Multiselect = false;

				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					try
					{
						string filePath = openFileDialog.FileName;
						string fileName = Path.GetFileName(filePath);
						long fileSize = new FileInfo(filePath).Length;

						// Проверка размера файла (например, максимум 10MB)
						if (fileSize > 10 * 1024 * 1024)
						{
							MessageBox.Show("Файл слишком большой. Максимальный размер - 10MB.", "Ошибка",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}

						// Читаем файл в массив байтов
						byte[] fileData = File.ReadAllBytes(filePath);

						// Сохраняем файл в базу данных
						SaveResumeFileToDatabase(fileName, fileData, fileSize);

						MessageBox.Show($"Резюме успешно прикреплено!\nФайл: {fileName}", "Успех",
							MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					catch (Exception ex)
					{
						MessageBox.Show($"Ошибка при загрузке резюме: {ex.Message}", "Ошибка",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void SaveResumeFileToDatabase(string fileName, byte[] fileData, long fileSize)
		{
			BDConnection database = new BDConnection();

			try
			{
				database.openConnection();

				// Сначала проверяем существует ли пользователь
				string checkUserQuery = "SELECT COUNT(*) FROM users WHERE id = @userId";
				MySqlCommand checkCommand = new MySqlCommand(checkUserQuery, database.getConnection());
				checkCommand.Parameters.AddWithValue("@userId", userId);

				long userExists = Convert.ToInt64(checkCommand.ExecuteScalar());

				if (userExists == 0)
				{
					MessageBox.Show("Ошибка: пользователь не найден в базе данных", "Ошибка",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				// Удаляем старое резюме если есть
				string deleteQuery = "DELETE FROM user_resumes WHERE user_id = @userId";
				MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, database.getConnection());
				deleteCommand.Parameters.AddWithValue("@userId", userId);
				deleteCommand.ExecuteNonQuery();

				// Сохраняем новое резюме
				string insertQuery = @"INSERT INTO user_resumes (user_id, file_name, file_data, file_size, file_type) 
                             VALUES (@userId, @fileName, @fileData, @fileSize, @fileType)";
				MySqlCommand insertCommand = new MySqlCommand(insertQuery, database.getConnection());
				insertCommand.Parameters.AddWithValue("@userId", userId);
				insertCommand.Parameters.AddWithValue("@fileName", fileName);
				insertCommand.Parameters.AddWithValue("@fileData", fileData);
				insertCommand.Parameters.AddWithValue("@fileSize", fileSize);
				insertCommand.Parameters.AddWithValue("@fileType", GetMimeType(fileName));

				int rowsAffected = insertCommand.ExecuteNonQuery();

				if (rowsAffected > 0)
				{
					Console.WriteLine("Файл резюме успешно сохранен в базу данных");

					// Также обновляем текстовое поле для совместимости
					UpdateUserResumeText();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка сохранения резюме в базу данных: {ex.Message}", "Ошибка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				database.closeConnection();
			}
		}

		// Метод для определения MIME типа файла
		private string GetMimeType(string fileName)
		{
			string extension = Path.GetExtension(fileName).ToLower();
			switch (extension)
			{
				case ".pdf": return "application/pdf";
				case ".doc": return "application/msword";
				case ".docx": return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
				case ".txt": return "text/plain";
				default: return "application/octet-stream";
			}
		}

		// Метод для обновления текстового поля резюме (для обратной совместимости)
		private void UpdateUserResumeText()
		{
			BDConnection database = new BDConnection();

			try
			{
				database.openConnection();

				string query = "UPDATE users SET resume_text = @resumeText WHERE id = @userId";
				MySqlCommand command = new MySqlCommand(query, database.getConnection());
				command.Parameters.AddWithValue("@resumeText", "Резюме прикреплено в виде файла");
				command.Parameters.AddWithValue("@userId", userId);

				command.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка обновления текста резюме: {ex.Message}");
			}
			finally
			{
				database.closeConnection();
			}
		}

		// Остальные методы без изменений
		private void button1_Click(object sender, EventArgs e)
		{
			this.Hide();
			Form1 form1 = new Form1();
			form1.Show();
		}

		private void roundButton1_Click(object sender, EventArgs e)
		{
			this.Hide();
			Topic2Test1 topic2 = new Topic2Test1();
			topic2.Show();
		}

		private void buttTest3_Click(object sender, EventArgs e)
		{
			this.Hide();
			Topic3Test1 topic3 = new Topic3Test1();
			topic3.Show();
		}

		private void buttTest4_Click(object sender, EventArgs e)
		{
			this.Hide();
			Topic4Test1 topic4 = new Topic4Test1();
			topic4.Show();
		}

		private void buttText5_Click(object sender, EventArgs e)
		{
			this.Hide();
			Topic5Test1 topic5 = new Topic5Test1();
			topic5.Show();
		}

		private void buttTest6_Click(object sender, EventArgs e)
		{
			this.Hide();
			Topic6Test1 topic6 = new Topic6Test1();
			topic6.Show();
		}

		private void buttTest7_Click(object sender, EventArgs e)
		{
			this.Hide();
			Topic7Test1 topic7 = new Topic7Test1();
			topic7.Show();
		}
	}
}