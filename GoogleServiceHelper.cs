using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterViewScheduler
{
    public class GoogleServiceHelper
    {
        public UserCredential GetUserCredential() {
            string[] scopes = new string[] { DriveService.Scope.Drive, 
                DriveService.Scope.DriveFile, 
                SheetsService.Scope.Spreadsheets, 
                CalendarService.Scope.Calendar ,

                
            };
            var clientId = "472130817863-5cba71lqpmdl1stlhn60a9je24us1lk7.apps.googleusercontent.com";      // From https://console.developers.google.com  
            var clientSecret = "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";          // From https://console.developers.google.com  
                                                                               // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%  
            UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            }, scopes,
            Environment.UserName, CancellationToken.None, new FileDataStore("MyAppsToken")).Result;

            return credential;

        }

      
        public DriveService GetDriveServicess()
        {
            DriveService service;
            try
            {
                //string[] scopes = new string[] { DriveService.Scope.Drive, DriveService.Scope.DriveFile, SheetsService.Scope.Spreadsheets, CalendarService.Scope.Calendar };
                //var clientId = "472130817863-5cba71lqpmdl1stlhn60a9je24us1lk7.apps.googleusercontent.com";      // From https://console.developers.google.com  
                //var clientSecret = "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";          // From https://console.developers.google.com  
                //                                                                   // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%  
                //var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
                //{
                //    ClientId = clientId,
                //    ClientSecret = clientSecret
                //}, scopes,
                //Environment.UserName, CancellationToken.None, new FileDataStore("MyAppsToken")).Result;
                ////Once consent is recieved, your token will be stored locally on the AppData directory, so that next time you wont be prompted for consent.   

                service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = GetUserCredential(),
                    ApplicationName = "MyAppName",

                });

            }
            catch (Exception)
            {

                throw;
            }
            return service;
        }
        public SheetsService GetSheetsService()
        {
            SheetsService service;
            try
            {
                //string[] scopes = new string[] { DriveService.Scope.Drive, DriveService.Scope.DriveFile};
                //var clientId = "472130817863-5cba71lqpmdl1stlhn60a9je24us1lk7.apps.googleusercontent.com";      // From https://console.developers.google.com  
                //var clientSecret = "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";          // From https://console.developers.google.com  
                //                                                                   // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%  
                //var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
                //{
                //    ClientId = clientId,
                //    ClientSecret = clientSecret
                //}, scopes,
                //Environment.UserName, CancellationToken.None, new FileDataStore("MyAppsToken")).Result;
                //Once consent is recieved, your token will be stored locally on the AppData directory, so that next time you wont be prompted for consent.   

                service = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = GetUserCredential(),
                    ApplicationName = "MyAppName",

                });

            }
            catch (Exception)
            {

                throw;
            }
            return service;
        }
        public CalendarService GetCalendarService()
        {
            CalendarService service;
            try
            {

                UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                               new ClientSecrets
                               {
                                   //ClientId = "486657048992-197fmta58hrdkitgakrpfschm29aa7os.apps.googleusercontent.com",
                                   //ClientSecret = "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",

                                   ClientId = "472130817863-5cba71lqpmdl1stlhn60a9je24us1lk7.apps.googleusercontent.com",
                                   ClientSecret = "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",
                               },
                               new[] { CalendarService.Scope.Calendar },
                               System.Environment.UserName,
                               CancellationToken.None).Result;

                service = new CalendarService(new BaseClientService.Initializer()
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
    }
}
