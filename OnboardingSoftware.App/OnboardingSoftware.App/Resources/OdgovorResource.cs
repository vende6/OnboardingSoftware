using OnboardingSoftware.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnboardingSoftware.App.Resources
{
    public class OdgovorResource : ExtendedBindableObject
    {
        public int ID { get; set; }
        public string PonudjeniOdgovor_1 { get; set; }
        public string PonudjeniOdgovor_2 { get; set; }
        public string PonudjeniOdgovor_3 { get; set; }
        public string PonudjeniOdgovor_4 { get; set; }
        public bool TacanOdgovor_1 { get; set; }
        public bool TacanOdgovor_2 { get; set; }
        public bool TacanOdgovor_3 { get; set; }
        public bool TacanOdgovor_4 { get; set; }

        public ICommand MarkAsCorrect_1Command => new Command<OdgovorResource>(async odgovor =>
        {
            odgovor.TacanOdgovor_1 = true;
            odgovor.TacanOdgovor_2 = false;
            odgovor.TacanOdgovor_3 = false;
            odgovor.TacanOdgovor_4 = false;
        });
        public ICommand MarkAsCorrect_2Command => new Command<OdgovorResource>(async odgovor =>
        {
            odgovor.TacanOdgovor_1 = false;
            odgovor.TacanOdgovor_2 = true;
            odgovor.TacanOdgovor_3 = false;
            odgovor.TacanOdgovor_4 = false;
        });
        public ICommand MarkAsCorrect_3Command => new Command<OdgovorResource>(async odgovor =>
        {
            odgovor.TacanOdgovor_1 = false;
            odgovor.TacanOdgovor_2 = false;
            odgovor.TacanOdgovor_3 = true;
            odgovor.TacanOdgovor_4 = false;
        });
        public ICommand MarkAsCorrect_4Command => new Command<OdgovorResource>(async odgovor =>
        {
            odgovor.TacanOdgovor_1 = false;
            odgovor.TacanOdgovor_2 = false;
            odgovor.TacanOdgovor_3 = false;
            odgovor.TacanOdgovor_4 = true;
        });
    }
}
