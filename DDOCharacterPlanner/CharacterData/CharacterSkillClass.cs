using DDOCharacterPlanner.Data;
using DDOCharacterPlanner.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;


namespace DDOCharacterPlanner.CharacterData
{
    public class CharacterSkillClass
    {
        #region Varibles
        int MaxSkillTomeBonus;
        List<Model.SkillModel> SkillsList;

        #endregion

        #region Enums
        public enum Skills
			{
            Balance,
            Bluff,
            Concentration,
            Diplomacy,
            Disable_Device,
            Haggle,
            Heal,
            Hide,
            Intimidate,
            Jump,
            Listen,
            Move_Silently,
            Open_Lock,
            Perform,
            Repair,
            Search,
            Spellcraft,
            Spot,
            Swim,
            Tumble,
            Use_Magic_Device
			}


		public enum ModifierTypes
			{
            Spent = 1,
			Rank = 2,
            RankTotal = 4,
			Ability = 8,
			Tome = 16,
			Feat = 32,
			Enhancement = 64,
			Destiny = 128,
			Gear = 256,
			All = (RankTotal | Ability | Tome | Feat | Enhancement | Destiny | Gear),
            SkillSheet = (RankTotal | Ability | Tome | Feat)
			}
		#endregion

		#region Properties

		public int TotalSkillRaisePoints
			{
			get;
			private set;
			}

        public int[,] RanksSpent
            {
            get;
            private set;
            }

        public bool[,] ValidRanksSpent
        {
            get;
            private set;
        }
        public int[] ClassRanks
            {
            get;
            private set;
            }
         
		public bool[,] ClassSkills
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

		public int NumSkills
			{
			get;
			private set;
			}
		#endregion

		#region Constructors
		public CharacterSkillClass()
			{
            SkillsList = Model.SkillModel.GetAll();
			NumSkills = Enum.GetNames(typeof(Skills)).Length;
            MaxSkillTomeBonus = Model.Tome.TomeModel.GetMaxBonus(Model.SkillModel.GetIdFromName("Balance"));
            RanksSpent = new int[NumSkills, Constant.MaxLevels];
            ValidRanksSpent = new bool[NumSkills, Constant.MaxLevels];
            ClassSkills = new bool[NumSkills, Constant.MaxLevels];
            ClassRanks = new int[Constant.MaxLevels];
			Tome = new int[NumSkills, MaxSkillTomeBonus];
			PriorLifeTome = new int [NumSkills, MaxSkillTomeBonus];
			Feat = new int[NumSkills];
			Enhancement = new int[NumSkills];
			Destiny = new int[NumSkills];
			Gear = new int[NumSkills];
			TotalSkillRaisePoints = 23;
			}
		#endregion

