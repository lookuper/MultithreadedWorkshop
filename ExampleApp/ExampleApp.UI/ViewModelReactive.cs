using ExampleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Splat;
using System.Reactive.Linq;

namespace ExampleApp.UI
{
    public class ViewModelReactive : ReactiveObject
    {
        private readonly MockModel _model = new MockModel();

        private TimeSpan _loadTime = TimeSpan.Zero;
        public TimeSpan LoadTime
        {
            get { return _loadTime; }
            set { this.RaiseAndSetIfChanged(ref _loadTime, value); }
        }


        private uint _delayMilliseconds;
        public uint DelayMilliseconds
        {
            get { return _delayMilliseconds; }
            set { this.RaiseAndSetIfChanged(ref _delayMilliseconds, value); }
        }

        private string _searchText = String.Empty;
        public String SearchText
        {
            get { return _searchText; }
            set { this.RaiseAndSetIfChanged(ref _searchText, value); }
        }

        private Progress<double> _progress;
        public Progress<double> Progress
        {
            get { return _progress; }
            set { this.RaiseAndSetIfChanged(ref _progress, value); }
        }

        private double _workDone;
        public double WorkDone
        {
            get { return _workDone; }
            set { this.RaiseAndSetIfChanged(ref _workDone, value); }
        }

        public ReactiveList<UserDto> AllData { get; set; }
        public ReactiveList<UserDto> SearchResult { get; set; }

        public ReactiveCommand<List<UserDto>> Search { get; set; }

        public ReactiveCommand<List<UserDto>> LoadDataCommand { get; set; }
        public ReactiveCommand<List<UserDto>> LoadDataSequenceCommand { get; set; }
        
        public Task<List<UserDto>> GetDataTask()
        {
            return Task.Run(() =>
            {
                return _model.GetData(Properties.Resources.Data, TimeSpan.FromMilliseconds(DelayMilliseconds)).ToList();
            });
        }

        public ViewModelReactive()
        {
            AllData = new ReactiveList<UserDto>();
            SearchResult = new ReactiveList<UserDto>();
            _progress = new Progress<double>((input) =>
            {
                WorkDone = input;
            });

            var canSearch = this.WhenAny(x => x.SearchText, x => !String.IsNullOrEmpty(x.Value));
            var canLoad = Observable.Return(true);

            Search = ReactiveCommand.CreateAsyncTask(canSearch, async x =>
            {
                return await Task.Run(() =>
                {
                    return AllData
                        .Where(d => d.Name.ToLower().Contains(_searchText.ToLower()))
                        .OrderBy(d => d.Name)
                        .ToList();
                });                 
            });
            Search.Subscribe(res =>
            {
                SearchResult.Clear();
                foreach (var item in res)
                {
                    SearchResult.Add(item);
                }
            });

            LoadDataCommand = ReactiveCommand.CreateAsyncTask(canLoad, async _ => { return await GetDataTask(); });
            LoadDataCommand.Subscribe(results =>
            {
                AllData.Clear();
                foreach (var item in results)
                {
                    AllData.Add(item);
                }
            });

            LoadDataSequenceCommand = ReactiveCommand.CreateAsyncTask(canLoad, async _ =>
            {
                return await Task.Run(() =>
                {
                    return _model.GetDataSequenceAsync(Properties.Resources.Data, TimeSpan.FromMilliseconds(DelayMilliseconds), _progress)
                        .ToList();
                });
            });
            LoadDataSequenceCommand.Subscribe(res =>
            {
                AllData.Clear();
                foreach (var item in res)
                {
                    AllData.Add(item);
                }
            });

            this.WhenAnyValue(x => x.SearchText)
                .Throttle(TimeSpan.FromSeconds(1))
                .InvokeCommand(this, x => x.Search);
        }
    }
}
