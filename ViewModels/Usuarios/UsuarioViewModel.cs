using AppRpgEtec.Models;
using AppRpgEtec.Services.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using AppRpgEtec.Views.Usuarios;

namespace AppRpgEtec.ViewModels.Usuarios
{
    public class UsuarioViewModel : BaseViewModel
    {
        private UsuarioService uService;

        public ICommand AutenticarCommand { get; set; }

        public ICommand RegistrarCommand {  get; set; }

        public ICommand DirecionarCadastroCommand { get; set; }


        public UsuarioViewModel()
        {
            uService = new UsuarioService();
            InicializarCommands();
        }

        public void InicializarCommands()
        {
            AutenticarCommand = new Command(async () => await AutenticarUsuario());

            RegistrarCommand = new Command(async () => await RegistrarUsuario());

            DirecionarCadastroCommand = new Command(async () => await DirecionarParaCadastro());
        }
        #region AtributosPropriedades
        private string login = string.Empty;

        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged();

            }
        }
        private string senha = string.Empty;

        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                OnPropertyChanged();

            }
        }
        #endregion

        public async Task AutenticarUsuario()
        {
            try
            {
                Usuario u = new Usuario();
                u.Username = Login;
                u.PasswordString = Senha;

                Usuario uAutenticado = await uService.PostAutenticarUsuarioAsync(u);
                if (!string.IsNullOrEmpty(uAutenticado.Token))
                {
                    string mensagem = $"Bem Vindo(a) {uAutenticado.Username}.";
                    Preferences.Set("UsuarioId", uAutenticado.id);
                    Preferences.Set("UsuarioUsername", uAutenticado.Username);
                    Preferences.Set("UsuarioPerfil", uAutenticado.Perfil);
                    Preferences.Set("UsuarioToken", uAutenticado.Token);

                    await Application.Current.MainPage.DisplayAlert("Informação", mensagem, "OK");

                    Application.Current.MainPage = new MainPage();


                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Informação", "dados incorretos :,V", "Ok");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.
                        DisplayAlert("informação", ex.Message + "Detalhes: " + ex.InnerException, "ok");
            }
        }
        public async Task RegistrarUsuario() //Método para registrar
        {
            try
            {
                Usuario u = new Usuario();
                u.Username = Login;
                u.PasswordString = Senha;

                Usuario uRegistrado = await uService.PostRegistrarUsuarioAsync(u);

                if (uRegistrado.id != 0)
                {
                    string mensagem = $"Usuario Id {uRegistrado.id} registrado com sucesso.";
                    await Application.Current.MainPage.DisplayAlert("Informação", mensagem, "Ok");

                    await Application.Current.MainPage.Navigation.PopAsync(); //Remove a página da ilha de visualização.
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informaçao", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }

        }
        public async Task DirecionarParaCadastro()
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(new CadastroView());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }
    }
}