		#region Public Methods
		/// <summary>
		/// return an ability at a given level (default to 30)
		/// </summary>
		/// <param name="Skill"></param>
		/// <returns></returns>
		public Decimal GetSkill(Skills Skill, int level = 30, ModifierTypes modifiers = ModifierTypes.All)
			{
			Decimal result = 0;
			Decimal tomeResult;
            Decimal PriorLifeTomeResult;
            
            //Spent Points
            if (modifiers.HasFlag(ModifierTypes.Spent))
            {
                result += (Decimal)RanksSpent[(int)Skill, level-1];
            }
                    

            //Rank Points at level
            if (modifiers.HasFlag(ModifierTypes.Rank))
            {
               if(ClassSkills[(int)Skill,level-1])
               {
                   result += (Decimal)RanksSpent[(int)Skill, level-1];
               }
               else
               {
                   result += (Decimal)RanksSpent[(int)Skill, level-1] / 2;
               }
            }
            //Rank Points Total
            if (modifiers.HasFlag(ModifierTypes.RankTotal))
            {
                for (int i = 0; i < level; ++i)
                {
                    if (ClassSkills[(int)Skill, i])
                    {
                        result += (Decimal)RanksSpent[(int)Skill, i];
                    }
                    else
                    {
                        result += (Decimal)RanksSpent[(int)Skill, i] / 2;
                    }
                }
            }




            //Ability
            if (modifiers.HasFlag(ModifierTypes.Ability))
            {
                CharacterAbilityClass.Abilities ability;

                ability = CharacterAbilityClass.Abilities.Strength;

                if (SkillsList[(int)Skill].AbilityModifier == "Strength")
                    ability = CharacterAbilityClass.Abilities.Strength;
                if (SkillsList[(int)Skill].AbilityModifier == "Dexterity" )
                    ability = CharacterAbilityClass.Abilities.Dexterity;
                if (SkillsList[(int)Skill].AbilityModifier == "Constitution")
                    ability = CharacterAbilityClass.Abilities.Constitution;
                if (SkillsList[(int)Skill].AbilityModifier == "Intelligence")
                    ability = CharacterAbilityClass.Abilities.Intelligence;
                if (SkillsList[(int)Skill].AbilityModifier == "Wisdom")
                    ability = CharacterAbilityClass.Abilities.Wisdom;
                if (SkillsList[(int)Skill].AbilityModifier == "Charisma")
                    ability = CharacterAbilityClass.Abilities.Charisma;
                result += (Decimal)CharacterManagerClass.CharacterManager.CharacterAbility.GetModLevelup(ability, level);


            }     

			//tomes
			tomeResult = 0;
            PriorLifeTomeResult = 0;
			if (modifiers.HasFlag(ModifierTypes.Tome))
				{
                    for (int i = MaxSkillTomeBonus - 1; i >= 0; i -= 1)
                    {

                        if (Tome[(int)Skill, i] <= level && Tome[(int)Skill, i] > 0)
                        {
                            for (int x = 0; x <= i; x++)
                            {
                                if (level >= Constant.MinSkillTomeLevel[x])
                                {
                                    tomeResult += 1;
                                }
                            }
                            break;
                        }

                    }


                    //for (int i = 0; i < MaxSkillTomeBonus; i++)
                    //{
                    //    if (Tome[(int)Skill, i] <= level && Tome[(int)Skill, i] > 0 && level <= Constant.MinSkillTomeLevel[i])
                    //        tomeResult = i + 1;
                    //}




				    for (int i=0; i<MaxSkillTomeBonus; i++)
                    {
                        if (PriorLifeTome[(int)Skill, i] <= level && PriorLifeTome[(int)Skill, i] > 0)
                            PriorLifeTomeResult = i + 1;
                    }
                
            
                }
            if(PriorLifeTomeResult>=tomeResult)
            {
                result += (Decimal)PriorLifeTomeResult;
            }
            else
            {
                result += (Decimal)tomeResult;
            }
			

			//Feats
			//TODO: limit by supplied level
			if ((modifiers & ModifierTypes.Feat) == ModifierTypes.Feat)
                result += (Decimal)Feat[(int)Skill];

			//Enhancements
			//TODO: limit by supplied level
			if ((modifiers & ModifierTypes.Enhancement) == ModifierTypes.Enhancement)
                result += (Decimal)Enhancement[(int)Skill];

			//Destinies
			//TODO: limit by supplied level
			if ((modifiers & ModifierTypes.Destiny) == ModifierTypes.Destiny)
                result += (Decimal)Destiny[(int)Skill];

			//Gear
			//TODO: limit by supplied level (do we need to limit gear by level? By MinLevels perhaps?)
			if ((modifiers & ModifierTypes.Gear) == ModifierTypes.Gear)
                result += (Decimal)Gear[(int)Skill];

			return result;
			}

