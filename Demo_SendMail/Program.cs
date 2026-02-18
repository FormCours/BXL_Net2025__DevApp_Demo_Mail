// Demo d'utilisation de MailKit
// *****************************
using MailKit.Net.Smtp;
using MimeKit;

// Configs
string smtpHost = "localhost";
int smtpPort = 25;
string appEmail = "no-reply@demo.be";
string appName = "Demo App";

// Mail
// - Création du mail
MimeMessage message = new MimeMessage();

// - Information de base
message.From.Add(new MailboxAddress(appName, appEmail));
message.To.Add(new MailboxAddress("Vladimir", "v.brasseur@bruxellesformation.brussels"));
message.Subject = "Hello World";

// - Ajout du contenu du mail
BodyBuilder bodyBuilder = new BodyBuilder();

bodyBuilder.TextBody = "Lorem ipsum dolor sit amet consectetur, adipisicing elit. (Vieux client)";
bodyBuilder.HtmlBody = @"
<div>
    <h1 style=""color: deeppink;"">Client modern 🦊</h1>
    <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit.</p>
</div>";

message.Body = bodyBuilder.ToMessageBody();

// Envoi du mail
using (SmtpClient smtpClient = new SmtpClient())
{
    try
    {
        // - Connexion au serveur Smtp
        smtpClient.Connect(smtpHost, smtpPort, false);

        // - Authentification
        smtpClient.Authenticate("DellaMail", "Test1234=");

        // - Envoi du mail 
        smtpClient.Send(message);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        smtpClient.Disconnect(true);
    }
}