using System;
using System.Collections.Generic;
using System.Linq;

namespace Gonzo.Lib
{
    public class SequenceOfZeroesOnes
    {
        private readonly IEnumerable<int> _sequence;

        public override string ToString() => string.Join(',', _sequence);

        public SequenceOfZeroesOnes(string rawSequence)
            : this(rawSequence.Split(',').Select(s => s.Trim()).Where(s => s == "0" || s == "1").Select(int.Parse)) { }

        public SequenceOfZeroesOnes(IEnumerable<int> rawSequence)
        {
            var sequence = rawSequence.Where(x => x == 0 || x == 1);
            if (!sequence.Any())
                throw new ArgumentException("Initial sequence contains no 0 or 1");
            _sequence = sequence;
        }

        public int MaxOnesAfterRemoveItemByStateMachine()
        {
            (int first, int second, int best, int state) = (0, 0, 0, 0);

            foreach (var digit in _sequence)
            {
                switch ((state, digit))
                {
                    case (0, 1): (state, first) = (1, first + 1); break;
                    case (1, 0): state = 2; break;
                    case (1, 1): first++; break;
                    case (2, 0): (best, first, state) = (Math.Max(best, first), 0, 0); break;
                    case (2, 1): (second, state) = (second + 1, 3); break;
                    case (3, 0): (best, first, second) = (Math.Max(best, first + second), second, 0); break;
                    case (3, 1): second++; break;
                }
            }

            var result = Math.Max(best, first + second);
            return result == _sequence.Count() ? result - 1 : result;
        }
    }
}
