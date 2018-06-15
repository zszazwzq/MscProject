using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

[ProtoInclude(9, typeof(ProtoGenericArray<ProtoFief>))]
[ProtoInclude(10, typeof(ProtoGenericArray<string>))]
[ProtoInclude(11, typeof(ProtoGenericArray<double>))]

/*
[ProtoInclude(5, typeof(ProtoLogIn))]

[ProtoInclude(6, typeof(ProtoPlayer))]
[ProtoInclude(7, typeof(ProtoClient))]
[ProtoInclude(8, typeof(ProtoGenericArray<ProtoPlayer>))]
[ProtoInclude(9, typeof(ProtoGenericArray<ProtoFief>))]
[ProtoInclude(10, typeof(ProtoGenericArray<string>))]
[ProtoInclude(11, typeof(ProtoGenericArray<double>))]
[ProtoInclude(12, typeof(ProtoGenericArray<ProtoCharacterOverview>))]
[ProtoInclude(13, typeof(ProtoGenericArray<ProtoDetachment>))]
[ProtoInclude(14, typeof(ProtoGenericArray<ProtoSiegeOverview>))]
[ProtoInclude(15, typeof(ProtoGenericArray<ProtoArmyOverview>))]
[ProtoInclude(16, typeof(ProtoGenericArray<ProtoJournalEntry>))]
[ProtoInclude(17, typeof(ProtoAilment))]
[ProtoInclude(18, typeof(ProtoArmy))]
[ProtoInclude(19, typeof(ProtoCharacter))]
[ProtoInclude(20, typeof(ProtoFief))]
[ProtoInclude(21, typeof(ProtoArmyOverview))]
[ProtoInclude(22, typeof(ProtoCharacterOverview))]
[ProtoInclude(23, typeof(ProtoPillageResult))]
[ProtoInclude(24, typeof(ProtoSiegeOverview))]
[ProtoInclude(25, typeof(ProtoSiegeDisplay))]
[ProtoInclude(26, typeof(ProtoBattle))]
[ProtoInclude(27, typeof(ProtoJournalEntry))]
[ProtoInclude(28, typeof(ProtoJournal))]
[ProtoInclude(29, typeof(ProtoDetachment))]
[ProtoInclude(30, typeof(ProtoTransfer))]
[ProtoInclude(31, typeof(ProtoTransferPlayer))]
[ProtoInclude(32, typeof(ProtoTravelTo))]
[ProtoInclude(33, typeof(ProtoRecruit))]
[ProtoInclude(34, typeof(ProtoCombatValues))]
[ProtoContract, Serializable]
*/

public class ProtoMessage
    {
    /// <summary>
    /// Contains the underlying type of the message. Used identify which action the client took
    /// </summary>
    [ProtoMember(1)]
        public Actions ActionType { get; set; }

        /// <summary>
        /// Contains a message or messageID for the client
        /// Used when sending error messages
        /// </summary>
        //[ProtoMember(2)]
        public String Message;

        /// <summary>
        /// Contains any fields that need to be sent along with the message
        /// e.g. amount of overspend in fief
        /// </summary>
        [ProtoMember(3)]
        public string[] MessageFields;

        /// <summary>
        /// Contains the server response
        /// </summary>
        //[ProtoMember(4)]
       // public DisplayMessages ResponseType { get; set; }

        public string getMessage()
        {
            return this.Message;
        }
        public string[] getFields()
        {
            return this.MessageFields;
        }
        public ProtoMessage()
        {
        }

       // public ProtoMessage(DisplayMessages result)
      //  {
       //     this.ResponseType = result;
     //   }
    }


/**************** MESSAGES TO CLIENT ***********************/

