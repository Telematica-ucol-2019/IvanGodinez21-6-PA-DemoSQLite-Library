using Bogus;
using DemoSQLite.Model;
using DemoSQLite.Repositories;
using DemoSQLite.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DemoSQLite.ViewMode
{
    public class InicioViewModel : BaseViewModel
    {
        public ObservableCollection<Libro> Libros { get; set; }
        public ICommand cmdAgregaLibro { get; set; }
        public ICommand cmdModifcaLibro { get; set; }
        public InicioViewModel()
        {
            Libros = new ObservableCollection<Libro>();
            cmdAgregaLibro = new Command(() => cmdAgregaLibroMetodo());
            cmdModifcaLibro = new Command<Libro>((item) => cmdModifcaLibroMetodo(item));

        }
        private void cmdModifcaLibroMetodo(Libro libro)
        {
            App.Current.MainPage.Navigation.PushAsync(new MattoLibro(libro));
        }
        private void cmdAgregaLibroMetodo()
        {
            Libro libro = new Faker<Libro>()
                .RuleFor(c => c.Autor, f => f.Name.FirstName())
                .RuleFor(c => c.Autor, f => f.Name.FirstName());

            Random rnd = new Random();
            DateTime datetoday = DateTime.Now;
            int rndYear = rnd.Next(1995, datetoday.Year);
            int rndMonth = rnd.Next(1, 12);
            int rndDay = rnd.Next(1, 31);
            DateTime generateDate = new DateTime(rndYear, rndMonth, rndDay);
            Debug.WriteLine($"FECHA ALEATORIA {generateDate}");
            libro.Titulo = "Diccionario fácil";
            libro.Editorial = "Espaninglish";
            libro.Descripcion = "Todo en uno";
            libro.FechaDePublicacion = new FechaDePublicacion() { Fecha = generateDate };
            App.Current.MainPage.Navigation.PushAsync(new MattoLibro(libro));

            Debug.WriteLine($"FECHA ALEATORIA {generateDate}");
        }
        public void GetAll()

        {
            if (Libros != null)
            {
                Libros.Clear();
                App.LibrosDb.GetAll().ForEach(item => Libros.Add(item));
            }
            else
            {
                Libros = new ObservableCollection<Libro>(App.LibrosDb.GetAll());

            }
            OnPropertyChanged();
        }

    
    }
}