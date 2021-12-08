using OnboardingSoftware.App.LanguageSupport;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnboardingSoftware.App.ViewModels.Cards
{
    public class CardsViewModel : BaseViewModel
    {
        public CardsViewModel()
        {
        }

        public ICommand JobDescriptionCommand
        {
            get
            {
                return new Command<string>(async (route) =>
                {
                    if (Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopupStack.Count == 0)
                        await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Views.Dialogs.JobDialog(Translation.Translate("LanguageTitle"), Translation.Translate("LanguageText")));
                });
            }
        }
    }
}
