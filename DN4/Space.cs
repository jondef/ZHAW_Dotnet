using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DN4
{
    public partial class Form1 : Form
    {
        private IList<Orb> space = new List<Orb>();
        private Timer timer1;

        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            //Objekte im Weltall positionieren
            space.Add(new Planet("jupiter", 600, 400, -0.099, 0, 100));
            space.Add(new Spaceship(600, 230, 3, 0, 1));
            space.Add(new Planet("mars", 300, 400, 0, 1.5, 4));
            space.Add(new Planet("merkur", 200, 200, 0, -1.5, 4));


            //Timer implementieren. 
            //Löst vom benutzerdefinierte Ereignisse in einem bestimmten Intervall aus.
            timer1 = new Timer();
            timer1.Interval = 50;
            timer1.Start();
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        public void timer1_Tick(object sender, EventArgs eArgs)
        {
            foreach (Orb o in space) o.CalcVelocity(space);
            foreach (Orb o in space) o.Move();
            this.Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            foreach (Orb o in space) o.Draw(e.Graphics);
        }
    }
}