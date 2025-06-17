
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;

namespace FSR3ModSetupUtilityEnhanced.ViewModel
{
    public partial class HomeViewModel : ObservableObject
    {
       
        private readonly DispatcherTimer _clockTimer;
        private readonly DispatcherTimer _wallpaperTimer;
        private readonly List<string> _wallpaperPaths = []; 
        private int _currentWallpaperIndex = -1;
        [ObservableProperty]
        private string? _currentTime;

        [ObservableProperty]
        private string? _currentDate;

        [ObservableProperty]
        private string? _currentDayOfWeek;
        [ObservableProperty]
        private string? _selectedGame;

        [ObservableProperty]
        private string? _selectedFsrVersion;

        [ObservableProperty]
        private bool _isFsrSelectorVisible;

        [ObservableProperty]
        private string? _backgroundImage;

        public ObservableCollection<string> Games { get; }
        public ObservableCollection<string> FsrVersions { get; }
        public HomeViewModel()
        {
            Games =
            [
                "Select a Game...",
                "A Plague Tale Requiem",
                "A Quiet Place: The Road Ahead",
                "Achilles Legends Untold",
                "Alan Wake Remastered",
                "Alan Wake 2",
                "Alone in the Dark",
                "Assassin's Creed Mirage",
                "Assassin's Creed Shadows",
                "Assassin's Creed Valhalla",
                "Assetto Corsa Evo",
                "Atomic Heart",
                "AVOWED",
                "Back 4 Blood",
                "Banishers: Ghosts of New Eden",
                "Black Myth: Wukong",
                "Blacktail",
                "Baldur's Gate 3",
                "Bright Memory",
                "Bright Memory Infinite",
                "Brothers: A Tale of Two Sons Remake",
                "Chernobylite",
                "Chernobylite 2: Exclusion Zone",
                "Choo-Choo Charles",
                "Chorus",
                "Clair Obscur: Expedition 33",
                "Cities: Skylines 2",
                "Cod Black Ops Cold War",
                "Cod MW3",
                "Control",
                "Crime Boss: Rockay City",
                "Crysis Remastered",
                "Cyberpunk 2077",
                "Dakar Desert Rally",
                "Dead Island 2",
                "Dead Rising Remaster",
                "Dead Space (2023)",
                "Death Stranding",
                "Deathloop",
                "Deliver Us Mars",
                "Deliver Us The Moon",
                "Dragon Age: Veilguard",
                "Dragons Dogma 2",
                "Dying Light 2",
                "Dynasty Warriors: Origins",
                "Elden Ring",
                "Empire of the Ants",
                "Everspace 2",
                "Evil West",
                "Eternal Strands",
                "F1 2022",
                "F1 2023",
                "Final Fantasy VII Rebirth",
                "Final Fantasy XVI",
                "Five Nights at Freddy’s: Security Breach",
                "FIST: Forged In Shadow Torch",
                "Flintlock: The Siege Of Dawn",
                "Fobia – St. Dinfna Hotel",
                "Fort Solis",
                "Forza Horizon 5",
                "Frostpunk 2",
                "Ghostrunner 2",
                "Ghostwire: Tokyo",
                "Ghost of Tsushima",
                "God Of War ",
                "God of War Ragnarök",
                "Gotham Knights",
                "GreedFall II: The Dying World",
                "GTA Trilogy",
                "Grand Theft Auto V",
                "Hellblade: Senua's Sacrifice",
                "High On Life",
                "Hitman 3",
                "Horizon Forbidden West",
                "Horizon Zero Dawn\\Remastered",
                "Hogwarts Legacy",
                "Hot Wheels Unleashed",
                "Icarus",
                "Indiana Jones and the Great Circle",
                "Judgment",
                "Jusant",
                "Kingdom Come: Deliverance 2",
                "Kena: Bridge of Spirits",
                "Layers of Fear",
                "Lies of P",
                "Like a Dragon: Pirate Yakuza in Hawaii",
                "Lego Horizon Adventures",
                "Lords of the Fallen",
                "Loopmancer",
                "Lost Records Bloom And Rage",
                "Manor Lords",
                "Martha Is Dead",
                "Marvel's Avengers",
                "Marvel's Guardians of the Galaxy",
                "Marvel's Spider-Man Miles Morales",
                "Marvel's Spider-Man Remastered",
                "Marvel's Spider-Man 2",
                "Marvel's Midnight Suns",
                "Metro Exodus Enhanced Edition",
                "Microsoft Flight Simulator 24",
                "MOTO GP 24",
                "Monster Hunter Rise",
                "Monster Hunter Wilds",
                "Mortal Shell",
                "Nightingale",
                "Ninja Gaiden 2 Black",
                "Nobody Wants To Die",
                "Orcs Must Die! Deathtrap",
                "Outpost: Infinity Siege",
                "Pacific Drive",
                "Palworld",
                "Path of Exile II",
                "Ratchet & Clank - Rift Apart",
                "Ready or Not",
                "Red Dead Redemption",
                "Red Dead Redemption 2",
                "Remnant II",
                "Resident Evil 4",
                "Returnal",
                "Ripout",
                "RoboCop: Rogue City",
                "Saints Row",
                "Sackboy: A Big Adventure",
                "Satisfactory",
                "Scorn",
                "Sengoku Dynasty",
                "Senua's Saga Hellblade II",
                "Shadow Warrior 3",
                "Shadow of the Tomb Raider",
                "Sifu",
                "Silent Hill 2",
                "Six Days in Fallujah",
                "Smalland",
                "Soulslinger Envoy of Death",
                "Soulstice",
                "South of Midnight",
                "Stalker 2",
                "Star Wars: Jedi Survivor",
                "Star Wars Outlaws",
                "Steelrising",
                "STARFIELD",
                "Suicide Squad: Kill the Justice League",
                "TEKKEN 8",
                "Test Drive Unlimited Solar Crown",
                "The Ascent",
                "The Callisto Protocol",
                "The Chant",
                "The Elder Scrolls IV: Oblivion Remastered",
                "The Casting Of Frank Stone",
                "The First Berserker: Khazan",
                "The Invincible",
                "The Last Of Us Part I",
                "The Last of Us Part II",
                "The Medium",
                "The Outer Worlds: Spacer's Choice Edition",
                "The Outlast Trials",
                "The Talos Principle 2",
                "The Thaumaturge",
                "The Witcher 3",
                "Thymesia",
                "Uncharted Legacy of Thieves Collection",
                "Unknown 9: Awakening",
                "Until Dawn",
                "Wanted: Dead",
                "Warhammer: Space Marine 2",
                "Watch Dogs Legion",
                "Way Of The Hunter",
                "Wayfinder",
                "WILD HEARTS",
            ];
            FsrVersions = new ObservableCollection<string> { "SDK", "2.0", "2.1", "2.2", "RDR2" };

            _clockTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
            _clockTimer.Tick += (s, e) => UpdateTimeAndDate();
            _clockTimer.Start();
            UpdateTimeAndDate();
            InitializeWallpapers();
            _wallpaperTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
            _wallpaperTimer.Tick += RotateWallpaper;
            SelectedGame = Games.First();
        }

