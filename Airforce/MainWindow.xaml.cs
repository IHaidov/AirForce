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
using BL = Alesik.Haidov.Airforce.BLC;

namespace Alesik.Haidov.Airforce.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ViewModels.AirbaseListViewModel AirbaseLVM { get; } = new ViewModels.AirbaseListViewModel();
        private ViewModels.AirbaseViewModel selectedAirbase = null;

        public ViewModels.AircraftListViewModel AircraftLVM { get; } = new ViewModels.AircraftListViewModel();
        private ViewModels.AircraftViewModel selectedAircraft = null;

        private readonly BL.BLC blc;

        private string selectedDataSource = "Airforce.DBMock.dll";

        public MainWindow()
        {
            blc = new BL.BLC(selectedDataSource);

            AirbaseLVM.RefreshList(blc.GetAllAirbases());
            AircraftLVM.RefreshList(blc.GetAllAircrafts());

            InitializeComponent();
        }

        private void AircraftList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                ChangeSelectedAircraft((ViewModels.AircraftViewModel)e.AddedItems[0]);
            }
        }

        private void ApplyAircraftSearch(object sender, RoutedEventArgs e)
        {

        }

        private void ApplyAircraftModelFilter(object sender, RoutedEventArgs e)
        {

        }

        private void ApplyAircraftServiceHoursFilter(object sender, RoutedEventArgs e)
        {

        }

        private void ApplyNewDataSource(object sender, RoutedEventArgs e)
        {
            try
            {
                blc.LoadLibrary(datasource.Text);
                AirbaseLVM.RefreshList(blc.GetAllAirbases());
                AircraftLVM.RefreshList(blc.GetAllAircrafts());
                selectedDataSource = datasource.Text;
            }
            catch
            {
                MessageBox.Show("Error occurred, check your input values!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                blc.LoadLibrary(selectedDataSource);
            }
        }

        private void EditAircraft(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveAircraft(object sender, RoutedEventArgs e)
        {

        }

        private void AddAircraft(object sender, RoutedEventArgs e)
        {

        }

        private void ChangeSelectedAircraft(ViewModels.AircraftViewModel aircraftViewModel)
        {
            selectedAircraft = aircraftViewModel;
            DataContext = selectedAircraft;
        }

        private void ChangeSelectedAirbase(ViewModels.AirbaseViewModel airbaseViewModel)
        {
            selectedAirbase = airbaseViewModel;
            DataContext = selectedAirbase;
        }
    }
}
