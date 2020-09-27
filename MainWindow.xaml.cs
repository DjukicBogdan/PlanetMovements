using System;
using System.Collections.Generic;
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
using System.Windows.Threading;

namespace PlanetsMovements
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public DateTime vreme = new DateTime();
        public DateTime vreme2000 = new DateTime();      
        public Planet mercur = new Planet();
        public Planet venera = new Planet();
        public Planet zemlja = new Planet();
        public Planet mesec = new Planet();
        public Planet mars = new Planet();
        public Planet jupiter = new Planet();
        public Planet saturn = new Planet();
        public Planet uran = new Planet();
        public Planet neptun = new Planet();
        public Planet pluton = new Planet();

        public MainWindow()
        {
            InitializeComponent();
            vreme2000 = vreme2000.AddYears(2019);
            vreme = DateTime.Now;
            datePicker.DisplayDate = DateTime.Now;
            TimerSet();         
            GetPositionOfPlanets();                      
        }

        private void TimerSet()
        {
            vreme = DateTime.Now;
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            dispatcherTimer.IsEnabled = true;
            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            vreme = vreme.AddSeconds(1);
            LabelVreme.Content = vreme.ToString();
            MovePlanets();
            MoveClock();
        }     

        public void MoveClock()
        {
            RotateTransform rotateTransformClockHour = new RotateTransform((360 / 12) * vreme.Hour  + (vreme.Minute / 2));
            rotateTransformClockHour.CenterX = 400;
            rotateTransformClockHour.CenterY = 400;
            CanvasClockHour.RenderTransform = rotateTransformClockHour;

            RotateTransform rotateTransformClockMin = new RotateTransform((360 / 60) * vreme.Minute);
            rotateTransformClockMin.CenterX = 400;
            rotateTransformClockMin.CenterY = 400;
            CanvasClockMin.RenderTransform = rotateTransformClockMin;

            RotateTransform rotateTransformClockSec = new RotateTransform((360 / 60) * vreme.Second);
            rotateTransformClockSec.CenterX = 400;
            rotateTransformClockSec.CenterY = 400;
            CanvasClockSec.RenderTransform = rotateTransformClockSec;
        }

        public void MovePlanets()
        {           
            int timeYearInMinutes = ((((int)vreme.Month * 30 - 30) + vreme.Day)*24) + vreme.Hour;
            RotateTransform rotateTransformMercur = new RotateTransform(((360 / 0.246) / (365 * 24)) * timeYearInMinutes + mercur.currenPosition);
            RotateTransform rotateTransformVenera = new RotateTransform(((360 / 0.615) / (365 * 24)) * timeYearInMinutes + venera.currenPosition);
            RotateTransform rotateTransformZemlja = new RotateTransform(((360 / 0.99) / (365 * 24)) * timeYearInMinutes + zemlja.currenPosition);
            RotateTransform rotateTransformHorizont = new RotateTransform((360 / 24) * vreme.Hour + (vreme.Minute / 2) + 160);
            RotateTransform rotateTransformMesec = new RotateTransform(((360 / 0.083) / (365 * 24)) * timeYearInMinutes + mesec.currenPosition);
            RotateTransform rotateTransformMars = new RotateTransform(((360 / 1.88) / (365 * 24)) * timeYearInMinutes + mars.currenPosition);
            RotateTransform rotateTransformJupiter = new RotateTransform(((360 / 11.86) / (365 * 24)) * timeYearInMinutes + jupiter.currenPosition);
            RotateTransform rotateTransformSaturn = new RotateTransform(((360 / 29.46) / (365 * 24)) * timeYearInMinutes + saturn.currenPosition);
            RotateTransform rotateTransformUran = new RotateTransform(((360 / 84.01) / (365 * 24)) * timeYearInMinutes + uran.currenPosition);
            RotateTransform rotateTransformNeptun = new RotateTransform(((360 / 164.79) / (365 * 24)) * timeYearInMinutes + neptun.currenPosition);
            RotateTransform rotateTransformPluton = new RotateTransform(((360 / 248.5) / (365 * 24)) * timeYearInMinutes + pluton.currenPosition);
            rotateTransformMercur.CenterX = 400;
            rotateTransformMercur.CenterY = 400;
            rotateTransformVenera.CenterX = 400;
            rotateTransformVenera.CenterY = 400;
            rotateTransformZemlja.CenterX = 400;
            rotateTransformZemlja.CenterY = 400;
            rotateTransformHorizont.CenterX = 396;
            rotateTransformHorizont.CenterY = 1;
            rotateTransformMesec.CenterX = 15;
            rotateTransformMesec.CenterY = 15;
            rotateTransformMars.CenterX = 400;
            rotateTransformMars.CenterY = 400;
            rotateTransformJupiter.CenterX = 400;
            rotateTransformJupiter.CenterY = 400;
            rotateTransformSaturn.CenterX = 400;
            rotateTransformSaturn.CenterY = 400;
            rotateTransformUran.CenterX = 400;
            rotateTransformUran.CenterY = 400;
            rotateTransformNeptun.CenterX = 400;
            rotateTransformNeptun.CenterY = 400;
            rotateTransformPluton.CenterX = 400;
            rotateTransformPluton.CenterY = 400;
            CanvasMercur.RenderTransform = rotateTransformMercur;
            CanvasVenera.RenderTransform = rotateTransformVenera;
            CanvasZemlja.RenderTransform = rotateTransformZemlja;
            CanvasHorizont.RenderTransform = rotateTransformHorizont;
            CanvasMesec.RenderTransform = rotateTransformMesec;
            CanvasMars.RenderTransform = rotateTransformMars;
            CanvasJupiter.RenderTransform = rotateTransformJupiter;
            CanvasSaturn.RenderTransform = rotateTransformSaturn;
            CanvasUran.RenderTransform = rotateTransformUran;
            CanvasNeptun.RenderTransform = rotateTransformNeptun;
            CanvasPluton.RenderTransform = rotateTransformPluton;
        }

        public void GetPositionOfPlanets()
        {  // year 2020
            mercur.positionOnTime2020 = 274.19;
            mercur.currenPosition = mercur.positionOnTime2020;
            venera.positionOnTime2020 = 374.22;
            venera.currenPosition = venera.positionOnTime2020;
            zemlja.positionOnTime2020 = 101.01;
            zemlja.currenPosition = zemlja.positionOnTime2020;
            mesec.positionOnTime2020 = 345.39;
            mesec.currenPosition = mesec.positionOnTime2020;
            mars.positionOnTime2020 = 238.21;
            mars.currenPosition = mars.positionOnTime2020;
            jupiter.positionOnTime2020 = 276.40;
            jupiter.currenPosition = jupiter.positionOnTime2020;
            saturn.positionOnTime2020 = 291.23;
            saturn.currenPosition = saturn.positionOnTime2020;
            uran.positionOnTime2020 = 32.42;
            uran.currenPosition = uran.positionOnTime2020;
            neptun.positionOnTime2020 = 346.16;
            neptun.currenPosition = neptun.positionOnTime2020;
            pluton.positionOnTime2020 = 292.23;
            pluton.currenPosition = pluton.positionOnTime2020;
        }

        private void ButtonStartStop_Click(object sender, RoutedEventArgs e)
        {
            if (dispatcherTimer.IsEnabled)
            {
                dispatcherTimer.IsEnabled = false;
                dispatcherTimer.Stop();
            }
            else
            {
                dispatcherTimer.IsEnabled = true;
                dispatcherTimer.Start();
                vreme = DateTime.Now;
            }
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            vreme = (DateTime)datePicker.SelectedDate;
            vreme = vreme.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute);
            CalculateYearPosition();
        }

        public void CalculateYearPosition()
        {  // 2020 year
            mercur.currenPosition = 274.19 + ((360 / 0.246) * (vreme.Year - 2020));
            venera.currenPosition = 374.22 + ((360 / 0.615) * (vreme.Year - 2020));
            zemlja.currenPosition = 101.01 + ((360 / 0.99) * (vreme.Year - 2020));
            mars.currenPosition = 238.21 + ((360 / 1.88) * (vreme.Year - 2020));
            jupiter.currenPosition = 276.40 + ((360 / 11.86) * (vreme.Year - 2020));
            saturn.currenPosition = 291.23 + ((360 / 29.46) * (vreme.Year - 2020));
            uran.currenPosition = 32.42 + ((360 / 84.01) * (vreme.Year - 2020));
            neptun.currenPosition = 346.16 + ((360 / 164.79) * (vreme.Year - 2020));
            pluton.currenPosition = 292.23 + ((360 / 248.5) * (vreme.Year - 2020));         
        }
    }
}
