namespace car_agency.Repository
{
    public static class CarMappings
    {
        public static readonly Dictionary<string, int> BrandMapping = new()
    {
        { "hyundi", 0 },
        { "volkswagen", 1 },
        { "BMW", 2 },
        { "skoda", 3 },
        { "ford", 4 },
        { "toyota", 5 },
        { "mercedes-benz", 6 },
        { "vauxhall", 7 },
        { "Audi", 8 }
    };

        public static readonly Dictionary<string, Dictionary<string, int>> ModelMapping = new()
{
    { "hyundi", new()
        {
            { "I10", 0 },
            { "Tucson", 1 },
            { "IX20", 2 },
            { "Santa Fe", 3 },
            { "I30", 4 },
            { "Ioniq", 5 },
            { "I20", 6 },
            { "I800", 7 },
            { "Kona", 8 },
            { "IX35", 9 },
            { "I40", 10 },
            { "Getz", 11 },
            { "Veloster", 12 },
            { "Terracan", 13 },
            { "Amica", 14 },
            { "Accent", 15 }
        }
    },
    { "volkswagen", new()
        {
            { "Polo", 0 },
            { "Tiguan", 1 },
            { "Up", 2 },
            { "Golf", 3 },
            { "T-Cross", 4 },
            { "Shuttle", 5 },
            { "Golf SV", 6 },
            { "Passat", 7 },
            { "Tiguan Allspace", 8 },
            { "Arteon", 9 },
            { "T-Roc", 10 },
            { "Scirocco", 11 },
            { "Touareg", 12 },
            { "Touran", 13 },
            { "Caravelle", 14 },
            { "CC", 15 },
            { "Eos", 16 },
            { "Amarok", 17 },
            { "Beetle", 18 },
            { "California", 19 },
            { "Sharan", 20 },
            { "Fox", 21 },
            { "Caddy Maxi Life", 22 },
            { "Caddy Maxi", 23 },
            { "Jetta", 24 },
            { "Caddy Life", 25 },
            { "Caddy", 26 }
        }
    },
    { "BMW", new()
        {
            { "2 Series", 0 },
            { "1 Series", 1 },
            { "X4", 2 },
            { "3 Series", 3 },
            { "X5", 4 },
            { "X1", 5 },
            { "4 Series", 6 },
            { "5 Series", 7 },
            { "8 Series", 8 },
            { "X2", 9 },
            { "X3", 10 },
            { "7 Series", 11 },
            { "6 Series", 12 },
            { "i3", 13 },
            { "X7", 14 },
            { "M4", 15 },
            { "X6", 16 },
            { "i8", 17 },
            { "Z4", 18 },
            { "M3", 19 },
            { "M5", 20 },
            { "M6", 21 },
            { "M2", 22 },
            { "Z3", 23 }
        }
    },
    { "skoda", new()
        {
            { "Yeti Outdoor", 0 },
            { "Karoq", 1 },
            { "Scala", 2 },
            { "Kodiaq", 3 },
            { "Citigo", 4 },
            { "Octavia", 5 },
            { "Fabia", 6 },
            { "Yeti", 7 },
            { "Superb", 8 },
            { "Kamiq", 9 },
            { "Rapid", 10 },
            { "Roomster", 11 }
        }
    },
    { "ford", new()
        {
            { "Fiesta", 0 },
            { "Kuga", 1 },
            { "Mondeo", 2 },
            { "Focus", 3 },
            { "B-MAX", 4 },
            { "C-MAX", 5 },
            { "EcoSport", 6 },
            { "Ka+", 7 },
            { "Tourneo Connect", 8 },
            { "Edge", 9 },
            { "S-MAX", 10 },
            { "Grand C-MAX", 11 },
            { "KA", 12 },
            { "Galaxy", 13 },
            { "Grand Tourneo Connect", 14 },
            { "Puma", 15 },
            { "Mustang", 16 },
            { "Fusion", 17 },
            { "Tourneo Custom", 18 },
            { "Ranger", 19 },
            { "Streetka", 20 },
            { "Escort", 21 },
            { "Transit Tourneo", 22 }
        }
    },
    { "toyota", new()
        {
            { "C-HR", 0 },
            { "RAV4", 1 },
            { "Aygo", 2 },
            { "Auris", 3 },
            { "Yaris", 4 },
            { "Verso", 5 },
            { "Corolla", 6 },
            { "GT86", 7 },
            { "Hilux", 8 },
            { "Avensis", 9 },
            { "Land Cruiser", 10 },
            { "Supra", 11 },
            { "Prius", 12 },
            { "Urban Cruiser", 13 },
            { "Verso-S", 14 },
            { "IQ", 15 },
            { "PROACE VERSO", 16 },
            { "Camry", 17 }
        }
    },
    { "mercedes-benz", new()
        {
            { "A Class", 0 },
            { "GLA Class", 1 },
            { "C Class", 2 },
            { "GLC Class", 3 },
            { "SL CLASS", 4 },
            { "E Class", 5 },
            { "B Class", 6 },
            { "GLE Class", 7 },
            { "GLS Class", 8 },
            { "S Class", 9 },
            { "SLK", 10 },
            { "CL Class", 11 },
            { "CLA Class", 12 },
            { "V Class", 13 },
            { "CLS Class", 14 },
            { "M Class", 15 },
            { "GL Class", 16 },
            { "GLB Class", 17 },
            { "X-CLASS", 18 },
            { "CLK", 19 },
            { "R Class", 20 },
            { "G Class", 21 },
            { "180", 22 },
            { "200", 23 },
            { "CLC Class", 24 },
            { "230", 25 },
            { "220", 26 }
        }
    },
    { "vauxhall", new()
        {
            { "Corsa", 0 },
            { "Viva", 1 },
            { "Astra", 2 },
            { "Insignia", 3 },
            { "Zafira", 4 },
            { "Mokka X", 5 },
            { "Antara", 6 },
            { "Mokka", 7 },
            { "Adam", 8 },
            { "Grandland X", 9 },
            { "Meriva", 10 },
            { "Crossland X", 11 },
            { "Combo Life", 12 },
            { "GTC", 13 },
            { "Cascada", 14 },
            { "Vivaro", 15 },
            { "Kadjar", 16 },
            { "Tigra", 17 },
            { "Agila", 18 },
            { "Zafira Tourer", 19 },
            { "Vectra", 20 },
            { "Ampera", 21 }
        }
    },
    { "Audi", new()
        {
            { "Q5", 0 },
            { "A4", 1 },
            { "Q3", 2 },
            { "A3", 3 },
            { "A5", 4 },
            { "A6", 5 },
            { "Q7", 6 },
            { "A1", 7 },
            { "TT", 8 },
            { "Q2", 9 },
            { "SQ5", 10 },
            { "A7", 11 },
            { "SQ7", 12 },
            { "RS3", 13 },
            { "RS5", 14 },
            { "A8", 15 },
            { "Q8", 16 },
            { "S4", 17 },
            { "RS4", 18 },
            { "RS6", 19 },
            { "R8", 20 },
            { "S5", 21 },
            { "S3", 22 },
            { "S8", 23 },
            { "A2", 24 },
            { "RS7", 25 }
        }
    }
};

        public static readonly Dictionary<string, int> TransMapping = new()
        {
        { "Manual", 0 },
        { "Semi-Auto", 1 },
        { "Automatic", 2 }
        
        };
        public static readonly Dictionary<string, int> FuelMapping = new()
        {
        { "Petrol", 0 },
        { "Diesel", 1 },
        { "Hybrid", 2 },
        {"Electric",3 }

        };
    }
}
