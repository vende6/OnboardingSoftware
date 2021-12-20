using Newtonsoft.Json;
using OnboardingSoftware.App.LanguageSupport;
using OnboardingSoftware.App.Resources;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnboardingSoftware.App.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        public ProfileViewModel()
        {

            RocketIcon = IconFont.Rocket;
            SettingsIcon = IconFont.Settings;
            SetGaugeValues();

            //Hook onto tabselectrenderer to refresh pages.
            //MessagingCenter.Subscribe<Application>(this, AppMessages.RefreshTab, async (s) => await OnAppearing());
        }



        private Page _currentPageSave;
        public string RocketIcon { get; set; }

        private bool _isPeriodDefined;
        public bool IsPeriodDefined
        {
            get
            {
                return Settings.DefaultMeasurementTemplateId > 0 ? true : false;
            }
            set
            {
                _isPeriodDefined = value;
                RaisePropertyChanged(() => IsPeriodDefined);
            }
        }

        public ICommand RedirectToAddAchievementCommand
        {
            get
            {
                return new Command<string>(async (route) =>
                {
                    await Shell.Current.GoToAsync(route);
                });
            }
        }

        public ICommand ChangeLanguageCommand
        {
            get
            {
                return new Command<string>(async (route) =>
                {
                    if (Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopupStack.Count == 0)
                        await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Views.Dialogs.LanguageDialog(Translation.Translate("LanguageTitle"), Translation.Translate("LanguageText")));
                });
            }
        }

        public ICommand LogoutCommand
        {
            get
            {
                return new Command<string>(async (route) =>
                {
                    if (Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopupStack.Count == 0)
                        await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Views.Dialogs.LogoutDialog(Translation.Translate("LogoutTitle"), Translation.Translate("LogoutText")));
                });
            }
        }


        public ICommand ReferencesCommand
        {
            get
            {
                return new Command<string>(async (route) =>
                {
                    if (Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopupStack.Count == 0)
                        await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Views.Dialogs.ReferenceDialog("Select references", "Import references for the application"));
                });
            }
        }


        public ICommand SkillsCommand
        {
            get
            {
                return new Command<string>(async (route) =>
                {
                    if (Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopupStack.Count == 0)
                        await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Views.Dialogs.SkillDialog("Select skills", "Select skills for the application"));
                });
            }
        }

        public ICommand InterestsCommand
        {
            get
            {
                return new Command<string>(async (route) =>
                {
                    if (Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopupStack.Count == 0)
                        await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Views.Dialogs.InterestDialog("Select interests", "Select interests for the application"));
                });
            }
        }

        private ImageSource _languageImage;
        public ImageSource LanguageImage
        {
            get
            {
                return _languageImage;
            }
            set
            {
                _languageImage = value;
                RaisePropertyChanged(() => LanguageImage);
            }
        }

        public string _meetingDate { get; set; } = Translation.Translate("DateNotSet");
        public string MeetingDate
        {
            get
            {
                return _meetingDate;
            }
            set
            {
                _meetingDate = value;
                RaisePropertyChanged(() => MeetingDate);
            }
        }

        public string _meetingDay { get; set; } = Translation.Translate("DateNotSet");
        public string MeetingDay
        {
            get
            {
                return _meetingDay;
            }
            set
            {
                _meetingDay = value;
                RaisePropertyChanged(() => MeetingDay);
            }
        }

        public string _meetingTime { get; set; }
        public string MeetingTime
        {
            get
            {
                return _meetingTime;
            }
            set
            {
                _meetingTime = value;
                RaisePropertyChanged(() => MeetingTime);
            }
        }

        private string _addIcon = IconFont.PlusSimple;
        public string AddIcon
        {
            get
            {
                return _addIcon;
            }
            set
            {
                _addIcon = value;
                RaisePropertyChanged(() => AddIcon);
            }
        }

        private string _settingsIcon = IconFont.Chat;
        public string SettingsIcon
        {
            get
            {
                return _settingsIcon;
            }
            set
            {
                _settingsIcon = value;
                RaisePropertyChanged(() => SettingsIcon);
            }
        }

        private string _cameraIcon = IconFont.Camera;
        public string CameraIcon
        {
            get
            {

                return _cameraIcon;
            }
            set
            {
                _cameraIcon = value;
                RaisePropertyChanged(() => CameraIcon);
            }
        }

        private string _galleryIcon = IconFont.Photos;
        public string GalleryIcon
        {
            get
            {

                return _galleryIcon;
            }
            set
            {
                _galleryIcon = value;
                RaisePropertyChanged(() => GalleryIcon);
            }
        }

        private bool _isVisibleCameraGallery = false;
        public bool IsVisibleCameraGallery
        {
            get
            {

                return _isVisibleCameraGallery;
            }
            set
            {
                _isVisibleCameraGallery = value;
                RaisePropertyChanged(() => IsVisibleCameraGallery);
            }
        }

        private int _reviewDayFontSize;
        public int ReviewDayFontSize
        {
            get
            {
                return _reviewDayFontSize;
            }
            set
            {
                _reviewDayFontSize = value;
                RaisePropertyChanged(() => ReviewDayFontSize);
            }
        }

        private string _headerMessage;
        public string HeaderMessage
        {
            get
            {
                return _headerMessage;
            }
            set
            {
                _headerMessage = value;
                RaisePropertyChanged(() => HeaderMessage);
            }
        }

        private ImageSource _profileImage = ImageSource.FromResource("OnboardingSoftware.App.Images.circle-cropped.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly);
        public ImageSource ProfileImage
        {
            get
            {
                return _profileImage;
            }
            set
            {
                _profileImage = value;
                RaisePropertyChanged(() => ProfileImage);
            }
        }

        public async override Task OnAppearing()
        {
            await base.OnAppearing();

            if (Settings.LanguageId == "en-GB")
                LanguageImage = ImageSource.FromResource("OnboardingSoftware.App.Images.flagg_engelsk.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly);
            else
                LanguageImage = ImageSource.FromResource("OnboardingSoftware.App.Images.flagg_engelsk.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly);

            _currentPageSave = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();
            _sendingPhoto = true;
            await LoadData();
        }

        public async override Task OnDisappearing()
        {
            await base.OnDisappearing();
            if (_currentPageSave != null && _sendingPhoto)
            {
                await _currentPageSave.Navigation.PopToRootAsync();
            }
            //MessagingCenter.Unsubscribe<Application>(this, AppMessages.RefreshTab);
        }

        public ICommand ToggleCameraGalleryCommand
        {
            get
            {
                return new Command(() =>
                {
                    IsVisibleCameraGallery = !IsVisibleCameraGallery;
                });
            }
        }

        public ICommand LoadCameraCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await LoadCamera();
                });
            }
        }

        public ICommand LoadGalleryCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await LoadGallery();
                });
            }
        }

        public async System.Threading.Tasks.Task LoadCamera()
        {
            try
            {
                IsBusy = true;
                _sendingPhoto = false;
                IsVisibleCameraGallery = false;
                Console.Write("Loading camera...");

                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    //DisplayAlert("No Camera", ":( No camera available.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "test.jpg"
                });

                if (file == null)
                {
                    IsBusy = false;
                    return;
                }

                //await DisplayAlert("File Location", file.Path, "OK");
                //await SwaggerClient.Client.ApiUsersImagePostAsync(Settings.UserId, new FileParameter(file.GetStream()));

                var imageSource = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStreamWithImageRotatedForExternalStorage();
                    return stream;
                });


                //set new Image to settings
                var str = file.GetStreamWithImageRotatedForExternalStorage();
                var bytes = new byte[str.Length];
                await str.ReadAsync(bytes, 0, (int)str.Length);
                Settings.UserImage = System.Convert.ToBase64String(bytes);

                ProfileImage = imageSource;

                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                // WrapAndHandleException(ex);
            }
        }

        public async System.Threading.Tasks.Task LoadGallery()
        {
            try
            {
                IsBusy = true;
                _sendingPhoto = false;
                IsVisibleCameraGallery = false;
                await CrossMedia.Current.Initialize();

                var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    CompressionQuality = 20,
                    CustomPhotoSize = 60
                });

                if (file == null)
                {
                    IsBusy = false;
                    return;
                }

                var imageSource = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStreamWithImageRotatedForExternalStorage();
                    return stream;
                });


                //update on database
                // await SwaggerClient.Client.ApiUsersImagePostAsync(Settings.UserId, new FileParameter(file.GetStream()));

                //convert image to byte array
                var str = file.GetStreamWithImageRotatedForExternalStorage();
                var bytes = new byte[str.Length];
                await str.ReadAsync(bytes, 0, (int)str.Length);

                //set new Image to settings
                Settings.UserImage = System.Convert.ToBase64String(bytes);

                //set profile image
                ProfileImage = imageSource;

                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                //    WrapAndHandleException(ex);
            }
        }

        private async Task LoadData()
        {

            IsBusy = true;
            cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;

            try
            {
                if (!String.IsNullOrEmpty(Settings.UserFullname))
                {
                    HeaderMessage = Translation.Translate("Hi") + " " + Settings.UserFullname.Substring(0, Settings.UserFullname.IndexOf(" ")) + "!";
                }
                else
                {
                    HeaderMessage = Translation.Translate("Hi");
                }


                await GetTestsData();

                IsBusy = false;

            }
            catch (Exception ex)
            {
                IsBusy = false;
                //WrapAndHandleException(ex);
                if (ex.Message != null && ex.Message.Contains(GlobalSettings.MissingTemplateErrorMessage))
                {
                    ClearData();
                }
            }
        }

        private ObservableCollection<TestResource> _tests = new ObservableCollection<TestResource>();
        public ObservableCollection<TestResource> Tests
        {
            get
            {
                return _tests;
            }
            set
            {
                _tests = value;
                RaisePropertyChanged(() => Tests);
            }
        }


        private async Task GetTestsData()
        {

            IsBusy = true;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI2ZGVjNDYzNS0zY2FmLTRiYzgtMDQ1Yi0wOGQ5YzAyMjJmM2YiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiZGFtaXIxQHRvYi5iYSIsImp0aSI6ImViN2Y1NTg0LThjN2QtNDM5MC1iODUxLWE3NzA1ZWU2MDJlYSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiNmRlYzQ2MzUtM2NhZi00YmM4LTA0NWItMDhkOWMwMjIyZjNmIiwiZXhwIjoxNjQyMjI0NzQ1LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjQ0MzA4IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo0NDMwOCJ9.6xPWKMbqS9RLqjwFRt9WvSuGRYwH8zk2L3BjL-6IoeE");

            Uri uri = new Uri("https://a2f2-77-238-220-218.ngrok.io/");

            HttpResponseMessage response = await client.GetAsync(uri + "api/testovi");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                Tests = new ObservableCollection<TestResource>(JsonConvert.DeserializeObject<List<TestResource>>(content));

            }

            IsBusy = false;
        }

        private void ClearData()
        {
            Settings.DefaultMeasurementTemplateId = 0;
            IsPeriodDefined = false;
        }

        private async Task GetDashboardData(CancellationToken cancellationToken)
        {
            try
            {
                if (Settings.UserImage != null && Settings.UserImage.Length > 0)
                    ProfileImage = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(Settings.UserImage)));

                // var reviewDate = await SwaggerClient.Client.ApiReviewplannersGetAsync(Settings.UserId, cancellationToken);
                var reviewDate = DateTime.Now;


                if (reviewDate != null && reviewDate.Year != 1)
                {
                    MeetingDate = reviewDate.Date.ToString("MMMM yyyy").ToUpper();
                    MeetingDay = reviewDate.Day.ToString();
                    MeetingTime = reviewDate.ToLocalTime().ToString("HH:mm");
                    ReviewDayFontSize = 28;
                }
                else
                {
                    MeetingDay = Translation.Translate("DateNotSet");
                    MeetingDate = Translation.Translate("DateNotSet");
                    MeetingTime = "";
                    ReviewDayFontSize = 14;
                }
                //var measuresFromApi = await SwaggerClient.Client.ApiAchievementsGetAsync(Settings.UserId, Settings.DefaultMeasurementTemplateId, cancellationToken);
                //if (measuresFromApi != null && measuresFromApi.Achievements != null)
                //{
                //    var achievementCount = measuresFromApi.Achievements.Count();
                //    if (achievementCount == 1)
                //    {
                //        var achievement1 = measuresFromApi.Achievements.ElementAt(0);

                //        RandomMeasurement1Title = achievement1.Name.ToUpper();
                //        AchievementsRealized = achievement1.Realized;
                //        AchievementsTotal = achievement1.Target;
                //    }
                //    else if (achievementCount == 2)
                //    {
                //        var achievement1 = measuresFromApi.Achievements.ElementAt(0);

                //        RandomMeasurement1Title = achievement1.Name.ToUpper();
                //        AchievementsRealized = achievement1.Realized;
                //        AchievementsTotal = achievement1.Target;

                //        var achievement2 = measuresFromApi.Achievements.ElementAt(1);
                //        RandomMeasurement2Title = achievement2.Name.ToUpper();
                //        TasksRealized = achievement2.Realized;
                //        TasksTotal = achievement2.Target;
                //    }
                //    else if (achievementCount > 2)
                //    {
                //        var rand = new Random();
                //        var randNumb1 = rand.Next(0, achievementCount - 1);
                //        var randNumb2 = rand.Next(0, achievementCount - 1);

                //        var achievement1 = measuresFromApi.Achievements.ElementAt(randNumb1);
                //        var achievement2 = measuresFromApi.Achievements.ElementAt(randNumb2);

                //        RandomMeasurement1Title = achievement1.Name.ToUpper();
                //        AchievementsRealized = achievement1.Realized;
                //        AchievementsTotal = achievement1.Target;

                //        RandomMeasurement2Title = achievement2.Name.ToUpper();
                //        TasksRealized = achievement2.Realized;
                //        TasksTotal = achievement2.Target;
                //    }

                //}

            }
            catch (Exception ex)
            {
                IsBusy = false;
                // WrapAndHandleException(ex);
            }
        }

        private string _randomMeasurement1Title = Translation.Translate("GoalNotSet").ToUpper();
        public string RandomMeasurement1Title
        {
            get
            {
                return _randomMeasurement1Title;
            }
            set
            {
                _randomMeasurement1Title = value;
                RaisePropertyChanged(() => RandomMeasurement1Title);
            }
        }

        private string _randomMeasurement2Title = Translation.Translate("GoalNotSet").ToUpper();
        public string RandomMeasurement2Title
        {
            get
            {
                return _randomMeasurement2Title;
            }
            set
            {
                _randomMeasurement2Title = value;
                RaisePropertyChanged(() => RandomMeasurement2Title);
            }
        }


        private int? _tasksRealized;
        public int? TasksRealized
        {
            get
            {
                return _tasksRealized;
            }
            set
            {
                _tasksRealized = value;
                RaisePropertyChanged(() => TasksRealized);
            }
        }

        private int? _tasksTotal;
        public int? TasksTotal
        {
            get
            {
                return _tasksTotal;
            }
            set
            {
                _tasksTotal = value;
                RaisePropertyChanged(() => TasksTotal);
            }
        }

        private int? _achievementsRealized;
        public int? AchievementsRealized
        {
            get
            {
                return _achievementsRealized;
            }
            set
            {
                _achievementsRealized = value;
                RaisePropertyChanged(() => AchievementsRealized);
            }
        }

        private int? _achievementsTotal;
        public int? AchievementsTotal
        {
            get
            {
                return _achievementsTotal;
            }
            set
            {
                _achievementsTotal = value;
                RaisePropertyChanged(() => AchievementsTotal);
            }
        }


        private void SetGaugeValues()
        {

            if (Device.RuntimePlatform == Device.Android)
            {
                NummSize = Helper.IsASmallDevice() ? 43 : 74;
                TextSize = Helper.IsASmallDevice() ? 20 : 25;
                StrokeWidth = Helper.IsASmallDevice() ? 20 : 30;


            }

            if (Device.RuntimePlatform == Device.iOS)
            {
                NummSize = Helper.IsASmallDevice() ? 43 : 74;
                TextSize = Helper.IsASmallDevice() ? 20 : 25;
                StrokeWidth = Helper.IsASmallDevice() ? 21 : 30;

            }

        }


        private double _nummSize;
        public double NummSize
        {
            get
            {
                return _nummSize;
            }
            set
            {
                _nummSize = value;
                RaisePropertyChanged(() => NummSize);
            }
        }

        private double _textSize;
        public double TextSize
        {
            get
            {
                return _textSize;
            }
            set
            {
                _textSize = value;
                RaisePropertyChanged(() => TextSize);
            }
        }

        private double _strokeWidth;
        public double StrokeWidth
        {
            get
            {
                return _strokeWidth;
            }
            set
            {
                _strokeWidth = value;
                RaisePropertyChanged(() => StrokeWidth);
            }
        }

        public ICommand NavigateCommand
        {
            get
            {
                return new Command<object>(async (obj) =>
                {

                    var x = obj as TestResource;

                    await Shell.Current.GoToAsync("//home/tests");


                });
            }
        }
    }
}
