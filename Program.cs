using Microsoft.Data.SqlClient;
using System;
using System.Text.RegularExpressions;

namespace FinalTP
{
    class AAAAAAAAAAAAAAAAAAA
    {
        public static void Main(string[] args)
        {
            bool lup = true;
            while (lup)
            {
                Console.Clear();
                Console.WriteLine("----------------------------------> DANSE MACABRE <----------------------------");
                Console.WriteLine("[1] New Game");
                Console.WriteLine("[2] Load Game");
                Console.WriteLine("[3] Campaign Mode");
                Console.WriteLine("[4] Credits");
                Console.WriteLine("[5] Exit");
                Console.Write("Choice: ");
                string MenuDecision = Console.ReadLine();

                if (byte.TryParse(MenuDecision, out byte menuDecision))
                {
                    switch (menuDecision)
                    {
                        case 1:
                            NewGame();
                            break;

                        case 2:
                            LoadGame();
                            break;

                        case 3:
                            CampaignMode();
                            break;

                        case 4:
                            Credits();
                            break;

                        case 5:
                            Console.WriteLine("\nExiting System....");
                            Environment.Exit(0);
                            break;
                    }
                }
            }
        }
        public static void NewGame()
        {
            Console.WriteLine("\n-----------------------------------> New Game <--------------------------------");
            PlayerCharacter cc = new PlayerCharacter(""); ///Polymorphism  
            cc.SetCharName();
            cc.SetGender();
            cc.SetArchetype();
            cc.SetPhysicalBuild();
            cc.SetEyeColor();
            cc.SetHairStyle();
            cc.SetHairColor();
            cc.SetFaceStructure();
            cc.SetSkinColor();
            cc.SetFacialHair();
            cc.SetScar();
            cc.SetTattoo();
            cc.SetPiercing();
            cc.SetFleekEyebrows();
            cc.SetAccessory();
            cc.SetStats();
            cc.SetHoroscope();
            cc.SetCompanion();
            cc.QuirkMenu();
            cc.SetQuirk1();
            cc.SetQuirk2();
            cc.SetQuirk3();
            cc.SetAbiliy();
            cc.SetStartingItem();
            cc.SetMap();
            cc.DisplaySummary();

            bool lup = true;
            while (lup)
            {
                Console.WriteLine("\n-----------------------------> Return to Main Menu? <-------------------------");
                Console.WriteLine("[1] Yes.");
                Console.WriteLine("[2] No.");
                Console.Write("Choice: ");

                if (byte.TryParse(Console.ReadLine(), out byte returnChoice))
                {
                    switch (returnChoice)
                    {
                        case 1:
                            lup = false;
                            break;

                        case 2:
                            lup = false;
                            Console.WriteLine("\nExiting System....");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid input. Select an option from the menu.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Enter a number between 1 and 2.");
                }
            }
        }
        public static void LoadGame()
        {
            SqlConnection SQLTable;
            string DatabaseThingy = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=C:\USERS\WGMSO\SOURCE\REPOS\FINALTPV3\FINALTPV3\CHARACTER_INFO.MDF;Integrated Security=True;";
            SQLTable = new SqlConnection(DatabaseThingy);
            SQLTable.Open();

            bool lup = true;
            while (lup)
            {
                Console.WriteLine("\n----------------------------------> Load Game <-------------------------------");
                Console.WriteLine("[1] View all saved characters.");
                Console.WriteLine("[2] Delete a character.");
                Console.WriteLine("[3] Back to Main Menu.");
                Console.Write("Choice: ");

                if (byte.TryParse(Console.ReadLine(), out byte loadChoice))
                {
                    switch (loadChoice)
                    {
                        case 1:
                            string countQueryString = "SELECT COUNT(*) FROM dbo.CHARACTER_INFO";
                            SqlCommand countDataPLz = new SqlCommand(countQueryString, SQLTable);

                            int exists = (int)countDataPLz.ExecuteScalar();

                            if (exists == 0)
                            {
                                Console.WriteLine("No characters found. Create a new one.");
                                break;
                            }

                            Console.WriteLine("\nList of Saved Characters:\n");

                            Console.WriteLine("==============================================================================\n");

                            string selectQueryString = @"
                                SELECT 
                                    user_Charname, user_Gender, user_Archetype, user_Phys, user_EyeColor, 
                                    user_HairColor, user_HairStyle, user_SkinColor, user_FaceStructure, user_FacialHair, 
                                    user_Scar, user_Tattoo, user_Piercing, user_EyebrowsonFleek, user_Assertive, 
                                    user_Foresight, user_Health, user_Leadership, user_Luck, user_Nimble, user_Nocturnal, 
                                    user_Persuasion, user_Sadness, user_Toughness, user_Quirk1, user_Quirk2, user_Quirk3, 
                                    user_Ability, user_Horoscope, user_Accessories, user_Companion, user_StartingItem, user_MapSettings
                                FROM dbo.CHARACTER_INFO";

                            SqlCommand selectDataPLz = new SqlCommand(selectQueryString, SQLTable);

                            using (SqlDataReader reead = selectDataPLz.ExecuteReader())
                            {
                                int nameIndex = 1;
                                while (reead.Read())
                                {
                                    Console.WriteLine($"CHARACTER #{nameIndex}");
                                    Console.WriteLine($"Name: {reead["user_Charname"]}");
                                    Console.WriteLine($"Gender: {reead["user_Gender"]}");
                                    Console.WriteLine($"Archetype: {reead["user_Archetype"]}");
                                    Console.WriteLine($"Build: {reead["user_Phys"]}");
                                    Console.WriteLine($"Eye Color: {reead["user_EyeColor"]}");
                                    Console.WriteLine($"Hair Color: {reead["user_HairColor"]}");
                                    Console.WriteLine($"Hair Style: {reead["user_HairStyle"]}");
                                    Console.WriteLine($"Skin Color: {reead["user_SkinColor"]}");
                                    Console.WriteLine($"Face Structure: {reead["user_FaceStructure"]}");
                                    Console.WriteLine($"Facial Hair: {reead["user_FacialHair"]}");
                                    Console.WriteLine($"Scar: {reead["user_Scar"]}");
                                    Console.WriteLine($"Tattoo: {reead["user_Tattoo"]}");
                                    Console.WriteLine($"Piercing: {reead["user_Piercing"]}");
                                    Console.WriteLine($"Eyebrows: {reead["user_EyebrowsonFleek"]}");
                                    Console.WriteLine($"Assertive: {reead["user_Assertive"]}");
                                    Console.WriteLine($"Foresight: {reead["user_Foresight"]}");
                                    Console.WriteLine($"Health: {reead["user_Health"]}");
                                    Console.WriteLine($"Leadership: {reead["user_Leadership"]}");
                                    Console.WriteLine($"Luck: {reead["user_Luck"]}");
                                    Console.WriteLine($"Nimble: {reead["user_Nimble"]}");
                                    Console.WriteLine($"Nocturnal: {reead["user_Nocturnal"]}");
                                    Console.WriteLine($"Persuasion: {reead["user_Persuasion"]}");
                                    Console.WriteLine($"Sadness: {reead["user_Sadness"]}");
                                    Console.WriteLine($"Toughness: {reead["user_Toughness"]}");
                                    Console.WriteLine($"Quirk 1: {reead["user_Quirk1"]}");
                                    Console.WriteLine($"Quirk 2: {reead["user_Quirk2"]}");
                                    Console.WriteLine($"Quirk 3: {reead["user_Quirk3"]}");
                                    Console.WriteLine($"Ability: {reead["user_Ability"]}");
                                    Console.WriteLine($"Horoscope: {reead["user_Horoscope"]}");
                                    Console.WriteLine($"Accessories: {reead["user_Accessories"]}");
                                    Console.WriteLine($"Companion: {reead["user_Companion"]}");
                                    Console.WriteLine($"Starting Item: {reead["user_StartingItem"]}");
                                    Console.WriteLine($"Map Setting: {reead["user_MapSettings"]}");
                                    Console.WriteLine("\n==============================================================================\n");
                                    nameIndex++;
                                }
                            }
                            break;

                        case 2:

                            countQueryString = "SELECT COUNT(*) FROM dbo.CHARACTER_INFO";
                            countDataPLz = new SqlCommand(countQueryString, SQLTable);

                            exists = (int)countDataPLz.ExecuteScalar();

                            if (exists == 0)
                            {
                                Console.WriteLine("No characters found.");
                                break;
                            }

                            Console.WriteLine("\nList of Saved Characters:");

                            selectQueryString = "SELECT user_Charname FROM dbo.CHARACTER_INFO";
                            selectDataPLz = new SqlCommand(selectQueryString, SQLTable);

                            using (SqlDataReader reead = selectDataPLz.ExecuteReader())
                            {
                                int nameIndex = 1;
                                while (reead.Read())
                                {
                                    string name = reead.GetValue(0).ToString();
                                    Console.WriteLine($"[{nameIndex}] {name}");
                                    nameIndex++;
                                }
                            } 

                            bool ikot = true;

                            while (ikot)
                            {
                                Console.Write("\nType the EXACT NAME of the character you want to delete: ");
                                string dedChar = Console.ReadLine();

                                if (string.IsNullOrWhiteSpace(dedChar))
                                {
                                    Console.WriteLine("Input cannot be empty or a whitespace. Try Again.");
                                    continue;
                                }
                                else
                                {
                                    try
                                    {
                                        string checkQueryString = "SELECT * FROM dbo.CHARACTER_INFO WHERE user_Charname = @Charname";
                                        SqlCommand checkDataPLz = new SqlCommand(checkQueryString, SQLTable);
                                        checkDataPLz.Parameters.AddWithValue("@Charname", dedChar);
                                        SqlDataReader reead = selectDataPLz.ExecuteReader();

                                        if (reead.HasRows)
                                        {
                                            reead.Close();
                                            string deleteQueryString = "DELETE FROM dbo.CHARACTER_INFO WHERE user_Charname = @Charname";
                                            SqlCommand deleteDataPLz = new SqlCommand(deleteQueryString, SQLTable);
                                            deleteDataPLz.Parameters.AddWithValue("@Charname", dedChar);

                                            int rows = deleteDataPLz.ExecuteNonQuery();

                                            if (rows > 0)
                                            {
                                                Console.WriteLine("\nCHARACTER SUCCESSFULLY DELETED!");
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid Input. Type in the proper character name.");
                                                continue;
                                            }
                                        }
                                    }
                                    catch (ArgumentException e)
                                    {
                                        Console.WriteLine($"Error: {e.Message}");
                                    }
                                }
                            }
                            break;
                        case 3:
                            lup = false;
                            break;
                        default:
                            Console.WriteLine("Invalid input. Select an option from the menu.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Enter a number between 1 and 3.");
                }
            } SQLTable.Close();
        }
        public static void CampaignMode()
        {
            Console.WriteLine("\n--------------------------------> Campaign Mode <-----------------------------");
            string[] campaign = {
                "Ang lungsod ng Failee Pines ay nasa liblib na lugar malayo",
                "sa kabihasnan, tila sila ay nasa gitna ng malawak na forest.",
                "Gayunpaman, they still managed to become a somewhat thriving",
                "community. Mayro’ng mall, school, at farm for the Failee",
                "Pines people at asylum para sa mga baliw. Isang araw, habang",
                "nagkakaon ang mga tao sa isang kantina, nagalit ang isang",
                "misteryosong person na naka - hoodie, “Bakit ang tamis ng sinigang?!”",
                "Agad itong tumayo at sinumpaan ang lugar ng Failee Pines. Dumilim,",
                "lumakas ang hangin at na - reveal ang mysterious person, s’ya ay",
                "si Sir Lorenz, isang salamangkero living in a secluded place",
                "called Sangandaan. Limang malakas na kidlat ang tumama sa siyudad.",
                "Simula ng pangyayaring ito, maraming kababalaghan ang nangyayari",
                "tulad na lamang ng mga missing persons disappearing without a trace,",
                "unidentified flying objects, daks na footprints, at marami pang iba.",
                "Dahil dito, the city gained attention and it became popular, and marami",
                "ang curious about the happenings in the city. The government of Failee",
                "Pines took advantage of this as they knew one way or another, they have",
                "to find a way to get rid of the spreading kababalaghan.",
                "",
                "Sino mang makaka - defeat sa whatever darkness looming in the corners",
                "of the siyudad, ay bibigyan ng malaking kwarta. Who doesn’t want big",
                "money kapalit ng kanilang sanity ?! Kaya naman, marami ang na - enganyo na",
                "tahakin ang trabahong ito.Gayunpaman, marami pa rin ang skeptical because",
                "puro segunda manong information lang ang kanilang nakukuha. Kaya mapa - believer",
                "or skeptic ay lumalahok sa Oplan Sindak. Siyempre, before partaking in",
                "the mission, the volunteers must sign a contract, stating that whatever",
                "happens to them, is their fault.",
                "",
                "Apparently, ang limang kidlat na tumama sa lungsod ng Failee Pines ay",
                "siyang pinagmumulan ng mga kababalaghan. Ngunit may isang lugar kung saan...",
                "Kapag nasimulan na ang misyon ay bawal na mag - bail. Ang kanilang will",
                "mabuhay ay siyang magtatakda kung kaya nilang sugpuin ang anumang",
                "kababalaghan na kanilang madadatnan. Ang mahina ay siyang agad mamamatay,",
                "ngunit ang magpupursigi ay maaaring mas lumakas pa. Nasa sa kanila kung",
                "anong klaseng skill na meron sila ang kanilang pauunlarin upang malampasan",
                "ang anumang pagsubok na dadaan sa kanilang way. Ang kanilang kapalaran ay",
                "nasa kanilang palad, they must conquer the darkness or they will be",
                "consumed by it."
                        };

            foreach (string story in campaign)
            {
                Console.WriteLine(story);
            }

            bool lup = true;

            while (lup)
            {
                Console.WriteLine("\n-----------------------------> Return to Main Menu? <-------------------------");
                Console.WriteLine("[1] Yes.");
                Console.WriteLine("[2] No.");
                Console.Write("Choice: ");

                if (byte.TryParse(Console.ReadLine(), out byte returnChoice))
                {
                    switch (returnChoice)
                    {
                        case 1:
                            lup = false;
                            break;
                        case 2:
                            lup = false;
                            Console.WriteLine("\nExiting System....");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid input. Select an option from the menu.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Enter a number between 1 and 2.");
                }
            }
        }

        public static void Credits()
        {
            Console.WriteLine("\n------------------------------------> Credits <--------------------------------");
            string[] credits = {
                        "SORIANO, WYONA GWEN | PROGRAMMERIST",
                        "The mother of this group. She keeps us on track for our project, guides",
                        "us like how a real mother would. She is the main source of our strength",
                        "and knowledge. More importantly, she is the main programmerist.",
                        "",
                        "CALIGAGAN, PAUL JADEN | PANCIT CANTON (programmerist on the side)",
                        "He who housed us and fed us and will continue to do so in the future",
                        "He who proclaimed himself as the Pancit Canton yet insists on helping",
                        "on the coding part of the project. In short, he excels n BS Pancit Canton,",
                        "Major in Programming. ",
                        "",
                        "YANGA, MARIEL | DOCUMENTATIONIST",
                        "Became a documentationist because she really had no other choice. Her main",
                        "task is to understand the code at the very least and do the typing and ",
                        "visualizing and daydreaming. She would gladly try to help with the coding",
                        "but the smartest move would be to not let her. But she tries her best to",
                        "become a valuableasset to the team."
                    };
            foreach (string creds in credits)
            {
                Console.WriteLine(creds);
            }

            bool lup = true;

            while (lup)
            {
                Console.WriteLine("\n-----------------------------> Return to Main Menu? <-------------------------");
                Console.WriteLine("[1] Yes.");
                Console.WriteLine("[2] No.");
                Console.Write("Choice: ");

                if (byte.TryParse(Console.ReadLine(), out byte returnChoice))
                {
                    switch (returnChoice)
                    {
                        case 1:
                            lup = false;
                            break;

                        case 2:
                            lup = false;
                            Console.WriteLine("\nExiting System....");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid input. Select an option from the menu.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Enter a number between 1 and 2.");
                }
            }
        }
    }

    public interface IValidation ///interface - all classes must have validation
    { ///overloading
        bool ValidateInput(string input);
        bool ValidateInput(byte input);
    }

    public abstract class Character ///abstract class
    {
        ///encapsulation. may automatic private backing field galing sa c# compiler so no need for "private string CharName;"
        public string CharName { get; set; }
        public string Gender { get; set; }
        public string PhysicalBuild { get; set; }
        public string EyeColor { get; set; }
        public string HairColor { get; set; }
        public string HairStyle { get; set; }
        public string FaceStructure { get; set; }
        public string SkinColor { get; set; }
        public string Accessories { get; set; }
        public bool FacialHair { get; set; }
        public bool Scar { get; set; }
        public bool Tattoo { get; set; }
        public bool Piercing { get; set; }
        public bool EyebrowsOnFleek { get; set; }

        ///Structures
        public struct Stats
        {
            public byte Assertive { get; set; }
            public byte Foresight { get; set; }
            public byte Health { get; set; }
            public byte Leadership { get; set; }
            public byte Luck { get; set; }
            public byte Nimble { get; set; }
            public byte Nocturnal { get; set; }
            public byte Persuasion { get; set; }
            public byte Sadness { get; set; }
            public byte Toughness { get; set; }
        }


        ///Constructor, this. keyword
        public Character(string charName)
        {
            this.CharName = charName;
        }

        ///Abstract method, overriding
        public abstract void DisplaySummary();
    }
    public class PlayerCharacter : Character, IValidation ///Inheritance
    {
        ///Encapsulation
        public string Archetype { get; set; }
        public string Horoscope { get; set; }
        public string Quirk1 { get; set; }
        public string Quirk2 { get; set; }
        public string Quirk3 { get; set; }
        public string Ability { get; set; }
        public string Companion { get; set; }
        public string StartingItem { get; set; }
        public string MapSettings { get; set; }
        //public Stats CharacterStats { get; set; } prob discard

        ///Constructor
        public PlayerCharacter(string name) : base(name) { }

        public bool ValidateInput(string input)///overloading
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        public bool ValidateInput(byte input)
        {
            return input >= 0 && input <= 8;
        }

        ///method for features
        public void SetCharName()
        {
            SqlConnection SQLTable;
            string DatabaseThingy = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=C:\USERS\WGMSO\SOURCE\REPOS\FINALTPV3\FINALTPV3\CHARACTER_INFO.MDF;Integrated Security=True;";

            using (SQLTable = new SqlConnection(DatabaseThingy))
            {
                SQLTable.Open();

                while (true)
                {

                    try ///Exceptions
                    {

                        Console.Write("Name of your Character: ");
                        string userInput = Console.ReadLine();

                        if (!ValidateInput(userInput))
                        {
                            throw new ArgumentException("Character name cannot be empty or be a whitespace. Try again.");
                        }

                        if (userInput.Length < 4 || userInput.Length > 10)
                        {
                            throw new ArgumentException("Character name must be between 4 and 10 characters. Try again.");
                        }

                        Regex regex = new Regex(@"^[\w\W]{4,10}$");
                        if (!regex.IsMatch(userInput))
                        {
                            throw new ArgumentException("Character name contains invalid characters. Try again.");
                        }

                        string[] offensiveWords = { "fuck", "shit", "dick", "hitler", "bitch", "whore" };
                        if (offensiveWords.Any(userInput.Contains))
                        {
                            throw new ArgumentException("Character name contains offensive language. Try again.");
                        }

                        string checkQueryString = "SELECT * FROM dbo.CHARACTER_INFO WHERE user_Charname = @Charname";
                        SqlCommand checkDataPLz = new SqlCommand(checkQueryString, SQLTable);
                        checkDataPLz.Parameters.AddWithValue("@Charname", userInput);

                        object result = checkDataPLz.ExecuteScalar();

                        int count = Convert.ToInt32(result);

                        if (count > 0)
                        {
                            Console.WriteLine("Character name already taken! Try again.\n");
                        }
                        else
                        {
                            CharName = userInput;
                            return;
                        }
                    }

                    catch (ArgumentException e)
                    {
                        Console.WriteLine($"Error: {e.Message}");
                    }
                }
            }
        } 

        public void SetGender()
        {
            Console.WriteLine($"\nGender of {CharName}: \n");
            Console.WriteLine("a. Male");
            Console.WriteLine("b. Female");
            Console.WriteLine("c. Non-Binary");
            Console.WriteLine("d. Prefer not to say");

            while (true)
            {
                try
                {
                    Console.Write("Choice: ");
                    string readGender = Console.ReadLine().ToLower();

                    if (!ValidateInput(readGender))
                    {
                        throw new ArgumentException("Gender cannot be empty or be a whitespace. Try again.");
                    }
                    else
                    {
                        switch (readGender)
                        {
                            case "a": Gender = "Male"; return;
                            case "b": Gender = "Female"; return;
                            case "c": Gender = "Non-Binary"; return;
                            case "d": Gender = "Prefer not to say"; return;
                            default:
                                throw new ArgumentException("Invalid input. Kindly select within the options");
                        }
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public void SetArchetype()
        {
            Console.WriteLine("\nWhat would be your chosen Archetype?: \n");
            Console.WriteLine("a. Normal Citizen");
            Console.WriteLine("--> An ordinary person caught up in extraordinary," +
                                   "\n    most times unfortunate, events.");
            Console.WriteLine("b. Student");
            Console.WriteLine("--> Young and curious, eager to learn but" +
                                   "\n    sometimes overly trusting.");
            Console.WriteLine("c. Paranormal Investigator");
            Console.WriteLine("--> A skeptic turned believer, armed with tools to" +
                                   "\n    unravel the secrets of the supernatural.");
            Console.WriteLine("d. Santa Claus"); ;
            Console.WriteLine("--> Ho! Ho! Ho!");
            Console.WriteLine("e. Police");
            Console.WriteLine("--> Enforcer of order, against the unknown" +
                                   "\n    however, the law means nothing.");

            while (true)
            {
                try
                {
                    Console.Write("Choice: ");
                    string readArch = Console.ReadLine().ToLower();

                    if (!ValidateInput(readArch))
                    {
                        throw new ArgumentException("Archetype cannot be empty or be a whitespace. Try again.");
                    }
                    else
                    {
                        switch (readArch)
                        {
                            case "a": Archetype = "Normal Citizen"; return;
                            case "b": Archetype = "Student"; return;
                            case "c": Archetype = "Paranormal Investigator"; return;
                            case "d": Archetype = "Santa Claus"; return;
                            case "e": Archetype = "Police"; return;
                            default:
                                throw new ArgumentException("Invalid input. Kindly select within the options");
                        }
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public void SetPhysicalBuild()
        {
            Console.WriteLine($"\nChoose your Character's Physical Build: \n");
            Console.WriteLine("a. Slim");
            Console.WriteLine("b. Average");
            Console.WriteLine("c. Athletic");
            Console.WriteLine("d. Muscular");
            Console.WriteLine("e. Petite");

            while (true)
            {
                try
                {
                    Console.Write("Choice: ");
                    string readPhys = Console.ReadLine().ToLower();

                    if (!ValidateInput(readPhys))
                    {
                        throw new ArgumentException("Physical Build cannot be empty or be a whitespace. Try again.");
                    }
                    else
                    {
                        switch (readPhys)
                        {
                            case "a": PhysicalBuild = "Slim"; return;
                            case "b": PhysicalBuild = "Average"; return;
                            case "c": PhysicalBuild = "Athletic"; return;
                            case "d": PhysicalBuild = "Muscular"; return;
                            case "e": PhysicalBuild = "Petite"; return;
                            default:
                                throw new ArgumentException("Invalid input. Kindly select within the options");
                        }
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public void SetEyeColor()
        {
            Console.WriteLine($"\nWhat would be your Eye Color?: \n");
            Console.WriteLine("a. Black");
            Console.WriteLine("b. Brown");
            Console.WriteLine("c. Blue");
            Console.WriteLine("d. Green");
            Console.WriteLine("e. Red");
            Console.WriteLine("f. Yellow");
            Console.WriteLine("g. Orange");
            Console.WriteLine("h. Pink");
            Console.WriteLine("i. Violet");

            while (true)
            {
                try
                {
                    Console.Write("Choice: ");
                    string readEC = Console.ReadLine().ToLower();

                    if (!ValidateInput(readEC))
                    {
                        throw new ArgumentException("Eye Color cannot be empty or be a whitespace. Try again.");
                    }
                    else
                    {
                        switch (readEC)
                        {
                            case "a": EyeColor = "Black"; return;
                            case "b": EyeColor = "Brown"; return;
                            case "c": EyeColor = "Blue"; return;
                            case "d": EyeColor = "Green"; return;
                            case "e": EyeColor = "Red"; return;
                            case "f": EyeColor = "Yellow"; return;
                            case "g": EyeColor = "Orange"; return;
                            case "h": EyeColor = "Pink"; return;
                            case "i": EyeColor = "Violet"; return;
                            default:
                                throw new ArgumentException("Invalid input. Kindly select within the options");
                        }
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public void SetHairStyle()
        {
            Console.WriteLine($"\nWhat would be your Hair Style?: \n");
            Console.WriteLine("a. Burst Fade");
            Console.WriteLine("b. Taper Fade");
            Console.WriteLine("c. Bob Cut");
            Console.WriteLine("d. Pony Tail");
            Console.WriteLine("e. Bald");
            Console.WriteLine("f. Undercut");
            Console.WriteLine("g. Shaggy");
            Console.WriteLine("h. Braids");
            Console.WriteLine("i. Mohawk");
            Console.WriteLine("j. Pixie Cut");
            Console.WriteLine("k. Dreadlocks");

            while (true)
            {
                try
                {
                    Console.Write("Choice: ");
                    string readHS = Console.ReadLine().ToLower();

                    if (!ValidateInput(readHS))
                    {
                        throw new ArgumentException("Hair Style cannot be empty or be a whitespace. Try again.");
                    }
                    else
                    {
                        switch (readHS)
                        {
                            case "a": HairStyle = "Burst Fade"; return;
                            case "b": HairStyle = "Taper Fade"; return;
                            case "c": HairStyle = "Bob Cut"; return;
                            case "d": HairStyle = "Pony Tail"; return;
                            case "e": HairStyle = "Bald"; return;
                            case "f": HairStyle = "Undercut"; return;
                            case "g": HairStyle = "Shaggy"; return;
                            case "h": HairStyle = "Braids"; return;
                            case "i": HairStyle = "Mohawk"; return;
                            case "j": HairStyle = "Pixie Cut"; return;
                            case "k": HairStyle = "Dreadlocks"; return;
                            default:
                                throw new ArgumentException("Invalid input. Kindly select within the options");
                        }
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public void SetHairColor()
        {
            Console.WriteLine($"\nWhat would be your Hair Color?: \n");
            Console.WriteLine("a. Black");
            Console.WriteLine("b. Brown");
            Console.WriteLine("c. Blue");
            Console.WriteLine("d. Green");
            Console.WriteLine("e. Red");
            Console.WriteLine("f. Yellow");
            Console.WriteLine("g. Orange");
            Console.WriteLine("h. Pink");
            Console.WriteLine("i. Violet");

            while (true)
            {
                try
                {
                    Console.Write("Choice: ");
                    string readHC = Console.ReadLine().ToLower();

                    if (!ValidateInput(readHC))
                    {
                        throw new ArgumentException("Hair Color cannot be empty or be a whitespace. Try again.");
                    }
                    else
                    {
                        switch (readHC)
                        {
                            case "a": HairColor = "Black"; return;
                            case "b": HairColor = "Brown"; return;
                            case "c": HairColor = "Blue"; return;
                            case "d": HairColor = "Green"; return;
                            case "e": HairColor = "Red"; return;
                            case "f": HairColor = "Yellow"; return;
                            case "g": HairColor = "Orange"; return;
                            case "h": HairColor = "Pink"; return;
                            case "i": HairColor = "Violet"; return;
                            default:
                                throw new ArgumentException("Invalid input. Kindly select within the options");
                        }
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public void SetFaceStructure()
        {
            Console.WriteLine($"\nWhat would be your Face Structure?: \n");
            Console.WriteLine("a. Oval");
            Console.WriteLine("b. Square");
            Console.WriteLine("c. Diamond");
            Console.WriteLine("d. Long");
            Console.WriteLine("e. Gaunt");
            Console.WriteLine("f. Chiseled");

            while (true)
            {
                try
                {
                    Console.Write("Choice: ");
                    string readFS = Console.ReadLine().ToLower();

                    if (!ValidateInput(readFS))
                    {
                        throw new ArgumentException("Face Structure cannot be empty or be a whitespace. Try again.");
                    }
                    else
                    {
                        switch (readFS)
                        {
                            case "a": FaceStructure = "Oval"; return;
                            case "b": FaceStructure = "Square"; return;
                            case "c": FaceStructure = "Diamond"; return;
                            case "d": FaceStructure = "Long"; return;
                            case "e": FaceStructure = "Gaunt"; return;
                            case "f": FaceStructure = "Chiseled"; return;
                            default:
                                throw new ArgumentException("Invalid input. Kindly select within the options");
                        }
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public void SetSkinColor()
        {
            Console.WriteLine($"\nWhat would be your Skin Color?: \n");
            Console.WriteLine("a. Blue");
            Console.WriteLine("b. Black");
            Console.WriteLine("c. White");
            Console.WriteLine("d. Green");
            Console.WriteLine("e. Pink");
            Console.WriteLine("f. Beige");
            Console.WriteLine("g. Brown");

            while (true)
            {
                try
                {
                    Console.Write("Choice: ");
                    string readSC = Console.ReadLine().ToLower();

                    if (!ValidateInput(readSC))
                    {
                        throw new ArgumentException("Skin Color cannot be empty or be a whitespace. Try again.");
                    }
                    else
                    {
                        switch (readSC)
                        {
                            case "a": SkinColor = "Blue"; return;
                            case "b": SkinColor = "Black"; return;
                            case "c": SkinColor = "WHite"; return;
                            case "d": SkinColor = "Green"; return;
                            case "e": SkinColor = "Pink"; return;
                            case "f": SkinColor = "Beige"; return;
                            case "g": SkinColor = "Brown"; return;
                            default:
                                throw new ArgumentException("Invalid input. Kindly select within the options");
                        }
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public void SetFacialHair()
        {
            Console.WriteLine($"\nAdd Facial hair?: \n");
            Console.WriteLine("a. Yes");
            Console.WriteLine("b. No");

            while (true)
            {
                try
                {
                    Console.Write("Choice: ");
                    string readFacialHair = Console.ReadLine().ToLower();

                    if (!ValidateInput(readFacialHair))
                    {
                        throw new ArgumentException("Question cannot be empty or be a whitespace. Try again.");
                    }
                    else
                    {
                        switch (readFacialHair)
                        {
                            case "a": FacialHair = true; return;
                            case "b": FacialHair = false; return;
                            default:
                                throw new ArgumentException("Invalid input. Kindly select within the options");
                        }
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public void SetScar()
        {
            Console.WriteLine($"\nAdd Scar?: \n");
            Console.WriteLine("a. Yes");
            Console.WriteLine("b. No");

            while (true)
            {
                try
                {
                    Console.Write("Choice: ");
                    string readScar = Console.ReadLine().ToLower();

                    if (!ValidateInput(readScar))
                    {
                        throw new ArgumentException("Question cannot be empty or be a whitespace. Try again.");
                    }
                    else
                    {
                        switch (readScar)
                        {
                            case "a": Scar = true; return;
                            case "b": Scar = false; return;
                            default:
                                throw new ArgumentException("Invalid input. Kindly select within the options");
                        }
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }
        public void SetTattoo()
        {
            Console.WriteLine($"\nAdd Tattoo?: \n");
            Console.WriteLine("a. Yes");
            Console.WriteLine("b. No");

            while (true)
            {
                try
                {
                    Console.Write("Choice: ");
                    string readTattoo = Console.ReadLine().ToLower();

                    if (!ValidateInput(readTattoo))
                    {
                        throw new ArgumentException("Question cannot be empty or be a whitespace. Try again.");
                    }
                    else
                    {
                        switch (readTattoo)
                        {
                            case "a": Tattoo = true; return;
                            case "b": Tattoo = false; return;
                            default:
                                throw new ArgumentException("Invalid input. Kindly select within the options");
                        }
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public void SetPiercing()
        {
            Console.WriteLine($"\nAdd Piercing?: \n");
            Console.WriteLine("a. Yes");
            Console.WriteLine("b. No");

            while (true)
            {
                try
                {
                    Console.Write("Choice: ");
                    string readPiercing = Console.ReadLine().ToLower();

                    if (!ValidateInput(readPiercing))
                    {
                        throw new ArgumentException("Question cannot be empty or be a whitespace. Try again.");
                    }
                    else
                    {
                        switch (readPiercing)
                        {
                            case "a": Piercing = true; return;
                            case "b": Piercing = false; return;
                            default:
                                throw new ArgumentException("Invalid input. Kindly select within the options");
                        }
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public void SetFleekEyebrows()
        {
            Console.WriteLine($"\nAre your eyebrows on FLEEK?: \n");
            Console.WriteLine("a. Yes");
            Console.WriteLine("b. No");

            while (true)
            {
                try
                {
                    Console.Write("Choice: ");
                    string readFleek = Console.ReadLine().ToLower();

                    if (!ValidateInput(readFleek))
                    {
                        throw new ArgumentException("Question cannot be empty or be a whitespace. Try again.");
                    }
                    else
                    {
                        switch (readFleek)
                        {
                            case "a": EyebrowsOnFleek = true; return;
                            case "b": EyebrowsOnFleek = false; return;
                            default:
                                throw new ArgumentException("Invalid input. Kindly select within the options");
                        }
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public void SetAccessory()
        {
            Console.WriteLine($"\nChoose your Accessories: \n");
            Console.WriteLine("a. Watch");
            Console.WriteLine("b. Ring");
            Console.WriteLine("c. Hat");
            Console.WriteLine("d. Eyeglasses");
            Console.WriteLine("e. Bandana");
            Console.WriteLine("f. Fedora");

            while (true)
            {
                try
                {
                    Console.Write("Choice: ");
                    string readAccs = Console.ReadLine().ToLower();

                    if (!ValidateInput(readAccs))
                    {
                        throw new ArgumentException("Accessories cannot be empty or be a whitespace. Try again.");
                    }
                    else
                    {
                        switch (readAccs)
                        {
                            case "a": Accessories = "Watch"; return;
                            case "b": Accessories = "Ring"; return;
                            case "c": Accessories = "Hat"; return;
                            case "d": Accessories = "Eyeglasses"; return;
                            case "e": Accessories = "Bandana"; return;
                            case "f": Accessories = "Fedora"; return;
                            default:
                                throw new ArgumentException("Invalid input. Kindly select within the options");
                        }
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        ///Stats hard to handle
        Stats CharacterStats = new Stats();
        public void SetStats()
        {
            Console.WriteLine("\nTime to Allocate your Stats! You have 30 points to assign across all stats, " +
                              "with a maximum of 8 points per stat.");

            Console.WriteLine("\nStat Options: ");
            Console.WriteLine("Assertive – Confidence to confront terrifying threats.");
            Console.WriteLine("Foresight – Spot dangers before they strike.");
            Console.WriteLine("Health – Stamina to endure injuries and fear.");
            Console.WriteLine("Leadership – Rally allies in the face of terror.");
            Console.WriteLine("Luck – Survive by sheer chance when all seems lost.");
            Console.WriteLine("Nimble – Quick reflexes to evade danger.");
            Console.WriteLine("Nocturnal – Excel in dark, eerie environments.");
            Console.WriteLine("Persuasion – Convince others to follow your lead.");
            Console.WriteLine("Sadness – Deep sorrow, strengthening resolve in despair.");
            Console.WriteLine("Toughness – Resist physical harm and psychological torment.");

            byte maxPts = 8;
            byte totalPts = 30;
            byte natirangPts = totalPts;

            string[] statNames = { "Assertive", "Foresight", "Health", "Leadership", "Luck", "Nimble", "Nocturnal", "Persuasion", "Sadness", "Toughness" };

            foreach (var stat in statNames)
            {
                Console.WriteLine($"\n(Max {maxPts} points per stat, {natirangPts} points remaining)");

                while (true)
                {
                    try
                    {
                        Console.Write($"{stat}: ");
                        string input = Console.ReadLine();

                        if (byte.TryParse(input, out byte pts) && pts <= maxPts && pts <= natirangPts)
                        {

                            switch (stat)
                            {
                                case "Assertive": CharacterStats.Assertive = pts; break;
                                case "Foresight": CharacterStats.Foresight = pts; break;
                                case "Health": CharacterStats.Health = pts; break;
                                case "Leadership": CharacterStats.Leadership = pts; break;
                                case "Luck": CharacterStats.Luck = pts; break;
                                case "Nimble": CharacterStats.Nimble = pts; break;
                                case "Nocturnal": CharacterStats.Nocturnal = pts; break;
                                case "Persuasion": CharacterStats.Persuasion = pts; break;
                                case "Sadness": CharacterStats.Sadness = pts; break;
                                case "Toughness": CharacterStats.Toughness = pts; break;
                            }
                            natirangPts -= pts;
                            break;
                        }
                        else
                        {
                            throw new ArgumentException($"Invalid points. You have {natirangPts} points remaining.");
                        }
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine($"Error: {e.Message}");
                    }
                }

                if (natirangPts == 0)
                {
                    Console.WriteLine("\nNo more points remaining.Stat allocation complete!");
                    break;
                }
            }
        }


        public void SetHoroscope()
        {
            Console.WriteLine("\nHere are your given Horoscopes.... ");
            Console.WriteLine("This may determine your survivability. Choose wisely.");
            Console.WriteLine("a. Turtle");
            Console.WriteLine("--> Steady and cautious, your resilience shields you" +
                                   "\n    from unseen dangers–but defenses don’t always last.");
            Console.WriteLine("b. Cat");
            Console.WriteLine("--> Possesses both grace and agility, luck favors your" +
                                   "\n    curiosity–yet beware of hidden dangers.");
            Console.WriteLine("c. Owl");
            Console.WriteLine("--> Your observant eyes never miss, though some sights" +
                                   "\n    can be utterly terrifying.");
            Console.WriteLine("d. Helicopter"); ;
            Console.WriteLine("--> Soars above challenges and seldom stops, your quick" +
                                   "\n    responses may avoid demise’s reach–or lead to doom.");
            Console.WriteLine("e.Diamond");
            Console.WriteLine("--> A vessel of endurance and clarity, strength enhances" +
                                   "\n    your survival, but envy attracts threats.");
            Console.WriteLine("f. Quill");
            Console.WriteLine("--> A weapon of words, articulate and introspective. Your mind crafts" +
                                   "\n    paths to security–but overthinking leads to hesitation.");
            Console.WriteLine("g. Syringe");
            Console.WriteLine("--> A symbol of both pain and renewal, feared by many–" +
                                   "\n    but you can be easily conquered.");
            Console.WriteLine("h. Pointing Finger");
            Console.WriteLine("--> Direct and assertive, you spot truths and lies–but not always.");
            Console.WriteLine("i. Bat");
            Console.WriteLine("--> Mysterious and nocturnal, darkness is your friend–though" +
                                   "\n    unseen predators also lurk within.");
            Console.WriteLine("j. Watch");
            Console.WriteLine("--> Time-bound and punctual, every second matters to you–" +
                                   "\n    but time is unpredictable, even for the most precise.");

            while (true)
            {
                try
                {
                    Console.Write("Choice: ");
                    string readHoro = Console.ReadLine().ToLower();

                    if (!ValidateInput(readHoro))
                    {
                        throw new ArgumentException("Horoscopes cannot be empty or be a whitespace. Try again.");
                    }
                    else
                    {
                        switch (readHoro)
                        {
                            case "a": Horoscope = "Turtle"; CharacterStats.Toughness += 7; return;
                            case "b": Horoscope = "Cat"; CharacterStats.Nimble += 5; return;
                            case "c": Horoscope = "Owl"; CharacterStats.Foresight += 5; return;
                            case "d": Horoscope = "Helicopter"; CharacterStats.Leadership += 5; return;
                            case "e": Horoscope = "Diamond"; CharacterStats.Luck += 3; return;
                            case "f": Horoscope = "Quill"; CharacterStats.Persuasion += 5; return;
                            case "g": Horoscope = "Syringe"; CharacterStats.Health += 10; return;
                            case "h": Horoscope = "Pointing Finger"; CharacterStats.Assertive += 2; return;
                            case "i": Horoscope = "Bat"; CharacterStats.Nocturnal += 2; return;
                            case "j": Horoscope = "Watch"; CharacterStats.Sadness += 5; return;
                            default:
                                throw new ArgumentException("Invalid input. Kindly select within the options");
                        }
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public void SetCompanion()
        {
            Console.WriteLine($"\nWhat would be your Companion?: ");
            Console.WriteLine("a. Dog");
            Console.WriteLine("b. Cat");
            Console.WriteLine("c. Worm");
            Console.WriteLine("d. Pickle in a Jar");
            Console.WriteLine("e. 8 Ball");

            while (true)
            {
                try
                {
                    Console.Write("Choice: ");
                    string readComp = Console.ReadLine().ToLower();

                    if (!ValidateInput(readComp))
                    {
                        throw new ArgumentException("Companion cannot be empty or be a whitespace. Try again.");
                    }
                    else
                    {
                        switch (readComp)
                        {
                            case "a": Companion = "Dog"; return;
                            case "b": Companion = "Cat"; return;
                            case "c": Companion = "Worm"; return;
                            case "d": Companion = "Pickle in a jar"; return;
                            case "e": Companion = "8 ball"; return;
                            default:
                                throw new ArgumentException("Invalid input. Kindly select within the options");
                        }
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public void QuirkMenu()
        {
            Console.WriteLine("\nHere are your given Quirks.... ");
            Console.WriteLine("This will determine your survivability. Choose three (3).");
            Console.WriteLine("a. Analytical");
            Console.WriteLine("--> Quickly assesses situations and weaknesses," +
                                   "\n    but overthinks in critical moments.");
            Console.WriteLine("b. Clumsy");
            Console.WriteLine("--> Trips, drops things, or accidentally causes" +
                                   "\n    mishaps due to lack of coordination.");
            Console.WriteLine("c. Kleptomaniac");
            Console.WriteLine("--> Has an irresistible urge to steal things," +
                                   "\n    even if they don't need them.");
            Console.WriteLine("d. Leader"); ;
            Console.WriteLine("--> Takes charge in crisis, sometimes to the group's peril." +
                                   "\n    Will make others feel trust in you.");
            Console.WriteLine("e. Empath");
            Console.WriteLine("--> Feels others' emotions deeply, risking their own sanity.");
            Console.WriteLine("f. Impulsive");
            Console.WriteLine("--> Acts without thinking, often making reckless decisions.");
            Console.WriteLine("g. Brave");
            Console.WriteLine("--> Faces terrifying situations head-on, often leading others into danger.");
            Console.WriteLine("h. Curious");
            Console.WriteLine("--> Can't resist investigating the unknown, even if it’s deadly.");
            Console.WriteLine("i. Crafty");
            Console.WriteLine("--> Creates makeshift tools or traps, using whatever’s at hand.");
            Console.WriteLine("j. Loud");
            Console.WriteLine("--> Unaware of how loudly they move or speak, alerting threats.");
        }

        private string chosenQuirk1;
        private string chosenQuirk2; 

        public void SetQuirk1() 
        {
            while (true)
            {
                try
                {
                    Console.Write("Choice 1: ");
                    string readQuirk1 = Console.ReadLine().ToLower();

                    if (!ValidateInput(readQuirk1))
                    {
                        throw new ArgumentException("Quirk cannot be empty or be a whitespace. Try again.");
                    }
                    else
                    {
                        switch (readQuirk1)
                        {
                            case "a": Quirk1 = "Analytical"; chosenQuirk1 = "a"; return;
                            case "b": Quirk1 = "Clumsy"; chosenQuirk1 = "b"; return;
                            case "c": Quirk1 = "Kleptomaniac"; chosenQuirk1 = "c"; return;
                            case "d": Quirk1 = "Leader"; chosenQuirk1 = "d"; return;
                            case "e": Quirk1 = "Empath"; chosenQuirk1 = "e"; return;
                            case "f": Quirk1 = "Impulsive"; chosenQuirk1 = "f"; return;
                            case "g": Quirk1 = "Brave"; chosenQuirk1 = "g"; return;
                            case "h": Quirk1 = "Curious"; chosenQuirk1 = "h"; return;
                            case "i": Quirk1 = "Crafty"; chosenQuirk1 = "i"; return;
                            case "j": Quirk1 = "Loud"; chosenQuirk1 = "j"; return;
                            default:
                                throw new ArgumentException("Invalid input. Kindly select within the options");
                        }
                    } 
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                } 
            }
        }
  
        public void SetQuirk2()
        {
            while (true)
            {
                try
                {
                    Console.Write("Choice 2: ");
                    string readQuirk2 = Console.ReadLine().ToLower();

                    if (!ValidateInput(readQuirk2))
                    {
                        throw new ArgumentException("Quirk cannot be empty or be a whitespace. Try again.");
                    }

                    if (readQuirk2 == chosenQuirk1)
                    {
                        throw new ArgumentException("Quirk option already chosen! Pick another one.");
                    }
                    switch (readQuirk2)
                    {

                        case "a": Quirk2 = "Analytical"; chosenQuirk2 = "a"; return;
                        case "b": Quirk2 = "Clumsy"; chosenQuirk2 = "b"; return;
                        case "c": Quirk2 = "Kleptomaniac"; chosenQuirk2 = "c"; return;
                        case "d": Quirk2 = "Leader"; chosenQuirk2 = "d"; return;
                        case "e": Quirk2 = "Empath"; chosenQuirk2 = "e"; return;
                        case "f": Quirk2 = "Impulsive"; chosenQuirk2 = "f"; return;
                        case "g": Quirk2 = "Brave"; chosenQuirk2 = "g"; return;
                        case "h": Quirk2 = "Curious"; chosenQuirk2 = "h"; return;
                        case "i": Quirk2 = "Crafty"; chosenQuirk2 = "i"; return;
                        case "j": Quirk2 = "Loud"; chosenQuirk2 = "j"; return;
                        default:
                            throw new ArgumentException("Invalid input. Kindly select within the options");
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                } 
            } 
        }

        public void SetQuirk3()
        {
            while (true)
            {
                try
                {
                    Console.Write("Choice 3: ");
                    string readQuirk3 = Console.ReadLine().ToLower();

                    if (!ValidateInput(readQuirk3))
                    {
                        throw new ArgumentException("Quirk cannot be empty or be a whitespace. Try again.");
                    }

                    if (readQuirk3 == chosenQuirk1 || readQuirk3 == chosenQuirk2)
                    {
                        throw new ArgumentException("Quirk option already chosen! Pick another one.");
                    }

                    switch (readQuirk3)
                    {
                        case "a": Quirk3 = "Analytical"; return;
                        case "b": Quirk3 = "Clumsy"; return;
                        case "c": Quirk3 = "Kleptomaniac"; return;
                        case "d": Quirk3 = "Leader"; return;
                        case "e": Quirk3 = "Empath"; return;
                        case "f": Quirk3 = "Impulsive"; return;
                        case "g": Quirk3 = "Brave"; return;
                        case "h": Quirk3 = "Curious"; return;
                        case "i": Quirk3 = "Crafty"; return;
                        case "j": Quirk3 = "Loud"; return;
                        default:
                            throw new ArgumentException("Invalid input. Kindly select within the options");
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            } 
        }

        public void SetAbiliy()
        {
            Console.WriteLine("\nChoose one for an ability you can use. \n");
            Console.WriteLine("a. Burst of Speed ");
            Console.WriteLine("--> Sprint to escape enemies for a certain duration.");
            Console.WriteLine("b. Deafening Scream ");
            Console.WriteLine("--> Stuns enemies and alerts allies nearby.");
            Console.WriteLine("c. Revive Faster ");
            Console.WriteLine("--> Quicker ally revival .");
            Console.WriteLine("d. 10 Crafting Speed "); ;
            Console.WriteLine("--> Faster item crafting speed.");
            Console.WriteLine("e. See Items/Allies through Walls   ");
            Console.WriteLine("--> Easily locate resources and allies for a short duration.");

            while (true)
            {
                try
                {
                    Console.Write("Choice: ");
                    string readAbility = Console.ReadLine().ToLower();

                    if (!ValidateInput(readAbility))
                    {
                        throw new ArgumentException("Ability cannot be empty or be a whitespace. Try again.");
                    }
                    else
                    {
                        switch (readAbility)
                        {
                            case "a": Ability = "Burst of Speed"; return;
                            case "b": Ability = "Deafening Scream"; return;
                            case "c": Ability = "Revive Faster"; return;
                            case "d": Ability = "+10 Crafting Speed"; return;
                            case "e": Ability = "See Items/Allies through Walls"; return;
                            default:
                                throw new ArgumentException("Invalid input. Kindly select within the options");
                        }
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public void SetStartingItem()
        {
            Console.WriteLine($"\nWhat would be your Starting Item?: ");
            Console.WriteLine("a. Map");
            Console.WriteLine("b. Flashlight");
            Console.WriteLine("c. Medkit");
            Console.WriteLine("d. Knife");
            Console.WriteLine("e. Bat");
            Console.WriteLine("f. Chancla");
            Console.WriteLine("g. Toolbox");

            while (true)
            {
                try
                {
                    Console.Write("Choice: ");
                    string readStartingItem = Console.ReadLine().ToLower();

                    if (!ValidateInput(readStartingItem))
                    {
                        throw new ArgumentException("Starting Item cannot be empty or be a whitespace. Try again.");
                    }
                    else
                    {
                        switch (readStartingItem)
                        {
                            case "a": StartingItem = "Map"; return;
                            case "b": StartingItem = "Flashlight"; return;
                            case "c": StartingItem = "Medkit"; return;
                            case "d": StartingItem = "Knife"; return;
                            case "e": StartingItem = "Bat"; return;
                            case "f": StartingItem = "Chancla"; return;
                            case "g": StartingItem = "Toolbox"; return;
                            default:
                                throw new ArgumentException("Invalid input. Kindly select within the options");
                        }
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public void SetMap()
        {
            Console.WriteLine("\nHere are your choices for the map. ");
            Console.WriteLine("a. Forest");
            Console.WriteLine("--> A dark, dense wilderness full of twisting paths, eerie" +
                                   "\n    silence, and hidden dangers lurking among the trees.");
            Console.WriteLine("b. School");
            Console.WriteLine("--> A decaying, abandoned building with long hallways, classrooms, and an" +
                                   "\n    unsettling atmosphere, filled with whispers of forgotten horrors.");
            Console.WriteLine("c. Asylum");
            Console.WriteLine("--> A crumbling, labyrinthine institution where madness once reigned, " +
                                   "\n    now home to the echoes of tormented souls and unsettling noises.");
            Console.WriteLine("d. Cabin in the Woods"); ;
            Console.WriteLine("--> A remote, secluded cabin surrounded by dark woods, with an " +
                                   "\n    oppressive sense of isolation and secrets buried deep in the forest.");
            Console.WriteLine("e. Sir Lorenz' House");
            Console.WriteLine("--> A once-familiar family home now warped by dark forces, with shifting rooms, " +
                                   "\n    creaky floors, and a haunting presence that never leaves.");
            Console.WriteLine("f. Farm");
            Console.WriteLine("--> An overgrown, isolated farm with dilapidated barns, fields, and a sense of " +
                                   "\n    abandonment, where something sinister watches from the shadows.");

            while (true)
            {
                try
                {
                    Console.Write("Choice: ");
                    string readMap = Console.ReadLine().ToLower();

                    if (!ValidateInput(readMap))
                    {
                        throw new ArgumentException("Map cannot be empty or be a whitespace. Try again.");
                    }
                    else
                    {
                        switch (readMap)
                        {
                            case "a": MapSettings = "Forest"; return;
                            case "b": MapSettings = "School"; return;
                            case "c": MapSettings = "Asylum"; return;
                            case "d": MapSettings = "Cabin in the Woods"; return;
                            case "e": MapSettings = "Sir Lorenz' House"; return;
                            case "f": MapSettings = "Farm"; return;
                            default:
                                throw new ArgumentException("Invalid input. Kindly select within the options");
                        }
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        ///Method Overriding 
        public override void DisplaySummary()
        {
            SqlConnection SQLTable;
            string DatabaseThingy = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=C:\USERS\WGMSO\SOURCE\REPOS\FINALTPV3\FINALTPV3\CHARACTER_INFO.MDF;Integrated Security=True;";

            Console.WriteLine("\n-------------------------------> Character Summary <---------------------------");
            Console.WriteLine($"Character Name: {CharName}");
            Console.WriteLine($"Gender: {Gender}");
            Console.WriteLine($"Archetype: {Archetype}");
            Console.WriteLine($"Physical Build: {PhysicalBuild}");
            Console.WriteLine($"Eye Color: {EyeColor}");
            Console.WriteLine($"Hair Color: {HairColor}");
            Console.WriteLine($"Hair Style: {HairStyle}");
            Console.WriteLine($"Face Structure: {FaceStructure}");
            Console.WriteLine($"Skin Color: {SkinColor}");
            Console.WriteLine($"Facial Hair: {FacialHair}");
            Console.WriteLine($"Scar: {Scar}");
            Console.WriteLine($"Tattoo: {Tattoo}");
            Console.WriteLine($"Piercing: {Piercing}");
            Console.WriteLine($"Eyebrows on Fleek: {EyebrowsOnFleek}");
            Console.WriteLine("--------------------------------> Character Stats <----------------------------");
            Console.WriteLine($"Assertive: {CharacterStats.Assertive}");
            Console.WriteLine($"Foresight: {CharacterStats.Foresight}");
            Console.WriteLine($"Health: {CharacterStats.Health}");
            Console.WriteLine($"Leadership: {CharacterStats.Leadership}");
            Console.WriteLine($"Luck: {CharacterStats.Luck}");
            Console.WriteLine($"Nimble: {CharacterStats.Nimble}");
            Console.WriteLine($"Nocturnal: {CharacterStats.Nocturnal}");
            Console.WriteLine($"Persuasion: {CharacterStats.Persuasion}");
            Console.WriteLine($"Sadness: {CharacterStats.Sadness}");
            Console.WriteLine($"Toughness: {CharacterStats.Toughness}");
            Console.WriteLine("------------------------------> Quirks and Abilities <--------------------------");
            Console.WriteLine($"Quirk #1: {Quirk1}");
            Console.WriteLine($"Quirk #2: {Quirk2}");
            Console.WriteLine($"Quirk #3: {Quirk3}");
            Console.WriteLine($"Abilities: {Ability}");
            Console.WriteLine("-------------------------------> Additional Details <---------------------------");
            Console.WriteLine($"Horoscope: {Horoscope}");
            Console.WriteLine($"Accessories: {Accessories}");
            Console.WriteLine($"Companion: {Companion}");
            Console.WriteLine($"Starting Item: {StartingItem}");
            Console.WriteLine($"Map: {MapSettings}");

            MapSettings = MapSettings.Replace("'", "''");

            SQLTable = new SqlConnection(DatabaseThingy);
            SQLTable.Open();

            string insertQueryString = "INSERT INTO dbo.CHARACTER_INFO (user_Charname, user_Gender, user_Archetype, user_Phys, user_EyeColor, user_HairColor, user_HairStyle, user_FaceStructure, user_SkinColor, user_FacialHair, user_Scar, user_Tattoo, user_Piercing, user_EyebrowsonFleek, user_Assertive, user_Foresight, user_Health, user_Leadership, user_Luck, user_Nimble, user_Nocturnal, user_Persuasion, user_Sadness, user_Toughness, user_Quirk1, user_Quirk2, user_Quirk3, user_Ability, user_Horoscope, user_Accessories, user_Companion, user_StartingItem, user_MapSettings) VALUES('" + CharName + "','" + Gender + "','" + Archetype + "','" + PhysicalBuild + "','" + EyeColor + "','" + HairColor + "','" + HairStyle + "','" + FaceStructure + "','" + SkinColor + "','" + FacialHair + "','" + Scar + "','" + Tattoo + "','" + Piercing + "','" + EyebrowsOnFleek + "','" + CharacterStats.Assertive + "','" + CharacterStats.Foresight + "','" + CharacterStats.Health + "','" + CharacterStats.Leadership + "','" + CharacterStats.Luck + "','" + CharacterStats.Nimble + "','" + CharacterStats.Nocturnal + "','" + CharacterStats.Persuasion + "','" + CharacterStats.Sadness + "','" + CharacterStats.Toughness + "','" + Quirk1 + "','" + Quirk2 + "','" + Quirk3 + "','" + Ability + "','" + Horoscope + "','" + Accessories + "','" + Companion + "','" + StartingItem + "','" + MapSettings + "')";
            SqlCommand insertDataPLz = new SqlCommand(insertQueryString, SQLTable);
            insertDataPLz.ExecuteNonQuery(); // ("polly);

            Console.WriteLine("\nCHARACTER DATA STORED SUCCESSFULLY!");
        }

    }
}