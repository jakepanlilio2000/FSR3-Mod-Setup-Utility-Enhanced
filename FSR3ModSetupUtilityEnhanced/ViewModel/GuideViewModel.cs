using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using FSR3ModSetupUtilityEnhanced.Models;

namespace FSR3ModSetupUtilityEnhanced.ViewModel
{
    public partial class GuideViewModel : ObservableObject
    {
        public ObservableCollection<GuideTopic> Topics { get; }

        [ObservableProperty]
        private GuideTopic _selectedTopic;

        public GuideViewModel()
        {
            Topics =
            [
                new()
                {
                    Title = "Initial Information",
                    Description = """
                        Initial Information

                        1 - When selecting the game folder, look for the game's .exe file. Some games have the full name .exe or abbreviated, while others have the .exe file in the game folder but within subfolders with the ending Binaries\Win64, and the .exe usually ends with Win64-Shipping, for example: TheCallistoProtocol-Win64-Shipping.

                        2 - It is recommended to read the guide before installing the mod. Some games do not have a guide because you only need to install the mod, while others, like Fallout 4 for example, have extra steps for installation.
                        If something is done incorrectly, the mod will not work.

                        3 - Some games may not work for certain users after installing the mod. It is recommended to check the Enable Signature Override if the mod does not work with the default files.
                        """,
                    ImagePath = "/Assets/Images/initial-info.png", // Example path ImagePath = "/Assets/Images/initial-info.png", // Example path
                },
                new()
                {
                    Title = "Add-on Mods",
                    Description =
                        "Add-on mods are additional files that can enhance your experience. Make sure to read the instructions for each mod carefully before installing.",
                    ImagePath = "/Images/Wallpaper/Addon.png",
                },
                new()
                {
                    Title = "Alan Wake 2",
                    Description =
                        "To install the FSR 3 mod for Alan Wake 2:\n1. Ensure the game is updated to the latest version.\n2. Use the 'Select Game' dropdown on the home page.\n3. Follow the on-screen instructions to apply the mod.",
                    ImagePath = "/Assets/Images/alan-wake-2.jpg",
                    VideoUrl = "https://www.youtube.com/watch?v=your_video_id", // Optional video link
                },
                new()
                {
                    Title = "Cyberpunk 2077",
                    Description =
                        "For Cyberpunk 2077, the process is straightforward:\n1. Select the game from the list.\n2. Choose the desired FSR version.\n3. The utility will handle the file replacement automatically.",
                    ImagePath = "/Assets/Images/cyberpunk.jpg",
                },
                //  Add aother topics 
            ];

            SelectedTopic =
                Topics.FirstOrDefault()
                ?? new GuideTopic
                {
                    Title = "No Topics Available",
                    Description =
                        "There are currently no topics available. Please check back later.",
                    ImagePath = "/Assets/Images/default.png",
                };
        }
    }
}
