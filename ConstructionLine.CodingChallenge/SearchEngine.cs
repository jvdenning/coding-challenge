using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine
    {
        private readonly List<Shirt> _shirts;

        public SearchEngine(List<Shirt> shirts)
        {
            _shirts = shirts;

            // TODO: data preparation and initialisation of additional data structures to improve performance goes here.
       
        }


        public SearchResults Search(SearchOptions options)
        {
            var matchingShirts = _shirts.Where(s =>
                (!options.Colors.Any() || options.Colors.Exists(c => c.Id == s.Color.Id)) &&
                (!options.Sizes.Any() || options.Sizes.Exists(sz => sz.Id == s.Size.Id))).ToList();


            return new SearchResults
            {
                Shirts = matchingShirts,
                ColorCounts = matchingShirts.Where(ms => options.Colors.Any(c => c.Id == ms.Color.Id))
                                    .GroupBy(s => s.Color)
                                    .Select(c => new ColorCount{Color = c.Key,Count = c.Count()})
                                    .Union(
                                        Color.All.Where(c=> options.Colors.All(mc => mc.Id != c.Id) || matchingShirts.All(ms => ms.Color.Id != c.Id))
                                            .Select(c => new ColorCount{Color = c}))
                                    .ToList(),
                SizeCounts = matchingShirts.Where(ms => options.Sizes.Any(s => s.Id == ms.Size.Id))
                                    .GroupBy(s => s.Size)
                                    .Select(c => new SizeCount { Size = c.Key, Count = c.Count() })
                                    .Union(Size.All.Where(s => options.Sizes.All(ms => ms.Id != s.Id) || matchingShirts.All(ms => ms.Size.Id != s.Id))
                                        .Select(s => new SizeCount{Size = s}))
                                    .ToList()
            };
        }
    }
}