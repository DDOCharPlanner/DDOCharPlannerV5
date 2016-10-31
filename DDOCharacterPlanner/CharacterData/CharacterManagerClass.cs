
using System;

namespace DDOCharacterPlanner.CharacterData
    {
    public sealed class CharacterManagerClass
        {
		#region Singleton Pattern
		private static readonly CharacterManagerClass characterManager = new CharacterManagerClass();
		private CharacterManagerClass() 
			{
			CharacterRace = new CharacterRaceClass();
			CharacterAbility = new CharacterAbilityClass();
            CharacterClass = new CharacterClassClass();
            CharacterFeat = new CharacterFeatCollectionClass();
            CharacterPastLife = new CharacterPastLifeClass();
            CharacterSkill = new CharacterSkillClass();
            CharacterAlignment = new CharacterAlignmentClass();
            
			}
		public static CharacterManagerClass CharacterManager
			{
			get { return characterManager; }
			}
		#endregion

		#region Properties
		public CharacterRaceClass CharacterRace
			{
			get;
			private set;
			}

		public CharacterAbilityClass CharacterAbility
			{
			get;
			private set;
			}

        public CharacterClassClass CharacterClass
            {
            get;
            private set;
            }

        public CharacterFeatCollectionClass CharacterFeat
            {
            get;
            private set;
            }
        public CharacterPastLifeClass CharacterPastLife
        {
            get;
            private set;
        }

        public CharacterSkillClass CharacterSkill
        {
            get;
            private set;
        }
        public CharacterAlignmentClass CharacterAlignment
        {
            get;
            private set;
        }

		#endregion
        }
    }
