using Microsoft.UI.Xaml.Controls;
using Prueba.Models;
using System.Collections.ObjectModel;

namespace Prueba;

public partial class TareaPage : ContentPage
{
    private readonly APIService _APIService;
    public TareaPage(APIService aPIService)
    {
        InitializeComponent();
        _APIService = aPIService;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        List<Tarea> ListaProducto = await _APIService.GetTarea();
        var tareas = new ObservableCollection<Tarea>(ListaTarea);
        listaTarea.ItemsSource = tareas;
    }

    private async void OnClickNuevoTarea(object sender, EventArgs e)
    {
        //var toast = Toast.Make("Click en nuevo producto", ToastDuration.Short, 14);

        //await toast.Show();

        await Navigation.PushAsync(new NuevaTareaPage(_APIService));
    }

        List<int> numberList = new List<int>();
        numbersList.Add(1);
        numbersList.Add(2);
        numbersList.Add(3);
   




   /* private async void OnClickBuscar(object sender, SelectedItemChangedEventArgs e)
    {
        var toast = CommunityToolkit.Maui.Alerts.Toast.Make("Click en ver producto", ToastDuration.Short, 14);

        await toast.Show();
        Producto producto = e.SelectedItem as Producto;
        await Navigation.PushAsync(new DetalleProductoPage(_APIService)
        {
            BindingContext = producto,
        });
    }*/
}