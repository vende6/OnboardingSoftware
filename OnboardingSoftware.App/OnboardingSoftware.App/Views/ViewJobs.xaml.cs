using OnboardingSoftware.App.Cards.BusinessLogic;
using OnboardingSotware.App.Cards.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnboardingSoftware.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewJobs : ContentPage
    {
        public ObservableCollection<Employee> employees;
        EmplyeeBL _EBL = new EmplyeeBL();
        public ViewJobs()
        {
            InitializeComponent();

            FillList();
        }

        public async void FillList()
        {
            employees = new ObservableCollection<Employee>();
            var _data = await _EBL.GetRecord();
            if (_data.Count != 0)
            {
                employees = _data;
                Emplist1.ItemsSource = _data;
            }
            else
            {
                employees = null;
            }

        }
    }
}