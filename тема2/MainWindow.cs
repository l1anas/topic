using MySqlConnector;
using System.Data;
using System.Drawing.Drawing2D;
using System.Windows.Forms.Design;
using тема_1;

namespace тема2
{
	public partial class MainWindow : Form
	{
		private int userRole;
		private int userId;

		public MainWindow(int userId)
		{
			this.userId = userId;
			InitializeComponent();
			this.Height = 1200;

			this.Text += " (Пользователь)";
			ShowUserFeatures();
			this.FormBorderStyle = FormBorderStyle.FixedDialog;    // Фиксированные границы
			this.MaximizeBox = false;                              // Убрать кнопку максимизации
			this.MinimizeBox = false;                              // Убрать кнопку минимизации

		}

		private void ShowUserFeatures()
		{
			Button btnAttachResume = new Button
			{
				Text = "Прикрепить резюме",
				Location = new Point(382, 160),
				Size = new Size(995, 60),
				BackColor = Color.Transparent,
				ForeColor = Color.SteelBlue,
				Font = new Font("Times New Roman", 16, FontStyle.Regular),
				FlatStyle = FlatStyle.Flat,
				Cursor = Cursors.Hand,
				TextAlign = ContentAlignment.MiddleCenter
			};

			// Убираем все границы и эффекты
			btnAttachResume.FlatAppearance.BorderSize = 0;
			btnAttachResume.FlatAppearance.MouseOverBackColor = Color.Transparent;
			btnAttachResume.FlatAppearance.MouseDownBackColor = Color.Transparent;

			// Меняем цвет при наведении
			btnAttachResume.MouseEnter += (s, e) => { btnAttachResume.ForeColor = Color.DarkBlue; };
			btnAttachResume.MouseLeave += (s, e) => { btnAttachResume.ForeColor = Color.SteelBlue; };

			btnAttachResume.Click += BtnAttachResume_Click;
			this.Controls.Add(btnAttachResume);
			btnAttachResume.BringToFront();

			// Добавляем кнопку "Выйти"
			AddExitButton();
		}

		private void AddExitButton()
		{
			RoundButton btnExit = new RoundButton
			{
				Text = "Выйти",
				Location = new Point(682, 920),
				Size = new Size(400, 70),
				BackColor = Color.LightCoral,
				ForeColor = Color.DarkRed,
				Font = new Font("Times New Roman", 16, FontStyle.Bold),
				Cursor = Cursors.Hand
			};

			btnExit.Click += (s, e) =>
			{
				var result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение выхода",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (result == DialogResult.Yes)
				{
					Application.Exit();
				}
			};

			this.Controls.Add(btnExit);
			btnExit.BringToFront();
		}




		private void BtnAttachResume_Click(object sender, EventArgs e)
		{
			var result = MessageBox.Show($"Как вы хотите прикрепить резюме?\n\n" +
										"Да - Прикрепить файл\nНет - Ввести текст\nОтмена - Закрыть",
										"Прикрепление резюме",
										MessageBoxButtons.YesNoCancel,
										MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				AttachResumeFile();
			}
			else if (result == DialogResult.No)
			{
				InputResumeText();
			}
		}

		private void AttachResumeFile()
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

