

namespace vsTest
{
    class Person
    {
        protected string name = "";
        protected int age = -1;
        protected List<string> info = new List<string>();
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        // 有参构造
        public Person()
        {

        }
        public Person(string name="",int age=-1)
        {
            this.name =  name;
            this.age = age;
        }

        public virtual void initInfo()
        {
            info.Add("name："+name);
            info.Add("age："+age.ToString());
        }
        public override string ToString()
        {
            initInfo();
            string ret = string.Join("；\n",(string[])info.ToArray());
            return ret;
        }
    }



    class Player:Person
    {
        private string gameId = "";
        public List<string> games = new List<string>();
        public string GameId
        {
            get {return gameId;}
            set {gameId=value;}
        }

        public Player(string name,int age, string gameId):base(name,age)
        {
            this.gameId = gameId;
        }

        public override void initInfo()
        {
            base.initInfo();
            info.Add(gameId);
            info.Add(string.Join(", ",(string[])games.ToArray()));
        }

    }

    
}