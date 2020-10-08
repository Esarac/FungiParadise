using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FungiParadise.Model
{
    class Manager
    {
        //Attributes
        private List<Mushroom> dataSet;

        //Constructor
        private Manager(string path)
        {
            Load(path);
        }

        //Table
        public DataTable GenerateEmptyTable()
        {
            DataTable table = new DataTable();

            table.Columns.Add("TYPE", typeof(string));//0
            table.Columns.Add("CAP SHAPE", typeof(char));//1
            table.Columns.Add("CAP COLOR", typeof(char));//3
            table.Columns.Add("BRUISES", typeof(char));//4
            table.Columns.Add("ODOR", typeof(char));//5
            table.Columns.Add("GILL SIZE", typeof(char));//8
            table.Columns.Add("STALK SHAPE", typeof(char));//10
            table.Columns.Add("STALK ROOT", typeof(char));//11
            table.Columns.Add("RING NUMBER", typeof(char));//18
            table.Columns.Add("HABITAD", typeof(char));//22

            return table;
        }



        public DataTable GenerateDataTable()
        {
            DataTable table = GenerateEmptyTable();

            foreach (Mushroom mushroom in dataSet)
            {
                DataRow row = table.NewRow();

                row["TYPE"] = mushroom.Type;//0
                row["CAP SHAPE"] = mushroom.CapShape;//1
                row["CAP COLOR"] = mushroom.CapColor;//3
                row["BRUISES"] = mushroom.Bruises;//4
                row["ODOR"] = mushroom.Odor;//5
                row["GILL SIZE"] = mushroom.GillSize;//8
                row["STALK SHAPE"] = mushroom.StalkShape;//10
                row["STALK ROOT"] = mushroom.StalkRoot;//11
                row["RING NUMBER"] = mushroom.RingNumber;//18
                row["HABITAD"] = mushroom.Habitad;//22

                table.Rows.Add(row);
            }

            return table;
        }

        //Chart
        public DataTable GenerateTypeChart()//1
        {
            DataTable table = new DataTable();

            //Init
            table.Columns.Add("X", typeof(string));
            table.Columns.Add("Y", typeof(int));

            //Search
            int numE = 0;
            int numP = 0;
            foreach(Mushroom mushroom in dataSet)
            {
                if (mushroom.Type == Mushroom.MushroomType.Edible)
                    numE++;
                else if (mushroom.Type == Mushroom.MushroomType.Poisonous)
                    numP++;
            }

            //Values
            DataRow rowE = table.NewRow();
            rowE["X"] = Mushroom.MushroomType.Edible;
            rowE["Y"] = numE;
            table.Rows.Add(rowE);

            DataRow rowP = table.NewRow();
            rowP["X"] = Mushroom.MushroomType.Poisonous;
            rowP["Y"] = numP;
            table.Rows.Add(rowP);

            return table;
        }

        public DataTable GenerateOdorChart()//2
        {
            DataTable table = new DataTable();

            //Init
            table.Columns.Add("X", typeof(string));
            table.Columns.Add("Y", typeof(int));

            //Search
            int[] quantity = new int[Mushroom.ODOR.Length];
            foreach (Mushroom mushroom in dataSet)
            {
                bool found = false;
                for (int i = 0; (i < quantity.Length) && found; i++)
                {
                    if (Mushroom.ODOR[i].Equals(mushroom.Odor))
                    {
                        quantity[i]++;
                        found = true;
                    }
                }
            }

            //Values
            for (int i=0; i< quantity.Length; i++)
            {
                DataRow row = table.NewRow();

                row["X"] = Mushroom.ODOR[i];
                row["Y"] = quantity[i];

                table.Rows.Add(row);
            }

            return table;
        }

        public DataTable GenerateRingNumberChart()//3
        {
            DataTable table = new DataTable();

            //Init
            table.Columns.Add("X", typeof(int));
            table.Columns.Add("Y", typeof(int));

            //Search
            int[] quantity = new int[Mushroom.RING_NUMBER.Length];
            foreach (Mushroom mushroom in dataSet)
            {
                bool found = false;
                for (int i = 0; (i < quantity.Length) && found; i++)
                {
                    if (Mushroom.RING_NUMBER[i].Equals(mushroom.RingNumber))
                    {
                        quantity[i]++;
                        found = true;
                    }
                }
            }

            //Values
            for (int i = 0; i < quantity.Length; i++)
            {
                DataRow row = table.NewRow();

                row["X"] = i;
                row["Y"] = quantity[i];

                table.Rows.Add(row);
            }

            return table;
        }

        public DataTable GenerateBruisesChart()//4
        {
            DataTable table = new DataTable();

            //Init
            table.Columns.Add("X", typeof(string));
            table.Columns.Add("Y", typeof(int));

            //Search
            int[] quantity = new int[Mushroom.BRUISES.Length];
            foreach (Mushroom mushroom in dataSet)
            {
                bool found = false;
                for (int i = 0; (i < quantity.Length) && found; i++)
                {
                    if (Mushroom.BRUISES[i].Equals(mushroom.Bruises))
                    {
                        quantity[i]++;
                        found = true;
                    }
                }
            }

            //Values
            for (int i = 0; i < quantity.Length; i++)
            {
                DataRow row = table.NewRow();

                row["X"] = Mushroom.BRUISES[i];
                row["Y"] = quantity[i];

                table.Rows.Add(row);
            }

            return table;
        }

        public DataTable GenerateCapColorChart()//5
        {
            DataTable table = new DataTable();

            //Init
            table.Columns.Add("X", typeof(string));
            table.Columns.Add("Y", typeof(int));

            //Search
            int[] quantity = new int[Mushroom.CAP_COLOR.Length];
            foreach (Mushroom mushroom in dataSet)
            {
                bool found = false;
                for (int i = 0; (i < quantity.Length) && found; i++)
                {
                    if (Mushroom.CAP_COLOR[i].Equals(mushroom.CapColor))
                    {
                        quantity[i]++;
                        found = true;
                    }
                }
            }

            //Values
            for (int i = 0; i < quantity.Length; i++)
            {
                DataRow row = table.NewRow();

                row["X"] = Mushroom.CAP_COLOR[i];
                row["Y"] = quantity[i];

                table.Rows.Add(row);
            }

            return table;
        }

        //Load
        public void Load(string path)
        {
            string[] info = File.ReadAllLines(path);
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");

            for (int i = 1; i < info.Length; i++)
            {
                //Split
                string[] dataInfo = Regex.Split(info[i], ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                //...

                try
                {
                    //Type
                    Mushroom.MushroomType type = Mushroom.MushroomType.Edible;//0
                    if (dataInfo[0].Equals("e"))
                        type = Mushroom.MushroomType.Edible;
                    else if (dataInfo[0].Equals("p"))
                        type = Mushroom.MushroomType.Poisonous;

                    //Info
                    char capShape = Char.Parse(dataInfo[1]);//1
                    char capColor = Char.Parse(dataInfo[3]);//3
                    char bruises = Char.Parse(dataInfo[4]);//4
                    char odor= Char.Parse(dataInfo[5]);//5
                    char gillSize= Char.Parse(dataInfo[8]);//8
                    char stalkShape= Char.Parse(dataInfo[10]);//10
                    char stalkRoot= Char.Parse(dataInfo[11]);//11
                    char ringNumber= Char.Parse(dataInfo[18]);//18
                    char habitad= Char.Parse(dataInfo[22]);//22

                    //Add
                    Mushroom mushroom = new Mushroom(type, capShape, capColor, bruises, odor, gillSize, stalkShape, stalkRoot, ringNumber, habitad);
                    dataSet.Add(mushroom);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Error en dato!");
                }
                //...
            }
        }


    }
}
