public static void DownloadFile(string username, string password, string server, string fileName, string pathToSave)
		{
			//Create FTP Request.
			FtpWebRequest request = (FtpWebRequest)WebRequest.Create(Path.Combine(server, fileName));
			request.Method = WebRequestMethods.Ftp.DownloadFile;

			//Enter FTP Server credentials.
			request.Credentials = new NetworkCredential(username, password);
			request.UsePassive = true;
			request.UseBinary = true;
			request.EnableSsl = false;

			//Fetch the Response and read it into a MemoryStream object.
			FtpWebResponse response = (FtpWebResponse)request.GetResponse();
			using (Stream responseStream = response.GetResponseStream())
			{
				using (Stream fileStream = new FileStream(Path.Combine(pathToSave, fileName), FileMode.CreateNew))
				{
					responseStream.CopyTo(fileStream);
				}
			}
		}
