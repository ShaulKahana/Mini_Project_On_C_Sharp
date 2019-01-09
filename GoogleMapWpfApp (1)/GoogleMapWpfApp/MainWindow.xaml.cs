using System;
using System.Windows;


namespace GoogleMapWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string source;
        string dest;
        algo.TravelType travelType;
        int distance = -1;
        private TimeSpan duration;

        public MainWindow()
        {
            InitializeComponent();
            TravelModeComboBox.ItemsSource = Enum.GetValues(typeof(algo.TravelType));
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            source = sourcePlaceAutoCompleteUC.Text;
            dest = destPlaceAutoCompleteUC.Text;
            travelType = (algo.TravelType)TravelModeComboBox.SelectedItem;

            System.ComponentModel.BackgroundWorker work = new System.ComponentModel.BackgroundWorker();
            work.DoWork += W_DoWork;
            work.RunWorkerCompleted += W_RunWorkerCompleted;
            work.RunWorkerAsync();

        }

        private void W_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                distance = algo.GoogleApiFunc.CalcDistance(source, dest, travelType);
                duration = algo.GoogleApiFunc.CalcDuration(source, dest, travelType);
            }
            catch (Exception)
            {
                distance = -1;
            }
        }
        private void W_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (distance != -1)
            {
                if (distance < 1000)
                    distanceResult.Content = distance + " meters";
                else
                    distanceResult.Content = distance / 1000.0 + " km";

                durationResult.Content = duration.ToString();
            }
            else
            {
                distanceResult.Content = "no result";
                durationResult.Content = "no result";
            }
        }


    }
}