						if (fileSize > 10 * 1024 * 1024)
						{
							MessageBox.Show("Файл слишком большой. Максимальный размер - 10MB.", "Ошибка",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}

						byte[] fileData = File.ReadAllBytes(filePath);
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

		private void InputResumeText()
		{
			Form textInputForm = new Form
			{
				Text = "Ввод текста резюме",
				Size = new Size(800, 650),
				StartPosition = FormStartPosition.CenterParent,
				MaximizeBox = false,
				MinimizeBox = false,
				FormBorderStyle = FormBorderStyle.FixedDialog,
				BackColor = Color.LemonChiffon
			};

			Label lblTitle = new Label
			{
				Text = "Введите текст вашего резюме:",
				Location = new Point(50, 7),
				Size = new Size(700, 50),
				Font = new Font("Times New Roman", 16, FontStyle.Regular),
				ForeColor = Color.FromArgb(64, 64, 64),
				TextAlign = ContentAlignment.MiddleCenter
			};

			TextBox txtResume = new TextBox
			{
				Location = new Point(50, 90),
				Size = new Size(700, 300),
				Multiline = true,
				ScrollBars = ScrollBars.Vertical,
				Font = new Font("Arial", 11),
				MaxLength = 2000,
				BackColor = Color.White,
				BorderStyle = BorderStyle.FixedSingle
			};

			Label lblCharCount = new Label
			{
				Text = $"Символов: 0/{txtResume.MaxLength}",
				Location = new Point(50, 400),
				Size = new Size(300, 30),
				Font = new Font("Arial", 10),
				ForeColor = Color.Gray
			};

			txtResume.TextChanged += (s, e) =>
			{
				lblCharCount.Text = $"Символов: {txtResume.Text.Length}/{txtResume.MaxLength}";

				if (txtResume.Text.Length > txtResume.MaxLength * 0.9)
				{
					lblCharCount.ForeColor = Color.Red;
				}
				else if (txtResume.Text.Length > txtResume.MaxLength * 0.7)
				{
					lblCharCount.ForeColor = Color.Orange;
				}
				else
				{
					lblCharCount.ForeColor = Color.Gray;
				}
			};

			RoundButton btnSave = new RoundButton
			{
				Text = "Сохранить",
				Location = new Point(160, 450),
				Size = new Size(220, 60),
				BackColor = Color.YellowGreen,
				ForeColor = Color.FromArgb(64, 64, 64),
				Font = new Font("Times New Roman", 14, FontStyle.Bold),
				Cursor = Cursors.Hand
			};

			RoundButton btnCancel = new RoundButton
			{
				Text = "Отмена",
				Location = new Point(420, 450),
				Size = new Size(180, 60),
				BackColor = Color.YellowGreen,
				ForeColor = Color.FromArgb(64, 64, 64),
				Font = new Font("Times New Roman", 14, FontStyle.Bold),
				Cursor = Cursors.Hand
			};

			btnSave.Click += (s, e) =>
			{
				if (string.IsNullOrWhiteSpace(txtResume.Text))
				{
					MessageBox.Show("Введите текст резюме", "Предупреждение",
						MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				if (txtResume.Text.Length > txtResume.MaxLength)
				{
					MessageBox.Show($"Превышен лимит символов. Максимум: {txtResume.MaxLength}", "Ошибка",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				SaveTextResumeToDatabase(txtResume.Text.Trim());
				textInputForm.DialogResult = DialogResult.OK;
				textInputForm.Close();
			};

			btnCancel.Click += (s, e) =>
			{
				textInputForm.DialogResult = DialogResult.Cancel;
				textInputForm.Close();
			};

			Label lblHint = new Label
			{
				Text = "Максимальная длина резюме: 2000 символов",
				Location = new Point(50, 520),
				Size = new Size(700, 25),
				Font = new Font("Arial", 9),
				ForeColor = Color.DarkGray,
				TextAlign = ContentAlignment.MiddleCenter
			};

			textInputForm.Controls.AddRange(new Control[] {
				lblTitle, txtResume, lblCharCount, btnSave, btnCancel, lblHint
			});

			textInputForm.AcceptButton = btnSave;
			textInputForm.CancelButton = btnCancel;

			if (textInputForm.ShowDialog() == DialogResult.OK)
			{
				MessageBox.Show("Текстовое резюме успешно сохранено!", "Успех",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void SaveTextResumeToDatabase(string resumeText)
		{
			BDConnection database = new BDConnection();

			try
			{
				database.openConnection();

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

				string deleteFileQuery = "DELETE FROM user_resumes WHERE user_id = @userId";
				MySqlCommand deleteFileCommand = new MySqlCommand(deleteFileQuery, database.getConnection());
				deleteFileCommand.Parameters.AddWithValue("@userId", userId);
				deleteFileCommand.ExecuteNonQuery();

				string updateQuery = "UPDATE users SET resume_text = @resumeText WHERE id = @userId";
				MySqlCommand updateCommand = new MySqlCommand(updateQuery, database.getConnection());
				updateCommand.Parameters.AddWithValue("@resumeText", resumeText);
				updateCommand.Parameters.AddWithValue("@userId", userId);

				int rowsAffected = updateCommand.ExecuteNonQuery();

				if (rowsAffected > 0)
				{
					Console.WriteLine("Текстовое резюме успешно сохранено в базу данных");
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

		private void SaveResumeFileToDatabase(string fileName, byte[] fileData, long fileSize)
		{
			BDConnection database = new BDConnection();

			try
			{
				database.openConnection();

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

				string deleteQuery = "DELETE FROM user_resumes WHERE user_id = @userId";
				MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, database.getConnection());
				deleteCommand.Parameters.AddWithValue("@userId", userId);
				deleteCommand.ExecuteNonQuery();

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
			Form1 form1 = new Form1(userId);
			form1.Show();
		}

		private void roundButton1_Click(object sender, EventArgs e)
		{
			this.Hide();
			Topic2Test1 topic2 = new Topic2Test1(userId);
			topic2.Show();
		}

		private void buttTest3_Click(object sender, EventArgs e)
		{
			this.Hide();
			Topic3Test1 topic3 = new Topic3Test1(userId);
			topic3.Show();
		}

		private void buttTest4_Click(object sender, EventArgs e)
		{
			this.Hide();
			Topic4Test1 topic4 = new Topic4Test1(userId);
			topic4.Show();
		}

		private void buttText5_Click(object sender, EventArgs e)
		{
			this.Hide();
			Topic5Test1 topic5 = new Topic5Test1(userId);
			topic5.Show();
		}

		private void buttTest6_Click(object sender, EventArgs e)
		{
			this.Hide();
			Topic6Test1 topic6 = new Topic6Test1(userId);
			topic6.Show();
		}

		private void buttTest7_Click(object sender, EventArgs e)
		{
			this.Hide();
			Topic7Test1 topic7 = new Topic7Test1(userId);
			topic7.Show();
		}
	}
}