using NUnit.Framework;
using SkyscraperCenter.Automation.PageObjects.TallestBuildings;
using System;
using System.Linq;

namespace SkyscraperCenter.Automation.Tests
{
    public class TallestBuildingsTests : BaseTest
    {
        private TallestBuildingsPage TallestBuildings;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Navigation.OpenTallestBuildingsPage();
            TallestBuildings = GetPage<TallestBuildingsPage>();

            TallestBuildings.TallestBuildingsList.Show100TallestCompletedBuildingsInTheWorld();
            // TODO wait the table updated. What is the event?
            // I do not know how to check that the table contains exactly needed data (completed, under construction, etc.)
        }

        [Test]
        public void Tallest_Completed_Buildings_Table_contains_100_items()
        {
            Assert.That(TallestBuildings.BuildingsTable.RowCount, Is.EqualTo(100));
        }

        [Test]
        public void Lotte_World_Tower_building_in_Seoul_has_123_floors()
        {
            var nameValues = TallestBuildings.BuildingsTable.GetColumnValues("Name");
            var LotteWorldTowerIndex = nameValues.IndexOf("Lotte World Tower");

            // Execution time: 542 ms
            //var floorValues = TallestBuildings.BuildingsTable.GetColumnValues("Floors");
            //var LotteWorldTowerFloorsNumber = floorValues[LotteWorldTowerIndex];

            // Execution time: 67 ms
            var LotteWorldTowerFloorsNumber = TallestBuildings.BuildingsTable.GetColumnValue("Floors", LotteWorldTowerIndex);

            const string expectedLotteWorldTowerFloorsNumber = "123";

            Assert.That(LotteWorldTowerFloorsNumber, Is.EqualTo(expectedLotteWorldTowerFloorsNumber));
        }

        [Test]
        public void Building_with_the_maximum_number_of_floors()
        {
            var floorValues = TallestBuildings.BuildingsTable.GetColumnValues("Floors");
            
            var maxFloors = floorValues.Select(i => int.TryParse(i, out int val) ? val : 0).Max();
            var maxFloorsIndex = floorValues.IndexOf(maxFloors.ToString());

            // Execution time: 1480 ms
            //var nameValues = TallestBuildings.BuildingsTable.GetColumnValues("Name");
            //var maxFloorsBuilding = nameValues[maxFloorsIndex];

            // Execution time: 78 ms
            var maxFloorsBuilding = TallestBuildings.BuildingsTable.GetColumnValue("Name", maxFloorsIndex);

            Console.WriteLine($"The building with the maximum number of floors {maxFloors} is {maxFloorsBuilding}");
        }
    }
}