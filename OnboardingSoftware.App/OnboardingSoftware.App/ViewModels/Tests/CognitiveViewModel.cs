using Newtonsoft.Json;
using OnboardingSoftware.App.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnboardingSoftware.App.ViewModels.Tests
{
    [QueryProperty("TestID", "testId")]
    public class CognitiveViewModel : BaseViewModel
    {
        public CognitiveViewModel()
        {
            
        }

        public override Task OnAppearing()
        {
            return base.OnAppearing();
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

        private void BindValues(string testId)
        {
            IsBusy = true;

            try
            {
                //var test = await SwaggerClient.Client.TestGetByIdAsync(testId);


                Naziv = "Test";
                Tip = "Test";
                BrojPitanja = "Test";
                Trajanje = "Test";
              


                IsBusy = false;
            }
            catch (Exception ex)
            {
                var x = ex;
                IsBusy = false;
            }
        }

        public ICommand GetTestDataCommand
        {
            get
            {
                return new Command<string>(async (route) => await GetTestDataAsync(route));
            }
        }

        private async Task GetTestDataAsync(string route)
        {
            try
            {

                IsBusy = true;

                HttpClient client = new HttpClient();
                Uri uri = new Uri("https://localhost:44308/");


                TestResource resource = new TestResource
                {  };


                string json = JsonConvert.SerializeObject(resource);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");



                //HttpResponseMessage response = null;
               // response = await client.PostAsync(uri + "api/Auth/signin", content);


                //if (response.IsSuccessStatusCode)
                //{
                //    await Shell.Current.GoToAsync(route);
                //}
                //if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                //{
               
                //}





                IsBusy = false;
                // await Shell.Current.GoToAsync(route);
            }
            catch (Exception ex)
            {
                //Handle it here
                IsBusy = false;
            }


        }




        private bool _isStarted;
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
            IsStarted = !IsStarted;
        });

        public ICommand FinishCommand => new Command(async vjestina =>
        {
            await Application.Current.MainPage.DisplayAlert("Done", "Results have been archived.", "OK");
            Application.Current.MainPage = new AppShell();
            await Shell.Current.GoToAsync("//home/profile");
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
