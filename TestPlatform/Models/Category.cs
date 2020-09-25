namespace TestPlatform.Models
{
    public class Category
    {
        public int Id { get; }
        public string Name { get; }

        public Category(string name)
        {
            Name = name;
        }
    }
}