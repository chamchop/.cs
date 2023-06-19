namespace Advanced.Structures
{
    public readonly struct Marvel
    {
        private readonly string _name;
        
        public string CharacterName
        {
            get
            {
                return _name;
            }
        }

        public void PrintCharacterName()
        {
            Console.WriteLine(this.CharacterName);
        }

        public Marvel(string character)
        {
            this._name = character;
        }
    }
}
