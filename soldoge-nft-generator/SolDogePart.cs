using System;

namespace soldoge_nft_generator
{
    public enum SolDogePartType
        {
            Background,
            Base,
            Backpack,
            Clothes,
            Collar,
            Extras,
            Eyes,
            Eyewear,
            Hair,
            Headwear,
            Mouth
        }

        public enum AssetType
        {
            File,
            Cdn
        }

        public class SolDogePart
        {
            public string AssetPath { get; }
            public SolDogePartType PartType { get; }
            public int Rarity { get; }
            public string Description { get; }
            public string Name { get; }

            public SolDogePart(string assetPath, SolDogePartType partType, int rarity, string description, string name, AssetType assetType = AssetType.File)
            {
                AssetPath = assetPath;
                PartType = partType;
                Rarity = rarity;
                Description = description;
                Name = name;
            }

            protected bool Equals(SolDogePart other)
            {
                return AssetPath == other.AssetPath && PartType == other.PartType && Rarity == other.Rarity && Description == other.Description && Name == other.Name;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((SolDogePart)obj);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(AssetPath, (int)PartType, Rarity, Description, Name);
            }
        
        }
}