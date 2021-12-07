using OnboardingSoftware.App.Cards.Api;
using OnboardingSotware.App.Cards.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.App.Cards.BusinessLogic
{
    public class EmplyeeBL
    {
         ObservableCollection<Employee> AllEmployee { get; set; }
       

        public async Task <ObservableCollection<Employee>>GetRecord()
        {
            AllEmployee = new ObservableCollection<Employee>();
            
            var data = await  ServiceApi.GetEmplyee();

            if(data!=null)
            {
                try
                {
                    foreach (var a in data)
                    {
                        int _age = Int32.Parse(a.employee_age);
                        if (_age <= 10)
                        {
                            a.color = "green";
                        }
                        else if(_age <=20)
                        {
                            a.color = "yellow";
                        }
                        else if(_age<=30)
                        {
                            a.color = "blue";
                        }
                        else
                        {
                            a.color = "violet ";
                        }
                        AllEmployee.Add(a);
                    }
                }
                catch(Exception ex)
                {

                }
                
            }
            return data;
        }

    }
}
