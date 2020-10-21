using System;
using System.Collections.Generic;
using System.Configuration; //automatisch hinzugefügt, aber notwendig!!
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_DB_ZooManager
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            /// Verbindung aufbauen mit den ConnectionString
            /// Im Projektmappen-Explorer, rechte Mausclick auf Verweise
            /// und da "Verweis hinufügen..." auswählen
            /// Da System.comfiguration auswählen und auf OK drücken.
            /// 

            /// Jetzt können wir den Connection Programmieren:
            /// using System.Configuration ist notwendig um den ConfigurationManager aufrufen zu können!!
            /// Der connectionString Name finden wir beim rechte maus auf unsere Datenquelle, 
            /// dann  "Datenquelle mit Assistent konfiguruieren..."
            /// und da auf ZURÜCK clicken, dann ist ganz oben der "AR_CSHARP_DBConnectionString" Name ausgegraut zu sehen verfügbar!
            /// 

            string connectionString = ConfigurationManager.ConnectionStrings["WPF_DB_ZooManager.Properties.Settings.AR_CSHARP_DBConnectionString"].ConnectionString;
            /// Das hier macht die Verbindung zum Datenbank
        }
    }
}
