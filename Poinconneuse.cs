using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using DXFLibrary;

namespace PoinconnerImage
{

    public struct Rec
    {
        public Point Point;
        public float Luminosite;
    }

    public class Poinconneuse
    {

        public Poinconneuse()
        {
        }

        public void Go(NameValueCollection Data)
        {
        }

        private void ConvertirEnDxf()
        {
            
            //﻿DXFLibrary.Document DocDXF = new DXFLibrary.Document();

            // DXFLibrary.Tables Table = new DXFLibrary.Tables();
            // DocDXF.SetTables(Table);

            // DXFLibrary.Table Claques = new DXFLibrary.Table("LAYER");
            // Table.addTable(Claques);

            // foreach (Rec pRect in _ListeTrous)
            // {
            //     DXFLibrary.Circle Cercle = new DXFLibrary.Circle(pRect.Point.X, pRect.Point.Y * -1, pRect.Luminosite * _ListePoincons[0], "Poinçonnage");
            //     DocDXF.add(Cercle);
            // }

            // _ListeTrous.Clear();

            // FileStream FichierDXF = new FileStream(_CheminDossierExport + "\\Test2.dxf", System.IO.FileMode.Create);
            // DXFLibrary.Writer.Write(DocDXF, FichierDXF);
            // FichierDXF.Close();

        }
    }
}
