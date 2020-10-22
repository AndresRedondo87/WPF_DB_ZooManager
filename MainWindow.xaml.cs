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

using System.Data.SqlClient;    // für SQL Verbindung
using System.Data;

namespace WPF_DB_ZooManager
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// Datenbank Verbindung mit den ConnectionString
        /// es braucht zuerst ein "using System.Data.SqlClient;    // für SQL Verbindung" ganz oben hinzugefügt zu bekommen.
        /// Hier deklariert so wir es in unsere neue Methoden verwenden können!
        SqlConnection sqlConnection;
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
            /// 

            /// Um SQL Abfragen zu machen: rechte Maus auf unsere Datenverbindung und "Neue Abfrage" auswählen.
            /// Das offnet uns eine neue SQL Query.
            /// 



            /// Datenbank Verbindung mit den ConnectionString
            /// es braucht zuerst ein "using System.Data.SqlClient;    // für SQL Verbindung" ganz oben hinzugefügt zu bekommen.
            /// 
            /// am anfang von MainWindow deklarieren wir den:  SqlConnection sqlConnection;
            /// wir setzen es...
            sqlConnection = new SqlConnection(connectionString);

            //wir rufen die Methode um die Zoos angezeigt zu bekommen:
            ShowZoos();
            ShowAllAnimals();

            /// ShowAssociatedAnimals(2);    //1 fest als test...
            /// Jetzt richtig als Selected ZooID Index...
            /// braucht irgendwie noch einen trigger dafür! sollte aber gehen!, ich mache mein mittel Commit und korrigiere was nötig sein könnte
            /// ShowAssociatedAnimals(listZoos.SelectedIndex);
            /// weitere versuche
            /// if (listZoos.SelectedValue.ToString() != string.Empty)
            /// {
            ///    ShowAssociatedAnimals((int)listZoos.SelectedValue);
            /// }
            /// EINFACH NICHT HIER AUFZURUFEN!!! SONDERN IN DER EVENT METHODE!!!!!
            /// Die verbindete tiere unter ein Zoo werden nur aufgerufen wenn ein Zoo ausgewählt worden ist!!!!
            
        }

        // Selber erstellen eine Methode um die Animals anzuzeigen. try and catch blocks. 
        public void ShowAllAnimals()
        {
            try
            {
                string query = "SELECT * FROM Animal";     
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);   
                using (sqlDataAdapter)
                {
                    DataTable animalTable = new DataTable();
                    sqlDataAdapter.Fill(animalTable);
                    //listAllAnimals ist der Name unserer ListBox...:
                    //welche Informationen der Tabelle in unserem DataTablesollen in unsere Listbox angezeigt werden
                    listAllAnimals.DisplayMemberPath = "Name";
                    //welche Wert soll gegeben werden, wenn eines unsere Items von der ListBox ausgewählt wird
                    listAllAnimals.SelectedValuePath = "Id";
                    /// festlegen dass DataTable ruft die Tabelle animalTable, 
                    /// die eigentlich von unserer adapter kommt, und deren Query "SELECT * FROM Animal"; war in der ConnectionString zu unserer DB
                    listAllAnimals.ItemsSource = animalTable.DefaultView;
                }

            }
            catch (Exception e)
            {
                string exceptionTitle = "ANIMALS HABEN EINE EXCEPTION AUSGELÖST! App nicht richtig geladen!";
                MessageBox.Show(e.ToString(), exceptionTitle, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }

        // wir erstellen eine Methode um die Zoos anzuzeigen.
        // in solche Methoden kann viel schief gehen... viele Exceptions könnte kommen, so am Besten IMMER mit try and catch blocks arbeiten.
        public void ShowZoos()
        {
            try
            {
                //string query = "SELECT * FROM Zoo2"; //UM DIE EXCEPTIONS TRYCATCH TESTEN
                string query = "SELECT * FROM Zoo";     //wir setzen einfach den SQL Query inhalt in ein string.
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);   //SqlDataAdapter mit unsere Query und die Connection...
                                                                                            //damit können wir die DB Tabelle als ein C# Objekt verwenden!

                using (sqlDataAdapter)
                {
                    //hier können wir die DataTable verwenden...
                    DataTable zooTable = new DataTable();
                    sqlDataAdapter.Fill(zooTable);      //zooTable bekommt die Tabelle von DB


                    //listZoos ist der Name unserer ListBox...:
                    //welche Informationen der Tabelle in unserem DataTablesollen in unsere Listbox angezeigt werden
                    listZoos.DisplayMemberPath = "Location";
                    //welche Wert soll gegeben werden, wenn eines unsere Items von der ListBox ausgewählt wird
                    listZoos.SelectedValuePath = "Id";

                    /// festlegen dass DataTable ruft die Tabelle zooTable, 
                    /// die eigentlich von unserer adapter kommt, und deren Query "SELECT * FROM Zoo"; war in der ConnectionString zu unserer DB
                    listZoos.ItemsSource = zooTable.DefaultView;
                }

            }
            catch (Exception e)
            {
                string exceptionTitle = "WIR HABEN EINE EXCEPTION AUSGELÖST! App nicht richtig geladen!";
                MessageBox.Show(e.ToString(), exceptionTitle, MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }
            
        }


        /// ICH VERSUCHE zu erstellen: eine Methode um die Animals in einem Zoo anzuzeigen.
        /// IMMER mit try and catch blocks arbeiten.
        /// public void ShowAssociatedAnimals(int zooId) //
        /// ShowAssociatedAnimals((int)listZoos.SelectedValue);
        /// casting als int auch nötig, das geht aber er macht es OHNE PARAMETER!!
        /// Es funktioniert da die  listZoos.SelectedValue braucht nicht als Parameter übergegeben sein sondern es ist einfach da!

        public void ShowAssociatedAnimals()
        {
            // Beim Zoo löschen wird hier eine Exception geworfen, da listZoos.SelectedValue leer wird.
            // um es umzugehen einfach mit einem IF vermeiden.
            if (listZoos.SelectedValue == null)
            {
                return;//einfach diese Methode verlassen
                //könnte man auch das ganze in ein if (listZoos.SelectedValue != null) reinpachen, dies hier ist aber einfacher :)
            }
            try
            {
                /*
                //MEINE OPTION: Funktioniert auch und "Einfacher":
                string query = $"SELECT a.Name FROM Animal a INNER JOIN ZooAnimal za on a.Id = za.AnimalId WHERE za.ZooId = {listZoos.SelectedValue}";
                //string query = $"SELECT * FROM Animal a INNER JOIN ZooAnimal za on a.Id = za.AnimalId WHERE za.ZooId = @ZooId";
                //@ZooId wäre eine Variable!!
                // NEUEN SQL Query inhalt in ein string. KORRIGIERT
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                // SqlDataAdapter mit unsere Query und die Connection...
                // damit können wir die DB Tabelle als ein C# Objekt verwenden!

                using (sqlDataAdapter)
                {
                    //hier können wir die DataTable verwenden...
                    DataTable associatedAnimalsTable = new DataTable();
                    sqlDataAdapter.Fill(associatedAnimalsTable);      //zooTable bekommt die Tabelle von DB


                    //listAssociatedAnimals ist der Name unserer ListBox...:
                    //welche Informationen der Tabelle in unserem DataTablesollen in unsere Listbox angezeigt werden
                    listAssociatedAnimals.DisplayMemberPath = "Name";
                    // HIER HATTE ICH IMMER NOCH LOCATION,DESWEGEN BLIEB ES LEER!!
                    //welche Wert soll gegeben werden, wenn eines unsere Items von der ListBox ausgewählt wird
                    listAssociatedAnimals.SelectedValuePath = "Id";

                    /// festlegen dass DataTable ruft die Tabelle zooTable, 
                    /// die eigentlich von unserer adapter kommt, und deren Query "SELECT * FROM Zoo"
                    /// war in der ConnectionString zu unserer DB
                    listAssociatedAnimals.ItemsSource = associatedAnimalsTable.DefaultView;
                }


                */
                //ENDE MEINE OPTION



                //LEHRER OPTION:
                
                //string query = $"SELECT a.Name FROM Animal a INNER JOIN ZooAnimal za on a.Id = za.AnimalId WHERE za.ZooId = {zooId}";
                string query = $"SELECT * FROM Animal a INNER JOIN ZooAnimal za on a.Id = za.AnimalId WHERE za.ZooId = @ZooId";
                //@ZooId ist eine Variable!!
                // NEUEN SQL Query inhalt in ein string. KORRIGIERT
                //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                // hier zieht er sich diese command AUS DEM AR***?!?!?!
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                // SqlDataAdapter mit unsere Query und die Connection...
                // damit können wir die DB Tabelle als ein C# Objekt verwenden!

                using (sqlDataAdapter)
                {
                    //und hier wird den Commando verwendet...einfach so...
                    sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);   //HIER wird der Wert für unsere @ZooId Parameter gesetzt!!

                    //hier können wir die DataTable verwenden...
                    DataTable associatedAnimalsTable = new DataTable();
                    sqlDataAdapter.Fill(associatedAnimalsTable);      //zooTable bekommt die Tabelle von DB


                    //listAssociatedAnimals ist der Name unserer ListBox...:
                    //welche Informationen der Tabelle in unserem DataTablesollen in unsere Listbox angezeigt werden
                    listAssociatedAnimals.DisplayMemberPath = "Name";
                    // HIER HATTE ICH IMMER NOCH LOCATION,DESWEGEN BLIEB ES LEER!!
                    //welche Wert soll gegeben werden, wenn eines unsere Items von der ListBox ausgewählt wird
                    listAssociatedAnimals.SelectedValuePath = "Id";

                    /// festlegen dass DataTable ruft die Tabelle zooTable, 
                    /// die eigentlich von unserer adapter kommt, und deren Query "SELECT * FROM Zoo"
                    /// war in der ConnectionString zu unserer DB
                    listAssociatedAnimals.ItemsSource = associatedAnimalsTable.DefaultView;
                }
                
                //ENDE LEHRER OPTION
            }
            catch (Exception e)
            {
                string exceptionTitle = "ASSOCIATEDANIMALS HAT EINE EXCEPTION AUSGELÖST! App nicht richtig geladen!";
                MessageBox.Show(e.ToString(), exceptionTitle, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }

        private void listZoos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /// MessageBox.Show(listZoos.SelectedValue.ToString());
            /// ZwischenStep zum bestätigen der ZooId, nicht mehr nötig
            //ShowAssociatedAnimals((int)listZoos.SelectedValue);
            //casting als int auch nötig, das geht aber er macht es OHNE PARAMETER!!
            ShowAssociatedAnimals();
        }

        private void listAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //NOCH NICHTS HIER?, ich glaube nicht, sein Wert wird einfach via listAnimals.SelectedValue aufrufbar sein!
        }


        private void deleteZoo_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Lösche Zoo");

            try
            {
                string query = "DELETE FROM Zoo WHERE Id = @ZooId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                //sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValuePath); //FALSCH beim Autofill aufpassen!!
                sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)    //e ist schon verwendet...
            {
                MessageBox.Show(ex.ToString(), "exception in Delete Zoo Button", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            finally
            {
                //verbindung MUSS geschlossen werden.
                sqlConnection.Close();
                ShowZoos();// anzeige aktualisieren um zu sehen dass es doch gelöscht worden ist
            }
            /// Nachdem ein Zoo gelöscht aus Zoo Tabelle wird,die Entsprechende einträgen unter ZooAnimal
            /// müssen auch entsprechend gelöscht/ignoriert werden.
            /// Dafür geht er zu ZooAnimal rechtemaus/Tabellendefinition öffnen und da hat er folgendes hinzugefügt:
            /// PRIMARY KEY CLUSTERED([Id] ASC),        /// WAR SCHON DA!!!
            /// --vor den CONSTRAIST für die FOREIGN KEYS.
            /// UND UN DER Zoo Fk wird am Ende "ON DELETE CASCADE" hinzugefügt.
            /// EIGENTLICH AUF BEIDE FK, auch für ANIMALS hinzugefügt.
            /// Damit wird, wenn ein Zoo/animal gelöscht wird, wird ALLES was zu ihn verbunden ist auch gelöscht!! SEHR VORSICHTIG ANWENDEN!!


        }
        private void removeAnimal_Click(object sender, RoutedEventArgs e)
        {

        }
        private void addZoo_Click(object sender, RoutedEventArgs e)
        {

        }
        private void updateZoo_Click(object sender, RoutedEventArgs e)
        {

        }
        private void addAnimal_Click(object sender, RoutedEventArgs e)
        {

        }
        private void updateAnimal_Click(object sender, RoutedEventArgs e)
        {

        }
        private void addAnimalToZoo_Click(object sender, RoutedEventArgs e)
        {

        }
        private void deleteAnimal_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
