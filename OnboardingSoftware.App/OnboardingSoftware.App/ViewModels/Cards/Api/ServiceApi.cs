using OnboardingSoftware.App.Cards.Common;
using OnboardingSotware.App.Cards.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace OnboardingSoftware.App.Cards.Api
{
    public class ServiceApi
    {
        public static ObservableCollection<Employee> emplyee;
        public static async Task<ObservableCollection<Employee>> GetEmplyee()
        {
            emplyee = new ObservableCollection<Employee>();
            //var client = new HttpClient();
            //string urlFomrate = ConstantsValue.BaseAddress + ConstantsValue.Emplyeelist;
            //string requestContent = urlFomrate;
            try
            {
                //    var request = new HttpRequestMessage(HttpMethod.Get, requestContent);
                //    var response = await client.SendAsync(request);
                //    if (response.IsSuccessStatusCode)
                //    {
                //        var result = response.Content.ReadAsStringAsync().Result;
                //        emplyee = JsonConvert.DeserializeObject<ObservableCollection<Employee>>(result);

                //    }
                //    else
                //    {
                //        return null;
                //    }

                emplyee = new ObservableCollection<Employee>
            {
                new Employee{employee_name="Damir Krkalic", employee_age = "25", employee_salary="3000", profile_image="resource://OnboardingSoftware.App.Images.logo.png", color="green", id="1"},
                new Employee{employee_name="Damir Krkalic", employee_age = "25", employee_salary="3000", profile_image="resource://OnboardingSoftware.App.Images.logo.png", color="green", id="2"}
            };
            }

            catch (Exception ex)
            {
                return null;
            }
            return emplyee;
        }
    }
}