        private void UpdateTimeAndDate()
        {
            DateTime now = DateTime.Now;
            CurrentTime = now.ToString("HH:mm:ss");
            CurrentDayOfWeek = now.ToString("dddd");
            CurrentDate = now.ToString("MMMM dd, yyyy");
        }

        private void InitializeWallpapers()
        {
            _wallpaperPaths.Clear();
            string? assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            var supportedExtensions = new[] { ".jpg", ".png", ".jpeg", ".bmp" };

            foreach (var gameName in Games.Where(g => g != "Select a Game..."))
            {
                foreach (var ext in supportedExtensions)
                {
                    var uriString = $"pack://application:,,,/{assemblyName};component/Images/Wallpaper/{gameName}{ext}";
                    var resourceUri = new Uri(uriString, UriKind.Absolute);

                    try
                    {
                        var streamInfo = Application.GetResourceStream(resourceUri);
                        if (streamInfo != null)
                        {
                            _wallpaperPaths.Add(uriString);
                            streamInfo.Stream.Close(); 
                            break; 
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }

        private void RotateWallpaper(object? sender, EventArgs e)
        {
            if (_wallpaperPaths.Count == 0)
            {
                BackgroundImage = null; 
                return;
            }

            _currentWallpaperIndex = (_currentWallpaperIndex + 1) % _wallpaperPaths.Count;
            BackgroundImage = _wallpaperPaths[_currentWallpaperIndex];
        }

        private void UpdateBackgroundBasedOnSelection(string? selectedGameName)
        {
            if (string.IsNullOrEmpty(selectedGameName) || selectedGameName == "Select a Game...")
            {
               
                _wallpaperTimer.Start();
                RotateWallpaper(null, EventArgs.Empty);
            }
            else
            {
                _wallpaperTimer.Stop();
                var foundWallpaper = _wallpaperPaths.FirstOrDefault(path =>
                    path.Contains($"/{selectedGameName}.", StringComparison.OrdinalIgnoreCase));
                BackgroundImage = foundWallpaper ?? _wallpaperPaths.FirstOrDefault();
            }
        }

        partial void OnSelectedGameChanged(string? value)
        {
            IsFsrSelectorVisible = value != "Select a Game...";
            UpdateBackgroundBasedOnSelection(value); 
        }


        partial void OnSelectedFsrVersionChanged(string? value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                // TODO: Implement logic
            }
        }
    }
}
