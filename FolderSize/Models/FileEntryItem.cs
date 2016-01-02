using System;
using System.Diagnostics;
using FolderSize.ViewModels;

namespace FolderSize.Models
{
    [DebuggerDisplay("{TotalLength} {Path}")]
    internal class FileEntryItem : BaseViewModel
    {
        private readonly string _path;
        private readonly Action<long> _call;
        private long _totalLength;
        private  int _level;

        public FileEntryItem(string path, Action<long> call, int level)
        {
            _path = path;
            _call = call;
            _level = level;
        }

        public string DisplayText { get { return _path; } }

        public string Path { get { return _path; } }

        public int Level { get { return _level; } }

        public long TotalLength
        {
            get { return _totalLength; }
            private set
            {
                if (value == _totalLength) return;
                _totalLength = value;
                OnPropertyChanged();
            }
        }

        public void AddLength(long length)
        {
            TotalLength = _totalLength + length;
            _call(length);
        }
    }
}