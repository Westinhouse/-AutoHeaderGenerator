using System;
using System.Collections.Generic;
using System.Linq;

namespace Classes
{
    internal class Program
    {
        class Location
        {
            public string Name;
            public string Description;
            public List<Location> Neighbors = new List<Location>();
        }
        static void ConnectLocations (Location a, Location b)
        {
           //for a, take location b and add it to the list neighbors for location a. Do the reverse for location b.
           a.Neighbors.Add(b);
           b.Neighbors.Add(a);
           
        }
        static void Main(string[] args)
        {
            var locations = new List<Location>();

            locations.Add(new Location
            {
                Name = "Winterfell",
                Description = "the capital of the Kingdom of the North"
            });

            locations.Add(new Location
            {
                Name = "Pyke",
                Description = "the stronghold and seat of House Greyjoy"
            });

            locations.Add(new Location
            {
                Name = "Riverrun",
                Descripti