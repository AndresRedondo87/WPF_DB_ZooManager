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
            //////////////////////////////////////////////////////////
            /// VIDEO 105: DIE DB TEIL HIER ERKLÄRT
            /// 
            ///  Wir werden ein WPF UI (WPF-APP PROJEKT!) mit den Zoos und die entsprechende Tiere die diese Zoos haben.
            ///  Mit add, delete und update Buttons für Zoo und Animal Tabellen
            ///  Und natürlich Zwei Buttons zum Tier zum Zoo hinzufügen und delete Tier.
            ///  
            ///  Server Explorer unter Ansicht öffnen.
            ///  Da Die Datenverbindungen öffnen.
            ///  Tabellen, neue Tabelle hinzufügen.
            ///  [Table] mit Zoo ersetzen.
            ///  In der rechte Seite , öffnen wir die Identitätspezifikation und setzen es auf true.
            ///  Es soll true true, 1, 1 für die incrementierung zeigen.
            ///  Wir hinzufügen eine Spalte Location in diese Tabelle Zoo.(einfach wie in Excel eintragen.
            ///  Name Location, NULL-werte zulassen deaktivieren.
            ///  Auf aktualisieren oben drücken, um die Tabelle zu wirklich erstellen.
            ///  Sobald es erledigt ist, auf "Datenbank aktualisieren" drücken und dann wird es in DB aktualisiert.
            ///  Bestätigen in Server-Explorer, beim aktualisieren Button und den Ordner Tabellen sollte Zoo enthalten.
            ///  TABELLEN NAMEN VERWENDEN SINGULAR FORMEN, keon Zoos oder TIere...
            ///  
            ///  Um Werte in die Tabelle einzutragen, rechte maus auf Zoo Tabelle und "TabellenDaten anzeigen" auswählen.
            ///  Da können wir so viel wie wir wollen eintragen, einfach verschiedenen Städte Namen.
            ///  
            ///  Datenquelle wird jetzt gebraucht.
            ///  Unter Ansicht, weitere Fenster, Datenquelle (UMSCHALT+Alt+D) auswählen.
            ///  Neues fenster, da auf "Neue Datenquelle hinzufügen" clicken
            ///  (wenn es nicht geht, wenn es ausgegraut ist, einfach Visual Studio neustarten und dann geht es)
            ///  Datenbank, weiter, Dataset, weiter, "ja, vertrauliche Daten in die Verbindungszeichenfolge einschließen" markieren,
            ///  "Zeigen Sie die Verbindungszeichenfolge..." kann man auch markieren um zu sehen welche Verbindung daraus wird...
            ///  weiter, dann ja und entsprechende Name für unsere ConnectionString eingeben (falls es nicht schon vorgeschlagen ist)
            ///  DIESE NAME AUFSCHREIBEN, BZW MERKEN, ES WIRD SPÄTER GEBRAUCHT! (kann man aber später nachholen...)
            ///  weiter, DB Tabellen auswählen,und entsprechende Name für unsere DBDataSet eingeben(falls es nicht schon vorgeschlagen ist)
            ///  und FertigStellen.
            ///  Jetzt in Datenquellen haben wir unsere DataSet.
            /// 
            //////////////////////////////////////////////////////////


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
