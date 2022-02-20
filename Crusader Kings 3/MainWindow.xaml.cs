using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Crusader_Kings_3 {
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {

            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri("..\\Locales\\"+ Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName +".xaml", UriKind.Relative);
            dict.Source = new Uri("..\\Locales\\en.xaml", UriKind.Relative);
            this.Resources.MergedDictionaries.Add(dict);
             

            InitializeComponent();









            Memory.Connect();

            Int64 aob_root_char = ((long)Memory.baseAddress + 0x969190);
            Int64 aob_trait_list =  ((long)Memory.baseAddress + 0x11BF196);


            Int64 aob_trait_listx = ((long)Memory.baseAddress + 0x11BF196);

            Int64 pTraitArena = Memory.getInt64(aob_trait_list + Memory.getInt(aob_trait_list + 0x0F) + 0x0F + 0x04);
            Int64 pTraitList = Memory.getInt64(pTraitArena + 160);
            int pTraitCount = Memory.getInt(pTraitArena + 172);
     
            for (int i = 0; i < pTraitCount; i++) {
                Int64 pTrait = Memory.getInt64(pTraitList + i * 8);
                Int64 pTraitID = Memory.getInt64(pTrait + 16);
                int size = Memory.getInt(pTrait + 40);
                string traitName = Memory.getString(Memory.getInt(pTrait + 40) < 16 ? pTrait + 24 : Memory.getInt64(pTrait + 24), 64);
      
            }

            MainPlayer.player = new Player();
            MainPlayer.player.base_address = Memory.getInt64(aob_root_char + Memory.getInt(aob_root_char + 0x0B) + 0x0B + 0x04);
             

            SelectedPlayer.player = new Player();
        }
    }
}
