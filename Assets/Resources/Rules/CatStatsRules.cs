using System;
using System.Collections.Generic;

public class CatStatsRules{


    public List<StatRule> rules;


    public CatStatsRules(){}


    public class StatRule{

        public CatTag tag;

        public List<StatModifierRule> modifiers;

        public StatRule(){}

        public static implicit operator List<object>(StatRule v)
        {
            throw new NotImplementedException();
        }
    }


    public class StatModifierRule{

            public CatTag tag;
            public float value;

            public StatModifierRule(){}

        }

}