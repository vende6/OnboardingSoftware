using OnboardingSoftware.Api;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace OnboardingSoftware.App.Resources
{
    public class PitanjeResource : ExtendedBindableObject
    {
        public int ID { get; set; }
        public string Tekst { get; set; }
        public string Tip { get; set; }
        public string RedniBroj { get; set; }
        public string Test { get; set; }
        public bool IsLast { get; set; }
        public int Position { get; set; }


        private Color _color;
        public Color Color
        {
            get
            {
                if(RedniBroj.Contains("1"))
                return Color.FromHex("#e16f62");
                else if (RedniBroj.Contains("2"))
                    return Color.FromHex("#e16f62");
                else
                return Color.FromHex("##56cd89");
            }
            set
            {
                _color = value;
                RaisePropertyChanged(() => Color);
            }
        }


        private ObservableCollection<OdgovorResource> _odgovori = new ObservableCollection<OdgovorResource>();
        public ObservableCollection<OdgovorResource> Odgovori
        {
            get
            {
                return _odgovori;
            }
            set
            {
                _odgovori = value;
                RaisePropertyChanged(() => Odgovori);
            }
        }
    }
}
