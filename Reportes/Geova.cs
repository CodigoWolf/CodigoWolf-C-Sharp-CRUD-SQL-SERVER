using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Entidad.Anime;
using System.Collections.Generic;

namespace Reportes
{
    public partial class Geova : DevExpress.XtraReports.UI.XtraReport
    {
        public Geova()
        {
            InitializeComponent();
        }

        private void Geova_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var lista = ((List<AnimeE>)this.objectDataSource1.DataSource);            
        }
    }
}
