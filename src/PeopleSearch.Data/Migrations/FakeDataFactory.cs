﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using PeopleSearch.Data.Entity.Model;

namespace PeopleSearch.Data.Migrations
{
    public static class FakeDataFactory
    {
        public static List<Address> CreateAddresses()
        {
            return new List<Address>
            {
                new Address
                {
                    StreetLineOne = "1728 Candlelight Drive",
                    City = "Houston",
                    StateOrProvince = "TX",
                    PostalCode = "77032"
                },

                new Address
                {
                    StreetLineOne = "3439 Viking Drive",
                    City = "Byesville",
                    StateOrProvince = "OH",
                    PostalCode = "43723"
                },

                new Address
                {
                    StreetLineOne = "4594 Berkley Street",
                    City = "Philadelphia",
                    StateOrProvince = "PA",
                    PostalCode = "19103"
                },
                new Address
                {
                    StreetLineOne = "3202 Briercliff Road",
                    City = "Hicksville",
                    StateOrProvince = "NY",
                    PostalCode = "11612"
                },
                new Address
                {
                    StreetLineOne = "2016 Overlook Drive",
                    City = "Indianapolis",
                    StateOrProvince = "IN",
                    PostalCode = "46225"
                },
                new Address
                {
                    StreetLineOne = "3021 Stadium Drive",
                    City = "Brockton",
                    StateOrProvince = "MA",
                    PostalCode = "02401"
                },
                new Address
                {
                    StreetLineOne = "3403 Benedum Drive",
                    City = "New Paltz",
                    StateOrProvince = "NY",
                    PostalCode = "12561"
                },
                new Address
                {
                    StreetLineOne = "161 Clarence Court",
                    City = "Long Beach",
                    StateOrProvince = "NC",
                    PostalCode = "28461"
                }
            };
        }

        public static List<Person> CreatePeople()
        {
            var people = new List<Person>
            {
                new Person { FirstName = "Susan", LastName = "Nicholson", Gender = Gender.Female},
                new Person { FirstName = "Albert", LastName = "Porter", Gender = Gender.Male},
                new Person { FirstName = "Helen", LastName = "Short", Gender = Gender.Female},
                new Person { FirstName = "Wendell", LastName = "Ford", Gender = Gender.Male},
                new Person { FirstName = "Billy", LastName = "Lane", Gender = Gender.Male},
                new Person { FirstName = "Roberto", LastName = "Peloquin", Gender = Gender.Male},
                new Person { FirstName = "Carrie", LastName = "Crawford", Gender = Gender.Female},
                new Person { FirstName = "Linwood", LastName = "McCarter", Gender = Gender.Female}
            };

            var thisAssembly = Assembly.GetAssembly(typeof(FakeDataFactory));
            
            foreach (var person in people.Where(person => person.Gender != Gender.Unspecified))
            {
                using (var ms = new MemoryStream())
                {
                    if (person.Gender == Gender.Female)
                    {
                        thisAssembly.GetManifestResourceStream("PeopleSearch.Data.MigrationResources.FemaleIcon.png")?.CopyTo(ms);
                    }
                    else
                    {
                        thisAssembly.GetManifestResourceStream("PeopleSearch.Data.MigrationResources.MaleIcon.png")?.CopyTo(ms);
                    }

                    person.PortraitPicture = ms.ToArray();
                }
                    
            }

            return people;
        }

