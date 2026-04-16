using AppRpgEtec.ViewModels.Armas;

namespace AppRpgEtec.Views.Armas;

public partial class ListagemViewArmas : ContentPage
{
	ListagemArmasViewModel viewModel;
	public ListagemViewArmas()
	{
        InitializeComponent();
		viewModel = new ListagemArmasViewModel();
		BindingContext = viewModel;
		Title = "Armas - App Rpg Etec";
	}
}