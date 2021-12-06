﻿using Rg.Plugins.Popup.Services;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnboardingSoftware.App.ViewModels.Dialogs
{
    public class LanguageDialogViewModel : BaseViewModel
    {
        public LanguageDialogViewModel()
        {
            IsDomesticSelected = Settings.LanguageId == "nb-NO" ? true : false;
        }


        public ICommand SelectEnglishCommand { get { return new Command(async () => await SelectEnglishLanguage()); } }
        public ICommand SelectNorwayCommand { get { return new Command(async () => await SelectNorwayLanguage()); } }
        public ICommand CloseInfoCommand { get { return new Command(async () => await CloseInfo()); } }

        private ImageSource _englishFlagImage = ImageSource.FromResource("OnboardingSoftware.App.Images.flagg_engelsk.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly);
        public ImageSource EnglishFlagImage
        {
            get
            {
                return _englishFlagImage;
            }
            set
            {
                _englishFlagImage = value;
                RaisePropertyChanged(() => EnglishFlagImage);
            }
        }

        private ImageSource _norwayFlagImage = ImageSource.FromResource("OnboardingSoftware.App.Images.flagg_norsk.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly);
        public ImageSource NorwayFlagImage
        {
            get
            {
                return _norwayFlagImage;
            }
            set
            {
                _norwayFlagImage = value;
                RaisePropertyChanged(() => NorwayFlagImage);
            }
        }

        public async Task<bool> SelectEnglishLanguage()
        {
            IsClosed = true;
            //Settings.LanguageId = "en-GB";
            //Settings.HasUserSetLanguage = true;
            //await SwaggerClient.Client.ApiUsersChangelanguageAsync(Settings.UserId, "en-GB");
            App.Current.MainPage = new AppShell();
            //App.GotoDashboard();
            await PopupNavigation.Instance.PopAsync(true);
            return false;
        }
        public async Task<bool> SelectNorwayLanguage()
        {
            IsClosed = true;
            //Settings.LanguageId = "nb-NO";
            //Settings.HasUserSetLanguage = true;
            //await SwaggerClient.Client.ApiUsersChangelanguageAsync(Settings.UserId, "nb-NO");
            App.Current.MainPage = new AppShell();
            //App.GotoDashboard();
            await PopupNavigation.Instance.PopAsync(true);
            return true;
        }

        public async Task CloseInfo()
        {
            await PopupNavigation.Instance.PopAsync(true);
        }

        private bool _isClosed;
        public bool IsClosed
        {
            get
            {
                return _isClosed;
            }
            set
            {
                _isClosed = value;
                RaisePropertyChanged(() => IsClosed);
            }
        }

        private bool _isDomesticSelected;
        public bool IsDomesticSelected
        {
            get
            {
                return _isDomesticSelected;
            }
            set
            {
                _isDomesticSelected = value;
                RaisePropertyChanged(() => IsDomesticSelected);
            }
        }
    }
}
