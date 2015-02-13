using ExampleApp.Model;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace ExampleApp.UI
{
    public class ViewModelAsync : BaseViewModel
    {
        private Progress<double> _progress;
        private CancellationTokenSource _canellationToken;
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

        private double _workDone;
        public double WorkDone
        {
            get { return _workDone; }
            set { _workDone = value; OnPropertyChanged("WorkDone"); }
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

        public ViewModelAsync()
        {
            DelayMilliseconds = 50;

            LoadDataCommand = new RelayCommand<Object>(LoadDataHandler);
            LoadDataSequenceCommand = new RelayCommand<Object>(LoadDataSequenceHandler);
            ClearCommand = new RelayCommand<Object>(ClearHandler);
            CancelCommand = new RelayCommand<Object>(CancelHandler);
        }

        private void CancelHandler(object obj)
        {
            LoadTime = TimeSpan.Zero;
            RequestRunning = false;
            _canellationToken.Cancel(throwOnFirstException:false);
            _progress = null;
        }

        private void ClearHandler(object obj)
        {
            CancelHandler(this);
            LoadTime = TimeSpan.Zero;
            AllData = null;
            SearchResult = null;
            _progress = null;
            WorkDone = 0;
        }

        private async void LoadDataSequenceHandler(object obj)
        {
            StopProgress();
            ReloadCancelationToken();
            _progress = new Progress<double>((input) =>
            {
                WorkDone = input;
            });
            AllData = new ObservableCollection<UserDto>();

            _model.GetDataSequenceAsync(Properties.Resources.Data,
                TimeSpan.FromMilliseconds(DelayMilliseconds),
                _progress,
                AllData as ICollection<UserDto>,
                _canellationToken.Token);
        }

        private void ReloadCancelationToken()
        {
            if (_canellationToken != null)
                _canellationToken.Dispose();

            _canellationToken = new CancellationTokenSource();
        }

        private void LoadDataHandler(object obj)
        {
            StartProgress();
            if (_canellationToken != null)
                _canellationToken.Dispose();

            _canellationToken = new CancellationTokenSource();
            LoadData(DelayMilliseconds);
        }

        private void LoadData(uint delayMilliseconds)
        {
            var sw = new Stopwatch();
            sw.Start();

            Utils.Async(() => _model.GetData(Properties.Resources.Data, TimeSpan.FromMilliseconds(delayMilliseconds)),
                result => {
                    if (!_canellationToken.IsCancellationRequested)
                        AllData = result;

                    sw.Stop();
                    LoadTime = sw.Elapsed;
                    StopProgress();
                });

            //Task.Factory.StartNew<ICollection<UserDto>>(() =>
            //{
            //    return _model.GetData(Properties.Resources.Data, TimeSpan.FromMilliseconds(delayMilliseconds));
            //}).ContinueWith((input) =>
            //{
            //    // why cannot user BeginInvoke here?
            //    //Dispatcher.CurrentDispatcher.Invoke(() =>
            //    //{
            //    //    AllData = input.Result;
            //    //    sw.Stop();
            //    //    LoadTime = sw.Elapsed;
            //    //}, DispatcherPriority.Render);

            //    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            //    {
            //        AllData = input.Result;
            //        sw.Stop();
            //        LoadTime = sw.Elapsed;
            //        StopProgress();
            //    }), DispatcherPriority.Background, null);
            //}, TaskContinuationOptions.OnlyOnRanToCompletion);

        }

        private void FilterData(string _searchText)
        {
            if (AllData == null)
                LoadData(delayMilliseconds: 0);

            Utils.Async(
                () => {
                    Thread.Sleep(TimeSpan.FromMilliseconds(DelayMilliseconds));
                    return AllData.Where(x => x.Name.ToLower().Contains(_searchText.ToLower()))
                      .OrderBy(x => x.Name)
                      .ToList();
                },
                result => {
                    SearchResult = result;
                });


            //Task.Factory.StartNew(() =>
            //{
            //    return AllData
            //        .Where(x => x.Name.ToLower().Contains(_searchText.ToLower()))
            //        .OrderBy(x => x.Name)
            //        .ToList();
            //}).ContinueWith((input) =>
            //{
            //    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            //    {
            //        SearchResult = input.Result;
            //    }), DispatcherPriority.Background, null);
            //});
        }

        private void StartProgress()
        {
            RequestRunning = true;
        }

        private void StopProgress()
        {
            RequestRunning = false;
        }
    }
}