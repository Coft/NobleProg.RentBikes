using NobleProg.RentBikes.Models;
using NobleProg.RentBikes.ViewModels.Commands;
using NobleProg.RentBikes.ViewModels.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NobleProg.RentBikes.ViewModels
{
    public class StationsViewModel : BaseViewModel
    {
        private readonly IStationsService stationsService;

        #region Stations

        private ObservableCollection<Station> _stations;

        public ObservableCollection<Station> Stations
        {
            get
            {
                return _stations;
            }

            set
            {
                _stations = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region SelectedStation

        private Station selectedStation;
        public Station SelectedStation
        {
            get
            {
                return selectedStation;
            }

            set
            {
                selectedStation = value;

                OnPropertyChanged();
            }
        }

        #endregion


        public Location CurrentLocation { get; set; }

        #region AddStationCommand

        private ICommand addStationCommand;

        public ICommand AddStationCommand
        {
            get
            {
                if (addStationCommand == null)
                {
                    addStationCommand = new RelayCommand(p=>AddStation());
                }
                return addStationCommand;
            }
        }

        private void AddStation()
        {
            this.Stations.Add(new Station
            {
                StationId = 5,
                StationNumber = "S05",
                StationName = "WaWa Wola",
                StationLocation = new Location(52.14, 20.90),
                IsActive = false,
            });
        }

        #endregion
       
        #region SendCommand

        private ICommand sendCommand;
        private ICommand asyncLoadCommand;

        public ICommand SendCommand
        {
            get
            {
                if (sendCommand == null)
                {
                    sendCommand = new RelayCommand(Send, CanSend);
                }
                return sendCommand;
            }
        }

     
        private bool CanSend(object o) => SelectedStation != null;

        private void Send(object o)
        {
            MessageBox.Show($"Sent to Station: {SelectedStation.FullName}");
            SelectedStation.StationName = "Berlin";
            
        }

        #endregion

        #region LoadCommand

        private ICommand loadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (loadCommand == null)
                {
                    loadCommand = new RelayCommand(p=>LoadStations());
                }
                return loadCommand;
            }
        }


        private void LoadStations()
        {
            Stations = new ObservableCollection<Station>(stationsService.GetStations());
            CurrentLocation = new Location(52.01, 20.90);
            //Thread.Sleep(2000);

        }

        #endregion

        #region AsyncLoadCommand

        public ICommand AsyncLoadCommand
        {
            get
            {
                if (asyncLoadCommand == null)
                {
                    asyncLoadCommand = new AsyncRelayCommand(p => AsyncLoadStations());
                }
                return asyncLoadCommand;
            }
        }

        private async Task AsyncLoadStations()
        {

            await Task.Delay(5000);
            Stations = new ObservableCollection<Station>(stationsService.GetStations());
            CurrentLocation = new Location(52.01, 20.90);
        }

        #endregion

        public StationsViewModel()
        {
            stationsService = new MockStationsService();
            this.Stations = new ObservableCollection<Station>();
        }
    }
}
