using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Dynamic;
using System.Data;
using CalendarQuickstart;

namespace InterViewScheduler
{
    public class GoogleSheetsHelper
    {
        static string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static string ApplicationName = "GoogleSheetsHelper";

        private readonly SheetsService _sheetsService;
        private readonly string _spreadsheetId;

        public GoogleSheetsHelper(string spreadsheetId)
        {
            try
            {
                //UserCredential credential;
                //using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
                //{
                //    string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                //    credPath = Path.Combine(credPath, ".credentials/drive-dotnet-quickstart");
                //    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                //        GoogleClientSecrets.Load(stream).Secrets,
                //        new[] {
                //        SheetsService.Scope.Spreadsheets
                //        },
                //        "user",
                //        CancellationToken.None).Result;
                //}

                //// Create Google SpredSheet API service.
                //_sheetsService = new SheetsService(new BaseClientService.Initializer()
                //{
                //    HttpClientInitializer = credential,
                //    ApplicationName = ApplicationName,
                //});

                GoogleServiceHelper googleServiceHelper = new GoogleServiceHelper();
                _sheetsService = googleServiceHelper.GetSheetsService();
                _spreadsheetId = spreadsheetId;
            }
            catch
            {
                throw;
            }
        }

        public DataTable ToDataTable(IEnumerable<dynamic> items)
        {
            var data = items.ToArray();
            if (data.Count() == 0) return null;

            var dt = new DataTable();
            foreach (var key in ((IDictionary<string, object>)data[0]).Keys)
            {
                dt.Columns.Add(key);
            }
            foreach (var d in data)
            {
                dt.Rows.Add(((IDictionary<string, object>)d).Values.ToArray());
            }
            return dt;
        }

        public List<ExpandoObject> GetDataFromSheet(GoogleSheetParameters googleSheetParameters)
        {
            googleSheetParameters = MakeGoogleSheetDataRangeColumnsZeroBased(googleSheetParameters);
            var range = $"{googleSheetParameters.SheetName}!{GetColumnName(googleSheetParameters.RangeColumnStart)}{googleSheetParameters.RangeRowStart}:{GetColumnName(googleSheetParameters.RangeColumnEnd)}{googleSheetParameters.RangeRowEnd}";

            SpreadsheetsResource.ValuesResource.GetRequest request =
                _sheetsService.Spreadsheets.Values.Get(_spreadsheetId, range);

            var numberOfColumns = googleSheetParameters.RangeColumnEnd - googleSheetParameters.RangeColumnStart;
            var columnNames = new List<string>();
            var returnValues = new List<ExpandoObject>();

            if (!googleSheetParameters.FirstRowIsHeaders)
            {
                for (var i = 0; i <= numberOfColumns; i++)
                {
                    columnNames.Add($"Column{i}");
                }
            }

            var response = request.Execute();

            int rowCounter = 0;
            IList<IList<Object>> values = response.Values;
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    if (googleSheetParameters.FirstRowIsHeaders && rowCounter == 0)
                    {
                        for (var i = 0; i <= numberOfColumns; i++)
                        {
                            columnNames.Add(row[i].ToString());
                        }
                        rowCounter++;
                        continue;
                    }

                    var expando = new ExpandoObject();
                    var expandoDict = expando as IDictionary<String, object>;
                    var columnCounter = 0;
                    foreach (var columnName in columnNames)
                    {
                        if(row.Count>columnCounter)
                            expandoDict.Add(columnName, row[columnCounter].ToString());
                        else
                            expandoDict.Add(columnName, "");
                        columnCounter++;
                    }
                    returnValues.Add(expando);
                    rowCounter++;
                }
            }

            return returnValues;
        }

        private string GetColumnName(int index)
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var value = "";

            if (index >= letters.Length)
                value += letters[index / letters.Length - 1];

            value += letters[index % letters.Length];
            return value;
        }

        private GoogleSheetParameters MakeGoogleSheetDataRangeColumnsZeroBased(GoogleSheetParameters googleSheetParameters)
        {
            googleSheetParameters.RangeColumnStart = googleSheetParameters.RangeColumnStart - 1;
            googleSheetParameters.RangeColumnEnd = googleSheetParameters.RangeColumnEnd - 1;
            return googleSheetParameters;
        }

        public void AddRow(GoogleSheetParameters googleSheetParameters, CandidateDetails candidateDetails)
        {
            string range;
            googleSheetParameters = MakeGoogleSheetDataRangeColumnsZeroBased(googleSheetParameters);
            if (candidateDetails.RecordType == "Update")
            {
                range = $"{googleSheetParameters.SheetName}!{GetColumnName(googleSheetParameters.RangeColumnStart)}{candidateDetails.Id}:{GetColumnName(googleSheetParameters.RangeColumnEnd)}{googleSheetParameters.RangeRowEnd}";
            }
            else
            {
                range = $"{googleSheetParameters.SheetName}!{GetColumnName(googleSheetParameters.RangeColumnStart)}{googleSheetParameters.RangeRowStart}:{GetColumnName(googleSheetParameters.RangeColumnEnd)}{googleSheetParameters.RangeRowEnd}";
            }

            IList<Object> obj = new List<Object>();
            foreach (var val in candidateDetails.GetType().GetProperties())
            {
               
                if (val.Name == "Duration") {
                    string Test = "dasdsadsa";
                }

                if (val.Name != "SchedulersEmail")
                {
                    obj.Add(val.GetValue(candidateDetails, null));
                }
                else
                {
                    break;
                }
            }
            IList<IList<Object>> values = new List<IList<Object>>();
            values.Add(obj);
            if (candidateDetails.RecordType == "Update")
            {
                SpreadsheetsResource.ValuesResource.UpdateRequest request =
                    _sheetsService.Spreadsheets.Values.Update(new ValueRange() { Values = values }, _spreadsheetId, range);
                _sheetsService.Spreadsheets.Values.Append(new ValueRange() { Values = values }, _spreadsheetId, range);
                request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
                var response = request.Execute();
            }
            else
            {
                SpreadsheetsResource.ValuesResource.AppendRequest request =
                _sheetsService.Spreadsheets.Values.Append(new ValueRange() { Values = values }, _spreadsheetId, range);
                request.InsertDataOption = SpreadsheetsResource.ValuesResource.AppendRequest.InsertDataOptionEnum.INSERTROWS;
                request.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.RAW;
                var response = request.Execute();
            }
        }
    }

    public class GoogleSheetCell
    {
        public string CellValue { get; set; }
        public bool IsBold { get; set; }
        public System.Drawing.Color BackgroundColor { get; set; } = System.Drawing.Color.White;
    }

    public class GoogleSheetParameters
    {
        public int RangeColumnStart { get; set; }
        public int RangeRowStart { get; set; }
        public int RangeColumnEnd { get; set; }
        public int RangeRowEnd { get; set; }
        public string SheetName { get; set; }
        public bool FirstRowIsHeaders { get; set; }
    }

    public class GoogleSheetRow
    {
        public GoogleSheetRow() => Cells = new List<GoogleSheetCell>();
        public List<GoogleSheetCell> Cells { get; set; }
    }
}
