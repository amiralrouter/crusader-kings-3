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
            LoadTraits();
            Int64 aob_root_char = ((long)Memory.baseAddress + 0x969190);

            // create a new player with default baseAddress
            Int64 main_player_base_address = Memory.getInt64(aob_root_char + Memory.getInt(aob_root_char + 0x0B) + 0x0B + 0x04);
            MainPlayer.player = new Player() { base_address = main_player_base_address };
            //MainPlayer.player.base_address = Memory.getInt64(aob_root_char + Memory.getInt(aob_root_char + 0x0B) + 0x0B + 0x04);
             

            SelectedPlayer.player = new Player();
        }


        public void LoadTraits() {
            Int64 aob_trait_list = ((long)Memory.baseAddress + 0x11BF196);

            Int64 pTraitArena = Memory.getInt64(aob_trait_list + Memory.getInt(aob_trait_list + 0x0F) + 0x0F + 0x04);
            Int64 pTraitList = Memory.getInt64(pTraitArena + 0xA0);
            int pTraitCount = Memory.getInt(pTraitArena + 0xAC);
            string asd = "";
            for (int i = 0; i < pTraitCount; i++) {
                Int64 pointer = Memory.getInt64(pTraitList + i * 8);
                string id = Memory.getText(pointer + 0x18);
                Utils.Traits.Add(new Trait(id));
                asd += id + "\n";
            }
             
        }
    }
}
