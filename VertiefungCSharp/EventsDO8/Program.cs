namespace EventsDO8
{
    public class MyEventArgs : EventArgs
    {
        public string Operation { get; }
        public string Value { get; }
        public MyEventArgs(string op, string val)
        {
            Operation = op;
            Value = val;
        }
    }
    public class Repository
    {
        private List<string> _dataList;

        //private Action _dataChanged;
        //public event Action DataChanged
        //{
        //    add { _dataChanged += value; }
        //    remove { _dataChanged -= value; }
        //}
        //public event Action DataChanged;
        public event EventHandler<MyEventArgs> DataChanged;
        public Repository()
        {
            _dataList = new List<string>()
            {
                "Hallo",
                "C#"
            };
        }
        public void AddData(string s)
        {
            _dataList.Add(s);
            //_dataChanged.Invoke();
            DataChanged(this, new MyEventArgs("Add", s));
        }
        public void RemoveData(string s)
        {
            _dataList.Remove(s);
            //_dataChanged.Invoke();
            DataChanged(this, new MyEventArgs("Remove", s));
        }
        public List<string> GetAllData() { return _dataList; }
    }
    public class View
    {
        private Repository _repo;
        public View(Repository repository)
        {
            this._repo = repository;
            _repo.DataChanged += RepoDataChanged;
        }
        public void RepoDataChanged(object sender, MyEventArgs e)
        {
            Console.Clear();
            Console.WriteLine("Letzte Aktion:");
            Console.WriteLine(e.Operation + " " + e.Value);
            Console.WriteLine(sender.ToString());
            Console.WriteLine();
            ShowData();
        }
        public void ShowData()
        {
            List<string> liste = _repo.GetAllData();

            //Console.Clear();
            Console.WriteLine("Datenbestand:");

            foreach (string s in liste)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Repository r = new Repository();
            View v = new View(r);

            v.ShowData();

            string eingabe;
            do
            {
                eingabe = Console.ReadLine() ?? string.Empty;//konstrukt für Compiler
                if (eingabe != string.Empty)
                {
                    if (eingabe[0] == '-')
                    {
                        r.RemoveData(eingabe.Substring(1));
                    }
                    else
                    {
                        r.AddData(eingabe);
                    }
                }
            } while (eingabe != string.Empty);
        }
    }
}