        public static List<Interest> CreateInterests()
        {
            return new List<Interest>
            {
                new Interest {Text = "Aircraft Spotting"},
                new Interest {Text = "Airbrushing"},
                new Interest {Text = "Airsofting"},
                new Interest {Text = "Acting"},
                new Interest {Text = "Aeromodeling"},
                new Interest {Text = "Amateur Astronomy"},
                new Interest {Text = "Amateur Radio"},
                new Interest {Text = "Animals/pets/dogs"},
                new Interest {Text = "Archery"},
                new Interest {Text = "Arts"},
                new Interest {Text = "Aquarium"},
                new Interest {Text = "Astrology"},
                new Interest {Text = "Astronomy"},
                new Interest {Text = "Backgammon"},
                new Interest {Text = "Badminton"},
                new Interest {Text = "Baseball"},
                new Interest {Text = "Base Jumping"},
                new Interest {Text = "Basketball"},
                new Interest {Text = "Beach/Sun tanning"},
                new Interest {Text = "Beachcombing"},
                new Interest {Text = "Beadwork"},
                new Interest {Text = "Beatboxing"},
                new Interest {Text = "Becoming A Child Advocate"},
                new Interest {Text = "Bell Ringing"},
                new Interest {Text = "Belly Dancing"},
                new Interest {Text = "Bicycling"},
                new Interest {Text = "Bicycle Polo"},
                new Interest {Text = "Bird watching"},
                new Interest {Text = "Birding"},
                new Interest {Text = "BMX"},
                new Interest {Text = "Blacksmithing"},
                new Interest {Text = "Blogging"},
                new Interest {Text = "BoardGames"},
                new Interest {Text = "Boating"},
                new Interest {Text = "Body Building"},
                new Interest {Text = "Bonsai Tree"},
                new Interest {Text = "Bookbinding"},
                new Interest {Text = "Boomerangs"},
                new Interest {Text = "Bowling"},
                new Interest {Text = "Brewing Beer"},
                new Interest {Text = "Bridge Building"},
                new Interest {Text = "Building Dollhouses"},
                new Interest {Text = "Butterfly Watching"},
                new Interest {Text = "Button Collecting"},
                new Interest {Text = "Cake Decorating"},
                new Interest {Text = "Calligraphy"},
                new Interest {Text = "Camping"},
                new Interest {Text = "Candle Making"},
                new Interest {Text = "Canoeing"},
                new Interest {Text = "Cartooning"},
                new Interest {Text = "Car Racing"},
                new Interest {Text = "Casino Gambling"},
                new Interest {Text = "Cave Diving"},
                new Interest {Text = "Ceramics"},
                new Interest {Text = "Cheerleading"},
                new Interest {Text = "Chess"},
                new Interest {Text = "Church/church activities"},
                new Interest {Text = "Cigar Smoking"},
                new Interest {Text = "Cloud Watching"},
                new Interest {Text = "Coin Collecting"},
                new Interest {Text = "Collecting"},
                new Interest {Text = "Collecting Antiques"},
                new Interest {Text = "Collecting Artwork"},
                new Interest {Text = "Collecting Hats"},
                new Interest {Text = "Collecting Music Albums"},
                new Interest {Text = "Collecting RPM Records"},
                new Interest {Text = "Collecting Sports Cards"},
                new Interest {Text = "Collecting Swords"},
                new Interest {Text = "Coloring"},
                new Interest {Text = "Compose Music"},
                new Interest {Text = "Computer activities"},
                new Interest {Text = "Conworlding"},
                new Interest {Text = "Cooking"},
                new Interest {Text = "Cosplay"},
                new Interest {Text = "Crafts"},
                new Interest {Text = "Crafts (unspecified)"},
                new Interest {Text = "Crochet"},
                new Interest {Text = "Crocheting"},
                new Interest {Text = "Cross-Stitch"},
                new Interest {Text = "Crossword Puzzles"},
                new Interest {Text = "Dancing"},
                new Interest {Text = "Darts"},
                new Interest {Text = "Diecast Collectibles"},
                new Interest {Text = "Digital Photography"},
                new Interest {Text = "Dodgeball"},
                new Interest {Text = "Dolls"},
                new Interest {Text = "Dominoes"},
                new Interest {Text = "Drawing"},
                new Interest {Text = "Dumpster Diving"},
                new Interest {Text = "Eating out"},
                new Interest {Text = "Educational Courses"},
                new Interest {Text = "Electronics"},
                new Interest {Text = "Embroidery"},
                new Interest {Text = "Entertaining"},
                new Interest {Text = "Exercise"},
                new Interest {Text = "Falconry"},
                new Interest {Text = "Fast cars"},
                new Interest {Text = "Felting"},
                new Interest {Text = "Fencing"},
                new Interest {Text = "Fire Poi"},
                new Interest {Text = "Fishing"},
                new Interest {Text = "Floorball"},
                new Interest {Text = "Floral Arrangements"},
                new Interest {Text = "Fly Tying"},
                new Interest {Text = "Football"},
                new Interest {Text = "Four Wheeling"},
                new Interest {Text = "Freshwater Aquariums"},
                new Interest {Text = "Frisbee Golf – Frolf"},
                new Interest {Text = "Games"},
                new Interest {Text = "Gardening"},
                new Interest {Text = "Garage Saleing"},
                new Interest {Text = "Genealogy"},
                new Interest {Text = "Geocaching"},
                new Interest {Text = "Ghost Hunting"},
                new Interest {Text = "Glowsticking"},
                new Interest {Text = "Gnoming"},
                new Interest {Text = "Going to movies"},
                new Interest {Text = "Golf"},
                new Interest {Text = "Go Kart Racing"},
                new Interest {Text = "Grip Strength"},
                new Interest {Text = "Guitar"},
                new Interest {Text = "Gunsmithing"},
                new Interest {Text = "Gun Collecting"},
                new Interest {Text = "Gymnastics"},
                new Interest {Text = "Gyotaku"},
                new Interest {Text = "Handwriting Analysis"},
                new Interest {Text = "Hang gliding"},
                new Interest {Text = "Herping"},
                new Interest {Text = "Hiking"},
                new Interest {Text = "Home Brewing"},
                new Interest {Text = "Home Repair"},
                new Interest {Text = "Home Theater"},
                new Interest {Text = "Horse riding"},
                new Interest {Text = "Hot air ballooning"},
                new Interest {Text = "Hula Hooping"},
                new Interest {Text = "Hunting"},
                new Interest {Text = "Iceskating"},
                new Interest {Text = "Illusion"},
                new Interest {Text = "Impersonations"},
                new Interest {Text = "Internet"},
                new Interest {Text = "Inventing"},
                new Interest {Text = "Jet Engines"},
                new Interest {Text = "Jewelry Making"},
                new Interest {Text = "Jigsaw Puzzles"},
                new Interest {Text = "Juggling"},
                new Interest {Text = "Keep A Journal"},
                new Interest {Text = "Jump Roping"},
                new Interest {Text = "Kayaking"},
                new Interest {Text = "Kitchen Chemistry"},
                new Interest {Text = "Kites"},
                new Interest {Text = "Kite Boarding"},
                new Interest {Text = "Knitting"},
                new Interest {Text = "Knotting"},
                new Interest {Text = "Lasers"},
                new Interest {Text = "Lawn Darts"},
                new Interest {Text = "Learn to Play Poker"},
                new Interest {Text = "Learning A Foreign Language"},
                new Interest {Text = "Learning An Instrument"},
                new Interest {Text = "Learning To Pilot A Plane"},
                new Interest {Text = "Leathercrafting"},
                new Interest {Text = "Legos"},
                new Interest {Text = "Letterboxing"},
                new Interest {Text = "Listening to music"},
                new Interest {Text = "Locksport"},
                new Interest {Text = "Lacrosse"},
                new Interest {Text = "Macramé"},
                new Interest {Text = "Magic"},
                new Interest {Text = "Making Model Cars"},
                new Interest {Text = "Marksmanship"},
                new Interest {Text = "Martial Arts"},
                new Interest {Text = "Matchstick Modeling"},
                new Interest {Text = "Meditation"},
                new Interest {Text = "Microscopy"},
                new Interest {Text = "Metal Detecting"},
                new Interest {Text = "Model Railroading"},
                new Interest {Text = "Model Rockets"},
                new Interest {Text = "Modeling Ships"},
                new Interest {Text = "Models"},
                new Interest {Text = "Motorcycles"},
                new Interest {Text = "Mountain Biking"},
                new Interest {Text = "Mountain Climbing"},
                new Interest {Text = "Musical Instruments"},
                new Interest {Text = "Nail Art"},
                new Interest {Text = "Needlepoint"},
                new Interest {Text = "Owning An Antique Car"},
                new Interest {Text = "Origami"},
                new Interest {Text = "Painting"},
                new Interest {Text = "Paintball"},
                new Interest {Text = "Papermaking"},
                new Interest {Text = "Papermache"},
                new Interest {Text = "Parachuting"},
                new Interest {Text = "Paragliding or Power Paragliding"},
                new Interest {Text = "Parkour"},
                new Interest {Text = "People Watching"},
                new Interest {Text = "Photography"},
                new Interest {Text = "Piano"},
                new Interest {Text = "Pinochle"},
                new Interest {Text = "Pipe Smoking"},
                new Interest {Text = "Planking"},
                new Interest {Text = "Playing music"},
                new Interest {Text = "Playing team sports"},
                new Interest {Text = "Pole Dancing"},
                new Interest {Text = "Pottery"},
                new Interest {Text = "Powerboking"},
                new Interest {Text = "Protesting"},
                new Interest {Text = "Puppetry"},
                new Interest {Text = "Pyrotechnics"},
                new Interest {Text = "Quilting"},
                new Interest {Text = "Racing Pigeons"},
                new Interest {Text = "Rafting"},
                new Interest {Text = "Railfans"},
                new Interest {Text = "Rapping"},
                new Interest {Text = "R/C Boats"},
                new Interest {Text = "R/C Cars"},
                new Interest {Text = "R/C Helicopters"},
                new Interest {Text = "R/C Planes"},
                new Interest {Text = "Reading"},
                new Interest {Text = "Reading To The Elderly"},
                new Interest {Text = "Relaxing"},
                new Interest {Text = "Renaissance Faire"},
                new Interest {Text = "Renting movies"},
                new Interest {Text = "Rescuing Abused Or Abandoned Animals"},
                new Interest {Text = "Robotics"},
                new Interest {Text = "Rock Balancing"},
                new Interest {Text = "Rock Collecting"},
                new Interest {Text = "Rockets"},
                new Interest {Text = "Rocking AIDS Babies"},
                new Interest {Text = "Roleplaying"},
                new Interest {Text = "Running"},
                new Interest {Text = "Saltwater Aquariums"},
                new Interest {Text = "Sand Castles"},
                new Interest {Text = "Scrapbooking"},
                new Interest {Text = "Scuba Diving"},
                new Interest {Text = "Self Defense"},
                new Interest {Text = "Sewing"},
                new Interest {Text = "Shark Fishing"},
                new Interest {Text = "Skeet Shooting"},
                new Interest {Text = "Skiing"},
                new Interest {Text = "Shopping"},
                new Interest {Text = "Singing In Choir"},
                new Interest {Text = "Skateboarding"},
                new Interest {Text = "Sketching"},
                new Interest {Text = "Sky Diving"},
                new Interest {Text = "Slack Lining"},
                new Interest {Text = "Sleeping"},
                new Interest {Text = "Slingshots"},
                new Interest {Text = "Slot Car Racing"},
                new Interest {Text = "Snorkeling"},
                new Interest {Text = "Snowboarding"},
                new Interest {Text = "Soap Making"},
                new Interest {Text = "Soccer"},
                new Interest {Text = "Socializing with friends/neighbors"},
                new Interest {Text = "Speed Cubing (rubix cube)"},
                new Interest {Text = "Spelunkering"},
                new Interest {Text = "Spending time with family/kids"},
                new Interest {Text = "Stamp Collecting"},
                new Interest {Text = "Storm Chasing"},
                new Interest {Text = "Storytelling"},
                new Interest {Text = "String Figures"},
                new Interest {Text = "Surfing"},
                new Interest {Text = "Surf Fishing"},
                new Interest {Text = "Survival"},
                new Interest {Text = "Swimming"},
                new Interest {Text = "Tatting"},
                new Interest {Text = "Taxidermy"},
                new Interest {Text = "Tea Tasting"},
                new Interest {Text = "Tennis"},
                new Interest {Text = "Tesla Coils"},
                new Interest {Text = "Tetris"},
                new Interest {Text = "Texting"},
                new Interest {Text = "Textiles"},
                new Interest {Text = "Tombstone Rubbing"},
                new Interest {Text = "Tool Collecting"},
                new Interest {Text = "Toy Collecting"},
                new Interest {Text = "Train Collecting"},
                new Interest {Text = "Train Spotting"},
                new Interest {Text = "Traveling"},
                new Interest {Text = "Treasure Hunting"},
                new Interest {Text = "Trekkie"},
                new Interest {Text = "Tutoring Children"},
                new Interest {Text = "TV watching"},
                new Interest {Text = "Ultimate Frisbee"},
                new Interest {Text = "Urban Exploration"},
                new Interest {Text = "Video Games"},
                new Interest {Text = "Violin"},
                new Interest {Text = "Volunteer"},
                new Interest {Text = "Walking"},
                new Interest {Text = "Warhammer"},
                new Interest {Text = "Watching sporting events"},
                new Interest {Text = "Weather Watcher"},
                new Interest {Text = "Weightlifting"},
                new Interest {Text = "Windsurfing"},
                new Interest {Text = "Wine Making"},
                new Interest {Text = "Wingsuit Flying"},
                new Interest {Text = "Woodworking"},
                new Interest {Text = "Working In A Food Pantry"},
                new Interest {Text = "Working on cars"},
                new Interest {Text = "World Record Breaking"},
                new Interest {Text = "Wrestling"},
                new Interest {Text = "Writing"},
                new Interest {Text = "Writing Music"},
                new Interest {Text = "Writing Songs"},
                new Interest {Text = "Yoga"},
                new Interest {Text = "YoYo"},
                new Interest {Text = "Ziplining"},
                new Interest {Text = "Zumba"}
            };
        }

        public static void AssociateAddressesWithPeople(List<Person> people, List<Address> addresses)
        {
            for (var i = 0; i <= addresses.Count - 1; i++)
            {
                addresses[i].People.Add(people[i]);
                people[i].HomeAddress = addresses[i];
            }
        }

        public static void AssociatePeopleWithInterests(List<Person> people, List<Interest> interests)
        {
            var rnd = new Random();

            foreach (var person in people)
            {
                var interestCount = rnd.Next(5, 20);
                for (var i = 0; i < interestCount; i++)
                {
                    var interestIndex = rnd.Next(0, interests.Count - 1);
                    person.Interests.Add(interests[interestIndex]);
                }
            }
        }
    }
}
