using NetworkShaker.Models;
using NetworkShaker.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace NetworkShaker.ViewModels
{
    public class RootViewModel : BaseViewModel
    {
        public RootViewModel()
        {
            AvailablePages =  AppDomain.CurrentDomain.GetAssemblies()
                                       .SelectMany(assembly => assembly.GetTypes())
                                       .Where(type => typeof(INetworkShakerPage).IsAssignableFrom(type) &&
                                                      type.IsInterface == false &&
                                                      type.IsAbstract == false)
                                       .Select(type => new RootPageMenuItem(type,type.Name.Substring(0,type.Name.Length - 4))) // Ohne "Page"
                                       .ToList();
        }

        public List<RootPageMenuItem> AvailablePages { get; set; }
    }
}
