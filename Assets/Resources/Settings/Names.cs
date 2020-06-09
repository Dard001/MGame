using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Names
{
    public static string[] femaleNames = new string[]{"Abbi", "Abbie", "Abby", "Abi", "Abigail", "Ada", "Adele", "Aila", "Aileen", "Ailsa", "Aimee", "Alana", "Alex", "Alexandra", "Alexis", "Alice", "Alicia",  "Alisha", 
        "Alison",  "Allison",  "Alyssa",  "Amanda",  "Amber",  "Amelia",  "Amelie",  "Amy",  "Andrea",  "Angela",  "Ann",  "Anna",  "Anne",  "Aoife",  "Aria",  "Ariana",  "Arianna",  "Arlene",  "Arya",  "Ashleigh",  
        "Ashley",  "Audrey",  "Aurora",  "Ava",  "Ayla",  "Barbara",  "Bella",  "Beth",  "Bethany",  "Bonnie",  "Brooke",  "Caitlin",  "Caitlyn",  "Callie",  "Cara",  "Carla",  "Carly",  "Carol",  "Caroline",  "Carolyn",  
        "Carrie",  "Casey",  "Catherine",  "Catriona",  "Cerys",  "Chantelle",  "Charlene",  "Charley",  "Charlie",  "Charlotte",  "Chelsea",  "Cheryl",  "Chloe",  "Christina",  "Christine",  "Ciara",  "Claire",  "Clara", 
        "Clare",  "Cora",  "Courtney",  "Daisy",  "Danielle",  "Darcy",  "Dawn",  "Debbie",  "Deborah",  "Demi",  "Denise",  "Diane",  "Donna",  "Eden",  "Eilidh",  "Elaine",  "Eleanor",  "Elise",  "Elizabeth",  "Ella",  
        "Elle",  "Ellen",  "Ellie",  "Elsie",  "Emilia",  "Emily",  "Emma",  "Erin",  "Esme",  "Eva",  "Eve",  "Evelyn",  "Evie",  "Faith",  "Fiona",  "Florence",  "Frances",  "Freya",  "Gail",  "Gayle",  "Gemma",  
        "Georgia",  "Georgie",  "Gillian",  "Grace",  "Gracie",  "Hallie",  "Hanna",  "Hannah",  "Harley",  "Harper",  "Hayley",  "Hazel",  "Heather",  "Heidi",  "Helen",  "Hollie",  "Holly",  "Hope",  "Imogen",  "Iona",  
        "Isabella",  "Isla",  "Ivy",  "Jacqueline",  "Jade",  "Jane",  "Janet",  "Jasmine",  "Jemma",  "Jenna",  "Jennifer",  "Jessica",  "Jill",  "Jillian",  "Joanna",  "Joanne",  "Jodie",  "Jordan",  "Judith",  "Julia",  
        "Julie",  "Kaitlin",  "Kaitlyn",  "Kara",  "Karen",  "Kate",  "Katherine",  "Kathleen",  "Kathryn",  "Katie",  "Katrina",  "Kayla",  "Kayleigh",  "Keira",  "Kelly",  "Kelsey",  "Kerri",  "Kerry",  "Kiera",  "Kim",  
        "Kimberley",  "Kimberly",  "Kirsteen",  "Kirsten",  "Kirstie",  "Kirsty",  "Kylie",  "Lacey",  "Laila",  "Lara",  "Laura",  "Lauren",  "Lauryn",  "Layla",  "Leah",  "Leanne",  "Lee",  "Leigh",  "Lena",  "Lesley",  
        "Lexi",  "Lexie",  "Libby",  "Lillie",  "Lilly",  "Lily",  "Linda",  "Lindsay",  "Lindsey",  "Linsey",  "Linzi",  "Lisa",  "Lois",  "Lola",  "Lorna",  "Lorraine",  "Lottie",  "Louise",  "Lucie",  "Lucy",  "Luna",  
        "Lyla",  "Lyndsay",  "Lyndsey",  "Lynn",  "Lynne",  "Lynsey",  "Madison",  "Maisie",  "Mandy",  "Margaret",  "Maria",  "Marie",  "Marion",  "Mary",  "Matilda",  "Maureen",  "Maya",  "Megan",  "Meghan",  "Melanie",  
        "Melissa",  "Mhairi",  "Mia",  "Michaela",  "Michelle",  "Mila",  "Miley",  "Millie",  "Mirren",  "Mollie",  "Molly",  "Morag",  "Morgan",  "Morven",  "Mya",  "Myla",  "Naomi",  "Natalie",  "Natasha",  "Neve",  
        "Niamh",  "Nicola",  "Nicole",  "Nicolle",  "Nieve",  "Nikki",  "Nina",  "Nova",  "Olivia",  "Orla",  "Paige",  "Pamela",  "Patricia",  "Paula",  "Pauline",  "Penelope",  "Phoebe",  "Piper",  "Poppy",  "Quinn",  
        "Rachael",  "Rachel",  "Rebecca",  "Rebekah",  "Rhiannon",  "Robyn",  "Rose",  "Rosie",  "Rowan",  "Ruby",  "Ruth",  "Sadie",  "Samantha",  "Sandra",  "Sara",  "Sarah",  "Scarlett",  "Shannon",  "Sharon",  "Shelley",  
        "Shirley",  "Shona",  "Sienna",  "Sinead",  "Siobhan",  "Skye",  "Sofia",  "Sophia",  "Sophie",  "Stacey",  "Stacy",  "Stephanie",  "Summer",  "Susan",  "Suzanne",  "Taylor",  "Thea",  "Toni",  "Tracey",  "Tracy",  
        "Valerie",  "Vicky",  "Victoria",  "Violet",  "Wendy",  "Willow",  "Yvonne",  "Zara",  "Zoe"
    };

    public static string[] maleNames = new string[] { "Aaron",  "Adam",  "Adrian",  "Aidan",  "Aiden",  "Alan",  "Alasdair",  "Alastair",  "Alex",  "Alexander",  "Alfie",  "Alistair",  "Allan",  "Andrew",  "Angus",  "Anthony",  
        "Antony",  "Archie",  "Arlo",  "Arran",  "Arthur",  "Bailey",  "Barrie",  "Barry",  "Ben",  "Benjamin",  "Blair",  "Blake",  "Bradley",  "Brandon",  "Brian",  "Brodie",  "Brody",  "Bruce",  "Bryan",  "Caleb",  "Callan",  
        "Callum",  "Calum",  "Calvin",  "Cameron",  "Campbell",  "Carson",  "Carter",  "Charles",  "Charlie",  "Christopher",  "Ciaran",  "Cody",  "Cole",  "Colin",  "Conner",  "Connor",  "Conor",  "Cooper",  "Corey",  "Craig", 
        "Dale",  "Daniel",  "Darren",  "Daryl",  "David",  "Dean",  "Declan",  "Derek",  "Dominic",  "Donald",  "Douglas",  "Duncan",  "Dylan",  "Edward",  "Elijah",  "Elliot",  "Ellis",  "Eric",  "Ethan",  "Euan",  "Evan",  
        "Ewan",  "Finlay",  "Finn",  "Francis",  "Frank",  "Frankie",  "Fraser",  "Freddie",  "Gabriel",  "Gareth",  "Garry",  "Gary",  "Gavin",  "George",  "Gerald",  "Gerard",  "Gordon",  "Graeme",  "Graham",  "Grant",  
        "Grayson",  "Greg",  "Gregor",  "Greig",  "Hamish",  "Harris",  "Harrison",  "Harry",  "Harvey",  "Hayden",  "Henry",  "Hugh",  "Hunter",  "Iain",  "Ian",  "Innes",  "Isaac",  "Jack",  "Jackson",  "Jacob",  "Jake",  
        "James",  "Jamie",  "Jason",  "Jax",  "Jaxon",  "Jay",  "Jayden",  "Joe",  "John",  "Jon",  "Jonathan",  "Jordan",  "Joseph",  "Josh",  "Joshua",  "Jude",  "Justin",  "Kai",  "Kaiden",  "Kayden",  "Keir",  "Keiran",  
        "Keith",  "Kenneth",  "Kenzie",  "Kevin",  "Kian",  "Kieran",  "Kris",  "Kristopher",  "Kyle",  "Lachlan",  "Lee",  "Lennon",  "Leo",  "Leon",  "Lewis",  "Liam",  "Logan",  "Louie",  "Louis",  "Luca",  "Lucas",  
        "Luke",  "Lyle",  "Mackenzie",  "Malcolm",  "Marc",  "Marcus",  "Mark",  "Martin",  "Martyn",  "Mason",  "Matthew",  "Max",  "Michael",  "Mitchell",  "Mohammed",  "Morgan",  "Muhammad",  "Murray",  "Nathan",  "Neil",  
        "Niall",  "Nicholas",  "Noah",  "Norman",  "Oliver",  "Ollie",  "Olly",  "Oscar",  "Owen",  "Patrick",  "Paul",  "Peter",  "Philip",  "Raymond",  "Reece",  "Reuben",  "Rhys",  "Richard",  "Riley",  "Robbie",  "Robert",  
        "Robin",  "Roderick",  "Ronald",  "Ronan",  "Rory",  "Ross",  "Roy",  "Ruairidh",  "Ruaridh",  "Russell",  "Ryan",  "Sam",  "Samuel",  "Scott",  "Sean",  "Shaun",  "Shay",  "Simon",  "Sonny",  "Stephen",  "Steven",  
        "Stewart",  "Struan",  "Stuart",  "Taylor",  "Theo",  "Theodore",  "Thomas",  "Timothy",  "Tommy",  "Tyler",  "Wayne",  "Wesley",  "William",  "Zac",  "Zachary",  "Zak"
 };

    public static string[] surnames = new string[] { "SMITH", "JOHNSON", "WILLIAMS", "BROWN", "JONES", "GARCIA", "RODRIGUEZ", "MILLER", "MARTINEZ", "DAVIS", "HERNANDEZ", "LOPEZ", "GONZALEZ", "WILSON", "ANDERSON", "THOMAS", 
        "TAYLOR", "LEE", "MOORE", "JACKSON", "PEREZ", "MARTIN", "THOMPSON", "WHITE", "SANCHEZ", "HARRIS", "RAMIREZ", "CLARK", "LEWIS", "ROBINSON", "WALKER", "YOUNG", "HALL", "ALLEN", "TORRES", "NGUYEN", "WRIGHT", "FLORES", 
        "KING", "SCOTT", "RIVERA", "GREEN", "HILL", "ADAMS", "BAKER", "NELSON", "MITCHELL", "CAMPBELL", "GOMEZ", "CARTER", "ROBERTS", "DIAZ", "PHILLIPS", "EVANS", "TURNER", "REYES", "CRUZ", "PARKER", "EDWARDS", "COLLINS", 
        "STEWART", "MORRIS", "MORALES", "ORTIZ", "GUTIERREZ", "MURPHY", "ROGERS", "COOK", "KIM", "MORGAN", "COOPER", "RAMOS", "PETERSON", "GONZALES", "BELL", "REED", "BAILEY", "CHAVEZ", "KELLY", "HOWARD", "RICHARDSON", 
        "WARD", "COX", "RUIZ", "BROOKS", "WATSON", "WOOD", "JAMES", "MENDOZA", "GRAY", "BENNETT", "ALVAREZ", "CASTILLO", "PRICE", "HUGHES", "VASQUEZ", "SANDERS", "JIMENEZ", "LONG", "FOSTER" };

    public static string GetMaleFirstName() {
        UnityEngine.Random r = new UnityEngine.Random();

        return maleNames[UnityEngine.Random.Range(0, maleNames.Length - 1)];
    }

    public static string GetFemaleFirstName() {
        UnityEngine.Random r = new UnityEngine.Random();

        return femaleNames[UnityEngine.Random.Range(0, femaleNames.Length - 1)];
    }

    public static string GetSurname() {
        UnityEngine.Random r = new UnityEngine.Random();

        return surnames[UnityEngine.Random.Range(0, surnames.Length - 1)];
    }
}
