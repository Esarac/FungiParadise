using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace FungiParadise.Model
{
    public class Mushroom
    {
        //Constants
        public enum MushroomType {Edible, Poisonous}
        public static readonly char[] CAP_SHAPE = {'b', 'c', 'x', 'f', 'k', 's'};//1
        public static readonly char[] CAP_COLOR = {'n', 'b', 'c', 'g', 'r', 'p', 'u', 'e', 'w', 'y'};//3
        public static readonly char[] BRUISES = {'t', 'f'};//4
        public static readonly char[] ODOR = {'a', 'l', 'c', 'y', 'f', 'm', 'n', 'p', 's'};//5
        public static readonly char[] GILL_SIZE = {'b', 'n'};//8
        public static readonly char[] STALK_SHAPE = {'e', 't'};//10
        public static readonly char[] STALK_ROOT = {'b', 'c', 'u', 'e', 'z', 'r', '?' };//11
        public static readonly char[] RING_NUMBER = {'n', 'o', 't' };//18
        public static readonly char[] HABITAD = { 'g', 'l', 'm', 'p', 'u', 'w', 'd' };//22

        //Attributes
            //Class
        private MushroomType type;//0
            //Vars
        private char capShape;//1
        private char capColor;//3
        private char bruises;//4
        private char odor;//5
        private char gillSize;//8
        private char stalkShape;//10
        private char stalkRoot;//11
        private char ringNumber;//18
        private char habitad;//22

        //Properties
        public MushroomType Type { get { return type; } set { type = value; } }
        public char CapShape { get { return capShape; } set { capShape = value; } }
        public char CapColor { get { return capColor; } set { capColor = value; } }
        public char Bruises { get { return bruises; } set { bruises = value; } }
        public char Odor { get { return odor; } set { odor = value; } }
        public char GillSize { get { return gillSize; } set { gillSize = value; } }
        public char StalkShape { get { return stalkShape; } set { stalkShape = value; } }
        public char StalkRoot { get { return stalkRoot; } set { stalkRoot = value; } }
        public char RingNumber { get { return ringNumber; } set { ringNumber = value; } }
        public char Habitad { get { return habitad; } set { habitad = value; } }

        //Constructor
        public Mushroom(MushroomType type, char capShape, char capColor, char bruises, char odor, char gillSize, char stalkShape, char stalkRoot, char ringNumber, char habitad)
        {
            if (CAP_SHAPE.Contains(capShape) && CAP_COLOR.Contains(capColor) && BRUISES.Contains(bruises) && ODOR.Contains(odor) && GILL_SIZE.Contains(gillSize) && STALK_SHAPE.Contains(stalkShape) && STALK_ROOT.Contains(stalkRoot) && RING_NUMBER.Contains(ringNumber) && HABITAD.Contains(habitad))
            {
                this.type = type;

                this.capShape = capShape;
                this.capColor = capColor;

                this.bruises = bruises;
                this.odor = odor;

                this.gillSize = gillSize;

                this.stalkShape = stalkShape;
                this.stalkRoot = stalkRoot;

                this.ringNumber = ringNumber;

                this.habitad = habitad;
            }
            else
            {
                Console.WriteLine("Error bip bup");
            }
        }



    }
}
