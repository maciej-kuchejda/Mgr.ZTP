namespace Kuchejda.ZTP.WebApi.Generatos
{
    public class IdGenerator : IIdGenerator
    {
        private readonly Random _rnd;
        private readonly List<int> _existingKeys;

        public IdGenerator()
        {
            _rnd = new Random();
            _existingKeys = new List<int>();
        }

        public int GenerateUniqueId(int amount)
        {
            int newId;
            do
            {
                newId = _rnd.Next(0, amount);
            } while (_existingKeys.Contains(newId));

            _existingKeys.Add(newId);

            return newId;
        }
    }
}
