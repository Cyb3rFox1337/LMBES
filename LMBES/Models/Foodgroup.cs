namespace LMBES.Models
{
    public class Foodgroup
    {
        protected int ID { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Foodgroup(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}