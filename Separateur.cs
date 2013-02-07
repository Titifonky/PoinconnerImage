using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using SD = System.Drawing;

namespace PoinconnerImage
{
    public class Poincon
    {
        public Double Diametre { get { return _Diametre; } }
        public float Min { get { return _Min; } }
        public float Max { get { return _Max; } }

        private Double _Diametre;
        private float _Min;
        private float _Max;

        public Poincon(Double Diametre, float Min, float Max)
        {
            _Diametre = Diametre;
            _Min = Min;
            _Max = Max;
        }
    }

    public class Separateurs
    {
        private Pen _Pen = Pens.Red;
        private PictureBox _Box;
        private int Tolerance = 2;
        private List<Separateur> _ListeSeps = new List<Separateur>();
        private List<Texte> _ListeTextes = new List<Texte>();
        private Graphics _Graphique;
        private List<Poincon> _ListePoincons = new List<Poincon>();

        public List<Texte> ListeTextes
        {
            get { return _ListeTextes; }
            set { _ListeTextes = value; }
        }

        public Separateurs(PictureBox Box, Double Echelle)
        {
            if (Box != null)
            {
                _Box = Box;
                _Graphique = _Box.CreateGraphics();
            }
        }

        public void Supprimer()
        {
            foreach (Separateur Sep in _ListeSeps)
            {
                Sep.Supprimer();
            }
            _ListeSeps.Clear();

            foreach (Texte Txt in _ListeTextes)
            {
                Txt.Supprimer();
            }
            _ListeTextes.Clear();

            _Box.Refresh();

        }

        public Separateur AjouterSeparateur(int No, int X)
        {
            if (X > _Box.Width || X < 0)
                return null;

            Separateur Sep = new Separateur(No, _Pen, X, _Graphique, _Box, _ListeSeps);
            if (Sep != null)
            {
                Sep.Tolerance = Tolerance;
                _ListeSeps.Add(Sep);
                _Box.Refresh();
                return Sep;
            }
            return null;
        }

        public void SupprimerSeparateur(Separateur Sep)
        {
            _ListeSeps.Remove(Sep);
            Sep.Supprimer();
            Sep = null;
            _Box.Refresh();
        }

        public Texte AjouterTexte(String Nom, Separateur Gauche, Separateur Droite)
        {
            if ((!String.IsNullOrEmpty(Nom)) || (Gauche != null) || (Droite != null))
            {
                Texte Text = new Texte(Nom, Gauche, Droite, _Graphique, _Box, _ListeTextes);
                if (Text != null)
                {
                    _ListeTextes.Add(Text);
                    _Box.Refresh();
                    return Text;
                }
            }
            return null;
        }

        public void SupprimerTexte(Texte Txt)
        {
            _ListeTextes.Remove(Txt);
            Txt.Supprimer();
            Txt = null;
            _Box.Refresh();
        }

    }

    public class Separateur
    {
        public int No { get { return _No; } }
        public int Tolerance { get; set; }
        public int X
        {
            get
            {
                return _X;
            }
            set
            {
                if ((value > 0) && (value < _Box.Width))
                {
                    _Depart.X = value;
                    _Fin.X = value;
                    _X = value;
                    _Box.Refresh();
                }
            }
        }

        private int _No;
        private Pen _Pen;
        private int _X;
        private SD.Point _Depart = new SD.Point();
        private SD.Point _Fin = new SD.Point();
        private Graphics _Graphique;
        private PictureBox _Box;
        private int _min = 0;
        private int _max = 10000;
        private List<Separateur> _ListeSep;

        private bool _Deplace = false;

        private PaintEventHandler _EvPaint;
        private MouseEventHandler _EvMsDown;
        private MouseEventHandler _EvMsMove;
        private MouseEventHandler _EvMsUp;

