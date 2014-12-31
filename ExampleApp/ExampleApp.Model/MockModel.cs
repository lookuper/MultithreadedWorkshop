using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExampleApp.Model
{
    public class MockModel
    {
        public ICollection<UserDto> GetData(String input, TimeSpan delay)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("input");

            var output = new List<UserDto>();
            var dataChunks = input.Split('\n');

            foreach (var chunk in dataChunks)
            {
                var record = chunk.Split('|');
                var userRecord = new UserDto
                {
                    Name = record[0],
                    Company = record[1],
                    Phone = record[2],
                    Country = record[3]
                };

                Thread.Sleep(delay);
                output.Add(userRecord);
            }

            return output;
        }

        public void GetDataSequence(String data, TimeSpan delay, IEnumerable<UserDto> allData)
        {
            if (allData == null)
                throw new ArgumentNullException("allData");

            var output = allData as ICollection<UserDto>;
            if (output == null)
                throw new InvalidCastException("Cannot cast allData to ICollection<UserDto>");

            var dataAsDto = GetData(data, delay);

            foreach (var item in dataAsDto)
            {
                Thread.Sleep(delay);
                output.Add(item);
            }
        }

        public ICollection<UserDto> GetDataSequenceAsync(string data, TimeSpan delay, IProgress<double> progress)
        {
            var output = new List<UserDto>();
            GetDataSequence(data, TimeSpan.Zero, output);

            var onePercent = output.Count / 100;

            foreach (var item in output)
            {
                progress.Report(onePercent);
                onePercent += onePercent;

                Thread.Sleep(delay);
            }

            return output;
        }

        public async void GetDataSequenceAsync(string data, TimeSpan delay, IProgress<double> progress, ICollection<UserDto> allData, CancellationToken token)
        {
            var output = GetData(data, TimeSpan.Zero);
            var onePercent = output.Count / 100;
            double totalPercents = 1;

            foreach (var item in output)
            {
                if (token.IsCancellationRequested)
                    return;

                await Task.Delay(delay);
                allData.Add(item);

                progress.Report(totalPercents);
                totalPercents += onePercent;
            }
        }
    }
}
