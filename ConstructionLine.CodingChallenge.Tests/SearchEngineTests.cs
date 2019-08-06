using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ConstructionLine.CodingChallenge.Tests
{
    [TestFixture]
    public class SearchEngineTests : SearchEngineTestsBase
    {
        private readonly List<Shirt> _shirts;

        public SearchEngineTests()
        {
            _shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
                new Shirt(Guid.NewGuid(), "Blue - Medium", Size.Medium, Color.Blue),
                new Shirt(Guid.NewGuid(), "Black - Small", Size.Small, Color.Black),
                new Shirt(Guid.NewGuid(), "Yellow - Small", Size.Small, Color.Yellow),
                new Shirt(Guid.NewGuid(), "Red - Large", Size.Large, Color.Red),
                new Shirt(Guid.NewGuid(), "Red - Large 2", Size.Large, Color.Red),
                new Shirt(Guid.NewGuid(), "Red - Large 3", Size.Large, Color.Red),
            };
        }

        // TODO: Use TestCaseData

        [Test]
        public void TestColorRed()
        {
            var searchEngine = new SearchEngine(_shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> {Color.Red}
            };

            var results = searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(_shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(_shirts, searchOptions, results.ColorCounts);
        }

        [Test]
        public void TestSizeMedium()
        {
            var searchEngine = new SearchEngine(_shirts);

            var searchOptions = new SearchOptions
            {
                Sizes = new List<Size> { Size.Medium }
            };

            var results = searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(_shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(_shirts, searchOptions, results.ColorCounts);
        }

        [Test]
        public void TestSizeLargeColorBlue()
        {
            var searchEngine = new SearchEngine(_shirts);

            var searchOptions = new SearchOptions
            {
                Sizes = new List<Size> { Size.Large },
                Colors = new List<Color> { Color.Blue}
            };

            var results = searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(_shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(_shirts, searchOptions, results.ColorCounts);
        }

        [Test]
        public void TestSizeMediumAndLarge()
        {
            var searchEngine = new SearchEngine(_shirts);

            var searchOptions = new SearchOptions
            {
                Sizes = new List<Size> { Size.Medium, Size.Large }
            };

            var results = searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(_shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(_shirts, searchOptions, results.ColorCounts);
        }

        [Test]
        public void TestSizeSmallAndMediumColorRed()
        {
            var searchEngine = new SearchEngine(_shirts);

            var searchOptions = new SearchOptions
            {
                Sizes = new List<Size> { Size.Small, Size.Medium },
                Colors = new List<Color> { Color.Red }
            };

            var results = searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(_shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(_shirts, searchOptions, results.ColorCounts);
        }

        [Test]
        public void TestSizeSmallAndMediumAndLargeColorRed()
        {
            var searchEngine = new SearchEngine(_shirts);

            var searchOptions = new SearchOptions
            {
                Sizes = Size.All,
                Colors = new List<Color> { Color.Red }
            };

            var results = searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(_shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(_shirts, searchOptions, results.ColorCounts);
        }

        [Test]
        public void TestAllSizesAndColorBlueAndYellow()
        {
            var searchEngine = new SearchEngine(_shirts);

            var searchOptions = new SearchOptions
            {
                Sizes = Size.All,
                Colors = new List<Color> { Color.Blue, Color.Yellow }
            };

            var results = searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(_shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(_shirts, searchOptions, results.ColorCounts);
        }
    }
}