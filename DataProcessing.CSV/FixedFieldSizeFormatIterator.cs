using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataProcessing.CSV
{
    public class FixedFieldSizeFormatIterator<T> : IEnumerable<string>
    {
        private readonly string _row;
        private readonly int[] _widths;
        private int _currentIndex = 0;

        public FixedFieldSizeFormatIterator(string row, params int[] widths)
        {
            _row = row;
            _widths = widths;
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            while (_widths.Length > _currentIndex)
            {
                var currentWidth = _widths[_currentIndex++];
                var currentString = new string(_row.Take(currentWidth).ToArray());

                yield return currentString;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable<string>) this).GetEnumerator();
        }
    }

}
