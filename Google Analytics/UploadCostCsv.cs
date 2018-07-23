using Google.Apis.Analytics.v3;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

private static async Task TesteAssync()
		{
			string path = Environment.CurrentDirectory + @"\Credentials\client_secrets.json";
			string pathxls = Environment.CurrentDirectory + @"\Arquivos\Importa Custo Teste - template.csv";

			string file = System.IO.Path.Combine(Environment.CurrentDirectory, "\\Credentials\\client_secrets.json");

			UserCredential credential;
			using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
					GoogleClientSecrets.Load(stream).Secrets,
					new[] { AnalyticsService.Scope.Analytics },
					"user", CancellationToken.None);
			}

			// Create the service.
			var service = new AnalyticsService(new BaseClientService.Initializer()
			{
				HttpClientInitializer = credential,
				ApplicationName = "Nome Aplicação",
			});

			FileStream stream2 = new FileStream(pathxls, FileMode.Open);

			service.Management.Uploads.UploadData("123", "UA-123", "sdadsad", stream2, "application/octet-stream").Upload();
		}
