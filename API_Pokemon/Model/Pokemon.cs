using System;

namespace Pokemon.Model
{
    public static class PokemonModel
    {
        public class Ability
    {
        public string Name { get; set; }
    }

        public class AbilityInfo
    {
        public Ability Ability { get; set; }
    }

        public class Pokemon
    {
        public string name { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public List<AbilityInfo> Abilities { get; set; }

    }
    }
}

