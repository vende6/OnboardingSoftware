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

        private bool _tacanOdgovor_1;
        public bool TacanOdgovor_1
        {
            get
            {
                return _tacanOdgovor_1;
            }
            set
            {
                _tacanOdgovor_1 = value;
                RaisePropertyChanged(() => TacanOdgovor_1);
            }
        }

        private bool _tacanOdgovor_4;
        public bool TacanOdgovor_4
        {
            get
            {
                return _tacanOdgovor_4;
            }
            set
            {
                _tacanOdgovor_4 = value;
                RaisePropertyChanged(() => TacanOdgovor_4);
            }
        }

        private bool _tacanOdgovor_2;
        public bool TacanOdgovor_2
        {
            get
            {
                return _tacanOdgovor_2;
            }
            set
            {
                _tacanOdgovor_2 = value;
                RaisePropertyChanged(() => TacanOdgovor_2);
            }
        }

        private bool _tacanOdgovor_3;
        public bool TacanOdgovor_3
        {
            get
            {
                return _tacanOdgovor_3;
            }
            set
            {
                _tacanOdgovor_3 = value;
                RaisePropertyChanged(() => TacanOdgovor_3);
            }
        }

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
