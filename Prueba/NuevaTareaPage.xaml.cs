using Prueba.Models;
using Prueba.Services;

namespace Prueba;

public partial class NuevaTareaPage : ContentPage
{
    private Tarea _tarea;

    private readonly APIService _APIService;
    public NuevaTareaPage(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _tarea = BindingContext as Tarea;
        if (_tarea != null)
        {
            NombreTarea.Text = _tarea.NombreTarea;
            //Estado.Text = _producto.cantidad.ToString();
            DescripcionTarea.Text = _tarea.DescripcionTarea;
        }
    }

    private async void OnClickGuardarNuevaTarea(object sender, EventArgs e)
    {
        
            Tarea tarea = new Tarea
            {
                IdTarea = 0,
                NombreTarea = Nombre.Text,
                DescripcionTarea = Descripcion.Text,
                //cantidad = Int32.Parse(cantidad.Text)
            };

            await _APIService.PostProducto(tarea);

            //Utils.Utils.ListaProductos.Add(producto);
        }
        await Navigation.PopAsync();

    
}