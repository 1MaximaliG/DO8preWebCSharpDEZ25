namespace Serien
{
    [Serializable]
    public class Hero
    {
        public string Name;
        public Hero Partner;

        [NonSerialized]
        public string stuff;

        private int _alter;

        public Hero() { }//brauchen wir für xml
        public Hero(string name, int alter)
        {
            Name = name;
            this._alter = alter;
        }
        public int getAge()
        {
            return _alter;
        }
    }
}
