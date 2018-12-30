namespace CQRSBasicDemo.Domains.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public static User CreateNew(string name)
        {
            return new User
            {
                Name = name
            };
        }
    }
}