        public Separateur(int No, Pen Pen, int X, Graphics Graphique, PictureBox Box, List<Separateur> ListeSep)
        {
            if ((Pen != null) || (Box != null) || (ListeSep != null))
            {
                _No = No;
                _Pen = Pen;
                _X = X;
                _Graphique = Graphique;
                _Box = Box;
                _ListeSep = ListeSep;
                _Depart = new SD.Point(X, 0);
                _Fin = new SD.Point(X, Box.Height);
                _EvPaint = new PaintEventHandler(Box_Paint);
                _EvMsDown = new MouseEventHandler(Box_MouseDown);
                _EvMsMove = new MouseEventHandler(Box_MouseMove);
                _EvMsUp = new MouseEventHandler(Box_MouseUp);

                _Box.Paint += _EvPaint;
                _Box.MouseDown += _EvMsDown;
                _Box.MouseMove += _EvMsMove;
                _Box.MouseUp += _EvMsUp;
            }
        }

        public void Supprimer()
        {
            _Box.Paint -= _EvPaint;
            _Box.MouseDown -= _EvMsDown;
            _Box.MouseMove -= _EvMsMove;
            _Box.MouseUp -= _EvMsUp;

            _EvPaint = null;
            _EvMsDown = null;
            _EvMsMove = null;
            _EvMsUp = null;

            _Box.Refresh();
            _Box = null;
            _Graphique = null;
        }

        public bool IsPointOnLine(SD.Point Pt)
        {
            if (Math.Abs(this.X - Pt.X) <= Tolerance)
                return true;
            else
                return false;
        }

        private void Box_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(_Pen, _Depart, _Fin);
        }

        private void Box_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && this.IsPointOnLine(e.Location))
            {
                _Deplace = true;

                foreach (Separateur Sep in _ListeSep)
                {
                    if (Sep.No != _No)
                    {
                        if (Sep.X > _min && Sep.X < X)
                        {
                            _min = Sep.X;
                        }

                        if (Sep.X < _max && Sep.X > X)
                        {
                            _max = Sep.X;
                        }
                    }
                }
            }
        }

        private void Box_MouseMove(object sender, MouseEventArgs e)
        {
            if (_Deplace)
            {
                int Xtmp = e.Location.X;

                if (Xtmp > _min && Xtmp < _max)
                    X = Xtmp;

                _Box.Refresh();
            }
        }

        private void Box_MouseUp(object sender, MouseEventArgs e)
        {
            _Deplace = false;
            _min = 0;
            _max = 10000;
        }
    }

    public class Texte
    {
        public String Nom { get { return _Nom; } set { _Nom = value; } }
        public float Taille { set { _Police = new Font("Arial", value); ; } }
        public Separateur Gauche { get { return _Gauche; } }
        public Separateur Droite { get { return _Droite; } }

        private Font _Police = new Font("Arial", 10);
        private SolidBrush _Brosse = new SolidBrush(Color.Black);
        private StringFormat _Format = new StringFormat();
        private String _Nom;
        private Separateur _Gauche;
        private Separateur _Droite;
        private Graphics _Graphique;
        private PictureBox _Box;
        private List<Texte> _ListeText;

        private PaintEventHandler _EvPaint;

        public Texte(String Nom, Separateur Gauche, Separateur Droite, Graphics Graphique, PictureBox Box, List<Texte> ListeText)
        {
            if ((Gauche != null) || (Droite != null) || (Box != null) || (ListeText != null))
            {
                _Nom = Nom;
                _Gauche = Gauche;
                _Droite = Droite;
                _Graphique = Graphique;
                _Box = Box;
                _Format.Alignment = StringAlignment.Center;
                _Format.LineAlignment = StringAlignment.Center;
                _ListeText = ListeText;
                _EvPaint = new PaintEventHandler(Box_Paint);

                _Box.Paint += _EvPaint;
            }
        }

        public void Supprimer()
        {
            _Gauche = null;
            _Droite = null;
            _Box.Paint -= _EvPaint;
            _EvPaint = null;
            _Box.Refresh();
            _Box = null;
            _Police.Dispose();
            _Brosse.Dispose();
            _Format.Dispose();
            _Graphique = null;
        }

        private void Box_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString(_Nom, _Police, _Brosse, ((_Gauche.X + _Droite.X) / 2), 20, _Format);
        }
    }
}
