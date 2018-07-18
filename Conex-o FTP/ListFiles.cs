// LISTANDO NOME DE ARQUIVOS QUE CONSTAM NO FTP

public static List<string> ListFiles(string username, string password, string server)
{
			FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(new Uri(server));
			ftpRequest.Credentials = new NetworkCredential(username, password);
			ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
			FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
			StreamReader streamReader = new StreamReader(response.GetResponseStream());

			List<string> directories = new List<string>();

			string line = streamReader.ReadLine();
			while (!string.IsNullOrEmpty(line))
			{
				directories.Add(line);
				line = streamReader.ReadLine();
			}

			streamReader.Close();

			return directories;
}