[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
public class Pair
{
    public string key { get; set; }
    public string value { get; set; }
    public Pair(string key, string val)
    {
        this.key = key;
        this.value = val;
    }
    public Pair()
    {
    }
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class ProtoCharacter : ProtoMessage
    {
        /* BASIC CHARACTER DETAILS */
        /// <summary>
        /// Holds character ID
        /// </summary>
        public string charID { get; set; }
        /// <summary>
        /// Holds character's first name
        /// </summary>
        public string firstName { get; set; }
        /// <summary>
        /// Holds character's family name
        /// </summary>
        public string familyName { get; set; }
        /// <summary>
        /// Character's year of birth
        /// </summary>
        public uint birthYear { get; set; }
        /// <summary>
        /// Character's birth season
        /// </summary>
        public byte birthSeason { get; set; }
        /// <summary>
        /// Holds if character male
        /// </summary>
        public bool isMale { get; set; }
        /// <summary>
        /// Holds the string representation of this character's nationality
        /// </summary>
        public string nationality { get; set; }
        /// <summary>
        /// Indicates whether a character is alive
        /// </summary>
        public bool isAlive { get; set; }
        /// <summary>
        /// Character's max health
        /// </summary>
        public double maxHealth { get; set; }
        /// <summary>
        /// Character's current health
        /// </summary>
        public double health { get; set; }
        /// <summary>
        /// Character's stature
        /// </summary>
        public double stature { get; set; }
        /// <summary>
        /// Character's virility
        /// </summary>
        public double virility { get; set; }
        /// <summary>
        /// Bool detclaring whether character is in keep
        /// </summary>
        public bool inKeep { get; set; }
        /// <summary>
        /// Character's language ID
        /// </summary>
        public string language { get; set; }
        /// <summary>
        /// number of days left in season
        /// </summary>
        public double days { get; set; }
        /// <summary>
        /// Character's family ID
        /// </summary>
        public String familyID { get; set; }
        /// <summary>
        /// Character spouse charID
        /// </summary>
        public String spouse { get; set; }
        /// <summary>
        /// Character father charID
        /// </summary>
        public String father { get; set; }
        /// <summary>
        /// Character mother charID
        /// </summary>
        public String mother { get; set; }
        /// <summary>
        /// Character mother charID
        /// </summary>
        public string fiancee { get; set; }
        /// <summary>
        /// Character location (FiefID)
        /// </summary>
        public string location { get; set; }
        /// <summary>
        /// Character statureModifier
        /// </summary>
        public double statureModifier { get; set; }
        /// <summary>
        /// Character management rating
        /// </summary>
        public double management { get; set; }
        /// <summary>
        /// Character combat skill
        /// </summary>
        public double combat { get; set; }
        /// <summary>
        /// Holds character's traits
        /// </summary>
        public Pair[] traits { get; set; }
        /// <summary>
        /// Bool to indicate whether char is pregnant
        /// </summary>
        public bool isPregnant { get; set; }
        /// <summary>
        /// Holds char's title
        /// </summary>
        public string[] titles { get; set; }
        /// <summary>
        /// ArmyID, if char leads army
        /// </summary>
        public string armyID { get; set; }
        /// <summary>
        /// Character's ailments
        /// </summary>
        public Pair[] ailments { get; set; }
        /// <summary>
        /// IDs of Fiefs in char's GoTo list
        /// </summary>
        public string[] goTo { get; set; }
        /// <summary>
        /// Holds name of captor (if is null character is not captive)
        /// </summary>
        public string captor { get; set; }
        // Holds information as to whether character is involved in a siege
        public enum SiegeRole { None = 0, Besieger, Defender, DefenderAdd };
        public SiegeRole siegeRole;

        [ProtoInclude(35, typeof(ProtoPlayerCharacter))]
        public class ProtoPlayerCharacter : ProtoCharacter
        {
            /// <summary>
            /// Holds ID of player who is currently playing this PlayerCharacter
            /// Note that list of sieges and list of armies is stored elsewhere- see ProtoSiegeList and ProtoArmyList
            /// </summary>
            public string playerID { get; set; }
            /// <summary>
            /// Holds character outlawed status
            /// </summary>
            public bool outlawed { get; set; }
            /// <summary>
            /// Holds character's treasury
            /// </summary>
            public uint purse { get; set; }
            /// <summary>
            /// Holds IDs and names of character's employees and family
            /// </summary>
            // public ProtoCharacterOverview[] myNPCs { get; set; }
            /// <summary>
            /// Holds details of heir
            /// </summary>
            // public ProtoCharacterOverview myHeir { get; set; }
            /// <summary>
            /// Holds IDs of character's owned fiefs
            /// </summary>
            public string[] ownedFiefs { get; set; }
            /// <summary>
            /// Holds IDs of character's owned provinces
            /// </summary>
            public string[] provinces { get; set; }
            /// <summary>
            /// Holds character's home fief (fiefID)
            /// </summary>
            public String homeFief { get; set; }
            /// <summary>
            /// Holds character's ancestral home fief (fiefID)
            /// </summary>
            public String ancestralHomeFief { get; set; }


        }
        /// <summary>
        /// Contains various keys and salts for logging in
        /// </summary>
    }
}
public class ProtoGenericArray<T> : ProtoMessage
{
    public T[] fields { get; set; }

    public ProtoGenericArray()
        : base()
    {

    }

    public ProtoGenericArray(T[] t)
    {
        this.fields = t;
    }
}
[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
[ProtoInclude(20, typeof(ProtoFief))]

public class ProtoFief : ProtoMessage
{
    /// <summary>
    /// ID of the fief
    /// </summary>
    public string fiefID { get; set; }
    /// <summary>
    /// CharID and name of fief title holder
    /// </summary>
    public string titleHolder { get; set; }
    /// <summary>
    /// Name of fief owner
    /// </summary>
    public string owner { get; set; }
    /// <summary>
    /// CharID of the fief owner
    /// </summary>
    public string ownerID { get; set; }
    /// <summary>
    /// Fief rank
    /// </summary>
    public string rank { get; set; }
    /// <summary>
    /// Holds fief population
    /// </summary>
    public int population { get; set; }
    /// <summary>
    /// Holds fief field level
    /// </summary>
    public double fields { get; set; }
    /// <summary>
    /// Holds fief industry level
    /// </summary>
    public double industry { get; set; }
    /// <summary>
    /// Holds number of troops in fief
    /// </summary>
    public uint troops { get; set; }
    /// <summary>
    /// Holds number of troops that can be recruited in this fief
    /// </summary>
    public int militia { get; set; }
    /// <summary>
    /// Holds fief tax rate
    /// </summary>
    public double taxRate { get; set; }
    /// <summary>
    /// Holds fief tax rate (next season)
    /// </summary>
    public double taxRateNext { get; set; }
    /// <summary>
    /// Holds expenditure on officials (next season)
    /// </summary>
    public uint officialsSpendNext { get; set; }
    /// <summary>
    /// Holds expenditure on garrison (next season)
    /// </summary>
    public uint garrisonSpendNext { get; set; }
    /// <summary>
    /// Holds expenditure on infrastructure (next season)
    /// </summary>
    public uint infrastructureSpendNext { get; set; }
    /// <summary>
    /// Holds expenditure on keep (next season)
    /// </summary>
    public uint keepSpendNext { get; set; }
    /// <summary>
    /// Holds key data for current season.
    /// 0 = loyalty,
    /// 1 = GDP,
    /// 2 = tax rate,
    /// 3 = official expenditure,
    /// 4 = garrison expenditure,
    /// 5 = infrastructure expenditure,
    /// 6 = keep expenditure,
    /// 7 = keep level,
    /// 8 = income,
    /// 9 = family expenses,
    /// 10 = total expenses,
    /// 11 = overlord taxes,
    /// 12 = overlord tax rate,
    /// 13 = bottom line
    /// </summary>
    public double[] keyStatsCurrent;
    /// <summary>
    /// Holds key data for previous season
    /// </summary>
    public double[] keyStatsPrevious;
    /// <summary>
    /// Holds key data for next season
    /// </summary>
    public double[] keyStatsNext;
    /// <summary>
    /// Holds fief keep level
    /// </summary>
    public double keepLevel { get; set; }
    /// <summary>
    /// Holds fief loyalty
    /// </summary>
    public double loyalty { get; set; }
    /// <summary>
    /// Holds fief status (calm, unrest, rebellion)
    /// </summary>
    public char status { get; set; }
    /// <summary>
    /// Holds overviews of characters present in fief
    /// </summary>
    //public ProtoCharacterOverview[] charactersInFief { get; set; }
    /// <summary>
    /// Holds characters banned from keep (charIDs)
    /// </summary>
    //public ProtoCharacterOverview[] barredCharacters { get; set; }
    /// <summary>
    /// Holds nationalities banned from keep (IDs)
    /// </summary>
    public string[] barredNationalities { get; set; }
    /// <summary>
    /// Holds fief ancestral owner (PlayerCharacter object)
    /// </summary>
    //public ProtoCharacterOverview ancestralOwner { get; set; }
    /// <summary>
    /// Holds fief bailiff (Character object)
    /// </summary>
    //public ProtoCharacterOverview bailiff { get; set; }
    /// <summary>
    /// Number of days the bailiff has been resident in the fief (this season)
    /// </summary>
    public Double bailiffDaysInFief { get; set; }
    /// <summary>
    /// Holds fief treasury
    /// </summary>
    public int treasury { get; set; }
    /// <summary>
    /// Holds overviews of armies present in the fief (armyIDs)
    /// </summary>
    //public ProtoArmyOverview[] armies { get; set; }
    /// <summary>
    /// Identifies if recruitment has occurred in the fief in the current season
    /// </summary>
    private bool hasRecruited { get; set; }
    /// <summary>
    /// Identifies if pillage has occurred in the fief in the current season
    /// </summary>
    public bool isPillaged { get; set; }
    /// <summary>
    /// Siege (siegeID) of active siege
    /// </summary>
    public String siege { get; set; }
    /// <summary>
    /// List of characters held captive in fief
    /// </summary>
    //public ProtoCharacterOverview[] gaol { get; set; }

    public ProtoFief()
        : base()
    {

    }

}



