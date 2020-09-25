namespace TestPlatform.Models
{
    public class Test
    {
        public int Id { get; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int CategoryId { get; private set; }

        public Test(string name, string description, int categoryId)
        {
            Name = name;
            Description = description;
            CategoryId = categoryId;
        }
    }
}