using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NsPlages
{
    public class Plage
    {
        public Double Intitule { get { return _Intitule; } }
        public Double Min { get { return _Min; } }
        public Double Max { get { return _Max; } }

        private Double _Intitule;
        private Double _Min;
        private Double _Max;

        public Plage(Double Intitule, Double Min, Double Max)
        {
            _Intitule = Intitule;
            _Min = Min;
            _Max = Max;
        }
    }

    public class Plages
    {
        private Pen _Pen = Pens.Red;
        private PictureBox _Box;
        private int Tolerance = 3;
        private Double _Echelle = 1;
        private int _LgHistogramme = 0;
        private int _Plage = 0;
        private List<Separateur> _ListeSeps = new List<Separateur>();
        private List<Texte> _ListeTextes = new List<Texte>();
        private List<Plage> _ListePlages = new List<Plage>();

        public int LgHistogramme
        {
            get { return _LgHistogramme; }
            set
            {
                _LgHistogramme = value;
                _Plage = _Box.Width - (int)Math.Truncate((_Box.Width - _LgHistogramme) * 0.5);
            }
        }
        public int Plage { get { return _Plage; } }
        public Double Echelle { get { return _Echelle; } }

        public Plages(PictureBox Box, Double Echelle)
        {
            if (Box != null)
            {
                _Box = Box;
                _Echelle = Echelle;
            }
        }

        public void Intitules(List<String> ListeIntitules)
        {

            /// Si _ListeTextes n'est pas vide, on garde la position des séparateurs
            /// et on remplace simplement la valeur de la plage.
            for (int i = 0; i < Math.Min(ListeIntitules.Count, _ListeTextes.Count); i++)
            {
                _ListeTextes[i].Nom = ListeIntitules[i];
            }

            /// Si il y a de nouveaux intitulés, on rajoute
            /// un séparateur et un texte pour chacun
            if (ListeIntitules.Count > _ListeTextes.Count)
            {
                Separateur pSepG;

                int pDiv;

                /// S'il n'y a aucun séparateur, on met le premier
                if (_ListeSeps.Count == 0)
                    pSepG = AjouterSeparateur(0, 5);
                /// sinon on récupère le séparateur de droite du dernier texte
                else
                    pSepG = _ListeTextes[_ListeTextes.Count - 1].Droite;

                /// Si la distance entre le dernier séparateur et le bord de la boite est inférieur
                /// à 10px, on le déplace pour laisser un peu de place aux autres
                /// puis on calcul l'entraxe
                if ((_Box.Width - pSepG.X) < 10)
                {
                    Separateur pSepTmp = _ListeTextes[_ListeTextes.Count - 1].Gauche;
                    pDiv = (_Box.Width - 5 - pSepTmp.X) / (1 + ListeIntitules.Count - _ListeTextes.Count);
                    pSepG.X = pSepTmp.X + pDiv;
                }
                else
                    pDiv = (_Box.Width - 5 - pSepG.X) / (ListeIntitules.Count - _ListeTextes.Count);

                /// Et on ajoute les derniers intitulés
                for (int i = _ListeTextes.Count; i < ListeIntitules.Count; i++)
                {
                    Separateur pSepD = AjouterSeparateur(pSepG.No + 1, pSepG.X + pDiv);
                    AjouterTexte(ListeIntitules[i], pSepG, pSepD);
                    pSepG = pSepD;
                }
            }
            /// Sinon, on supprime ceux qui sont en trop
            else if (ListeIntitules.Count < _ListeTextes.Count)
            {
                if (ListeIntitules.Count == 0)
                    Supprimer();
                else
                    for (int i = (_ListeTextes.Count - 1); i >= ListeIntitules.Count; i--)
                    {
                        Texte pTxt = _ListeTextes[i];
                        SupprimerSeparateur(pTxt.Droite);
                        SupprimerTexte(pTxt);
                    }
            }

            _Box.Refresh();
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

        private Separateur AjouterSeparateur(int No, int X)
        {
            if (X > _Box.Width || X < 0)
                return null;

            Separateur Sep = new Separateur(this, No, _Pen, X, _Box, _ListeSeps);
            if (Sep != null)
            {
                Sep.Tolerance = Tolerance;
                _ListeSeps.Add(Sep);
                _Box.Refresh();
                return Sep;
            }
            return null;
        }

        private void SupprimerSeparateur(Separateur Sep)
        {
            _ListeSeps.Remove(Sep);
            Sep.Supprimer();
            Sep = null;
            _Box.Refresh();
        }

        private Texte AjouterTexte(String Nom, Separateur Gauche, Separateur Droite)
        {
            if ((!String.IsNullOrEmpty(Nom)) || (Gauche != null) || (Droite != null))
            {
                Texte Text = new Texte(Nom, Gauche, Droite, _Box, _ListeTextes);
                if (Text != null)
                {
                    _ListeTextes.Add(Text);
                    _Box.Refresh();
                    return Text;
                }
            }
            return null;
        }

        private void SupprimerTexte(Texte Txt)
        {
            _ListeTextes.Remove(Txt);
            Txt.Supprimer();
            Txt = null;
            _Box.Refresh();
        }

        public List<Plage> ListePlages()
        {
            List<Plage> pListePoincons = new List<Plage>();

            foreach (Texte pTxt in _ListeTextes)
            {
                String pNom = pTxt.Nom;

                if (String.IsNullOrWhiteSpace(pNom))
                    pNom = "0";

                Plage pPc = new Plage(Convert.ToDouble(pNom), pTxt.Droite.Valeur, pTxt.Gauche.Valeur);
                pListePoincons.Add(pPc);
            }

            return pListePoincons;
        }

        public List<int> ListeValeurs()
        {
            List<int> pListeValeurs = new List<int>();

            foreach (Separateur pSep in _ListeSeps)
            {
                pListeValeurs.Add(Convert.ToInt32(pSep.Valeur));
            }

            return pListeValeurs;
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
        public double Valeur
        {
            get
            {
                // Calcul des valeurs Min et Max en fonction des dimensions de la boite, de l'histogramme et de l'echelle
                // On prend comme reference le bord droit. Il faut inverser les valeurs
                Double pVal = (_Parent.Plage - X) * _Parent.Echelle / _Parent.LgHistogramme;

                if (pVal > _Parent.Echelle)
                    pVal = _Parent.Echelle;
                else if (pVal < 0)
                    pVal = 0;

                return pVal;

            }
            set
            {
                Double pVal = value;

                if (pVal > _Parent.Echelle)
                    pVal = _Parent.Echelle;
                else if (pVal < 0)
                    pVal = 0;

                // On calul le X
                X = Convert.ToInt32(_Parent.Plage - ((pVal * _Parent.LgHistogramme) / _Parent.Echelle));
            }
        }

        private Plages _Parent;
        private Font _Police = new Font("Arial", 10);
        private SolidBrush _Brosse = new SolidBrush(Color.Black);
        private StringFormat _Format = new StringFormat();
        private int _No;
        private Pen _Pen;
        private int _X;
        private Point _Depart = new Point();
        private Point _Fin = new Point();
        private PictureBox _Box;
        private int _min = 0;
        private int _max = 10000;
        private List<Separateur> _ListeSep;

        private bool _Deplace = false;

        private PaintEventHandler _EvPaint;
        private MouseEventHandler _EvMsDown;
        private MouseEventHandler _EvMsMove;
        private MouseEventHandler _EvMsUp;

        public Separateur(Plages Parent, int No, Pen Pen, int X, PictureBox Box, List<Separateur> ListeSep)
        {
            if ((Pen != null) || (Box != null) || (ListeSep != null))
            {
                _Parent = Parent;
                _No = No;
                _Pen = Pen;
                _X = X;
                _Box = Box;
                _ListeSep = ListeSep;
                _Depart = new Point(X, 0);
                _Fin = new Point(X, Box.Height);

                _Format.Alignment = StringAlignment.Center;
                _Format.LineAlignment = StringAlignment.Center;

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
        }

        public bool IsPointOnLine(Point Pt)
        {
            if (Math.Abs(this.X - Pt.X) <= Tolerance)
                return true;
            else
                return false;
        }

        private void Box_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Red, _Depart.X - 1, _Depart.Y + 15, 3, _Fin.Y);
            e.Graphics.DrawString(Convert.ToInt32(Valeur).ToString(), _Police, _Brosse, X, 5, _Format);
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
                _min += 3;
                _max -= 3;
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

        private Font _Police = new Font("Arial", 12, FontStyle.Bold);
        private SolidBrush _Brosse = new SolidBrush(Color.Black);
        private StringFormat _Format = new StringFormat();
        private String _Nom;
        private Separateur _Gauche;
        private Separateur _Droite;
        private PictureBox _Box;
        private List<Texte> _ListeText;

        private PaintEventHandler _EvPaint;

        public Texte(String Nom, Separateur Gauche, Separateur Droite, PictureBox Box, List<Texte> ListeText)
        {
            if ((Gauche != null) || (Droite != null) || (Box != null) || (ListeText != null))
            {
                _Nom = Nom;
                _Gauche = Gauche;
                _Droite = Droite;
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
        }

        private void Box_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString(_Nom, _Police, _Brosse, ((_Gauche.X + _Droite.X) / 2), 25, _Format);
        }
    }
}
