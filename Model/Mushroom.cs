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
    class Mushroom
    {
        //Constants
        public enum Type {Edible, Poisonous}
        public static readonly char[] CAP_SHAPE = {'b', 'c', 'x', 'f', 'k', 's'};
        public static readonly char[] CAP_SURFACE = { 'b', 'c', 'x', 'f', 'k', 's' };
        public static readonly char[] CAP_COLOR = { 'b', 'c', 'x', 'f', 'k', 's' };

        //Attributes
        //Class
        private Type type;
            //Vars
        private char capShape;
        private char capSurface;
        private char capColor;

        private char bruises;
        private char odor;

        private char gillAttachment;
        private char gillSpacing;
        private char gillSize;
        private char gillColor;

        private char stalkShape;
        private char stalkRoot;
        private char stalkSurfaceAboveRing;
        private char stalkSurfaceBelowRing;
        private char stalkColorAboveRing;
        private char stalkColorBelowRing;

        private char veilType;
        private char veilColor;

        private char ringNumber;
        private char ringType;

        private char sporePrintColor;
        private char population;
        private char habitad;

        //Constructor

    }
}
