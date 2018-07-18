// Upload de Arquivo para FTP

private static void UploadFileToFtp(string fileNameFace, string pathNameFace, string username, string password, string server, string nomePasta)
		{
			FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri($"{server}/{nomePasta}/{fileNameFace}"));
			request.Method = WebRequestMethods.Ftp.UploadFile;
			request.Credentials = new NetworkCredential(username, password);
			Stream ftpStream = request.GetRequestStream();

			FileStream fs = File.OpenRead(pathNameFace);

			byte[] buffer = new byte[1024];
			double total = (double)fs.Length;
			int byteRead = 0;
			double read = 0;

			do
			{
				byteRead = fs.Read(buffer, 0, 1024);
				ftpStream.Write(buffer, 0, byteRead);
				read += (double)byteRead;

			} while (byteRead != 0);
			fs.Close();
			ftpStream.Close();
		}
