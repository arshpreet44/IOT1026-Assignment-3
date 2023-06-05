namespace Assignment
{
    public class Pack
    {
        private readonly List<InventoryItem> _items; // List to store the inventory items in the pack.
        private readonly int _maxCount; // Maximum number of items that can be stored in the pack.
        private readonly float _maxVolume; //Maximum volume that the pack can hold.
        private readonly float _maxWeight; // Maximum weight that the pack can hold.
        private float _currentVolume; // Current volume occupied in the pack.
        private float _currentWeight; // Current weight occupied in the pack.

        // Default constructor sets 
        // the maxCount to 10 
        // maxVolume to 20 
        // maxWeight to 30
        public Pack() : this(10, 20, 30) { }

        public Pack(int maxCount, float maxVolume, float maxWeight)
        {
            _items = new List<InventoryItem>();// Initialize an empty list to store the inventory items.
            _maxCount = maxCount; // Set the maximum count of items that the pack can hold.
            _maxVolume = maxVolume; // Set the maximum volume that the pack can hold.
            _maxWeight = maxWeight; // Set the maximum weight that the pack can hold.
        }

        // This is called a getter
        public List<InventoryItem> GetItems()
        {
            return _items;
        }

        public float GetVolume()
        {
            return _currentVolume;
        }

        public float GetWeight()
        {
            return _currentWeight;
        }

        public int GetMaxCount()
        {
            return _maxCount;
        }

        public float GetMaxVolume()
        {
            return _maxVolume;
        }

        public float GetMaxWeight()
        {
            return _maxWeight;
        }

        public bool Add(InventoryItem item)
        {
            float weight = item.GetWeight();
            float volume = item.GetVolume();

            if (weight < 0 || volume < 0)
            {
                return false; // If the weight or volume is negative, return false indicating that the item cannot be added.
            }

            if (_items.Count + 1 > GetMaxCount() || (_currentWeight + weight) > GetMaxWeight() || (_currentVolume + volume) > GetMaxVolume())
            {
                return false; // If adding the item would exceed the maximum count, weight, or volume of the pack, return false indicating that the item cannot be added.
            }

            _items.Add(item);
            _currentWeight += weight;
            _currentVolume += volume;
            return true;
        }

        public override string ToString()
        {
            // Create a string variable to hold the result
            string result = $"Pack is currently at {_items.Count}/{GetMaxCount()} items, {GetWeight()}/{GetMaxWeight()} weight, and {GetVolume()}/{GetMaxVolume()} volume";
            return result;
        }
    }

    // Come back to this once we learn about abstract classes.
    public abstract class InventoryItem
    {
        private readonly float _volume;
        private readonly float _weight;

        protected InventoryItem(float volume, float weight)
        {
            if (volume <= 0f || weight <= 0f)
            {
                throw new ArgumentOutOfRangeException($"An item can't have {volume} volume or {weight} weight");
            }
            _volume = volume;
            _weight = weight;
        }

        // Returns a string representing the quantities of the item (volume & weight of the item)
        public abstract string Display();

        // Getters
        public float GetVolume()
        {
            return _volume;
        }

        public float GetWeight()
        {
            return _weight;
        }
    }

    public class Arrow : InventoryItem
    {
        public Arrow() : base(0.5f, 0.1f) { }

        public override string Display()
        {
            return $"An arrow with weight {GetWeight()} and volume {GetVolume()}";
        }
    }

    public class Bow : InventoryItem
    {
        public Bow() : base(4f, 1f) { }

        public override string Display()
        {
            return $"A bow with weight {GetWeight()} and volume {GetVolume()}";
        }
    }

    public class Rope : InventoryItem
    {
        public Rope() : base(1.5f, 1f) { }

        public override string Display()
        {
            return $"A rope with weight {GetWeight()} and volume {GetVolume()}";
        }
    }

    public class Water : InventoryItem
    {
        public Water() : base(3f, 2f) { }

        public override string Display()
        {
            return $"Water with weight {GetWeight()} and volume {GetVolume()}";
        }
    }

    public class Food : InventoryItem
    {
        public Food() : base(0.5f, 1f) { }

        public override string Display()
        {
            return $"Yummy food with weight {GetWeight()} and volume {GetVolume()}";
        }
    }

    public class Sword : InventoryItem
    {
        public Sword() : base(3f, 5f) { }

        public override string Display()
        {
            return $"A sharp sword with weight {GetWeight()} and volume {GetVolume()}";
        }
    }
}
