using JetBrains.Annotations;
using Microsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fractal.Fractals.LSytemFractals
{
    public sealed class GenerativeRules
    {
        public GenerativeRules(
            [NotNull] string from,
            [NotNull] string to)
        {
            From = From ?? throw new Exception($"NotNull parameter {from} exception");
            To = to ?? throw new Exception($"NotNull parameter {to} exception");
        }

        [NotNull]
        public string From { get; }

        [NotNull]
        public string To { get; }

        public static List<GenerativeRules> FromString(string text)
        {
            return text.Split(Environment.NewLine).Select(line =>
            {
                var linePair = line.Split('=');
                if(linePair.Count() != 2)
                {
                    throw new Exception($"Broken rule {line}");
                }

                return new GenerativeRules(linePair[0], linePair[1]);
            }).ToList();

        }
    }
}
