using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExampleApp.Model;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace ExampleApp.UI
{
    public class ViewModel : BaseViewModel
    {
        #region vm properties and commands
        private TimeSpan _loadTime = TimeSpan.Zero;
        public TimeSpan LoadTime
        {
            get { return _loadTime; }
            set { _loadTime = value; OnPropertyChanged("LoadTime"); }
        }

        private String _searchText { get; set; }
        public String SearchText
        {
            get { return _searchText; }
            set { _searchText = value; FilterData(_searchText); OnPropertyChanged("SearchText"); }
        }

        private uint _delayMilliseconds { get; set; }
        public uint DelayMilliseconds
        {
            get { return _delayMilliseconds; }
            set { _delayMilliseconds = value; OnPropertyChanged("DelayMilliseconds"); }
        }

        private bool _requestRunning;
        public bool RequestRunning
        {
            get { return _requestRunning; }
            set { _requestRunning = value; OnPropertyChanged("RequestRunning"); }
        }

        private IEnumerable<UserDto> _allData;
        public IEnumerable<UserDto> AllData
        {
            get { return _allData; }
            set { _allData = value; OnPropertyChanged("AllData"); }
        }

        private IEnumerable<UserDto> _searchResult;
        public IEnumerable<UserDto> SearchResult
        {
            get { return _searchResult; }
            set { _searchResult = value; OnPropertyChanged("SearchResult"); }
        }

        public ICommand LoadDataCommand { get; set; }
        public ICommand LoadDataSequenceCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        #endregion

        private readonly MockModel _model = new MockModel();        

        public ViewModel()
        {
            DelayMilliseconds = 50;

            LoadDataCommand = new RelayCommand<Object>(LoadDataHandler);
            LoadDataSequenceCommand = new RelayCommand<Object>(LoadDataSequenceHandler);
            ClearCommand = new RelayCommand<Object>(ClearHandler);
            CancelCommand = new RelayCommand<Object>(CancelHandler);
        }

        private void CancelHandler(object obj)
        {
            RequestRunning = false;
        }

        private void ClearHandler(object obj)
        {
            AllData = null;
            SearchResult = null;
        }

        private void LoadDataSequenceHandler(object obj)
        {
            RequestRunning = true;
            AllData = new ObservableCollection<UserDto>();
            _model.GetDataSequence(Properties.Resources.Data, TimeSpan.FromMilliseconds(DelayMilliseconds), AllData);
        }

        private void LoadDataHandler(object obj)
        {
            RequestRunning = true;
            LoadData(DelayMilliseconds);
        }

        private void LoadData(uint delayMilliseconds)
        {
            var sw = new Stopwatch();
            sw.Start();
            AllData = _model.GetData(Properties.Resources.Data, TimeSpan.FromMilliseconds(delayMilliseconds));
            sw.Stop();

            LoadTime = sw.Elapsed;
        }

        private void FilterData(string _searchText)
        {
            if (AllData == null)
                LoadData(0);

            Thread.Sleep(TimeSpan.FromMilliseconds(DelayMilliseconds));
            SearchResult = AllData
                .Where(x => x.Name.ToLower().Contains(_searchText.ToLower()))
                .OrderBy(x => x.Name)
                .ToList();
        }
    }
}
