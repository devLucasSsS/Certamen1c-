using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL;
using DAL;
namespace main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        inscripcionBLL ibll = new inscripcionBLL();
        public MainWindow()
        {
            InitializeComponent();
            cmbProfesion.ItemsSource = Enum.GetValues(typeof(Profesion));
            cmbExperiencia.ItemsSource = Enum.GetValues(typeof(Experiencia));
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            Inscripcion nueva = new Inscripcion();
            nueva.Profesion = (Profesion)cmbProfesion.SelectedValue;
            nueva.Experiencia = (Experiencia)cmbExperiencia.SelectedValue;
            string BonoExp;
            double sueldoBase;
            double bono;
            double bonoEdad;
            nueva.FechaNacimiento = (DateTime)DPfecha.SelectedDate;
            int fecha = nueva.FechaNacimiento.Date.Year;
            DateTime hoy = DateTime.Today;
            if (cmbProfesion.SelectedValue.ToString() == "Constructor" | cmbProfesion.SelectedValue.ToString() == "Ingeniero" | cmbProfesion.SelectedValue.ToString() == "Arquitecto")
            {
                sueldoBase = 1300000;
            }
            else if (cmbProfesion.SelectedValue.ToString() == "Ceramista" | cmbProfesion.SelectedValue.ToString() == "Pintor" | cmbProfesion.SelectedValue.ToString() == "Carpintero")
            {
                sueldoBase = 680000;
            }
            else
            {
                sueldoBase = 860000;
            }

            if (cmbExperiencia.SelectedValue.ToString() == "Junior")
            {
                bono = 1;
                BonoExp = "no Tiene bono";
            }
            else if (cmbProfesion.SelectedValue.ToString() == "Maestro")
            {
                bono = 0.2;
                BonoExp = "Tiene bono por experiencia";
            }
            else
            {
                bono = 0.5;
                BonoExp = "Tiene bono por experiencia";
            }

            if (nueva.Edad < 30)
            {
                bonoEdad = 100000;
            }
            else if (nueva.Edad > 55)
            {
                bonoEdad = 150000;
            }
            else
            {
                bonoEdad = 0;
            }
            sueldoBase = sueldoBase + (sueldoBase * bono) + bonoEdad;
            nueva.Sueldo = sueldoBase;
            nueva.Nombre = txtnombre.Text.Trim();
            nueva.BonoExp = BonoExp;
            if (txtnombre.Text.Trim() == "")
            {
                MessageBox.Show("el nombre no puede estar vacio");
            }
            else if (nueva.FechaNacimiento > hoy)
            {
                MessageBox.Show("la fecha no peude ser mayor a la actual");
            }
            else
            {
                nueva.Edad = hoy.Year - fecha;
                ibll.Agregar(nueva);
            }
            lstDatos.ItemsSource = null;
            lstDatos.ItemsSource = ibll.GetAll();
        }
    }
}
