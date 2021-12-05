using System.Collections.Generic;

namespace OnboardingSoftware.App
{
    public static class IconFont
    {
        //Arrows
        public const string ArrowDown = "\ue953";
        public const string ArrowLeft = "\ue954";
        public const string ArrowRight = "\ue955";
        public const string ArrowUp = "\ue956";
        public const string OptionsHorizontal = "\ue957";
        public const string OptionsVertical = "\ue958";

        //Buttons
        public const string CloseButton = "\ue942";
        public const string InfoButton = "\ue946";
        public const string MinusButton = "\ue948";
        public const string PhotoCameraButton = "\ue94a";
        public const string PlusButton = "\ue94c";
        public const string ProfileButton = "\ue94f";
        public const string YesButton = "\ue951";

        //Menu icons
        public const string Chat = "\ue93d";
        public const string Conversations = "\ue93e";
        public const string Measures = "\ue93f";
        public const string Motivation = "\ue940";
        public const string YourGoals = "\ue941";

        //Motivation icons
        public const string CommonIdentityAndVasion = "\ue933";
        public const string CopingFeeling = "\ue934";
        public const string Development = "\ue935";
        public const string ExtraGoods = "\ue936";
        public const string FacilitationAndFlexibility = "\ue937";
        public const string FeedbackAndComunication = "\ue938";
        public const string FeedbackComunication = "\ue939";
        public const string Payment = "\ue93a";
        public const string Recruitment = "\ue93b";
        public const string WorkEnvironment = "\ue93c";

        //Navigation icons
        public const string CloseSimple = "\ue92c";
        public const string Home = "\ue92d";
        public const string Inbox = "\ue92e";
        public const string Line = "\ue92f";
        public const string NewMessage = "\ue930";
        public const string PlusSimple = "\ue931";
        public const string SearchSecond = "\ue932";

        //Rest of icons 
        public const string DetailsGoals = "\ue91c";
        public const string RightArrowCircle = "\ue922";
        public const string RingBellCircle = "\ue924";
        public const string SendMessage = "\ue92a";

        //Standard icons
        public const string Alert = "\ue908";
        public const string Attachment = "\ue909";
        public const string Attention = "\ue90a";
        public const string Bookmark = "\ue90b";
        public const string Calendar = "\ue90c";
        public const string Camera = "\ue90d";
        public const string Cancel = "\ue90e";
        public const string Chart = "\ue90f";
        public const string Compose = "\ue910";
        public const string Delete = "\ue911";
        public const string Favorite = "\ue912";
        public const string Folder = "\ue913";
        public const string Help = "\ue914";
        public const string Lock = "\ue915";
        public const string Microphone = "\ue916";
        public const string Photos = "\ue917";
        public const string Price = "\ue918";
        public const string Profile = "\ue919";
        public const string Settings = "\ue91a";
        public const string Videos = "\ue91b";

        //Symbols icons
        public const string Locked = "\ue900";
        public const string ProfileInactive = "\ue901";
        public const string Refresh = "\ue902";
        public const string Ringbell = "\ue903";
        public const string Rocket = "\ue904";
        public const string Search = "\ue905";
        public const string TouchPoint = "\ue906";
        public const string Unlocked = "\ue907";

        public static List<IconItem> icons = new List<IconItem>
        {
            new IconItem { Id = 0, Name="SenseOfAchievement", IconString = IconFont.CopingFeeling },
            new IconItem { Id = 1, Name="Involvement", IconString = IconFont.FeedbackAndComunication},
            new IconItem { Id = 2, Name="FacilitationAndFlexibility", IconString = IconFont.FacilitationAndFlexibility},
            new IconItem { Id = 3, Name="FeedbackAndCommunication", IconString = IconFont.FeedbackComunication},
            new IconItem { Id = 4, Name="IdentityAndVision", IconString = IconFont.CommonIdentityAndVasion},
            new IconItem { Id = 5, Name="SocialEnvironment", IconString = IconFont.WorkEnvironment},
            new IconItem { Id = 6, Name="Development", IconString = IconFont.Development},
            new IconItem { Id = 7, Name="Salary", IconString = IconFont.Payment},
            new IconItem { Id = 8, Name="ExtraBenefits", IconString = IconFont.ExtraGoods},
            new IconItem { Id = 9, Name="RecruitmentAndOnBoarding", IconString = IconFont.Recruitment}
        };

        public static string GetIcon(int itemId)
        {
            foreach(var itemIcon in icons)
            {
                if(itemIcon.Id == itemId)
                {
                    return itemIcon.IconString;
                }
            }
            //default icon is trust
            return Chat;
        }
    }

    public class IconItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconString { get; set; }
    }
}
