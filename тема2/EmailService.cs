using System.Net;
using System.Net.Mail;
using System.Configuration;

public static class EmailService
{
	private static string smtpServer = "smtp.gmail.com"; // или ваш SMTP сервер
	private static int smtpPort = 587;
	private static string smtpUsername = "fnfillms@gmail.com"; // ваша почта
	private static string smtpPassword = "ljwb wrks nxir edpc"; // пароль приложения

	public static bool SendEmail(string toEmail, string subject, string body)
	{
		try
		{
			using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
			{
				smtpClient.EnableSsl = true;
				smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
				smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

				MailMessage mailMessage = new MailMessage();
				mailMessage.From = new MailAddress(smtpUsername, "HR Department");
				mailMessage.To.Add(toEmail);
				mailMessage.Subject = subject;
				mailMessage.Body = body;
				mailMessage.IsBodyHtml = true;

				smtpClient.Send(mailMessage);
				return true;
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Ошибка отправки email: {ex.Message}");
			return false;
		}
	}
}