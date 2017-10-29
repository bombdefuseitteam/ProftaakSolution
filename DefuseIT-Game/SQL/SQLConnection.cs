using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DefuseIT_Game.SQL
{
    class SQLConnection
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        private string tablename;
        private Dictionary<string, int> list = new Dictionary<string, int>();
        private List<Dictionary<string, int>> xlist = new List<Dictionary<string, int>>();

        //Constructor
        public SQLConnection()
        {
            Initialize();
        }

        //Initialize vlaues
        private void Initialize()
        {
            server = "studmysql01.fhict.local";
            database = "dbi387895";
            password = "Hoihoi1995";
            uid = "dbi387895";
            tablename = "defuseit";
            string connectionString;
            connectionString = "Server=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }
        /// <summary>
        /// Maakt connectie tussen C# en de database
        /// </summary>
        /// <returns>is er connectie true/false indien false geeft error message.</returns>
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                /*
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Kan geen verbinding maken naar de SQL server", "DefuseIT-Game");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid SQL user/password", "DefuseIT-Game");
                        break;
                }
                */
                return false;
            }
        }
        /// <summary>
        /// sluit connectie tussen C# en database
        /// </summary>
        /// <returns>sluiten gelukt true/false</returns>
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"> naam van speler</param>
        /// <param name="score"> score van speler</param>
        public void Insert(string name, int score)
        {

            string query = "INSERT INTO `" + tablename + "` ( `name`, `score`) VALUES( '" + name + "', '" + score + "');";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                this.CloseConnection();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="colomn"></param>
        /// <param name="value"></param>
        public void Delete(string colomn, string value)
        {
            string query = "DELETE FROM defuseit WHERE " + colomn + "='" + value + "' ;";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public List<string> Select()
        {
            string query = "SELECT  * FROM defuseit ORDER BY score desc Limit 10";

            //Create a list to store the result
            List<string> scores = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {

                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    //string id = Convert.ToString(dataReader.GetInt32(0));
                    string name = dataReader.GetString(1);
                    string punten = Convert.ToString(dataReader.GetInt32(2));
                    string score = name + " " + punten;
                    scores.Add(score);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed

            }
            return scores;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            string query = "SELECT Count(*) FROM tableinfo";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

    }
}

