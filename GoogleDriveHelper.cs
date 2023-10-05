using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Requests;
using Google.Apis.Services;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace InterViewScheduler
{
    public class GoogleDriveHelper
    {
        #region "Google Servicess"

        public void Test() {
            //DriveService service = null;
            //service = GetServicess();
            //service.Permissions.Get(,);
        }
        public DriveService GetServicess()
        {
            DriveService service;
            try
            {
                string[] scopes = new string[] { DriveService.Scope.Drive,
                               DriveService.Scope.DriveFile,};
               // var clientId = "472130817863-lbbl2lle1tdsudfc2pnrg638knuqhmh2.apps.googleusercontent.com";      // From https://console.developers.google.com  
               // var clientSecret = "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";          // From https://console.developers.google.com  


                var clientId = "472130817863-5cba71lqpmdl1stlhn60a9je24us1lk7.apps.googleusercontent.com";      // From https://console.developers.google.com  
                var clientSecret = "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";          // From https://console.developers.google.com  

                // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%  
                var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret
                }, scopes,
                Environment.UserName, CancellationToken.None, new FileDataStore("MyAppsToken")).Result;
                //Once consent is recieved, your token will be stored locally on the AppData directory, so that next time you wont be prompted for consent.   

                service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "MyAppName",

                });

            }
            catch (Exception)
            {

                throw;
            }
            return service;
        }
        public DriveService GetServicess_JSOn() {
            DriveService service = null;
            try
            {
                UserCredential credential;
                using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    credPath = Path.Combine(credPath, ".credentials/drive-dotnet-quickstart");
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        new[] {
                       DriveService.Scope.Drive, DriveService.Scope.DriveFile
                        },
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                }

                // Create Google Drive API service.
                service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "GoogleDriveHelper",

                });
            }
            catch
            {
                throw;
            }
            return service;
        }
        /// <summary>
        /// Create the google servicess, using client id and secret key
        /// </summary>
        /// <returns></returns>
        public DriveService GetServicess_Working()
        {
            DriveService service;
            try
            {
                string[] scopes = new string[] { DriveService.Scope.Drive,
                               DriveService.Scope.DriveFile,};
                var clientId = "486657048992-197fmta58hrdkitgakrpfschm29aa7os.apps.googleusercontent.com";      // From https://console.developers.google.com  
                var clientSecret = "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";          // From https://console.developers.google.com  
                                                                                   // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%  
                var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret
                }, scopes,
                Environment.UserName, CancellationToken.None, new FileDataStore("MyAppsToken")).Result;
                //Once consent is recieved, your token will be stored locally on the AppData directory, so that next time you wont be prompted for consent.   

                service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "MyAppName",

                });

            }
            catch (Exception)
            {

                throw;
            }
            return service;
        }
        #endregion

        #region "Create Folder in google drive"
        /// <summary>
        /// Create folder for douemnt or resume upload  
        /// </summary>
        /// <param name="folderName">provider folder name that you want to create</param>
        /// <param name="parentFolderID">Parent folder name</param>
        /// <returns></returns>
        public string CreateFolder(string folderName, string parentFolderID = "")
        {
            DriveService service = null;
            string FolderID = "";
            service = GetServicess();


            //Permission permission = new Permission() { Role = "reader", Type = "group", EmailAddress = "anzar.ansari@wonderbiz.in" };
           // List<Permission> permissions = new List<Permission>();
           // permissions.Add(permission);
            try
            {

                // File metadata
                var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                   // Permissions = permissions,
                    WritersCanShare = true,
                    Name = folderName,
                    MimeType = "application/vnd.google-apps.folder"


                };

                if (parentFolderID != "")
                {
                    fileMetadata.Parents = new string[] { parentFolderID };
                }

                // Create a new folder on drive.
                var request = service.Files.Create(fileMetadata);
                request.Fields = "id";
                var file = request.Execute();
                // Prints the created folder id.
                Console.WriteLine("Folder ID: " + file.Id);

                //service.Permissions.Create(permission, file.Id).Execute();


                
               
                FolderID = file.Id;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return FolderID;
        }
        #endregion

       



        #region "Check folder already present or not"
        /// <summary>
        /// Check if folder already present or not if present return the folder id
        /// </summary>
        /// <param name="folderName">folder name that you want to check</param>
        /// <returns>if present then retun the folder id else return blank</returns>
        public string FolderExists(string folderName, string parentID = "", string searchFile = "")
        {
            string FolderID = "";
            DriveService service;

            service = GetServicess();

            try
            {
                //string query = "mimeType!='application/vnd.google-apps.folder' and trashed = false";
                string query = " trashed = false ";
                if (parentID != "")
                {
                    query += " and '" + parentID + "' in parents";
                }

                if (searchFile != "")
                {
                    query += " and name contains '" + searchFile + "' in parents";
                }


                // if (!folderName.Contains(".docx"))
                query += " and mimeType = 'application/vnd.google-apps.folder' ";

               query += " and  fullText contains '" + folderName + "' ";

                var newFile = new Google.Apis.Drive.v3.Data.File { Name = folderName, MimeType = "application/vnd.google-apps.folder and trashed = false" };
                FilesResource.ListRequest listRequest = service.Files.List();
                listRequest.Q = query;


                // listRequest.Fields = "nextPageToken, files(id, name)";
                IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
                    .Files;


                if (files != null && files.Count > 0)
                {

                    foreach (var file in files)
                    {
                        if (file.Name.ToLower() == newFile.Name.ToLower())
                        {
                            FolderID = file.Id;

                            return FolderID;

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return FolderID;
        }
        #endregion

        #region "Upload file"
        /// <summary>
        /// upload files 
        /// </summary>
        /// <param name="filePath">Source file path</param>
        /// <param name="folderID">google drive folder id</param>
        /// <returns>retun the uploaded files id</returns>
        public string UploadFile(string filePath, string filename, string folderID, string Mode="ADD", string updateFileID="")
        {
            DriveService service = null;
            string ContentType = "application/msword";
            service = GetServicess();
            string newFolderID = "";




            List<Permission> permissions = new List<Permission>();

            permissions.Add(new Permission() { Role = "reader", Type = "group", EmailAddress = "anzar.ansari@wonderbiz.in" });
             


            //var filename = Path.GetFileName(filePath);
            FileInfo fi = new FileInfo(filePath);

            if (fi.Extension.ToLower() == ".pdf") {
                ContentType = "application/pdf";
            }

            // Upload file photo.jpg on drive.
            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
               // WritersCanShare = true,

               // Permissions = permissions,
               
                Name = filename,
                Parents = new string[] { folderID }

            };
            var fileMetadataUpdated = new Google.Apis.Drive.v3.Data.File()
            {
                //   WritersCanShare = true,

                Permissions = permissions,
                Name = filename
               
            };
            Google.Apis.Drive.v3.Data.File file1 = new Google.Apis.Drive.v3.Data.File();
            file1.Name = filename; 
           // file1.Permissions = permissions;
            file1.WritersCanShare = true;


            FilesResource.CreateMediaUpload request;
            // Create a new file on drive.
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                FilesResource.CreateMediaUpload createRequest;
                FilesResource.UpdateMediaUpload updateRequest;

                if (Mode == "UPDATE")
                {


                    updateRequest = service.Files.Update(file1, updateFileID, stream, ContentType);
                    updateRequest.Upload();
                    var file = updateRequest.ResponseBody;
                    newFolderID = file.Id;

                }
                else {
                    // Create a new file, with metadata and stream.
                    createRequest = service.Files.Create(fileMetadata, stream, ContentType);
                    createRequest.Fields = "id";
                    //  request.Fields = folderID;

                    createRequest.Upload();
                    var file = createRequest.ResponseBody;
                    newFolderID = file.Id;
                }
                
               
            }

            service.Permissions.Create(new Permission() { Role = "reader", Type = "group", EmailAddress = "anzar.ansari@wonderbiz.in"}, newFolderID);
            
            // Prints the uploaded file id.
           // Console.WriteLine("File ID: " + file.Id);
            return newFolderID;

        }
        #endregion

        public List<EventAttachment> AttachedGoogleDriveFile(string realFileId) {
            DriveService service = null;
            service = GetServicess();

            //var pa = service.Permissions.Create(new Permission { Type = "anyone", Role = "reader" }, realFileId);
           // pa.Execute();

            Google.Apis.Drive.v3.Data.File file;
            FilesResource.GetRequest f = service.Files.Get(realFileId);
            //f.Fields = "webViewLink";
            f.Fields = "*";
            f.IncludePermissionsForView = "published";
            file = f.Execute();

            EventAttachment attach1 = new EventAttachment();

            attach1.Title = file.Name;
            attach1.MimeType = file.MimeType;
            attach1.FileUrl = file.WebViewLink;


            List<EventAttachment> attachment = new List<EventAttachment>();
            attachment.Add(attach1);


            return attachment;
        }

        public Dictionary<string, string> getFiles(string searchFile = "", string parentID = "")
        {
            Dictionary<string,string> filesId = new Dictionary<string,string>(); 

            string FolderID = "";
            DriveService service;

            service = GetServicess();

            //string query = "mimeType!='application/vnd.google-apps.folder' and trashed = false";
            string query = " trashed = false ";
            if (parentID != "")
            {
                query += " and '" + parentID + "' in parents";
            }

            if (searchFile != "")
            {
                query += " and name contains '" + searchFile + "'";
            }

            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.Q = query;


            // listRequest.Fields = "nextPageToken, files(id, name)";
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
                .Files;


            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    bool contains = file.Name.IndexOf(searchFile.ToLower(), StringComparison.OrdinalIgnoreCase) >= 0;
                    if (contains)
                    //if (file.Name.Contains(searchFile.ToLower()))
                    {
                        FolderID = file.Id;

                        filesId.Add(FolderID,file.Name);
                        //return FolderID;

                    }
                }
            }
            return filesId;
        }


        public string getFile(string searchFile = "", string parentID = "")
        {
            Dictionary<string, string> filesId = new Dictionary<string, string>();

            string FolderID = "";
            DriveService service;

            service = GetServicess();

            //string query = "mimeType!='application/vnd.google-apps.folder' and trashed = false";
            string query = " trashed = false ";
            query += " and trashed = false and mimeType != 'application/vnd.google-apps.folder' ";
            if (parentID != "")
            {
                query += " and '" + parentID + "' in parents";
            }

            if (searchFile != "")
            {
                query += " and name contains '" + searchFile + "'";
            }

            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.Q = query;
            var newFile = new Google.Apis.Drive.v3.Data.File { Name = searchFile, MimeType = "application/vnd.google-apps.folder and trashed = false" };

            // listRequest.Fields = "nextPageToken, files(id, name)";
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
                .Files;


            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    if (file.Name.ToLower() == newFile.Name.ToLower())
                    {
                        FolderID = file.Id;

                        return FolderID;

                    }
                }
            }
            return FolderID;
        }


        public void DeleteFile(string fileId) {
            DriveService service;

            service = GetServicess();

            service.Files.Delete(fileId).Execute();
        }
        public void CopyFiles(string sourceFileID, string destinationFolderID, string FileName="")
        {
            try
            {
                DriveService service = null;
                service = GetServicess();

                Google.Apis.Drive.v3.Data.File copiedFile = new Google.Apis.Drive.v3.Data.File();
                copiedFile.Name = FileName;
                copiedFile.Parents = new string[] { destinationFolderID };

                Google.Apis.Drive.v3.Data.File file = service.Files.Copy(copiedFile, sourceFileID).Execute();

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
