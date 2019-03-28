using MVVM_Simpel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVM_Simpel.ViewModels
{
    class PersonenViewModel : BaseViewModel
    {
        public PersonenViewModel()
        {
            // Controlfreak-Antipattern
            service = new PersonenService();
            LadePersonenCommand = new Command(LadePersonen);
        }
        private readonly PersonenService service;

        private List<Person> personenliste;
        public List<Person> Personenliste
        {
            get => personenliste;
            set => SetProperty(ref personenliste, value);
        }
        public Command LadePersonenCommand { get; set; }
        private void LadePersonen(object obj)
        {
            Personenliste = service.LadePersonen();
        }
    }
}
