using RandomPicker.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RandomPicker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        #region Defaultvalue
        private ObservableCollection<Member> memberlist;

        public  ObservableCollection<Member> MemberList
        {
            get { return memberlist; }
            set { memberlist = value; }
        }

        private ObservableCollection<Member> toplist;

        public ObservableCollection<Member> TopList
        {
            get { return toplist; }
            set { toplist = value; }
        }


        DispatcherTimer dispatcherTimer1 = new DispatcherTimer();
        DateTimeOffset startTime;
        DateTimeOffset lastTime;
        DateTimeOffset stopTime;
        
        int timesTicked = 1;
        int timesToTick = 10;
        int index;
        bool firstimestart=true;
        bool firstimeadd = true;
        bool looptop = false;
        #endregion

        

        void dispatcherTimer_Tick(object sender, object e)
        {
            randomlist(memberlist);
        }
     

        public MainPage()
        {
            CreateList();
            CreateTopList();
            this.InitializeComponent();
            combox.ItemsSource = memberlist;
            namelist.ItemsSource = memberlist;
            toplistview.ItemsSource = toplist;
        }

        #region Events

        private void start_click(object sender, RoutedEventArgs e)
        {
            if(firstimestart)
            {
                log.Text += "Starting......\n";
                firstimestart = false;
            }               
            DispatcherTimerSetup(dispatcherTimer1);
            startbtn.IsEnabled = false;
            
        }

        private void pause_click(object sender, RoutedEventArgs e)
        {
            startbtn.IsEnabled = true;
            DispatcherTimerStop(dispatcherTimer1);
            log.Text += memberlist[index].Name + "已中奖，来个节目呗！\n";
            memberlist.RemoveAt(index);  
            
        }

        private void remove_click(object sender, RoutedEventArgs e)
        {
            memberlist.RemoveAt(combox.SelectedIndex);
        }

        private async void add_click(object sender, RoutedEventArgs e)
        {
            toplist.Add(memberlist[combox.SelectedIndex]);
        }

        private void switch_click(object sender, RoutedEventArgs e)
        {
            namelist.Visibility = Visibility.Visible;
            toplistview.Visibility = Visibility.Collapsed;
        }

        #endregion


        #region HelperClass
        void randomlist(ObservableCollection<Member> list)
        {
            Random rnd = new Random();
            int maxvalue = list.Count;
            index = rnd.Next(maxvalue);
            NameList.Text = list[index].Name;
        }

        void CreateList()
        {
            ObservableCollection<Member> templist = new ObservableCollection<Member>();
            templist.Add(new Member { Alias="v-chli1",   Name="Roy Li" });
            templist.Add(new Member { Alias = "v-anqche", Name = "Annie Chen" });
            templist.Add(new Member { Alias = "v-jiacch", Name = "Akira Chen" });
            templist.Add(new Member { Alias = "v-doxie", Name = "Dongwei Xie" });
            //templist.Add(new Member { Alias = "v-barryw", Name = "Barry Wang" });
            templist.Add(new Member { Alias = "v-zhumin", Name = "Nico Zhu" });
            templist.Add(new Member { Alias = "v-liuson", Name = "Breeze Liu" });
            templist.Add(new Member { Alias = "v-zhendw", Name = "Zhendong Wu" });
            templist.Add(new Member { Alias = "v-linfen", Name = "Grace Feng" });
            templist.Add(new Member { Alias = "v-shenya", Name = "York Shen" });
            templist.Add(new Member { Alias = "v-jizuo", Name = "Jay Zuo" });
            templist.Add(new Member { Alias = "v-luting", Name = "Land Lu" });
            templist.Add(new Member { Alias = "v-luhan", Name = "Rita Han" });
            templist.Add(new Member { Alias = "v-liujxu", Name = "Michael Xu" });
            templist.Add(new Member { Alias = "v-yepa", Name = "Jason Pan" });
            templist.Add(new Member { Alias = "v-xunwu", Name = "Sunteen Wu" });
            templist.Add(new Member { Alias = "v-mixia", Name = "Cole Xia" });
            templist.Add(new Member { Alias = "v-lchunx", Name = "Kevin Li" });
            templist.Add(new Member { Alias = "v-wngwei", Name = "Wei Wang" });
            templist.Add(new Member { Alias = "v-haolv", Name = "Joe Lv" });
            memberlist = templist;
        }

        void CreateTopList()
        {
            ObservableCollection<Member> templist = new ObservableCollection<Member>();
            toplist = templist;
        }

        public void DispatcherTimerSetup(DispatcherTimer dispatcher)
        {
            dispatcher.Tick += dispatcherTimer_Tick;
            dispatcher.Interval = new TimeSpan(0, 0, 0, 0, 200);
            startTime = DateTimeOffset.Now;
            lastTime = startTime;
            dispatcher.Start();
        }

        public void DispatcherTimerStop(DispatcherTimer dispatcher)
        {
            dispatcher.Stop();
        }
        #endregion
    }
}
