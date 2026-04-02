using AppRpgEtec.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using AppRpgEtec.ViewModels.Usuarios;
namespace AppRpgEtec.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public  void OnPropertyChanged([CallerMemberName] string Name = "")
        {
            PropertyChanged?.Invoke
                (this, new PropertyChangedEventArgs(Name));
        }
       


    }
}
