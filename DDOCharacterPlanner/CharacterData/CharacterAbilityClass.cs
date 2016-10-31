using DDOCharacterPlanner.Data;
using DDOCharacterPlanner.Utility;
using System;

namespace DDOCharacterPlanner.CharacterData
	{
	public class CharacterAbilityClass
    {
        #region Varibles
        int MaxAbilityTomeBonus;

        #endregion

        #region Enums
        public enum Abilities
			{
			Strength,
			Dexterity,
			Constitution,
			Intelligence,
			Wisdom,
			Charisma,
			}

		[Flags]
		public enum BuildPointType
			{
			None = 0,
			Drow = 1,
			Iconic = 2,
			Favor = 4,
			SecondLife = 8,
			ThirdLife = 16,
			}

		[Flags]
		public enum ModifierTypes
			{
            Base = 1,
			CreationRaise = 2,
			LevelUp = 4,
			Tome = 8,
			Feat = 16,
			Enhancement = 32,
			Destiny = 64,
			Gear = 128,
            TomeMod = 256,
			All = (Base | CreationRaise | LevelUp | Tome | Feat | Enhancement | Destiny | Gear),
			Creation = (Base | CreationRaise),
            Skill = (Base | CreationRaise | LevelUp | TomeMod)
			}
		#endregion

		#region Fields
		private BuildPointType BuildType;
		#endregion

		#region Properties
		public int[] BaseStat
			{
			get;
			private set;
			}

		public int TotalStatRaisePoints
			{
			get;
			private set;
			}

		public int[] BaseStatRaise
			{
			get;
			private set;
			}

		public Abilities[] LevelUp
			{
			get;
			private set;
			}

		public int[,] Tome
			{
			get;
			private set;
			}

		public int[,] PriorLifeTome
			{
			get;
			private set;
			}

		public int[] Feat
			{
			get;
			private set;
			}

		public int[] Enhancement
			{
			get;
			private set;
			}

		public int[] Destiny
			{
			get;
			private set;
			}

		public int[] Gear
			{
			get;
			private set;
			}

		public int NumAbilities
			{
			get;
			private set;
			}
		#endregion

		#region Constructors
		public CharacterAbilityClass()
			{
			NumAbilities = Enum.GetNames(typeof(Abilities)).Length;
            MaxAbilityTomeBonus = Model.Tome.TomeModel.GetMaxBonus(Model.AbilityModel.GetIdFromName("Strength"));
			BaseStat = new int[NumAbilities];
			BaseStatRaise = new int[NumAbilities];
			LevelUp = new Abilities[Constant.MaxLevels];
			for (int i=0; i<Constant.MaxLevels; i++)
				LevelUp[i] = Abilities.Strength;
			Tome = new int[NumAbilities, MaxAbilityTomeBonus];
			PriorLifeTome = new int [NumAbilities, MaxAbilityTomeBonus];
			Feat = new int[NumAbilities];
			Enhancement = new int[NumAbilities];
			Destiny = new int[NumAbilities];
			Gear = new int[NumAbilities];
			TotalStatRaisePoints = 28;
			BuildType = BuildPointType.None;
			}
		#endregion

		#region Public Methods
		/// <summary>
		/// return an ability at a given level (default to 30)
		/// </summary>
		/// <param name="ability"></param>
		/// <returns></returns>
		public int GetAbility(Abilities ability, int level = 30, ModifierTypes modifiers = ModifierTypes.All)
			{
			int result = 0;
			int tomeResult;
            int PriorLifeTomeResult;

			//base value
			if (modifiers.HasFlag(ModifierTypes.Base))
				result += BaseStat[(int)ability];

			//creation raises
			if (modifiers.HasFlag(ModifierTypes.CreationRaise))
				result += BaseStatRaise[(int)ability];

			//level up
			if (modifiers.HasFlag(ModifierTypes.LevelUp))
				{
				for (int i=4; i<=level; i+=4)
					{
					if (LevelUp[i-1] == ability)
						result++;
					}
				}

			//tomes
			tomeResult = 0;
            PriorLifeTomeResult = 0;
			if (modifiers.HasFlag(ModifierTypes.Tome))
				{
				for (int i=MaxAbilityTomeBonus-1; i>=0; i -= 1)
					{

                        if (Tome[(int)ability, i] <= level && Tome[(int)ability, i] > 0)
                        {
                            for(int x=0; x<=i;x++)
                            {
                                if(level >= Constant.MinTomeLevel[x])
                                {
                                    tomeResult += 1;
                                }
                            }
                            break;
                        }

					}





				for (int i=0; i<MaxAbilityTomeBonus; i++)
                {
                    if (PriorLifeTome[(int)ability, i] <= level && PriorLifeTome[(int)ability, i] > 0)
                        PriorLifeTomeResult = i + 1;
                }
                
            
                }
            if(PriorLifeTomeResult>=tomeResult)
            {
                result += PriorLifeTomeResult;
            }
            else
            {
                result += tomeResult;
            }

            //tomes modified for Skill Ranks
            tomeResult = 0;
            PriorLifeTomeResult = 0;
            if (modifiers.HasFlag(ModifierTypes.TomeMod))
            {
                //tomes used at level do not get added till after level has been taken so can not be used for Skill Ranks
                for (int i = MaxAbilityTomeBonus - 1; i >= 0; i -= 1)
                {

                        if (Tome[(int)ability, i] < level && Tome[(int)ability, i] > 0)
                        {
                            for (int x = 0; x <= i; x++)
                            {
                                if (level >= Constant.MinTomeLevel[x])
                                {
                                    tomeResult += 1;
                                }
                            }
                            break;
                        }
                    

                }
                //tome for past life are added at begining of levelup.
                for (int i = 0; i < MaxAbilityTomeBonus; i++)
                {
                    if (PriorLifeTome[(int)ability, i] <= level && PriorLifeTome[(int)ability, i] > 0)
                        PriorLifeTomeResult = i + 1;
                }


            }
            if (PriorLifeTomeResult >= tomeResult)
            {
                result += PriorLifeTomeResult;
            }
            else
            {
                result += tomeResult;
            }

			//Feats
			//TODO: limit by supplied level
			if ((modifiers & ModifierTypes.Feat) == ModifierTypes.Feat)
				result += Feat[(int)ability];

			//Enhancements
			//TODO: limit by supplied level
			if ((modifiers & ModifierTypes.Enhancement) == ModifierTypes.Enhancement)
				result += Enhancement[(int)ability];

			//Destinies
			//TODO: limit by supplied level
			if ((modifiers & ModifierTypes.Destiny) == ModifierTypes.Destiny)
				result += Destiny[(int)ability];

			//Gear
			//TODO: limit by supplied level (do we need to limit gear by level? By MinLevels perhaps?)
			if ((modifiers & ModifierTypes.Gear) == ModifierTypes.Gear)
				result += Gear[(int)ability];

			return result;
			}

		/// <summary>
		/// return the mod based on the total ability at a given level (default to 30)
		/// </summary>
		/// <param name="ability"></param>
		/// <returns></returns>
		public int GetMod(Abilities ability, int level = 30)
			{ 
			int abilityValue;

			abilityValue = GetAbility(ability, level);
			return GetMod(abilityValue);
			}

        /// <summary>
        /// return the mod based at the time of levelup for the ability at a given level (default to 30)
        /// </summary>
        /// <param name="ability"></param>
        /// <returns></returns>
        public int GetModLevelup(Abilities ability, int level = 30, ModifierTypes Mod=ModifierTypes.Skill)
        {
            int abilityValue;

            abilityValue = GetAbility(ability, level, Mod);
            return GetMod(abilityValue);
        }
		/// <summary>
		/// return the mod based on the given value of the ability
		/// </summary>
		/// <param name="ability"></param>
		/// <returns></returns>
		public int GetMod(int abilityValue)
			{
			if (abilityValue >= 10)
				return (abilityValue - 10) / 2;
			else
				return (abilityValue - 11) / 2;
			}

		/// <summary>
		/// When the race changes, we need to update the base stats
		/// </summary>
		/// <param name="raceName">new race name</param>
		public void UpdateRace(string raceName)
			{
			for (int i = 0; i < NumAbilities; i++)
				{
				BaseStat[i] = DataManagerClass.DataManager.RaceDataCollection.Races[raceName].BaseAbility[i];
				}
			}

		/// <summary>
		/// return the remaining number of stat raise points available
		/// </summary>
		public int GetRemainingStatRaisePoints()
			{
			int result;

			result = TotalStatRaisePoints;
			for (int i = 0; i < 6; i++)
				{
				result -= GetStatRaiseSpent((Abilities)i);
				}

			return result;
			}

		/// <summary>
		/// returns the cost of taking the NEXT ability point during creation
		/// </summary>
		/// <param name="ability">The ability of which to return the cost</param>
		/// <returns></returns>
		public int GetStatRaiseCost(Abilities ability)
			{
			if (BaseStatRaise[(int)ability] <= 6)
				return 1;
			if (BaseStatRaise[(int)ability] > 6 && BaseStatRaise[(int)ability] <= 8)
				return 2;
			if (BaseStatRaise[(int)ability] > 8)
				return 3;
			return 0;
			}

		/// <summary>
		/// returns the total amount spent (level 1 creation points) on this ability
		/// </summary>
		/// <param name="ability"></param>
		/// <returns></returns>
		public int GetStatRaiseSpent(Abilities ability)
			{
			int cost = 0;

			for (int i = 0; i < BaseStatRaise[(int)ability]; i++)
				{
				if (i <= 6)
					cost += 1;
				if (i > 6 && i <= 8)
					cost += 2;
				if (i > 8)
					cost += 3;
				}
			return cost;
			}

		public void AdjustBaseStatRaise(Abilities ability, bool raise)
			{
			int cost;
			string raceName;

			//if we are increasing, make sure we have enough points to accept this raise
			if (raise == true)
				{
				cost = GetStatRaiseCost(ability);
				if (cost > GetRemainingStatRaisePoints())
					return;
				//also, don't go above the max ability (we could just use 10, but let's be more general and grab the data from the database, since we have it)
				raceName = CharacterManagerClass.CharacterManager.CharacterRace.GetRaceName();
				if (BaseStatRaise[(int)ability] >= (DataManagerClass.DataManager.RaceDataCollection.Races[raceName].BaseAbilityMax[(int)ability] - DataManagerClass.DataManager.RaceDataCollection.Races[raceName].BaseAbility[(int)ability]))
					return;
				//all is good, allow the change
				BaseStatRaise[(int)ability]++;
				}

			//don't accept a decrease if we haven't spend enough points
			if (raise == false)
				{
				//we cannot go below 0 points spent
				if (BaseStatRaise[(int)ability] == 0)
					return;
				//all is good, allow the change
				BaseStatRaise[(int)ability]--;
				}
			}

		public void SetBuildType(BuildPointType type, bool set)
			{
			if (!set)
				BuildType = BuildType & ~type;
			else
				BuildType = BuildType | type;

			//checks (drow and iconic are mutually exclusive)
			if (type == BuildPointType.Drow)
				BuildType = BuildType & ~BuildPointType.Iconic;
			if (type == BuildPointType.Iconic)
				BuildType = BuildType & ~BuildPointType.Drow;

			//deterine the correct number of build points
			if ((BuildType & BuildPointType.Drow) != 0)
				{
				if ((BuildType & BuildPointType.ThirdLife) != 0)
					TotalStatRaisePoints = 32;
				else if ((BuildType & BuildPointType.SecondLife) != 0)
					TotalStatRaisePoints = 30;
				else
					TotalStatRaisePoints = 28;
				}
			else
				{
				if ((BuildType & BuildPointType.ThirdLife) != 0)
					TotalStatRaisePoints = 36;
				else if ((BuildType & BuildPointType.SecondLife) != 0)
					TotalStatRaisePoints = 34;
				else if ((BuildType & BuildPointType.Iconic) != 0)
					TotalStatRaisePoints = 32;
				else if ((BuildType & BuildPointType.Favor) != 0)
					TotalStatRaisePoints = 32;
				else
					TotalStatRaisePoints = 28;
				}
			}

		public void SetAbilityLevelUp(Abilities ability, int level)
			{
			//validate level from 1-30, and also that it is divisible by 4
			if (level < 1 || level > 30)
				return;
			if (level%4 != 0)
				return;
			//note that level input will be from 1-30, but we are storing them as 0-29 in the array
			level--;

			LevelUp[level] = ability;
			}

		public void SetTomeBonus(Abilities ability, int bonus, int level)
			{
			Tome[(int)ability, bonus-1] = level;
			}

		public void SetPriorLifeTomeBonus(Abilities ability, int bonus, int level)
			{
			PriorLifeTome[(int)ability, bonus - 1] = level;
			}
		#endregion

		}
	}
