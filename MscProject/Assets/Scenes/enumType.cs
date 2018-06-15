using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    
        public enum Actions
        {
            Update = 0, LogIn, UseChar, GetPlayers, ViewChar, ViewArmy, GetNPCList, HireNPC, FireNPC, TravelTo, MoveCharacter, ViewFief, ViewMyFiefs, AppointBailiff, RemoveBailiff, BarCharacters, BarNationalities, UnbarCharacters, UnbarNationalities, GrantFiefTitle, AdjustExpenditure, TransferFunds,
            TransferFundsToPlayer, EnterExitKeep, ListCharsInMeetingPlace, TakeThisRoute, Camp, AddRemoveEntourage, ProposeMarriage, AcceptRejectProposal, RejectProposal, AppointHeir, TryForChild, RecruitTroops, MaintainArmy, AppointLeader, DropOffTroops,
            ListDetachments, ListArmies, PickUpTroops, PillageFief, BesiegeFief, AdjustCombatValues, ExamineArmiesInFief, Attack, ViewJournalEntries, ViewJournalEntry, SiegeRoundReduction, SiegeRoundStorm, SiegeRoundNegotiate, SiegeList, ViewSiege, EndSiege, DisbandArmy, SpyFief, SpyCharacter, SpyArmy, Kidnap, ViewCaptives, ViewCaptive, RansomCaptive, ReleaseCaptive, ExecuteCaptive, RespondRansom, SeasonUpdate
        }
        public enum DisplayMessages
        {
            /// <summary>
            /// Default message; used only when nothing to display
            /// </summary>
            None = 0,
            /// <summary>
            /// Indicates action was successful
            /// </summary>
            Success, Error, Armies, Fiefs, Characters, JournalEntries, ArmyMaintainInsufficientFunds, ArmyMaintainCost, ArmyMaintainConfirm, ArmyMaintainedAlready, JournalProposal, JournalProposalReply, JournalMarriage, ChallengeKingSuccess, ChallengeKingFail, ChallengeProvinceSuccess, ChallengeProvinceFail, newEvent,
            SwitchPlayerErrorNoID, SwitchPlayerErrorIDInvalid, ChallengeErrorExists, SiegeNegotiateSuccess, SiegeNegotiateFail, SiegeStormSuccess, SiegeStormFail, SiegeEndDefault, SiegeErrorDays, SiegeRaised, SiegeReduction, ArmyMove,
            ArmyAttritionDebug, ArmyDetachmentArrayWrongLength, ArmyDetachmentNotEnoughTroops, ArmyDetachmentNotSelected, ArmyRetreat, ArmyDisband, ErrorGenericNotEnoughDays, ErrorGenericPoorOrganisation, ErrorGenericUnidentifiedRecipient, ArmyNoLeader, ArmyBesieged,
            ArmyAttackSelf, ArmyPickupsDenied, ArmyPickupsNotEnoughDays, BattleBringSuccess, BattleBringFail, BattleResults, ErrorGenericNotInSameFief, BirthAlreadyPregnant, BirthSiegeSeparation, BirthNotMarried, CharacterMarriageDeath, CharacterDeath, CharacterDeathNoHeir, CharacterEnterArmy,
            CharacterAlreadyArmy, CharacterNationalityBarred, CharacterBarred, CharacterRoyalGiftPlayer, CharacterRoyalGiftSelf, CharacterNotMale, CharacterNotOfAge, CharacterLeaderLocation, CharacterLeadingArmy,
            /// <summary>
            /// Character does not have enough days to make this journey, so their destination has been added to a Go-To list
            /// </summary>
            CharacterDaysJourney, CharacterSpousePregnant, CharacterSpouseNotPregnant, CharacterSpouseNeverPregnant,
            CharacterBirthOK, CharacterBirthChildDead, CharacterBirthMumDead, CharacterBirthAllDead, RankTitleTransfer, CharacterCombatInjury, CharacterProposalMan, CharacterProposalUnderage, CharacterProposalEngaged, CharacterProposalMarried, CharacterProposalFamily, CharacterProposalIncest, CharacterProposalAlready, CharacterRemovedFromEntourage, CharacterCamp,
            CharacterCampAttrition, CharacterBailiffDuty,
            /// <summary>
            /// Character must end siege before moving
            /// </summary>
            CharacterMoveEndSiege, MoveCancelled, CharacterInvalidMovement, ErrorGenericFiefUnidentified, CharacterHireNotEmployable, CharacterFireNotEmployee, CharacterOfferLow, CharacterOfferHigh, CharacterOfferOk, CharacterOfferAlmost, CharacterOfferHaggle, CharacterBarredKeep, CharacterRecruitOwn, CharacterRecruitAlready, CharacterLoyaltyLanguage, ErrorGenericInsufficientFunds, CharacterRecruitSiege, CharacterRecruitRebellion, RecruitCancelled,
            CharacterTransferTitle, CharacterTitleOwner, CharacterTitleHighest, CharacterTitleKing, CharacterTitleAncestral, CharacterHeir, PillageInitiateSiege, PillageRetreat, PillageDays, PillageOwnFief, PillageUnderSiege, PillageSiegeAlready, PillageAlready, PillageArmyDefeat, PillageSiegeRebellion, FiefExpenditureAdjustment, FiefExpenditureAdjusted, FiefStatus, FiefOwnershipHome,
            FiefOwnershipNewHome, FiefOwnershipNoFiefs, FiefChangeOwnership, FiefQuellRebellionFail, FiefEjectCharacter, FiefNoCaptives, ProvinceAlreadyOwn, KingdomAlreadyKing, KingdomOwnershipChallenge, ProvinceOwnershipChallenge, ErrorGenericCharacterUnidentified, ErrorGenericUnauthorised, ErrorGenericMessageInvalid, ErrorGenericTooFarFromFief, FiefNoBailiff, FiefCouldNotBar, FiefCouldNotUnbar,
            ErrorGenericBarOwnNationality, ErrorGenericPositiveInteger, GenericReceivedFunds, ErrorGenericNoHomeFief, CharacterRecruitInsufficientFunds, CharacterRecruitOk, SiegeNotBesieger, JournalEntryUnrecognised, JournalEntryNotProposal, ErrorGenericArmyUnidentified, ErrorGenericSiegeUnidentified, ErrorSpyDead, ErrorSpyCaptive, ErrorSpyOwn, SpyChance, SpySuccess, SpyFail, SpySuccessDetected, SpyFailDetected, SpyFailDead, SpyCancelled, EnemySpySuccess, EnemySpyFail, EnemySpyKilled, CharacterHeldCaptive, RansomReceived, RansomPaid, RansonDenied, RansomRepliedAlready, RansomCaptiveDead, RansomAlready, NotCaptive, EntryNotRansom, KidnapOwnCharacter, KidnapDead, KidnapNoPlayer, KidnapSuccess, KidnapSuccessDetected, KidnapFailDetected, KidnapFailDead, KidnapFail, EnemyKidnapSuccess, EnemyKidnapSuccessDetected, EnemyKidnapFail, EnemyKidnapKilled, CharacterExecuted, CharacterReleased, LogInSuccess, LogInFail, YouDied, YouDiedNoHeir, CharacterIsDead, Timeout
        }
    