		/// <summary>
		/// When the class changes, we need to update Skill list
		/// </summary>
		/// <param name="raceName">new race name</param>
		public void UpdateClass(int Level, Guid Class)
			{

            //set Class Skills
            List<Model.SkillModel> ClassSkillList;
            ClassSkillList = new List<Model.SkillModel>();
            ClassSkillList = Model.SkillModel.GetAllForClass(Class);
            for(int i = 0; i<NumSkills;++i)
            {   ClassSkills[i,Level-1]=false;
                for(int y= 0;y<ClassSkillList.Count;++y)
                {
                    
                    if(SkillsList[i].Name == ClassSkillList[y].Name)
                    {
                        ClassSkills[i,Level-1]=true;
                    }
                }
            }
                int multi = 1;
                if (Level == 1)
                    multi = 4;
                ClassRanks[Level-1] = (Model.ClassModel.GetSkillPoints(Class) + CharacterManagerClass.CharacterManager.CharacterAbility.GetModLevelup(CharacterAbilityClass.Abilities.Intelligence, Level, CharacterAbilityClass.ModifierTypes.Skill)) * multi;
                multi = multi;
        }
        public void IntChange()
        {
            //
            for (int i = 1; i <= 20; ++i)
            {
                int multi = 1;
                if (i == 1)
                    multi = 4;
                ClassRanks[i-1] = (Model.ClassModel.GetSkillPoints(CharacterManagerClass.CharacterManager.CharacterClass.GetClass(i)) + CharacterManagerClass.CharacterManager.CharacterAbility.GetModLevelup(CharacterAbilityClass.Abilities.Intelligence, i, CharacterAbilityClass.ModifierTypes.Skill)) * multi;
            }
		}

		/// <summary>
		/// return the remaining number of ranks points available
		/// </summary>
		public int GetRemainingRanks(int level)
			{
			int result;

			result = ClassRanks[level-1];
            result -= GetTotalSpent(level);

			return result;
			}

        public int GetTotalSpent(int Level)
        {
            int result = 0;
            for (int i = 0; i < NumSkills; ++i)
                result += (int)GetSkill((Skills)i, Level, ModifierTypes.Spent);
                return result;
        }

        public void validateRankSpent()
        {
            decimal maxrank = 0;
            for(int i=0;i<NumSkills;++i)
            {
                for (int y = 1; y < 21; ++y)
                {
                    if(HasSkill((Skills)i,y))
                    {
                        maxrank = y + 3;
                    }
                    else
                    {
                        maxrank = (Decimal)(y + 3) / 2;
                    }
                    if (GetSkill((Skills)i, y, ModifierTypes.RankTotal) <= maxrank)
                    {
                        ValidRanksSpent[i, y-1] = true;
                    }
                    else
                    {
                        ValidRanksSpent[i, y-1] = false;
                    }
                }
            }
        }

        public bool HasSkill(Skills Skill, int Level)
        {
            bool hasSkill = false;

            for(int i = 0; i< Level;++i)
            {
                hasSkill |= ClassSkills[(int)Skill, i];
            }
            return hasSkill;
        }
		public bool AdjustRankRaise(Skills Skill, int Level, bool raise)
			{
                decimal maxrank = 0;

			//if we are increasing, make sure we have enough points to accept this raise
			if (raise == true)
				{
                    //max ranks at lvl ok
                    if(GetRemainingRanks(Level)>0)
                    {
                    //Check if Rank Exceeds Max
                        //set Max allowed

                        if (HasSkill(Skill,Level))
                        {
                            maxrank = Level + 3;
                        }
                        else
                        {
                            maxrank = (Decimal)(Level + 3) / 2;
                        }
                        decimal test = GetSkill(Skill, Level, ModifierTypes.RankTotal);
                        Debug.WriteLine(test);
                    if(GetSkill(Skill, Level, ModifierTypes.RankTotal) < maxrank)
                        {

                            RanksSpent[(int)Skill, Level - 1]++;
                            validateRankSpent();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    
                    }
                    else
                    {
                        return false;
                    }
                }

			//don't accept a decrease if we haven't spend enough points
			if (raise == false)
				{
				//we cannot go below 0 points spent
                if(RanksSpent[(int)Skill, Level-1] == 0)
                    return false;
                //all is good, allow the change
                RanksSpent[(int)Skill, Level-1]--;
                validateRankSpent();
                return true;
                }
            return false;
			}

        public void ResetRanks()
        {
            for(int i=0; i<Enum.GetValues(typeof(Skills)).Length; ++i)
            {
                for(int y=0; y<Constant.MaxLevels;++y)
                {
                    RanksSpent[i, y] = 0;
                }
            }

        }
		public void SetTomeBonus(Skills Skill, int bonus, int level)
			{
			Tome[(int)Skill, bonus-1] = level;
			}

		public void SetPriorLifeTomeBonus(Skills Skill, int bonus, int level)
			{
			PriorLifeTome[(int)Skill, bonus - 1] = level;
			}
		#endregion

    }
}
