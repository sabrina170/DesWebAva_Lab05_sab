﻿using System;
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
using System.Windows.Shapes;
using Business;
using Entity;

namespace Semana5
{
    /// <summary>
    /// Lógica de interacción para ListaCategoria.xaml
    /// </summary>
    public partial class ListaCategoria : Window
    {
        public ListaCategoria()
        {
            InitializeComponent();
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e) {

            Cargar();
        }

        private void Cargar()
        {
            BCategoria Bcategoria = null;
            try
            {
                Bcategoria = new BCategoria();
                dgvCategoria.ItemsSource = Bcategoria.Listar(0);
            }
            catch (Exception)
            {
                MessageBox.Show("Comunicate con el administrador");
            }
            finally
            {
                Bcategoria = null;
            }
        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            ManCategoria manCategoria = new ManCategoria(0);
            manCategoria.ShowDialog();
            Cargar();
        }

        private void DgvCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idCategoria;
            var item = (Categoria)dgvCategoria.SelectedItem;
            if (null == item) return;
            idCategoria = Convert.ToInt32(item.IdCategoria);
            //colo 0 porque es uno
            ManCategoria manCategoria = new ManCategoria(idCategoria);
            manCategoria.ShowDialog();
            Cargar();
        }

    }
}
