using System;
using System.Collections.Generic;
using System.Linq;

namespace Gonzo.Lib
{
    public class SequenceOfZeroesOnes
    {
        private readonly IEnumerable<int> _sequence;

        public SequenceOfZeroesOnes(string rawSequence)
            : this(rawSequence.Split(',').Select(s => s.Trim()).Where(s => s == "0" || s == "1").Select(int.Parse)) { }

        public SequenceOfZeroesOnes(IEnumerable<int> rawSequence)
        {
            var sequence = rawSequence.Where(x => x == 0 || x == 1);
            if (!sequence.Any())
                throw new ArgumentException("Initial sequence contains no 0 or 1");
            _sequence = sequence;
        }

        public int CalculateMaxOnesAfterRemoveItem()
        {
            return _sequence.Count();
        }
    }
}
