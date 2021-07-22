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
                if (state == 0)
                {
                    if (digit == 1)
                    {
                        state = 1;
                        first++;
                    }
                    continue;
                }
                if (state == 1)
                {
                    if (digit == 0)
                        state = 2;
                    else
                        first++;
                    continue;
                }
                if (state == 2)
                {
                    if (digit == 0)
                    {
                        best = Math.Max(best, first);
                        first = 0;
                        state = 0;
                    }
                    else
                    {
                        second++;
                        state = 3;
                    }
                    continue;
                }
                if (state == 3)
                {
                    if (digit == 0)
                    {
                        best = Math.Max(best, first + second);
                        first = second;
                        second = 0;
                    }
                    else
                        second++;
                    continue;
                }
            }

            var result = Math.Max(best, first + second);
            return result == _sequence.Count() ? result - 1 : result;
        }
    }
}
