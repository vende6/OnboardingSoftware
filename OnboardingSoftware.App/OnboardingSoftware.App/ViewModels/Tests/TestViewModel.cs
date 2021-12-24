using Newtonsoft.Json;
using OnboardingSoftware.App.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnboardingSoftware.App.ViewModels.Tests
{
    [QueryProperty("TestID", "testId")]
    public class TestViewModel : BaseViewModel
    {
        public TestViewModel()
        {
            MessagingCenter.Subscribe<Application>(this, "InitializeTest", async (s) => await OnAppearing());
        }

        public override async Task OnAppearing()
        {
            await base.OnAppearing();
            BindValues(_testId);

        }

        private string _testId;
        public string TestID
        {
            get
            {
                return _testId;
            }
            set
            {
                _testId = Uri.UnescapeDataString(value);
                BindValues(_testId);
            }
        }

        private string _naziv;
        public string Naziv
        {
            get
            {
                return _naziv;
            }
            set
            {
                _naziv = value;
                RaisePropertyChanged(() => Naziv);
            }
        }

        private string _tip;
        public string Tip
        {
            get
            {
                return _tip;
            }
            set
            {
                _tip = value;
                RaisePropertyChanged(() => Tip);
            }
        }

        private ObservableCollection<OdgovorResource> _ponudjeniOdgovori  = new ObservableCollection<OdgovorResource>();
        public ObservableCollection<OdgovorResource> PonudjeniOdgovori
        {
            get
            {
                return _ponudjeniOdgovori;
            }
            set
            {
                _ponudjeniOdgovori = value;
                RaisePropertyChanged(() => Tip);
            }
        }

        private string _brojPitanja;
        public string BrojPitanja
        {
            get
            {
                return _brojPitanja;
            }
            set
            {
                _brojPitanja = value;
                RaisePropertyChanged(() => BrojPitanja);
            }
        }

        private string _trajanje;
        public string Trajanje
        {
            get
            {
                return _trajanje;
            }
            set
            {
                _trajanje = value;
                RaisePropertyChanged(() => Trajanje);
            }
        }

        private TestResource _test;
        public TestResource Test
        {
            get
            {
                return _test;
            }
            set
            {
                _test = value;
                RaisePropertyChanged(() => Test);
            }
        }

        private List<PitanjeResource> _pitanja;
        public  List<PitanjeResource> Pitanja
        {
            get
            {
                return _pitanja;
            }
            set
            {
                _pitanja = value;
                RaisePropertyChanged(() => Pitanja);
            }
        }

        private async void BindValues(string testId)
        {
            IsBusy = true;

            try
            {
                IsBusy = true;

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI2ZGVjNDYzNS0zY2FmLTRiYzgtMDQ1Yi0wOGQ5YzAyMjJmM2YiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiZGFtaXIxQHRvYi5iYSIsImp0aSI6ImViN2Y1NTg0LThjN2QtNDM5MC1iODUxLWE3NzA1ZWU2MDJlYSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiNmRlYzQ2MzUtM2NhZi00YmM4LTA0NWItMDhkOWMwMjIyZjNmIiwiZXhwIjoxNjQyMjI0NzQ1LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjQ0MzA4IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo0NDMwOCJ9.6xPWKMbqS9RLqjwFRt9WvSuGRYwH8zk2L3BjL-6IoeE");

                Uri uri = new Uri("https://localhost:44308/");

                HttpResponseMessage response = await client.GetAsync(uri + "api/testovi/" + testId);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Test = JsonConvert.DeserializeObject<TestResource>(content);
                }

                Naziv = Test.Naziv;
                Tip = Test.Tip;
                BrojPitanja = Test.BrojPitanja;
                Trajanje = Test.Trajanje;

                    //HttpResponseMessage response2 = await client.GetAsync(uri + "api/pitanja/" + testId);
                    //if (response2.IsSuccessStatusCode)
                    //{
                    //    string content = await response2.Content.ReadAsStringAsync();
                    //    Pitanja = new List<PitanjeResource>(JsonConvert.DeserializeObject<IEnumerable<PitanjeResource>>(content));
                    // Pitanja.Last().IsLast = true;
               // }

                IsBusy = false;
            }
            catch (Exception ex)
            {
                var x = ex;
                IsBusy = false;
            }
        }


        private bool _isStarted = false;
        public bool IsStarted
        {
            get { return this._isStarted; }
            set
            {
                this._isStarted = value;
                RaisePropertyChanged(() => IsStarted);
            }
        }

        public ICommand StartCommand => new Command(async test =>
        {
            await Shell.Current.GoToAsync("//home/start" + "?testId=" + _testId);
        });




        //    public class XamarinQuiz
        //    {
        //        public string Id { get; set; }
        //        public string Question { get; set; }
        //        public string Answer1 { get; set; }
        //        public string Answer2 { get; set; }
        //        public string Answer3 { get; set; }
        //        public int CorrectAnswer { get; set; }
        //    }

        //    public class UserScore
        //    {
        //        public string Id { get; set; }
        //        public string Username { get; set; }
        //        public int Score { get; set; }
        //    }


        //    private int _correctAnswer = 0;
        //    public int CorrectAnswer
        //    {
        //        get { return this._correctAnswer; }
        //        set
        //        {
        //            this._correctAnswer = value;
        //            RaisePropertyChanged(() => CorrectAnswer);
        //        }
        //    }
        //    private string _question;
        //    public string Question
        //    {
        //        get { return this._question; }
        //        set
        //        {
        //            this._question = value;
        //            RaisePropertyChanged(() => Question);
        //        }
        //    }

        //    private string _answer1;
        //    public string Answer1
        //    {
        //        get { return this._answer1; }
        //        set
        //        {
        //            this._answer1 = value;
        //            RaisePropertyChanged(() => Answer1);
        //        }
        //    }

        //    private bool _answer1Enabled;
        //    public bool Answer1Enabled
        //    {
        //        get { return this._answer1Enabled; }
        //        set
        //        {
        //            this._answer1Enabled = value;
        //            RaisePropertyChanged(() => Answer1Enabled);
        //        }
        //    }

        //    private string _answer2;
        //    public string Answer2
        //    {
        //        get { return this._answer2; }
        //        set
        //        {
        //            this._answer2 = value;
        //            RaisePropertyChanged(() => Answer2);
        //        }
        //    }

        //    private bool _answer2Enabled;
        //    public bool Answer2Enabled
        //    {
        //        get { return this._answer2Enabled; }
        //        set
        //        {
        //            this._answer2Enabled = value;
        //            RaisePropertyChanged(() => Answer2Enabled);
        //        }
        //    }

        //    private string _answer3;
        //    public string Answer3
        //    {
        //        get { return this._answer3; }
        //        set
        //        {
        //            this._answer3 = value;
        //            RaisePropertyChanged(() => Answer3);
        //        }
        //    }

        //    private bool _answer3Enabled;
        //    public bool Answer3Enabled
        //    {
        //        get { return this._answer3Enabled; }
        //        set
        //        {
        //            this._answer3Enabled = value;
        //            RaisePropertyChanged(() => Answer3Enabled);
        //        }
        //    }

        //    private List<XamarinQuiz> _questionList;
        //    List<XamarinQuiz> QuestionList
        //    {
        //        get { return this._questionList; }
        //        set
        //        {
        //            this._questionList = value;
        //            RaisePropertyChanged(() => QuestionList);
        //        }
        //    }
        //    Random rnd = new Random();

        //    public event PropertyChangedEventHandler PropertyChanged;

        //    private bool _isLoading;
        //    public bool IsLoading
        //    {
        //        get { return this._isLoading; }
        //        set
        //        {
        //            this._isLoading = value;
        //            RaisePropertyChanged(() => IsLoading);
        //        }
        //    }

        //    private string _message;
        //    public string Message
        //    {
        //        get
        //        {
        //            return this._message;
        //        }
        //        set
        //        {
        //            this._message = value;
        //            RaisePropertyChanged(() => Message);
        //        }
        //    }

        //    public bool CheckIfCorrect(int correct)
        //    {
        //        if (CorrectAnswer == correct)
        //        {
        //            Message = "Correcto !!";
        //            return true;
        //        }
        //        Message = "No señor !!";
        //        return false;
        //    }

        //    public async Task LoadQuestions()
        //    {
        //        IsLoading = true;
        //      //  MobileServiceClient client = AppSettings.MobileService;

        //       // IMobileServiceTable<XamarinQuiz> xamarinQuizTable = client.GetTable<XamarinQuiz>();

        //        try
        //        {
        //            //  QuestionList = await xamarinQuizTable.ToListAsync();
        //            QuestionList = new List<XamarinQuiz>() {
        //              new XamarinQuiz() { Answer1 = "Da", Answer2 = "Ne", Answer3 = "Maybe", Question = "What was the question?" },
        //              new XamarinQuiz() { Answer1 = "Da", Answer2 = "Ne", Answer3 = "Maybe", Question = "What was the question?" },
        //              new XamarinQuiz() { Answer1 = "Da", Answer2 = "Ne", Answer3 = "Maybe", Question = "What was the question?" }
        //              };
        //        }
        //        catch (Exception exc)
        //        {
        //        }


        //        IsLoading = false;
        //        ChooseNewQuestion();
        //    }

        //    public void ChooseNewQuestion()
        //    {
        //        IsLoading = true;

        //        int questionNumber = rnd.Next(0, QuestionList.Count);
        //        XamarinQuiz selectedItem = QuestionList[questionNumber];

        //        Answer1Enabled = true;
        //        Answer2Enabled = true;
        //        Answer3Enabled = true;

        //        Question = selectedItem.Question;
        //        Answer1 = selectedItem.Answer1;
        //        Answer2 = selectedItem.Answer2;
        //        Answer3 = selectedItem.Answer3;

        //        CorrectAnswer = selectedItem.CorrectAnswer;

        //        IsLoading = false;
        //    }
    }
}
